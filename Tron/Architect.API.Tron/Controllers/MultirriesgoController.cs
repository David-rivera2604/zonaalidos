using Microsoft.Web.Http;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Http;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Permite ejecutar las acciones vinculadas con los proceso de cotización del ramo de multirriesgo de tron.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Multirriesgo")]
    public class MultirriesgoController : ApiController
    {

        /// <summary>
        /// Devuelve la estructura de datos con los valores por defecto para una cotización de tipo Multirriesgo
        /// </summary>
        [HttpGet]
        [Route("QuoteSetup")]
        public async Task<IHttpActionResult> QuoteSetup()
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Architect.API.Tron.Contracts.Cotizacion.Multirriesgo result = null;
            await Task.Run(() =>
            {
                result = Business.Multirriesgo.QuoteHandler.QuoteSetup(204, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }


        [HttpGet]
        [Route("QuoteSettings")]
        public async Task<IHttpActionResult> QuoteSettings(int cod_ramo, int num_contrato, int num_subcontrato, string num_poliza_grupo, int cod_mon)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.HogarTotalSettings result = null;
            await Task.Run(() =>
            {
                result = Business.Cotizacion.HogarTotal.Settings(cod_ramo, num_contrato, num_subcontrato, num_poliza_grupo, cod_mon, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la validación de datos y cálculo necesarios para obtener una cotización o presupuesto de un producto de tipo Multirriesgo
        /// </summary>
        [HttpPost]
        [Route("Quote")]
        public async Task<IHttpActionResult> Quote([FromBody] Tron.Contracts.Cotizacion.Multirriesgo quoteInfo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.Multirriesgo result = null;
            await Task.Run(() =>
            {
                result = Business.Multirriesgo.QuoteHandler.Quote(quoteInfo, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }


        /// <summary>
        /// Devuelve la estructura de datos asociados a un presupuesto, con información complementaria para permitir la emisión de una póliza de tipo Multirriesgo
        /// </summary>
        [HttpGet]
        [Route("IssueSetup/{presupuesto}")]
        public async Task<IHttpActionResult> IssueSetup(string presupuesto, string mode)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Emision.Multirriesgo result = null;
            await Task.Run(() =>
            {
                result = Business.Multirriesgo.IssueHandler.Setup(presupuesto, mode, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la validación de datos y emisión de la póliza para un producto de tipo Multirriesgo
        /// </summary>
        [HttpPost]
        [Route("Issue")]
        public async Task<IHttpActionResult> Issue([FromBody] Tron.Contracts.Emision.Multirriesgo quoteInfo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.Multirriesgo result = null;
            await Task.Run(() =>
            {
                result = Business.Multirriesgo.IssueHandler.Issue(quoteInfo, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }


        /// <summary>
        /// Envío o reenvío de una solicitud Multirriesgo asociada a un presupuesto para su firma manual o por medio de evicertia
        /// </summary>
        [HttpGet]
        [Route("EnviarSolicitud")]
        public async Task<IHttpActionResult> EnviarSolicitud(string presupuesto, string correoenvio)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            string result = string.Empty;
            await Task.Run(() =>
            {
                result = Business.Multirriesgo.RequestHandler.ReEnviarSolicitud(presupuesto, correoenvio, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }



    }
}
