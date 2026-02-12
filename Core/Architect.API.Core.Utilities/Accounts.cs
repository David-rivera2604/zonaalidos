using Architect.API.Core.Contracts.Security;
using Architect.API.Core.DataAccess.Security;
using Architect.Utilities;
using Architect.Utilities.Extensions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Results;

namespace Architect.API.Core.Security
{
    /// <summary>
    /// Provides core account and authentication functionality including context assignment and JWT token generation.
    /// </summary>
    public static class Accounts
    {
        /// <summary>
        /// Creates an authentication cookie and assigns the user context to the current thread and HTTP context.
        /// Extension method for establishing server-side authentication state.
        /// </summary>
        /// <param name="request">The HTTP request containing connection information.</param>
        /// <param name="responseItem">The authentication response with user data and token.</param>
        /// <param name="token">The security token containing user identity and permissions.</param>
        /// <returns>
        /// An HttpCookie configured with the authentication token, expiration, and security settings.
        /// The cookie is configured as:
        /// - HttpOnly: true (prevents JavaScript access)
        /// - Secure: matches request security (HTTPS only if request is secure)
        /// - SameSite: Lax (allows navigation from external sites)
        /// - Path: "/" (available for entire application)
        /// </returns>
        /// <remarks>
        /// This method performs two critical operations:
        /// 1. Creates an authentication cookie with the JWT token
        /// 2. Calls token.Assinged() to set the current user context in Thread.CurrentPrincipal and HttpContext.Current.User
        /// 
        /// This enables stateful authentication for MVC controllers, allowing subsequent requests
        /// to access the authenticated user context without requiring the token in headers.
        /// </remarks>
        public static HttpCookie AssingedContext(HttpRequestBase request, AuthenticationResponse responseItem, Architect.API.Core.Contracts.Security.Token token)
        {
            var authCookie = new HttpCookie("AuthToken", responseItem.Token)
            {
                Expires = DateTime.Now.AddMinutes(responseItem.ExpiresIn),
                HttpOnly = true,
                Secure = request.IsSecureConnection,
                SameSite = SameSiteMode.Lax,
                Path = "/"
            };
            token.Assinged();
            return authCookie;
        }

        public static string GeneratorToken(Contracts.Security.Token userInfo)
        {
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Architect.Utilities.Helpers.Settings.StringValue("Jwt:SecretKey")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            List<Claim> claims = new List<Claim> 
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim("UserId", userInfo.UserId.ToString()),
                new Claim("Body", Architect.Utilities.Helpers.CryptSupport.EncryptString(userInfo.Serialize<Contracts.Security.Token>().CompressString())),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            
            foreach (var item in userInfo.Settings)
            {
                claims.Add(new Claim(item.Key, item.Value));
            }
            
            var token = new JwtSecurityToken(
                issuer: Architect.Utilities.Helpers.Settings.StringValue("Jwt:Issuer"),
                audience: Architect.Utilities.Helpers.Settings.StringValue("Jwt:Audience"),
                claims: claims,
                expires: userInfo.Expires,
                signingCredentials: credentials);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}