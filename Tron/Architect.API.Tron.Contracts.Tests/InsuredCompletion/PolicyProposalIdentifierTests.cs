using System;
using Architect.API.Tron.Business.Backoffice;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Verifica la generación del identificador de negocio inmutable de una solicitud de póliza.
    /// </summary>
    [TestClass]
    public class PolicyProposalIdentifierTests
    {
        /// <summary>
        /// Concatena el ramo y el identificador técnico sin separadores ni relleno.
        /// </summary>
        [TestMethod]
        public void Create_ConcatenaRamoEIdentificadorSinSeparador()
        {
            Assert.AreEqual("1172109", PolicyProposalIdentifier.Create(117, 2109));
        }

        /// <summary>
        /// Rechaza un ramo que no identifica una línea de negocio válida.
        /// </summary>
        [TestMethod]
        public void Create_RechazaRamoNoPositivo()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => PolicyProposalIdentifier.Create(0, 2109));
        }

        /// <summary>
        /// Rechaza un identificador técnico que no puede relacionarse con una solicitud persistida.
        /// </summary>
        [TestMethod]
        public void Create_RechazaIdentificadorNoPositivo()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => PolicyProposalIdentifier.Create(117, 0));
        }
    }
}
