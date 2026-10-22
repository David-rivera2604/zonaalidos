using System;
using Architect.API.Tron.Contracts.InsuredCompletion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Verifica que la invitación conserve la relación técnica con la solicitud sin sustituir su identificador de negocio.
    /// </summary>
    [TestClass]
    public class PolicyProposalInvitationContractTests
    {
        /// <summary>
        /// Conserva tanto la clave técnica como el identificador de negocio de la solicitud autorizada.
        /// </summary>
        [TestMethod]
        public void CreateActive_ConservaIdentificadorTecnicoDeSolicitud()
        {
            PolicyProposalInvitation invitation = PolicyProposalInvitation.CreateActive(
                1001,
                12,
                2109,
                "1172109",
                "insured@example.test",
                "hash",
                new DateTime(2026, 10, 6, 12, 0, 0, DateTimeKind.Utc),
                new DateTime(2026, 10, 8, 12, 0, 0, DateTimeKind.Utc));

            Assert.AreEqual(2109, invitation.PolicyProposalId);
            Assert.AreEqual("1172109", invitation.ProposalId);
        }

        /// <summary>
        /// Impide crear invitaciones sin una solicitud técnica válida a la cual asociarse.
        /// </summary>
        [TestMethod]
        public void CreateActive_RechazaIdentificadorTecnicoNoPositivo()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                PolicyProposalInvitation.CreateActive(
                    1001,
                    12,
                    0,
                    "1172109",
                    "insured@example.test",
                    "hash",
                    DateTime.UtcNow,
                    DateTime.UtcNow.AddHours(1)));
        }
    }
}
