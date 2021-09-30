using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Lista de valores disponibles.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class Lookup
    {
        /// <summary>
        /// LookupId
        /// </summary>
        [DataMember(), JsonProperty()] public int LookupId { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Código lenguaje.
        /// </summary>
        [DataMember(), JsonProperty()] public int Language { get; set; }
        /// <summary>
        /// Descripción para código lenguaje.
        /// </summary>
        [DataMember(), JsonProperty()] public string LanguageDesc { get; set; }
        /// <summary>
        /// Identificación del registro padre para lista con dependencias.
        /// </summary>
        [DataMember(), JsonProperty()] public int ParentLookupId { get; set; }
        /// <summary>
        /// Identificación del registro de según nivel para lista con dependencias.
        /// </summary>
        [DataMember(), JsonProperty()] public int SubParentLookupId { get; set; }
        /// <summary>
        /// Código.
        /// </summary>
        [DataMember(), JsonProperty()] public int Code { get; set; }
        /// <summary>
        /// Descripción.
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }
        /// <summary>
        /// Orden de despliegue.
        /// </summary>
        [DataMember(), JsonProperty()] public int QueryOrder { get; set; }
        /// <summary>
        /// Código usado para homologación.
        /// </summary>
        [DataMember(), JsonProperty()] public string HomologousCode { get; set; }
        /// <summary>
        /// Primer complemento numérico.
        /// </summary>
        [DataMember(), JsonProperty()] public double ExtendNumberValue1 { get; set; }
        /// <summary>
        /// Segundo complemento numérico.
        /// </summary>
        [DataMember(), JsonProperty()] public double ExtendNumberValue2 { get; set; }
        /// <summary>
        /// Primer complemento alpha numérico.
        /// </summary>
        [DataMember(), JsonProperty()] public string ExtendStringValue1 { get; set; }
        /// <summary>
        /// Segundo complemento alpha numérico.
        /// </summary>
        [DataMember(), JsonProperty()] public string ExtendStringValue2 { get; set; }
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

