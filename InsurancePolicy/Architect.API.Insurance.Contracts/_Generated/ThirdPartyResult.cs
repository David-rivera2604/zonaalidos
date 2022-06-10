using System.Collections.Generic;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Controla el flujo de procesamiento para Información centralizada de terceros (personas y empresas). (OJO)
    /// </summary>
    public partial class ThirdPartyResult
    {
        /// <summary>
        /// Información centralizada de terceros (personas y empresas). (OJO)
        /// </summary>
        public ThirdParty ThirdParty { get; set; }
        /// <summary>
        /// Lista de notificaciones resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

