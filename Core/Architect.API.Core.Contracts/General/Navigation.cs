using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Navegación disponible.
    /// </summary>
    public partial class Navigation
    {
        /// <summary>
        /// Roles de acceso.
        /// </summary>
        [DataMember(), JsonProperty()] public List<Utilities.Contracts.LookUpValue> Roles { get; set; }
    }
}

