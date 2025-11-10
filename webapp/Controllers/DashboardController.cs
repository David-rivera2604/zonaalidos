using Architect.API.Core.Security;
using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult Render()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
    }
}