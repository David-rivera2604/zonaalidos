namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Contiene el alcance autorizado por el agente, el destinatario y el contexto de correo usados para emitir una invitación.
    /// </summary>
    public sealed class CreateInvitationRequest
    {
        /// <summary>Obtiene o establece la empresa propietaria de la propuesta.</summary>
        public int CompanyId { get; set; }
        /// <summary>Obtiene o establece el identificador técnico NUMBER(9) de la solicitud que el asegurado puede completar.</summary>
        public int PolicyProposalId { get; set; }
        /// <summary>Obtiene o establece el identificador de negocio de la propuesta que el asegurado puede completar.</summary>
        public string ProposalId { get; set; }
        /// <summary>Obtiene o establece el correo destinatario seleccionado por el agente.</summary>
        public string RecipientEmail { get; set; }
        /// <summary>Obtiene o establece el usuario autenticado que se expone como CurrentUser en la plantilla.</summary>
        public int UserId { get; set; }
        /// <summary>Obtiene o establece el propietario que se expone como Owner en la plantilla.</summary>
        public int OwnerId { get; set; }
        /// <summary>Obtiene o establece la ruta relativa y los parámetros del formulario que completará el asegurado.</summary>
        public string CompletionPath { get; set; }
        /// <summary>Obtiene o establece el código de flujo servidor que limita los recursos autorizados de la sesión técnica.</summary>
        public string CompletionFlow { get; set; }
    }
}
