using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Roles de seguridad.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class RoleMember
    {
        /// <summary>
        /// Identificación Rol.
        /// </summary>
        [DataMember(), JsonProperty()] public int RoleId { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Nombre del rol.
        /// </summary>
        [DataMember(), JsonProperty()] public string RoleName { get; set; }
        /// <summary>
        /// Descripción del rol.
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }
        /// <summary>
        /// Nivel de seguridad.
        /// </summary>
        [DataMember(), JsonProperty()] public int SecurityLevel { get; set; }
        /// <summary>
        /// Estado general del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int RecordStatus { get; set; }
        /// <summary>
        /// Descripción para estado general del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public string RecordStatusDesc { get; set; }
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

