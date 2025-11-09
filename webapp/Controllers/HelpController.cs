using Architect.API.Core.Security;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    public class HelpController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region General

        public ActionResult general_cambio_clave()
        {
            return View();
        }
        public ActionResult general_cerrar_sesion()
        {
            return View();
        }
        public ActionResult general_inicio_sesion()
        {
            return View();
        }
        public ActionResult general_restaurar_clave()
        {
            return View();
        }
        public ActionResult general_termino_sesion()
        {
            return View();
        }

        #endregion

        #region Póliza
        public ActionResult poliza_aceptar()
        {
            return View();
        }
        public ActionResult poliza_anular()
        {
            return View();
        }
        public ActionResult poliza_busqueda()
        {
            return View();
        }
        public ActionResult poliza_borrador()
        {
            return View();
        }
        public ActionResult poliza_emitir()
        {
            return View();
        }
        public ActionResult poliza_refundicion()
        {
            return View();
        }
        public ActionResult poliza_impresion()
        {
            return View();
        }
        public ActionResult poliza_modificar()
        {
            return View();
        }
        public ActionResult poliza_opciones()
        {
            return View();
        }
        public ActionResult poliza_revision()
        {
            return View();
        }
        #endregion

        #region Seguridad
        public ActionResult seguridad_usuarios()
        {
            return View();
        }
        #endregion
    }
}