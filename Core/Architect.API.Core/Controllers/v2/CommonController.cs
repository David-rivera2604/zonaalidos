using Architect.API.Core.Business;
using Architect.API.Core.Business.General;
using Architect.API.Core.Contracts.General;
using Architect.Utilities.Extensions;
using Architect.Utilities.Helpers;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace Architect.API.Process.WebApi.Controllers.v2
{
    [ApiVersion("2.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Common")]
    public class CommonController : ApiController
    {
        private const string FILENAME_PLACEHOLDER = "#filename#";
        private const string FORM_ENTITY_TYPE = "EntityType";
        private const string FORM_ENTITY_ID = "EntityId";
        private const string FORM_DOCUMENT_TYPE = "DocumentType";
        private const string FORM_DESCRIPTION = "Description";
        private const string FILES_PATH_KEY = "Files.Path";

        private const string ERROR_INVALID_FILE_FORMAT = "El archivo {0} no es válido para su tipo";
        private const string ERROR_INVALID_FILE_SIZE = "El archivo {0} no tiene el tamaño permitido";
        private const string ERROR_FILE_SAVE = "Error al guardar el archivo {0}";
        private const string ERROR_PROCESSING_FILE = "Error al procesar el archivo {0}: {1}";
        private const string ERROR_NO_CONTEXT = "No se pudo obtener el contexto HTTP actual";

        [HttpPost]
        [Route("Upload")]
        [Authorize]
        public HttpResponseMessage Upload()
        {
            try
            {
                var httpContext = HttpContext.Current;
                if (httpContext.IsEmpty())
                {
                    return CreateErrorResponse(ERROR_NO_CONTEXT);
                }

                var tokenInfo = Core.Security.Token.Info();
                var successResults = new List<object>();
                var failedResults = new List<object>();

                Utilities.Log.TraceLog("CommonController.Upload", $"═══════════════════════════════════════");
                Utilities.Log.TraceLog("CommonController.Upload", $"Files.Count: {httpContext.Request.Files.Count}");
                Utilities.Log.TraceLog("CommonController.Upload", $"ContentType: {httpContext.Request.ContentType}");
                Utilities.Log.TraceLog("CommonController.Upload", $"ContentLength: {httpContext.Request.ContentLength}");
                Utilities.Log.TraceLog("CommonController.Upload", $"═══════════════════════════════════════");

                if (httpContext.Request.Files.Count == 0)
                {
                    Utilities.Log.TraceLog("CommonController.Upload", "No se recibieron archivos en la solicitud");
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        Success = successResults,
                        Failed = failedResults
                    });
                }

                for (var i = 0; i < httpContext.Request.Files.Count; i++)
                {
                    var uploadedFile = httpContext.Request.Files[i];

                    Utilities.Log.TraceLog("CommonController.Upload", $"───────────────────────────────────────");
                    Utilities.Log.TraceLog("CommonController.Upload", $"Archivo {i + 1}/{httpContext.Request.Files.Count}:");

                    if (uploadedFile.IsEmpty())
                    {
                        Utilities.Log.TraceLog("CommonController.Upload", $"Archivo en índice {i} es null");
                        failedResults.Add(new
                        {
                            FileName = $"Archivo_{i}",
                            Error = "El archivo es nulo"
                        });
                        continue;
                    }

                    Utilities.Log.TraceLog("CommonController.Upload", $"  - FileName: {uploadedFile.FileName}");
                    Utilities.Log.TraceLog("CommonController.Upload", $"  - ContentLength: {uploadedFile.ContentLength}");
                    Utilities.Log.TraceLog("CommonController.Upload", $"  - ContentType: {uploadedFile.ContentType}");
                    Utilities.Log.TraceLog("CommonController.Upload", $"───────────────────────────────────────");

                    try
                    {
                        var validationError = ValidateFile(uploadedFile);
                        if (validationError.IsNotEmpty())
                        {
                            Utilities.Log.TraceLog("CommonController.Upload", $"Validación fallida: {validationError}");
                            failedResults.Add(new
                            {
                                FileName = uploadedFile.FileName,
                                Error = validationError
                            });
                            continue;
                        }

                        var fileInfo = ProcessFile(uploadedFile, tokenInfo, httpContext);
                        if (fileInfo == null)
                        {
                            Utilities.Log.TraceLog("CommonController.Upload", $"ProcessFile retornó null");
                            failedResults.Add(new
                            {
                                FileName = uploadedFile.FileName,
                                Error = "Error al procesar el archivo"
                            });
                            continue;
                        }

                        Utilities.Log.TraceLog("CommonController.Upload", $"Archivo procesado exitosamente");
                        successResults.Add(fileInfo);
                    }
                    catch (Exception ex)
                    {
                        Utilities.Log.ErrorLog("CommonController.Upload", $"Excepción al procesar archivo: {ex.Message}", ex);
                        failedResults.Add(new
                        {
                            FileName = uploadedFile.FileName,
                            Error = ex.Message
                        });
                    }
                }

                Utilities.Log.TraceLog("CommonController.Upload", $"═══════════════════════════════════════");
                Utilities.Log.TraceLog("CommonController.Upload", $"Exitosos: {successResults.Count}");
                Utilities.Log.TraceLog("CommonController.Upload", $"Fallidos: {failedResults.Count}");
                Utilities.Log.TraceLog("CommonController.Upload", $"═══════════════════════════════════════");

                // Determinar el código de estado HTTP
                var statusCode = HttpStatusCode.OK;
                if (successResults.Count == 0 && failedResults.Count > 0)
                {
                    // Todos los archivos fallaron
                    statusCode = HttpStatusCode.BadRequest;
                }
                else if (successResults.Count > 0)
                {
                    // Al menos uno fue exitoso
                    statusCode = HttpStatusCode.Created;
                }

                return Request.CreateResponse(statusCode, new
                {
                    Success = successResults,
                    Failed = failedResults
                });
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("CommonController.Upload", $"Error inesperado: {ex.Message}", ex);
                return CreateErrorResponse($"Error inesperado: {ex.Message}");
            }
        }

        private string ValidateFile(HttpPostedFile file)
        {
            if (file.IsEmpty())
            {
                return "Archivo no válido";
            }

            if (file.FileName.IsEmpty())
            {
                return "El nombre del archivo no puede estar vacío";
            }

            if (!file.IsValidFileFormat())
            {
                return string.Format(ERROR_INVALID_FILE_FORMAT, file.FileName);
            }

            if (!file.IsValidFileSize())
            {
                return string.Format(ERROR_INVALID_FILE_SIZE, file.FileName);
            }

            return null;
        }

        private object ProcessFile(HttpPostedFile uploadedFile, Core.Contracts.Security.Token tokenInfo, HttpContext httpContext)
        {
            try
            {
                var size = uploadedFile.ContentLength;
                var storedFileName = GenerateUniqueFileName(uploadedFile.FileName);
                var fullFilePath = GetFullFilePath(storedFileName);

                EnsureDirectoryExists(fullFilePath);
                uploadedFile.SaveAs(fullFilePath);

                var attachmentId = 0;
                if (HasAttachmentMetadata(httpContext))
                {
                    attachmentId = SaveAttachment(uploadedFile, tokenInfo, httpContext, fullFilePath, size);
                }

                return new
                {
                    FileName = uploadedFile.FileName,
                    StoredFileName = storedFileName,
                    Size = size,
                    Id = attachmentId
                };
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(ERROR_PROCESSING_FILE, uploadedFile.FileName, ex.Message), ex);
            }
        }

        private string GenerateUniqueFileName(string originalFileName)
        {
            var extension = Path.GetExtension(originalFileName);
            return $"{Guid.NewGuid()}{extension}";
        }

        private string GetFullFilePath(string fileName)
        {
            var filesPath = FILES_PATH_KEY.StringValue();
            var mappedPath = HostingEnvironment.MapPath(filesPath);
            return Path.Combine(mappedPath, fileName);
        }

        private void EnsureDirectoryExists(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);
            if (directory.IsNotEmpty() && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private bool HasAttachmentMetadata(HttpContext httpContext)
        {
            var form = httpContext?.Request?.Form;
            return form != null &&
                   form.Get(FORM_ENTITY_TYPE).IsNotEmpty() &&
                   form.Get(FORM_ENTITY_ID).IsNotEmpty() &&
                   form.Get(FORM_DOCUMENT_TYPE).IsNotEmpty() &&
                   form.Get(FORM_DESCRIPTION).IsNotEmpty();
        }

        private int SaveAttachment(HttpPostedFile uploadedFile, Core.Contracts.Security.Token tokenInfo,
            HttpContext httpContext, string fullFilePath, int fileSize)
        {
            var form = httpContext.Request.Form;
            var description = form.Get(FORM_DESCRIPTION);

            if (description == FILENAME_PLACEHOLDER)
            {
                description = Path.GetFileNameWithoutExtension(uploadedFile.FileName);
            }

            var attachment = new Core.Contracts.General.Attachments
            {
                EntityType = Convert.ToInt32(form.Get(FORM_ENTITY_TYPE)),
                EntityId = Convert.ToInt64(form.Get(FORM_ENTITY_ID)),
                CompanyId = tokenInfo.CompanyId,
                UpdateUserCode = tokenInfo.UserId,
                DocumentType = Convert.ToInt32(form.Get(FORM_DOCUMENT_TYPE)),
                Description = description,
                FileName = uploadedFile.FileName,
                FileSize = fileSize,
                FileContent = fullFilePath
            };

            attachment = Architect.API.Core.Business.General.Attachment.SyncUp(attachment);
            return attachment.Id;
        }

        private HttpResponseMessage CreateErrorResponse(string message)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = message });
        }

        /// <summary>
        /// Descarga un archivo individual por su nombre almacenado o por Id de attachment.
        /// </summary>
        /// <param name="fileName">Nombre del archivo almacenado (GUID + extensión)</param>
        /// <param name="id">Id del attachment en base de datos (opcional)</param>
        /// <returns>Archivo descargable</returns>
        [HttpGet]
        [Route("Download")]
        [Authorize]
        public HttpResponseMessage Download([FromUri] string fileName = null, [FromUri] int? id = null)
        {
            try
            {
                string fullPath = null;
                string downloadFileName = null;

                byte[] fileBytes = null;

                // Si se proporciona un Id, obtener el archivo desde la base de datos
                if (id.HasValue && id.Value > 0)
                {
                    Utilities.Log.TraceLog("CommonController.Download", $"Descargando por Id: {id.Value}");

                    var attachment = Core.Business.General.Attachment.RetrieveById(id.Value);

                    if (attachment.IsEmpty())
                    {
                        Utilities.Log.TraceLog("CommonController.Download", $"Attachment no encontrado: Id={id.Value}");
                        return Request.CreateResponse(HttpStatusCode.NotFound,
                            new { Message = $"El archivo con Id {id.Value} no existe" });
                    }

                    if (attachment.Content.IsEmpty())
                    {
                        Utilities.Log.TraceLog("CommonController.Download", $"Attachment sin contenido: Id={id.Value}");
                        return Request.CreateResponse(HttpStatusCode.NotFound,
                            new { Message = $"El archivo con Id {id.Value} no tiene contenido" });
                    }

                    fileBytes = attachment.Content;
                    downloadFileName = attachment.FileName;
                    fullPath = attachment.FileName; // Para determinar MIME type

                    Utilities.Log.TraceLog("CommonController.Download", $"Archivo cargado desde BD: {downloadFileName} ({fileBytes.Length} bytes)");
                }
                else if (fileName.IsNotEmpty())
                {
                    // Descarga por nombre de archivo (comportamiento original)
                    Utilities.Log.TraceLog("CommonController.Download", $"Descargando por nombre: {fileName}");

                    var filesPath = FILES_PATH_KEY.StringValue();
                    fullPath = Path.Combine(HostingEnvironment.MapPath(filesPath), fileName);
                    downloadFileName = fileName;

                    if (!File.Exists(fullPath))
                    {
                        Utilities.Log.TraceLog("CommonController.Download", $"Archivo no encontrado en disco: {fullPath}");
                        return Request.CreateResponse(HttpStatusCode.NotFound,
                            new { Message = $"El archivo {downloadFileName} no existe en el sistema de archivos" });
                    }

                    Utilities.Log.TraceLog("CommonController.Download", $"Leyendo archivo desde disco: {fullPath}");
                    fileBytes = File.ReadAllBytes(fullPath);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        new { Message = "Debe proporcionar el nombre del archivo o su Id" });
                }
                var dataStream = new MemoryStream(fileBytes);

                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StreamContent(dataStream)
                };

                var mime = System.Web.MimeMapping.GetMimeMapping(downloadFileName);

                response.Content.Headers.ContentDisposition =
                    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                    {
                        FileName = downloadFileName
                    };

                response.Content.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue(mime);

                response.Content.Headers.ContentLength = dataStream.Length;

                return response;
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("CommonController.Download", $"Error al descargar archivo: {ex.Message}", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new { Message = $"Error al descargar el archivo: {ex.Message}" });
            }
        }

        /// <summary>
        /// Descarga múltiples archivos como un archivo ZIP.
        /// Acepta lista de strings (compatibilidad) o lista de objetos DownloadFileItem (con IsLoaded).
        /// </summary>
        /// <param name="request">Lista de nombres de archivos o estructura completa con Id/IsLoaded</param>
        /// <returns>Archivo ZIP descargable</returns>
        [HttpPost]
        [Route("DownloadZip")]
        [Authorize]
        public HttpResponseMessage DownloadZip([FromBody] dynamic request)
        {
            try
            {
                if (request.IsEmpty())
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        new { Message = "Debe proporcionar al menos un archivo" });
                }

                // Intentar procesar como List<DownloadFileItem> primero
                try
                {
                    var fileItems = ((Newtonsoft.Json.Linq.JArray)request).ToObject<List<DownloadFileItem>>();

                    if (fileItems.IsNotEmpty() && fileItems.Count > 0)
                    {
                        // Si algún item tiene IsLoaded, usar la lógica V2
                        var hasIsLoadedItems = fileItems.Any(f => f.IsLoaded);
                        if (hasIsLoadedItems)
                        {
                            Utilities.Log.TraceLog("CommonController.DownloadZip", $"Procesando con lógica V2 (IsLoaded detectado)");
                            return DownloadZipV2Internal(fileItems);
                        }

                        // Si no hay items con IsLoaded, extraer solo los nombres
                        var fileNames = fileItems.Select(f => f.StoredFileName).Where(s => s.IsNotEmpty()).ToList();
                        if (fileNames.Count > 0)
                        {
                            Utilities.Log.TraceLog("CommonController.DownloadZip", $"Procesando como nombres de archivo");
                            return DownloadZipByFileNames(fileNames);
                        }
                    }
                }
                catch
                {
                    // Si falla, intentar como lista de strings
                }

                // Compatibilidad con versión anterior: lista simple de strings
                var stringList = ((Newtonsoft.Json.Linq.JArray)request).ToObject<List<string>>();
                if (stringList.IsNotEmpty() && stringList.Count > 0)
                {
                    Utilities.Log.TraceLog("CommonController.DownloadZip", $"Procesando como lista de strings (legacy)");
                    return DownloadZipByFileNames(stringList);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    new { Message = "Debe proporcionar al menos un archivo válido" });
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("CommonController.DownloadZip", $"Error al generar ZIP: {ex.Message}", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new { Message = $"Error al generar el archivo ZIP: {ex.Message}" });
            }
        }

        /// <summary>
        /// Descarga múltiples archivos como un archivo ZIP.
        /// Versión flexible que acepta items con Id o StoredFileName.
        /// </summary>
        /// <param name="request">Lista de items con información del archivo</param>
        /// <returns>Archivo ZIP descargable</returns>
        [HttpPost]
        [Route("DownloadZipV2")]
        [Authorize]
        public HttpResponseMessage DownloadZipV2([FromBody] List<DownloadFileItem> request)
        {
            return DownloadZipV2Internal(request);
        }

        // Método interno compartido entre DownloadZip y DownloadZipV2
        private HttpResponseMessage DownloadZipV2Internal(List<DownloadFileItem> request)
        {
            try
            {
                if (request.IsEmpty() || request.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        new { Message = "Debe proporcionar al menos un archivo" });
                }

                var filesPath = FILES_PATH_KEY.StringValue();
                var mappedPath = HostingEnvironment.MapPath(filesPath);
                var filesToZip = new List<FileToZipInfo>();

                Utilities.Log.TraceLog("CommonController.DownloadZipV2Internal", $"Procesando {request.Count} archivo(s)");

                foreach (var item in request)
                {
                    try
                    {
                        // Si IsLoaded es true y tiene Id, descargar desde BD
                        if (item.IsLoaded && item.Id.HasValue && item.Id.Value > 0)
                        {
                            Utilities.Log.TraceLog("CommonController.DownloadZipV2Internal", $"Procesando archivo desde BD: Id={item.Id.Value}");

                            var attachment = Core.Business.General.Attachment.RetrieveById(item.Id.Value);

                            if (attachment.IsEmpty())
                            {
                                Utilities.Log.TraceLog("CommonController.DownloadZipV2Internal", $"[WARNING] Attachment no encontrado, saltando: Id={item.Id.Value}");
                                continue;
                            }

                            if (attachment.Content.IsEmpty())
                            {
                                Utilities.Log.TraceLog("CommonController.DownloadZipV2Internal", $"[WARNING] Attachment sin contenido, saltando: Id={item.Id.Value}");
                                continue;
                            }

                            filesToZip.Add(new FileToZipInfo
                            {
                                Content = attachment.Content,
                                ZipEntryName = attachment.FileName
                            });

                            Utilities.Log.TraceLog("CommonController.DownloadZipV2Internal", $"Archivo cargado desde BD: {attachment.FileName} ({attachment.Content.Length} bytes)");
                        }
                        // Si no es IsLoaded, usar StoredFileName
                        else if (item.StoredFileName.IsNotEmpty())
                        {
                            Utilities.Log.TraceLog("CommonController.DownloadZipV2Internal", $"Procesando archivo temporal: {item.StoredFileName}");

                            var fullPath = Path.Combine(mappedPath, item.StoredFileName);

                            if (!File.Exists(fullPath))
                            {
                                Utilities.Log.TraceLog("CommonController.DownloadZipV2Internal", $"[WARNING] Archivo no encontrado, saltando: {item.StoredFileName}");
                                continue;
                            }

                            filesToZip.Add(new FileToZipInfo
                            {
                                FullPath = fullPath,
                                ZipEntryName = item.FileName ?? item.StoredFileName
                            });
                        }
                        else
                        {
                            Utilities.Log.TraceLog("CommonController.DownloadZipV2Internal", $"[WARNING] Item inválido, saltando: Id={item.Id}, StoredFileName={item.StoredFileName}, IsLoaded={item.IsLoaded}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Utilities.Log.ErrorLog("CommonController.DownloadZipV2Internal", $"Error al procesar item: {ex.Message}", ex);
                    }
                }

                if (filesToZip.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                        new { Message = "No se encontraron archivos válidos para descargar" });
                }

                return GenerateZipResponse(filesToZip);
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("CommonController.DownloadZipV2Internal", $"Error al generar ZIP V2: {ex.Message}", ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new { Message = $"Error al generar el archivo ZIP: {ex.Message}" });
            }
        }

        // Método helper para compatibilidad con versión anterior
        private HttpResponseMessage DownloadZipByFileNames(List<string> fileNames)
        {
            var filesPath = FILES_PATH_KEY.StringValue();
            var mappedPath = HostingEnvironment.MapPath(filesPath);
            var filesToZip = new List<FileToZipInfo>();

            Utilities.Log.TraceLog("CommonController.DownloadZipByFileNames", $"Procesando {fileNames.Count} archivo(s) por nombre");

            foreach (var fileName in fileNames)
            {
                var fullPath = Path.Combine(mappedPath, fileName);

                if (!File.Exists(fullPath))
                {
                    Utilities.Log.TraceLog("CommonController.DownloadZipByFileNames", $"[WARNING] Archivo no encontrado, saltando: {fileName}");
                    continue;
                }

                filesToZip.Add(new FileToZipInfo
                {
                    FullPath = fullPath,
                    ZipEntryName = fileName
                });
            }

            if (filesToZip.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    new { Message = "No se encontraron archivos válidos para descargar" });
            }

            return GenerateZipResponse(filesToZip);
        }

        // Método helper para generar el ZIP
        private HttpResponseMessage GenerateZipResponse(List<FileToZipInfo> filesToZip)
        {
            Utilities.Log.TraceLog("CommonController.GenerateZipResponse", $"Generando ZIP con {filesToZip.Count} archivo(s)");

            using (var zipStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                {
                    foreach (var fileInfo in filesToZip)
                    {
                        Utilities.Log.TraceLog("CommonController.GenerateZipResponse", $"Agregando archivo: {fileInfo.ZipEntryName}");

                        var entry = archive.CreateEntry(fileInfo.ZipEntryName, CompressionLevel.Optimal);
                        using (var entryStream = entry.Open())
                        {
                            // Si tiene contenido en memoria, usarlo directamente
                            if (fileInfo.Content.IsNotEmpty())
                            {
                                entryStream.Write(fileInfo.Content, 0, fileInfo.Content.Length);
                            }
                            // Si no, leer desde disco
                            else if (fileInfo.FullPath.IsNotEmpty())
                            {
                                using (var fileStream = File.OpenRead(fileInfo.FullPath))
                                {
                                    fileStream.CopyTo(entryStream);
                                }
                            }
                        }
                    }
                }

                zipStream.Position = 0;
                var responseStream = new MemoryStream();
                zipStream.CopyTo(responseStream);
                responseStream.Position = 0;

                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StreamContent(responseStream)
                };

                response.Content.Headers.ContentDisposition =
                    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                    {
                        FileName = $"adjuntos_{DateTime.Now:yyyyMMddHHmmss}.zip"
                    };

                response.Content.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("application/zip");

                response.Content.Headers.ContentLength = responseStream.Length;

                Utilities.Log.TraceLog("CommonController.GenerateZipResponse", $"ZIP generado exitosamente ({responseStream.Length} bytes)");

                return response;
            }
        }
    }
}