using Architect.API.Tron.Contracts.Variaciones;
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
    [RoutePrefix("api/v{version:apiVersion}/Variaciones")]
    public class VariacionesController : ApiController
    {
        /// <summary>
        /// Devuelve la estructura de datos asociados a una póliza de tipo Mapfre Más
        /// </summary>
        /// <param name="poliza"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MapfreMasSetup/{poliza}/{num_spto}/{mca_provisional}")]
        public async Task<IHttpActionResult> MapfreMasSetup(string poliza, int num_spto, string mca_provisional)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Variaciones.MapfreMas result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Variaciones.MapfreMas.Setup(poliza, num_spto, mca_provisional, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Recupera lista de valores para sumas aseguradas de coberturas o valores deducibles según el rol del usuario
        /// </summary>
        [HttpGet]
        [Route("MapfreMasSettings")]
        public async Task<IHttpActionResult> MapfreMasSettings(int cod_ramo, int cod_mon, int cod_marca, int cod_modelo, int cod_sub_modelo, int anio_sub_modelo, int cod_tip_vehi, int cod_uso_vehi, int mca_sexo, int cod_zona_circul, int edad, int cod_plan_auto, int num_contrato, int num_subcontrato, string num_poliza_grupo, string tipo_prod, int cod_agt = 0)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.MapfreMasSettings result = null;
            await Task.Run(() =>
            {
                if (cod_agt == 0)
                {
                    cod_agt = tokenInfo.AgentCode;
                }
                result = Architect.API.Tron.Business.Variaciones.MapfreMas.Settings(cod_ramo, cod_mon, cod_marca, cod_modelo, cod_sub_modelo, anio_sub_modelo, cod_tip_vehi, cod_uso_vehi, mca_sexo, cod_zona_circul, edad, cod_plan_auto, num_contrato, num_subcontrato, num_poliza_grupo, tipo_prod, cod_agt, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la validación de datos y emisión de la variacion para un producto de tipo Mapfre Más
        /// </summary>
        /// <param name="quoteInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MapfreMas")]
        public async Task<IHttpActionResult> MapfreMasIssue([FromBody] Tron.Contracts.Variaciones.MapfreMas quoteInfo)
        {
            VariacionIssueResult result = null;

            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Variaciones.MapfreMas.Issue(quoteInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la cancelacion para un producto de tipo Mapfre Más
        /// </summary>
        /// <param name="quoteInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MapfreMasCancelation")]
        public async Task<IHttpActionResult> MapfreMasCancelation([FromBody] Tron.Contracts.Variaciones.MapfreMas quoteInfo)
        {
            VariacionIssueResult result = null;

            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Variaciones.MapfreMas.Cancelation(quoteInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la cancelacion para un producto de tipo Mapfre Más
        /// </summary>
        /// <param name="quoteInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MapfreMasManageAuthorizationCT")]
        public async Task<IHttpActionResult> MapfreMasManageAuthorizationCT([FromBody] Tron.Contracts.Variaciones.MapfreMas quoteInfo)
        {
            VariacionIssueResult result = null;

            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Variaciones.MapfreMas.ManageAuthorizationCT(quoteInfo.cod_cia, quoteInfo.cod_ramo, quoteInfo.num_poliza, quoteInfo.num_spto, quoteInfo.Mca_Autoriza_CT);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Devuelve la estructura de datos asociados a un presupuesto, con información complementaria para permitir la emisión de una póliza de tipo Mapfre Más Plus
        /// </summary>
        /// <param name="presupuesto"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MapfreMasPlusSetup/{poliza}/{num_spto}/{mca_provisional}")]
        public async Task<IHttpActionResult> MapfreMasPlusSetup(string poliza, int num_spto, string mca_provisional)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Variaciones.MapfreMasPlus result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Variaciones.MapfreMasPlus.Setup(poliza, num_spto, mca_provisional, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la validación de datos y emisión de la variacion para un producto de tipo Mapfre Más
        /// </summary>
        /// <param name="quoteInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MapfreMasPlus")]
        public async Task<IHttpActionResult> MapfreMasPlusIssue([FromBody] Tron.Contracts.Variaciones.MapfreMasPlus quoteInfo)
        {
            VariacionIssueResult result = null;

            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Variaciones.MapfreMasPlus.Issue(quoteInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la cancelacion para un producto de tipo Mapfre Más
        /// </summary>
        /// <param name="quoteInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MapfreMasPlusCancelation")]
        public async Task<IHttpActionResult> MapfreMasPlusCancelation([FromBody] Tron.Contracts.Variaciones.MapfreMasPlus quoteInfo)
        {
            VariacionIssueResult result = null;

            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Variaciones.MapfreMasPlus.Cancelation(quoteInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la cancelacion para un producto de tipo Mapfre Más
        /// </summary>
        /// <param name="quoteInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MapfreMasPlusManageAuthorizationCT")]
        public async Task<IHttpActionResult> MapfreMasPlusManageAuthorizationCT([FromBody] Tron.Contracts.Variaciones.MapfreMasPlus quoteInfo)
        {
            VariacionIssueResult result = null;

            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Variaciones.MapfreMasPlus.ManageAuthorizationCT(quoteInfo.cod_cia, quoteInfo.cod_ramo, quoteInfo.num_poliza, quoteInfo.num_spto, quoteInfo.Mca_Autoriza_CT);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

    }
}
