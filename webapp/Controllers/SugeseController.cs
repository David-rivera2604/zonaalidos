using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class SugeseController : Controller
    {
        public ActionResult Generador()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        [HttpPost]
        public JsonResult ProcesaArchivo(string modelo, int pediodoMensual, int pediodoTrimestral, int ano, string excelFileName, string internalFileName)
        {
            //var result = new Architect.Common.DataType.Result
            //{
            //    Success = false,
            //    Code = 0,
            //    Reason = string.Empty
            //};
            
            return Json("");
        }

        }
    }