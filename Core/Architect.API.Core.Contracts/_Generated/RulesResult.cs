using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para Reglas a ser ejecutar despues de un evento asociado a un entidad de la aplicaciión.
    /// </summary>
    public partial class RulesResult
    {
        /// <summary>
        /// Reglas a ser ejecutar despues de un evento asociado a un entidad de la aplicaciión.
        /// </summary>
        public Rules Rules { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

