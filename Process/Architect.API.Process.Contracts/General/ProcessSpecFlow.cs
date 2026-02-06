using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Process.Contracts.General
{
    public partial class ProcessSpecFlow
    {

        /// <summary>
        /// Lista de roles asociados al proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public string RoleNames { get; set; }

        /// <summary>
        /// Pasos o estados de un proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public List<ProcessSpecStep> ProcessSpecSteps { get; set; }

        /// <summary>
        /// Pasos o estados de un proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public List<ProcessSpecLink> ProcessSpecLinks { get; set; }

        [DataMember(), JsonProperty()] public List<Utilities.Contracts.LookUpValue> Roles { get; set; }

        [DataMember(), JsonProperty()] public List<ProcessSpecSLALevel> SLALevels { get; set; }

    }
}

