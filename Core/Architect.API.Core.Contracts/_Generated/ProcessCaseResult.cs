using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para ProcessCase
    /// </summary>
    public partial class ProcessCaseResult
    {
        /// <summary>
        /// ProcessCase
        /// </summary>
        public ProcessCase ProcessCase { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

