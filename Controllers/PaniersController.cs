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
            return View("ViewName", DB.Paniers);
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

        public ActionResult DeleteCart()
        {
            DB.DeleteCart(OnlinePlayers.GetSessionUser());
            return RedirectToAction("Index", "Items");
        }
    }
}