using Asp.Versioning;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Permite ejecutar las acciones vinculadas con los proceso de cotización del ramo de hogar total de tron.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Funerario")]    
    public class FunerarioController : ApiController
    {

        /// <summary>
        /// Devuelve la estructura de datos con los valores por defecto para una cotización de tipo hogar total
        /// </summary>
        [HttpGet]
        [Route("Quote/Setup")]
        [ResponseType(typeof(Architect.API.Tron.Contracts.Cotizacion.Funerario))]
        public async Task<IHttpActionResult> QuoteSetup()
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Architect.API.Tron.Contracts.Cotizacion.Funerario result = null;
            await Task.Run(() =>
            {
                result = Business.Funerario.Quote.Setup(196, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }


        /// <summary>
        /// Realiza la validación de datos y cálculo necesarios para obtener una cotización o presupuesto de un producto de tipo hogar total
        /// </summary>
        [HttpPost]
        [Route("Quote")]
        [ResponseType(typeof(Architect.API.Tron.Contracts.Cotizacion.Funerario))]
        public async Task<IHttpActionResult> Quote([FromBody] Tron.Contracts.Cotizacion.Funerario quoteInfo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.Funerario result = null;
            await Task.Run(() =>
            {
                if (quoteInfo != null && quoteInfo.cod_agt == 0)
                {
                    quoteInfo.cod_agt = tokenInfo.AgentCode;
                }
                result = Business.Funerario.Quote.Apply(quoteInfo, tokenInfo, true, Business.Funerario.Quote.ApplyType.Cotizar);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost]
        [Route("Issue")]
        [ResponseType(typeof(Architect.API.Tron.Contracts.Cotizacion.Funerario))]
        public async Task<IHttpActionResult> Issue([FromBody] Tron.Contracts.Cotizacion.Funerario quoteInfo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.Funerario result = null;
            await Task.Run(() =>
            {
                if (quoteInfo != null && quoteInfo.cod_agt == 0)
                {
                    quoteInfo.cod_agt = tokenInfo.AgentCode;
                }
                result = Business.Funerario.Quote.Apply(quoteInfo, tokenInfo, false, Business.Funerario.Quote.ApplyType.Emitir);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }
    }
}
