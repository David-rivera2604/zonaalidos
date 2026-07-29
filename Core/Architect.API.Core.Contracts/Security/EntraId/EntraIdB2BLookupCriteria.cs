using Newtonsoft.Json;

namespace Architect.API.Core.Contracts.Security.EntraId
{
    public class EntraIdB2BLookupCriteria
    {
        public string UidPerson { get; set; }
        public string CentralAccount { get; set; }
        public string PersonnelNumber { get; set; }
        public string Nif { get; set; }

        [JsonProperty("WHERE")]
        public string Where { get; set; }
    }
}
