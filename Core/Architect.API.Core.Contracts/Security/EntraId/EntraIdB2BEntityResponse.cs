using Newtonsoft.Json;

namespace Architect.API.Core.Contracts.Security.EntraId
{
    public class EntraIdB2BEntityResponse
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("state")]
        public int State { get; set; }

        [JsonProperty("values")]
        public EntraIdB2BEntityValuesResponse Values { get; set; }
    }
}
