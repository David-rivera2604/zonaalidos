using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para Lista de tareas o chequeo.
    /// </summary>
    public partial class TasksResult
    {
        /// <summary>
        /// Lista de tareas o chequeo.
        /// </summary>
        public Tasks Tasks { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

