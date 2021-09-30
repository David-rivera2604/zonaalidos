using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Campos personalizados
    /// </summary>
    [Serializable(), DataContract()]
    public partial class CustomFields
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
        /// Nombre del campo.
        /// </summary>
        [DataMember(), JsonProperty()] public string Name { get; set; }
        /// <summary>
        /// Etiqueta del campo.
        /// </summary>
        [DataMember(), JsonProperty()] public string Caption { get; set; }
        /// <summary>
        /// Tipo de datos.
        /// </summary>
        [DataMember(), JsonProperty()] public int DataType { get; set; }
        /// <summary>
        /// Descripción para tipo de datos.
        /// </summary>
        [DataMember(), JsonProperty()] public string DataTypeDesc { get; set; }
        /// <summary>
        /// Precisión o longitud.
        /// </summary>
        [DataMember(), JsonProperty()] public int Precision { get; set; }
        /// <summary>
        /// Precisión decimal para campos númericos.
        /// </summary>
        [DataMember(), JsonProperty()] public int Scale { get; set; }
        /// <summary>
        /// Indica que le campo es requerido.
        /// </summary>
        [DataMember(), JsonProperty()] public bool IsRequired { get; set; }
        /// <summary>
        /// Orden de visualización.
        /// </summary>
        [DataMember(), JsonProperty()] public int DisplayOrder { get; set; }
        /// <summary>
        /// Especificación.
        /// </summary>
        [DataMember(), JsonProperty()] public string Specification { get; set; }
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

