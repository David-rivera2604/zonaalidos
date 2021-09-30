using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Controla el flujo de procesamiento para Navegación permitidas por rol de usuario..
    /// </summary>
    public partial class RoleMemberNavigationResult
    {
        /// <summary>
        /// Navegación permitidas por rol de usuario..
        /// </summary>
        public RoleMemberNavigation RoleMemberNavigation { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

