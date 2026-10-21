using System;
using System.Collections.Generic;
using System.Net.Mail;
using RequestPoliza = Architect.API.Tron.Contracts.AltasBajas.Request.Poliza;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Valida los datos que debe completar el agente antes de delegar el completado de una solicitud al asegurado.
    /// </summary>
    public static class PolicyProposalInvitationRiskValidator
    {
        /// <summary>
        /// Verifica el correo, los datos comunes de póliza y el riesgo mínimo del ramo antes de crear una invitación.
        /// </summary>
        /// <param name="poliza">Solicitud de alta que el agente pretende enviar al asegurado.</param>
        public static void ValidateForInvitation(RequestPoliza poliza)
        {
            List<string> pendientes = new List<string>();
            Require(poliza != null && poliza.RAMO > 0, "ramo", pendientes);
            Require(poliza != null && poliza.NUM_CONTRATO > 0, "contrato", pendientes);
            Require(poliza != null && poliza.EFEC_SPTO != DateTime.MinValue, "inicio de vigencia", pendientes);
            Require(poliza != null && poliza.VCTO_SPTO > poliza.EFEC_SPTO, "fin de vigencia", pendientes);
            Require(HasValidEmail(poliza == null ? null : poliza.EMAIL_ASEG), "correo electrónico del asegurado", pendientes);

            if (poliza == null || poliza.RAMO <= 0)
            {
                ThrowIfPending(pendientes);
            }

            switch (poliza.RAMO)
            {
                case 117:
                    Require(poliza.IMP_SUM_ASEG_VC > 0, "sueldo del asegurado", pendientes);
                    Require(poliza.IMP_PRIMA_INFORMADA > 0 || (poliza.IMP_PRIMA_FACT ?? 0) > 0, "prima", pendientes);
                    break;

                case 194:
                    Require(poliza.ID_CRED_ESTUDIANTE > 0, "identificación del estudiante", pendientes);
                    Require(poliza.MCA_ASISTENCIA == "1" || poliza.MCA_ASISTENCIA == "2", "asistencia", pendientes);
                    Require(poliza.IMP_SUMA_MUERTE > 0, "suma asegurada por muerte", pendientes);
                    Require(!string.IsNullOrWhiteSpace(poliza.COD_PLAN_AP), "plan", pendientes);
                    break;

                case 401:
                    Require(!string.IsNullOrWhiteSpace(poliza.NUM_PRESTAMO), "número del préstamo", pendientes);
                    Require(poliza.INI_PRESTAMO != DateTime.MinValue, "inicio del préstamo", pendientes);
                    Require(poliza.VCTO_PRESTAMO > poliza.INI_PRESTAMO, "fin del préstamo", pendientes);
                    Require(poliza.IMP_SUMA_ASEG > 0, "suma asegurada", pendientes);
                    Require(poliza.IMP_PRIMA_INFORMADA > 0, "prima informada", pendientes);
                    break;

                default:
                    throw new InvalidOperationException("El ramo seleccionado no está habilitado para enviar una invitación al asegurado.");
            }

            ThrowIfPending(pendientes);
        }

        /// <summary>
        /// Impide que una sesión restringida modifique la información comercial o de riesgo que corresponde al agente.
        /// </summary>
        /// <param name="almacenada">Instantánea vigente antes de que el asegurado envíe cambios.</param>
        /// <param name="enviada">Datos recibidos desde la sesión restringida del asegurado.</param>
        public static void ValidateInsuredMayNotChangeAgentData(RequestPoliza almacenada, RequestPoliza enviada)
        {
            if (almacenada == null || enviada == null ||
                almacenada.RAMO != enviada.RAMO ||
                almacenada.NUM_CONTRATO != enviada.NUM_CONTRATO ||
                almacenada.NUM_CONTRATODesc != enviada.NUM_CONTRATODesc ||
                almacenada.MONEDA != enviada.MONEDA ||
                almacenada.NUM_POLIZA_GRUPO != enviada.NUM_POLIZA_GRUPO ||
                almacenada.EFEC_SPTO != enviada.EFEC_SPTO ||
                almacenada.VCTO_SPTO != enviada.VCTO_SPTO ||
                almacenada.NUM_PRESTAMO != enviada.NUM_PRESTAMO ||
                almacenada.INI_PRESTAMO != enviada.INI_PRESTAMO ||
                almacenada.VCTO_PRESTAMO != enviada.VCTO_PRESTAMO ||
                almacenada.IMP_SUMA_ASEG != enviada.IMP_SUMA_ASEG ||
                almacenada.IMP_SUM_ASEG_VC != enviada.IMP_SUM_ASEG_VC ||
                almacenada.IMP_PRIMA_INFORMADA != enviada.IMP_PRIMA_INFORMADA ||
                almacenada.IMP_PRIMA_FACT != enviada.IMP_PRIMA_FACT ||
                almacenada.ID_CRED_ESTUDIANTE != enviada.ID_CRED_ESTUDIANTE ||
                almacenada.MCA_ASISTENCIA != enviada.MCA_ASISTENCIA ||
                almacenada.IMP_SUMA_MUERTE != enviada.IMP_SUMA_MUERTE ||
                almacenada.COD_PLAN_AP != enviada.COD_PLAN_AP)
            {
                throw new InvalidOperationException("La invitación no permite modificar los datos exclusivos del agente.");
            }
        }

        /// <summary>
        /// Conserva los textos comerciales de la instantánea del agente al guardar datos del asegurado.
        /// </summary>
        /// <param name="almacenada">Instantánea vigente preparada por el agente.</param>
        /// <param name="enviada">Solicitud del asegurado que se persistirá.</param>
        public static void PreserveAgentDescriptions(RequestPoliza almacenada, RequestPoliza enviada)
        {
            if (almacenada == null) throw new ArgumentNullException(nameof(almacenada));
            if (enviada == null) throw new ArgumentNullException(nameof(enviada));

            enviada.RAMODesc = almacenada.RAMODesc;
            enviada.IMP_PRIMA_FACTDesc = almacenada.IMP_PRIMA_FACTDesc;
            enviada.MCA_ASISTENCIADesc = almacenada.MCA_ASISTENCIADesc;
            enviada.COD_PLAN_APDesc = almacenada.COD_PLAN_APDesc;
        }

        /// <summary>
        /// Agrega el nombre de un campo pendiente solo cuando su regla mínima no se cumple.
        /// </summary>
        private static void Require(bool condition, string field, List<string> pending)
        {
            if (!condition)
            {
                pending.Add(field);
            }
        }

        /// <summary>
        /// Determina si el correo declarado puede utilizarse como destinatario de la invitación.
        /// </summary>
        private static bool HasValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                MailAddress address = new MailAddress(email);
                return string.Equals(address.Address, email.Trim(), StringComparison.OrdinalIgnoreCase);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// Detiene el envío antes de cualquier persistencia cuando faltan datos mínimos.
        /// </summary>
        private static void ThrowIfPending(List<string> pending)
        {
            if (pending.Count > 0)
            {
                throw new InvalidOperationException(
                    "Debe completar los siguientes datos antes de enviar al asegurado: " + string.Join(", ", pending) + ".");
            }
        }
    }
}
