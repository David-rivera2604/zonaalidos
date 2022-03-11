using Architect.DataFactory;
using System;
using System.Data;

namespace Architect.API.Tron.DataAccess.Batch
{
    /// <summary>
    ///  Riesgos del presupuesto
    /// </summary>
    public static class P2000031
    {

        public static bool UpdateEffectiveDate(DateTime fecha_efec, DateTime fecha_vec, string num_poliza, IDbConnection currentConnection)
        {
            var result = Database.Update("UPDATE p2000031 " +
                                           " SET fec_efec_riesgo = :fec_efec_riesgo, " +
                                               " fec_vcto_riesgo = :fec_vcto_riesgo " +
                                         " WHERE num_poliza = :num_poliza")
                    .AddParameter("fec_efec_riesgo", Architect.DataFactory.Enumerations.DbType.Date, 0, fecha_efec)
                    .AddParameter("fec_vcto_riesgo", Architect.DataFactory.Enumerations.DbType.Date, 0, fecha_vec)
                    .AddParameter("num_poliza", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                    .Execute(currentConnection, "Tron");
            return result >= 1;
        }

    }
}
