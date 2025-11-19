using Architect.API.Core.Contracts.Security;
using Architect.Utilities.Extensions;
using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;

namespace Architect.API.Core.Security
{
    /// <summary>
    /// Atributo para controladores MVC que valida la existencia y caducidad del token de autenticación.
    /// Si el token no es válido o está caducado, redirige automáticamente al login.
    /// Además, establece el contexto del usuario (User.Principal) para que esté disponible en el controlador.
    /// </summary>
    public sealed class IsConnectedAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// URL de redirección al login. Se puede configurar en web.config con la clave "Security.Login.RedirectUrl".
        /// Por defecto usa "/Security/Login".
        /// </summary>
        private string LoginUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["Security.Login.RedirectUrl"] ?? "/Security/Login";
            }
        }

        /// <summary>
        /// Timeout por defecto de sesión en minutos.
        /// </summary>
        private double SessionTimeout
        {
            get
            {
                string timeoutConfig = ConfigurationManager.AppSettings["Session.Timeout"];
                if (double.TryParse(timeoutConfig, out double timeout))
                {
                    return timeout;
                }
                return 30; // Default: 30 minutos
            }
        }

        /// <summary>
        /// Se ejecuta antes de la acción del controlador para validar el token.
        /// </summary>
        /// <param name="filterContext">Contexto del filtro.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Verificar si es endpoint IsLive - no requiere validación
            if (IsLiveEndpoint(filterContext))
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            // ========================================================================
            // ✅ VERIFICAR SI YA EXISTE UN USUARIO AUTENTICADO EN EL CONTEXTO
            // ========================================================================
            if (HttpContext.Current?.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // Ya hay un usuario autenticado - continuar con la ejecución
                base.OnActionExecuting(filterContext);
                return;
            }

            // Extraer y validar token
            Core.Contracts.Security.Token tokenInfo = null;
            string authenticationToken = null;

            // Intentar obtener token del Authorization header (peticiones AJAX)
            string authHeader = filterContext.HttpContext.Request.Headers["Authorization"];

            // Si no hay header Authorization, intentar obtener de la cookie (navegación MVC)
            if (string.IsNullOrWhiteSpace(authHeader))
            {
                var authCookie = filterContext.HttpContext.Request.Cookies["AuthToken"];
                if (authCookie != null && !string.IsNullOrWhiteSpace(authCookie.Value))
                {
                    authHeader = authCookie.Value;
                }
            }

            // Si no hay token ni AccessKey
            if (string.IsNullOrWhiteSpace(authHeader) && 
                filterContext.HttpContext.Request.Headers["_AccessKey_"] == null)
            {
                // No hay ningún tipo de autenticación - redirigir a login
                RedirectToLogin(filterContext, "No se proporcionó token de autenticación");
                return;
            }

            // Extraer token del Authorization header, cookie o AccessKey
            if (!string.IsNullOrWhiteSpace(authHeader))
            {
                try
                {
                    // Extraer token del header Authorization (formato: "Bearer {token}")
                    if (authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    {
                        authenticationToken = authHeader.Substring(7);
                    }
                    else
                    {
                        authenticationToken = authHeader;
                    }

                    tokenInfo = Token.Info(authenticationToken);
                }
                catch (Microsoft.IdentityModel.Tokens.SecurityTokenExpiredException)
                {
                    RedirectToLogin(filterContext, "El token ha expirado");
                    return;
                }
                catch (Exception)
                {
                    RedirectToLogin(filterContext, "Token inválido");
                    return;
                }
            }
            else
            {
                // Extraer AccessKey
                authenticationToken = filterContext.HttpContext.Request.Headers["_AccessKey_"];
                try
                {
                    tokenInfo = Token.AccessKeyInfo(authenticationToken);
                    if (tokenInfo == null || tokenInfo.UserId == 0)
                    {
                        RedirectToLogin(filterContext, "AccessKey inválido");
                        return;
                    }
                }
                catch (Exception)
                {
                    RedirectToLogin(filterContext, "Error al validar AccessKey");
                    return;
                }
            }

            if (tokenInfo == null)
            {
                RedirectToLogin(filterContext, "No se pudo obtener información del token");
                return;
            }

            // Validar expiración del token
            if (tokenInfo.Expires < DateTime.Now)
            {
                RedirectToLogin(filterContext, "El token ha expirado");
                return;
            }

            // Obtener y validar sesión
            Contracts.Security.Activity session = Session.Get(authenticationToken);
            
            if (session.IsEmpty())
            {
                RedirectToLogin(filterContext, "No existe una sesión activa para este token");
                return;
            }

            // Validar expiración de sesión por inactividad
            DateTime sessionExpiration = session.LastDateTime.AddMinutes(SessionTimeout);

            if (DateTime.Now >= sessionExpiration)
            {
                RedirectToLogin(filterContext, $"La sesión ha expirado por inactividad (timeout: {SessionTimeout} minutos)");
                return;
            }

            // ========================================================================
            // ✅ ESTABLECER EL CONTEXTO DEL USUARIO usando el extension method
            // ========================================================================
            tokenInfo.Assinged();

            // Refrescar sesión si hay referrer
            if (filterContext.HttpContext.Request.UrlReferrer != null)
            {
                Session.Refresh(authenticationToken, filterContext.HttpContext.Request.UrlReferrer.AbsoluteUri);
            }

            // Token y sesión válidos - continuar con la ejecución
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Redirige el request al login cuando el token no es válido.
        /// </summary>
        /// <param name="filterContext">Contexto del filtro.</param>
        /// <param name="reason">Razón de la redirección.</param>
        private void RedirectToLogin(ActionExecutingContext filterContext, string reason)
        {
            // Verificar si es una petición AJAX
            bool isAjaxRequest = filterContext.HttpContext.Request.IsAjaxRequest();

            if (isAjaxRequest)
            {
                // Para peticiones AJAX, devolver JSON con información de redirección
                filterContext.Result = new JsonResult
                {
                    Data = new
                    {
                        success = false,
                        message = reason,
                        redirectUrl = GetFullLoginUrl(filterContext),
                        requiresAuthentication = true
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                filterContext.HttpContext.Response.StatusCode = 401;
            }
            else
            {
                // Para peticiones web normales, hacer redirección
                string loginUrl = GetFullLoginUrl(filterContext);
                filterContext.Result = new RedirectResult(loginUrl);
            }
        }

        /// <summary>
        /// Obtiene la URL completa de login incluyendo parámetro de retorno.
        /// </summary>
        /// <param name="filterContext">Contexto del filtro.</param>
        /// <returns>URL completa del login.</returns>
        private string GetFullLoginUrl(ActionExecutingContext filterContext)
        {
            string currentUrl = filterContext.HttpContext.Request.Url.ToString();
            string encodedReturnUrl = HttpUtility.UrlEncode(currentUrl);
            
            // Construir URL de login con returnUrl
            string loginUrl = LoginUrl;
            
            // Agregar returnUrl como query parameter
            string separator = loginUrl.Contains("?") ? "&" : "?";
            return $"{loginUrl}{separator}returnUrl={encodedReturnUrl}";
        }

        /// <summary>
        /// Verifica si el endpoint actual es IsLive.
        /// </summary>
        /// <param name="filterContext">Contexto del filtro.</param>
        /// <returns>True si es endpoint IsLive.</returns>
        private bool IsLiveEndpoint(ActionExecutingContext filterContext)
        {
            string rawUrl = filterContext.HttpContext.Request.RawUrl;
            return rawUrl.EndsWith("/IsLive", StringComparison.OrdinalIgnoreCase) ||
                   rawUrl.EndsWith("v1/Security/IsLive", StringComparison.OrdinalIgnoreCase);
        }
    }
}
