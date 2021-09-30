using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para Lista de valores disponibles.
    /// </summary>
    public partial class LookupResult
    {
        /// <summary>
        /// Lista de valores disponibles.
        /// </summary>
        public Lookup Lookup { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

