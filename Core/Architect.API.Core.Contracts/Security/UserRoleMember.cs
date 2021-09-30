using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.Security
{
    public partial class UserRoleMember
    {
        /// <summary>
        /// Nombre del rol.
        /// </summary>
        [DataMember(), JsonProperty()] public string RoleName { get; set; }

   }
}

