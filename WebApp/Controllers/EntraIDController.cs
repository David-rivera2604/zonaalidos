using aliados.Filters;
using Architect.API.Core.Business;
using Architect.Utilities.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace aliados.Controllers
{
    /// <summary>
    /// Controlador MVC que gestiona el flujo de autenticación federada mediante
    /// Microsoft Entra ID (Azure AD) usando el protocolo OAuth 2.0 Authorization Code Flow.
    /// </summary>
    /// <remarks>
    /// Soporta múltiples tenants de la aplicación: aliados, purdy y mapfre.
    /// El tenant se determina desde la ruta base de entrada a la aplicación y se
    /// propaga a través de la sesión hasta completar el flujo de autenticación.
    ///
    /// Settings requeridos en Web.config:
    /// - EntraId.ClientId      : ID de la aplicación registrada en Entra ID.
    /// - EntraId.TenantId      : ID del directorio de Entra ID.
    /// - EntraId.ClientSecret  : Secreto de cliente de la app registrada.
    /// - EntraId.RedirectUri   : URI de redirección registrada en el portal de Entra ID.
    /// - Aliados.URL.Base      : URL base de la aplicación (usada para construir URIs absolutas).
    /// </remarks>
    [SetTheme]
    public class EntraIDController : Controller
    {
        /// <summary>
        /// Conjunto de tenants válidos aceptados por la aplicación.
        /// Cualquier valor fuera de esta lista es rechazado.
        /// </summary>
        private static readonly HashSet<string> AllowedTenants = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "aliados",
            "purdy",
            "mapfre"
        };

        /// <summary>
        /// Inicia el flujo OAuth 2.0 Authorization Code hacia Microsoft Entra ID.
        /// Genera un valor <c>state</c> anti-CSRF, lo persiste en sesión junto con el tenant
        /// y redirige al endpoint de autorización de Microsoft.
        /// </summary>
        /// <param name="tenant">
        /// Nombre del tenant de la aplicación (aliados, purdy, mapfre).
        /// Se resuelve desde la ruta base de entrada. Si no es válido, se usa "mapfre" por defecto.
        /// </param>
        /// <returns>Redirección al endpoint de autorización de Microsoft Entra ID.</returns>
        [HttpGet]
        public ActionResult Login(string tenant)
        {
            tenant = NormalizeTenant(tenant);
            if (string.IsNullOrEmpty(tenant))
            {
                tenant = "mapfre";
            }

            string clientId = WebConfigurationManager.AppSettings["EntraId.ClientId"];
            string tenantId = WebConfigurationManager.AppSettings["EntraId.TenantId"];
            string redirectUri = WebConfigurationManager.AppSettings["EntraId.RedirectUri"];

            string state = Guid.NewGuid().ToString("N");
            Session["entraid_state"] = state;
            Session["entraid_tenant"] = tenant;

            string authorizeUrl =
                $"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/authorize" +
                $"?client_id={Uri.EscapeDataString(clientId)}" +
                "&response_type=code" +
                $"&redirect_uri={Uri.EscapeDataString(redirectUri)}" +
                "&scope=openid%20profile%20email" +
                "&response_mode=query" +
                $"&state={Uri.EscapeDataString(state)}";

            return Redirect(authorizeUrl);
        }

        /// <summary>
        /// Recibe el código de autorización devuelto por Microsoft Entra ID, lo intercambia
        /// por un <c>access_token</c>, extrae el email del JWT y autentica al usuario
        /// en la aplicación estableciendo la cookie de sesión.
        /// </summary>
        /// <remarks>
        /// Flujo completo:
        /// 1. Valida el parámetro <c>state</c> anti-CSRF contra el valor guardado en sesión.
        /// 2. Intercambia el código por un access_token via <see cref="ExchangeCodeForTokenAsync"/>.
        /// 3. Extrae el email del JWT via <see cref="ExtractEmailFromJwt"/>.
        /// 4. Autentica al usuario en la aplicación via <c>AuthenticationByEntraId</c>.
        /// 5. Establece la cookie de sesión y redirige al <c>InitialPath</c> del usuario.
        ///
        /// En caso de error, redirige a la página de acceso del tenant con el parámetro <c>?fail=</c>.
        /// </remarks>
        /// <returns>
        /// Página HTML intermedia que configura <c>localStorage</c> y redirige al destino final,
        /// o redirección a la página de acceso del tenant en caso de error.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult> Callback()
        {
            string tenant = NormalizeTenant(Session["entraid_tenant"]?.ToString())
                ?? (NormalizeTenant(WebConfigurationManager.AppSettings["app.theme"]) ?? "mapfre");
            string loginUrl = "/" + tenant;

            string error = Request.QueryString["error"];
            if (!string.IsNullOrEmpty(error))
            {
                string errorDescription = Request.QueryString["error_description"] ?? "Autenticación cancelada.";
                TempData["EntraIdError"] = errorDescription;
                return Redirect(loginUrl);
            }

            string code = Request.QueryString["code"];
            string state = Request.QueryString["state"];

            string storedState = Session["entraid_state"]?.ToString();
            Session.Remove("entraid_state");
            // ⚠️ NO eliminar entraid_tenant aquí; se mantiene en sesión para el logout

            if (string.IsNullOrEmpty(code) || state != storedState)
            {
                TempData["EntraIdError"] = "La solicitud de autenticación no es válida.";
                Session.Remove("entraid_tenant"); // Limpiar si falla la validación
                return Redirect(loginUrl);
            }

            string accessToken = await ExchangeCodeForTokenAsync(code);
            if (string.IsNullOrEmpty(accessToken))
            {
                TempData["EntraIdError"] = "No fue posible obtener el token de Microsoft. Intente nuevamente.";
                return Redirect(loginUrl);
            }

            string email = ExtractEmailFromJwt(accessToken);
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                TempData["EntraIdError"] = "No se pudo obtener el correo del token de Microsoft.";
                return Redirect(loginUrl);
            }

            var token = new Architect.API.Core.Contracts.Security.Token();
            var response = Architect.API.Core.Business.Security.Accounts.AuthenticationByEntraId(
                email,
                tenant,
                Architect.Utilities.Helpers.Connection.UserHostAddress(),
                Request.UserAgent,
                ref token);

            if (response.Reason.IsNotEmpty())
            {
                TempData["EntraIdError"] = response.Reason;
                string aliadosBaseUrl = WebConfigurationManager.AppSettings["Aliados.URL.Base"];
                return Redirect(aliadosBaseUrl + "/Acceso/" + tenant + "?fail="+ response.Reason);
            }

            Response.Cookies.Add(Architect.API.Core.Business.Security.Accounts.AssingedContext(Request, response, token));

            string responseJson = Newtonsoft.Json.JsonConvert.SerializeObject(response);
            string basePath = Url.Content("~/");
            string redirectTo = response.InitialPath ?? "/";

            string html = $@"<!DOCTYPE html>
<html><head><meta charset=""utf-8""><title>Autenticando...</title></head>
<body>
<script>
(function() {{
    var data = {responseJson};
    if (data.Settings) {{
        data.Settings.forEach(function(item) {{ localStorage.setItem(item.Key, item.Value); }});
    }}
    localStorage.setItem('Username', data.UserName || '');
    localStorage.setItem('Tenant', data.Tenant || '');
    localStorage.setItem('Token', data.Token || '');
    localStorage.setItem('Roles', JSON.stringify(data.Roles || []));
    var now = new Date();
    localStorage.setItem('LastActivity', now);
    var expires = new Date();
    expires.setMinutes(expires.getMinutes() + parseInt(data.ExpiresIn || 30));
    localStorage.setItem('Expires', expires);
    window.location.replace('{basePath}' + '{redirectTo}');
}})();
</script>
</body></html>";

            return Content(html, "text/html");
        }

        /// <summary>
        /// Cierra la sesión del usuario local (cookie, FormsAuthentication, Session)
        /// y construye la URL de logout federado de Microsoft Entra ID.
        /// </summary>
        /// <param name="tenant">Nombre del tenant para construir el <c>post_logout_redirect_uri</c>.</param>
        /// <returns>
        /// URL absoluta del endpoint de logout de Microsoft Entra ID con el
        /// <c>post_logout_redirect_uri</c> apuntando a la página de acceso del tenant.
        /// </returns>
        internal static string Logout(string tenant)
        {
            string tenantId = WebConfigurationManager.AppSettings["EntraId.TenantId"];
            string aliadosBaseUrl = WebConfigurationManager.AppSettings["Aliados.URL.Base"];

            return $"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/logout" +
                $"?post_logout_redirect_uri={Uri.EscapeDataString(aliadosBaseUrl + "/Acceso/" + tenant)}";
        }

        /// <summary>
        /// Intercambia el código de autorización OAuth 2.0 por un <c>access_token</c>
        /// consumiendo el endpoint de token de Microsoft Entra ID.
        /// </summary>
        /// <param name="code">Código de autorización devuelto por Microsoft tras la autenticación del usuario.</param>
        /// <returns>
        /// El <c>access_token</c> JWT si el intercambio fue exitoso; <c>null</c> en caso contrario.
        /// </returns>
        private async Task<string> ExchangeCodeForTokenAsync(string code)
        {
            string tenantId = WebConfigurationManager.AppSettings["EntraId.TenantId"];
            string clientId = WebConfigurationManager.AppSettings["EntraId.ClientId"];
            string clientSecret = WebConfigurationManager.AppSettings["EntraId.ClientSecret"];
            string redirectUri = WebConfigurationManager.AppSettings["EntraId.RedirectUri"];
            string tokenEndpoint = $"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token";

            using (var client = new HttpClient())
            {
                var body = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("client_secret", clientSecret),
                    new KeyValuePair<string, string>("code", code),
                    new KeyValuePair<string, string>("redirect_uri", redirectUri),
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("scope", "openid profile email")
                });

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                HttpResponseMessage httpResponse = await client.PostAsync(tokenEndpoint, body).ConfigureAwait(false);
                string responseBody = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (!httpResponse.IsSuccessStatusCode)
                    return null;

                var json = JObject.Parse(responseBody);
                return json["access_token"]?.ToString();
            }
        }

        /// <summary>
        /// Decodifica el payload de un JWT y extrae el email del usuario.
        /// Intenta los claims en orden: <c>email</c>, <c>preferred_username</c>, <c>unique_name</c>.
        /// </summary>
        /// <param name="jwt">Token JWT en formato Base64Url.</param>
        /// <returns>Email del usuario si se encuentra en el payload; <c>null</c> en caso contrario.</returns>
        private static string ExtractEmailFromJwt(string jwt)
        {
            try
            {
                string[] parts = jwt.Split('.');
                if (parts.Length < 2) return null;

                string padded = parts[1].PadRight(parts[1].Length + (4 - parts[1].Length % 4) % 4, '=');
                string payload = Encoding.UTF8.GetString(Convert.FromBase64String(padded));
                var claims = JObject.Parse(payload);

                return claims["email"]?.ToString()
                    ?? claims["preferred_username"]?.ToString()
                    ?? claims["unique_name"]?.ToString();
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Normaliza y valida el nombre del tenant contra la lista de tenants permitidos.
        /// La comparación es insensible a mayúsculas/minúsculas.
        /// </summary>
        /// <param name="tenant">Nombre del tenant a validar.</param>
        /// <returns>
        /// El nombre del tenant en minúsculas si es válido;
        /// <c>null</c> si es nulo, vacío o no pertenece a <see cref="AllowedTenants"/>.
        /// </returns>
        internal static string NormalizeTenant(string tenant)
        {
            if (string.IsNullOrWhiteSpace(tenant))
                return null;

            var normalized = tenant.Trim().ToLowerInvariant();
            return AllowedTenants.Contains(normalized) ? normalized : null;
        }
    }
}
