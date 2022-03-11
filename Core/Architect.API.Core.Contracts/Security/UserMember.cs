using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.Security
{
    public partial class UserMember
    {
        /// <summary>
        /// Roles asociados a un usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public List<Utilities.Contracts.LookUpValue> Roles { get; set; }

        [DataMember(), JsonProperty()] public string RoleList { get; set; }

        [DataMember(), JsonProperty()] public object Extent { get; set; }

    }
}

