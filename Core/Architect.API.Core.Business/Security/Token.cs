using Architect.API.Core.DataAccess.Security;
using Architect.Utilities.Extensions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Web;

namespace Architect.API.Core.Business.Security
{
    public static class Token
    {
        public static Contracts.Security.Token Info()
        {
            Contracts.Security.Token result = new Contracts.Security.Token() { CompanyId = 0, BranchOffice = 0, Roles = string.Empty, ManagerId = 0, SecurityLevel = 0, UserId = 0 };

            if (HttpContext.Current?.User != null && result.CompanyId != 0)
            {
                //System.Security.Claims.ClaimsPrincipal.Current.Identities.First().Claims.ToList()
                System.Security.Claims.ClaimsPrincipal user = (System.Security.Claims.ClaimsPrincipal)HttpContext.Current.User;
                result.CompanyId = Convert.ToInt32(user.Claims.FirstOrDefault(c => c.Type == "CompanyId").Value);
                result.BranchOffice = Convert.ToInt32(user.Claims.FirstOrDefault(c => c.Type == "BranchOffice").Value);
                result.Roles = user.Claims.FirstOrDefault(c => c.Type == "Roles").Value;
                result.ManagerId = Convert.ToInt32(user.Claims.FirstOrDefault(c => c.Type == "ManagerId").Value);
                result.SecurityLevel = Convert.ToInt32(user.Claims.FirstOrDefault(c => c.Type == "SecurityLevel").Value);
                result.UserId = Convert.ToInt32(user.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
                result.AgentCode = Convert.ToInt32(user.Claims.FirstOrDefault(c => c.Type == "AgentCode").Value);
                result.SubAgentCode = Convert.ToInt32(user.Claims.FirstOrDefault(c => c.Type == "SubAgentCode").Value);
                result.IdentificationType = user.Claims.FirstOrDefault(c => c.Type == "IdentificationType").Value;
                result.Identification = user.Claims.FirstOrDefault(c => c.Type == "Identification").Value;
                result.UserName = user.Claims.FirstOrDefault(c => c.Type == "UserName").Value;
            }

            if (result.CompanyId == 0 && HttpContext.Current?.Request?.Headers != null)
            {
                if (HttpContext.Current.Request.Headers["AccessKey"] != null)
                {
                    result = AccessKeyInfo(HttpContext.Current.Request.Headers["AccessKey"]);
                }
                else if (HttpContext.Current.Request.Headers["Authorization"] != null)
                {
                    result = Info(HttpContext.Current.Request.Headers["Authorization"]);
                }
            }
            return result;
        }

        public static string AccessKeyInfo2(string accessKey, string ipAddress)
        {
            string result = string.Empty;
            Architect.API.Core.Contracts.Security.UserMember user = DataAccess.Security.UserMember.RetrieveByAccessKey(accessKey);
            if (user.IsNotEmpty())
            {
                Contracts.Security.Token token = AccessKeyInfo(accessKey);
                if (token.UserId > 0)
                {
                    result = Architect.API.Core.Business.Security.Accounts.GeneratorToken(User2Token(user));

                    Session.Create(new Contracts.Security.Activity()
                        {
                            Token = result,
                            CompanyId = user.CompanyId,
                            UserId = user.UserId,
                            UserName = user.UserName,
                            EMail = user.EMail,
                            IP = ipAddress
                        });
                }
            }
            return result;
        }

        private static Contracts.Security.Token User2Token(Architect.API.Core.Contracts.Security.UserMember user)
        {
            Contracts.Security.Token result = new Contracts.Security.Token() { CompanyId = 0, BranchOffice = 0, Roles = string.Empty, ManagerId = 0, SecurityLevel = 0, UserId = 0 };
            List<Architect.API.Core.Contracts.Security.RoleMember> rols = DataAccess.Security.UserRoleMember.RetrieveLookByUserId(user.UserId, user.CompanyId);

            result.CompanyId = user.CompanyId;
            result.BranchOffice = user.BranchOffice;
            result.Roles = string.Join(",", rols.Select(x => x.Description));
            result.ManagerId = user.ManagerId;
            result.SecurityLevel = user.SecurityLevel;
            result.UserId = user.UserId;
            result.IdentificationType = user.IdentificationType.ToString();
            result.Identification = user.Identification;
            result.UserName = string.Format("{0} {1}", user.FirstName, user.LastName).Trim();
            result.Expires = DateTime.Now.AddMinutes(Utilities.Helpers.Settings.IntegerValue("Session.Timeout", 30));

            //Este bloque esta duplicado en la clase account
            if (user.CompanyId == 2)
            {
                Contracts.Security.AgentInformation agentInfo = Tron.RetrieveAgentInformationByEmail(user.CompanyId, user.EMail);
                if (agentInfo != null)
                {
                    result.AgentCode = agentInfo.cod_agt;
                    result.SubAgentCode = agentInfo.cod_sub_agt;
                    result.IdentificationType = agentInfo.tip_docum;
                    result.Identification = agentInfo.cod_docum;
                }
            }
            if (user.CompanyId == 3)
            {
                result.IdentificationType = result.IdentificationType.IdentificationType();
                result.Identification = Convert.ToInt64(result.Identification.OnlyNumbers()).ToString();
            }
            return result;
        }

        public static Contracts.Security.Token AccessKeyInfo(string accessKey)
        {
            Contracts.Security.Token result = new Contracts.Security.Token() { CompanyId = 0, BranchOffice = 0, Roles = string.Empty, ManagerId = 0, SecurityLevel = 0, UserId = 0 };

            if (accessKey.IsNotEmpty())
            {
                Architect.API.Core.Contracts.Security.UserMember user = DataAccess.Security.UserMember.RetrieveByAccessKey(accessKey);
                if (user.IsNotEmpty())
                {
                    result = User2Token(user);
                    Architect.Utilities.Log.WarningLog(">", string.Format("AccessKey={0} - Ok - CompanyId={1}, UserId={2}, From={3} ", accessKey, result.CompanyId, result.UserId, Architect.Utilities.Helpers.Connection.UserHostAddress()), "api");
                }
                else
                {
                    Architect.Utilities.Log.WarningLog(">", string.Format("AccessKey={0} - Fail - From={1}", accessKey, Architect.Utilities.Helpers.Connection.UserHostAddress()), "api");
                }
            }
            return result;
        }

        public static Contracts.Security.Token Info(string tokenValue)
        {
            Contracts.Security.Token result = null;

            if (tokenValue != null && tokenValue != "null")
            {
                if (tokenValue.StartsWith("Bearer ", StringComparison.CurrentCultureIgnoreCase))
                    tokenValue = tokenValue.Substring(7);

                if (tokenValue.IsNotEmpty() && tokenValue != "null")
                {
                    if (Utilities.Helpers.Settings.StringValue("Token.Mode") != "JWT")
                    {
                        tokenValue = Architect.Utilities.Helpers.CryptSupport.DecryptString(tokenValue);
                        tokenValue = tokenValue.DecompressString();
                        result = Architect.Utilities.SerializeHandler<Contracts.Security.Token>.Deserialize(tokenValue);
                    }
                    else
                    {
                        var tokenHandler = new JwtSecurityTokenHandler();
                        tokenHandler.ValidateToken(tokenValue, new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = Utilities.Helpers.Settings.StringValue("Jwt:Issuer"),
                            ValidAudience = Utilities.Helpers.Settings.StringValue("Jwt:Audience"),
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Utilities.Helpers.Settings.StringValue("Jwt:SecretKey"))), // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                            ClockSkew = TimeSpan.Zero
                        }, out SecurityToken validatedToken);
                        var jwtToken = (JwtSecurityToken)validatedToken;
                        if (jwtToken.Claims.Count(x => x.Type == "Body") != 0)
                        {
                            var body = jwtToken.Claims.First(x => x.Type == "Body").Value.ToString();
                            body = Architect.Utilities.Helpers.CryptSupport.DecryptString(body);
                            body = body.DecompressString();
                            result = Architect.Utilities.SerializeHandler<Contracts.Security.Token>.Deserialize(body);
                        }
                    }
                }
                else
                {
                    result = new Contracts.Security.Token() { CompanyId = 0, BranchOffice = 0, Roles = string.Empty, ManagerId = 0, SecurityLevel = 0, UserId = 0 };
                }
            }

            return result;
        }

        public static string Value()
        {
            string result = null;

            if (HttpContext.Current?.Request?.Headers != null)
            {
                string tokenValue = HttpContext.Current.Request.Headers["Authorization"];
                if (tokenValue != null && tokenValue != "null" && tokenValue.StartsWith("Bearer ", StringComparison.CurrentCultureIgnoreCase))
                {
                    tokenValue = tokenValue.Substring(7);
                }
                result = tokenValue;
            }

            return result;
        }
    }
}