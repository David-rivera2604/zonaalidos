using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class PurdyController : Controller
    {
        public ActionResult Panel()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
    }
}