using Architect.API.Core.Security;
using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    public class CaturixController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Login", "Security", new { tenant = "Caturix" });
        }

        public ActionResult Login()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Login", "Security", new { tenant = "Caturix" });
        }
        public ActionResult Acceso()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Login", "Security", new { tenant = "Caturix" });
        }

        public ActionResult Register()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Register", "Security", new { tenant = "Caturix" });
        }
        public ActionResult Registro()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Register", "Security", new { tenant = "Caturix" });
        }

        public ActionResult Inclusion()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
    }
}