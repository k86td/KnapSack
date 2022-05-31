using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnapSack.Models
{
    public static class OnlinePlayers
    {
        private static List<int> PlayersId
        {
            get
            {
                if (HttpRuntime.Cache["OnLinePlayers"] == null)
                    HttpRuntime.Cache["OnLinePlayers"] = new List<int>();
                return (List<int>)HttpRuntime.Cache["OnLinePlayers"];
            }
        }
        private static int CurrentPlayerId
        {
            get
            {
                try
                {
                    if (HttpContext.Current.Session["PlayerId"] != null)
                        return (int)HttpContext.Current.Session["PlayerId"];
                    return 0;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            set
            {
                if (value != 0)
                {
                    HttpContext.Current.Session.Timeout = 60;
                    HttpContext.Current.Session["PlayerId"] = value;
                }
                else
                {
                    if (HttpContext.Current != null)
                        HttpContext.Current.Session.Abandon();
                }
            }
        }
        private static string SerialNumber
        {
            get
            {
                if (HttpRuntime.Cache["OnLinePlayersSerialNumber"] == null)
                    RenewSerialNumber();
                return (string)HttpRuntime.Cache["OnLinePlayersSerialNumber"];
            }
            set
            {
                HttpRuntime.Cache["OnLinePlayersSerialNumber"] = value;
            }
        }
        public static bool NeedUpdate()
        {
            if (HttpContext.Current.Session["SerialNumber"] == null)
            {
                HttpContext.Current.Session["SerialNumber"] = SerialNumber;
                return true;
            }
            string sessionSerialNumber = (string)HttpContext.Current.Session["SerialNumber"];
            HttpContext.Current.Session["SerialNumber"] = SerialNumber;
            return SerialNumber != sessionSerialNumber;
        }
        public static void RenewSerialNumber()
        {
            SerialNumber = Guid.NewGuid().ToString();
        }
        public static void AddSessionUser(int playerId)
        {
            if (playerId != 0)
            {
                if (!PlayersId.Contains(playerId))
                {
                    PlayersId.Add(playerId);
                    CurrentPlayerId = playerId;
                    RenewSerialNumber();
                }
            }
        }
        public static void RemoveSessionUser()
        {
            if (CurrentPlayerId != 0)
            {
                PlayersId.Remove(CurrentPlayerId);
                CurrentPlayerId = 0;
                RenewSerialNumber();
            }
        }
        public static Joueur GetSessionUser()
        {
            if (CurrentPlayerId != 0)
            {
                KnapsackDBEntities DB = new KnapsackDBEntities();
                Joueur currentUser = DB.FindUser(CurrentPlayerId);
                DB.Dispose();
                return currentUser;
            }
            return null;
        }
        public static bool IsOnLine(int playerId)
        {
            return PlayersId.Contains(playerId);
        }
    }

    public class UserAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Joueur player = OnlinePlayers.GetSessionUser();
            if (OnlinePlayers.GetSessionUser() != null)
                return true;
            else
            {
                OnlinePlayers.RemoveSessionUser();
                httpContext.Response.Redirect("~/Accounts/Login?message=Acces illegal!");
            }
            return base.AuthorizeCore(httpContext);
        }
    }
    public class AdminAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Joueur sessionUser = OnlinePlayers.GetSessionUser();
            if (sessionUser != null && sessionUser.isAdmin)
                return true;
            else
            {
                OnlinePlayers.RemoveSessionUser();
                httpContext.Response.Redirect("~/Accounts/Login?message=Acces illegal!");
            }
            return base.AuthorizeCore(httpContext);
        }
    }
}