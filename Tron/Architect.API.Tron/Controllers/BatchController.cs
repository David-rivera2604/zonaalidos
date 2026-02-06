using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Asp.Versioning;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Permite ejecutar las acciones vinculadas a procesos batch de tron.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Batch")]
    public class BatchController : ApiController
    {
        /// <summary>
        /// Realiza la solicitud de información para vehículos sin placa.
        /// </summary>
        [HttpPost]
        [Route("SinPlaca")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Informacion([FromUri] int offset = 0, [FromUri] int size = 9)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            await Business.Backoffice.Batch.SinPlaca.RetrieveUnregisteredVehiclesAsync(offset, size);
            return Ok();
        }

        /// <summary>
        /// Procesa la información de vehículos sin placa, para la asignación de la misma.
        /// </summary>
        [HttpPost]
        [Route("SinPlacaCallback")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> SinPlacaCallback([FromBody] List<Contracts.Robots.CivilRegistrationRequest> vehicles)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            await Business.Backoffice.Batch.SinPlaca.ProcessLicensePlateUpdateAsync(vehicles);
            return Ok();
        }
    }
}