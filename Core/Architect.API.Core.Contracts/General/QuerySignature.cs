using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Email sending request.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class QuerySignature
    {
        /// <summary>
        /// The recipients of this email message. The recipients list separated by semicolon.
        /// </summary>
        [DataMember(), JsonProperty()] public string Id { get; set; }


    }
}

