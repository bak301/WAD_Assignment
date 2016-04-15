using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WAD_MVC.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult LogIn(string username, string pass)
        {
            bool isValid = HomeController.client.Login(username, pass);
            if (isValid)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                Debug.WriteLine("YAY !");
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }
    }
}