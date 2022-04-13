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
        public ActionResult Index(string onlyTheseTypes = null)
        {
            var defaultQuery =
                from items in DB.Items
                join typeItems in DB.TypesItems on items.idType equals typeItems.idType
                orderby typeItems.nomType, items.poid, items.prix
                where typeItems.idType == 1 || typeItems.idType == 2
                select items;

            if (! (onlyTheseTypes is null))
            {
                
            }

            return View(defaultQuery);
        }
    }
}