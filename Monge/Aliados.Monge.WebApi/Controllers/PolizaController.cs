using Aliados.Monge.Application.Poliza;
using Aliados.Monge.Domain.Poliza.Certificado;
using Aliados.Monge.Domain.Poliza.Documentos;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Aliados.Monge.WebApi.Controllers
{
    /// <summary>
    /// Manejo de pólizas en MAPFRE
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Poliza")]
    public class PolizaController : ApiController
    {
        /// <summary>
        /// Emite una póliza.
        /// </summary>
        [HttpPost]
        [Route("Emision")]
        [Authorize]
        [ResponseType(typeof(Domain.Poliza.Emision.Respuesta))]
        public async Task<IHttpActionResult> Emision(Domain.Poliza.Emision.Poliza risk)
        {
            Architect.API.Core.Contracts.Security.Token tokenInfo = Architect.API.Core.Security.Token.Info_V2();
            if (risk == null)
            {
                return BadRequest("Debe indicar un objeto Poliza");
            }
            return Ok(Application.Poliza.Emision.Handler(risk, tokenInfo).Result);
        }

        /// <summary>
        /// Recibe documentos a ser asociados a una póliza emitida.
        /// </summary>
        [HttpPost]
        [Route("Documentos")]
        [Authorize]
        [ResponseType(typeof(Domain.Poliza.Documentos.RespuestaDocumentos))]
        public async Task<IHttpActionResult> Documentos(Domain.Poliza.Documentos.Documentos documentos)
        {
            Architect.API.Core.Contracts.Security.Token tokenInfo = Architect.API.Core.Security.Token.Info_V2();
            if (documentos == null)
            {
                return BadRequest("Debe indicar un objeto Documentos");
            }
            return Ok(Application.Poliza.Documentos.Handler(documentos, tokenInfo).Result);
        }

        /// <summary>
        /// Recuperar el certificado asociado a una póliza.
        /// </summary>
        [HttpPost]
        [Route("Certificado")]
        [Authorize]
        [ResponseType(typeof(Domain.Poliza.Certificado.RespuestaCertificado))]
        public async Task<IHttpActionResult> Certificado(Domain.Poliza.Certificado.Certificado certificado)
        {
            Architect.API.Core.Contracts.Security.Token tokenInfo = Architect.API.Core.Security.Token.Info_V2();
            if (certificado == null)
            {
                return BadRequest("Debe indicar un objeto Certificado");
            }
            return Ok(Application.Poliza.Certificado.Handler(certificado, tokenInfo).Result);
        }

        /// <summary>
        /// Cancela o anula una póliza emitida.
        /// </summary>
        [HttpPost]
        [Route("Cancelacion")]
        [Authorize]
        [ResponseType(typeof(Domain.Poliza.Cancelacion.RespuestaCancelacion))]
        public async Task<IHttpActionResult> Cancelacion(Domain.Poliza.Cancelacion.SolicitudDeCancelacion solicitud)
        {
            Architect.API.Core.Contracts.Security.Token tokenInfo = Architect.API.Core.Security.Token.Info_V2();
            if (solicitud == null)
            {
                return BadRequest("Debe indicar un objeto SolicitudDeCancelacion");
            }
            return Ok(Application.Poliza.Cancelacion.Handler(solicitud, tokenInfo).Result);
        }

        /// <summary>
        /// Recupera el estado de una solicitud.
        /// </summary>
        [HttpPost]
        [Route("Consulta")]
        [Authorize]
        [ResponseType(typeof(Domain.Poliza.Consulta.RespuestaConsulta))]
        public async Task<IHttpActionResult> Consulta(Domain.Poliza.Consulta.Solicitud solicitud)
        {
            Architect.API.Core.Contracts.Security.Token tokenInfo = Architect.API.Core.Security.Token.Info_V2();
            if (solicitud == null)
            {
                return BadRequest("Debe indicar un objeto Solicitud");
            }
            return Ok(Application.Poliza.Consulta.Handler(solicitud, tokenInfo).Result);
        }
    }
}
