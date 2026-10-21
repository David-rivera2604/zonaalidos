using System.Collections.Generic;

namespace Architect.API.Tron.Business.InsuredCompletion
{
    /// <summary>
    /// Entrega capacidades de completado por asegurado mediante el transporte de correo predeterminado ya configurado.
    /// La URL renderizada se entrega al motor de plantillas, pero este adaptador ni su operación sensible la registran.
    /// </summary>
    public sealed class InvitationMailSender : IInvitationMailSender
    {
        // Default usa la configuración EMail.* existente; no se requiere una segunda cuenta SMTP.
        private const string MailServer = "Default";
        private const string TemplateKey = "InsuredCompletionInvitation";

        /// <summary>
        /// Envía la plantilla de invitación aprobada mediante la cuenta de correo ya configurada.
        /// </summary>
        /// <param name="recipientEmail">Dirección seleccionada por el agente para el asegurado.</param>
        /// <param name="invitationUrl">URL de capacidad cuyo secreto se transporta en el fragmento.</param>
        /// <param name="companyId">Empresa usada para resolver la plantilla y su contexto.</param>
        /// <param name="userId">Usuario autenticado expuesto como CurrentUser en la plantilla.</param>
        /// <param name="ownerId">Propietario expuesto como Owner en la plantilla.</param>
        public void Send(string recipientEmail, string invitationUrl, int companyId, int userId, int ownerId)
        {
            Core.Business.General.Mail.SendSensitiveByTemplate(
                MailServer,
                TemplateKey,
                companyId,
                userId,
                ownerId,
                new { InvitationUrl = invitationUrl },
                new Dictionary<string, string> { { recipientEmail, string.Empty } });
        }
    }
}
