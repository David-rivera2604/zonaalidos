using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class PagosController : Controller
    {

        public ActionResult Resultado()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
    }
}