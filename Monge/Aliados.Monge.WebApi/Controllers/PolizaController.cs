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
        [ResponseType(typeof(Domain.Poliza.Emision.Respuesta))]
        public async Task<IHttpActionResult> Emision(Domain.Poliza.Emision.Poliza risk)
        {
            Architect.API.Core.Contracts.Security.Token tokenInfo = Architect.API.Core.Security.Token.Info();
            return Ok(Application.Poliza.PolizaHandler.Emision(risk).Result);
        }

        /// <summary>
        /// Recibe documentos a ser asociados a una póliza emitida.
        /// </summary>
        [HttpPost]
        [Route("Documentos")]
        [ResponseType(typeof(Domain.Poliza.Documentos.RespuestaDocumentos))]
        public async Task<IHttpActionResult> Documentos(Domain.Poliza.Documentos.Documentos documentos)
        {
            Architect.API.Core.Contracts.Security.Token tokenInfo = Architect.API.Core.Security.Token.Info();
            return Ok(Application.Poliza.PolizaHandler.Documentos(documentos).Result);
        }

        /// <summary>
        /// Recuperar el certificado asociado a una póliza.
        /// </summary>
        [HttpPost]
        [Route("Certificado")]
        [ResponseType(typeof(Domain.Poliza.Certificado.RespuestaCertificado))]
        public async Task<IHttpActionResult> Certificado(Domain.Poliza.Certificado.Certificado certificado)
        {
            Architect.API.Core.Contracts.Security.Token tokenInfo = Architect.API.Core.Security.Token.Info();
            return Ok(Application.Poliza.PolizaHandler.Certificado(certificado).Result);
        }

        /// <summary>
        /// Cancela o anula una póliza emitida.
        /// </summary>
        [HttpPost]
        [Route("Cancelacion")]
        [ResponseType(typeof(Domain.Poliza.Cancelacion.RespuestaCancelacion))]
        public async Task<IHttpActionResult> Cancelacion(Domain.Poliza.Cancelacion.SolicitudDeCancelacion solicitud)
        {
            Architect.API.Core.Contracts.Security.Token tokenInfo = Architect.API.Core.Security.Token.Info();
            return Ok(Application.Poliza.PolizaHandler.Cancelacion(solicitud).Result);
        }

        /// <summary>
        /// Recupera el estado de una solicitud.
        /// </summary>
        [HttpPost]
        [Route("Consulta")]
        [ResponseType(typeof(Domain.Poliza.Consulta.RespuestaConsulta))]
        public async Task<IHttpActionResult> Consulta(Domain.Poliza.Consulta.Solicitud solicitud)
        {
            Architect.API.Core.Contracts.Security.Token tokenInfo = Architect.API.Core.Security.Token.Info();
            return Ok(Application.Poliza.PolizaHandler.Consulta(solicitud).Result);
        }
    }
}
