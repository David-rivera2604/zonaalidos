using System;
using Architect.API.Tron.Business.Backoffice;
using Architect.API.Tron.Contracts.AltasBajas.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Verifica que una invitación solo se habilite cuando el agente completó el riesgo mínimo del ramo.
    /// </summary>
    [TestClass]
    public class PolicyProposalInvitationRiskValidatorTests
    {
        /// <summary>
        /// Impide crear invitaciones para ramos que no declararon sus datos mínimos de riesgo.
        /// </summary>
        [TestMethod]
        public void ValidateForInvitation_CuandoElRamoNoEstaRegistrado_RechazaLaInvitacion()
        {
            Poliza poliza = CreateValidPolicy(117);
            poliza.RAMO = 999;

            InvalidOperationException error = Assert.ThrowsException<InvalidOperationException>(
                () => PolicyProposalInvitationRiskValidator.ValidateForInvitation(poliza));

            StringAssert.Contains(error.Message, "no está habilitado");
        }

        /// <summary>
        /// Impide crear invitaciones si el ramo 117 no tiene el sueldo del asegurado.
        /// </summary>
        [TestMethod]
        public void ValidateForInvitation_CuandoFaltaSueldoEnRamo117_RechazaLaInvitacion()
        {
            Poliza poliza = CreateValidPolicy(117);
            poliza.IMP_SUM_ASEG_VC = 0;

            Assert.ThrowsException<InvalidOperationException>(
                () => PolicyProposalInvitationRiskValidator.ValidateForInvitation(poliza));
        }

        /// <summary>
        /// Impide crear invitaciones si el ramo 194 no tiene un plan seleccionado.
        /// </summary>
        [TestMethod]
        public void ValidateForInvitation_CuandoFaltaPlanEnRamo194_RechazaLaInvitacion()
        {
            Poliza poliza = CreateValidPolicy(194);
            poliza.COD_PLAN_AP = string.Empty;

            Assert.ThrowsException<InvalidOperationException>(
                () => PolicyProposalInvitationRiskValidator.ValidateForInvitation(poliza));
        }

        /// <summary>
        /// Impide crear invitaciones si el ramo 401 no tiene el número de préstamo.
        /// </summary>
        [TestMethod]
        public void ValidateForInvitation_CuandoFaltaPrestamoEnRamo401_RechazaLaInvitacion()
        {
            Poliza poliza = CreateValidPolicy(401);
            poliza.NUM_PRESTAMO = string.Empty;

            Assert.ThrowsException<InvalidOperationException>(
                () => PolicyProposalInvitationRiskValidator.ValidateForInvitation(poliza));
        }

        /// <summary>
        /// Acepta los tres ramos visibles cuando cuentan con su mínimo riesgo y correo del asegurado.
        /// </summary>
        [TestMethod]
        public void ValidateForInvitation_CuandoCadaRamoTieneDatosMinimos_AceptaLaInvitacion()
        {
            foreach (int ramo in new[] { 117, 194, 401 })
            {
                PolicyProposalInvitationRiskValidator.ValidateForInvitation(CreateValidPolicy(ramo));
            }
        }

        /// <summary>
        /// Impide que el asegurado cambie una prima antes de guardar o confirmar su información personal.
        /// </summary>
        [TestMethod]
        public void ValidateInsuredMayNotChangeAgentData_CuandoCambiaLaPrima_RechazaLaOperacion()
        {
            Poliza almacenada = CreateValidPolicy(117);
            Poliza enviada = CreateValidPolicy(117);
            enviada.IMP_PRIMA_INFORMADA = almacenada.IMP_PRIMA_INFORMADA + 1;

            InvalidOperationException error = Assert.ThrowsException<InvalidOperationException>(
                () => PolicyProposalInvitationRiskValidator.ValidateInsuredMayNotChangeAgentData(almacenada, enviada));

            StringAssert.Contains(error.Message, "exclusivos del agente");
        }

        /// <summary>
        /// Conserva la descripción del contrato para mostrarla sin consultar catálogos asociados al agente.
        /// </summary>
        [TestMethod]
        public void Poliza_ConservaDescripcionDeContratoParaSesionDeAsegurado()
        {
            Poliza poliza = new Poliza
            {
                NUM_CONTRATO = 99340,
                NUM_CONTRATODesc = "Contrato colectivo de vida"
            };

            Assert.AreEqual("Contrato colectivo de vida", poliza.NUM_CONTRATODesc);
        }

        /// <summary>
        /// Conserva la moneda del contrato para visualizarla sin acceder al catálogo filtrado por agente.
        /// </summary>
        [TestMethod]
        public void Poliza_ConservaMonedaParaSesionDeAsegurado()
        {
            Poliza poliza = new Poliza
            {
                MONEDA = "COLONES"
            };

            Assert.AreEqual("COLONES", poliza.MONEDA);
        }

        /// <summary>
        /// Construye una solicitud válida y exclusiva para probar las reglas de invitación.
        /// </summary>
        private static Poliza CreateValidPolicy(int ramo)
        {
            return new Poliza
            {
                RAMO = ramo,
                NUM_CONTRATO = 8,
                EFEC_SPTO = new DateTime(2026, 10, 19),
                VCTO_SPTO = new DateTime(2027, 10, 19),
                EMAIL_ASEG = "asegurado@example.test",
                IMP_SUM_ASEG_VC = 1000,
                IMP_PRIMA_INFORMADA = 100,
                IMP_PRIMA_FACT = 100,
                ID_CRED_ESTUDIANTE = 20,
                MCA_ASISTENCIA = "1",
                IMP_SUMA_MUERTE = 2000,
                COD_PLAN_AP = "AP-01",
                NUM_PRESTAMO = "PRESTAMO-01",
                INI_PRESTAMO = new DateTime(2026, 10, 19),
                VCTO_PRESTAMO = new DateTime(2027, 10, 19),
                IMP_SUMA_ASEG = 3000
            };
        }
    }
}
