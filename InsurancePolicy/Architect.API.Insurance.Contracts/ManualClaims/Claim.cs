using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.ManualClaims
{
    public partial class Claim
    {
        /// <summary>
        /// Roles de un siniestro.
        /// </summary>
        [DataMember(), JsonProperty()] public List<ClaimRole> Roles { get; set; }

        /// <summary>
        /// Documento requeridos de un siniestro.
        /// </summary>
        [DataMember(), JsonProperty()] public List<ClaimDocumentRequest> DocumentRequests { get; set; }
    }
}

