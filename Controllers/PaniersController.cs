using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnapSack.Models;
using System.Data.Entity;

namespace KnapSack.Controllers
{
    public class PaniersController : Controller
    {
        KnapsackDBEntities DB = new KnapsackDBEntities();
        // GET: Paniers

        public ActionResult Panier()
        {
            var t = OnlinePlayers.GetSessionUser();
            var panierList = DB.Paniers.Where(e => e.idJoueur == t.idJoueur);
            ViewBag.totale = DB.CalculeTotale(t);
            //List<Panier> panierList = DB.Paniers.Where(e => e.idJoueur == 8).ToList();
            return View(panierList);
        }

        public ActionResult ModifyQuantity(int idItem, int newQuantity)
        {
            var item = DB.Items.Where(i => i.idItem == idItem).FirstOrDefault();
            DB.ModifyCartQuantityItem(item, OnlinePlayers.GetSessionUser(), newQuantity);
            return RedirectToAction("Panier");
        }

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

        public ActionResult ModCart(int idItem, int qteItem)
        {
            Panier panier = DB.Paniers.Find(idItem);
            panier.qteItem = qteItem;
            DB.Entry(panier).State = EntityState.Modified;
            DB.SaveChanges();

            return RedirectToAction("Panier");
        }
    }
}