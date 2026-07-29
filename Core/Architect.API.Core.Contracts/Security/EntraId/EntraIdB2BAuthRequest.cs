using Newtonsoft.Json;

namespace Architect.API.Core.Contracts.Security.EntraId
{
    public class EntraIdB2BAuthRequest
    {
        [JsonProperty("authString")]
        public string AuthString { get; set; }
    }
}
