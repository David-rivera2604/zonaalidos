using Newtonsoft.Json;

namespace Architect.API.Core.Contracts.Security.EntraId
{
    public class EntraIdB2BDeactivateRequest
    {
        [JsonProperty("Values")]
        public EntraIdB2BDeactivateValues Values { get; set; }
    }
}
