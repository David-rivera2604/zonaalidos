using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    public partial class ProcessSpecFlow
    {

        /// <summary>
        /// Pasos o estados de un proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public List<ProcessSpecStep> ProcessSpecSteps { get; set; }

        /// <summary>
        /// Pasos o estados de un proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public List<ProcessSpecLink> ProcessSpecLinks { get; set; }
    }
}

