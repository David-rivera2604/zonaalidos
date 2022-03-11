using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    public partial class CustomFields
    {
        public static List<Contracts.General.CustomFields> RetrieveByEntityType(int entityType, int companyId, IDbConnection connection = null)
        {
            List<Contracts.General.CustomFields> result = new List<Contracts.General.CustomFields>();
            Database.Select(@"SELECT Id, CustomFields.CompanyId, EntityType, Name, Caption, DataType, Precision, Scale, IsRequired, DisplayOrder, Specification, CustomFields.RecordStatus, CustomFields.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, CustomFields.UpdateDate 
                               FROM CustomFields LEFT JOIN UserMember um ON um.UserId = CustomFields.UpdateUserCode 
                              WHERE EntityType=:EntityType AND CustomFields.CompanyId=:CompanyId AND CustomFields.RecordStatus=1 ORDER BY DisplayOrder")
                        .AddParameter("EntityType", DbType.Decimal, 5,  entityType)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToCustomFields(reader));
                        }));
            return result; 
        }
    }
}