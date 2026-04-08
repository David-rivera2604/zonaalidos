using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class VariacionesController : Controller
    {
        public ActionResult MapfreMas()
        {
            return View();
        }

        public ActionResult MapfreMasOld()
        {
            return View();
        }

        public ActionResult MapfreMasPlus()
        {
            return View();
        }

        public ActionResult HogarTotal()
        {
            return View();
        }
        
        public ActionResult Multirriesgo()
        {
            return View();
        }

        public ActionResult HogarTotalPlus()
        {
            return View();
        }

    }
}