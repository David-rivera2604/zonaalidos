using System;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Genera el identificador de negocio inmutable que representa una solicitud de póliza fuera de su clave técnica.
    /// </summary>
    public static class PolicyProposalIdentifier
    {
        /// <summary>
        /// Concatena literalmente el ramo y el identificador técnico NUMBER(9) de una solicitud nueva.
        /// </summary>
        /// <param name="ramo">Código positivo del ramo asociado a la solicitud.</param>
        /// <param name="policyProposalId">Identificador técnico positivo de PolicyProposal.</param>
        /// <returns>Identificador de negocio formado por RAMO e Id sin separador ni relleno.</returns>
        public static string Create(int ramo, int policyProposalId)
        {
            if (ramo <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ramo), "Debe indicar un ramo válido.");
            }

            if (policyProposalId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(policyProposalId), "Debe indicar una solicitud técnica válida.");
            }

            return ramo.ToString() + policyProposalId.ToString();
        }
    }
}
