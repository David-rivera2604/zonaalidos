using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Process.Contracts.General
{
    /// <summary>
    /// Resultado de operaciones sobre Reassignment.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class ReassignmentResult
    {
        [DataMember(), JsonProperty()] public Reassignment Reassignment { get; set; }
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.Error> Errors { get; set; }
    }
}
