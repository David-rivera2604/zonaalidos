using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para Tareas vinculadas a un paso o estado de un proceso.
    /// </summary>
    public partial class ProcessSpecTaskResult
    {
        /// <summary>
        /// Tareas vinculadas a un paso o estado de un proceso.
        /// </summary>
        public ProcessSpecTask ProcessSpecTask { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

