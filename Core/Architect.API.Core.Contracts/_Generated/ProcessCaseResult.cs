using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para Casos asociados a los procesos.
    /// </summary>
    public partial class ProcessCaseResult
    {
        /// <summary>
        /// Casos asociados a los procesos.
        /// </summary>
        public ProcessCase ProcessCase { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

