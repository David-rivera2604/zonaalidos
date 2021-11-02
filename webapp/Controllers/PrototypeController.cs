using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class PrototypeController : Controller
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

        public ActionResult Producto()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
    }
}