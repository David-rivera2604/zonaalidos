using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Archivos adjuntos.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class Attachments
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
        /// Identificador de la entidad u objeto que genera el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public Int64 EntityId { get; set; }
        /// <summary>
        /// Indica el tipo de documento vinculado al adjunto.
        /// </summary>
        [DataMember(), JsonProperty()] public int DocumentType { get; set; }
        /// <summary>
        /// Descripción para indica el tipo de documento vinculado al adjunto.
        /// </summary>
        [DataMember(), JsonProperty()] public string DocumentTypeDesc { get; set; }
        /// <summary>
        /// Descripción del archivo.
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }
        /// <summary>
        /// Nombre original del archivo.
        /// </summary>
        [DataMember(), JsonProperty()] public string FileName { get; set; }
        /// <summary>
        /// Tamaño del archivo
        /// </summary>
        [DataMember(), JsonProperty()] public int FileSize { get; set; }
        /// <summary>
        /// Contenido del archivo.
        /// </summary>
        [DataMember(), JsonProperty()] public string FileContent { get; set; }
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

