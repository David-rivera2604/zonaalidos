using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para ProcessSpecFlowRole
    /// </summary>
    public partial class ProcessSpecFlowRoleResult
    {
        /// <summary>
        /// ProcessSpecFlowRole
        /// </summary>
        public ProcessSpecFlowRole ProcessSpecFlowRole { get; set; }
        /// <summary>
        /// Lista de notificaciones resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

