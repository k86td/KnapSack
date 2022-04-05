using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

namespace KnapSack.Models
{
    public static class KnapsackDBDAL
    {
        public static bool CreateJoueurFromCredentials(this KnapSackDbEntities DB, LoginCredential credential)
        {
            try
            {
                Joueur toInsert = new Joueur(credential);

                DB.Joueurs.Add(toInsert);
                DB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Joueur GetJoueur(this KnapSackDbEntities DB, LoginCredential loginCredential)
        {
            Joueur user = DB.Joueurs.Where(u => (u.alias.ToLower() == loginCredential.Alias.ToLower()) &&
                                            (u.password == Encoding.UTF8.GetBytes(loginCredential.Password)))
                                .FirstOrDefault();
            return user;
        }

        public static Joueur FindUser(this KnapSackDbEntities DB, int id)
        {
            Joueur user = DB.Joueurs.Find(id);
            return user;
        }
    }
}