using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Architect.DataFactory
{
    public class Session : IDisposable

    {
        IDbTransaction _transaction;
        IDbConnection _connection;

        public IDbConnection dbConnection
        {
            get { return _connection; }
        }

        public Session(string connectionStringName)
        {
            _connection = Database.OpenConnection(connectionStringName);
            _transaction = dbConnection.BeginTransaction();
        }

        public void CommitAndClose()
        {
            _transaction.Commit();
            _connection.Close();
        }

        public void RollbackAndClose()
        {
            _transaction.Rollback();
            _connection.Close();
        }

        public void Dispose()
        {
            _transaction = null;
            _connection = null;
        }
    }
}
