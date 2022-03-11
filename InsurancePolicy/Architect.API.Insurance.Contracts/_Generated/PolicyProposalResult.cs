using System;
using System.Collections.Generic;

namespace Architect.API.Insurance.Contracts.ManualPolicies
{
    /// <summary>
    /// Controla el flujo de procesamiento para Prespuestos disponibles.
    /// </summary>
    public partial class PolicyProposalResult
    {
        /// <summary>
        /// Prespuestos disponibles.
        /// </summary>
        public PolicyProposal PolicyProposal { get; set; }
        /// <summary>
        /// Lista de notificaciones resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

