using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class CarroFácilController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Login", "Security", new { tenant = "CarroFácil" });
        }

        public ActionResult Login()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Login", "Security", new { tenant = "CarroFácil" });
        }

    }
}