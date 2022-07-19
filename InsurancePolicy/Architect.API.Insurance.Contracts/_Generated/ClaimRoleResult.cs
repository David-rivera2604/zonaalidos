using System.Collections.Generic;

namespace Architect.API.Insurance.Contracts.ManualClaims
{
    /// <summary>
    /// Controla el flujo de procesamiento para Beneficiarios, Asociado.
    /// </summary>
    public partial class ClaimRoleResult
    {
        /// <summary>
        /// Beneficiarios, Asociado.
        /// </summary>
        public ClaimRole ClaimRole { get; set; }
        /// <summary>
        /// Lista de notificaciones resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

