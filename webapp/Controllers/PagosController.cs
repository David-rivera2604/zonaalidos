using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class PagosController : Controller
    {

        public ActionResult Resultado()
        {
            return View();
        }
    }
}