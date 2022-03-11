using Architect.DataFactory;
using System;
using System.Data;

namespace Architect.API.Tron.DataAccess.Batch
{
    /// <summary>
    ///  Datos fijos del presupuesto
    /// </summary>
    public static class P2000030
    {

        public static bool Update(string tip_docum, string cod_docum, string num_poliza, IDbConnection currentConnection)
        {
            var result = Database.Update("UPDATE P2000030 " +
                                           " SET TIP_DOCUM = :TIP_DOCUM, " +
                                               " COD_DOCUM = :COD_DOCUM" +
                                         " WHERE NUM_POLIZA = :NUM_POLIZA")
                     .AddParameter("TIP_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 13, tip_docum)
                     .AddParameter("COD_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 13, cod_docum)
                     .AddParameter("NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                     .Execute(currentConnection, "Tron");
            return result >= 1;
        }
        public static bool UpdateEffectiveDate(DateTime fecha_efec, DateTime fecha_vec, string num_poliza, IDbConnection currentConnection)
        {
            var result = Database.Update("UPDATE P2000030 " +
                                           " SET fec_efec_poliza = :fec_efec_poliza, " +
                                               " fec_vcto_poliza = :fec_vcto_poliza, " +
                                               " fec_efec_spto = :fec_efec_spto, " +
                                               " fec_vcto_spto = :fec_vcto_spto" +
                                         " WHERE num_poliza = :num_poliza")
                    .AddParameter("fec_efec_poliza", Architect.DataFactory.Enumerations.DbType.Date, 0, fecha_efec)
                    .AddParameter("fec_vcto_poliza", Architect.DataFactory.Enumerations.DbType.Date, 0, fecha_vec)
                    .AddParameter("fec_efec_spto", Architect.DataFactory.Enumerations.DbType.Date, 0, fecha_efec)
                    .AddParameter("fec_vcto_spto", Architect.DataFactory.Enumerations.DbType.Date, 0, fecha_vec)
                    .AddParameter("num_poliza", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                    .Execute(currentConnection, "Tron");
            return result >= 1;
        }

    }
}