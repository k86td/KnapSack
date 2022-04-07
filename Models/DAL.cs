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
        public static Joueur CreateJoueurFromCredentials(this KnapSackDbEntities DB, LoginCredential credential)
        {
            try
            {
                Joueur toInsert = new Joueur(credential);

                DB.Joueurs.Add(toInsert);
                DB.SaveChanges();
                return toInsert;
            }
            catch
            {
                return null;
            }
        }

        public static Joueur GetJoueur(this KnapSackDbEntities DB, LoginCredential loginCredential)
        {
            Joueur user = DB.Joueurs.Where(u => (u.alias == loginCredential.Alias)).FirstOrDefault();
            return user;
        }

        public static Joueur FindUser(this KnapSackDbEntities DB, int id)
        {
            Joueur user = DB.Joueurs.Find(id);
            return user;
        }

        public static void AddItemToCart(this KnapSackDbEntities DB, Item item, Joueur player)
        {
            Panier existingCartItem = DB.Paniers.Where(c => c.idJoueur == player.idJoueur && c.idItem == item.idItem).FirstOrDefault();
           
            if (existingCartItem == null) {
                Panier cartItem = new Panier
                {
                    idItem = item.idItem,
                    idJoueur = player.idJoueur,
                    qteItem = 1
                };
                DB.Paniers.Add(cartItem);
                DB.SaveChanges();
            }
            else
            {
                DB.ModifyCartQuantityItem(item, player, (existingCartItem.qteItem + 1));
            }
        }

        public static void DeleteCart(this KnapSackDbEntities DB, Joueur player)
        {
            var cartToDelete = DB.Paniers.Where(c => c.idJoueur == player.idJoueur);
            DB.Paniers.RemoveRange(cartToDelete);
            DB.SaveChanges();
        }

        public static void ModifyCartQuantityItem(this KnapSackDbEntities DB, Item item, Joueur player  , int newQuantity)
        {
            var itemToModify = DB.Paniers.Where(c => c.idJoueur == player.idJoueur && c.idItem == item.idItem).FirstOrDefault();
            itemToModify.qteItem = newQuantity;
            DB.Entry(itemToModify).State = EntityState.Modified;
            DB.SaveChanges();
        }

        public static List<Panier> FindCart(this KnapSackDbEntities DB, Joueur player)
        {
            var cart = DB.Paniers.Where(c => c.idJoueur == player.idJoueur).ToList();
            return cart;
        }
    }
}