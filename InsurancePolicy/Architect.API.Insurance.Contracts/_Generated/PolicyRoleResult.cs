using System.Collections.Generic;

namespace Architect.API.Insurance.Contracts.ManualPolicies
{
    /// <summary>
    /// Controla el flujo de procesamiento para Rol del tercero en la póliza.
    /// </summary>
    public partial class PolicyRoleResult
    {
        /// <summary>
        /// Rol del tercero en la póliza.
        /// </summary>
        public PolicyRole PolicyRole { get; set; }
        /// <summary>
        /// Lista de notificaciones resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

