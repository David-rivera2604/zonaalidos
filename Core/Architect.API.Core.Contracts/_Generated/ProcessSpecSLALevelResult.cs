using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para ProcessSpecSLALevel
    /// </summary>
    public partial class ProcessSpecSLALevelResult
    {
        /// <summary>
        /// ProcessSpecSLALevel
        /// </summary>
        public ProcessSpecSLALevel ProcessSpecSLALevel { get; set; }
        /// <summary>
        /// Lista de notificaciones resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

