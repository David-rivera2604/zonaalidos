using Architect.API.Core.Contracts.Security;
using Architect.API.Core.DataAccess.Security;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using Architect.API.Core.Security;
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

        public static HttpCookie AssingedContext( HttpRequestBase request, AuthenticationResponse responseItem, Architect.API.Core.Contracts.Security.Token token)
        {
            var authCookie = new HttpCookie("AuthToken", responseItem.Token)
            {
                Expires = DateTime.Now.AddMinutes(responseItem.ExpiresIn),
                HttpOnly = ShouldEnableHttpOnly(request),
                Secure = request.IsSecureConnection,
                SameSite = SameSiteMode.Lax,
                Path = "/"
            };
            token.Assinged();
            return authCookie;
        }

        /// <summary>
        /// Determines if HttpOnly should be enabled based on the request URL or environment
        /// </summary>
        private static bool ShouldEnableHttpOnly(HttpRequestBase request)
        {
            // Option 1: Based on host/domain
            string host = request.Url.Host.ToLower();

            // Disable HttpOnly only for specific development domains
            if (host.Contains("localhost") || host.Contains("127.0.0.1"))
            {
                // For development, you might want HttpOnly = false for testing
                return false;
            }

            // Option 2: Based on specific URL patterns
            if (request.Url.AbsolutePath.Contains("/api/external"))
            {
                return false; // Disable for specific APIs that need JS access
            }

            // Option 3: Based on configuration setting
            bool httpOnlyFromConfig = Business.Settings.BoolValue(0, "Security.Cookie.HttpOnly", true);
            if (!httpOnlyFromConfig)
            {
                return false;
            }

            // Default: ALWAYS use HttpOnly = true for security (RECOMMENDED)
            return true;
        }


        /// <summary>
        /// Permite autenticar un usuario por medio de sus credenciales.
        /// </summary>
        /// <param name="authenticationRequest">Credenciales de uso.</param>
        /// <returns>Contexto de autenticación incluyendo el token que identifica la sesión del usuario.</returns>
        public static Contracts.Security.AuthenticationResponse Authentication(Contracts.Security.AuthenticationRequest authenticationRequest, ref Contracts.Security.Token token, bool firstInit = false)
        {
            var result = new Contracts.Security.AuthenticationResponse { Settings = new List<SettingItem>() };
            var track = new Contracts.Security.AuthenticationTrace 
            { 
                TraceType = 1, 
                IPAddress = authenticationRequest.IPAddress, 
                UserName = authenticationRequest.Email, 
                UserAgent = authenticationRequest.UserAgent 
            };

            // Validar request inicial
            if (!AccountSupport.ValidateAuthenticationRequest(authenticationRequest, result))
            {
                Business.Security.AuthenticationTrace.Create(track);
                return result;
            }

            // Obtener información del tenant
            int companyId = 0;
            if (!AccountSupport.TryGetCompanyId(authenticationRequest.Tenant, result, track, out companyId))
            {
                Business.Security.AuthenticationTrace.Create(track);
                return result;
            }

            // Recuperar usuario
            track.UserName = authenticationRequest.Email.Trim();
            var user = AccountSupport.RetrieveUser(authenticationRequest.Email, companyId);

            //Verifica si el usuario no está registrado
            if (user.IsEmpty())
            {
                track.TraceType = 1;
                result.Reason = "Usuario no registrado";
                track.Reason = result.Reason;
                Business.Security.AuthenticationTrace.Create(track);
                return result;
            }

            // Actualizar tracking con datos de usuario
            track.UserId = user.UserId;
            track.UserName = user.UserName;
            result.EMail = user.EMail;

            // Validar credenciales
            var accessAllowed = AccountSupport.ValidateUserCredentials(authenticationRequest, user, result, track);

            if (accessAllowed)
            {
                // Autenticación exitosa
                ProcessSuccessfulAuthentication(authenticationRequest, user, result, ref token, firstInit, companyId, track);
            }
            else
            {
                // Autenticación fallida
                AccountSupport.ProcessFailedAuthentication(authenticationRequest, user, result, track);
            }

            track.Reason = result.Reason;
            Business.Security.AuthenticationTrace.Create(track);

            if (result.MustChangePassword && user != null)
            {
                OTP.Create(new ResetPasswordRequest { Tenant = authenticationRequest.Tenant, EMail = user.EMail }, user, "MustChangePassword");
            }

            return result;
        }

        /// <summary>
        /// Procesa una autenticación exitosa.
        /// </summary>
        private static void ProcessSuccessfulAuthentication(
            Contracts.Security.AuthenticationRequest request, 
            Contracts.Security.UserMember user, 
            Contracts.Security.AuthenticationResponse result, 
            ref Contracts.Security.Token token, 
            bool firstInit, 
            int companyId,
            Contracts.Security.AuthenticationTrace track)
        {
            track.TraceType = 2;
            
            // Configurar tiempos de expiración
            var sessionTimeout = Business.Settings.IntegerValue(0, "Security.Session.Timeout", 30);
            result.ExpiresIn = sessionTimeout;
            var tokenExpiresIn = Business.Settings.IntegerValue(0, "Security.Token.Timeout", (int)(sessionTimeout * 2.5));

            // Configurar información básica
            result.UserName = string.Format("{0} {1}", user.FirstName, user.LastName).Trim();

            // Obtener roles
            var roles = DataAccess.Security.UserRoleMember.RetrieveLookByUserId(user.UserId, user.CompanyId);
            result.Roles = roles.Select(x => x.Description).ToArray();

            // Crear token
            var agentInfo = AccountSupport.GetAgentInformation(user);
            var tokenItem = AccountSupport.CreateTokenItem(user, roles, agentInfo, tokenExpiresIn, result.UserName);
            token = tokenItem;

            if (firstInit)
            {
                UserIdActual = tokenItem;
            }

            // Configurar settings
            AccountSupport.ApplySettings(user.CompanyId, result, tokenItem);

            // Generar token de acceso
            result.Token = Architect.API.Core.Security.Accounts.GeneratorToken(tokenItem);

            // Actualizar usuario
            AccountSupport.UpdateUserOnSuccessfulLogin(user);

            // Configurar ruta inicial
            result.InitialPath = AccountSupport.DetermineInitialPath(user, roles, companyId);

            // Verificar si debe cambiar contraseña
            if (!request.EmployeeMode)
            {
                var expirationDays = Business.Settings.IntegerValue(0, "Security.Password.Expiration", 90);
                result.MustChangePassword = user.PasswordChangedDate.AddDays(expirationDays) <= DateTime.Today;
            }

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

            // Verificar 2FA
            result.Need2FAOTP = Business.Settings.BoolValue(0, "Security.2FA.Enable", false);
            if (!result.MustChangePassword && result.Need2FAOTP)
            {
                OTP.Create(new ResetPasswordRequest { Tenant = request.Tenant, EMail = user.EMail, IPAddress = request.IPAddress }, user, "2FA");
            }
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
            Core.Contracts.General.LookupValue companyItem = AccountSupport.TenantInformation(registerRequest.Tenant);

            if (companyItem.IsNotEmpty())
            {
                companyId = Int32.Parse(companyItem.Code);
                internalUserId = Architect.Utilities.Helpers.Settings.IntegerValue(string.Format("Tenant.Settings.{0}.External.UserId", companyId));
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
                string roleName = Architect.Utilities.Helpers.Settings.StringValue(string.Format("Tenant.Settings.{0}.External.RoleName", companyId));
                if (roleName.IsNotEmpty())
                {
                    Contracts.General.LookupValue rolInfo = Common.Lkp("Roles", companyId).Where(r => r.Description == roleName).FirstOrDefault();
                    if (rolInfo.IsNotEmpty())
                    {
                        roleId = rolInfo.Code;
                    }
                }
                if (roleId.IsEmpty())
                {
                    roleId = Architect.Utilities.Helpers.Settings.StringValue(string.Format("Tenant.Settings.{0}.External.RoleId", companyId));
                }

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
    
    }
}