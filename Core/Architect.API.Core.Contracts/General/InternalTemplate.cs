using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Plantillas de comunicación.
    /// </summary>
    public class InternalTemplate
    {
        /// <summary>
        /// Asunto del correo.
        /// </summary>
        [DataMember(), JsonProperty()] public string Subject { get; set; }
        /// <summary>
        /// Texto del correo.
        /// </summary>
        [DataMember(), JsonProperty()] public string Body { get; set; }
        /// <summary>
        /// A quien va difigido el correo.
        /// </summary>
        [DataMember(), JsonProperty()] public string EmailTo { get; set; }

        [DataMember(), JsonProperty()] public int MasterTemplateId { get; set; }

        [DataMember(), JsonProperty()] public bool Partial { get; set; }
    }
}
