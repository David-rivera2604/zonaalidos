using Architect.API.Core.Contracts.Security;
using Architect.API.Core.DataAccess.Security;
using Architect.API.Core.Security;
using Architect.Utilities;
using Architect.Utilities.Extensions;
using Architect.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Architect.API.Core.Business.Security
{
    public static class Accounts
    {
        /// <summary>
        /// objeto de clase Security.Token que almacena el usuario actual
        /// </summary>
        public static Contracts.Security.Token UserIdActual;

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

        /// <summary>
        /// Permite autenticar un usuario por medio de sus credenciales.
        /// </summary>
        /// <param name="authenticationRequest">Credenciales de uso.</param>
        /// <returns>Contexto de autenticación incluyendo el token que identifica la sesión del usuario.</returns>

        public static Contracts.Security.AuthenticationResponse Authentication(this Contracts.Security.AuthenticationRequest authenticationRequest, ref Contracts.Security.Token token, bool firstInit = false, bool fromAliados = false)
        {
            var result = new Contracts.Security.AuthenticationResponse { Settings = new List<SettingItem>() };

            var track = new Contracts.Security.AuthenticationTrace
            {
                TraceType = 1,
                IPAddress = authenticationRequest.IPAddress,
                UserName = authenticationRequest.Email?.Trim(),
                UserAgent = authenticationRequest.UserAgent
            };

            // Validar request inicial
            if (!AccountSupport.ValidateAuthenticationRequest(authenticationRequest, result))
            {
                Business.Security.AuthenticationTrace.Create(track);
                return result;
            }

            // Obtener información del tenant
            if (!AccountSupport.TryGetCompanyId(authenticationRequest.Tenant, result, track, out int companyId))
            {
                Business.Security.AuthenticationTrace.Create(track);
                return result;
            }

            // Recuperar usuario
            var user = AccountSupport.RetrieveUser(authenticationRequest.Email, companyId);

            // Usuario no registrado
            if (user.IsEmpty())
            {
                result.Reason = track.Reason = "Usuario no registrado";
                Business.Security.AuthenticationTrace.Create(track);
                return result;
            }

            // Las cuentas de servicio nopueden autenticarse desde Aliados
            if (user.IsService & fromAliados)
            {
                result.Reason = track.Reason = "Las cuentas de servicio deben ser autenticadas desde el api";
                Business.Security.AuthenticationTrace.Create(track);
                return result;
            }

            // Actualizar tracking
            track.UserId = user.UserId;
            track.UserName = user.UserName;
            result.EMail = user.EMail;

            // Validar credenciales
            var accessAllowed = AccountSupport.ValidateUserCredentials(authenticationRequest, user, result, track);

            if (!accessAllowed)
                AccountSupport.ProcessFailedAuthentication(authenticationRequest, user, result, track);
            else
            {
                string mode = "Security.2FA.Mode".StringValue(0, "none").ToLower();

                // Si se trata de una cuenta de servicio no se usa 2FA
                if (user.IsService)
                {
                    result.Need2FAOTP = false;
                }
                else
                {
                    switch (mode)
                    {
                        case "full":    // Forza el 2FA oara todos los usuarios.
                            result.Need2FAOTP = true;
                            break;

                        case "user":    // Respeta lo indicado por cada usuario.
                            result.Need2FAOTP = user.Is2FAEnabled;
                            break;

                        default:        // Modo de autenticación normal.
                            result.Need2FAOTP = false;
                            break;
                    }
                }

                if (!result.Need2FAOTP)
                    ProcessSuccessfulAuthentication(authenticationRequest, user, result, ref token, firstInit, companyId, track);
                else
                {
                    if (!authenticationRequest.EmployeeMode)
                        result.MustChangePassword = user.PasswordChangedDate.AddDays("Security.Password.Expiration".IntegerValue(0, 90)) <= DateTime.Today;

                    if (result.MustChangePassword)
                        ProcessSuccessfulAuthentication(authenticationRequest, user, result, ref token, firstInit, companyId, track);
                    else
                    {
                        var roles = DataAccess.Security.UserRoleMember.RetrieveLookByUserId(user.UserId, user.CompanyId);
                        result.ExpiresIn = "Security.Session.Timeout".IntegerValue(0, 30);

                        var tokenBody = TokenItem(
                            user,
                            roles.ToArrayOf(x => x.Description),
                            "Security.Token.Timeout".IntegerValue(0, (int)(result.ExpiresIn * 2.5)),
                            user.UserName
                        );

                        result.InitialPath = AccountSupport.DetermineInitialPath(user, roles, companyId);
                        result.Token = Architect.API.Core.Security.Accounts.GeneratorToken(tokenBody);
                        result.UserName = user.UserName;
                        result.Roles = roles.ToArrayOf(c => c.Description);

                        // Crear sesión
                        Architect.API.Core.Security.Session.Create(new Contracts.Security.Activity
                        {
                            Token = result.Token,
                            CompanyId = user.CompanyId,
                            CompanyName = result.Tenant,
                            UserId = user.UserId,
                            UserName = user.UserName,
                            EMail = user.EMail,
                            IP = track.IPAddress,
                            UserAgent = track.UserAgent
                        });

                        var key = OTP.Create(
                            new ResetPasswordRequest { Tenant = authenticationRequest.Tenant, EMail = user.EMail, IPAddress = authenticationRequest.IPAddress },
                            user,
                            "2FA"
                        );

                        var aOTPResponse = new Contracts.Security.AOTPResponse { Context = result, Token = tokenBody, Key = key };
                        result.AOTP = aOTPResponse;
                        key.SetItem(aOTPResponse.SerializeJSON<Contracts.Security.AOTPResponse>(false));
                        result.Token = string.Empty;
                    }
                }
            }

            // Finalizar tracking
            track.Reason = result.Reason;
            Business.Security.AuthenticationTrace.Create(track);

            if (result.MustChangePassword)
            {
                OTP.Create(
                    new ResetPasswordRequest { Tenant = authenticationRequest.Tenant, EMail = user.EMail },
                    user,
                    "MustChangePassword"
                );
            }

            return result;
        }

        /// <summary>
        /// Procesa una autenticación exitosa.
        /// </summary>
        private static void ProcessSuccessfulAuthentication(Contracts.Security.AuthenticationRequest request, Contracts.Security.UserMember user, Contracts.Security.AuthenticationResponse result,
            ref Contracts.Security.Token token, bool firstInit, int companyId, Contracts.Security.AuthenticationTrace track)
        {
            track.TraceType = 2;

            // Configurar tiempos de expiración
            result.ExpiresIn = "Security.Session.Timeout".IntegerValue(0, 30);
            var tokenExpiresIn = "Security.Token.Timeout".IntegerValue(0, (int)(result.ExpiresIn * 2.5));

            // Configurar información básica
            result.UserName = string.Format("{0} {1}", user.FirstName, user.LastName).Trim();

            // Obtener roles
            ;

            var roles = DataAccess.Security.UserRoleMember.RetrieveLookByUserId(user.UserId, user.CompanyId);
            result.Roles = roles.ToArrayOf(x => x.Description);

            // Crear token
            token = TokenItem(user, result.Roles, tokenExpiresIn, result.UserName);

            if (firstInit)
            {
                UserIdActual = token;
            }

            // Configurar settings
            AccountSupport.ApplySettings(user.CompanyId, result, token);

            // Generar token de acceso
            result.Token = Architect.API.Core.Security.Accounts.GeneratorToken(token);

            // Actualizar usuario
            AccountSupport.UpdateUserOnSuccessfulLogin(user);

            // Configurar ruta inicial
            result.InitialPath = AccountSupport.DetermineInitialPath(user, roles, companyId);

            // Verificar si debe cambiar contraseña
            //if (!request.EmployeeMode)
            //{
            //    var expirationDays = "Security.Password.Expiration".IntegerValue(0, 90);
            //    result.MustChangePassword = user.PasswordChangedDate.AddDays(expirationDays) <= DateTime.Today;
            //}

            // Crear sesión
            Architect.API.Core.Security.Session.Create(new Contracts.Security.Activity
            {
                Token = result.Token,
                CompanyId = user.CompanyId,
                CompanyName = result.Tenant,
                UserId = user.UserId,
                UserName = user.UserName,
                EMail = user.EMail,
                IP = request.IPAddress,
                UserAgent = request.UserAgent
            });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        /// <param name="tokenExpiresIn"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static Contracts.Security.Token TokenItem(Contracts.Security.UserMember user, string[] roles, int tokenExpiresIn, string userName)
        {
            Contracts.Security.Token result = new Contracts.Security.Token();
            var agentInfo = AccountSupport.GetAgentInformation(user);
            var tokenItem = AccountSupport.CreateTokenItem(user, roles, agentInfo, tokenExpiresIn, userName);
            result = tokenItem;
            return result;
        }

        /// <summary>
        /// Leer los colores disponibles
        /// </summary>
        public static List<Architect.API.Core.Contracts.Security.ColoresResponse> ReadColor()
        {
            List<Architect.API.Core.Contracts.Security.ColoresResponse> RespuestaData = Architect.API.Core.DataAccess.General.ColorKey.RetrieveAllColors();

            return RespuestaData;
        }

        /// <summary>
        /// Leer datos del inicio
        /// </summary>
        public static Architect.API.Core.Contracts.Security.ClientesInicioResponse ReadInicio(Core.Contracts.Security.Token tokenInfo)
        {
            Architect.API.Core.Contracts.Security.ClientesInicioResponse DataInicio = Architect.API.Core.DataAccess.General.ProcessData.RetrieveInicio(tokenInfo.CompanyId);

            return DataInicio;
        }

        /// <summary>
        /// Restablece la contraseña de un usuario.
        /// </summary>
        public static Core.Contracts.General.GenericResponse ResetPassword(Contracts.Security.ResetPasswordRequest resetRequest)
        {
            Core.Contracts.General.GenericResponse result = new Contracts.General.GenericResponse() { Successful = false, Reason = string.Empty };
            int companyId = 0;
            Contracts.Security.AuthenticationTrace track = new Contracts.Security.AuthenticationTrace() { TraceType = 9, IPAddress = resetRequest.IPAddress };
            if (resetRequest.Tenant.IsEmpty())
                result.Reason = "Debe indicar la compañia";
            if (result.Reason.IsEmpty())
            {
                Core.Contracts.General.LookupValue companyItem = AccountSupport.TenantInformation(resetRequest.Tenant);

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
                                result.Successful = true;

                                user.OldPassword = user.Password;
                                user.Password = PasswordHasher.HashPassword(resetRequest.Password);
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

        /// <summary>
        /// Cambia la contraseña de un usuario.
        /// </summary>
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
                        if (PasswordHasher.VerifyPassword(resetRequest.Current, user.Password))
                        {
                            result.Successful = true;

                            user.OldPassword = user.Password;
                            user.Password = PasswordHasher.HashPassword(resetRequest.Password);
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
            Core.Contracts.General.LookupValue companyItem = AccountSupport.TenantInformation(registerRequest.Tenant);

            if (companyItem.IsNotEmpty())
            {
                companyId = Int32.Parse(companyItem.Code);
                internalUserId = $"Tenant.Settings.{companyId}.External.UserId".IntegerValue();
                result.UserMember.CompanyId = companyId;

                result.Errors = UserMember.Validate(result.UserMember, true);
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
                        ClientInformation clientInfo = Tron.RetrieveClientInformationByDocument(result.UserMember.IdentificationType.ToString().IdentificationType(), result.UserMember.Identification.DocumentNumber(result.UserMember.IdentificationType.ToString().IdentificationType()));

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
                string roleId = "";
                string roleName = string.Format("Tenant.Settings.{0}.External.RoleName", companyId).StringValue();
                if (roleName.IsNotEmpty())
                {
                    Contracts.General.LookupValue rolInfo = Common.Lkp("Roles", companyId).Where(r => r.Description == roleName).FirstOrDefault();
                    if (rolInfo.IsNotEmpty())
                    {
                        roleId = rolInfo.Code;
                    }
                }
                if (roleId.IsEmpty())                
                    roleId = string.Format("Tenant.Settings.{0}.External.RoleId", companyId).StringValue();
                

                result.UserMember.Roles = new List<Architect.Utilities.Contracts.LookUpValue> { new Architect.Utilities.Contracts.LookUpValue() { Code = roleId } };
                result.UserMember = UserMember.Create(companyId, internalUserId, result.UserMember, 1);
            }

            return result;
        }

        /// <summary>
        /// Permite autenticar un usuario por medio de sus credenciales.
        /// </summary>
        public static async Task<Architect.API.Core.Contracts.Seguridad.RespuestaSeguridad> Token(string clienteID, string secretID, string ipAddress, string userAgent)
        {
            Architect.API.Core.Contracts.Seguridad.RespuestaSeguridad result = null;
            try
            {
                if (string.IsNullOrEmpty(clienteID) || string.IsNullOrEmpty(secretID))
                {
                    return result;
                }
                else
                {
                    Architect.API.Core.Contracts.Security.Token token = null;

                    AuthenticationResponse response = Architect.API.Core.Business.Security.Accounts.Authentication(new AuthenticationRequest()
                    {
                        Tenant = "Aliados",
                        Email = clienteID,
                        Password = secretID,
                        IPAddress = ipAddress,
                        UserAgent = userAgent
                    }, ref token);

                    if (response != null)
                    {
                        result = new Architect.API.Core.Contracts.Seguridad.RespuestaSeguridad()
                        {
                            access_token = response.Token,
                            token_type = "Bearer",
                            expires_in = response.ExpiresIn
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(ex);
            }

            return result;
        }

        /// <summary>
        /// Obtiene el perfil de un usuario.
        /// </summary>
        public static Contracts.Security.UserMember Profile(int companyId, int userId)
        {
            Contracts.Security.UserMember result = null;
            Architect.API.Core.Contracts.Security.UserMember user = Architect.API.Core.DataAccess.Security.UserMember.Retrieve(userId, companyId);
            if (user != null)
            {
                result = new Contracts.Security.UserMember
                {
                    EMail = user.EMail,
                    PhoneNumber = user.PhoneNumber
                };
            }
            return result;
        }

        /// <summary>
        /// Autentica a un usuario cuya identidad ya fue verificada por Microsoft Entra ID.
        /// No valida contraseña; el email proviene del id_token de Microsoft.
        /// </summary>
        /// <param name="email">Correo extraído del token de Entra ID.</param>
        /// <param name="tenant">Nombre del tenant al que pertenece el usuario.</param>
        /// <param name="ipAddress">Dirección IP del cliente.</param>
        /// <param name="userAgent">User-Agent del cliente.</param>
        /// <param name="token">Token de salida con el contexto del usuario autenticado.</param>
        /// <returns>Respuesta de autenticación con el token JWT y datos del usuario.</returns>
        public static Contracts.Security.AuthenticationResponse AuthenticationByEntraId(
            string email, string tenant, string ipAddress, string userAgent,
            ref Contracts.Security.Token token)
        {
            var result  = new Contracts.Security.AuthenticationResponse { Settings = new List<SettingItem>() };
            var track   = new Contracts.Security.AuthenticationTrace
            {
                TraceType = 1,
                IPAddress = ipAddress,
                UserName  = email?.Trim(),
                UserAgent = userAgent
            };

            var dummyRequest = new Contracts.Security.AuthenticationRequest
            {
                Tenant    = tenant,
                Email     = email,
                IPAddress = ipAddress,
                UserAgent = userAgent
            };

            if (!AccountSupport.TryGetCompanyId(tenant, result, track, out int companyId))
            {
                AuthenticationTrace.Create(track);
                return result;
            }

            var user = AccountSupport.RetrieveUser(email, companyId);
            if (user.IsEmpty())
            {
                result.Reason = track.Reason = "Usuario no registrado";
                AuthenticationTrace.Create(track);
                return result;
            }

            track.UserId   = user.UserId;
            track.UserName = user.UserName;
            result.EMail   = user.EMail;

            ProcessSuccessfulAuthentication(dummyRequest, user, result, ref token, true, companyId, track);

            track.Reason = result.Reason;
            AuthenticationTrace.Create(track);

            return result;
        }
    }
}