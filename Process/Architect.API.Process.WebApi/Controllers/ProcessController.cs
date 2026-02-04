using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Architect.Utilities.Extensions;
using Asp.Versioning;

namespace Architect.API.Process.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Process")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProcessController : ApiController
    {
        /// <summary>
        /// Especificación de proceso.
        /// </summary>
        /// <param name="flowId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Specification")]
        public IHttpActionResult Specification([FromUri] int flowId)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            Process.Contracts.General.ProcessSpecFlow result = Process.Business.General.Process.Specification(flowId, tokenInfo.CompanyId, 0);
            if (result.IsEmpty())
                return NotFound();
            else
                return Ok(result);
        }

        [HttpPost]
        [Route("Instance/Automatic")]
        public IHttpActionResult CreateAutomaticInstance([FromBody] Process.Contracts.General.CreateProcessInstance instance)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            Core.Contracts.General.InstanceInformation result = Process.Business.General.Process.CreateAutomaticInstance(instance, tokenInfo);
            return Ok(result);
        }

        [HttpPost]
        [Route("Instance")]
        public IHttpActionResult CreateInstance([FromBody] Process.Contracts.General.CreateProcessInstance instance)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            Process.Contracts.General.ProcessInstance result = Process.Business.General.Process.CreateInstance(instance, tokenInfo.UserId, tokenInfo.CompanyId).First();
            return Ok(new { InstanceId = result.InstanceId, currentActivityId = result.ActivityId, currentActivityDesc = result.TaskDesc });
        }

        [HttpGet]
        [Route("Instance/Entity/Exist/{entityType:int}/{entityId:long}")]
        public IHttpActionResult InstanceByEntityExist([FromUri] int entityType, [FromUri] long entityId)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            bool result = Process.Business.General.Process.InstanceByEntityExist(entityType, entityId, tokenInfo.CompanyId);
            return Ok(result);
        }

        [HttpGet]
        [Route("Instance/{instanceId:int}/{level:int?}")]
        public IHttpActionResult CurrentByInstance([FromUri] int instanceId, [FromUri] int level = 2)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            Core.Contracts.General.InstanceInformation result = Process.Business.General.Process.CurrentByInstance(instanceId, level, tokenInfo);
            return Ok(result);
        }

        [HttpGet]
        [Route("Instance/Entity/{entityType:int}/{entityId:long}/{level:int?}")]
        public IHttpActionResult CurrentStep([FromUri] int entityType, [FromUri] long entityId, [FromUri] int level = 2)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            Core.Contracts.General.InstanceInformation result = Process.Business.General.Process.CurrentByEntity(entityType, entityId, level, tokenInfo);
            return Ok(result);
        }

        [HttpPut]
        [Route("Task/Checked/{instanceId:int}")]
        public IHttpActionResult TaskChecked([FromUri] int instanceId, [FromBody] Core.Contracts.General.TaskChecked checkedInformation)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            Process.Contracts.General.ProcessInstance result = Process.Business.General.Process.TaskCompletedByInstance(instanceId, checkedInformation, tokenInfo.UserId, tokenInfo.CompanyId);
            return Ok(new { InstanceId = result.InstanceId, currentActivityId = result.ActivityId, currentActivityDesc = result.TaskDesc });
        }

        [HttpPut]
        [Route("Task/Checked/Entity/{entityType:int}/{entityId:long}")]
        public IHttpActionResult TaskChecked([FromUri] int entityType, [FromUri] long entityId, [FromBody] Core.Contracts.General.TaskChecked checkedInformation)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            Process.Contracts.General.ProcessInstance result = Process.Business.General.Process.TaskCompletedByEntity(entityType, entityId, checkedInformation, tokenInfo.UserId, tokenInfo.CompanyId);
            return Ok(new { InstanceId = result.InstanceId, currentActivityId = result.ActivityId, currentActivityDesc = result.TaskDesc });
        }

        [HttpPut]
        [Route("Case/Complement/{caseId:int}")]
        public IHttpActionResult CaseComplement([FromUri] int caseId, [FromBody] Core.Contracts.General.CaseComplement caseComplement)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            Process.Business.General.Process.CaseComplement(caseId, caseComplement, tokenInfo);
            return Ok();
        }

        [HttpGet]
        [Route("Case/Complement/{caseId:int}")]
        public IHttpActionResult CaseComplement([FromUri] int caseId)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            return Ok(Process.Business.General.Process.CaseComplement(caseId, tokenInfo));
        }

        [HttpPost]
        [Route("Notify")]
        public IHttpActionResult Notify([FromBody] Newtonsoft.Json.Linq.JObject payload)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            // Acceder a las propiedades del payload

            int noteId = payload.TokenInt32Value("NoteId");
            string note = payload.TokenStringValue("Note");
            bool contactNotify = payload.TokenBoolValue("contactNotify");
            bool responsibleNotify = payload.TokenBoolValue("responsibleNotify");
            int instanceId = payload.TokenInt32Value("InstanceId");
            string type = payload.TokenStringValue("Type");

            Process.Business.General.Process.SendNotification(noteId, note, contactNotify, responsibleNotify, instanceId, type, tokenInfo);

            return Ok(new { success = true, message = "Notificación enviada correctamente" });
        }

        /// <summary>
        /// fix data
        /// </summary>
        [HttpGet]
        [Route("fix")]
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult fix([FromUri] bool apply = false)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            string result = Process.Business.General.ProcessHelpers.FixData(apply);

            return Ok(result);
        }
    }
}