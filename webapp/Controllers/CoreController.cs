using Architect.API.Core.Security;
using aliados.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class CoreController : Controller
    {
        
        public ActionResult History()
        {
            return View("ChangeSet");
        }
        public ActionResult ChangeSet()
        {
            return View("ChangeSet");
        }

        public ActionResult ClearCache()
        {
            return this.RedirectToAction("Viewer", "Index");
        }
    }
}