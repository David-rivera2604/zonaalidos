using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Lisat de empresas configuradas
    /// </summary>
    public class Tenant
    {
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Nombre de la compañia
        /// </summary>
        [DataMember(), JsonProperty()] public string Name { get; set; }
    }
}
