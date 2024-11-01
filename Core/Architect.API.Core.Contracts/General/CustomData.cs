using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Custom Data.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class CustomData
    {
        /// <summary>
        /// Identificación única del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Tipo de entidad u objeto que genera el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int EntityType { get; set; }
        /// <summary>
        /// Subtipo de entidad u objeto que genera el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int EntitySubType { get; set; }
        /// <summary>
        /// Identificador de la entidad u objeto que genera el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public Int64 EntityId { get; set; }

        /// <summary>
        /// Información en formato JSON.
        /// </summary>
        [DataMember(), JsonProperty()] public string Data { get; set; }


        /// <summary>
        /// Primera clave opcional de busqueda.
        /// </summary>
        [DataMember(), JsonProperty()] public string Key1 { get; set; }
        /// <summary>
        /// Segunda clave opcional de busqueda.
        /// </summary>
        [DataMember(), JsonProperty()] public string Key2 { get; set; }


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

