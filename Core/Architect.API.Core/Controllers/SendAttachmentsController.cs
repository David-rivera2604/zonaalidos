using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Web.Http;
using Architect.Utilities.Extensions;
using Architect.API.Core.Business.Security;

namespace Architect.API.Core.Controllers
{
    /// <summary>
    /// Envio de adjuntos relacionados a un identificador
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/SendAttachments")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SendAttachmentsController : ApiController
    {
        /// <summary>
        /// Usuario actual que ingreso desde el login.
        /// </summary>
        public static Contracts.Security.Token UsuaActual = Accounts.ReturnUser();


        /// <summary>
        /// Guarda adjuntos en la tabla Attachments.
        /// </summary>
        /// <param name="item">Instancia del objecto Attachment.</param>
        /// <returns>Información del registro creado en la tabla Attachments.</returns>
        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IHttpActionResult> Post([FromBody] Architect.API.Core.Contracts.General.ProcessCase item)
        {
            //usuario que envio la solicitud del caso.   
            UsuaActual = Accounts.ReturnUser();

            item.UserSend = UsuaActual.UserId;

            IHttpActionResult result = BadRequest();

            if (item.IsEmpty())
            {
                return BadRequest("Debe indicar un processcase");
            }
            Contracts.Security.Token tokenInfo = Security.Token.Info();
            await Task.Run(() =>
            {

                Architect.API.Core.Contracts.General.ProcessCaseResult created = Architect.API.Core.Business.General.ProcessCase.Create(tokenInfo.CompanyId, tokenInfo.UserId, item);
                

                if (created.Errors.Count == 0)
                {
                    result = Created(string.Format("{0}/{1}", Request.RequestUri.AbsoluteUri.Substring(0, Request.RequestUri.AbsoluteUri.LastIndexOf("/")), created.ProcessCase.Id), new { Id = created.ProcessCase.Id, UpdateDate = created.ProcessCase.UpdateDate });
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
                ModelState.AddModelError(string.Format("{0}.{1}", errorItem.Group, errorItem.Key), errorItem.Message);
            }
            return BadRequest(ModelState);
        }
    }
}
