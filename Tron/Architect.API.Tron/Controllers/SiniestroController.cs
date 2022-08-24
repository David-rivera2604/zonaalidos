using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Permite ejecutar las acciones vinculadas a los siniestros de tron.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Siniestro")]
    public class SiniestroController : ApiController
    {

        /// <summary>
        /// Recupera una lista de siniestros por agente para un rango de fecha de ocurrencia.
        /// </summary>
        /// <param name="startDate">Fecha inicial de ocurrencia del siniestro.</param>
        /// <param name="endDate">Fecha final de ocurrencia del siniestro.</param>
        [HttpGet]
        [Route("Purdy")]
        [ResponseType(typeof(List<Contracts.Siniestro.Purdy.Siniestro>))]
        public async Task<IHttpActionResult> Informacion([FromUri] DateTime startDate, [FromUri]  DateTime endDate)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            List<Contracts.Siniestro.Purdy.Siniestro> result = null;
            await Task.Run(() =>
            {
                result = Business.Siniestro.Purdy.Retrieve(startDate, endDate, tokenInfo);
            }).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Ejecuta el proceso que consulta el estado de los siniestro por parte de purdy.
        /// </summary>
        [HttpGet]
        [Route("pull")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Pull()
        {
            List<Contracts.Siniestro.Purdy.Siniestro> result = null;
            Business.Siniestro.Purdy.PurdyServiceRequests(0);
            return Ok();
        }

    }
}
