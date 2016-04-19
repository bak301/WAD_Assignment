using System;
using System.Linq;
using System.Web.Mvc;
using WAD_MVC.localhost;
using WAD_MVC.Models;

namespace WAD_MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public static Service Client = new Service();
        // GET: Home

        private ActionResult GetTable()
        {
            var data = Client.GetAllExam();
            var subjList = Client.GetSubject();

            return View("Index", new IndexModel
            {
                Exam = data,
                Subject = subjList
            });
        }

        public ActionResult Index()
        {
            return GetTable();
        }

        // ----------- POST -------------
        [HttpPost]
        public ActionResult Index(int examId)
        {
            exam exam;
            try
            {
                exam = Client.GetAllExam().Single(e => e.id.Equals(examId));
            }
            catch (InvalidOperationException)
            {
                return GetTable();
            }
            TempData["exam"] = exam;
            return RedirectToAction("Delete");
        }

        public ActionResult Add()
        {
            var type = Request.Params["type"];
            if (type.Equals("exam"))
            {
                return RedirectToAction("AddExam", "AddModel");
            }
            if (type.Equals("subject"))
            {
                return RedirectToAction("AddSubject", "AddModel");
            }
            return View("Index");
        }


        // ----TABLE EVENT

        public ActionResult Delete()
        {
            var model = TempData["exam"] as exam;
            TempData["delete"] = model;
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(exam exam)
        {
            Client.DeleteExam(TempData["delete"] as exam);
            return RedirectToAction("Index");
        }
    }
}