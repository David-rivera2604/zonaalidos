using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Información para un notifición.
    /// </summary>
    [Serializable(), DataContract()]
    public class Error
    {
        /// <summary>
        /// Identificación del grupo a la fuente de la notificación.
        /// </summary>
        [DataMember(), JsonProperty()] public string Group { get; set; }
        /// <summary>
        /// Identificación asociada a la fuente de la notificación.
        /// </summary>
        [DataMember(), JsonProperty()] public string Key { get; set; }
        /// <summary>
        /// Mensaje a ser notificado.
        /// </summary>
        [DataMember(), JsonProperty()] public string Message { get; set; }
    }
}
