using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    public partial class ProcessSpecStep
    {
        /// <summary>
        /// Tareas vinculadas a un paso o estado de un proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public List<ProcessSpecTask> ProcessSpecTasks { get; set; }

        [DataMember(), JsonProperty()] public List<ProcessSpecStepRole> ProcessSpecStepRoles { get; set; }

        /// <summary>
        /// Roles asociados a un usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public List<Utilities.Contracts.LookUpValue> Roles { get; set; }

    }
}

