using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Process.Contracts.General
{
    public partial class ProcessSpecSLA
    {
        /// <summary>
        /// ProcessSpecSLALevel.
        /// </summary>
        [DataMember(), JsonProperty()] public List<ProcessSpecSLALevel> Levels { get; set; }

    }
}
