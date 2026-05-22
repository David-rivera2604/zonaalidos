using aliados.Filters;
using Architect.API.Core.Business;
using Architect.API.Core.Business.Security;
using Architect.API.Core.Security;
using Architect.API.Tron.Business.Cotizacion;
using Architect.Utilities.Extensions;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    /// <summary>
    /// Controlador MVC para manejar las acciones relacionadas con la seguridad y autenticación de usuarios.
    /// Este controlador establece cookies de autenticación y contexto del usuario en el servidor.
    /// </summary>
    /// <remarks>
    /// A diferencia del controlador Web API de seguridad, este controlador MVC es stateful y:
    /// - Establece cookies de autenticación en el servidor
    /// - Configura el contexto del usuario mediante AssingedContext()
    /// - Maneja las vistas de login y páginas relacionadas con seguridad
    /// </remarks>
    [SetTheme]
    public class SecurityController : Controller
    {
        /// <summary>
        /// Autentica a un usuario mediante sus credenciales y establece el contexto de autenticación en el servidor.
        /// </summary>
        /// <param name="authenticationRequest">Objeto que contiene las credenciales del usuario (Tenant, Email, Password).</param>
        /// <returns>
        /// Retorna un objeto JSON con la respuesta de autenticación:
        /// - Si las credenciales son incorrectas: retorna el objeto con Reason conteniendo el mensaje de error
        /// - Si la autenticación es exitosa: retorna el objeto Context con el token y datos del usuario
        /// </returns>
        /// <remarks>
        /// Este método realiza las siguientes operaciones:
        /// 1. Valida que se hayan proporcionado los datos de autenticación
        /// 2. Llama al servicio de autenticación de forma sincrónica (preserva HttpContext)
        /// 3. Si es exitoso:
        ///    - Establece una cookie "AuthToken" con el token JWT
        ///    - Configura el contexto del usuario en el servidor mediante token.AssingedContext()
        ///    - Retorna el objeto Context directamente (sin wrapper)
        ///
        /// La cookie establecida permite que las navegaciones MVC subsecuentes puedan autenticar al usuario
        /// mediante el atributo [IsConnected] sin necesidad de enviar el token en headers.
        /// </remarks>
        /// <example>
        /// Ejemplo de uso desde JavaScript:
        /// <code>
        /// app.core.Post(app.setting.basepath + 'Security/Authentication',
        ///     JSON.stringify({
        ///         Tenant: 'Mapfre',
        ///         Email: 'usuario@example.com',
        ///         Password: 'password123',
        ///         EmployeeMode: false
        ///     }))
        ///     .done(function(data) {
        ///         if (data.Reason == null) {
        ///             // Autenticación exitosa
        ///             localStorage.setItem('Token', data.Token);
        ///             window.location.replace(data.InitialPath);
        ///         }
        ///     });
        /// </code>
        /// </example> 
        [HttpPost]
        public ActionResult LogIn(Architect.API.Core.Contracts.Security.AuthenticationRequest authenticationRequest)
        {
            ActionResult result = null;

            if (authenticationRequest.IsEmpty())
            {
                Response.StatusCode = 400; // Bad Request
                return Json(new { success = false, mensaje = "Debe indicar los datos" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Architect.API.Core.Contracts.Security.AuthenticationResponse responseItem = null;

                authenticationRequest.IPAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
                authenticationRequest.UserAgent = Request.UserAgent.ToString();

                var token = new Architect.API.Core.Contracts.Security.Token();

                responseItem = authenticationRequest.Authentication(ref token, true, true);

                if (responseItem.Reason.IsNotEmpty())
                {
                    if (responseItem.Reason.Equals("No autorizado", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Response.StatusCode = 200; // Unauthorized
                        return Json(new { success = false, Reason = responseItem.Reason }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        Response.StatusCode = 200; // Bad Request
                        return Json(new { success = false, Reason = responseItem.Reason }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    if (!responseItem.Need2FAOTP)
                        Response.Cookies.Add(Architect.API.Core.Business.Security.Accounts.AssingedContext(Request, responseItem, token));
                    Response.StatusCode = 200;
                    result = Json(responseItem, JsonRequestBehavior.AllowGet);
                }
            }

            return result;
        }

        /// <summary>
        /// Valida un código OTP (One-Time Password) y establece el contexto de autenticación si es válido.
        /// </summary>
        /// <param name="resetRequest">Objeto que contiene el código OTP a validar y información del usuario.</param>
        /// <returns>
        /// Retorna un objeto JSON con la respuesta de validación:
        /// - Si el OTP es válido: establece cookies de autenticación y retorna el contexto con Successful = true
        /// - Si el OTP es inválido: retorna un objeto con Successful = false y el Reason del error
        /// </returns>
        /// <remarks>
        /// Este método realiza las siguientes operaciones:
        /// 1. Valida el código OTP proporcionado mediante el servicio OTP.IsValid()
        /// 2. Si es válido:
        ///    - Recupera el contexto de autenticación del caché usando el OTP como clave
        ///    - Deserializa el objeto AOTPResponse almacenado en caché
        ///    - Establece la cookie de autenticación mediante AssingedContext()
        ///    - Configura el contexto del usuario en el servidor
        /// 3. Retorna la respuesta GenericResponse con el resultado de la validación
        ///
        /// Este método es parte del flujo de autenticación de dos factores (2FA).
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult> IsOTPValid(Architect.API.Core.Contracts.Security.ResetPasswordRequest resetRequest)
        {
            ActionResult result = null;
            resetRequest.IPAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
            Architect.API.Core.Contracts.Security.AOTPResponse body = null;

            await Task.Run(() => body = Architect.API.Core.Business.Security.OTP.IsValid(resetRequest)).ConfigureAwait(false);

            if (body.Successful)
            {
                var context = Architect.Utilities.SerializeHandler.DeserializeJSON<Architect.API.Core.Contracts.Security.AOTPResponse>((string)Architect.Utilities.Cache.GetItem(resetRequest.OTP));
                body.Context = context.Context;
                body.Token = context.Token;
                Response.Cookies.Add(Architect.API.Core.Business.Security.Accounts.AssingedContext(Request, body.Context, body.Token));
            }

            Response.StatusCode = 200;

            result = Json(body, JsonRequestBehavior.AllowGet);

            return result;
        }


        /// <summary>
        /// Cierra la sesión del usuario. 
        /// Si el login fue realizado vía Entra ID (sesión contiene entraid_tenant),
        /// realiza logout federado de Entra ID; si fue vía Okta (sesión contiene okta_tenant),
        /// realiza logout federado de Okta; de lo contrario, solo logout local.
        /// </summary>
        /// <returns>
        /// Objeto JSON con { success: true, url: logoutUrl } donde logoutUrl es:
        /// - URL de logout federado de Entra ID si la sesión contiene entraid_tenant.
        /// - URL de logout federado de Okta si la sesión contiene okta_tenant.
        /// - Ruta de login local en caso contrario.
        /// </returns>
        [IsConnected]
        [HttpPost]
        public ActionResult Logout()
        {
            var entraIdTenant = Session["entraid_tenant"]?.ToString();
            string normalizedEntraTenant = EntraIDController.NormalizeTenant(entraIdTenant);

            var oktaTenant = Session["okta_tenant"]?.ToString();
            string normalizedOktaTenant = OktaController.NormalizeTenant(oktaTenant);
            string oktaIdToken = Session["okta_id_token"]?.ToString();

            string logoutUrl = ClearLocalSession();

            // Si el login fue por Entra ID, hacer logout federado
            if (normalizedEntraTenant != null)
            {
                logoutUrl = EntraIDController.Logout(normalizedEntraTenant);
            }
            else if (normalizedOktaTenant != null)
            {
                logoutUrl = OktaController.Logout(normalizedOktaTenant, oktaIdToken);
            }

            return Json(new { success = true, mensaje = "Sesión cerrada exitosamente", url = logoutUrl }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Limpia la sesión local: elimina cookies, limpia FormsAuthentication y contexto del usuario.
        /// </summary>
        /// <returns>Ruta de login local como fallback.</returns>
        private string ClearLocalSession()
        {
            // ✅ Eliminar la cookie de autenticación estableciendo su expiración en el pasado
            if (Request.Cookies["AuthToken"] != null)
            {
                var authCookie = new HttpCookie("AuthToken")
                {
                    Expires = DateTime.Now.AddDays(-1), // Fecha en el pasado para eliminar la cookie
                    Path = "/"
                };
                Response.Cookies.Add(authCookie);
            }

            // ✅ Limpiar el contexto de autenticación de FormsAuthentication
            System.Web.Security.FormsAuthentication.SignOut();

            // ✅ Limpiar el contexto del usuario
            if (HttpContext.User != null)
            {
                HttpContext.User = null;
            }

            if (System.Threading.Thread.CurrentPrincipal != null)
            {
                System.Threading.Thread.CurrentPrincipal = null;
            }

            // ✅ Limpiar la sesión si existe
            if (Session != null)
            {
                Session.Clear();
                Session.Abandon();
            }
            return WebConfigurationManager.AppSettings["Security.Login.RedirectUrl"];
        }

        /// <summary>
        /// Muestra la vista de login para usuarios de Mapfre en modo empleado.
        /// </summary>
        /// <returns>Vista de Login configurada para modo empleado Mapfre.</returns>
        public ActionResult Mapfre()
        {
            return View("Login");
        }

        /// <summary>
        /// Redirige a la página de login with el tenant "Carrofácil" preconfigurado.
        /// </summary>
        /// <returns>Redirección a la acción Login con tenant = "Carrofácil".</returns>
        public ActionResult Carrofácil()
        {
            return this.RedirectToAction("Login", "Security", new { tenant = "Carrofácil" });
        }

        /// <summary>
        /// Redirige a la página de login with el tenant "Coopeservidores" preconfigurado.
        /// </summary>
        /// <returns>Redirección a la acción Login con tenant = "Coopeservidores".</returns>
        public ActionResult Coope()
        {
            return this.RedirectToAction("Login", "Security", new { tenant = "Coopeservidores" });
        }

        /// <summary>
        /// Muestra la vista principal de login para que los usuarios puedan autenticarse.
        /// </summary>
        /// <returns>Vista de Login.</returns>
        /// <remarks>
        /// Esta vista permite a los usuarios ingresar sus credenciales (Tenant, Email, Password).
        /// El tenant puede ser preconfigurado mediante el query parameter ?tenant=xxx.
        /// </remarks>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Muestra la vista de administración de roles de miembros.
        /// </summary>
        /// <returns>Vista de RoleMember.</returns>
        [IsConnected]
        public ActionResult RoleMember()
        {
            return View();
        }

        /// <summary>
        /// Muestra la vista de administración de roles (alias de RoleMember).
        /// </summary>
        /// <returns>Vista de RoleMember.</returns>
        [IsConnected]
        public ActionResult Role()
        {
            return View("RoleMember");
        }

        /// <summary>
        /// Muestra la vista de navegación de roles de miembros para configurar permisos de acceso.
        /// </summary>
        /// <returns>Vista de RoleMemberNavigation.</returns>
        [IsConnected]
        public ActionResult RoleMemberNavigation()
        {
            return View();
        }

        /// <summary>
        /// Muestra la vista de administración de usuarios miembros del sistema.
        /// </summary>
        /// <returns>Vista de UserMember.</returns>
        [IsConnected]
        public ActionResult UserMember()
        {
            return View();
        }

        /// <summary>
        /// Muestra la vista de asignación de roles a usuarios miembros.
        /// </summary>
        /// <returns>Vista de UserRoleMember.</returns>
        [IsConnected]
        public ActionResult UserRoleMember()
        {
            return View();
        }

        /// <summary>
        /// Muestra la vista para que usuarios autenticados puedan cambiar su contraseña.
        /// </summary>
        /// <returns>Vista de ChangePassword.</returns>
        /// <remarks>
        /// Esta vista requiere que el usuario esté autenticado.
        /// Debe estar protegida con el atributo [IsConnected] si se requiere autenticación.
        /// </remarks>
        public ActionResult ChangePassword()
        {
            return View();
        }

        /// <summary>
        /// Muestra la vista de auto-registro para que nuevos usuarios puedan crear una cuenta.
        /// </summary>
        /// <returns>Vista de Register.</returns>
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Muestra la vista de integración del sistema.
        /// </summary>
        /// <returns>Vista de Integrate.</returns>
        public ActionResult Integrate()
        {
            return View();
        }

        /// <summary>
        /// Redirige al callback de EntraID (legacy)
        /// </summary>
        /// <param name="code">Código de autorización recibido</param>
        /// <param name="state">Estado recibido</param>
        /// <param name="error">Error, si ocurrió</param>
        /// <param name="error_description">Descripción del error, si ocurrió</param>
        /// <returns>Redirect a EntraID.Callback</returns>
        [HttpGet]
        public ActionResult EntraIdCallback(string code, string state, string error, string error_description)
        {
            return RedirectToAction("Callback", "EntraID", new
            {
                code,
                state,
                error,
                error_description
            });
        }

        private Uri ResolveAbsoluteUrl(string value, string aliadosBaseUrl)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            if (Uri.TryCreate(value, UriKind.Absolute, out var absolute))
                return absolute;

            var normalized = value.StartsWith("~/") ? Url.Content(value) : value;

            if (!string.IsNullOrWhiteSpace(aliadosBaseUrl) && Uri.TryCreate(aliadosBaseUrl, UriKind.Absolute, out var baseUri))
            {
                if (Uri.TryCreate(normalized, UriKind.RelativeOrAbsolute, out var candidate))
                {
                    return candidate.IsAbsoluteUri ? candidate : new Uri(baseUri, normalized);
                }
            }

            if (Request?.Url != null && Uri.TryCreate(normalized, UriKind.RelativeOrAbsolute, out var relativeToRequest))
            {
                return relativeToRequest.IsAbsoluteUri ? relativeToRequest : new Uri(Request.Url, normalized);
            }

            return null;
        }
    }
}