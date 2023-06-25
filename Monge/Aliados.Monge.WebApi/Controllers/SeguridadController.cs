using Architect.API.Core.Contracts.Security;
using Architect.Utilities.Extensions;
using Microsoft.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Aliados.Monge.WebApi.Controllers
{
    /// <summary>
    /// Autentica y genera un token
    /// </summary>
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/Seguridad")]
    public class SeguridadController : ApiController
    {

        /// <summary>
        /// Permite validar las credenciales de acceso para la generar y generar un token que permite el consumo de las APIs.
        /// </summary>
        [HttpPost]
        [Route("Token")]
        [AllowAnonymous]
        [ResponseType(typeof(Domain.Seguridad.RespuestaSeguridad))]
        public async Task<IHttpActionResult> Token(Domain.Seguridad.SolicitudAcceso solicitud)
        {

            if (solicitud.IsEmpty() || solicitud.clienteID.IsEmpty() || solicitud.secretID.IsEmpty())
            {
                return BadRequest("Debe indicar la credenciales de acceso");
            }

            string IPAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
            string useragent = Request.Headers.UserAgent.ToString();

            Domain.Seguridad.RespuestaSeguridad x1 = Application.Seguridad.SeguridadHandler.Autorizacion(solicitud.clienteID, solicitud.secretID, IPAddress, useragent).Result;

            if (x1 != null && !x1.access_token.IsEmpty())
            {
                return Ok(x1);
            }
            else
            {
                return Unauthorized();
            }

        }

    }
}
