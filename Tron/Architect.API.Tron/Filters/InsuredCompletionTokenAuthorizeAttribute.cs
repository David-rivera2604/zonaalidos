using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Architect.API.Tron.Business.InsuredCompletion;
using Architect.API.Tron.Contracts.InsuredCompletion;

namespace Architect.API.Tron.Filters
{
    /// <summary>
    /// Revalida el token de la cuenta técnica contra una sesión de invitación activa y su alcance de negocio.
    /// Los roles de la cuenta técnica autorizan las APIs; los tokens ordinarios no se alteran.
    /// </summary>
    public sealed class InsuredCompletionTokenAuthorizeAttribute : AuthorizationFilterAttribute
    {
        /// <summary>Nombre de la cookie HttpOnly que contiene el verificador opaco de sesión de invitación.</summary>
        public const string SessionCookieName = "InsuredCompletionSession";

        /// <summary>
        /// Valida el alcance serializado y renueva la sesión activa de la invitación.
        /// No conoce rutas ni formularios: las reglas de autorización se resuelven con los roles de la cuenta técnica.
        /// </summary>
        /// <param name="actionContext">Contexto Web API que ya fue autenticado por el filtro global.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            Core.Contracts.Security.Token token = Core.Security.Token.Info();
            IDictionary<string, string> settings = token.Settings == null
                ? new Dictionary<string, string>(StringComparer.Ordinal)
                : token.Settings.GroupBy(item => item.Key).ToDictionary(group => group.Key, group => group.Last().Value, StringComparer.Ordinal);

            if (!InsuredCompletionTokenScope.TryParse(settings, out InsuredCompletionTokenScope scope))
            {
                return;
            }

            HttpCookie cookie = HttpContext.Current.Request.Cookies[SessionCookieName];
            InvitationSessionAccess access = new InvitationSessionService(new InvitationStore(), () => DateTime.UtcNow)
                .ValidateAndRenew(cookie == null ? null : cookie.Value);
            if (!access.Found || !scope.Authorizes(access.InvitationId, access.CompanyId, access.ProposalId))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotFound);
                return;
            }

            actionContext.Request.Properties[InvitationSessionAuthorizeAttribute.SessionAccessProperty] = access;
        }
    }
}
