using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Architect.Utilities.Extensions;
using Asp.Versioning;

namespace Architect.API.Process.WebApi.Controllers
{
    /// <summary>
    /// Acciones para manipular la tabla ProcessCase. ProcessCase
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/ProcessCase")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProcessCaseController : ApiController
    {
        /// <summary>
        /// Crea un registro en la tabla ProcessCase.
        /// </summary>
        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IHttpActionResult> Post([FromBody] Architect.API.Process.Contracts.General.ProcessCase item)
        {
            IHttpActionResult result = BadRequest();

            if (item.IsEmpty())
                return BadRequest("Debe indicar un processcase");

            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            await Task.Run(() =>
            {
                if (item.CurrentToken.IsNotEmpty())
                {
                    Core.Contracts.Security.Token currentTokenInfo = Core.Security.Token.Info(item.CurrentToken);
                    Core.Contracts.Security.UserMember currentUserInfo = Architect.API.Core.Business.Security.UserMember.RetrieveById(currentTokenInfo.CompanyId, currentTokenInfo.UserId);

                    item.UserSend = currentTokenInfo.UserId;
                    item.CustomNumericKey = currentTokenInfo.AgentCode;
                    item.UserId = 0;
                    item.ContactMainName = currentUserInfo.FirstName.CompleteFullName(currentUserInfo.LastName);
                    item.ContactMainEmail = currentUserInfo.EMail;
                }
                Architect.API.Process.Contracts.General.ProcessCaseResult created = Architect.API.Process.Business.General.ProcessCase.Create(tokenInfo.CompanyId, tokenInfo, item);
                if (created.Errors.Count == 0)
                    result = Created(string.Format("{0}/{1}", Request.RequestUri.AbsoluteUri.Substring(0, Request.RequestUri.AbsoluteUri.LastIndexOf("/")), created.ProcessCase.Id), new { Id = created.ProcessCase.Id, UpdateDate = created.ProcessCase.UpdateDate });
                else
                    result = ErrorHandler(created.Errors);
            }).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessCase.
        /// </summary>
        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<IHttpActionResult> Get([FromUri] string filter = "", int beginIndex = 1, int endIndex = int.MaxValue)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            List<Architect.API.Process.Contracts.General.ProcessCase> result = null;

            await Task.Run(() =>
            {
                result = Architect.API.Process.Business.General.ProcessCase.Retrieve(tokenInfo.CompanyId, filter, beginIndex, endIndex, tokenInfo.AgentCode);
            }).ConfigureAwait(false);

            return result.IsEmpty() ? (IHttpActionResult)NotFound() : Ok(result);
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessCase.
        /// </summary>
        [HttpGet]
        [Route("Count")]
        [Authorize]
        public async Task<IHttpActionResult> Count([FromUri] string filter = "")
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            int result = 0;

            await Task.Run(() =>
            {
                result = Architect.API.Process.Business.General.ProcessCase.Count(tokenInfo.CompanyId, filter);
            }).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Recupera un registro en la tabla ProcessCase por su identificador único.
        /// </summary>
        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            if (id.IsEmpty())
                return BadRequest("Debe indicar el identificador del processcase");

            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            IHttpActionResult result = null;

            await Task.Run(() =>
            {
                Architect.API.Process.Contracts.General.ProcessCase data = Architect.API.Process.Business.General.ProcessCase.RetrieveById(tokenInfo.CompanyId, id);
                result = data.IsEmpty() ? (IHttpActionResult)NotFound() : Ok(data);
            }).ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessCase por su identificador único.
        /// </summary>
        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IHttpActionResult> Put([FromUri] int id, [FromBody] Architect.API.Process.Contracts.General.ProcessCase item)
        {
            if (id.IsEmpty() || item.IsEmpty())
                return BadRequest("Debe indicar el identificador y una instancia de processcase");

            IHttpActionResult result = NotFound();
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            await Task.Run(() =>
            {
                item.Id = id;
                Architect.API.Process.Contracts.General.ProcessCaseResult updated = Architect.API.Process.Business.General.ProcessCase.Update(tokenInfo.CompanyId, tokenInfo.UserId, id, item);
                if (updated.Errors.Count == 0)
                    result = Ok(new { Id = updated.ProcessCase.Id, UpdateDate = updated.ProcessCase.UpdateDate });
                else
                    result = ErrorHandler(updated.Errors);
            }).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Asigna o reasigna un usuario a la etapa activa de un caso.
        /// Actualiza PROCESSCASE.USERASSIGNED, PROCESSINSTANCE.USERASSIGNED
        /// y registra el historial en la tabla Reassignment.
        /// </summary>
        /// <param name="id">ID del caso.</param>
        /// <param name="item">Objeto con el campo UserAssigned (ID del usuario).</param>
        [HttpPut]
        [Route("Assign/{id:int}")]
        [Authorize]
        public async Task<IHttpActionResult> Assign([FromUri] int id, [FromBody] Architect.API.Process.Contracts.General.ProcessCase item)
        {
            if (id.IsEmpty() || item.IsEmpty())
                return BadRequest("Debe indicar el identificador del caso y el usuario a asignar");

            IHttpActionResult result = NotFound();
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            await Task.Run(() =>
            {
                Architect.API.Process.Contracts.General.ProcessCaseResult assigned =
                    Architect.API.Process.Business.General.ProcessCase.Assign(
                        tokenInfo.CompanyId, tokenInfo, id, item.UserAssigned);

                if (assigned.Errors.Count == 0)
                    result = Ok(new
                    {
                        Id = assigned.ProcessCase.Id,
                        UserAssigned = assigned.ProcessCase.UserAssigned,
                        UpdateDate = assigned.ProcessCase.UpdateDate
                    });
                else
                    result = ErrorHandler(assigned.Errors);
            }).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Elimina un registro en la tabla ProcessCase por su identificador único.
        /// </summary>
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            if (id.IsEmpty())
                return BadRequest("Debe indicar el identificador del processcase");

            IHttpActionResult result = NotFound();
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            await Task.Run(() =>
            {
                Architect.API.Process.Contracts.General.ProcessCaseResult deleted = Architect.API.Process.Business.General.ProcessCase.DeleteFull(tokenInfo.CompanyId, tokenInfo.UserId, id);
                if (deleted.Errors.Count == 0)
                    result = Ok(deleted.ProcessCase);
                else
                    result = ErrorHandler(deleted.Errors);
            }).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Retorna los usuarios asignables al caso, filtrados por los roles del step activo
        /// que coincidan con los roles del usuario logueado. Ordenados por carga ascendente.
        /// </summary>
        [HttpGet]
        [Route("{id:int}/Users")]
        [Authorize]
        public async Task<IHttpActionResult> GetAssignableUsers([FromUri] int id)
        {
            if (id.IsEmpty())
                return BadRequest("Debe indicar el identificador del caso");

            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            IHttpActionResult result = NotFound();

            await Task.Run(() =>
            {
                var users = Architect.API.Process.DataAccess.General.ProcessInstance
                    .RetrieveAssignableUsers(tokenInfo.CompanyId, id, tokenInfo.UserId);

                result = users == null || users.Count == 0
                    ? (IHttpActionResult)NotFound()
                    : Ok(users.Select(u => new
                    {
                        UserId = u.UserId,
                        FullName = u.FirstName + " " + u.LastName,
                        CaseCount = u.FailedPasswordCount
                    }));
            }).ConfigureAwait(false);

            return result;
        }


        /// <summary>
        /// Retorna el historial de asignaciones/reasignaciones de un caso,
        /// ordenado por fecha descendente. Incluye nombre del usuario y estado.
        /// </summary>
        [HttpGet]
        [Route("{id:int}/Reassignments")]
        [Authorize]
        public async Task<IHttpActionResult> GetReassignments([FromUri] int id)
        {
            if (id.IsEmpty())
                return BadRequest("Debe indicar el identificador del caso");

            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            IHttpActionResult result = NotFound();

            await Task.Run(() =>
            {
                var items = Architect.API.Process.DataAccess.General.Reassignment
                    .RetrieveByCaseId(tokenInfo.CompanyId, id);

                result = items == null || items.Count == 0
                    ? (IHttpActionResult)NotFound()
                    : Ok(items.Select(r => new
                    {
                        UserName         = r.StateDesc,   // nombre guardado en StateDesc
                        UserAssignedDate = r.UserAssignedDate,
                        State            = (int)r.State,
                        StateDesc        = r.State == Contracts.General.ReassignmentState.Reasignacion
                                            ? "Reasignacion"
                                            : r.State == Contracts.General.ReassignmentState.Caso
                                                ? "Primera asignacion"
                                                : "Automatico"
                    }));
            }).ConfigureAwait(false);

            return result;
        }
        private IHttpActionResult ErrorHandler(List<Core.Contracts.General.Error> errors)
        {
            ModelState.Clear();
            foreach (Core.Contracts.General.Error errorItem in errors)
                ModelState.AddModelError(string.Format("{0}.{1}", errorItem.Group, errorItem.Key), errorItem.Message);
            return BadRequest(ModelState);
        }
    }
}