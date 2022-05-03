using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using KnapSack.Utilities;
using KnapSack.Models;
using System.Data.Entity;

namespace KnapSack.Controllers
{
    public class ItemsController : Controller
    {
        readonly KnapsackDBEntities DB = new KnapsackDBEntities();

        // GET: Items
        public ActionResult Index()
        {
            // set all TypesItems inside the ViewBag for use inside Index page (for the search parameters)
            ViewBag.TypesItems = DB.TypesItems;
            return View();

        }

        public PartialViewResult GetItemsGrid (int[] typeFilterInclude = null)
        {
            var query =
                from items in DB.Items
                join typeItems in DB.TypesItems on items.idType equals typeItems.idType
                orderby typeItems.nomType, items.poid, items.prix
                select items;

            // if typeFilterInclude is defined
            if ((typeFilterInclude is null) == false)
                query = query.Where(el => typeFilterInclude.Contains(el.idType)); // filter the items for the specified idType

            return PartialView("_ItemsGridDisplay", query);
        }
        public ActionResult AddPanier(int? id)
        {
            int t = OnlinePlayers.GetSessionUser().idJoueur;
            Panier panier = new Panier();
            panier.idJoueur = OnlinePlayers.GetSessionUser().idJoueur;
            //panier.idJoueur = 8;
            panier.idItem = (int) id;
            if(DB.Paniers.Where(e => e.idItem == id && e.idJoueur == t).Count() == 0)
            {
                
                panier.qteItem = 1;
                DB.Paniers.Add(panier);
            }
            else
            {
                panier = DB.Paniers.Where(e => e.idItem == id && e.idJoueur == t).FirstOrDefault();
                panier.qteItem += 1;
                DB.Entry(panier).State = EntityState.Modified;
            }
            

            DB.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            Session["RatingFieldSortDir"] = true;
            Item item = DB.Items.Find(Id);
            if (item != null)
                return View(item);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCurrentUserRating(int itemId, int rating, string comment)
        {
            Rating itemRating = new Rating
            {
                idItem = itemId,
                idJoueur = OnlinePlayers.GetSessionUser().idJoueur,
                rating = rating,
                commentaire = comment,
            };

            DB.AddItemRating(itemRating);

            DB.Update_Items_Ratings();
            return View();
        }
        public ActionResult SortRatingsBy(string fieldToSort)
        {
            try
            {
                Session["RatingFieldToSort"] = fieldToSort;
                Session["RatingFieldSortDir"] = !(bool)Session["RatingFieldToSort"];
                return View();
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [AdminAccess]
        public ActionResult Create ()
        {
            return View(new Item());
        }

        [AdminAccess, HttpPost]
        public ActionResult Create (Item item)
        {
            DB.Items.Add(item);
            return RedirectToAction("Index");
        }
    }
}