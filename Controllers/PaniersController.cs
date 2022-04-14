using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnapSack.Models;

namespace KnapSack.Controllers
{
    public class PaniersController : Controller
    {
        KnapSackDbEntities DB = new KnapSackDbEntities();
        // GET: Paniers

        public ActionResult Panier()
        {
            var t = OnlinePlayers.GetSessionUser();
            var panierList = DB.Paniers.Where(e => e.idJoueur == t.idJoueur);
            ViewBag.totale = DB.CalculeTotale(t);
            //List<Panier> panierList = DB.Paniers.Where(e => e.idJoueur == 8).ToList();
            return View(panierList);
        }

        public ActionResult AddToCart(Item item) 
        {
            DB.AddItemToCart(item, OnlinePlayers.GetSessionUser());
            return RedirectToAction("Panier");
        }

        public ActionResult ModifyQuantity(Item item, int newQuantity)
        {
            DB.ModifyCartQuantityItem(item, OnlinePlayers.GetSessionUser(), newQuantity);
            return RedirectToAction("Panier");
        }

        //public ActionResult BuyCart()
        //{

        //}
        public ActionResult Delete(int id)
        {
            int t = OnlinePlayers.GetSessionUser().idJoueur;
            Panier panier = DB.Paniers.Where(e => e.idItem == id && e.idJoueur == t).FirstOrDefault();
            DB.Paniers.Remove(panier);
            DB.SaveChanges();
            return RedirectToAction("Panier");
        }
        public ActionResult DeleteCart()
        {
            DB.DeleteCart(OnlinePlayers.GetSessionUser());
            return RedirectToAction("Index", "Items");
        }
        public ActionResult BuyCart()
        {
            var t = OnlinePlayers.GetSessionUser();
            DB.BuyCart(OnlinePlayers.GetSessionUser());


            DB.DeleteCart(OnlinePlayers.GetSessionUser());
            return RedirectToAction("Index", "Items");
        }
    }
}