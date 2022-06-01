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
            Question questionTiree;
            if (questions.Count() > 0)
            {
                questionTiree = questions[rdm.Next(questions.Count())];
                ViewBag.reponses = DB.Reponses.Where(r => r.IdQuestion == questionTiree.Id).ToList();
                return View("Question", questionTiree);
            }

            return View("Question", null);
        }

        public ActionResult VerifReponse(int idReponse)
        {
            var reponse = DB.Reponses.Find(idReponse);
            return View("VerificationReponse", reponse);
        }
    }
}