using Architect.Utilities.Extensions;
using Microsoft.Web.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.API.Core.Controllers
{
    /// <summary>
    /// Acciones para manipular la tabla Lookup. Lista de valores disponibles.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Lookup")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class LookupController : ApiController
    {
        /// <summary>
        /// Crea un registro en la tabla Lookup.
        /// </summary>
        /// <param name="item">Instancia del objecto Lookup.</param>
        /// <returns>Información del registro creado en la tabla Lookup.</returns>
        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IHttpActionResult> Post([FromBody] Architect.API.Core.Contracts.General.Lookup item)
        {
            IHttpActionResult result = BadRequest();
            if (item.IsEmpty())
            {
                return BadRequest("Debe indicar un lookup");
            }
            Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            await Task.Run(() =>
            {
                Architect.API.Core.Contracts.General.LookupResult created = Architect.API.Core.Business.General.Lookup.Create(tokenInfo.CompanyId, tokenInfo.UserId, item);
                if (created.Errors.Count == 0)
                {
                    result = Created(string.Format("{0}/{1}", Request.RequestUri.AbsoluteUri.Substring(0, Request.RequestUri.AbsoluteUri.LastIndexOf("/")), created.Lookup.LookupId), new { Id = created.Lookup.LookupId, UpdateDate = created.Lookup.UpdateDate });
                }
                else
                {
                    result = ErrorHandler(created.Errors);
                }
            }).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Lookup.
        /// </summary>
        /// <param name="filter">Filtro a ser aplicado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de objetos Lookup.</returns>
        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<IHttpActionResult> Get([FromUri] string filter = "", int beginIndex = 1, int endIndex = int.MaxValue)
        {
            Contracts.Security.Token tokenInfo = Business.Security.Token.Info();

            List<Architect.API.Core.Contracts.General.Lookup> result = null;

            await Task.Run(() =>
            {
                result = Architect.API.Core.Business.General.Lookup.Retrieve(tokenInfo.CompanyId, filter, beginIndex, endIndex);
            }).ConfigureAwait(false);

            if (result.IsEmpty())
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Lookup que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Filtro a ser aplicado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        [HttpGet]
        [Route("Count")]
        [Authorize]
        public async Task<IHttpActionResult> Count([FromUri] string filter = "")
        {
            Contracts.Security.Token tokenInfo = Business.Security.Token.Info();
            int result = 0;

            await Task.Run(() =>
            {
                result = Architect.API.Core.Business.General.Lookup.Count(tokenInfo.CompanyId, filter);
            }).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Recupera un registro en la tabla Lookup por medio de su identificador único.
        /// </summary>
        /// <param name="id">Identificador único.</param>
        /// <returns>Instancia del objecto Lookup.</returns>
        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            Contracts.Security.Token tokenInfo = Business.Security.Token.Info();
            IHttpActionResult result = null;
            Architect.API.Core.Contracts.General.Lookup data = null;

            if (id.IsEmpty())
            {
                result = BadRequest("Debe indicar el identificador del lookup");
            }
            else
            {
                await Task.Run(() =>
                {
                    data = Architect.API.Core.Business.General.Lookup.RetrieveById(tokenInfo.CompanyId, id);
                    if (data.IsEmpty())
                    {
                        result = NotFound();
                    }
                    else
                    {
                        result = Ok(data);
                    }
                }).ConfigureAwait(false);
            }
            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla Lookup por medio de su identificador único.
        /// </summary>
        /// <param name="id">Identificador único.</param>
        /// <param name="item">Instancia del objecto Lookup.</param>
        /// <returns>Información del registro actualizado en la tabla Lookup.</returns>
        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IHttpActionResult> Put([FromUri] int id, [FromBody] Architect.API.Core.Contracts.General.Lookup item)
        {
            IHttpActionResult result = NotFound();

            if (id.IsEmpty() || item.IsEmpty())
            {
                return BadRequest("Debe indicar el identificador y una instancia de lookup");
            }

            Contracts.Security.Token tokenInfo = Business.Security.Token.Info();
            await Task.Run(() =>
            {
                item.LookupId = id;
                Architect.API.Core.Contracts.General.LookupResult updated = Architect.API.Core.Business.General.Lookup.Update(tokenInfo.CompanyId, tokenInfo.UserId, id, item);
                if (updated.Errors.Count == 0)
                {
                    result = Ok(new
                    {
                        Id = updated.Lookup.LookupId,
                        UpdateDate = updated.Lookup.UpdateDate
                    });
                }
                else
                {
                    result = ErrorHandler(updated.Errors);
                }
            }).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Elimina un registro en la tabla Reclamos por medio de su identificador único.
        /// </summary>
        /// <param name="id">Identificador único.</param>
        /// <returns>Información del registro eliminado en la tabla Visualizations.</returns>
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            IHttpActionResult result = NotFound();

            if (id.IsEmpty())
            {
                return BadRequest("Debe indicar el identificador del lookup");
            }

            Contracts.Security.Token tokenInfo = Business.Security.Token.Info();
            await Task.Run(() =>
            {
                Architect.API.Core.Contracts.General.LookupResult deleted = Architect.API.Core.Business.General.Lookup.Delete(tokenInfo.CompanyId, tokenInfo.UserId, id);
                if (deleted.Errors.Count == 0)
                {
                    result = Ok(deleted.Lookup);
                }
                else
                {
                    result = ErrorHandler(deleted.Errors);
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

    }
}
