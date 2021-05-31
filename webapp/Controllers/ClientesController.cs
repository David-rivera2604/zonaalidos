using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class ClientesController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Login", "Security", new { tenant = "Clientes" });
        }
        public ActionResult Login()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Login", "Security", new { tenant = "Clientes" });
        }
        public ActionResult Acceso()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Login", "Security", new { tenant = "Clientes" });
        }
        public ActionResult Register()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Register", "Security", new { tenant = "Clientes" });
        }
        public ActionResult Registro()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Register", "Security", new { tenant = "Clientes" });
        }

    }
}