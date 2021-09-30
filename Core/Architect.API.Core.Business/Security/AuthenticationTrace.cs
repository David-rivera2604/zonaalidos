using System;

namespace Architect.API.Core.Business.Security
{
    public static class AuthenticationTrace
    {
        public static void Create(Architect.API.Core.Contracts.Security.AuthenticationTrace item)
        {
            item.Id = DataAccess.Security.AuthenticationTrace.RetrieveLastKey() + 1;
            item.EffectDate = DateTime.Now;
            DataAccess.Security.AuthenticationTrace.Create(item);
        }
    }
}
