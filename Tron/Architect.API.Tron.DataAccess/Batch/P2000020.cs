using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Data;

namespace Architect.API.Tron.DataAccess.Batch
{
    /// <summary>
    ///  Datos variables del presupuesto
    /// </summary>
    public static class P2000020
    {

        internal static bool Delete(Architect.API.Tron.Contracts.Presupuesto.DatoVariable p2000020Instance, IDbConnection currentConnection)
        {
            bool result = false;
            int affected = Database.Delete("DELETE FROM P2000020" +
                                           " WHERE COD_CIA=:P_COD_CIA" +
                                           "  AND NUM_POLIZA=:P_NUM_POLIZA" +
                                           "  AND NUM_SPTO=:P_NUM_SPTO" +
                                           "  AND NUM_APLI=:P_NUM_APLI" +
                                           "  AND NUM_SPTO_APLI=:P_NUM_SPTO_APLI" +
                                           "  AND NUM_RIESGO=:P_NUM_RIESGO" +
                                           "  AND NUM_PERIODO=:P_NUM_PERIODO" +
                                           "  AND COD_CAMPO=:P_COD_CAMPO")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, p2000020Instance.num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.num_spto_apli)
                                           .AddParameter("P_NUM_RIESGO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.num_riesgo)
                                           .AddParameter("P_NUM_PERIODO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.num_periodo)
                                           .AddParameter("P_COD_CAMPO", Architect.DataFactory.Enumerations.DbType.String, 30, p2000020Instance.cod_campo)
                                           .Execute(currentConnection, "Tron");
            if (affected != 0)
            {
                result = true;
            }
            return result;
        }

        internal static bool Exist(Architect.API.Tron.Contracts.Presupuesto.DatoVariable p2000020Instance, IDbConnection currentConnection)
        {
            string cod_campo = Database.Select("SELECT COD_CAMPO" + "" +
                                            " FROM P2000020" +
                                           " WHERE COD_CIA=:P_COD_CIA" +
                                           "  AND NUM_POLIZA=:P_NUM_POLIZA" +
                                           "  AND NUM_SPTO=:P_NUM_SPTO" +
                                           "  AND NUM_APLI=:P_NUM_APLI" +
                                           "  AND NUM_SPTO_APLI=:P_NUM_SPTO_APLI" +
                                           "  AND NUM_RIESGO=:P_NUM_RIESGO" +
                                           "  AND NUM_PERIODO=:P_NUM_PERIODO" +
                                           "  AND COD_CAMPO=:P_COD_CAMPO")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, p2000020Instance.num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.num_spto_apli)
                                           .AddParameter("P_NUM_RIESGO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.num_riesgo)
                                           .AddParameter("P_NUM_PERIODO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000020Instance.num_periodo)
                                           .AddParameter("P_COD_CAMPO", Architect.DataFactory.Enumerations.DbType.String, 30, p2000020Instance.cod_campo)
                                          .QueryScalar<string>(currentConnection, "Tron");

            return cod_campo.IsNotEmpty();
        }

        public static bool Exist(string num_presupuesto, string cod_campo, IDbConnection currentConnection)
        {
            return (int)Database.Select("SELECT COUNT(COD_CAMPO)" +
                                             " FROM P2000020" +
                                            " WHERE COD_CIA=1" +
                                             "  AND NUM_POLIZA=:P_NUM_POLIZA" +
                                             "  AND COD_CAMPO=:P_COD_CAMPO")
               .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 20, num_presupuesto)
               .AddParameter("P_COD_CAMPO", Architect.DataFactory.Enumerations.DbType.String, 20, cod_campo)
                                          .QueryScalar<Decimal>(currentConnection, "Tron") >0;
        }

        public static bool Update(string num_presupuesto, string cod_campo, string val_campo, IDbConnection currentConnection)
        {
            bool result = false;
            int affected = Database.Procedure("em_k_Mapfre_Batch_Contract_mcr.P_UPDATE_P2000020")
                    .AddParameter("P_NUM_PRESUPUESTO", Architect.DataFactory.Enumerations.DbType.String, 20, num_presupuesto)
                    .AddParameter("P_COD_CAMPO", Architect.DataFactory.Enumerations.DbType.String, 20, cod_campo)
                    .AddParameter("P_VALOR_CAMPO", Architect.DataFactory.Enumerations.DbType.String, 100, val_campo)
                    .Execute(currentConnection, "Tron");
            if (affected != 0)
            {
                result = true;
            }
            return result;
        }

    }
}
