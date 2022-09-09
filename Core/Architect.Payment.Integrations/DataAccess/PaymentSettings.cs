using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.Payment.Integrations.DataAccess
{
    /// <summary>
    /// .
    /// </summary>
    public sealed partial class PaymentSettings
    {

        /// <summary>
        /// Recupera una lista de registros en la tabla PaymentSettings.
        /// </summary>
        public static List<Contracts.PaymentSettings> RetrieveAll(IDbConnection connection = null)
        {
            List<Contracts.PaymentSettings> result = new List<Contracts.PaymentSettings>();
            Database.Select("SELECT Id, UserName, Currency, ClientId, SecretKey " +
                              "FROM PaymentSettings")
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Contracts.PaymentSettings()
                            {
                                Id = reader.IntegerValue("Id"),
                                UserName = reader.StringValue("UserName"),
                                Currency = reader.IntegerValue("Currency"),
                                ClientId = reader.StringValue("ClientId"),
                                SecretKey = reader.StringValue("SecretKey")
                            });
                        }));
            return result;
        }

    }
}
