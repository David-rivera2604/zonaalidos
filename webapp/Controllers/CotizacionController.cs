using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class CotizacionController : Controller
    {
        public ActionResult Multirriesgo()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult HogarTotal()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult PolizaLider()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
        public ActionResult MapfreMas()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
    }
}