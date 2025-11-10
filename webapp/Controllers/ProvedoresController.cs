using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class ProvedoresController : Controller
    {
        // GET: Provedores
       
        public ActionResult ConsultasGastosMedicos()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
    }
}