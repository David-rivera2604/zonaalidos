using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
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
        /// Método que autentica y genera un token para poder utilizar los métodos disponibles, se colocara un cliente id para generar el token.
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
 
            Domain.Seguridad.RespuestaSeguridad x1 = Application.Seguridad.SeguridadHandler.Autorizacion(clienteID, secretID).Result;

            if (x1!= null)
            {
                return Ok(x1);
            } else
            {
                return Unauthorized();
            }
            
        }
    }
}
