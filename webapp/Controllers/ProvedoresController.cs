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
    public class ProvedoresController : Controller
    {
        // GET: Provedores
       
        public ActionResult ConsultasGastosMedicos()
        {
            return View();
        }
    }
}