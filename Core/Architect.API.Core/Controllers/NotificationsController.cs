using Architect.Utilities.Extensions;
using Asp.Versioning;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.API.Process.WebApi.Controllers
{
    /// <summary>
    /// Centro de notificaciones del usuario autenticado.
    /// CompanyId y UserId siempre se leen del JWT — nunca del body.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Notifications")]
    public class NotificationsController : ApiController
    {
        /// <summary>Lista paginada de notificaciones del usuario autenticado.</summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(Architect.API.Core.Contracts.Notifications.NotificationPagedResult))]
        public async Task<IHttpActionResult> GetAll([FromUri] bool onlyUnread = false, [FromUri] int page = 1, [FromUri] int pageSize = 20)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Architect.API.Core.Contracts.Notifications.NotificationPagedResult result = null;
            await Task.Run(() => result = Architect.API.Core.Business.Notifications.NotificationBusiness.GetPaged(tokenInfo.CompanyId, tokenInfo.UserId, onlyUnread, page, pageSize)).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>Conteo de notificaciones no leidas del usuario autenticado.</summary>
        [HttpGet]
        [Route("unread/count")]
        [ResponseType(typeof(object))]
        public async Task<IHttpActionResult> GetUnreadCount()
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            int count = 0;
            await Task.Run(() => count = Architect.API.Core.Business.Notifications.NotificationBusiness.GetUnreadCount(tokenInfo.CompanyId, tokenInfo.UserId)).ConfigureAwait(false);
            return Ok(new { UnreadCount = count });
        }

        /// <summary>
        /// Envia un mensaje directo a un usuario del mismo tenant.
        /// Body: { UserId (destinatario), Title, Message, Type, Category, EntityType, EntityId, Metadata }
        /// </summary>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Architect.API.Core.Contracts.Notifications.NotificationResult))]
        public async Task<IHttpActionResult> Send([FromBody] Architect.API.Core.Contracts.Notifications.Notification request)
        {
            if (request.IsEmpty()) return BadRequest("Debe indicar los datos.");
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            string type = string.IsNullOrWhiteSpace(request.Type) ? "USER_MESSAGE" : request.Type;
            Architect.API.Core.Contracts.Notifications.NotificationResult result = null;
            // UserId del body = destinatario. CompanyId siempre del JWT.
            await Task.Run(() => result = Architect.API.Core.Business.Notifications.NotificationBusiness.Send(tokenInfo.CompanyId, request.UserId, type, request.Title, request.Message, request.EntityType, request.EntityId, request.Category, request.Metadata)).ConfigureAwait(false);
            if (!result.Successful) return BadRequest(string.Join(", ", result.Errors.ConvertAll(e => e.Message)));
            return Ok(result);
        }

        /// <summary>Marca una notificacion como leida. Solo puede hacerlo el destinatario.</summary>
        [HttpPatch]
        [Route("read/{id:int}")]
        [ResponseType(typeof(object))]
        public async Task<IHttpActionResult> MarkAsRead(int id)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            bool success = false;
            await Task.Run(() => success = Architect.API.Core.Business.Notifications.NotificationBusiness.MarkAsRead(id, tokenInfo.CompanyId, tokenInfo.UserId)).ConfigureAwait(false);
            if (!success) return NotFound();
            return Ok(new { Successful = true });
        }

        /// <summary>Marca todas las notificaciones del usuario como leidas.</summary>
        [HttpPatch]
        [Route("read-all")]
        [ResponseType(typeof(object))]
        public async Task<IHttpActionResult> MarkAllAsRead()
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            await Task.Run(() => Architect.API.Core.Business.Notifications.NotificationBusiness.MarkAllAsRead(tokenInfo.CompanyId, tokenInfo.UserId)).ConfigureAwait(false);
            return Ok(new { Successful = true });
        }

        /// <summary>Elimina una notificacion propia.</summary>
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(object))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            bool success = false;
            await Task.Run(() => success = Architect.API.Core.Business.Notifications.NotificationBusiness.Delete(id, tokenInfo.CompanyId, tokenInfo.UserId)).ConfigureAwait(false);
            if (!success) return NotFound();
            return Ok(new { Successful = true });
        }
    }
}