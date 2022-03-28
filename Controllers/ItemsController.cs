using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using KnapSack.Models;

namespace KnapSack.Controllers
{
    public class ItemsController : Controller
    {
        KnapSackDbEntities DB = new KnapSackDbEntities();

        // GET: Items
        public ActionResult Index()
        {
            return View(DB.Items);
        }
    }
}