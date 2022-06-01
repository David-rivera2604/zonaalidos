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
    /// Permite ejecutar las acciones vinculadas con pagos online.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/AvisoCobro")]
    public class AvisoCobroController : ApiController
    {

        /// <summary>
        ///  Consulta Recibos para incluir en aviso de cobro
        /// </summary>
        [HttpGet]
        public async Task<IHttpActionResult> Consulta([FromUri] Contracts.AvisosDeCobro.Parameters.AvisoCobroConsultaParametros item)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Contracts.AvisosDeCobro.InformacionAvisosResponse result = null;
            await Task.Run(() =>
            {
                result = Business.Backoffice.AvisoCobro.Consulta(item, tokenInfo.AgentCode);
            }).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        ///  Genera aviso de cobro
        /// </summary>
        [HttpPost]
        public async Task<IHttpActionResult> Generar([FromBody] Contracts.AvisosDeCobro.Parameters.AvisoCobroGenerarParametros item)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            List<Contracts.AvisosDeCobro.AvisoResponse> result = new List<Contracts.AvisosDeCobro.AvisoResponse>();

            await Task.Run(() =>
            {
                result = Business.Backoffice.AvisoCobro.Generar(item, tokenInfo.AgentCode);
            }).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        ///  Elimina un aviso de cobro
        /// </summary>
        [HttpDelete]
        [Route("Elimina/{numAviso}")]
        [Authorize]
        public async Task<IHttpActionResult> Delete([FromUri] string numAviso)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            bool result = false;

            await Task.Run(() =>
            {
                result = Business.Backoffice.AvisoCobro.Elimina(numAviso);
            }).ConfigureAwait(false);

            return Ok(result);
        }

    }
}
