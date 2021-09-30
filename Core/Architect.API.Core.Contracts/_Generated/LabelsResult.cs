using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para Etiquetas
    /// </summary>
    public partial class LabelsResult
    {
        /// <summary>
        /// Etiquetas
        /// </summary>
        public Labels Labels { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

