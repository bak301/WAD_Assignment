using System.Web.Mvc;
using WAD_MVC.localhost;

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
        public ActionResult AddExam(exam exam)
        {
            HomeController.Client.AddExam(exam);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult AddSubject(subject subject)
        {
            HomeController.Client.AddSubject(subject);
            return RedirectToAction("Index", "Home");
        }
    }
}