using Microsoft.Web.Http;
using System;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Web.Http;
using Architect.API.Core.Business.Security;
using System.IO;

namespace Architect.API.Core.Controllers
{
    /// <summary>
    /// Envio de adjuntos relacionados a un identificador
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/SendAttachments")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class SendAttachmentsController : ApiController
    {
        /// <summary>
        /// Usuario actual que ingreso desde el login.
        /// </summary>
        public static Contracts.Security.Token UsuaActual = Accounts.ReturnUser();


        /// <summary>
        /// Recibe documentos a ser asociados a una póliza emitida.
        /// </summary>
        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IHttpActionResult> SendAttachments(Architect.API.Core.Contracts.General.Attachment_customers.Attachments_customer attachments)
        {
            Contracts.Security.Token tokenInfo = Security.Token.Info();
            Architect.API.Core.Contracts.General.Attachments _documento;

            Architect.API.Core.Contracts.General.GenericResponse result = new Contracts.General.GenericResponse 
            {
            Successful = true,
            Reason = "Adjuntos recibidos correctamente"
            };

            try { 

                if (attachments.entity_id == null)
                {
                    return BadRequest("Debe indicar el entity_id");
                }
                if(attachments.attachments_list == null){
                    return BadRequest("Debe existir una lista de documentos");
                }

                foreach (Contracts.General.Attachment_customers.Attachment_customer documento in attachments.attachments_list)
                {
                    byte[] bytes = Convert.FromBase64String(documento.file_content_base64);
                    string filename = string.Format("{0}{1}", Architect.Utilities.Helpers.Settings.StringValue("Attachments.Path"), documento.file_name);
                    using (var stream = new FileStream(filename, FileMode.Create))
                    {
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Flush();
                    }

                    _documento = new Architect.API.Core.Contracts.General.Attachments()
                    {
                        EntityType = 3000,
                        EntityId = Int64.Parse(attachments.entity_id),
                        EntitySubType = 0,
                        CompanyId = tokenInfo.CompanyId,
                        UpdateUserCode = tokenInfo.UserId,
                        DocumentType = documento.document_type,
                        Description = documento.file_name,
                        FileName = documento.file_name,
                        FileSize = Int32.Parse(documento.file_size),
                        FileContent = filename
                    };
                    Architect.API.Core.Business.General.Attachment.SyncUp(_documento);
                }

                return Ok(result);
            
           }
            catch(Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

    }
}
