using System;
using System.Web.Http;
using Architect.API.Tron.Business.Backoffice;
using Architect.API.Tron.Contracts.InsuredCompletion;
using Asp.Versioning;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Expone el seguimiento autenticado de solicitudes de póliza para su agente propietario.
    /// </summary>
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/PolicyProposals")]
    public class PolicyProposalController : ApiController
    {
        /// <summary>
        /// Recupera una solicitud del agente y las acciones disponibles según su estado.
        /// </summary>
        /// <param name="id">Identificador técnico NUMBER(9) de la solicitud.</param>
        /// <returns>Vista de seguimiento, o no encontrado para solicitudes ajenas.</returns>
        [HttpGet]
        [Authorize]
        [Route("{id:int}")]
        public IHttpActionResult Retrieve(int id)
        {
            try
            {
                return Ok(PolicyProposalAgentWorkflow.Retrieve(id, Core.Security.Token.Info()));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Reenvía la invitación de una solicitud pendiente y permite actualizar sólo el correo del asegurado.
        /// </summary>
        /// <param name="id">Identificador técnico NUMBER(9) de la solicitud.</param>
        /// <param name="request">Correo actualizado del asegurado.</param>
        /// <returns>Vista de seguimiento actualizada.</returns>
        [HttpPost]
        [Authorize]
        [Route("{id:int}/Invitation/Resend")]
        public IHttpActionResult ResendInvitation(int id, [FromBody] ResendInvitationRequest request)
        {
            try
            {
                return Ok(PolicyProposalAgentWorkflow.ResendInvitation(id, request == null ? null : request.RecipientEmail, Core.Security.Token.Info()));
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (InvalidOperationException exception)
            {
                return CommandFailure(exception);
            }
        }

        /// <summary>
        /// Anula la invitación vigente sin alterar la solicitud ni habilitar su edición.
        /// </summary>
        /// <param name="id">Identificador técnico NUMBER(9) de la solicitud.</param>
        /// <param name="request">Motivo opcional de anulación.</param>
        /// <returns>Vista de seguimiento actualizada.</returns>
        [HttpPost]
        [Authorize]
        [Route("{id:int}/Invitation/Revoke")]
        public IHttpActionResult RevokeInvitation(int id, [FromBody] RevokeInvitationRequest request)
        {
            try
            {
                return Ok(PolicyProposalAgentWorkflow.RevokeInvitation(id, request == null ? null : request.Reason, Core.Security.Token.Info()));
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (InvalidOperationException exception)
            {
                return CommandFailure(exception);
            }
        }

        /// <summary>
        /// Anula la invitación y devuelve la solicitud pendiente al estado editable de borrador.
        /// </summary>
        /// <param name="id">Identificador técnico NUMBER(9) de la solicitud.</param>
        /// <returns>Vista de seguimiento actualizada.</returns>
        [HttpPost]
        [Authorize]
        [Route("{id:int}/ResumeEditing")]
        public IHttpActionResult ResumeEditing(int id)
        {
            try
            {
                return Ok(PolicyProposalAgentWorkflow.ResumeEditing(id, Core.Security.Token.Info()));
            }
            catch (InvalidOperationException exception)
            {
                return CommandFailure(exception);
            }
        }

        /// <summary>
        /// No revela la existencia de solicitudes ajenas, pero informa transiciones inválidas al propietario autenticado.
        /// </summary>
        /// <param name="exception">Error controlado producido por el flujo de negocio.</param>
        /// <returns>404 para solicitudes no disponibles y 400 para comandos no permitidos.</returns>
        private IHttpActionResult CommandFailure(InvalidOperationException exception)
        {
            if (exception.Message == "La solicitud indicada no está disponible.")
            {
                return NotFound();
            }

            return BadRequest(exception.Message);
        }
    }
}
