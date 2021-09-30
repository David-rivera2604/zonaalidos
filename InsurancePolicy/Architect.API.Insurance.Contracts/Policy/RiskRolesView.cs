using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Información de asegurados y/o beneficiarios de una póliza.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class RiskRolesView : RiskRoles
    {
        /// <summary>
        /// Nombre completo del asegurado.
        /// </summary>
        [DataMember(), JsonProperty()] public string FullName { get; set; }
        /// <summary>
        /// Indica si el asegura es un retirado.
        /// </summary>
        [DataMember(), JsonProperty()] public string IsRetired { get; set; }
        /// <summary>
        /// Dirección completa.
        /// </summary>
        [DataMember(), JsonProperty()] public string FullAddress { get; set; }
    }
}

