using Architect.API.Tron.Contracts.Masivos;
using Asp.Versioning;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Architect.API.Tron.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Masivos")]
    public class MasivosController : ApiController
    {
        /// <summary>
        /// Obtiene las cargas masivas registradas para el usuario autenticado.
        /// </summary>
        /// <param name="codCia">Código de compañía a filtrar (opcional).</param>
        /// <returns>Lista de cargas masivas.</returns>
        [HttpGet]
        [Route("Cargas")]
        public async Task<IHttpActionResult> Cargas(int? codCia = null)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            List<MasivoCarga> result = null;

            await Task.Run(() =>
            {
                result = Business.Masivos.MasivosBusiness.Consultar(tokenInfo.UserId, 1);
            }).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        /// Consulta el avance de varios procesamientos en curso en una sola solicitud (uso en polling por lote).
        /// </summary>
        /// <param name="ids">Identificadores de los registros de carga a consultar.</param>
        /// <returns>Lista con el mensaje de avance de cada identificador.</returns>
        [HttpPost]
        [Route("ResultadosBatch")]
        public async Task<IHttpActionResult> ResultadosBatch([FromBody] List<int> ids)
        {
            List<MasivoResultadoProceso> result = new List<MasivoResultadoProceso>();

            if (ids != null && ids.Count > 0)
            {
                await Task.Run(() =>
                {
                    result = Business.Masivos.MasivosBusiness.ConsultarResultados(ids);
                }).ConfigureAwait(false);
            }

            return Ok(result);
        }

        /// <summary>
        /// Recibe un archivo CSV multipart y lo registra como una nueva carga masiva.
        /// </summary>
        /// <returns>Resultado de la carga del archivo.</returns>
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
                result = Business.Masivos.MasivosBusiness.Cargar(codRamo, fileName, fileBytes, fileSize, tokenInfo.UserId);
            }).ConfigureAwait(false);

            if (result.Exitoso)
            {
                return Ok(result);
            }

            return Content(HttpStatusCode.InternalServerError, result);
        }

        /// <summary>
        /// Ejecuta la validación del archivo de carga masiva indicado.
        /// </summary>
        /// <param name="request">Request con el identificador del registro a validar.</param>
        /// <returns>Resultado de la validación.</returns>
        [HttpPost]
        [Route("Validar")]
        public async Task<IHttpActionResult> Validar([FromBody] MasivoProcesarRequest request)
        {
            if (request == null || request.id <= 0)
            {
                return BadRequest("Debe indicar el identificador del registro.");
            }

            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            MasivoResult result = null;

            await Task.Run(() =>
            {
                result = Business.Masivos.MasivosBusiness.Validar(request.id, tokenInfo.UserId);
            }).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        /// Ejecuta el procesamiento del archivo de carga masiva indicado.
        /// </summary>
        /// <param name="request">Request con el identificador del registro a procesar.</param>
        /// <returns>Resultado del procesamiento.</returns>
        [HttpPost]
        [Route("Procesar")]
        public async Task<IHttpActionResult> Procesar([FromBody] MasivoProcesarRequest request)
        {
            if (request == null || request.id <= 0)
            {
                return BadRequest("Debe indicar el identificador del registro.");
            }

            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            MasivoResult result = null;

            await Task.Run(() =>
            {
                result = Business.Masivos.MasivosBusiness.Procesar(request.id, tokenInfo.UserId);
            }).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        /// Recibe un archivo CSV multipart y actualiza el archivo de carga de un registro existente.
        /// </summary>
        /// <returns>Resultado de la actualización del archivo.</returns>
        [HttpPost]
        [Route("ActualizarArchivo")]
        public async Task<IHttpActionResult> ActualizarArchivo()
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            if (!Request.Content.IsMimeMultipartContent())
            {
                return StatusCode(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider).ConfigureAwait(false);

            int id = 0;
            byte[] fileBytes = null;
            string fileName = string.Empty;
            int fileSize = 0;

            foreach (var content in provider.Contents)
            {
                var disposition = content.Headers.ContentDisposition;
                string fieldName = disposition.Name.Trim('"');

                if (fieldName == "id")
                {
                    string value = await content.ReadAsStringAsync().ConfigureAwait(false);
                    int.TryParse(value, out id);
                }
                else if (fieldName == "file")
                {
                    fileBytes = await content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    fileName = disposition.FileName != null ? disposition.FileName.Trim('"') : "archivo.csv";
                    fileSize = fileBytes.Length;
                }
            }

            if (id <= 0 || fileBytes == null || fileBytes.Length == 0)
            {
                return BadRequest("Debe indicar el identificador del registro y adjuntar un archivo CSV válido.");
            }

            MasivoResult result = null;
            await Task.Run(() =>
            {
                result = Business.Masivos.MasivosBusiness.ActualizarArchivo(id, fileName, fileBytes, fileSize, tokenInfo.UserId);
            }).ConfigureAwait(false);

            if (result.Exitoso)
            {
                return Ok(result);
            }

            return Content(HttpStatusCode.InternalServerError, result);
        }
    }
}
