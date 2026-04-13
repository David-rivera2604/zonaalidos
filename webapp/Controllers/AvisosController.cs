using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class AvisosController : Controller
    {
        public ActionResult Recibos()
        {
            return View();
        }
    }
}