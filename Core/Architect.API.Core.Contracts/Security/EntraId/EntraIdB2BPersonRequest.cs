using Newtonsoft.Json;

namespace Architect.API.Core.Contracts.Security.EntraId
{
    public class EntraIdB2BPersonRequest
    {
        [JsonProperty("values")]
        public EntraIdB2BPersonValuesDto Values { get; set; }
    }
}
