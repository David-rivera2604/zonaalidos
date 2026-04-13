using aliados.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [SetTheme]
    public class SugeseController : Controller
    {
        public ActionResult Generador()
        {
            return View();
        }

        public ActionResult Envio()
        {
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