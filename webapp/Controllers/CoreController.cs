using Architect.API.Core.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    public class CoreController : Controller
    {
        
        public ActionResult History()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View("ChangeSet");
        }
        public ActionResult ChangeSet()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View("ChangeSet");
        }

        public ActionResult ClearCache()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Viewer", "Index");
        }
    }
}