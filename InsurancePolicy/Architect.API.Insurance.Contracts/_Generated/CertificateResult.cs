using System.Collections.Generic;

namespace Architect.API.Insurance.Contracts.ManualPolicies
{
    public partial class CertificateResult
    {
        /// <summary>
        /// .
        /// </summary>
        public Certificate Certificate { get; set; }
        /// <summary>
        /// Lista de notificaciones resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

