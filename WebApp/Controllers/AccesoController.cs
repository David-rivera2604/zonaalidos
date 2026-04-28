using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    /// <summary>
    /// Controlador MVC que gestiona las vistas de acceso por tenant de la aplicación.
    /// Cada acción renderiza la vista de login correspondiente al tenant solicitado.
    /// </summary>
    /// <remarks>
    /// Las rutas de este controlador actúan como puntos de entrada por tenant:
    /// - /Acceso/Aliados  → vista de acceso para el tenant Aliados.
    /// - /Acceso/Purdy    → vista de acceso para el tenant Purdy.
    /// - /Acceso/Mapfre   → vista de acceso para el tenant Mapfre.
    ///
    /// El atributo <see cref="SetThemeAttribute"/> aplica el tema visual según el tenant activo.
    /// </remarks>
    [SetTheme]
    public class AccesoController : Controller
    {
        /// <summary>
        /// Muestra la vista de acceso para el tenant Aliados.
        /// </summary>
        /// <returns>Vista de acceso <c>Aliados.cshtml</c>.</returns>
        public ActionResult Aliados()
        {
            return View();
        }

        /// <summary>
        /// Muestra la vista de acceso para el tenant Purdy.
        /// </summary>
        /// <returns>Vista de acceso <c>Purdy.cshtml</c>.</returns>
        public ActionResult Purdy()
        {
            return View();
        }

        /// <summary>
        /// Muestra la vista de acceso para el tenant Mapfre.
        /// </summary>
        /// <returns>Vista de acceso <c>Mapfre.cshtml</c>.</returns>
        public ActionResult Mapfre()
        {
            return View();
        }
    }
}