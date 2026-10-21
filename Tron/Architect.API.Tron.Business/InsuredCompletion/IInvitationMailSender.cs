namespace Architect.API.Tron.Business.InsuredCompletion
{
    /// <summary>
    /// Envía el enlace opaco de invitación mediante el canal de correo saliente aprobado.
    /// </summary>
    public interface IInvitationMailSender
    {
        /// <summary>
        /// Entrega un enlace de invitación sin colocar el secreto en asuntos ni registros de la aplicación.
        /// </summary>
        /// <param name="recipientEmail">Dirección seleccionada para el asegurado.</param>
        /// <param name="invitationUrl">URL cuyo fragmento transporta el secreto de capacidad.</param>
        /// <param name="companyId">Empresa usada para resolver la plantilla y su contexto.</param>
        /// <param name="userId">Usuario autenticado expuesto como CurrentUser en la plantilla.</param>
        /// <param name="ownerId">Propietario expuesto como Owner en la plantilla.</param>
        void Send(string recipientEmail, string invitationUrl, int companyId, int userId, int ownerId);
    }
}
