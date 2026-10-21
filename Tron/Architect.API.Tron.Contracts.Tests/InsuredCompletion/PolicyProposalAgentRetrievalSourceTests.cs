using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Protege la recuperación de solicitudes para seguimiento por el agente propietario.
    /// </summary>
    [TestClass]
    public class PolicyProposalAgentRetrievalSourceTests
    {
        /// <summary>
        /// Exige el filtro combinado de identificador técnico, compañía y agente.
        /// </summary>
        [TestMethod]
        public void RecuperacionAgente_UsaClaveTecnicaCompaniaYAgente()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "InsuredCompletion", "ProposalOwnership.cs"));

            StringAssert.Contains(source, "RetrieveOwnedByAgent(int policyProposalId");
            StringAssert.Contains(source, "DataAccess.PolicyProposal.Retrieve(policyProposalId, companyId)");
            StringAssert.Contains(source, "proposal.AgentCode == agentCode");
        }

        /// <summary>
        /// Exige consultar la invitación más reciente usando la clave técnica de la solicitud.
        /// </summary>
        [TestMethod]
        public void InvitacionMasReciente_SeConsultaPorSolicitudTecnica()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.DataAccess", "PolicyProposalInvitation.cs"));

            StringAssert.Contains(source, "RetrieveLatestByPolicyProposalId");
            StringAssert.Contains(source, "PolicyProposalId=:PolicyProposalId");
            StringAssert.Contains(source, "ORDER BY Id DESC");
        }
    }
}
