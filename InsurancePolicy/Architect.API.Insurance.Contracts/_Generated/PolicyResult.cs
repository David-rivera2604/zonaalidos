using System.Collections.Generic;

namespace Architect.API.Insurance.Contracts.ManualPolicies
{
    /// <summary>
    /// Controla el flujo de procesamiento para Póliza
    /// </summary>
    public partial class PolicyResult
    {
        /// <summary>
        /// Póliza
        /// </summary>
        public Policy Policy { get; set; }
        /// <summary>
        /// Lista de notificaciones resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

