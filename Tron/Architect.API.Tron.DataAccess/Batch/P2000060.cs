using Architect.DataFactory;
using System;
using System.Data;

namespace Architect.API.Tron.DataAccess.Batch
{
    /// <summary>
    ///  Terceros del presupuesto
    /// </summary>
    public static class P2000060
    {

        public static bool Delete(string num_poliza, IDbConnection currentConnection)
        {
            var result = Database.Delete("DELETE P2000060 " +
                                         " WHERE NUM_POLIZA = :NUM_POLIZA " +
                                            "AND TIP_DOCUM= 'CNA' " +
                                            "AND COD_DOCUM='999999999' ")
                                 .AddParameter("NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                                 .Execute(currentConnection, "Tron");
            return result >= 1;
        }

        public static bool Exist(string tip_docum, string cod_docum, string num_presupuesto, string tip_benef, IDbConnection currentConnection)
        {
            return (int)Database.Select("SELECT COUNT(COD_DOCUM)" +
                                         " FROM P2000060" +
                                        " WHERE TIP_DOCUM=:TIP_DOCUM" +
                                          " AND COD_DOCUM=:COD_DOCUM" +
                                          " AND TIP_BENEF=:TIP_BENEF" +
                                          " AND NUM_POLIZA=:NUM_POLIZA" +
                                          " AND COD_CIA=1")                
                        .AddParameter("TIP_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 20, tip_docum)
                        .AddParameter("COD_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 20, cod_docum)
                        .AddParameter("TIP_BENEF", Architect.DataFactory.Enumerations.DbType.String, 100, tip_benef)
                        .AddParameter("NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 20, num_presupuesto)
                        .QueryScalar<Decimal>(currentConnection, "Tron") > 0;
        }
    }
}
