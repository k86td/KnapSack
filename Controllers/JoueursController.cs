using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnapSack.Models;

namespace KnapSack.Controllers
{
    public class JoueursController : Controller
    {
        KnapSackDbEntities DB = new KnapSackDbEntities();
        // GET: Joueurs
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Alias_isAvailable (string alias)
        {
            if (DB.Joueurs.Where(el => el.alias == alias).Count() > 0)
            {
                return Json(false);
            }

            return Json(true);
        }

        public ActionResult Login(string message)
        {
            ViewBag.Message = message;
            return View(new LoginCredential());
        }

        [HttpPost]
        public ActionResult Login(LoginCredential loginCredential)
        {
            if (ModelState.IsValid)
            {
                Joueur joueur = DB.GetJoueur(loginCredential);
                if (joueur == null)
                {
                    ModelState.AddModelError("Password", "Mot de passe incorrecte.");
                    return View(loginCredential);
                }
                if (OnlinePlayers.IsOnLine(joueur.idJoueur))
                {
                    ModelState.AddModelError("Alias", "Cet usager est déjà connecté.");
                    return View(loginCredential);
                }
                OnlinePlayers.AddSessionUser(joueur.idJoueur);
                return RedirectToAction("Index", "Items");
            }
            return View(loginCredential);
        }

        public ActionResult Logout()
        {
            OnlinePlayers.RemoveSessionUser();
            return RedirectToAction("Index", "Items");
        }


        public ActionResult Create ()
        {
            return View(new LoginCredential());
        }

        [HttpPost]
        public ActionResult Create (LoginCredential credential)
        {
            if (ModelState.IsValid == false)
                return View(credential);

            Joueur inserted = DB.CreateJoueurFromCredentials(credential);

            if (inserted is null)
                throw new Exception("Creation du joueur error! Le joueur est null");
            OnlinePlayers.AddSessionUser(inserted.idJoueur);

            return RedirectToAction("Index", "Items");
        }

        public ActionResult Backpack()
        {
            return View("Sac", DB.Sacs);
        }
    }
}