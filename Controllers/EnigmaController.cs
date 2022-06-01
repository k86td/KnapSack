using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnapSack.Models;


namespace KnapSack.Controllers
{
    public class EnigmaController : Controller
    {
        KnapsackDBEntities DB = new KnapsackDBEntities();
        Random rdm = new Random();

        // GET: Enigma
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetQuestion()
        {
            var questions = DB.Questions.ToList();

            if (questions.Count() != 0)
            {
                var questionTiree = questions[rdm.Next(questions.Count())];
                ViewBag.reponses = DB.Reponses.Where(r => r.IdQuestion == questionTiree.Id).ToList();
                return View("Question", questionTiree);
            }
            return RedirectToAction("Index", "Items");
        }

        public ActionResult VerifReponse(int idReponse)
        {
            var reponse = DB.Reponses.Find(idReponse);
            var currentPlayer = OnlinePlayers.GetSessionUser();
            int montantAjout = 0;
            if(reponse.Question.Difficulte == 1)
            {
                montantAjout = 600;
            }
            else if(reponse.Question.Difficulte == 2)
            {
                montantAjout = 800;
            }
            else if(reponse.Question.Difficulte == 3)
            {
                montantAjout = 1000;
            }
            if (reponse.Vrai)
            {
                DB.AddCaps(montantAjout, currentPlayer.idJoueur);
            }
            return View("VerificationReponse", reponse);
        }
    }
}