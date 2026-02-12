using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Architect.Utilities;
using Architect.Utilities.Extensions;
using Asp.Versioning;

namespace Architect.API.Process.WebApi.Controllers
{
    /// <summary>
    /// Acciones relacionas con la seguridad de la aplicación.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Security")]
    public class SecurityController : ApiController
    {
        /// <summary>
        /// Verifica que un código temporal sea valido.
        /// </summary>
        /// <param name="resetRequest">Datos de la solicitud.</param>
        /// <returns>Indicador si el codigo es valido o no.</returns>
        [HttpPost]
        [Route("IsOTPValid")]
        [AllowAnonymous]
        [ResponseType(typeof(Core.Contracts.General.GenericResponse))] 
        public async Task<IHttpActionResult> IsOTPValid(Core.Contracts.Security.ResetPasswordRequest resetRequest)
        {
            resetRequest.IPAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
            Architect.API.Core.Contracts.Security.AOTPResponse result = null;

            await Task.Run(() => result = Architect.API.Core.Business.Security.OTP.IsValid(resetRequest)).ConfigureAwait(false);

            if(result.Successful)
            {
                var originen = resetRequest.OTP.GetItem<string>().DeserializeJSON<Architect.API.Core.Contracts.Security.AOTPResponse>();
                result.Context = originen.Context;
                result.Token = originen.Token;
                result.Key = originen.Key;
            }    

            return Ok(result);
        }

        /// <summary>
        /// Permite autenticar un usuario por medio de sus credenciales.
        /// </summary>
        /// <param name="authenticationRequest">Credenciales de uso.</param>
        /// <returns>Contexto de autenticación incluyendo el token que identifica la sesión del usuario.</returns>
        /// <response code="200">OK. Contexto de autenticación incluyendo el token que identifica la sesión del usuario.</response>
        /// <response code="400">BadRequest. Debe indicar los datos de forma correcta.</response>
        /// <response code="401">Unauthorized. Acceso no permitido.</response>
        [HttpPost]
        [Route("Authentication")]
        [AllowAnonymous]
        [ResponseType(typeof(Core.Contracts.Security.AuthenticationResponse))]
        public IHttpActionResult Authentication([FromBody] Core.Contracts.Security.AuthenticationRequest authenticationRequest)
        {
            IHttpActionResult result = null;

            if (authenticationRequest.IsEmpty())
            {
                result = BadRequest("Debe indicar los datos");
            }
            else
            {
                Core.Contracts.Security.AuthenticationResponse responseItem = null;
                authenticationRequest.IPAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
                authenticationRequest.UserAgent = Request.Headers.UserAgent.ToString();
                Architect.API.Core.Contracts.Security.Token token = new Core.Contracts.Security.Token();

                // Llamada sincrónica - eliminar Task.Run para preservar HttpContext
                responseItem = Core.Business.Security.Accounts.Authentication(authenticationRequest, ref token, true);

                if (responseItem.Reason.IsNotEmpty())
                {
                    if (responseItem.Reason.Equals("No autorizado", StringComparison.CurrentCultureIgnoreCase))
                        result = Unauthorized();
                    else
                        result = BadRequest(responseItem.Reason);
                }
                else
                {
                    result = Ok(responseItem);
                }
            }

            return result;
        }

        /// <summary>
        /// Navegación permitida según los roles asociados al usuario del token
        /// </summary>
        /// <returns></returns>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token acceso.</response>
        [HttpGet]
        [Route("NavegationAllowed")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult NavegationAllowed()
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            List<Architect.API.Core.Contracts.Security.NavAllowed> result = Core.Business.Security.Navigation.RetrieveNavigationAllowed(tokenInfo.Roles, tokenInfo.CompanyId);

            if (result.IsEmpty())
                return NotFound();
            else
                return Ok(result);
        }

        /// <summary>
        /// Verifica la vigencia de token en uso.
        /// </summary>
        /// <param name="force">Forza a que el token sea refrescado.</param>
        /// <returns>Tiempo para la expiración.</returns>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token acceso.</response>
        [HttpGet]
        [Route("IsLive")]
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult IsLive(bool force = false)
        {
            string token = Core.Security.Token.Value();

            if (force)
                Core.Security.Session.Refresh(token, Request.Headers.Referrer.AbsoluteUri);

            int result = Core.Business.Security.Navigation.IsLive(token);

            return Ok(result);
        }

        /// <summary>
        /// Enviado de un código temporal, el cual le permitirá establecer una clave de acceso.
        /// </summary>
        /// <param name="resetRequest">Datos de la solicitud.</param>
        /// <returns>Confirmación del envio.</returns>
        [HttpPost]
        [Route("SendOTP")]
        [AllowAnonymous]
        [ResponseType(typeof(Core.Contracts.General.GenericResponse))]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> SendOTP(Core.Contracts.Security.ResetPasswordRequest resetRequest)
        {
            resetRequest.IPAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
            Core.Contracts.General.GenericResponse result = null;

            await Task.Run(() => result = Architect.API.Core.Business.Security.OTP.Send(resetRequest)).ConfigureAwait(false);

            return Ok(result);
        }

       
        /// <summary>
        /// Permite restablecer una clave de acceso.
        /// </summary>
        /// <param name="resetRequest">Datos de la solicitud.</param>
        /// <returns>Indicador si la clave de acceso fue cambiada de forma exitosa o no.</returns>
        [HttpPost]
        [Route("ResetPassword")]
        [AllowAnonymous]
        [ResponseType(typeof(Core.Contracts.General.GenericResponse))]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> ResetPassword(Core.Contracts.Security.ResetPasswordRequest resetRequest)
        {
            resetRequest.IPAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
            Core.Contracts.General.GenericResponse result = null;

            await Task.Run(() => result = Architect.API.Core.Business.Security.Accounts.ResetPassword(resetRequest)).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        /// Permite el cambio de clave de acceso de un usuario conectado.
        /// </summary>
        /// <param name="resetRequest">Datos de la solicitud.</param>
        /// <returns>Confirmación del cambio.</returns>
        [HttpPut]
        [Route("ChangePassword")]
        [Authorize]
        [ResponseType(typeof(Core.Contracts.General.GenericResponse))]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> ChangePassword(Core.Contracts.Security.ResetPasswordRequest resetRequest)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            resetRequest.IPAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
            Core.Contracts.General.GenericResponse result = null;

            await Task.Run(() => result = Architect.API.Core.Business.Security.Accounts.ChangePassword(tokenInfo.CompanyId, tokenInfo.UserId, resetRequest)).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        /// Permite el auto registro de un usuarios al sistema.
        /// </summary>
        /// <param name="registerRequest">Datos de la solicitud.</param>
        /// <returns>Confirmación del registro.</returns>
        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> Register([FromBody] Core.Contracts.Security.Register registerRequest)
        {
            IHttpActionResult result = null;
            Core.Contracts.Security.UserMemberResult reponse = null;

            if (registerRequest.IsEmpty())
            {
                result = BadRequest("Debe indicar los datos");
            }
            else
            {
                await Task.Run(() => reponse = Architect.API.Core.Business.Security.Accounts.Register(registerRequest)).ConfigureAwait(false);

                if (reponse.Errors == null || reponse.Errors.Count == 0)
                {
                    result = Ok(new { Successful = true, Message = "" });
                }
                else
                {
                    ModelState.Clear();
                    foreach (Core.Contracts.General.Error errorItem in reponse.Errors)
                    {
                        ModelState.AddModelError(string.Format("{0}.{1}", "Register", errorItem.Key), errorItem.Message);
                    }
                    result = BadRequest(ModelState);
                }
            }

            return result;
        }

        /// <summary>
        /// Lista de sesiones de usuarios.
        /// </summary>
        /// <returns>Lista de sesiones de usuarios.</returns>
        [HttpGet]
        [Route("Sessions")]
        [AllowAnonymous]
        [ResponseType(typeof(List<Core.Contracts.Security.Activity>))]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> Sessions([FromUri] string filter = "")
        {
            List<Core.Contracts.Security.Activity> result = null;

            await Task.Run(() => result = Core.Security.Session.Sessions(filter)).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        /// Lista de sesiones de usuarios.
        /// </summary>
        /// <returns>Lista de sesiones de usuarios.</returns>
        [HttpGet]
        [Route("Sessions/{id}")]
        [AllowAnonymous]
        [ResponseType(typeof(Core.Contracts.Security.Activity))]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> SessionById(int id)
        {
            Core.Contracts.Security.Activity result = null;

            await Task.Run(() => result = Core.Security.Session.SessionById(id)).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        /// Permite validar las credenciales de acceso y generar un token que permite el consumo de las APIs.
        /// </summary>
        [HttpPost]
        [Route("Token")]
        [AllowAnonymous]
        [ResponseType(typeof(Architect.API.Core.Contracts.Seguridad.RespuestaSeguridad))]
        public async Task<IHttpActionResult> Token(Architect.API.Core.Contracts.Seguridad.SolicitudAcceso solicitud)
        {
            if (solicitud.IsEmpty() || solicitud.clienteID.IsEmpty() || solicitud.secretID.IsEmpty())
            {
                return BadRequest("Debe indicar la credenciales de acceso");
            }

            string IPAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
            string useragent = Request.Headers.UserAgent.ToString();

            Architect.API.Core.Contracts.Seguridad.RespuestaSeguridad result = Architect.API.Core.Business.Security.Accounts.Token(solicitud.clienteID, solicitud.secretID, IPAddress, useragent).Result;

            if (result != null && !result.access_token.IsEmpty())
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized();
            }
        }

        /// <summary>
        /// Permite validar las credenciales de acceso y generar un token que permite el consumo de las APIs.
        /// </summary>
        [HttpPost]
        [Route("ObtenerToken")]
        [AllowAnonymous]
        [ResponseType(typeof(Architect.API.Core.Contracts.Seguridad.RespuestaToken))]
        public async Task<IHttpActionResult> ObtenerToken(Architect.API.Core.Contracts.Seguridad.ObtenerToken solicitud)
        {
            if (solicitud.IsEmpty() || solicitud.username.IsEmpty() || solicitud.password.IsEmpty())
            {
                return BadRequest("Debe indicar la credenciales de acceso");
            }

            string IPAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
            string useragent = Request.Headers.UserAgent.ToString();

            Architect.API.Core.Contracts.Seguridad.RespuestaSeguridad result = Architect.API.Core.Business.Security.Accounts.Token(solicitud.username, solicitud.password, IPAddress, useragent).Result;

            if (result != null && !result.access_token.IsEmpty())
            {
                return Ok(new Architect.API.Core.Contracts.Seguridad.RespuestaToken() { access_token = result.access_token, expires_in = result.expires_in });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("Profile")]
        public async Task<IHttpActionResult> Profile()
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Core.Contracts.Security.UserMember result = null;

            await Task.Run(() => result = Core.Business.Security.Accounts.Profile(tokenInfo.CompanyId, tokenInfo.UserId)).ConfigureAwait(false);

            if (result != null)
            {
                return Ok(new
                {
                    EMail = result.EMail,
                    PhoneNumber = result.PhoneNumber
                });
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Agent")]
        public async Task<IHttpActionResult> Agent(string tip_docum, string cod_docum)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            string result = string.Empty;

            await Task.Run(() => result = Core.Business.General.Tron.RetrieveAgentEMailByDocument(tip_docum.IdentificationType(), cod_docum)).ConfigureAwait(false);

            return Ok(new
            {
                EMail = result
            });
        }
    }
}