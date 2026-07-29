using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.Security.EntraId
{
    public class EntraIdB2BEntityValuesResponse
    {
        [JsonProperty("UID_Person")]
        public string UidPerson { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> ExtraValues { get; set; }
    }
}
