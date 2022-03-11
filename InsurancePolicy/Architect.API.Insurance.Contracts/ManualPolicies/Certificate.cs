using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.ManualPolicies
{
    public partial class Certificate
    {

        /// <summary>
        /// Roles de un certificado.
        /// </summary>
        [DataMember(), JsonProperty()] public List<CertificateRole> Roles { get; set; }

    }
}

