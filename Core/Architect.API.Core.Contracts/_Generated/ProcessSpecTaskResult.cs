using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Tareas vinculadas a un paso o estado de un proceso.
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

