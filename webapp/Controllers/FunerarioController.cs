using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class FunerarioController : Controller
    {

        public ActionResult Index()
        {
            return this.RedirectToAction("Cotizacion", "Funerario");
        }

        public ActionResult Cotizacion()
        {
            return View();
        }

    }
}