using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    public partial class ReferenceField
    {
        [DataMember(), JsonProperty()] public string Name { get; set; }

        [DataMember(), JsonProperty()] public string Caption { get; set; }

    }
}

