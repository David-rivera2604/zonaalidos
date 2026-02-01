using System;
using System.Collections.Generic;

namespace Architect.API.Process.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para Especificación de un proceso.
    /// </summary>
    public partial class ProcessSpecFlowResult
    {
        /// <summary>
        /// Especificación de un proceso.
        /// </summary>
        public ProcessSpecFlow ProcessSpecFlow { get; set; }
        /// <summary>
        /// Lista de notificaciones resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }

        /// <summary>
        /// Lista de notificaciones resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Warnings { get; set; }
    }
}

