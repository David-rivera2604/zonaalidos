using System;
using Architect.API.Tron.Contracts.InsuredCompletion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Define los destinos internos que una invitación puede conservar sin habilitar redirecciones externas.
    /// </summary>
    [TestClass]
    public class CompletionDestinationTests
    {
        /// <summary>
        /// Exige que una ruta relativa conserve los parámetros necesarios para abrir la solicitud autorizada.
        /// </summary>
        [TestMethod]
        public void Validate_ConRutaRelativaYParametros_ConservaElDestino()
        {
            Assert.AreEqual(
                "/form/EmitirPoliza?proposal=23",
                CompletionDestination.Validate("/form/EmitirPoliza?proposal=23"));
        }

        /// <summary>
        /// Impide que datos de una invitación permitan navegar a otro sitio, conservar secretos o alterar la ruta del portal.
        /// </summary>
        [DataTestMethod]
        [DataRow("")]
        [DataRow("https://externo.example/form")]
        [DataRow("//externo.example/form")]
        [DataRow("/form/EmitirPoliza#invite=secreto")]
        [DataRow("/form\\EmitirPoliza")]
        public void Validate_ConDestinoNoRelativoSeguro_RechazaElValor(string completionPath)
        {
            Assert.ThrowsException<ArgumentException>(() => CompletionDestination.Validate(completionPath));
        }
    }
}
