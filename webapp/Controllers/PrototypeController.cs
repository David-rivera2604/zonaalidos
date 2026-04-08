using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class PrototypeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Render()
        {
            return View();
        }

        public ActionResult Producto()
        {
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }
    }
}