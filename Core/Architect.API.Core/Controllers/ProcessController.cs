using Microsoft.Web.Http;
using System.Web.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Architect.Utilities.Extensions;
using System.Web.Http.Description;
using System.Linq;

namespace Architect.API.Core.Controllers
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
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();

            Contracts.General.ProcessSpecFlow result = Business.General.Process.Specification(flowId, tokenInfo.CompanyId, 0);
            if (result.IsEmpty())
                return NotFound();
            else
                return Ok(result);
        }

        [HttpPost]
        [Route("Instance/Automatic")]
        public IHttpActionResult CreateAutomaticInstance([FromBody] Contracts.General.CreateProcessInstance instance)
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();

            Contracts.General.InstanceInformation result = Business.General.Process.CreateAutomaticInstance(instance, tokenInfo);
            return Ok(result);
        }

        [HttpPost]
        [Route("Instance")]
        public IHttpActionResult CreateInstance([FromBody] Contracts.General.CreateProcessInstance instance)
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();

            Contracts.General.ProcessInstance result = Business.General.Process.CreateInstance(instance, tokenInfo.UserId, tokenInfo.CompanyId).First();
            return Ok(new { InstanceId = result.InstanceId, currentActivityId = result.ActivityId, currentActivityDesc = result.TaskDesc });
        }

        [HttpGet]
        [Route("Instance/Entity/Exist/{entityType:int}/{entityId:long}")]
        public IHttpActionResult InstanceByEntityExist([FromUri] int entityType, [FromUri] long entityId)
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();

            bool result = Business.General.Process.InstanceByEntityExist(entityType, entityId, tokenInfo.CompanyId);
            return Ok(result);
        }

        [HttpGet]
        [Route("Instance/{instanceId:int}/{level:int?}")]
        public IHttpActionResult CurrentByInstance([FromUri] int instanceId, [FromUri] int level = 2)
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();

            Contracts.General.InstanceInformation result = Business.General.Process.CurrentByInstance(instanceId, level, tokenInfo);
            return Ok(result);
        }

        [HttpGet]
        [Route("Instance/Entity/{entityType:int}/{entityId:long}/{level:int?}")]
        public IHttpActionResult CurrentStep([FromUri] int entityType, [FromUri] long entityId, [FromUri] int level = 2)
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();

            Contracts.General.InstanceInformation result = Business.General.Process.CurrentByEntity(entityType, entityId, level, tokenInfo);
            return Ok(result);
        }

        [HttpPut]
        [Route("Task/Checked/{instanceId:int}")]
        public IHttpActionResult TaskChecked([FromUri] int instanceId, [FromBody] Contracts.General.TaskChecked checkedInformation)
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();

            Contracts.General.ProcessInstance result = Business.General.Process.TaskCompletedByInstance(instanceId, checkedInformation, tokenInfo.UserId, tokenInfo.CompanyId);
            return Ok(new { InstanceId = result.InstanceId, currentActivityId = result.ActivityId, currentActivityDesc = result.TaskDesc });
        }

        [HttpPut]
        [Route("Task/Checked/Entity/{entityType:int}/{entityId:long}")]
        public IHttpActionResult TaskChecked([FromUri] int entityType, [FromUri] long entityId, [FromBody] Contracts.General.TaskChecked checkedInformation)
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();

            Contracts.General.ProcessInstance result = Business.General.Process.TaskCompletedByEntity(entityType, entityId, checkedInformation, tokenInfo.UserId, tokenInfo.CompanyId);
            return Ok(new { InstanceId = result.InstanceId, currentActivityId = result.ActivityId, currentActivityDesc = result.TaskDesc });
        }

        [HttpPut]
        [Route("Case/Complement/{caseId:int}")]
        public IHttpActionResult CaseComplement([FromUri] int caseId, [FromBody] Contracts.General.CaseComplement caseComplement)
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();

            Business.General.Process.CaseComplement(caseId, caseComplement, tokenInfo);
            return Ok();
        }
        [HttpGet]
        [Route("Case/Complement/{caseId:int}")]
        public IHttpActionResult CaseComplement([FromUri] int caseId)
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();

            return Ok(Business.General.Process.CaseComplement(caseId, tokenInfo));
        }

        [HttpPost]
        [Route("Notify")]
        public IHttpActionResult Notify([FromBody] Newtonsoft.Json.Linq.JObject payload)
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();

            // Acceder a las propiedades del payload

            int noteId = payload.TokenInt32Value("NoteId");
            string note = payload.TokenStringValue("Note");
            bool contactNotify = payload.TokenBoolValue("contactNotify");
            bool responsibleNotify = payload.TokenBoolValue("responsibleNotify");
            int instanceId = payload.TokenInt32Value("InstanceId");
            string type = payload.TokenStringValue("Type");

            Business.General.Process.SendNotification(noteId, note, contactNotify, responsibleNotify, instanceId, type, tokenInfo);

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
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();

            string result = Business.General.ProcessHelpers.FixData(apply);

            return Ok(result);
        }

    }
}