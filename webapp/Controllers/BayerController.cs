using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class BayerController : Controller
    {
        public ActionResult Index()
        {
            return this.RedirectToAction("Login", "Security", new { tenant = "Bayer" });
        }

        public ActionResult Login()
        {
            return this.RedirectToAction("Login", "Security", new { tenant = "Bayer" });
        }

        public ActionResult Acceso()
        {
            return this.RedirectToAction("Login", "Security", new { tenant = "Bayer" });
        }

        public ActionResult Register()
        {
            return this.RedirectToAction("Register", "Security", new { tenant = "Bayer" });
        }

        public ActionResult Registro()
        {
            return this.RedirectToAction("Register", "Security", new { tenant = "Bayer" });
        }

        public ActionResult Inclusion()
        {
            return View();
        }

        public ActionResult Carnet()
        {
            return View();
        }
    }
}