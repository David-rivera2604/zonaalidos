using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class ManualController : Controller
    {
        public ActionResult Siniestro()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
    }
}