namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Permite documentar de forma opcional y acotada la anulación de una invitación.
    /// </summary>
    public sealed class RevokeInvitationRequest
    {
        /// <summary>Motivo opcional, limitado por el servicio a 200 caracteres.</summary>
        public string Reason { get; set; }
    }
}
