using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para Plantillas de comunicación.
    /// </summary>
    public partial class TemplateResult
    {
        /// <summary>
        /// Plantillas de comunicación.
        /// </summary>
        public Template Template { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

