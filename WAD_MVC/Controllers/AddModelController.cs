using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WAD_MVC.Controllers
{
    public class AddModelController : Controller
    {
        // GET: AddModel
        public ActionResult AddExam()
        {
            return View();
        }

        public ActionResult AddSubject()
        {
            return View();
        }


        // POST
        [HttpPost]
        public ActionResult AddExam(localhost.exam exam)
        {
            WAD_MVC.Controllers.HomeController.client.AddExam(exam);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult AddSubject(localhost.subject subject)
        {
            HomeController.client.AddSubject(subject);
            return RedirectToAction("Index", "Home");
        }
    }
}