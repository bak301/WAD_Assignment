using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Security;

namespace WAD_MVC.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult LogIn(string username, string pass)
        {
            var isValid = HomeController.Client.Login(username, pass);
            if (!isValid) return View();
            FormsAuthentication.SetAuthCookie(username, false);
            Debug.WriteLine("YAY !");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }
    }
}