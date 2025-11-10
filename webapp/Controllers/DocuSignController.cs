using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class DocuSignController : Controller
    {
        public ActionResult Notify()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
    }
}