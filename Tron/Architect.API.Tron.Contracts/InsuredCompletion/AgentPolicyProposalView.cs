namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Expone al agente la solicitud de póliza y las únicas acciones disponibles para su estado actual.
    /// </summary>
    public sealed class AgentPolicyProposalView
    {
        /// <summary>Identificador técnico de la solicitud.</summary>
        public int Id { get; set; }
        /// <summary>Identificador de negocio de la solicitud.</summary>
        public string ProposalId { get; set; }
        /// <summary>Estado numérico vigente.</summary>
        public int Status { get; set; }
        /// <summary>Descripción funcional del estado vigente.</summary>
        public string StatusDesc { get; set; }
        /// <summary>Instantánea del formulario creada por el agente o asegurado.</summary>
        public string ProposalData { get; set; }
        /// <summary>Resumen no sensible de la última invitación.</summary>
        public InvitationSummaryView Invitation { get; set; }
        /// <summary>Indica si se puede reenviar una invitación.</summary>
        public bool CanResend { get; set; }
        /// <summary>Indica si se puede anular la invitación activa.</summary>
        public bool CanRevoke { get; set; }
        /// <summary>Indica si se puede regresar la solicitud a borrador.</summary>
        public bool CanResumeEditing { get; set; }
    }
}
