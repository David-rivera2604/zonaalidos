using System;

namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Applies the domain transition used when an agent replaces an invitation for a proposal.
    /// </summary>
    public static class InvitationStateMachine
    {
        /// <summary>
        /// Revokes the prior invitation, when present, and creates its active replacement.
        /// </summary>
        /// <param name="policyProposalId">Identificador técnico NUMBER(9) de la solicitud autorizada.</param>
        /// <returns>The active replacement invitation.</returns>
        public static PolicyProposalInvitation CreateActiveAndRevokePrior(
            PolicyProposalInvitation previous,
            int id,
            int companyId,
            int policyProposalId,
            string proposalId,
            string secretHash,
            DateTime createdAtUtc,
            DateTime expiresAtUtc)
        {
            if (previous != null)
            {
                previous.Revoke(createdAtUtc);
            }

            return PolicyProposalInvitation.CreateActive(
                id,
                companyId,
                policyProposalId,
                proposalId,
                secretHash,
                createdAtUtc,
                expiresAtUtc);
        }
    }
}
