using System.Web.Mvc;

namespace aliados.Controllers
{
    /// <summary>
    /// Entrega la entrada pública mínima que canjea el secreto de invitación antes de abrir el formulario protegido.
    /// No lee secretos, solicitudes ni datos personales desde la URL o el servidor MVC.
    /// </summary>
    public sealed class InsuredCompletionController : Controller
    {
        /// <summary>
        /// Muestra la página que extrae el secreto exclusivamente desde el fragmento del navegador.
        /// </summary>
        /// <returns>Vista pública sin el diseño ni la sesión del portal de agentes.</returns>
        [AllowAnonymous]
        public ActionResult Start()
        {
            return View();
        }
    }
}
