using System;
using System.Data;

namespace Architect.API.Core.Business.Security
{
    public static class AuthenticationTrace
    {
        public static void Create(Architect.API.Core.Contracts.Security.AuthenticationTrace item)
        {
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Research");

            IDbTransaction dbTransaction = currentConnection.BeginTransaction();

            item.Id = DataAccess.Security.AuthenticationTrace.RetrieveLastKey(currentConnection) + 1;
            item.EffectDate = DateTime.Now;
            DataAccess.Security.AuthenticationTrace.Create(item, currentConnection);

            dbTransaction.Commit();

            currentConnection.Close();

        }
    }
}
