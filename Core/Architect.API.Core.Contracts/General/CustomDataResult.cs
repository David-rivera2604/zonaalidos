using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// CustomData.
    /// </summary>
    public partial class CustomDataResult
    {
        /// <summary>
        /// CustomData
        /// </summary>
        public CustomData CustomData { get; set; }
        /// <summary>
        /// Lista de notificaciones resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

