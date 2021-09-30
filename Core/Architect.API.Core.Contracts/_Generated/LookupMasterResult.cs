using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para Maestro de lista de valores disponibles.
    /// </summary>
    public partial class LookupMasterResult
    {
        /// <summary>
        /// Maestro de lista de valores disponibles.
        /// </summary>
        public LookupMaster LookupMaster { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

