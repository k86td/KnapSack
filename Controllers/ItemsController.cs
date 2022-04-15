using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using KnapSack.Utilities;
using KnapSack.Models;

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

        public ViewResult Details (int id)
        {
            Item toDisplay = DB.Items.Where(el => el.idItem == id).First();
            return View(toDisplay);
        }
    }
}