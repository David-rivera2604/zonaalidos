using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class CoopeController : Controller
    {
        public ActionResult Index()
        {
            return this.RedirectToAction("Login", "Security", new { tenant = "Coopeservidores" });
        }

        public ActionResult Login()
        {
            return this.RedirectToAction("Login", "Security", new { tenant = "Coopeservidores" });
        }

    }
}