using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class InicioController : Controller
    {
        public ActionResult Agente()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

    }
}