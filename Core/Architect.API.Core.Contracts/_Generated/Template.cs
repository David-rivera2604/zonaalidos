using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Plantillas de comunicación.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class Template
    {
        /// <summary>
        /// Identificación única de la plantilla.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Clave de acceso a la plantilla.
        /// </summary>
        [DataMember(), JsonProperty()] public string Key { get; set; }
        /// <summary>
        /// Describe la plantilla.
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }
        /// <summary>
        /// Aquien va dirigido el correo.
        /// </summary>
        [DataMember(), JsonProperty()] public string EmailTo { get; set; }
        /// <summary>
        /// Asunto del correo.
        /// </summary>
        [DataMember(), JsonProperty()] public string Subject { get; set; }
        /// <summary>
        /// Texto del correo.
        /// </summary>
        [DataMember(), JsonProperty()] public string Body { get; set; }
        [DataMember(), JsonProperty()] public int MasterTemplateId { get; set; }
        [DataMember(), JsonProperty()] public string MasterTemplateIdDesc { get; set; }
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

