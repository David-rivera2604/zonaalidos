using Architect.API.Core.Contracts.Security;
using Architect.API.Core.DataAccess.Security;
using Architect.Utilities.Extensions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Security;

namespace Architect.API.Core.Security
{
    public static class Token
    {
        /// <summary>
        /// Establece la identidad del usuario en el contexto actual (HttpContext.User y Thread.CurrentPrincipal).
        /// Este método toma toda la información del token y la convierte en claims accesibles en el contexto.
        /// Usa EXACTAMENTE las propiedades definidas en Architect.API.Core.Contracts.Security.Token
        /// </summary>
        /// <param name="token">Información del token con todos los datos del usuario.</param>
        public static void Assinged(this Contracts.Security.Token token)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token), "token no puede ser null");
            }

            // 2. ✅ CREAR COOKIE DE AUTENTICACIÓN (solo si HttpContext está disponible)
            if (HttpContext.Current.IsNotEmpty()) 
                FormsAuthentication.SetAuthCookie(token.UserId.ToString(), false);
            

            // Crear identidad con el UserId como nombre de identidad
            var identity = new GenericIdentity(token.UserId.ToString());

            // ====================================================================
            // CLAIMS EXACTOS SEGÚN LA CLASE Token
            // ====================================================================

            // UserId
            identity.AddClaim(new Claim("UserId", token.UserId.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, token.UserId.ToString())); // Claim estándar

            // CompanyId
            identity.AddClaim(new Claim("CompanyId", token.CompanyId.ToString()));

            // BranchOffice
            identity.AddClaim(new Claim("BranchOffice", token.BranchOffice.ToString()));

            // ManagerId
            identity.AddClaim(new Claim("ManagerId", token.ManagerId.ToString()));

            // SecurityLevel
            identity.AddClaim(new Claim("SecurityLevel", token.SecurityLevel.ToString()));

            // Roles
            identity.AddClaim(new Claim("Roles", token.Roles ?? string.Empty));
            identity.AddClaim(new Claim(ClaimTypes.Role, token.Roles ?? string.Empty)); // Claim estándar

            // UserName
            identity.AddClaim(new Claim("UserName", token.UserName ?? string.Empty));
            identity.AddClaim(new Claim(ClaimTypes.Name, token.UserName ?? string.Empty)); // Claim estándar

            // IdentificationType
            identity.AddClaim(new Claim("IdentificationType", token.IdentificationType ?? string.Empty));

            // Identification
            identity.AddClaim(new Claim("Identification", token.Identification ?? string.Empty));

            // AgentCode
            identity.AddClaim(new Claim("AgentCode", token.AgentCode.ToString()));

            // SubAgentCode
            identity.AddClaim(new Claim("SubAgentCode", token.SubAgentCode.ToString()));

            // Expires
            identity.AddClaim(new Claim("Expires", token.Expires.ToString("O"))); // ISO 8601 format
            identity.AddClaim(new Claim(ClaimTypes.Expiration, token.Expires.ToString("O"))); // Claim estándar

            // ====================================================================
            // SETTINGS ADICIONALES (configuraciones personalizadas por compañía)
            // ====================================================================
            if (token.Settings != null && token.Settings.Count > 0)
            {
                foreach (var item in token.Settings)
                {
                    if (!string.IsNullOrEmpty(item.Key) && item.Value != null)
                    {
                        // Agregar con prefijo "app." para identificar settings personalizados
                        identity.AddClaim(new Claim($"app.{item.Key}", item.Value));
                    }
                }
            }

            // ====================================================================
            // CREAR PRINCIPAL CON ROLES
            // ====================================================================
            string[] roles = string.IsNullOrEmpty(token.Roles)
                ? new string[0]
                : token.Roles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(r => r.Trim())
                            .ToArray();

            IPrincipal principal = new GenericPrincipal(identity, roles);

            // ====================================================================
            // ✅ ASIGNAR AL CONTEXTO DEL THREAD ACTUAL
            // ====================================================================
            Thread.CurrentPrincipal = principal;

            // ====================================================================
            // ✅ ASIGNAR AL CONTEXTO HTTP (para controladores MVC y Web API)
            // ====================================================================
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        public static Contracts.Security.Token Info_V2()
        {
            Contracts.Security.Token result = new Contracts.Security.Token() { CompanyId = 0, BranchOffice = 0, Roles = string.Empty, ManagerId = 0, SecurityLevel = 0, UserId = 0 };

            if (HttpContext.Current?.User != null)
            {
                System.Security.Claims.ClaimsPrincipal user = (System.Security.Claims.ClaimsPrincipal)HttpContext.Current.User;

                result = Architect.Utilities.SerializeHandler<Contracts.Security.Token>.Deserialize(Architect.Utilities.Helpers.CryptSupport.DecryptString(user.Claims.FirstOrDefault(c => c.Type == "Body").Value).DecompressString());
            }

            return result;
        }

        public static Contracts.Security.Token Info()
        {
            Contracts.Security.Token result = new Contracts.Security.Token() { CompanyId = 0, BranchOffice = 0, Roles = string.Empty, ManagerId = 0, SecurityLevel = 0, UserId = 0, Settings = new List<Contracts.Security.SettingItem>() };

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

                // Leer Expires desde los claims
                var expiresClaim = user.Claims.FirstOrDefault(c => c.Type == "Expires" || c.Type == ClaimTypes.Expiration);
                if (expiresClaim != null)
                {
                    DateTime expiresDate;
                    if (DateTime.TryParse(expiresClaim.Value, out expiresDate))
                    {
                        result.Expires = expiresDate;
                    }
                }

                foreach (var claim in user.Claims)
                {
                    if (claim.Type.StartsWith("app.", StringComparison.CurrentCultureIgnoreCase))
                    {
                        result.Settings.Add(new Contracts.Security.SettingItem() { Key = claim.Type.Substring(4), Value = claim.Value });
                    }
                }
            }

            if (result.CompanyId == 0 && HttpContext.Current?.Request?.Headers != null)
            {
                if (HttpContext.Current.Request.Headers["_AccessKey_"] != null)
                {
                    result = AccessKeyInfo(HttpContext.Current.Request.Headers["_AccessKey_"]);
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
                    result = Accounts.GeneratorToken(User2Token(user));

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
            Contracts.Security.Token result = new Contracts.Security.Token() { CompanyId = 0, BranchOffice = 0, Roles = string.Empty, ManagerId = 0, SecurityLevel = 0, UserId = 0, Settings = new List<Contracts.Security.SettingItem>() };
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
            result.Expires = DateTime.Now.AddMinutes(Architect.Utilities.Helpers.Settings.IntegerValue("Session.Timeout", 30));


            //Este bloque esta duplicado en la clase account
            if (Utilities.Helpers.Settings.StringValue("Tenant.Tron.Agent.Information").Contain(user.CompanyId.ToString()))
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

            List<Contracts.General.Setting> settings = DataAccess.General.Setting.Retrieve(user.CompanyId);
            if (settings.Count > 0)
            {
                foreach (Contracts.General.Setting item in settings.Where(r => r.TokenEnabled))
                {
                    result.Settings.Add(new Architect.API.Core.Contracts.Security.SettingItem() { Key = item.Key, Value = item.Value });
                }

            }
            return result;
        }

        public static Contracts.Security.Token AccessKeyInfo(string accessKey)
        {
            Contracts.Security.Token result = new Contracts.Security.Token() { CompanyId = 0, BranchOffice = 0, Roles = string.Empty, ManagerId = 0, SecurityLevel = 0, UserId = 0, Settings= new List<Contracts.Security.SettingItem>() };

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

                if (tokenValue.IsNotEmpty() && tokenValue != "null" && tokenValue != "undefined")
                {
                    if (Architect.Utilities.Helpers.Settings.StringValue("Token.Mode") != "JWT")
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
                            ValidIssuer = Architect.Utilities.Helpers.Settings.StringValue("Jwt:Issuer"),
                            ValidAudience = Architect.Utilities.Helpers.Settings.StringValue("Jwt:Audience"),
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Architect.Utilities.Helpers.Settings.StringValue("Jwt:SecretKey"))), // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
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
                    result = new Contracts.Security.Token() { CompanyId = 0, BranchOffice = 0, Roles = string.Empty, ManagerId = 0, SecurityLevel = 0, UserId = 0, Settings= new List<Contracts.Security.SettingItem>() };
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