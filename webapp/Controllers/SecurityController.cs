using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class SecurityController : Controller
    {

        public ActionResult Mapfre()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View("Login");
        }

        public ActionResult Carrofácil()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Login", "Security", new { tenant = "Carrofácil" });
        }
        public ActionResult Coope()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Login", "Security", new { tenant = "Coopeservidores" });
        }
        public ActionResult Login()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult RoleMember()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
        public ActionResult Role()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View("RoleMember");
        }

        public ActionResult RoleMemberNavigation()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult UserMember()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult UserRoleMember()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult ChangePassword()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
        public ActionResult Integrate()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
    }
}