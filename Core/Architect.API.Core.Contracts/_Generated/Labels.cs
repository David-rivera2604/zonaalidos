using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Etiquetas
    /// </summary>
    [Serializable(), DataContract()]
    public partial class Labels
    {
        /// <summary>
        /// Identificación única del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Tipo de entidad u objeto que genera el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int EntityType { get; set; }
        /// <summary>
        /// Descripción para tipo de entidad u objeto que genera el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public string EntityTypeDesc { get; set; }
        /// <summary>
        /// Identificador de la entidad u objeto que genera el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public Int64 EntityId { get; set; }
        /// <summary>
        /// Etiqueta vinculada.
        /// </summary>
        [DataMember(), JsonProperty()] public int LabelId { get; set; }
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

