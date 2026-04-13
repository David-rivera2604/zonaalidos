using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class MapfreController : Controller
    {
        public ActionResult Index()
        {
            return this.RedirectToAction("Login", "Security", new { tenant = "Aliados" });
        }

        public ActionResult Login()
        {
            return this.RedirectToAction("Login", "Security", new { tenant = "Aliados" });
        }

    }
}