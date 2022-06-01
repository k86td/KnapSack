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
            int nbrQuestions = DB.Questions.Count();
            int idQuestion = rdm.Next(1, nbrQuestions);
            Question question = DB.Questions.Find(idQuestion);
            ViewBag.reponses = DB.Reponses.Where(r => r.IdQuestion == question.Id).ToList();
            return View("Question", question);
        }

        public ActionResult VerifReponse(int idQuestion, int idReponse)
        {
            var reponse = DB.Reponses.Find(idReponse);
            return View("VerificationReponse", reponse);
        }
    }
}