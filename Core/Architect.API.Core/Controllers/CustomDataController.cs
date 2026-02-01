using Architect.DocuSign.Integrations.Providers.Evicertia.Contracts;
using Architect.Utilities.Extensions;
using Microsoft.Web.Http;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.API.Process.WebApi.Controllers
{
    /// <summary>
    /// Acciones para manipular la tabla CustomData. Roles de seguridad.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/CustomData")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CustomDataController : ApiController
    {
        /// <summary>
        /// Crea un registro en la tabla CustomData.
        /// </summary>
        /// <param name="item">Instancia del objecto CustomData.</param>
        /// <returns>Información del registro creado en la tabla CustomData.</returns>
        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IHttpActionResult> Post([FromBody] Architect.API.Core.Contracts.General.CustomData item)
        {
            IHttpActionResult result = BadRequest();
            if (item.IsEmpty())
            {
                return BadRequest("Debe indicar un rol");
            }
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            await Task.Run(() =>
            {
                Architect.API.Core.Contracts.General.CustomDataResult created = Architect.API.Core.Business.General.CustomData.CreateOrUpdateByEntityType(tokenInfo.CompanyId, tokenInfo.UserId, item);
                if (created.Errors.Count == 0)
                {
                    result = Created(string.Format("{0}/{1}", Request.RequestUri.AbsoluteUri.Substring(0, Request.RequestUri.AbsoluteUri.LastIndexOf("/")), created.CustomData.Id), new { Id = created.CustomData.Id, UpdateDate = created.CustomData.UpdateDate });
                }
                else
                {
                    result = ErrorHandler(created.Errors);
                }
            }).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla CustomData por medio de su identificador único.
        /// </summary>
        /// <returns>Instancia del objecto CustomData.</returns>
        [HttpGet]
        [Route("{entityName}/{entityId}/Data")]
        [Authorize]
        public async Task<IHttpActionResult> GetById([FromUri] string entityName, [FromUri] string entityId)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            IHttpActionResult result = null;
            Architect.API.Core.Contracts.General.CustomData data = null;

            if (entityName.IsEmpty() || entityId.IsEmpty())
            {
                result = BadRequest("Debe indicar el tipo de entidad y la clave");
            }
            else
            {
                await Task.Run(() =>
                {
                    data = Architect.API.Core.Business.General.CustomData.RetrieveByEntity(entityName, entityId);
                    if (data.IsEmpty())
                    {
                        result = NotFound();
                    }
                    else
                    {
                        result = Ok(data.Data);
                    }
                }).ConfigureAwait(false);
            }
            return result;
        }


        [HttpGet]
        [Route("{entityName}/{entityId}/View")]
        [AllowAnonymous]
        public HttpResponseMessage View([FromUri] string entityName, [FromUri] string entityId)
        {
            Core.Contracts.General.CustomData data = Core.Business.General.CustomData.RetrieveByEntity(entityName, entityId);

            var response = new HttpResponseMessage();
            if (data.IsEmpty())
            {
                response.StatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                response.Content = new StringContent(data.Data);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
                response.StatusCode = HttpStatusCode.OK;
            }
            return response;
        }

        /// <summary>
        /// Manejo general de los error de validación.
        /// </summary>
        /// <param name="errors">Lista de errores de validación.</param>
        /// <returns>Repuesta de tipo BadRequest con el detalle de los errores de validación.</returns>
        private IHttpActionResult ErrorHandler(List<Core.Contracts.General.Error> errors)
        {
            ModelState.Clear();
            foreach (Core.Contracts.General.Error errorItem in errors)
            {
                ModelState.AddModelError(string.Format("{0}.{1}", errorItem.Group, errorItem.Key), errorItem.Message);
            }
            return BadRequest(ModelState);
        }

    }
}
