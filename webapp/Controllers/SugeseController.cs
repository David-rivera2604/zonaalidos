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

        public ActionResult Envio()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        [HttpPost]
        public JsonResult ProcesaArchivo(string modelo, int pediodoMensual, int pediodoTrimestral, int ano, string excelFileName, string internalFileName)
        {
            return Json(Architect.Sugese.Manager.Instance.ProcesaArchivo(modelo, pediodoTrimestral, pediodoTrimestral, ano, excelFileName, internalFileName));
        }

        [HttpPost]
        public JsonResult EnviarArchivo(string modelo, int periodoMensual, int ano, string xmlFileName, string internalFileName)
        {
            return Json(Architect.Sugese.Manager.Instance.EnviarArchivo(modelo, periodoMensual, ano, xmlFileName, internalFileName));
        }
    }
}