using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Archivos adjuntos.
    /// </summary>
    [Serializable(), DataContract()]
    public class AttachmentView
    {
        /// <summary>
        /// Identificación única del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
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
        /// Nombre del archivo en el servidor.
        /// </summary>
        [DataMember(), JsonProperty()] public string Stored { get; set; }
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

