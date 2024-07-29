using Microsoft.Ajax.Utilities;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

namespace aliados.Controllers
{
    public class MultirriesgoController : Controller
    {
        public ActionResult Cotizacion()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult Solicitud()
        {
            RouteValueDictionary routerValues = new RouteValueDictionary();
            Request.QueryString.AllKeys.ForEach(key => routerValues.Add(key, Request.QueryString[key]));

            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Emision", "Multirriesgo", routerValues);
        }

        public ActionResult Emision()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

    }
}