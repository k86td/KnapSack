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
        readonly KnapSackDbEntities DB = new KnapSackDbEntities();

        // GET: Items
        public ActionResult Index()
        {
            // set all TypesItems inside the ViewBag for use inside Index page (for the search parameters)
            ViewBag.TypesItems = DB.TypesItems;
            return View();

        }

        public ActionResult Details(int id)
        {
            return View(DB.Items.Where(el => el.idItem == id).First());
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

        [RestoreModelStateFromTempData]
        public ActionResult GetSpecificForm (string formName)
        {
            try
            {
                return PartialView("SpecificsForm/" + formName);
            }
            catch (Exception)
            {
                return new EmptyResult();
            }
        }

        [PropagateModelStateFromTempData, AdminAccess]
        public ActionResult Create (int idType = 1)
        {
            ViewBag.selectList = SelectListItemConverter<TypesItem>.Convert(DB.TypesItems.ToList());

            // TODO implement getting all the 
            return View(new ItemSpecific<ISpecific>
            {
                Item = new Item
                {
                    idType = idType,
                    disponibilite = true,
                },
                Specifics = DB.GetISpecificFromId(idType),
            });
        }

        [HttpPost]
        [SetTempDataModelState, AdminAccess]
        public ActionResult CreateArmure ([Bind(Prefix = "Item")] Item item, Armure specific)
        {
            if (ModelState.IsValid)
            {
                DB.Armures.Add(specific);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create", "Items", new { idType = item.idType });
        }

        [HttpPost]
        [SetTempDataModelState, AdminAccess]
        public ActionResult CreateArme([Bind(Prefix = "Item")] Item item, Arme specific)
        {
            if (ModelState.IsValid)
            {
                DB.Armes.Add(specific);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create", "Items", new { idType = item.idType });
        }

        [HttpPost]
        [SetTempDataModelState, AdminAccess]
        public ActionResult CreateMedicament([Bind(Prefix = "Item")] Item item, Medicament specific)
        {
            if (ModelState.IsValid)
            {
                DB.Medicaments.Add(specific);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create", "Items", new { idType = item.idType });
        }

        [HttpPost]
        [SetTempDataModelState, AdminAccess]
        public ActionResult CreateNourriture([Bind(Prefix = "Item")] Item item)
        {
            if (ModelState.IsValid)
            {
                Item added = DB.Items.Add(item);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create", "Items", new { idType = item.idType });
        }

        [HttpPost]
        [SetTempDataModelState, AdminAccess]
        public ActionResult CreateMunition([Bind(Prefix = "Item")] Item item)
        {
            if (ModelState.IsValid)
            {
                Item added = DB.Items.Add(item);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create", "Items", new { idType = item.idType });
        }


    }
}