using System;
using RequestPoliza = Architect.API.Tron.Contracts.AltasBajas.Request.Poliza;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Construye el documento PDF de una solicitud de altas o bajas antes de remitirla a firma electrónica.
    /// </summary>
    internal static class PolicyProposalSignatureDocument
    {
        /// <summary>
        /// Genera el PDF a partir de los datos confirmados de la solicitud.
        /// </summary>
        /// <param name="poliza">Datos de la solicitud que se firmará.</param>
        /// <param name="tokenInfo">Contexto que permite acceder a la plantilla configurada.</param>
        /// <returns>Ruta interna del PDF generado.</returns>
        internal static string Generate(RequestPoliza poliza, Core.Contracts.Security.Token tokenInfo)
        {
            ValidateTemplate(poliza);
            if (tokenInfo == null)
            {
                throw new ArgumentNullException(nameof(tokenInfo));
            }

            return Core.Business.General.Report.Generate(
                tokenInfo.CompanyId,
                poliza.RAMO == 117
                    ? "117_seguro_vida_colectivo_solicitud_inclusion"
                    : "401_saldo_deudor",
                poliza).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Comprueba la disponibilidad de una plantilla adaptada antes de congelar la solicitud o completar su invitación.
        /// </summary>
        /// <param name="poliza">Solicitud cuyo ramo requiere un documento para firma.</param>
        internal static void ValidateTemplate(RequestPoliza poliza)
        {
            if (poliza == null)
            {
                throw new ArgumentNullException(nameof(poliza));
            }

            if (poliza.RAMO != 117 && poliza.RAMO != 401)
            {
                throw new NotSupportedException(
                    "No hay una plantilla de solicitud adaptada a Poliza para el ramo " + poliza.RAMO + ".");
            }
        }
    }
}
