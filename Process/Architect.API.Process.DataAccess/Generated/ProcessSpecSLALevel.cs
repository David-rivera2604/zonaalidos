using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Process.DataAccess.General
{
    /// <summary>
    /// ProcessSpecSLALevel
    /// </summary>
    public sealed partial class ProcessSpecSLALevel
    {
        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecSLALevel.
        /// </summary>
        public static List<Architect.API.Process.Contracts.General.ProcessSpecSLALevel> RetrieveAll(int companyId, int slaId, IDbConnection connection = null)
        {  
            return RetrieveAll(companyId,
                    " AND ProcessSpecSLALevel.SLAId=:SLAId",
                    Database.ParameterList().AddParameter("SLAId", DbType.Decimal, 9, slaId).Parameters, connection);

        }

        /// <summary>
        /// Elimina un registro en la tabla ProcessSpecSLALevel por medio de su clave primaria.
        /// </summary>
        public static int DeleteBySLAId(int slaId, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ProcessSpecSLALevel " +
                                    "WHERE SLAId=:SLAId AND CompanyId=:CompanyId")
                                .AddParameter("SLAId", DbType.Decimal, 9, slaId)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

    }

}

