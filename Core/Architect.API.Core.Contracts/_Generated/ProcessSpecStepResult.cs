using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para Pasos o estados de un proceso.
    /// </summary>
    public partial class ProcessSpecStepResult
    {
        /// <summary>
        /// Pasos o estados de un proceso.
        /// </summary>
        public ProcessSpecStep ProcessSpecStep { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

