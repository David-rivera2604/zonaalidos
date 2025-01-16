using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class VariacionesController : Controller
    {
        public ActionResult MapfreMas()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult MapfreMasOld()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult MapfreMasPlus()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

    }
}