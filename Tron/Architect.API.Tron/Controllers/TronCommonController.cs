using Microsoft.Web.Http;
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

        [HttpGet]
        [Route("Producto")]
        public async Task<IHttpActionResult> Producto([FromUri] string alias)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Contracts.Especificacion.Producto result = null;
            await Task.Run(() =>
            {
                result = Business.Reglas.research.GetProducto(alias);
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

        //[Route("EnviarCertificado/{num_poliza}/{correoprincipal}/{correocopia1}/{correocopia2}")]
        /// <summary>
        /// Permite el envió de un certificado por correo
        /// </summary>
        /// <param name="num_poliza"></param>
        /// <param name="correoprincipal"></param>
        /// <param name="correocopia1"></param>
        /// <param name="correocopia2"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("EnviarCertificado")]
        public async Task<IHttpActionResult> EnviarCertificado([FromUri] string num_poliza, [FromUri] string correoprincipal, [FromUri] string correocopia1, [FromUri] string correocopia2)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            string result = "";
            await Task.Run(() =>
            {
                result = Architect.API.Tron.Business.Backoffice.Common.EnviarCertificado(num_poliza, correoprincipal, correocopia1, correocopia2, tokenInfo);
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
            var dataStream = new MemoryStream(Architect.API.Tron.Business.Backoffice.Common.ImprimirPoliza(num_poliza, num_riesgo));
            result.Content = new StreamContent(dataStream);
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            result.Content.Headers.ContentDisposition.FileName = "Mapfre Certificado.pdf";
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
            result.Content.Headers.ContentLength = dataStream.Length;
            return result;
        }

        /// <summary>
        /// Descarga un recibo asociado a una póliza
        /// </summary>
        /// <param name="num_recibo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ImprimirRecibo/{num_recibo}")]
        public HttpResponseMessage ImprimirRecibo([FromUri] int num_recibo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var dataStream = new MemoryStream(Architect.API.Tron.Business.Backoffice.Common.ImprimirRecibo(num_recibo));
            result.Content = new StreamContent(dataStream);
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            result.Content.Headers.ContentDisposition.FileName = "Mapfre Recibo.pdf";
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
            result.Content.Headers.ContentLength = dataStream.Length;
            return result;
        }

    }
}
