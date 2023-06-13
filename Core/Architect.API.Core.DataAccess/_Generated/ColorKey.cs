using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    public sealed partial class ColorKey
    {

        public static List<Architect.API.Core.Contracts.Security.ColoresResponse> RetrieveAllColors(IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.Security.ColoresResponse> result = new List<Architect.API.Core.Contracts.Security.ColoresResponse>();
            Database.Select("SELECT LOOKUP.CODE , LOOKUP.LOOKUPID , LOOKUP.DESCRIPTION , TENANTSPERSONALIZATION.COMPANYID , TENANTSPERSONALIZATION.COLOR1TENANT , " +
                "TENANTSPERSONALIZATION.COLOR2TENANT , TENANTSPERSONALIZATION.LOGO  " +
                "FROM LOOKUP " +
                "JOIN TENANTSPERSONALIZATION ON LOOKUP.CODE = TENANTSPERSONALIZATION.COMPANYID " +
                "WHERE LOOKUP.LOOKUPID = 4")
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToColorData(reader));
                        }));
            return result;
        }

        public static Architect.API.Core.Contracts.Security.ColoresResponse DataReaderToColorData(System.Data.IDataReader reader, Architect.API.Core.Contracts.Security.ColoresResponse item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.Security.ColoresResponse();
            }
            item.CompanyID = reader.StringValue("COMPANYID");
            item.Tenant = reader.StringValue("DESCRIPTION");
            item.Color1 = reader.StringValue("Color1Tenant");
            item.Color2 = reader.StringValue("Color2Tenant");
            item.Logo = reader.StringValue("LOGO");
            return item;
        }

        public static int Update(Architect.API.Core.Contracts.Security.ColoresResponse ColorKeyItem, IDbConnection connection = null)
        {
            return Database.Update("Update TENANTSPERSONALIZATION " +
                                   "Set COLOR1TENANT = :Color1 , COLOR2TENANT = :Color2 , LOGO = :Logo " +
                                   "Where COMPANYID = :CompanyID")
                            .AddParameter("Color1", DbType.String, 25, ColorKeyItem.Color1)
                            .AddParameter("Color2", DbType.String, 25, ColorKeyItem.Color2)
                            .AddParameter("Logo", DbType.String, 3850, ColorKeyItem.Logo)
                            .AddParameter("CompanyID", DbType.String, 5, ColorKeyItem.CompanyID)
                            .Execute(connection, "Research");
        }

    }

}

