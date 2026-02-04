using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Asp.Versioning;

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
        /// Modifica un aviso de cobro para exluir recibos del mismo
        /// </summary>
        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Modifica([FromBody] Contracts.AvisosDeCobro.Parameters.AvisoCobroModificaParametros item)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            bool result = false;
            await Task.Run(() =>
            {
                result = Business.Backoffice.AvisoCobro.Modifica(item);
            }).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        ///  Consulta Recibos para incluir en aviso de cobro
        /// </summary>
        [HttpPost]
        [Route("ConsultaRecibos")]
        public async Task<IHttpActionResult> ConsultaRecibos([FromBody] Contracts.AvisosDeCobro.Parameters.RecibosParametros item)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            List<Contracts.AvisosDeCobro.ReciboRespose> result = null;
            await Task.Run(() =>
            {
                result = Business.Backoffice.AvisoCobro.ConsultaRecibos(item, tokenInfo);
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
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            List<Contracts.AvisosDeCobro.AvisoResponse> result = new List<Contracts.AvisosDeCobro.AvisoResponse>();

            await Task.Run(() =>
            {
                result = Business.Backoffice.AvisoCobro.Generar(item, tokenInfo);
            }).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        ///  Elimina un aviso de cobro
        /// </summary>
        [HttpDelete]
        [Route("{numAviso}")]
        public async Task<IHttpActionResult> Delete([FromUri] string numAviso)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            bool result = false;

            await Task.Run(() =>
            {
                result = Business.Backoffice.AvisoCobro.Elimina(numAviso);
            }).ConfigureAwait(false);

            return Ok(result);
        }
    }
}