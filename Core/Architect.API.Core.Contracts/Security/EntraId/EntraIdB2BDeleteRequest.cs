using System;

namespace Architect.API.Core.Contracts.Security.EntraId
{
    public class EntraIdB2BDeleteRequest
    {
        public string UidPerson { get; set; }
        public EntraIdB2BLookupCriteria Lookup { get; set; }
        public DateTime? DeactivationStart { get; set; }
    }
}
