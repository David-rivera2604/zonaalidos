using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Process.Contracts.General
{
    /// <summary>
    /// ProcessSpecSLA
    /// </summary>
    [Serializable(), DataContract()]
    public partial class ProcessSpecSLA
    {
        /// <summary>
        /// Identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Nombre del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public string Name { get; set; }
        /// <summary>
        /// Descripción del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }
        /// <summary>
        /// Estado (Activo/Inactivo)
        /// </summary>
        [DataMember(), JsonProperty()] public int Status { get; set; }
        /// <summary>
        /// Descripción para estado (activo/inactivo)
        /// </summary>
        [DataMember(), JsonProperty()] public string StatusDesc { get; set; }
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

