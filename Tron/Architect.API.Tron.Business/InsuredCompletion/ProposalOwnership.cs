namespace Architect.API.Tron.Business.InsuredCompletion
{
    /// <summary>
    /// Resolves whether an authenticated agent owns a proposal before an invitation capability can be issued.
    /// </summary>
    public static class ProposalOwnership
    {
        /// <summary>
        /// Checks proposal ownership within the caller's company boundary.
        /// </summary>
        /// <param name="proposalId">Proposal identifier supplied by the agent.</param>
        /// <param name="companyId">Company identifier obtained from the authenticated token.</param>
        /// <param name="agentCode">Agent identifier obtained from the authenticated token.</param>
        /// <returns><c>true</c> only when the proposal exists in the company and belongs to that agent.</returns>
        public static bool IsOwnedByAgent(string proposalId, int companyId, int agentCode)
        {
            return RetrieveOwnedByAgent(proposalId, companyId, agentCode) != null;
        }

        /// <summary>
        /// Obtiene la solicitud del agente dentro de su compañía para reutilizar su identificador técnico al emitir una invitación.
        /// </summary>
        /// <param name="proposalId">Identificador de negocio proporcionado por el agente.</param>
        /// <param name="companyId">Identificador de compañía obtenido del token autenticado.</param>
        /// <param name="agentCode">Identificador del agente obtenido del token autenticado.</param>
        /// <returns>Solicitud perteneciente al agente, o <c>null</c> cuando no existe o pertenece a otro agente.</returns>
        public static Contracts.PolicyProposal RetrieveOwnedByAgent(string proposalId, int companyId, int agentCode)
        {
            Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.RetrieveByProposalId(proposalId, companyId);
            return proposal != null && proposal.AgentCode == agentCode ? proposal : null;
        }

        /// <summary>
        /// Obtiene una solicitud por su identificador técnico, exclusivamente cuando pertenece al agente autenticado.
        /// </summary>
        /// <param name="policyProposalId">Identificador técnico de la solicitud.</param>
        /// <param name="companyId">Identificador de la compañía obtenido del token autenticado.</param>
        /// <param name="agentCode">Identificador del agente obtenido del token autenticado.</param>
        /// <returns>Solicitud perteneciente al agente, o <c>null</c> cuando no existe o pertenece a otro agente.</returns>
        public static Contracts.PolicyProposal RetrieveOwnedByAgent(int policyProposalId, int companyId, int agentCode)
        {
            Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.Retrieve(policyProposalId, companyId);
            return proposal != null && proposal.AgentCode == agentCode ? proposal : null;
        }
    }
}
