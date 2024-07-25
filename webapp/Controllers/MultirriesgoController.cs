using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class MultirriesgoController : Controller
    {
        public ActionResult Cotizacion()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult Emision()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

    }
}