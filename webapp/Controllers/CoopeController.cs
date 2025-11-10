using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class CoopeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Login", "Security", new { tenant = "Coopeservidores" });
        }

        public ActionResult Login()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Login", "Security", new { tenant = "Coopeservidores" });
        }

    }
}