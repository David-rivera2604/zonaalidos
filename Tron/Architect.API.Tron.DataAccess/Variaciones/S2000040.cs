using Architect.DataFactory;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Variaciones
{
    public static class S2000040
    {
        public static bool Create(Architect.API.Tron.Contracts.Variaciones.s2000040 s2000040Instance)
        {
            bool result = false;
            int affected = 0;
            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                affected = Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_INSERT_S2000040")
                                    .AddParameter("P_FEC_TRATAMIENTO", DbType.Date, 0, s2000040Instance.Fec_Tratamiento)
                                    .AddParameter("P_TIP_MVTO_BATCH", DbType.String, 2, s2000040Instance.Tip_Mvto_Batch)
                                    .AddParameter("P_COD_CIA", DbType.Int32, 2, s2000040Instance.Cod_Cia)
                                    .AddParameter("P_NUM_POLIZA", DbType.String, 13, s2000040Instance.Num_Poliza)
                                    .AddParameter("P_NUM_RIESGO", DbType.Int32, 7, s2000040Instance.Num_Riesgo)
                                    .AddParameter("P_COD_COB", DbType.Int32, 4, s2000040Instance.Cod_Cob)
                                    .AddParameter("P_MCA_SELECCION", DbType.String, 1, s2000040Instance.Mca_Seleccion)
                                    .AddParameter("P_COD_LIMITE", DbType.Int32, 3, s2000040Instance.Cod_Limite)
                                    .AddParameter("P_SUMA_ASEG", DbType.Double, 12, s2000040Instance.Suma_Aseg)
                                    .AddParameter("P_COD_FRANQUICIA", DbType.Int32, 3, s2000040Instance.Cod_Franquicia)
                                    .AddParameter("P_TASA_COB", DbType.Double, 12, s2000040Instance.Tasa_Cob)
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
