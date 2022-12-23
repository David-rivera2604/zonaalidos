using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Cors;

namespace Aliados.Monge.App_Start
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {
                "*"
            });

            Dictionary<string, string> user =  Aliados.Monge.Application.Seguridad.SeguridadHandler.AutorizacionInternal(context.UserName, context.Password, "192.168.1.1", "none");

            //db Logic to validate user  
            if (user.Count>0)
            {
                identity.AddClaim(new Claim("sub", user["UserName"]));
                identity.AddClaim(new Claim("UserId", user["UserId"]));
                identity.AddClaim(new Claim("Body", user["Body"]));
                identity.AddClaim(new Claim("jti", Guid.NewGuid().ToString()));


                var props = new AuthenticationProperties(new Dictionary<string, string> {
                    {
                        "userdisplayname",
                        context.UserName
                    },
                    {
                        "role",
                        "admin"
                    }
                });
                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
            }
            else
            {
                context.SetError("invalid_grant", "Provide username and password is incorrect");
                context.Rejected();
            }
        }
        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));
            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);
            return Task.FromResult<object>(null);
        }

    }
}