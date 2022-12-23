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
        public static List<Contracts.PaymentSettings> RetrieveAll(int companyId, IDbConnection connection = null)
        {
            List<Contracts.PaymentSettings> result = new List<Contracts.PaymentSettings>();
            Database.Select("SELECT Id, UserId, Currency, ClientId, SecretKey " +
                              "FROM PaymentSettings " +
                              "WHERE CompanyId=:CompanyId")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Contracts.PaymentSettings()
                            {
                                Id = reader.IntegerValue("Id"),
                                UserId = reader.IntegerValue("UserId"),
                                Currency = reader.IntegerValue("Currency"),
                                ClientId = reader.StringValue("ClientId"),
                                SecretKey = reader.StringValue("SecretKey")
                            });
                        }));
            return result;
        }

    }
}
