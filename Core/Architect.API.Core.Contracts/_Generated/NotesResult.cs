using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para Notas.
    /// </summary>
    public partial class NotesResult
    {
        /// <summary>
        /// Notas.
        /// </summary>
        public Notes Notes { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

