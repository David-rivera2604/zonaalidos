using Architect.API.Core.Security;
using aliados.Filters;
using Microsoft.Ajax.Utilities;
using System.Web.Mvc;
using System.Web.Routing;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class MultirriesgoController : Controller
    {
        public ActionResult Cotizacion()
        {
            return View();
        }

        public ActionResult Solicitud()
        {
            RouteValueDictionary routerValues = new RouteValueDictionary();
            Request.QueryString.AllKeys.ForEach(key => routerValues.Add(key, Request.QueryString[key]));

            return this.RedirectToAction("Emision", "Multirriesgo", routerValues);
        }

        public ActionResult Emision()
        {
            return View();
        }

    }
}