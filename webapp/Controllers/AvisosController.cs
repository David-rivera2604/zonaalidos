using Architect.API.Core.Security;
using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    public class AvisosController : Controller
    {
        public ActionResult Recibos()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
    }
}