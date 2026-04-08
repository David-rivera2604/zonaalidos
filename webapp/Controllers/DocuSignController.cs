using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class DocuSignController : Controller
    {
        public ActionResult Notify()
        {
            return View();
        }
    }
}