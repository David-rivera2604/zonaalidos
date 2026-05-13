using Architect.API.Tron.Contracts.Masivos;
using Asp.Versioning;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Permite ejecutar las acciones vinculadas con los procesos de carga masiva.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Masivos")]
    public class MasivosController : ApiController
    {
        /// <summary>
        /// Consulta las cargas masivas registradas, opcionalmente filtradas por código de ramo.
        /// </summary>
        /// <param name="codRamo">Código del ramo (opcional).</param>
        /// <returns>Lista de cargas registradas.</returns>
        [HttpGet]
        [Route("Cargas")]
        public async Task<IHttpActionResult> Cargas(int? codRamo = null)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            List<MasivoCarga> result = null;

            await Task.Run(() =>
            {
                result = Business.Masivos.MasivosBusiness.Consultar(codRamo);
            }).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        /// Recibe un archivo CSV y lo registra como carga masiva.
        /// </summary>
        /// <returns>Resultado de la operación de carga.</returns>
        [HttpPost]
        [Route("CargarCsv")]
        public async Task<IHttpActionResult> CargarCsv()
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            MasivoResult result = null;

            if (!Request.Content.IsMimeMultipartContent())
            {
                return StatusCode(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider).ConfigureAwait(false);

            int codRamo = 0;
            byte[] fileBytes = null;
            string fileName = string.Empty;
            int fileSize = 0;

            foreach (var content in provider.Contents)
            {
                var disposition = content.Headers.ContentDisposition;
                string fieldName = disposition.Name.Trim('"');

                if (fieldName == "codRamo")
                {
                    string value = await content.ReadAsStringAsync().ConfigureAwait(false);
                    int.TryParse(value, out codRamo);
                }
                else if (fieldName == "file")
                {
                    fileBytes = await content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    fileName = disposition.FileName != null ? disposition.FileName.Trim('"') : "archivo.csv";
                    fileSize = fileBytes.Length;
                }
            }

            if (codRamo == 0 || fileBytes == null || fileBytes.Length == 0)
            {
                return BadRequest("Debe indicar el código de ramo y adjuntar un archivo CSV válido.");
            }

            await Task.Run(() =>
            {
                result = Business.Masivos.MasivosBusiness.Cargar(codRamo, fileName, fileBytes, fileSize, tokenInfo.UserName);
            }).ConfigureAwait(false);

            if (result.Exitoso)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, result);
            }
        }

        /// <summary>
        /// Ejecuta el procesamiento de una carga masiva previamente registrada.
        /// </summary>
        /// <param name="request">Datos del procesamiento (codRamo, fileName).</param>
        /// <returns>Resultado del procesamiento.</returns>
        [HttpPost]
        [Route("Procesar")]
        public async Task<IHttpActionResult> Procesar([FromBody] MasivoProcesarRequest request)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            MasivoResult result = null;

            if (request == null || request.codRamo == 0)
            {
                return BadRequest("Debe indicar el código de ramo.");
            }

            await Task.Run(() =>
            {
                result = Business.Masivos.MasivosBusiness.Procesar(request.codRamo, request.fileName);
            }).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
