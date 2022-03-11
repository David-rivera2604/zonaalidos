using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.ManualPolicies
{
    /// <summary>
    /// Póliza
    /// </summary>
    public partial class Policy
    {
        /// <summary>
        /// Roles de una póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public List<PolicyRole> Roles { get; set; }

        /// <summary>
        /// Coberturas de una póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public List<PolicyCoverage> Coverages { get; set; }

    }
}

