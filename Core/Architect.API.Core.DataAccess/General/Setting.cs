using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.XPath;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    public partial class Setting
    {
        public static List<Contracts.General.Setting> Retrieve(int companyId, IDbConnection connection = null)
        {
            List<Contracts.General.Setting> result = new List<Contracts.General.Setting>();
            Database.Select(
@"SELECT COMPANYID, KEY, VALUE, LOCALSTORAGEENABLED, TOKENENABLED 
  FROM SETTINGS
 WHERE COMPANYID IN (0, :CompanyId)
   AND RECORDSTATUS = 1
 ORDER BY COMPANYID DESC")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            if (result.Find(r => r.Key == reader.StringValue("Key")) == null)
                            {
                                result.Add(new Contracts.General.Setting()
                                {
                                    Key = reader.StringValue("Key"),
                                    Value = reader.StringValue("Value"),
                                    LocalStorageEnabled = reader.IntegerValue("LocalStorageEnabled") == 1,
                                    TokenEnabled = reader.IntegerValue("TokenEnabled") == 1
                                });
                            }
                        }));
            return result;
        }
    }
}