using Architect.API.Core.Contracts.Security;
using Architect.API.Core.DataAccess.Security;
using Architect.Utilities.Extensions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Architect.API.Core.Security
{
    public static class Accounts
    {

        public static string GeneratorToken(Contracts.Security.Token userInfo)
        {
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Architect.Utilities.Helpers.Settings.StringValue("Jwt:SecretKey")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                                    new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                                    new Claim("UserId", userInfo.UserId.ToString()),
                                    new Claim("Body",Architect.Utilities.Helpers.CryptSupport.EncryptString(Architect.Utilities.SerializeHandler<Contracts.Security.Token>.Serialize(userInfo).CompressString())),
                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                                };
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