using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class PurdyController : Controller
    {
        public ActionResult Panel()
        {
            return View();
        }
    }
}