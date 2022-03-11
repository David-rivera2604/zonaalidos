using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Maestro de lista de valores disponibles.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class LookupMaster
    {
        /// <summary>
        /// Identificación de la lista.
        /// </summary>
        [DataMember(), JsonProperty()] public int LookupId { get; set; }
        /// <summary>
        /// Indica el tipo de la lista de valores.
        /// </summary>
        [DataMember(), JsonProperty()] public int Type { get; set; }
        /// <summary>
        /// Descripción para indica el tipo de la lista de valores.
        /// </summary>
        [DataMember(), JsonProperty()] public string TypeDesc { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }
        /// <summary>
        /// Clave que identificac la lista.
        /// </summary>
        [DataMember(), JsonProperty()] public string Key { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public bool Tenant { get; set; }
        /// <summary>
        /// Indica el tipo del comando 1 select, 2 procedure
        /// </summary>
        [DataMember(), JsonProperty()] public int StatementType { get; set; }
        /// <summary>
        /// Instrucción o datos para la generación de la lista
        /// </summary>
        [DataMember(), JsonProperty()] public string Statement { get; set; }
        [DataMember(), JsonProperty()] public string Fields { get; set; }
        [DataMember(), JsonProperty()] public bool IsCached { get; set; }
        /// <summary>
        /// Nombre de la cadena de conexión.
        /// </summary>
        [DataMember(), JsonProperty()] public string ConnectionName { get; set; }
        [DataMember(), JsonProperty()] public string IncludeByRole { get; set; }
        [DataMember(), JsonProperty()] public string ExcludeByRole { get; set; }
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

