using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Email sending request.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class SendEMail
    {
        /// <summary>
        /// The recipients of this email message. The recipients list separated by semicolon.
        /// </summary>
        [DataMember(), JsonProperty()] public string To { get; set; }
        /// <summary>
        /// The subject line for this email message.
        /// </summary>
        [DataMember(), JsonProperty()] public string Subject { get; set; }
        /// <summary>
        /// The message html body.
        /// </summary>
        [DataMember(), JsonProperty()] public string Body { get; set; }
       
    }
}

