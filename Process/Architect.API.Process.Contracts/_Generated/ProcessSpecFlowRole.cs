using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Process.Contracts.General
{
    /// <summary>
    /// ProcessSpecFlowRole
    /// </summary>
    [Serializable(), DataContract()]
    public partial class ProcessSpecFlowRole
    {
        /// <summary>
        /// Identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación Rol.
        /// </summary>
        [DataMember(), JsonProperty()] public int RoleId { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Usuario que actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int UpdateUserCode { get; set; }
        /// <summary>
        /// Nombre del usuario que actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public string UpdateUserName { get; set; }
        /// <summary>
        /// Fecha que se actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime UpdateDate { get; set; }
    }
}

