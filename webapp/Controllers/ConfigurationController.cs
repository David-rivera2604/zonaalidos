using Architect.Utilities.Helpers;
using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    /// <summary>
    /// Controller que expone la configuración de la aplicación desde el web.config.
    /// Proporciona valores de configuración para el cliente JavaScript (app.setting).
    /// No requiere autenticación para permitir que la aplicación cargue la configuración
    /// antes del proceso de login.
    /// </summary>
    public class ConfigurationController : Controller
    {
        /// <summary>
        /// Retorna las configuraciones de app.setting en formato JSON.
        /// Este endpoint permite centralizar la configuración en el web.config
        /// en lugar de mantenerla hardcoded en archivos JavaScript.
        /// </summary>
        /// <returns>
        /// Objeto JSON con las propiedades:
        /// - apibase: URL base de la API
        /// - apipath: Ruta completa de la API
        /// - basepath: Ruta base de la aplicación
        /// - viewpath: Ruta de las vistas
        /// - entityapi: URL del API de entidades
        /// - reportapi: URL del API de reportes
        /// </returns>
        /// <example>
        /// GET /Configuration/GetAppSettings
        ///
        /// JavaScript:
        /// fetch('/Aliados/Configuration/GetAppSettings')
        ///   .then(response => response.json())
        ///   .then(settings => {
        ///     app.setting.apibase = settings.apibase;
        ///     app.setting.apipath = settings.apipath;
        ///     // ... otros valores
        ///   });
        ///
        /// Retorna:
        /// {
        ///   "apibase": "https://localhost:44341",
        ///   "apipath": "https://localhost:44341/aliados/api/",
        ///   "basepath": "/Aliados/",
        ///   "viewpath": "http://localhost:8080/aliados/",
        ///   "entityapi": "https://appqa.mapfrecr.com/datapides/api/entity",
        ///   "reportapi": "https://appqa.mapfrecr.com/aliadoservreports"
        /// }
        /// </example>
        [HttpGet]
        public ActionResult GetAppSettings()
        {
            var settings = new
            {
                apiCore = "app.setting.api.core".StringValue() ?? string.Empty,
                apiProcess = "app.setting.api.process".StringValue() ?? string.Empty,
                apiPolicy = "app.setting.api.policy".StringValue() ?? string.Empty,
                apiTron = "app.setting.api.tron".StringValue() ?? string.Empty,
                apiSugese = "app.setting.api.sugese".StringValue() ?? string.Empty,
                apibase = "app.setting.apibase".StringValue() ?? string.Empty,
                apipath = "app.setting.apipath".StringValue() ?? string.Empty,
                basepath = "app.setting.basepath".StringValue() ?? string.Empty,
                viewpath = "app.setting.viewpath".StringValue() ?? string.Empty,
                entityapi = "app.setting.entityapi".StringValue() ?? string.Empty,
                reportapi = "app.setting.reportapi".StringValue() ?? string.Empty
            };

            return Json(settings, JsonRequestBehavior.AllowGet);
        }
    }
}