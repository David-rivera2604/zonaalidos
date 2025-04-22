using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Architect.API.Tron.Contracts.SINPEMovil.Response;
using Microsoft.Web.Http;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Controlador para la vinculación asistida de SINPE Móvil Empresarial.
    /// </summary>
    [ApiVersion("1.0")]    
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/SINPEMovil")]
    public class SINPEMovilController : ApiController
    {
        /// <summary>
        /// Aplica un pago recibido.
        /// </summary>
        /// <param name="request">Datos del pago a aplicar.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPost]
        [Route("AplicarPago")]
        [ResponseType(typeof(Contracts.SINPEMovil.Response.AplicarPago))]
        public async Task<IHttpActionResult> AplicarPago([FromBody] Contracts.SINPEMovil.Request.AplicarPago request)
        {
            if (request == null)
            {
                return BadRequest("El request no puede ser nulo.");
            }

            var response = await Business.Backoffice.SINPEMovil.Create(request);    

            return Ok(response);
        }

        /// <summary>
        /// Consulta los datos de una transacción.
        /// </summary>
        /// <param name="id">Identificador de la transacción.</param>
        /// <param name="request">La solicitud de consulta de datos.</param>
        /// <returns>Resultado de la consulta.</returns>
        [HttpPost]
        [Route("ConsultaDatos")]
        [ResponseType(typeof(Contracts.SINPEMovil.Response.ConsultaDatos))]
        public async Task<IHttpActionResult> ConsultaDatos([FromUri] string id, [FromBody] Contracts.SINPEMovil.Request.ConsultaDatos request)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("El id no puede ser nulo o vacío.");
            }
            if (request == null)
            {
                return BadRequest("El request no puede ser nulo.");
            }

            var response = await Business.Backoffice.SINPEMovil.Consulta(id, request);

            return Ok(response);
        }
    }
}
