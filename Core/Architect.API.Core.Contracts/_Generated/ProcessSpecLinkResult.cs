using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    public partial class ProcessSpecLinkResult
    {
        /// <summary>
        /// .
        /// </summary>
        public ProcessSpecLink ProcessSpecLink { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

