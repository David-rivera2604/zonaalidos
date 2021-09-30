using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{

    public partial class ProcessSpecStepRole
    {
        [DataMember(), JsonProperty()] public string RoleName { get; set; }

    }
}

