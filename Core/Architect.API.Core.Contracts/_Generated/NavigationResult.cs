using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para Navegación disponible.
    /// </summary>
    public partial class NavigationResult
    {
        /// <summary>
        /// Navegación disponible.
        /// </summary>
        public Navigation Navigation { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

