using Architect.DataFactory;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Variaciones
{
    public static class S2000020
    {
        public static bool Create(Architect.API.Tron.Contracts.Variaciones.s2000020 a2000020Instance)
        {
            bool result = false;
            int affected = 0;
            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                affected = Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_INSERT_S2000020")
                                    .AddParameter("P_FEC_TRATAMIENTO", DbType.Date, 0, a2000020Instance.Fec_Tratamiento)
                                    .AddParameter("P_TIP_MVTO_BATCH", DbType.String, 2, a2000020Instance.Tip_Mvto_Batch)
                                    .AddParameter("P_COD_CIA", DbType.Int32, 2, a2000020Instance.Cod_Cia)
                                    .AddParameter("P_COD_RAMO", DbType.Int32, 3, a2000020Instance.Cod_Ramo)
                                    .AddParameter("P_NUM_POLIZA", DbType.String, 13, a2000020Instance.Num_Poliza)
                                    .AddParameter("P_NUM_RIESGO", DbType.Int32, 7, a2000020Instance.Num_Riesgo)
                                    .AddParameter("P_COD_MODALIDAD", DbType.Int32, 5, a2000020Instance.Cod_Modalidad)
                                    .AddParameter("P_COD_CAMPO", DbType.String, 30, a2000020Instance.Cod_Campo)
                                    .AddParameter("P_VAL_CAMPO_ACTUAL", DbType.String, 80, a2000020Instance.Val_Campo_Actual)
                                    .AddParameter("P_VAL_CAMPO_NUEVO", DbType.String, 80, a2000020Instance.Val_Campo_Nuevo)
                                    .AddParameter("P_NOM_PRG_SELECCION", DbType.String, 30, a2000020Instance.Nom_Prg_Seleccion)
                                  .Execute(currentConnection, "Tron");

                currentConnection.Close();
            }
            if (affected != 0)
            {
                result = true;
            }
            return result;
        }
    }
}
