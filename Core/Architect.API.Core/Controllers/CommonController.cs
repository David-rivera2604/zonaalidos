using Architect.Utilities.Extensions;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;
using Architect.API.Core.Business.General;

namespace Architect.API.Core.Controllers
{
    /// <summary>
    /// Acciones para obtener cualquier lista de valores disponible de la aplicación.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Common")]
    public class CommonController : ApiController
    {
        /// <summary>
        /// Lista de valores disponibles según la clave de valores posibles.
        /// </summary>
        /// <param name="key">clave de la lista de valores posibles.</param>
        /// <param name="parentId">clave que identifica el agrupado de la lista dependiente.</param>
        /// <param name="url"></param>
        /// <returns>Lista de valores disponibles</returns>
        [HttpGet]
        [Route("LkpChild")]
        public IQueryable<Contracts.General.LookupValue> LkpChild([FromUri] string key, [FromUri] int parentId, [FromUri] string url = "")
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();

            List<Contracts.General.LookupValue> values = Business.Common.LkpChild(key, parentId, url, tokenInfo);
            return values.AsQueryable();
        }

        /// <summary>
        /// Recupera múltiples lista de valores disponibles a partir de múltiples claves.
        /// </summary>
        /// <param name="keys">Lista de claves de valores posibles separadas por coma.</param>
        /// <param name="url"></param>
        /// <returns>Múltiples listas de valores disponibles</returns>
        [HttpGet]
        [Route("Lkps")]
        [Authorize]
        public IQueryable<Contracts.General.LookupValues> Lkps([FromUri] string keys, [FromUri] string url = "")
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();

            List<Contracts.General.LookupValues> values = Business.Common.Lkps(keys, url, tokenInfo);
            return values.AsQueryable();
        }

        /// <summary>
        /// Permite recuperar la lista optimizada para consulta del seguimiento de los cambios disponibles por medio del tipo de entidad y su respectiva identificación.
        /// </summary>
        /// <param name="entityType">Tipo de entidad.</param>
        /// <param name="entityId">Identificación de la entidad.</param>
        /// <returns>Lista optimizada para consulta del seguimiento de los cambios.</returns>
        [HttpGet]
        [Route("ChangeSets")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult ChangeSets([FromUri] int entityType, [FromUri] Int64 entityId = 0, string filter = "")
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();

            List<Contracts.General.ChangeSetView> result = Business.General.ChangeSet.RetrieveByEntity(entityType, entityId, tokenInfo.CompanyId, filter);
            if (result.IsEmpty())
                return NotFound();
            else
                return Ok(result);
        }

        /// <summary>
        /// Permite recuperar la lista optimizada para consulta de los adjuntos disponibles por medio del tipo de entidad y su respectiva identificación.
        /// </summary>
        /// <param name="entityType">Tipo de entidad.</param>
        /// <param name="entityId">Identificación de la entidad.</param>
        /// <returns>Lista optimizada para consulta de los adjuntos disponibles.</returns>
        [HttpGet]
        [Route("Attachments")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Attachments([FromUri] int entityType, [FromUri] Int64 entityId)
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();
            List<Contracts.General.AttachmentView> result = Business.General.Attachment.RetrieveByEntity(entityType, entityId, tokenInfo.CompanyId);
            if (result.IsEmpty())
                return NotFound();
            else
                return Ok(result);
        }

        [HttpPost]
        [Route("Attachments")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> Post([FromBody] Contracts.General.Attachments item)
        {
            IHttpActionResult result = BadRequest();
            if (item.IsEmpty())
            {
                return BadRequest("Debe indicar un adjunto");
            }
            Contracts.Security.Token tokenInfo = Security.Token.Info();
            await Task.Run(() =>
            {
                item = Architect.API.Core.Business.General.Attachment.SyncUpBase(item, tokenInfo.CompanyId, tokenInfo.UserId);
                if (item.Id != 0)
                {
                    result = Created(string.Format("{0}/{1}", Request.RequestUri.AbsoluteUri.Substring(0, Request.RequestUri.AbsoluteUri.LastIndexOf("/")), item.Id), new { Id = item.Id, UpdateDate = item.UpdateDate });
                }

            }).ConfigureAwait(false);
            return result;
        }

        [HttpDelete]
        [Route("Attachments/{id:int}")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> AttachmentsDelete([FromUri] int id)
        {
            IHttpActionResult result = NotFound();

            if (id.IsEmpty())
            {
                return BadRequest("Debe indicar el identificador del adjunto");
            }

            Contracts.Security.Token tokenInfo = Security.Token.Info();
            await Task.Run(() =>
            {
                Architect.API.Core.Business.General.Attachment.Delete(id);
                result = Ok(new { Id = id });
            }).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Permite la carga de forma temporal de un archivo para ser vinculado como adjunto o documento requerido.
        /// </summary>
        /// <returns>Datos del archivo cargado, principalmente el nombre único.</returns>
        [HttpPost]
        [Route("Upload")]
        [Authorize]
        public HttpResponseMessage Upload()
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();
            List<dynamic> result = new List<dynamic>();
            var httpContext = HttpContext.Current;
            // Check for any uploaded file
            if (httpContext.Request.Files.Count > 0)
            {
                //Loop through uploaded files
                for (int i = 0; i < httpContext.Request.Files.Count; i++)
                {
                    HttpPostedFile httpPostedFile = httpContext.Request.Files[i];
                    if (httpPostedFile.IsValidFileFormat())
                    {
                        int size = httpPostedFile.ContentLength;
                        int id = 0;
                        string fileName = string.Format("{0}{1}", Guid.NewGuid(), Path.GetExtension(httpPostedFile.FileName));
                        string fullFileName = Path.Combine(HostingEnvironment.MapPath(ConfigurationManager.AppSettings["Files.Path"]), fileName);
                        httpPostedFile.SaveAs(fullFileName);


                        if (httpContext.Request.Form?.Get("entityType") != null &&
                            httpContext.Request.Form?.Get("entityId") != null &&
                            httpContext.Request.Form?.Get("DocumentType") != null &&
                            httpContext.Request.Form?.Get("Description") != null)
                        {
                            Contracts.General.Attachments attachment = new Contracts.General.Attachments
                            {
                                EntityType = Convert.ToInt32(httpContext.Request.Form?.Get("EntityType")),
                                EntityId = Convert.ToInt64(httpContext.Request.Form?.Get("EntityId")),
                                CompanyId = tokenInfo.CompanyId,
                                UpdateUserCode = tokenInfo.UserId,
                                DocumentType = Convert.ToInt32(httpContext.Request.Form?.Get("DocumentType")),
                                Description = httpContext.Request.Form?.Get("Description"),
                                FileName = httpPostedFile.FileName,
                                FileSize = size,
                                FileContent = fullFileName
                            };
                            attachment = Architect.API.Core.Business.General.Attachment.SyncUp(attachment);
                            id = attachment.Id;
                        }
                        result.Add(new { FileName = httpPostedFile.FileName, StoredFileName = fileName, Size = size, Id = id });
                    }


                }
            }

            return Request.CreateResponse(HttpStatusCode.Created, result);
        }

        [Route("Download")]
        [HttpGet]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Download([FromUri] int id)
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();
            Architect.API.Core.Contracts.General.AttachmentItem result = Business.General.Attachment.RetrieveById(id);
            return Ok(result);
        }

        [Route("Download2")]
        [HttpGet]
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        public HttpResponseMessage Download2([FromUri] int id)
        {
            //Core.Contracts.Security.Token tokenInfo = Security.Token.Info();
            Architect.API.Core.Contracts.General.AttachmentItem result2 = Business.General.Attachment.RetrieveById(id);

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var dataStream = new MemoryStream(result2.Content);
            result.Content = new StreamContent(dataStream);
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            result.Content.Headers.ContentDisposition.FileName = result2.FileName;
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(result2.Type);
            result.Content.Headers.ContentLength = dataStream.Length;
            return result;
        }

        //[Route("Download2")]
        //[HttpGet]
        //[AllowAnonymous]
        //public HttpResponseMessage Download2([FromUri]int id)
        //{
        //    //Core.Contracts.Security.Token tokenInfo = Security.Token.Info();
        //    Architect.API.Core.Contracts.General.AttachmentItem result2 = Business.General.Attachment.RetrieveById(id, 1);
        //    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        //    var dataStream = new MemoryStream(result2.Content);
        //    result.Content = new StreamContent(dataStream);
        //    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
        //    result.Content.Headers.ContentDisposition.FileName = result2.FileName;
        //    result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
        //    result.Content.Headers.ContentLength = dataStream.Length;
        //    return result;

        //}

        [Route("RenderCustomFields")]
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult RenderCustomFields([FromUri] int entityType)
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();

            return Ok(Business.General.CustomFields.Render(entityType, tokenInfo.CompanyId));
        }

        [Route("Cache/{prefix?}")]
        [HttpGet]
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Cache([FromUri] string prefix = "")
        {
            return Ok(Business.Common.Cache(prefix));
        }

        /// <summary>
        /// Permite recuperar la lista optimizada para consulta de los adjuntos disponibles por medio del tipo de entidad y su respectiva identificación.
        /// </summary>
        /// <param name="entityType">Tipo de entidad.</param>
        /// <param name="entityId">Identificación de la entidad.</param>
        /// <returns>Lista optimizada para consulta de los adjuntos disponibles.</returns>
        [HttpGet]
        [Route("Notes")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Notes([FromUri] int entityType, [FromUri] Int64 entityId)
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();
            List<Contracts.General.Notes> result = Business.General.Notes.RetrieveByEntity(entityType, entityId, tokenInfo.CompanyId);
            if (result.IsEmpty())
                return NotFound();
            else
                return Ok(result);
        }

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla Notes.
        /// </summary>
        /// <param name="item">Instancia del objecto Notes.</param>
        /// <returns>Información del registro creado en la tabla Notes.</returns>
        [HttpPost]
        [Route("Note")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> Post([FromBody] Architect.API.Core.Contracts.General.Notes item)
        {
            IHttpActionResult result = BadRequest();
            if (item.IsEmpty())
            {
                return BadRequest("Debe indicar una nota");
            }
            Contracts.Security.Token tokenInfo = Security.Token.Info();
            await Task.Run(() =>
            {
                Architect.API.Core.Contracts.General.NotesResult created = Architect.API.Core.Business.General.Notes.CreateOrUpdate(tokenInfo.CompanyId, tokenInfo.UserId, item);
                if (created.Errors.Count == 0)
                {
                    result = Created(string.Format("{0}/{1}", Request.RequestUri.AbsoluteUri.Substring(0, Request.RequestUri.AbsoluteUri.LastIndexOf("/")), created.Notes.Id), new { Id = created.Notes.Id, UpdateDate = created.Notes.UpdateDate });
                }
                else
                {
                    result = ErrorHandler(created.Errors);
                }
            }).ConfigureAwait(false);
            return result;
        }


        /// <summary>
        /// Manejo general de los error de validación.
        /// </summary>
        /// <param name="errors">Lista de errores de validación.</param>
        /// <returns>Repuesta de tipo BadRequest con el detalle de los errores de validación.</returns>
        private IHttpActionResult ErrorHandler(List<Contracts.General.Error> errors)
        {
            ModelState.Clear();
            foreach (Contracts.General.Error errorItem in errors)
            {
                //string.Format("{0}.{1}:{2}", s.Group, s.Key, s.Message)
                ModelState.AddModelError(errorItem.Key, errorItem.Message);
            }
            return BadRequest(ModelState);
        }


        /// <summary>
        /// Permite el envío de correos electrónico.
        /// </summary>
        [HttpPost]
        [Route("SendEmail")]
        [Authorize]
        public async Task<IHttpActionResult> SendEmail([FromBody] Architect.API.Core.Contracts.General.SendEMail item)
        {
            IHttpActionResult result = BadRequest();
            if (item.IsEmpty())
            {
                return BadRequest("Debe indicar una solicitud de envio de correo");
            }
            if (item.To.IsEmpty() || item.Subject.IsEmpty() || item.Body.IsEmpty())
            {
                return BadRequest("Debe indicar todos los parámetros (to, subject, body)");
            }

            Contracts.Security.Token tokenInfo = Security.Token.Info();
            await Task.Run(() =>
            {
                Dictionary<string, string> receip = new Dictionary<string, string>();
                foreach (var email in item.To.Split(';'))
                {
                    receip.Add(email, string.Empty);
                }
                Core.Business.General.Mail.SendEmail(receip, item.Subject, item.Body);
            }).ConfigureAwait(false);
            return Ok(true);
        }

    }
}
