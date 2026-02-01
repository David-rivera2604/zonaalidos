using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Process.Contracts.General
{

    public partial class ProcessSpecStepRole
    {
        [DataMember(), JsonProperty()] public string RoleName { get; set; }

    }
}

