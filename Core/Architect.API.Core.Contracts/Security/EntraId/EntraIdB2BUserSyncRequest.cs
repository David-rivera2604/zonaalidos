namespace Architect.API.Core.Contracts.Security.EntraId
{
    public class EntraIdB2BUserSyncRequest
    {
        public EntraIdB2BLookupCriteria Lookup { get; set; }
        public EntraIdB2BPersonValuesDto Values { get; set; }
    }
}
