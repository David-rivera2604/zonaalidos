using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Controla el flujo de procesamiento para Roles de seguridad.
    /// </summary>
    public partial class RoleMemberResult
    {
        /// <summary>
        /// Roles de seguridad.
        /// </summary>
        public RoleMember RoleMember { get; set; }
        /// <summary>
        /// Lista de notificaciones resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

