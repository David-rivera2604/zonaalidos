using Architect.API.Core.Security;
using System;
using System.Data;
using System.IO;

namespace Architect.API.Core.Business.Security
{
    public static class AuthenticationTrace
    {
        public static void Create(Architect.API.Core.Contracts.Security.AuthenticationTrace item)
        {
            //item.Id = DataAccess.Security.AuthenticationTrace.RetrieveLastKey() + 1;
            //item.EffectDate = DateTime.Now;
            //DataAccess.Security.AuthenticationTrace.Create(item);

            item.EffectDate = DateTime.Now;
            item.Id = DataAccess.Security.AuthenticationTrace.Create(item);
        }
    }
}
