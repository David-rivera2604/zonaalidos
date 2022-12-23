using Architect.API.Core.Contracts.Security;
using Architect.Utilities.Extensions;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Architect.API.Core.Security
{
    /// <summary>
    /// Permite establecer la identidad del usuario que consume el api, por medio del token.
    /// </summary>
    public sealed class AuthorizeExtendAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Se llama cuando un proceso solicita autorización.
        /// </summary>
        /// <param name="actionContext">Contexto.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            if(actionContext.ControllerContext.Request.RequestUri.AbsolutePath.EndsWith("v1/Security/IsLive"))
            {
                base.OnAuthorization(actionContext);
            }
            else if (actionContext.Request.Headers.Authorization == null && HttpContext.Current.Request.Headers["AccessKey"] == null)
            {
                base.OnAuthorization(actionContext);
            }
            else
            {
                Core.Contracts.Security.Token tokenInfo = null;
                string authenticationToken = null;

                bool skip = false;

                if (actionContext.Request.Headers.Authorization != null)
                {
                    try
                    {
                        authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                        if (authenticationToken == null) {
                            authenticationToken = actionContext.Request.Headers.Authorization.Scheme;
                        }

                        tokenInfo = Token.Info(authenticationToken);
                    }
                    catch (Microsoft.IdentityModel.Tokens.SecurityTokenExpiredException )
                    {
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "El token ha expirado" };
                    }
                }
                else
                {
                    authenticationToken = HttpContext.Current.Request.Headers["AccessKey"];
                    tokenInfo = Token.AccessKeyInfo(authenticationToken);
                    if (tokenInfo.UserId == 0)
                    {                        
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        tokenInfo = null;
                    }
                    else
                    {
                        var ipConsume = Architect.Utilities.Helpers.Connection.UserHostAddress();
                        if (ipConsume.Equals("127.0.0.1"))
                            ipConsume = "*.*.*.*";
                        //if(Business.General.WhiteList.Find(ipConsume))
                        //    skip = true;
                    }
                }

                if (tokenInfo != null)
                {
                    Contracts.Security.Activity session = Session.Get(authenticationToken); 
                    if (!skip && !actionContext.Request.RequestUri.LocalPath.EndsWith("/IsLive") && tokenInfo.Expires < DateTime.Now)
                    {
                       
                        if (session.IsNotEmpty())
                        {
                            DateTime expDateTime = session.LastDateTime.AddMinutes(Convert.ToDouble(ConfigurationManager.AppSettings["Session.Timeout"]));
                            //En caso que la session halla expirado, es decir si el time del últimos respuesta mas la duración de session es
                            //if (DateTime.Now < expDateTime)
                                
                        }
                    } 
                    if (!ValidationRole(tokenInfo, actionContext))
                    {
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "El usuario no posee roles validos para consumir la operación" };
                    }
                    else
                    {
                        var identity = new GenericIdentity(tokenInfo.UserId.ToString());

                        identity.AddClaim(new Claim("CompanyId", tokenInfo.CompanyId.ToString()));
                        identity.AddClaim(new Claim("BranchOffice", tokenInfo.BranchOffice.ToString()));
                        identity.AddClaim(new Claim("Roles", tokenInfo.Roles.ToString()));
                        identity.AddClaim(new Claim("ManagerId", tokenInfo.ManagerId.ToString()));
                        identity.AddClaim(new Claim("SecurityLevel", tokenInfo.SecurityLevel.ToString()));
                        identity.AddClaim(new Claim("UserId", tokenInfo.UserId.ToString()));
                        identity.AddClaim(new Claim("AgentCode", tokenInfo.AgentCode.ToString()));
                        identity.AddClaim(new Claim("SubAgentCode", tokenInfo.SubAgentCode.ToString()));

                        IPrincipal principal = new GenericPrincipal(identity, tokenInfo.Roles.Split(','));
                        Thread.CurrentPrincipal = principal;

                        if (HttpContext.Current != null)
                        {
                            HttpContext.Current.User = principal;
                        }

                        if (!actionContext.Request.RequestUri.LocalPath.EndsWith("/IsLive") && actionContext.Request.Headers.Referrer!=null)
                            Session.Refresh(authenticationToken, actionContext.Request.Headers.Referrer.AbsoluteUri);
                    }
                }
            }
        }

        private bool ValidationRole(Contracts.Security.Token tokenInfo, HttpActionContext actionContext)
        {
            bool result = false;
            if (actionContext.ActionDescriptor.GetFilters().Count != 0)
            {
                System.Web.Http.AuthorizeAttribute authorizeAttribute = (System.Web.Http.AuthorizeAttribute)actionContext.ActionDescriptor.GetFilters().Where(c => c is System.Web.Http.AuthorizeAttribute).FirstOrDefault();
                if (authorizeAttribute.IsNotEmpty() && authorizeAttribute.Roles.IsNotEmpty())
                {
                    var rolesAuthorized = authorizeAttribute.Roles.ToLower().Split(',');
                    var rolesAsigned = tokenInfo.Roles.ToLower().Split(',');
                    var exist = rolesAuthorized.Intersect(rolesAsigned).ToList();
                    if(exist.Count >0 )
                    {
                        result = true;
                    }
                }
                else
                {
                    result = true;
                }
            }
            else
                result = true;
            return result;
        }
    }
}