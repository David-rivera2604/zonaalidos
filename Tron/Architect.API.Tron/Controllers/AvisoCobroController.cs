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
        [HttpPost]
        [Route("ConsultaRecibos")]
        public async Task<IHttpActionResult> ConsultaRecibos([FromBody] Contracts.AvisosDeCobro.Parameters.RecibosParametros item)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            List<Contracts.AvisosDeCobro.ReciboRespose> result = null;
            await Task.Run(() =>
            {
                result = Business.Backoffice.AvisoCobro.ConsultaRecibos(item, tokenInfo.AgentCode);
            }).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        ///  Consulta avisos de cobro
        /// </summary>
        [HttpPost]
        [Route("ConsultaAvisos")]
        public async Task<IHttpActionResult> ConsultaAvisos([FromBody] Contracts.AvisosDeCobro.Parameters.AvisoCobroConsultaParametros item)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Contracts.AvisosDeCobro.InformacionAvisosResponse result = null;
            await Task.Run(() =>
            {
                result = Business.Backoffice.AvisoCobro.ConsultaAvisos(item, tokenInfo.AgentCode);
            }).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        ///  Genera aviso de cobro
        /// </summary>
        [HttpPost]
        [Route("Generar")]
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
