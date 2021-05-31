using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class CasesController : Controller
    {

        public ActionResult NewCase()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }


        public ActionResult Case()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult ProcessCase()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

    }
}