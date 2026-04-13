using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class CaturixController : Controller
    {
        public ActionResult Index()
        {
            return this.RedirectToAction("Login", "Security", new { tenant = "Caturix" });
        }

        public ActionResult Login()
        {
            return this.RedirectToAction("Login", "Security", new { tenant = "Caturix" });
        }
        public ActionResult Acceso()
        {
            return this.RedirectToAction("Login", "Security", new { tenant = "Caturix" });
        }

        public ActionResult Register()
        {
            return this.RedirectToAction("Register", "Security", new { tenant = "Caturix" });
        }
        public ActionResult Registro()
        {
            return this.RedirectToAction("Register", "Security", new { tenant = "Caturix" });
        }

        public ActionResult Inclusion()
        {
            return View();
        }
    }
}