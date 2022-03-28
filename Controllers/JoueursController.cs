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
                return RedirectToAction("Index", "Application");
            }
            return View(loginCredential);
        }
    }
}