using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class ClientesController : Controller
    {
        public ActionResult Index()
        {
            return this.RedirectToAction("Login", "Security", new { tenant = "Clientes" });
        }
        public ActionResult Login()
        {
            return this.RedirectToAction("Login", "Security", new { tenant = "Clientes" });
        }
        public ActionResult Acceso()
        {
            return this.RedirectToAction("Login", "Security", new { tenant = "Clientes" });
        }
        public ActionResult Register()
        {
            return this.RedirectToAction("Register", "Security", new { tenant = "Clientes" });
        }
        public ActionResult Registro()
        {
            return this.RedirectToAction("Register", "Security", new { tenant = "Clientes" });
        }
        public ActionResult CompraSegurosC()
        {
            return View();
        }
        public ActionResult CompraSegurosE()
        {
            return View();
        }
        public ActionResult Inicio()
        {
            return View();
        }

    }
}