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
        public static Joueur GetJoueur(this KnapSackDbEntities DB, LoginCredential loginCredential)
        {
            Joueur user = DB.Joueurs.Where(u => (u.alias.ToLower() == loginCredential.Alias.ToLower()) &&
                                            (u.password == Encoding.UTF8.GetBytes(loginCredential.Password)))
                                .FirstOrDefault();
            return user;
        }
    }
}