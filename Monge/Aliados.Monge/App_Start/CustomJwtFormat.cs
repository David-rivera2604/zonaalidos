using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Configuration;
using Thinktecture.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace Aliados.Monge.App_Start
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {

        private readonly string _issuer = string.Empty;

        public CustomJwtFormat(string issuer)
        {
            _issuer = issuer;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            //string audienceId = ;

            //string symmetricKeyAsBase64 = ConfigurationManager.AppSettings["as:AudienceSecret"];

            //var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);

            ////var signingKey = new HmacSigningCredentials(keyByteArray);
            //var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(keyByteArray);
            //var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
            //securityKey, SecurityAlgorithms.HmacSha256Signature);

            //var issued = data.Properties.IssuedUtc;

            //var expires = data.Properties.ExpiresUtc;

            ////var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime,  signingKey);
            //var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingCredentials);

            var securityKey2 = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["Jwt:SecretKey"]));
            var credentials2 = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey2, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);

            var token2 = new JwtSecurityToken(
                                issuer: ConfigurationManager.AppSettings["Jwt:Issuer"],
                                audience: ConfigurationManager.AppSettings["Jwt:Audience"],
                                claims: data.Identity.Claims,
                                expires: data.Properties.ExpiresUtc.Value.UtcDateTime,
                                signingCredentials: credentials2);

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token2);

            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(protectedText, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = ConfigurationManager.AppSettings["Jwt:Issuer"],
                ValidAudience = ConfigurationManager.AppSettings["Jwt:Audience"],
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["Jwt:SecretKey"])), // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out Microsoft.IdentityModel.Tokens.SecurityToken validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;
            return new AuthenticationTicket(principal.Identities.First(), new AuthenticationProperties());
            throw new NotImplementedException();
        }
    }
}