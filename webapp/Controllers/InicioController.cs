using Architect.Utilities.Extensions;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using System.Web.WebPages;

namespace aliados.Controllers
{
    public class InicioController : Controller
    {
        public ActionResult Agente()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];

            if (!string.IsNullOrEmpty(Architect.Utilities.Helpers.Settings.StringValue("Message"))){
                ViewBag.AlertMessage = Architect.Utilities.Helpers.Settings.StringValue("Message");
            }
            return View();
        }

    }
}