using Microsoft.Web.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Permite ejecutar las acciones vinculadas con los proceso de emisión de tron.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Issue")]
    public class IssueController : ApiController
    {

        /// <summary>
        /// Devuelve la estructura de datos asociados a un presupuesto, con información complementaria para permitir la emisión de una póliza de tipo Hogar Total
        /// </summary>
        /// <param name="presupuesto"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("HogarTotalSetup/{presupuesto}")]
        public async Task<IHttpActionResult> HogarTotalSetup(string presupuesto)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Tron.Contracts.Emision.HogarTotal result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Emision.HogarTotal.Setup(presupuesto);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la validación de datos y emisión de la póliza para un producto de tipo Hogar Total
        /// </summary>
        /// <param name="quoteInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("HogarTotal")]
        public async Task<IHttpActionResult> HogarTotalIssue([FromBody] Tron.Contracts.Emision.HogarTotal quoteInfo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Tron.Contracts.Cotizacion.HogarTotal result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Emision.HogarTotal.Issue(quoteInfo, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Devuelve la estructura de datos asociados a un presupuesto, con información complementaria para permitir la emisión de una póliza de tipo Mapfre Más
        /// </summary>
        /// <param name="presupuesto"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MapfreMasSetup/{presupuesto}")]
        public async Task<IHttpActionResult> MapfreMasSetup(string presupuesto, string mode)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Tron.Contracts.Emision.MapfreMas result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Emision.MapfreMas.Setup(presupuesto, mode, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la validación de datos y emisión de la póliza para un producto de tipo Mapfre Más
        /// </summary>
        /// <param name="quoteInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MapfreMas")]
        public async Task<IHttpActionResult> MapfreMasIssue([FromBody] Tron.Contracts.Emision.MapfreMas quoteInfo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Tron.Contracts.Cotizacion.MapfreMas result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Emision.MapfreMas.Issue(quoteInfo, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Envío o reenvío de una solicitud asociada a un presupuesto para su firma manual o por medio de evicertia
        /// </summary>
        /// <param name="presupuesto"></param>
        /// <param name="correoenvio"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MapfreMas/EnviarSolicitud")]
        public async Task<IHttpActionResult> ReEnviarSolicitud(string presupuesto, string correoenvio)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            string result = string.Empty;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Emision.MapfreMas.ReEnviarSolicitud(presupuesto, correoenvio, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Devuelve posibles complementos a la información de terceros según el rol del usuario y/o fuentes del tomador de la póliza
        /// </summary>
        /// <param name="fuente_Tomador"></param>
        /// <param name="terceros"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MapfreMas/Terceros/{fuente_Tomador}")]
        public async Task<IHttpActionResult> Tercero_Complement([FromUri] string fuente_Tomador, [FromBody] List<Contracts.Emision.MapfreMasterceros> terceros)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            List<Contracts.Emision.MapfreMasterceros> result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Emision.MapfreMas.Tercero_Complement(terceros, fuente_Tomador, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Devuelve la estructura de datos asociados a un presupuesto, con información complementaria para permitir la emisión de una póliza de tipo Multirriesgo
        /// </summary>
        /// <param name="presupuesto"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MultirriesgoSetup/{presupuesto}")]
        public async Task<IHttpActionResult> MultirriesgoSetup(string presupuesto)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Tron.Contracts.Emision.Multirriesgo result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Emision.Multirriesgo.Setup(presupuesto);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la validación de datos y emisión de la póliza para un producto de tipo Multirriesgo
        /// </summary>
        /// <param name="quoteInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Multirriesgo")]
        public async Task<IHttpActionResult> MultirriesgoIssue([FromBody] Tron.Contracts.Emision.Multirriesgo quoteInfo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Tron.Contracts.Cotizacion.Multirriesgo result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Emision.Multirriesgo.Issue(quoteInfo, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

    }
}
