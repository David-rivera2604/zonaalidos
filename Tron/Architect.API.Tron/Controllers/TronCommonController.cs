using Microsoft.Web.Http;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Permite ejecutar las acciones vinculadas con los proceso de cotización de tron.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/TronCommon")]
    public class TronCommonController : ApiController
    {
        /// <summary>
        /// Descarga el reporte para un aviso de cobro
        /// </summary>
        [HttpGet]
        [Route("ImprimirAviso/{num_aviso}")]
        public HttpResponseMessage ImprimirAviso([FromUri] int num_aviso)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var dataStream = new MemoryStream(Business.Backoffice.Common.ImprimirAviso(num_aviso));
            result.Content = new StreamContent(dataStream);
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline")
            {
                FileName = "Mapfre Aviso " + num_aviso.ToString() + ".pdf"
            };
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
            result.Content.Headers.ContentLength = dataStream.Length;
            return result;
        }

        /// <summary>
        /// Descarga el detalle de un reporte para un aviso de cobro
        /// </summary>
        [HttpGet]
        [Route("ImprimirAvisoDetalle/{num_aviso}")]
        public HttpResponseMessage ImprimirAvisoDetalle([FromUri] int num_aviso)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var dataStream = new MemoryStream(Business.Backoffice.Common.ImprimirAvisoDetalle(num_aviso));
            result.Content = new StreamContent(dataStream);
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline")
            {
                FileName = "Mapfre Aviso " + num_aviso.ToString() + ".pdf"
            };
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
            result.Content.Headers.ContentLength = dataStream.Length;
            return result;
        }

        [HttpGet]
        [Route("Ramo")]
        public async Task<IHttpActionResult> Ramo([FromUri] int cod_ramo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Contracts.Ramo.A1001800 result = null;
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Ramo.Configuracion.Retrieve(cod_ramo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet]
        [Route("vocabulario")]
        public async Task<IHttpActionResult> vocabulario([FromUri] string alias)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            List<Architect.Decision.Vocabulary.Vocabulary> result = null;
            await Task.Run(() =>
            {
                result = Business.Reglas.research.GetVocabulario(alias);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost]
        [Route("Producto")]
        public async Task<IHttpActionResult> Producto([FromUri] string alias, [FromBody] Contracts.Especificacion.Producto def)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Contracts.Especificacion.Producto result = null;
            await Task.Run(() =>
            {
                result = Business.Reglas.research.UpdateProducto(alias, def);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Permite el envió de un certificado por correo
        /// </summary>
        [HttpGet]
        [Route("EnviarCertificado")]
        public async Task<IHttpActionResult> EnviarCertificado([FromUri] string num_poliza, [FromUri] int num_riesgo, [FromUri] string correoprincipal, [FromUri] string correocopia1, [FromUri] string correocopia2)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            string result = string.Empty;
            await Task.Run(() =>
            {
                result = Business.Backoffice.Common.EnviarCertificado(num_poliza, num_riesgo, correoprincipal, correocopia1, correocopia2, tokenInfo);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Descarga un certificado de una póliza
        /// </summary>
        /// <param name="num_poliza"></param>
        /// <param name="num_riesgo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ImprimirPoliza/{num_poliza}/{num_riesgo}")]
        public HttpResponseMessage ImprimirPoliza([FromUri] string num_poliza, int num_riesgo = 1)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var dataStream = new MemoryStream(Business.Backoffice.Common.ImprimirPoliza(num_poliza, num_riesgo));
            result.Content = new StreamContent(dataStream);
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline")
            {
                FileName = "Mapfre Certificado.pdf"
            };
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
            result.Content.Headers.ContentLength = dataStream.Length;
            return result;
        }

    }
}
