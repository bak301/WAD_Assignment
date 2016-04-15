using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WAD_MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public static localhost.Service client = new localhost.Service();
        // GET: Home

        private ActionResult GetTable()
        {
            var data = client.GetAllExam();
            var subjList = client.GetSubject();

            return View("Index", new Models.IndexModel
            {
                exam = data,
                subject = subjList
            });
        }

        public ActionResult Index()
        {
            return GetTable();
        }

        // ----------- POST -------------
        [HttpPost]
        public ActionResult Index(int exam_id)
        {
            localhost.exam exam;
            try {
                exam = client.GetAllExam().Single(e => e.id.Equals(exam_id));
            } catch (InvalidOperationException) {
                return GetTable();
            }
            TempData["exam"] = exam;
            return RedirectToAction("Delete");
        }

        public ActionResult Add()
        {
            string type = Request.Params["type"];
            if (type.Equals("exam"))
            {
                return RedirectToAction("AddExam", "AddModel");
            }
            else if (type.Equals("subject"))
            {
                return RedirectToAction("AddSubject", "AddModel");
            }
            return View();
        }


        // ----TABLE EVENT

        public ActionResult Delete()
        {
            var model = TempData["exam"] as localhost.exam;
            TempData["delete"] = model;
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(localhost.exam exam) {
            HomeController.client.DeleteExam(TempData["delete"] as localhost.exam);
            return RedirectToAction("Index");
        }
    }
}