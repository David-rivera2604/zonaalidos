using System;
using System.Collections.Generic;

namespace Architect.API.Process.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para ProcessSpecSLA
    /// </summary>
    public partial class ProcessSpecSLAResult
    {
        /// <summary>
        /// ProcessSpecSLA
        /// </summary>
        public ProcessSpecSLA ProcessSpecSLA { get; set; }
        /// <summary>
        /// Lista de notificaciones resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

