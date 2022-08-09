using Newtonsoft.Json;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    public partial class ProcessSpecTask
    {
        /// <summary>
        /// Identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public int FlowId { get; set; }
        /// <summary>
        /// Descripción para identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public string FlowIdDesc { get; set; }

        [DataMember(), JsonProperty()] public string ActionDesc { get; set; }
    }
}
