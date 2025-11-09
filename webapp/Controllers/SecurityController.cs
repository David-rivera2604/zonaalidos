using Architect.API.Core.Security;
using Architect.Utilities.Extensions;
using System;
using System.Configuration;
using System.Web;
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
    public class SecurityController : Controller
    {
        /// <summary>
        /// Autentica a un usuario mediante sus credenciales y establece el contexto de autenticación en el servidor.
        /// </summary>
        /// <param name="authenticationRequest">Objeto que contiene las credenciales del usuario (Tenant, Email, Password).</param>
        /// <returns>
        /// Retorna un objeto JSON con la respuesta de autenticación:
        /// - Si las credenciales son incorrectas: retorna el objeto con Reason conteniendo el mensaje de error
        /// - Si la autenticación es exitosa: retorna el objeto AuthenticationResponse con el token y datos del usuario
        /// </returns>
        /// <remarks>
        /// Este método realiza las siguientes operaciones:
        /// 1. Valida que se hayan proporcionado los datos de autenticación
        /// 2. Llama al servicio de autenticación de forma sincrónica (preserva HttpContext)
        /// 3. Si es exitoso:
        ///    - Establece una cookie "AuthToken" con el token JWT
        ///    - Configura el contexto del usuario en el servidor mediante token.AssingedContext()
        ///    - Retorna el objeto AuthenticationResponse directamente (sin wrapper)
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
            if (authenticationRequest.IsEmpty())
            {
                return Json(new { success = false, mensaje = "Debe indicar los datos" }, JsonRequestBehavior.AllowGet);
            }

            Architect.API.Core.Contracts.Security.AuthenticationResponse responseItem = null;
            authenticationRequest.IPAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
            authenticationRequest.UserAgent = Request.UserAgent;
            Architect.API.Core.Contracts.Security.Token token = new Architect.API.Core.Contracts.Security.Token();

            // Llamada sincrónica - eliminar Task.Run para preservar HttpContext
            responseItem = Architect.API.Core.Business.Security.Accounts.Authentication(authenticationRequest, ref token, true);

            if (responseItem.Reason.IsNotEmpty())
            {
                return Json(responseItem, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // ✅ Establecer la cookie con el token
                var authCookie = new HttpCookie("AuthToken", responseItem.Token)
                {
                    Expires = DateTime.Now.AddMinutes(responseItem.ExpiresIn),
                    HttpOnly = false, // false para que JavaScript pueda leerla si es necesario
                    Secure = Request.IsSecureConnection, // true si es HTTPS
                    SameSite = SameSiteMode.Lax,
                    Path = "/"
                };
                Response.Cookies.Add(authCookie);

                // ✅ Establecer el contexto del usuario inmediatamente
                token.AssingedContext();

                // ✅ Devolver responseItem tal cual, sin wrapper
                return Json(responseItem, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Cierra la sesión del usuario eliminando la cookie de autenticación y limpiando el contexto del servidor.
        /// </summary>
        /// <returns>
        /// Retorna un objeto JSON indicando que el cierre de sesión fue exitoso:
        /// { success: true, mensaje: "Sesión cerrada exitosamente" }
        /// </returns>
        /// <remarks>
        /// Este método realiza las siguientes operaciones:
        /// 1. Elimina la cookie "AuthToken" estableciendo su expiración en el pasado
        /// 2. Limpia el contexto del usuario en el servidor (HttpContext.User y Thread.CurrentPrincipal)
        /// 3. Invalida la autenticación de FormsAuthentication
        ///
        /// Después de llamar a este método, el usuario deberá autenticarse nuevamente para acceder
        /// a páginas protegidas con el atributo [IsConnected].
        /// </remarks>
        /// <example>
        /// Ejemplo de uso desde JavaScript:
        /// <code>
        /// app.core.Post(app.setting.basepath + 'Security/Logout')
        ///     .done(function(data) {
        ///         if (data.success) {
        ///             // Limpiar localStorage
        ///             localStorage.removeItem('Token');
        ///             localStorage.removeItem('Username');
        ///             localStorage.removeItem('Roles');
        ///             // Redirigir al login
        ///             window.location.replace(app.setting.basepath + 'Security/Login');
        ///         }
        ///     });
        /// </code>
        /// </example>
        [HttpPost]
        public ActionResult Logout()
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

            return Json(new { success = true, mensaje = "Sesión cerrada exitosamente" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Muestra la vista de login para usuarios de Mapfre en modo empleado.
        /// </summary>
        /// <returns>Vista de Login configurada para modo empleado Mapfre.</returns>
        public ActionResult Mapfre()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View("Login");
        }

        /// <summary>
        /// Redirige a la página de login con el tenant "Carrofácil" preconfigurado.
        /// </summary>
        /// <returns>Redirección a la acción Login con tenant = "Carrofácil".</returns>
        public ActionResult Carrofácil()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return this.RedirectToAction("Login", "Security", new { tenant = "Carrofácil" });
        }

        /// <summary>
        /// Redirige a la página de login con el tenant "Coopeservidores" preconfigurado.
        /// </summary>
        /// <returns>Redirección a la acción Login con tenant = "Coopeservidores".</returns>
        public ActionResult Coope()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
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
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        /// <summary>
        /// Muestra la vista de administración de roles de miembros.
        /// </summary>
        /// <returns>Vista de RoleMember.</returns>
        public ActionResult RoleMember()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        /// <summary>
        /// Muestra la vista de administración de roles (alias de RoleMember).
        /// </summary>
        /// <returns>Vista de RoleMember.</returns>
        public ActionResult Role()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View("RoleMember");
        }

        /// <summary>
        /// Muestra la vista de navegación de roles de miembros para configurar permisos de acceso.
        /// </summary>
        /// <returns>Vista de RoleMemberNavigation.</returns>
        public ActionResult RoleMemberNavigation()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        /// <summary>
        /// Muestra la vista de administración de usuarios miembros del sistema.
        /// </summary>
        /// <returns>Vista de UserMember.</returns>
        public ActionResult UserMember()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        /// <summary>
        /// Muestra la vista de asignación de roles a usuarios miembros.
        /// </summary>
        /// <returns>Vista de UserRoleMember.</returns>
        public ActionResult UserRoleMember()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
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
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        /// <summary>
        /// Muestra la vista de auto-registro para que nuevos usuarios puedan crear una cuenta.
        /// </summary>
        /// <returns>Vista de Register.</returns>
        public ActionResult Register()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        /// <summary>
        /// Muestra la vista de integración del sistema.
        /// </summary>
        /// <returns>Vista de Integrate.</returns>
        public ActionResult Integrate()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
    }
}