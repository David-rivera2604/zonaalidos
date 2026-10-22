using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using Architect.API.Core.Business;
using Architect.API.Tron.Business.InsuredCompletion;
using Architect.API.Tron.Contracts.InsuredCompletion;
using Architect.API.Tron.Filters;
using Asp.Versioning;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Expone la emisión de invitaciones autorizada por agente y la ruta pública aislada de canje de capacidad.
    /// El canje público nunca invoca la API de token del agente ni revela información de la propuesta.
    /// </summary>
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/InsuredCompletion")]
    public class InsuredCompletionController : ApiController
    {
        private const string SessionCookieName = "InsuredCompletionSession";
        private const string TechnicalTokenCookieName = "InsuredCompletionAuthToken";

        /// <summary>
        /// Emite una invitación de reemplazo para una propuesta propiedad del agente autenticado.
        /// </summary>
        /// <param name="request">Destinatario e identificador de propuesta seleccionados por el agente.</param>
        /// <returns>Estado de invitación sin secretos, o resultado genérico no encontrado para una propuesta ajena.</returns>
        [HttpPost]
        [Authorize]
        [Route("invitations")]
        public IHttpActionResult CreateInvitation([FromBody] CreateInvitationRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.ProposalId))
            {
                return NotFound();
            }

            Core.Contracts.Security.Token agent = Core.Security.Token.Info();
            Contracts.PolicyProposal proposal = ProposalOwnership.RetrieveOwnedByAgent(
                request.ProposalId,
                agent.CompanyId,
                agent.AgentCode);
            if (proposal == null)
            {
                return NotFound();
            }

            InvitationView invitation = CreateService().CreateOrResend(new CreateInvitationRequest
            {
                CompanyId = agent.CompanyId,
                PolicyProposalId = proposal.Id,
                ProposalId = proposal.ProposalId,
                RecipientEmail = request.RecipientEmail,
                UserId = agent.UserId,
                OwnerId = agent.UserId,
                CompletionPath = request.CompletionPath,
                CompletionFlow = request.CompletionFlow
            });

            return Ok(invitation);
        }

        /// <summary>
        /// Canjea una capacidad opaca de invitación por una sesión restringida y un token temporal de una cuenta técnica.
        /// Todas las capacidades inválidas, vencidas, revocadas o en carrera reciben la misma respuesta no encontrada.
        /// </summary>
        /// <param name="request">Secreto recibido del fragmento de URL del navegador en el cuerpo JSON.</param>
        /// <returns>Token técnico de corta duración para la pestaña actual, o respuesta genérica no encontrada.</returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("exchange")]
        public IHttpActionResult Exchange([FromBody] ExchangeInvitationRequest request)
        {
            InvitationSession session = CreateService().Exchange(request == null ? null : request.Secret);
            if (!session.Found)
            {
                return NotFound();
            }

            InvitationSessionAccess access = CreateSessionService().ValidateAndRenew(session.SessionSecret);
            if (!access.Found)
            {
                return NotFound();
            }

            Core.Contracts.Security.Token technicalToken = CreateTechnicalAuthentication(access);
            string serializedToken = Core.Security.Accounts.GeneratorToken(technicalToken);
            Core.Security.Session.Create(new Core.Contracts.Security.Activity
            {
                Token = serializedToken,
                CompanyId = technicalToken.CompanyId,
                UserId = technicalToken.UserId,
                UserName = technicalToken.UserName,
                IP = HttpContext.Current.Request.UserHostAddress,
                UserAgent = HttpContext.Current.Request.UserAgent
            });

            HttpCookie cookie = new HttpCookie(SessionCookieName, session.SessionSecret)
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Path = "/",
                Expires = session.ExpiresAtUtc.Value
            };
            HttpContext.Current.Response.Cookies.Add(cookie);

            HttpContext.Current.Response.Cookies.Add(new HttpCookie(TechnicalTokenCookieName, serializedToken)
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Path = "/",
                Expires = technicalToken.Expires
            });

            return Ok(new
            {
                Token = serializedToken,
                Roles = technicalToken.Roles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(item => item.Trim()).ToArray(),
                Tenant = "Aliados",
                CompletionPath = access.CompletionPath
            });
        }

        /// <summary>
        /// Confirma una sesión restringida sin devolver información de propuesta, personal ni de ciclo de vida.
        /// </summary>
        /// <returns>Sin contenido para una sesión activa, o resultado genérico no encontrado del filtro de sesión.</returns>
        [HttpGet]
        [AllowAnonymous]
        [InvitationSessionAuthorize]
        [Route("session")]
        public IHttpActionResult Session()
        {
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Devuelve la instantánea de la única solicitud que la invitación activa permite completar.
        /// El identificador no se recibe desde URL ni del cuerpo para impedir que un asegurado explore solicitudes ajenas.
        /// </summary>
        /// <returns>Datos del formulario sin información de estado, firma, agente ni de otras solicitudes.</returns>
        [HttpGet]
        [Authorize]
        [InvitationSessionAuthorize]
        [Route("proposal")]
        public IHttpActionResult Proposal()
        {
            if (!Request.Properties.TryGetValue(InvitationSessionAuthorizeAttribute.SessionAccessProperty, out object accessValue) ||
                !(accessValue is InvitationSessionAccess access) ||
                !access.Found ||
                access.PolicyProposalId <= 0)
            {
                return NotFound();
            }

            try
            {
                return Ok(Business.Backoffice.PolicyProposalWorkflow.RetrieveInsuredForm(access));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Crea la composición del servicio de producción sin exponer valores de configuración en respuestas o registros.
        /// </summary>
        /// <returns>Servicio de invitación usado por este controlador.</returns>
        private static InvitationService CreateService()
        {
            return new InvitationService(
                new InvitationStore(),
                new InvitationMailSender(),
                () => DateTime.UtcNow,
                InvitationSecret.Generate,
                ConfigurationManager.AppSettings["Aliados.URL.Base"]);
        }

        /// <summary>
        /// Construye el contexto de una cuenta técnica, con sus propios roles mínimos, y agrega el alcance inmutable de la invitación.
        /// Nunca toma el usuario, los roles ni el código de agente del remitente de la invitación.
        /// </summary>
        /// <param name="access">Invitación que acaba de ser validada por la sesión HttpOnly.</param>
        /// <returns>Token temporal que requiere validar nuevamente la sesión en cada llamada API.</returns>
        private static Core.Contracts.Security.Token CreateTechnicalAuthentication(InvitationSessionAccess access)
        {
            string settingKey = string.Format("PolicyProposal.InsuredCompletion.Tenant.{0}.UserId", access.CompanyId);
            if (!int.TryParse(settingKey.StringValue(access.CompanyId), out int technicalUserId) || technicalUserId <= 0)
            {
                throw new ConfigurationErrorsException("Debe configurar la cuenta técnica de completado para la compañía.");
            }

            Core.Contracts.Security.UserMember technicalUser = Core.DataAccess.Security.UserMember.Retrieve(technicalUserId, access.CompanyId);
            if (technicalUser == null)
            {
                throw new ConfigurationErrorsException("La cuenta técnica de completado configurada no existe en la compañía.");
            }

            string[] roles = Core.DataAccess.Security.UserRoleMember
                .RetrieveLookByUserId(technicalUser.UserId, technicalUser.CompanyId)
                .Select(item => item.Description)
                .ToArray();
            Core.Contracts.Security.Token token = Core.Business.Security.Accounts.TokenItem(
                technicalUser,
                roles,
                30,
                string.Format("{0} {1}", technicalUser.FirstName, technicalUser.LastName).Trim());
            token.Expires = DateTime.Now.AddMinutes(30);
            token.Settings = token.Settings ?? new List<Core.Contracts.Security.SettingItem>();

            foreach (KeyValuePair<string, string> setting in InsuredCompletionTokenScope
                .Create(access.InvitationId, access.CompanyId, access.ProposalId)
                .ToSettings())
            {
                token.Settings.RemoveAll(item => string.Equals(item.Key, setting.Key, StringComparison.Ordinal));
                token.Settings.Add(new Core.Contracts.Security.SettingItem { Key = setting.Key, Value = setting.Value });
            }

            return token;
        }

        /// <summary>
        /// Crea el validador de la sesión persistida sin exponer el secreto de sesión fuera de la cookie HttpOnly.
        /// </summary>
        private static InvitationSessionService CreateSessionService()
        {
            return new InvitationSessionService(new InvitationStore(), () => DateTime.UtcNow);
        }
    }
}
