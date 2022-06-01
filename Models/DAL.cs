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

        public static Joueur CreateJoueurFromCredentials(this KnapsackDBEntities DB, LoginCredentialCreate credential)
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

        public static Joueur GetJoueur(this KnapsackDBEntities DB, LoginCredential loginCredential)
        {
            Joueur user = DB.Joueurs.Where(u => (u.alias == loginCredential.Alias)).FirstOrDefault();
            return user;
        }

        public static Joueur FindUser(this KnapsackDBEntities DB, int id)
        {
            Joueur user = DB.Joueurs.Find(id);
            return user;
        }

        public static void DeleteCart(this KnapsackDBEntities DB, Joueur player)
        {
            var cartToDelete = DB.Paniers.Where(c => c.idJoueur == player.idJoueur);
            DB.Paniers.RemoveRange(cartToDelete);
            DB.SaveChanges();
        }

        public static void ModifyCartQuantityItem(this KnapsackDBEntities DB, Item item, Joueur player  , int newQuantity)
        {
            var itemToModify = DB.Paniers.Where(c => c.idJoueur == player.idJoueur && c.idItem == item.idItem).FirstOrDefault();
            itemToModify.qteItem = newQuantity;
            DB.Entry(itemToModify).State = EntityState.Modified;
            DB.SaveChanges();
        }

        public static List<Panier> FindCart(this KnapsackDBEntities DB, Joueur player)
        {
            var cart = DB.Paniers.Where(c => c.idJoueur == player.idJoueur).ToList();
            return cart;
        }

        public static float CalculeTotale(this KnapsackDBEntities DB, Joueur player)
        {
            List<Panier> panier = DB.Paniers.Where(e => e.idJoueur == player.idJoueur).ToList();
            float totale = 0;

            foreach (var item in panier)
            {
                Item nItem = DB.Items.Find(item.idItem);
                
                totale += (float)nItem.prix * item.qteItem;
            }

            return totale;
        }
        public static void BuyCart(this KnapsackDBEntities DB, Joueur player)
        {
            DB.Entry(player).State = EntityState.Modified;
            var cart = DB.FindCart(player);
            decimal totale = (decimal)DB.CalculeTotale(player);
            DB.AddToBackpack(player, cart);
            player.montantCaps -= totale;
            
            DB.SaveChanges();

            //OnlinePlayers.AddSessionUser(player.idJoueur);
        }
        
        public static void AddToBackpack(this KnapsackDBEntities DB, Joueur player, List<Panier> cart)
        {
            foreach(var item in cart)
            {
                var backpackItem = new Sac
                {
                    idItem = item.idItem,
                    idJoueur = player.idJoueur,
                    qteItem = item.qteItem
                };
                DB.Sacs.Add(backpackItem);
                DB.SaveChanges();
            }
        }

        public static Rating AddItemRating(this KnapsackDBEntities DB, Rating itemRating)
        {
            Rating existingItemRating = DB.Ratings.Where(r => r.idItem == itemRating.idItem && r.idJoueur ==
           itemRating.idJoueur).FirstOrDefault();
            if (existingItemRating != null)
            {
                existingItemRating.rating1 = itemRating.rating1;
                existingItemRating.commentaire = itemRating.commentaire;
                DB.Entry(existingItemRating).State = EntityState.Modified;
            }
            else
            {
                itemRating = DB.Ratings.Add(itemRating);
            }

            Rating toUpdate = existingItemRating == null ? itemRating : existingItemRating;

            DB.Entry(toUpdate.Item).State = EntityState.Modified;

            int averageRating = (int)Math.Round(toUpdate.Item.Ratings.Average(ob => ob.rating1));
            int ratingCount = toUpdate.Item.Ratings.Count();

            toUpdate.Item.rating = averageRating;
            toUpdate.Item.ratingCount = ratingCount;

            DB.SaveChanges();
            return itemRating;
        }

        public static bool CompileItemsRating(this KnapsackDBEntities DB, Item item)
        {
            DB.Entry(item).State = EntityState.Modified;
            int ratingsCount = 0;
            double ratingsTotal = 0;
            foreach (Rating rating in item.Ratings.ToList())
            {
                ratingsCount++;
                ratingsTotal += rating.rating1;
            }
            if (ratingsCount > 0)
            {
                item.rating = (int)Math.Round(ratingsTotal / ratingsCount);
                item.ratingCount = ratingsCount;
            }
            else
            {
                item.rating = 0;
                item.ratingCount = 0;
            }
            return true;
        }

        public static bool Update_Items_Ratings(this KnapsackDBEntities DB)
        {
            foreach (Item item in DB.Items.ToList())
            {
                DB.CompileItemsRating(item);
            }
            DB.SaveChanges();
            return true;
        }

        public static bool Remove_Rating(this KnapsackDBEntities DB, int itemId, int playerId)
        {
            var ratingToDelete = DB.Ratings.Where(r => r.idItem == itemId && r.idJoueur == playerId).FirstOrDefault();
            if (ratingToDelete != null)
            {
                DB.Ratings.Remove(ratingToDelete);
                DB.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool AddCaps(this KnapsackDBEntities DB,int montant, int playerId)
        {
            var player = DB.Joueurs.Find(playerId);
            if(player != null)
            {
                player.montantCaps += montant;
                DB.Entry(player).State = EntityState.Modified;
                DB.SaveChanges();
                return true;
            }
            return false;
        }
    }
}