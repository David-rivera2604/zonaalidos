using Microsoft.Web.Http;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Permite ejecutar las acciones vinculadas a las pólizas de tron.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Poliza")]
    public class PolizaController : ApiController
    {

        [HttpPost]
        [Route("Emitir")]
        [Authorize]
        public async Task<IHttpActionResult> Emitir([FromBody] Architect.API.Tron.Contracts.Presupuesto.API.Presupuesto presupuesto)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Contracts.Poliza.API.Poliza result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.API.Issue(presupuesto, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Recupera la información de una póliza
        /// </summary>
        [HttpGet]
        [Route("{num_poliza}")]
        public async Task<IHttpActionResult> Informacion([FromUri] string num_poliza)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Architect.API.Tron.Contracts.Poliza.DatoFijo result = null;
            await Task.Run(() =>
            {
                result = Business.Backoffice.Common.InformacionDePoliza(num_poliza);
            }).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Recupera los datos variables de una póliza
        /// </summary>
        [HttpGet]
        [Route("{num_poliza}/DatosVariables")]
        public async Task<IHttpActionResult> DatosVariables([FromUri] string num_poliza)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            List<Contracts.Poliza.DatoVariacion> result = null;
            await Task.Run(() =>
            {
                result = Business.Backoffice.Poliza.DatosVariables(num_poliza);
            }).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Aplica variaciones a una póliza
        /// </summary>
        [HttpPut]
        [Route("{num_poliza}/Variaciones")]
        public async Task<IHttpActionResult> Variaciones([FromUri] string num_poliza, [FromBody] Contracts.Poliza.Variacion variacion)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            bool result = false;
            await Task.Run(() =>
            {
                result = Business.Backoffice.Poliza.Variaciones(num_poliza, variacion);
            }).ConfigureAwait(false);

            return Ok(new
            {
                Success = result,
                Reason = result ? "Las variaciones fueron procesadas de forma correcta" : "Ha ocurrido un error tratando de procesar las variaciones"
            });
        }

    }
}
