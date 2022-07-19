using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    public partial class ProcessSpecSLA
    {
        /// <summary>
        /// ProcessSpecSLALevel.
        /// </summary>
        [DataMember(), JsonProperty()] public List<ProcessSpecSLALevel> Levels { get; set; }

    }
}
