using System;
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
    /// Authorizes only a valid restricted invitation session, independently from the global agent token filter.
    /// </summary>
    public sealed class InvitationSessionAuthorizeAttribute : AuthorizationFilterAttribute
    {
        /// <summary>Gets the request-property key used to pass internal invitation scope to protected endpoints.</summary>
        public const string SessionAccessProperty = "InsuredCompletion.SessionAccess";

        /// <summary>
        /// Rejects absent, altered, revoked, expired, or raced session cookies with the public generic not-found result.
        /// </summary>
        /// <param name="actionContext">Web API context for the protected endpoint.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["InsuredCompletionSession"];
            InvitationSessionAccess access = new InvitationSessionService(new InvitationStore(), () => DateTime.UtcNow)
                .ValidateAndRenew(cookie == null ? null : cookie.Value);

            if (!access.Found)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotFound);
                return;
            }

            actionContext.Request.Properties[SessionAccessProperty] = access;
        }
    }
}
