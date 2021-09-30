using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Especificación de un proceso.
    /// </summary>
    public partial class ProcessSpecFlowResult
    {
        /// <summary>
        /// Pasos o estados de un proceso.
        /// </summary>
        public ProcessSpecFlow ProcessSpecFlow { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

