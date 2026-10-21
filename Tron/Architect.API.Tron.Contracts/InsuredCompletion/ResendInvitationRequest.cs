namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Contiene exclusivamente el correo que el agente puede corregir al reenviar una invitación.
    /// </summary>
    public sealed class ResendInvitationRequest
    {
        /// <summary>Correo electrónico actualizado del asegurado.</summary>
        public string RecipientEmail { get; set; }
    }
}
