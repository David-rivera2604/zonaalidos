using aliados.Filters;
using Architect.Utilities.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    /// <summary>
    /// Controlador MVC que gestiona el flujo de autenticación federada mediante
    /// Okta usando OpenID Connect / OAuth 2.0 Authorization Code Flow.
    /// </summary>
    /// <remarks>
    /// Soporta múltiples tenants de la aplicación: aliados, purdy y mapfre.
    /// El tenant se determina desde la ruta base de entrada a la aplicación y se
    /// propaga a través de la sesión hasta completar el flujo de autenticación.
    ///
    /// Settings requeridos en Web.config:
    /// - Okta.Domain                : URL base del tenant de Okta (ej. https://your-org.okta.com).
    /// - Okta.ClientId              : ID de la aplicación registrada en Okta.
    /// - Okta.ClientSecret          : Secreto de cliente de la app registrada.
    /// - Okta.RedirectUri           : URI de redirección registrada en Okta.
    /// - Okta.AuthorizationServerId : ID del Authorization Server (típicamente "default").
    /// - Aliados.URL.Base           : URL base de la aplicación (usada para construir URIs absolutas).
    /// </remarks>
    [SetTheme]
    public class OktaController : Controller
    {
        /// <summary>
        /// Conjunto de tenants válidos aceptados por la aplicación.
        /// Cualquier valor fuera de esta lista es rechazado.
        /// </summary>
        private static readonly HashSet<string> AllowedTenants = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "clientes",
            "bayer"
        };

        /// <summary>
        /// Inicia el flujo OAuth 2.0 Authorization Code hacia Okta.
        /// Genera un valor <c>state</c> anti-CSRF, lo persiste en sesión junto con el tenant
        /// y redirige al endpoint de autorización de Okta.
        /// </summary>
        /// <param name="tenant">
        /// Nombre del tenant de la aplicación (aliados, purdy, mapfre).
        /// Se resuelve desde la ruta base de entrada. Si no es válido, se usa "mapfre" por defecto.
        /// </param>
        /// <returns>Redirección al endpoint de autorización de Okta.</returns>
        [HttpGet]
        public ActionResult Login(string tenant)
        {
            tenant = NormalizeTenant(tenant);
            if (string.IsNullOrEmpty(tenant))
            {
                tenant = "clientes";
            }

            string clientId = WebConfigurationManager.AppSettings["Okta.ClientId"];
            string redirectUri = ResolveRedirectUri();

            string state = Guid.NewGuid().ToString("N");
            Session["okta_state"] = state;
            Session["okta_tenant"] = tenant;

            string authorizeUrl =
                $"{GetAuthorizationServerBaseUrl()}/v1/authorize" +
                $"?client_id={Uri.EscapeDataString(clientId)}" +
                "&response_type=code" +
                $"&redirect_uri={Uri.EscapeDataString(redirectUri)}" +
                "&scope=openid%20profile%20email" +
                "&response_mode=query" +
                $"&state={Uri.EscapeDataString(state)}";

            return Redirect(authorizeUrl);
        }

        /// <summary>
        /// Recibe el código de autorización devuelto por Okta, lo intercambia
        /// por un <c>access_token</c>/<c>id_token</c>, extrae el email del JWT y autentica al usuario
        /// en la aplicación estableciendo la cookie de sesión.
        /// </summary>
        /// <returns>
        /// Página HTML intermedia que configura <c>localStorage</c> y redirige al destino final,
        /// o redirección a la página de acceso del tenant en caso de error.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult> Callback()
        {
            string tenant = NormalizeTenant(Session["okta_tenant"]?.ToString()) ?? "clientes";
            string aliadosBaseUrl = (WebConfigurationManager.AppSettings["Aliados.URL.Base"] ?? string.Empty).TrimEnd('/');
            string loginUrl = aliadosBaseUrl + "/Acceso/" + tenant;

            string error = Request.QueryString["error"];
            if (!string.IsNullOrEmpty(error))
            {
                string errorDescription = Request.QueryString["error_description"] ?? "Autenticación cancelada.";
                TempData["OktaError"] = errorDescription;
                return Redirect(loginUrl);
            }

            string code = Request.QueryString["code"];
            string state = Request.QueryString["state"];

            string storedState = Session["okta_state"]?.ToString();
            Session.Remove("okta_state");
            // ⚠️ NO eliminar okta_tenant aquí; se mantiene en sesión para el logout

            if (string.IsNullOrEmpty(code) || state != storedState)
            {
                TempData["OktaError"] = "La solicitud de autenticación no es válida.";
                Session.Remove("okta_tenant");
                return Redirect(loginUrl);
            }

            var tokens = await ExchangeCodeForTokensAsync(code);
            if (tokens == null)
            {
                TempData["OktaError"] = "No fue posible obtener el token de Okta. Intente nuevamente.";
                return Redirect(loginUrl);
            }

            string email = ExtractEmailFromJwt(tokens.IdToken)
                ?? ExtractEmailFromJwt(tokens.AccessToken);

            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                email = await GetEmailFromUserInfoAsync(tokens.AccessToken);
            }

            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                TempData["OktaError"] = "No se pudo obtener el correo del token de Okta.";
                return Redirect(loginUrl);
            }

            var token = new Architect.API.Core.Contracts.Security.Token();
            var response = Architect.API.Core.Business.Security.Accounts.AuthenticationByOkta(
                email,
                tenant,
                Architect.Utilities.Helpers.Connection.UserHostAddress(),
                Request.UserAgent,
                ref token);

            if (response.Reason.IsNotEmpty())
            {
                TempData["OktaError"] = response.Reason;
                return Redirect(aliadosBaseUrl + "/Acceso/" + tenant + "?fail=" + response.Reason);
            }

            Response.Cookies.Add(Architect.API.Core.Business.Security.Accounts.AssingedContext(Request, response, token));

            // Persistir id_token para logout federado
            if (!string.IsNullOrEmpty(tokens.IdToken))
                Session["okta_id_token"] = tokens.IdToken;

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
        /// Construye la URL de logout federado de Okta para el tenant indicado.
        /// </summary>
        /// <param name="tenant">Nombre del tenant para construir el <c>post_logout_redirect_uri</c>.</param>
        /// <param name="idTokenHint">id_token obtenido en el login (opcional pero recomendado por Okta).</param>
        /// <returns>
        /// URL absoluta del endpoint de logout de Okta con el
        /// <c>post_logout_redirect_uri</c> apuntando a la página de acceso del tenant.
        /// </returns>
        internal static string Logout(string tenant, string idTokenHint)
        {
            string aliadosBaseUrl = WebConfigurationManager.AppSettings["Aliados.URL.Base"];
            string postLogoutRedirect = aliadosBaseUrl + "/Acceso/" + tenant;

            string url = $"{GetAuthorizationServerBaseUrl()}/v1/logout" +
                $"?post_logout_redirect_uri={Uri.EscapeDataString(postLogoutRedirect)}";

            if (!string.IsNullOrEmpty(idTokenHint))
                url += $"&id_token_hint={Uri.EscapeDataString(idTokenHint)}";

            return url;
        }

        /// <summary>
        /// Intercambia el código de autorización OAuth 2.0 por tokens consumiendo
        /// el endpoint de token de Okta.
        /// </summary>
        /// <param name="code">Código de autorización devuelto por Okta tras la autenticación del usuario.</param>
        /// <returns>
        /// Objeto con <c>AccessToken</c> e <c>IdToken</c> si el intercambio fue exitoso; <c>null</c> en caso contrario.
        /// </returns>
        private async Task<OktaTokens> ExchangeCodeForTokensAsync(string code)
        {
            string clientId = WebConfigurationManager.AppSettings["Okta.ClientId"];
            string clientSecret = WebConfigurationManager.AppSettings["Okta.ClientSecret"];
            string redirectUri = ResolveRedirectUri();
            string tokenEndpoint = $"{GetAuthorizationServerBaseUrl()}/v1/token";

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
                return new OktaTokens
                {
                    AccessToken = json["access_token"]?.ToString(),
                    IdToken = json["id_token"]?.ToString()
                };
            }
        }

        /// <summary>
        /// Consulta el endpoint userinfo de Okta para obtener el email del usuario
        /// cuando no es posible extraerlo del JWT.
        /// </summary>
        private async Task<string> GetEmailFromUserInfoAsync(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
                return null;

            try
            {
                string userInfoEndpoint = $"{GetAuthorizationServerBaseUrl()}/v1/userinfo";

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                    HttpResponseMessage httpResponse = await client.GetAsync(userInfoEndpoint).ConfigureAwait(false);
                    string responseBody = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!httpResponse.IsSuccessStatusCode)
                        return null;

                    var json = JObject.Parse(responseBody);
                    return json["email"]?.ToString()
                        ?? json["preferred_username"]?.ToString();
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Decodifica el payload de un JWT y extrae el email del usuario.
        /// Intenta los claims en orden: <c>email</c>, <c>preferred_username</c>, <c>sub</c>.
        /// </summary>
        /// <param name="jwt">Token JWT en formato Base64Url.</param>
        /// <returns>Email del usuario si se encuentra en el payload; <c>null</c> en caso contrario.</returns>
        private static string ExtractEmailFromJwt(string jwt)
        {
            try
            {
                if (string.IsNullOrEmpty(jwt))
                    return null;

                string[] parts = jwt.Split('.');
                if (parts.Length < 2) return null;

                string padded = parts[1].PadRight(parts[1].Length + (4 - parts[1].Length % 4) % 4, '=');
                string payload = Encoding.UTF8.GetString(Convert.FromBase64String(padded));
                var claims = JObject.Parse(payload);

                return claims["email"]?.ToString()
                    ?? claims["preferred_username"]?.ToString()
                    ?? claims["sub"]?.ToString();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Construye la URL base del Authorization Server de Okta a partir de los settings.
        /// Formato: {Okta.Domain}/oauth2/{Okta.AuthorizationServerId}
        /// </summary>
        private static string GetAuthorizationServerBaseUrl()
        {
            string domain = (WebConfigurationManager.AppSettings["Okta.Domain"] ?? string.Empty).TrimEnd('/');
            string authServerId = WebConfigurationManager.AppSettings["Okta.AuthorizationServerId"];
            if (string.IsNullOrWhiteSpace(authServerId))
                authServerId = "default";

            return $"{domain}/oauth2/{authServerId}";
        }

        /// <summary>
        /// Devuelve el <c>redirect_uri</c> a usar contra Okta.
        /// Si <c>Okta.RedirectUri</c> en Web.config es relativo, se combina con
        /// <c>Aliados.URL.Base</c> para producir una URI absoluta tal como
        /// está registrada en Okta.
        /// </summary>
        private static string ResolveRedirectUri()
        {
            string redirectUri = (WebConfigurationManager.AppSettings["Okta.RedirectUri"] ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(redirectUri))
                return redirectUri;

            if (Uri.IsWellFormedUriString(redirectUri, UriKind.Absolute))
                return redirectUri;

            string baseUrl = (WebConfigurationManager.AppSettings["Aliados.URL.Base"] ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(baseUrl))
                return redirectUri;

            return $"{baseUrl.TrimEnd('/')}/{redirectUri.TrimStart('/')}";
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

        /// <summary>
        /// DTO interno para encapsular los tokens devueltos por el endpoint /token de Okta.
        /// </summary>
        private class OktaTokens
        {
            public string AccessToken { get; set; }
            public string IdToken { get; set; }
        }
    }
}
