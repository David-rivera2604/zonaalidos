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

        public static int Update(Architect.API.Core.Contracts.Security.ColoresResponse ColorKeyItem, IDbConnection connection = null)
        {
            return Database.Update("Update LOOKUP " +
                                   "Set COLOR1TENANT = :Color1 , COLOR2TENANT = :Color2 , LOGO = :Logo " +
                                   "Where Description = :Tenant")
                            .AddParameter("Color1", DbType.String, 25, ColorKeyItem.Color1)
                            .AddParameter("Color2", DbType.String, 25, ColorKeyItem.Color2)
                            .AddParameter("Logo", DbType.String, 3850, ColorKeyItem.Logo)
                            .AddParameter("Tenant", DbType.String, 25, ColorKeyItem.Tenant)
                            .Execute(connection, "Research");
        }

    }

}

