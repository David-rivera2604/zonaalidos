using Microsoft.Web.Http;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Http;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Permite ejecutar las acciones vinculadas con los proceso de cotización de tron.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Quote")]
    public class QuoteController : ApiController
    {

        /// <summary>
        /// Recupera la información de un presupuesto
        /// </summary>
        [HttpGet]
        [Route("{num_presupuesto}")]
        public async Task<IHttpActionResult> Informacion([FromUri] string num_presupuesto)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = null;
            await Task.Run(() =>
            {
                result = Business.Backoffice.Common.InformacionDePresupuesto(num_presupuesto);
            }).ConfigureAwait(false);
            return Ok(result);
        }

        #region Hogar Total

        /// <summary>
        /// Devuelve la estructura de datos con los valores por defecto para una cotización de tipo Hogar Total
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("HogarTotalSetup")]
        public async Task<IHttpActionResult> HogarTotalSetup()
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.HogarTotal result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.HogarTotal.Setup(tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Recupera lista de valores para sumas aseguradas de coberturas o valores deducibles según el rol del usuario
        /// </summary>
        /// <param name="cod_ramo"></param>
        /// <param name="num_contrato"></param>
        /// <param name="num_subcontrato"></param>
        /// <param name="num_poliza_grupo"></param>
        /// <param name="cod_mon"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("HogarTotalSettings")]
        public async Task<IHttpActionResult> HogarTotalSettings(int cod_ramo, int num_contrato, int num_subcontrato, string num_poliza_grupo, int cod_mon)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.HogarTotalSettings result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.HogarTotal.Settings(cod_ramo, num_contrato, num_subcontrato, num_poliza_grupo, cod_mon, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet]
        [Route("MultirriesgoSettings")]
        public async Task<IHttpActionResult> MultiriesgoSettings(int cod_ramo, int num_contrato, int num_subcontrato, string num_poliza_grupo, int cod_mon)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.HogarTotalSettings result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.HogarTotal.Settings(cod_ramo, num_contrato, num_subcontrato, num_poliza_grupo, cod_mon, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la validación de datos y cálculo necesarios para obtener una cotización o presupuesto de un producto de tipo Hogar Total
        /// </summary>
        /// <param name="quoteInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("HogarTotalQuote")]
        public async Task<IHttpActionResult> HogarTotalQuote([FromBody] Tron.Contracts.Cotizacion.HogarTotal quoteInfo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.HogarTotal result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.HogarTotal.Quote(quoteInfo, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        #endregion

        #region Multirriesgo

        /// <summary>
        /// Devuelve la estructura de datos con los valores por defecto para una cotización de tipo Multirriesgo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("MultirriesgoSetup")]
        public async Task<IHttpActionResult> MultirriesgoSetup()
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Architect.API.Tron.Contracts.Cotizacion.Multirriesgo result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.Multirriesgo.Setup(tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la validación de datos y cálculo necesarios para obtener una cotización o presupuesto de un producto de tipo Multirriesgo
        /// </summary>
        /// <param name="quoteInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MultirriesgoQuote")]
        public async Task<IHttpActionResult> MultirriesgoQuote([FromBody] Tron.Contracts.Cotizacion.Multirriesgo quoteInfo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.Multirriesgo result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.Multirriesgo.Quote(quoteInfo, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        #endregion

        #region Póliza Lider

        /// <summary>
        /// Devuelve la estructura de datos con los valores por defecto para una cotización de tipo Póliza Lider
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("PolizaLiderSetup")]
        public async Task<IHttpActionResult> PolizaLiderSetup()
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Architect.API.Tron.Contracts.Cotizacion.PolizaLider result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.PolizaLider.Setup(tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la validación de datos y cálculo necesarios para obtener una cotización o presupuesto de un producto de tipo Póliza Lider
        /// </summary>
        /// <param name="quoteInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PolizaLiderQuote")]
        public async Task<IHttpActionResult> PolizaLiderQuote([FromBody] Tron.Contracts.Cotizacion.PolizaLider quoteInfo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.PolizaLider result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.PolizaLider.Quote(quoteInfo, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        #endregion

        #region MapfreMas

        /// <summary>
        /// Devuelve la estructura de datos con los valores por defecto para una cotización de tipo Mapfre Más
        /// </summary>
        [HttpGet]
        [Route("MapfreMasSetup")]
        public async Task<IHttpActionResult> MapfreMasSetup(string mode = "")
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Architect.API.Tron.Contracts.Cotizacion.MapfreMas result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.MapfreMas.Setup(mode , tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        //'http://localhost:8082/aliados/api/v1/Quote/MapfreMasSettings?cod_ramo=302&cod_mon=2&edad=18&plan=basico&cod_marca=255&_=1621315088177'.
        //Mhttp://localhost:8082/aliados/api/v1/Quote/MapfreMasSettings?cod_ramo=302&cod_mon=1&edad=18&tipo_prod=basico&cod_marca=255&contrato=0&num_subcontrato=0&_=1621480590098

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
                if (cod_agt== 0)
                {
                    cod_agt = tokenInfo.AgentCode;
                }
                result = Architect.API.Tron.Business.Cotizacion.MapfreMas.Settings(cod_ramo, cod_mon, cod_marca, cod_modelo, cod_sub_modelo, anio_sub_modelo, cod_tip_vehi, cod_uso_vehi, mca_sexo, cod_zona_circul, edad, cod_plan_auto, num_contrato, num_subcontrato, num_poliza_grupo, tipo_prod, cod_agt, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Recupera configuración de coberturas por defecto
        /// </summary>
        [HttpGet]
        [Route("MapfreMasCoverages")]
        public async Task<IHttpActionResult> MapfreMasCoverages(int cod_ramo, int cod_mon, int cod_marca, int cod_modelo, int cod_sub_modelo, int anio_sub_modelo, int cod_tip_vehi, int cod_uso_vehi, int mca_sexo, int cod_zona_circul, int edad, int cod_plan_auto, int num_contrato, int num_subcontrato, string num_poliza_grupo, int cod_agt = 0)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            List<Tron.Contracts.Comun.Cobertura> result = null;
            await Task.Run(() =>
            {
                if (cod_agt == 0)
                {
                    cod_agt = tokenInfo.AgentCode;
                }
                result = Architect.API.Tron.Business.Cotizacion.MapfreMas.CoverageByDefault(cod_ramo, cod_mon, cod_marca, cod_modelo, cod_sub_modelo, anio_sub_modelo, cod_tip_vehi, cod_uso_vehi, mca_sexo, cod_zona_circul, edad, cod_plan_auto, num_contrato, num_subcontrato, num_poliza_grupo, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la validación de datos y cálculo necesarios para obtener una cotización o presupuesto de un producto de tipo Mapfre Más
        /// </summary>
        [HttpPost]
        [Route("MapfreMasQuote")]
        public async Task<IHttpActionResult> MapfreMasQuote([FromBody] Tron.Contracts.Cotizacion.MapfreMas quoteInfo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.MapfreMas result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.MapfreMas.Quote(quoteInfo, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        #endregion

        #region Viajero

        /// <summary>
        /// Devuelve la estructura de datos con los valores por defecto para una cotización de tipo Viajero|
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ViajeroSetup")]
        public async Task<IHttpActionResult> ViajeroSetup()
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Architect.API.Tron.Contracts.Cotizacion.Viajero result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.Viajero.Setup(tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la validación de datos y cálculo necesarios para obtener una cotización o presupuesto de un producto de tipo Hogar Total
        /// </summary>
        /// <param name="quoteInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ViajeroQuote")]
        public async Task<IHttpActionResult> ViajeroQuote([FromBody] Tron.Contracts.Cotizacion.Viajero quoteInfo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.Viajero result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.Viajero.Quote(quoteInfo, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        #endregion

        #region Saldo Deudor

        /// <summary>
        /// Devuelve la estructura de datos con los valores por defecto para una cotización de tipo Saldo Deudor
        /// </summary>
        [HttpGet]
        [Route("SaldoDeudorSetup")]
        public async Task<IHttpActionResult> SaldoDeudorSetup()
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Contracts.Cotizacion.SaldoDeudor result = null;
            await Task.Run(() =>
            {
                // tokenInfo.AgentCode = 180;
                result = Business.Cotizacion.SaldoDeudor.Setup(tokenInfo);
            }).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la validación de datos y cálculo necesarios para obtener una cotización o presupuesto de un producto de tipo Saldo Deudor
        /// </summary>
        /// <param name="quoteInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaldoDeudorQuote")]
        public async Task<IHttpActionResult> SaldoDeudorQuote([FromBody] Tron.Contracts.Cotizacion.SaldoDeudor quoteInfo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.SaldoDeudor result = null;
            await Task.Run(() =>
            {
                //tokenInfo.AgentCode = 180;
                result = Architect.API.Tron.Business.Cotizacion.SaldoDeudor.Quote(quoteInfo, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Recupera lista de valores para sumas aseguradas de coberturas o valores deducibles según el rol del usuario
        /// </summary>
        /// <param name="cod_ramo"></param>
        /// <param name="num_contrato"></param>
        /// <param name="num_subcontrato"></param>
        /// <param name="num_poliza_grupo"></param>
        /// <param name="cod_mon"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SaldoDeudorSettings")]
        public async Task<IHttpActionResult> SaldoDeudorSettings(int cod_ramo, int num_contrato, int num_subcontrato, string num_poliza_grupo, int cod_mon)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.SaldoDeudorSettings result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.SaldoDeudor.Settings(cod_ramo, num_contrato, num_subcontrato, num_poliza_grupo, cod_mon, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Recupera calculo del imc de acuerdo al peso y estatura del asegurado
        /// </summary>
        /// <param name="estatura"></param>
        /// <param name="peso"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SaldoDeudorPreIMC")]
        public async Task<IHttpActionResult> SaldoDeudorPreIMC(string estatura, string peso)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.SaldoDeudor result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.SaldoDeudor.calcula_imc(estatura, peso, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        #endregion

        #region MapfreMasPlus

        /// <summary>
        /// Devuelve la estructura de datos con los valores por defecto para una cotización de tipo Mapfre Más
        /// </summary>
        [HttpGet]
        [Route("MapfreMasPlusSetup")]
        public async Task<IHttpActionResult> MapfreMasPlusSetup(string mode = "")
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Architect.API.Tron.Contracts.Cotizacion.MapfreMas result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.MapfreMasPlus.Setup(mode, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        //'http://localhost:8082/aliados/api/v1/Quote/MapfreMasPlusSettings?cod_ramo=302&cod_mon=2&edad=18&plan=basico&cod_marca=255&_=1621315088177'.
        //Mhttp://localhost:8082/aliados/api/v1/Quote/MapfreMasPlusSettings?cod_ramo=302&cod_mon=1&edad=18&tipo_prod=basico&cod_marca=255&contrato=0&num_subcontrato=0&_=1621480590098

        /// <summary>
        /// Recupera lista de valores para sumas aseguradas de coberturas o valores deducibles según el rol del usuario
        /// </summary>
        [HttpGet]
        [Route("MapfreMasPlusSettings")]
        public async Task<IHttpActionResult> MapfreMasPlusSettings(int cod_ramo, int cod_mon, int cod_marca, int cod_modelo, int cod_sub_modelo, int anio_sub_modelo, int cod_tip_vehi, int cod_uso_vehi, int mca_sexo, int cod_zona_circul, int edad, int cod_plan_auto, int num_contrato, int num_subcontrato, string num_poliza_grupo, string tipo_prod)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.MapfreMasSettings result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.MapfreMasPlus.Settings(cod_ramo, cod_mon, cod_marca, cod_modelo, cod_sub_modelo, anio_sub_modelo, cod_tip_vehi, cod_uso_vehi, mca_sexo, cod_zona_circul, edad, cod_plan_auto, num_contrato, num_subcontrato, num_poliza_grupo, tipo_prod, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Recupera configuración de coberturas por defecto
        /// </summary>
        [HttpGet]
        [Route("MapfreMasPlusCoverages")]
        public async Task<IHttpActionResult> MapfreMasPlusCoverages(int cod_ramo, int cod_mon, int cod_marca, int cod_modelo, int cod_sub_modelo, int anio_sub_modelo, int cod_tip_vehi, int cod_uso_vehi, int mca_sexo, int cod_zona_circul, int edad, int cod_plan_auto, int num_contrato, int num_subcontrato, string num_poliza_grupo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            List<Tron.Contracts.Comun.Cobertura> result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.MapfreMasPlus.CoverageByDefault(cod_ramo, cod_mon, cod_marca, cod_modelo, cod_sub_modelo, anio_sub_modelo, cod_tip_vehi, cod_uso_vehi, mca_sexo, cod_zona_circul, edad, cod_plan_auto, num_contrato, num_subcontrato, num_poliza_grupo, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la validación de datos y cálculo necesarios para obtener una cotización o presupuesto de un producto de tipo Mapfre Más
        /// </summary>
        [HttpPost]
        [Route("MapfreMasPlusQuote")]
        public async Task<IHttpActionResult> MapfreMasPlusQuote([FromBody] Tron.Contracts.Cotizacion.MapfreMas quoteInfo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.MapfreMas result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.MapfreMasPlus.Quote(quoteInfo, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        #endregion

        #region Estudiantil

        /// <summary>
        /// Devuelve la estructura de datos con los valores por defecto para una cotización de tipo estudiantil
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("EstudiantilSetup")]
        public async Task<IHttpActionResult> EstudiantilSetup()
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Architect.API.Tron.Contracts.Cotizacion.Estudiantil result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.Estudiantil.Setup(tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Realiza la validación de datos y cálculo necesarios para obtener una cotización o presupuesto de un producto de estudiantil
        /// </summary>
        /// <param name="quoteInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("EstudiantilQuote")]
        public async Task<IHttpActionResult> EstudiantilQuote([FromBody] Tron.Contracts.Cotizacion.Estudiantil quoteInfo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Tron.Contracts.Cotizacion.Estudiantil result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Cotizacion.Estudiantil.Quote(quoteInfo, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        #endregion

    }
}
