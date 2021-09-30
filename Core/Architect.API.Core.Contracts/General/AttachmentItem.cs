using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Información de un archivo adjunto.
    /// </summary>
    [Serializable(), DataContract()]
    public class AttachmentItem
    {
        /// <summary>
        /// Nombre original del archivo.
        /// </summary>
        [DataMember(), JsonProperty()] public string FileName { get; set; }
        /// <summary>
        /// Extensión o tipo de archivo.
        /// </summary>
        [DataMember(), JsonProperty()] public string Type { get; set; }
        /// <summary>
        /// Contenido del archivo.
        /// </summary>
        [DataMember(), JsonProperty()] public byte[] Content { get; set; }
    }
}

