using Architect.API.Core.Security;
using aliados.Filters;
using Architect.Utilities.Extensions;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using System.Web.WebPages;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class InicioController : Controller
    {
        public ActionResult Agente()
        {
            if (!string.IsNullOrEmpty(Architect.Utilities.Helpers.Settings.StringValue("Message"))){
                ViewBag.AlertMessage = Architect.Utilities.Helpers.Settings.StringValue("Message");
            }
            return View();
        }

    }
}