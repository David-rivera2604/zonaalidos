using Architect.API.Core.Security;
using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
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
        public ActionResult CasesAliados()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }


        public ActionResult Seguimiento_Al()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

    }
}