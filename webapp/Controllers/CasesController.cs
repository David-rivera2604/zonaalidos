using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class CasesController : Controller
    {

        public ActionResult NewCase()
        {
            return View();
        }


        public ActionResult Case()
        {
            return View();
        }

        public ActionResult ProcessCase()
        {
            return View();
        }
        public ActionResult CasesAliados()
        {
            return View();
        }


        public ActionResult Seguimiento_Al()
        {
            return View();
        }

    }
}