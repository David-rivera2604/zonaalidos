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
    public class GeneralController : Controller
    {
        public ActionResult Lookup()
        {
            return View();
        }

        public ActionResult LookupMaster()
        {
            return View();
        }

        public ActionResult Navigation()
        {
            return View();
        }

        public ActionResult Visualizations()
        {
            return View();
        }
        public ActionResult VisualizationsEdtForm()
        {
            return View();
        }

        public ActionResult Template()
        {
            return View();
        }

        public ActionResult PaymentSettings()
        {
            return View();
        }
        
        public ActionResult ColorTenant()
        {
            return View();
        }
        public ActionResult Administration()
        {
            return View();
        }
        public ActionResult MantenimientoInicio()
        {
            return View();
        }
    }
}