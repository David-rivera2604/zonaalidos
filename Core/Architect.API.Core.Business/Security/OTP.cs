using Architect.API.Core.Contracts.Security;
using Architect.API.Core.DataAccess.Security;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Threading.Tasks;

namespace Architect.API.Core.Business.Security
{
    public static class OTP
    {

        /// <summary>
        /// Envía un código OTP para restablecer la contraseña de un usuario.
        /// </summary>
        public static Core.Contracts.General.GenericResponse Send(Contracts.Security.ResetPasswordRequest resetRequest)
        {
            Core.Contracts.General.GenericResponse result = new Contracts.General.GenericResponse() { Successful = false, Reason = string.Empty };
            int companyId = 0;
            Contracts.Security.AuthenticationTrace track = new Contracts.Security.AuthenticationTrace() { TraceType = 7, IPAddress = resetRequest.IPAddress };
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
                    Create(resetRequest, user, "ResetPassword");
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

        /// <summary>
        /// Crea un código OTP para restablecer la contraseña de un usuario.
        /// </summary>
        public static void Create(ResetPasswordRequest resetRequest, Contracts.Security.UserMember user, string mode)
        {
            Random random = new Random();
            user.OneTimePassword = random.Next(100000, 999999).ToString();

            //Define que la expiracion del OTP es de 60 minutos
            user.LockedOutDate = DateTime.Now.AddMinutes(60);
            DataAccess.Security.UserMember.InternalUpdate(user);
            string templateName = "Notify_OTP";

            if (mode == "2FA")
            {
                templateName = "Notify_2FA";
                AuthenticationTrace.Create(new Contracts.Security.AuthenticationTrace()
                {
                    TraceType = 12,
                    IPAddress = resetRequest.IPAddress,
                    UserName = resetRequest.EMail,
                    UserId = user.UserId,
                    CompanyId = user.CompanyId,
                    Reason = "2FA"
                });
            }

            General.Mail.SendByTemplate(templateName,
                user.CompanyId, new { User = user, Request = resetRequest },
                new Dictionary<string, string> { { user.EMail, string.Empty } });
        }

        /// <summary> 
        /// Valida el código OTP para restablecer la contraseña de un usuario o cuando se activa 2FA.
        /// </summary>
        public static Core.Contracts.General.GenericResponse IsValid(Contracts.Security.ResetPasswordRequest resetRequest)
        {
            Core.Contracts.General.GenericResponse result = new Contracts.General.GenericResponse() { Successful = false, Reason = string.Empty };
            int companyId = 0;
            Contracts.Security.AuthenticationTrace track = new Contracts.Security.AuthenticationTrace() { TraceType = 8, IPAddress = resetRequest.IPAddress };
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
                    track.CompanyId = user.CompanyId;

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

    }
}