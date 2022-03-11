using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para ProcessSpecStepRole
    /// </summary>
    public partial class ProcessSpecStepRoleResult
    {
        /// <summary>
        /// ProcessSpecStepRole
        /// </summary>
        public ProcessSpecStepRole ProcessSpecStepRole { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

