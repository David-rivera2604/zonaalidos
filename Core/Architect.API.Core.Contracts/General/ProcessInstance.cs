using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Procesos ejecutados o en ejecución.
    /// </summary>
    public partial class ProcessInstance
    {
        /// <summary>
        /// Descripción para el paso.
        /// </summary>
        [DataMember(), JsonProperty()] public string StepName { get; set; }

        /// <summary>
        /// Descripción para la tarea paso.
        /// </summary>
        [DataMember(), JsonProperty()] public string TaskDesc { get; set; }

        [DataMember(), JsonProperty()] public string UserName { get; set; }

        [JsonIgnore]
        public ProcessSpecStep Step { get; set; }

        [JsonIgnore]
        public ProcessSpecTask Task { get; set; }

        [DataMember(), JsonProperty()] public int SLA { get; set; }
    }
}

