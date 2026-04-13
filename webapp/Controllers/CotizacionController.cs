using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class CotizacionController : Controller
    {
        public ActionResult Funerario()
        {
            return View();
        }

        public ActionResult Multirriesgo()
        {
            return View();
        }

        public ActionResult HogarTotal()
        {
            return View();
        }

        public ActionResult PolizaLider()
        {
            return View();
        }
        public ActionResult MapfreMas()
        {
            return View();
        }
        public ActionResult MapfreMasPlus()
        {
            return View();
        }

        public ActionResult Viajero()
        {
            return View();
        }

        public ActionResult SaldoDeudor()
        {
            return View();
        }

        public ActionResult Estudiantil()
        {
            return View();
        }
        public ActionResult AccidentesPersonales()
        {
            return View();
        }
    }
}