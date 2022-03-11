using System;
using System.Collections.Generic;

namespace Architect.API.Insurance.Contracts.ManualClaims
{
    public partial class ClaimResult
    {
        /// <summary>
        /// .
        /// </summary>
        public Claim Claim { get; set; }
        /// <summary>
        /// Lista de notificaciones resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

