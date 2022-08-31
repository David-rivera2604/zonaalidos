using Architect.API.Core.Contracts.Security;
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
    [Authorize]
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
        public async Task<IHttpActionResult> Token()
        {
            string clienteID = string.Empty;
            string secretID = string.Empty;
            IEnumerable<string> values;
            Request.Headers.TryGetValues("clienteID", out values);

            if (values != null && values.Count() > 0)
                clienteID = values.FirstOrDefault();

            Request.Headers.TryGetValues("secretID", out values);
            if (values != null && values.Count() > 0)
                secretID = values.FirstOrDefault();

            string IPAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
            string useragent = Request.Headers.UserAgent.ToString();

            Domain.Seguridad.RespuestaSeguridad x1 = Application.Seguridad.SeguridadHandler.Autorizacion(clienteID, secretID, IPAddress, useragent).Result;

            if (x1 != null)
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
