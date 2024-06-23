using Architect.Utilities.Extensions;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Schema;

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

        /// <summary>
        /// Cancela una póliza
        /// </summary>
        [HttpPut]
        [Route("{num_poliza}/Cancelacion")]
        public async Task<IHttpActionResult> Cancelacion([FromUri] string num_poliza, [FromBody] Contracts.Poliza.Cancelacion datosCancelacion)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            string result = string.Empty;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Backoffice.Poliza.Cancelacion(1, num_poliza, num_poliza, datosCancelacion.Fec_Anulacion, datosCancelacion.Mot_Spto);
            }).ConfigureAwait(false);

            return Ok(new
            {
                Success = result.IsEmpty(),
                Reason = result.IsEmpty() ? "La cancelación fue procesada de forma correcta" : result
            });
        }

        /// <summary>
        /// Control técnico de una póliza, permite su aprobación o rechazo
        /// </summary>
        [HttpPut]
        [Route("{num_poliza}/ControlTecnico")]
        public async Task<IHttpActionResult> ControlTecnico([FromUri] string num_poliza, [FromBody] Contracts.Poliza.Parameters.ControlTecnicoParametros controlTecnico)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            string result = string.Empty;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Backoffice.Poliza.ControlTecnico(num_poliza, controlTecnico, tokenInfo);
            }).ConfigureAwait(false);

            return Ok(new
            {
                Success = true,
                Reason = result
            });
        }


        /// <summary>
        /// Permite renovar una póliza
        /// </summary>
        [HttpPut]
        [Route("{num_poliza}/Renovar")]
        public async Task<IHttpActionResult> Renovar([FromUri] string num_poliza)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            string result = string.Empty;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Backoffice.Poliza.Renovar(num_poliza);
            }).ConfigureAwait(false);

            return Ok(new
            {
                Success = (result == "Póliza renovada correctamente."),
                Reason = result
            });
        }

        [HttpPost]
        [Route("Altas")]
        [Authorize]
        public async Task<IHttpActionResult> Altas([FromBody] Architect.API.Tron.Contracts.AltasBajas.Request.Poliza poliza)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Architect.API.Tron.Contracts.AltasBajas.Response.Poliza result = new Contracts.AltasBajas.Response.Poliza();

            Contracts.AltasBajas.Request.SPCall sp = new Contracts.AltasBajas.Request.SPCall()
            {
                NUM_POLIZA_GRUPO = poliza.NUM_POLIZA_GRUPO,
                NUM_CONTRATO = poliza.NUM_CONTRATO,
                RAMO = poliza.RAMO,
                TIP_DOCUM_ASEG = poliza.TIP_DOCUM_ASEG.IdentificationType(),
                COD_DOCUM_ASEG = poliza.COD_DOCUM_ASEG,
                NOM_TERCERO_ASEG = poliza.NOM_TERCERO_ASEG,
                APE_TERCERO_ASEG = poliza.APE_TERCERO_ASEG,
                MCA_SEXO_ASEG = poliza.MCA_SEXO_ASEG == "1" ? "M" : "F",
                NACIONALIDAD_ASEG = poliza.NACIONALIDAD_ASEG,
                COD_ESTADO = poliza.COD_ESTADO,
                COD_PROVINCIA = poliza.COD_PROVINCIA,
                COD_LOCALIDAD = poliza.COD_LOCALIDAD,
                DOMICILIO = poliza.DOMICILIO,
                NUM_PRESTAMO = poliza.NUM_PRESTAMO,
                IMP_SUMA_ASEG = poliza.IMP_SUMA_ASEG,
                IMP_PRIMA_INFORMADA = poliza.IMP_PRIMA_INFORMADA,
                ID_CRED_ESTUDIANTE = poliza.ID_CRED_ESTUDIANTE,
                MCA_ASISTENCIA = poliza.MCA_ASISTENCIA,
                IMP_SUMA_MUERTE = poliza.IMP_SUMA_MUERTE,
                FEC_EFEC_SPTO = poliza.EFEC_SPTO.ToString("dd/MM/yyyy"),
                FEC_VCTO_SPTO = poliza.VCTO_SPTO.ToString("dd/MM/yyyy"),
                FEC_NAC_ASEG = poliza.NAC_ASEG.ToString("dd/MM/yyyy"),
                FEC_INI_PRESTAMO = poliza.INI_PRESTAMO.ToString("dd/MM/yyyy"),
                FEC_VCTO_PRESTAMO = poliza.VCTO_PRESTAMO.ToString("dd/MM/yyyy"),
                TIP_DE_PROCESO = "N"
            };

            //await Task.Run(() =>
            //{
            //    result = Architect.API.Tron.Business.Cotizacion.API.Issue(presupuesto, tokenInfo);
            //}).ConfigureAwait(false);
            return Ok(sp);
        }

        [HttpPost]
        [Route("Bajas")]
        [Authorize]
        public async Task<IHttpActionResult> Bajas([FromBody] Architect.API.Tron.Contracts.AltasBajas.Request.Poliza poliza)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Contracts.Poliza.API.Poliza result = null;
            //await Task.Run(() =>
            //{
            //    result = Architect.API.Tron.Business.Cotizacion.API.Issue(presupuesto, tokenInfo);
            //}).ConfigureAwait(false);
            return Ok(poliza);
        }

    }
}
