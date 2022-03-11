using System;
using System.Collections.Generic;

namespace Architect.API.Insurance.Contracts.ManualPolicies
{
    /// <summary>
    /// Controla el flujo de procesamiento para Coberturas.
    /// </summary>
    public partial class PolicyCoverageResult
    {
        /// <summary>
        /// Coberturas.
        /// </summary>
        public PolicyCoverage PolicyCoverage { get; set; }
        /// <summary>
        /// Lista de notificaciones resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

