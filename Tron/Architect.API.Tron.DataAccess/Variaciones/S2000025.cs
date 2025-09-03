using Architect.DataFactory;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Variaciones
{
    public static class S2000025
    {
        public static bool Create(Architect.API.Tron.Contracts.Variaciones.s2000025 a2000025Instance)
        {
            bool result = false;
            int affected = 0;
            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                affected = Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_INSERT_S2000025")
                                    .AddParameter("P_FEC_TRATAMIENTO", DbType.Date, 0, a2000025Instance.Fec_Tratamiento)
                                    .AddParameter("P_TIP_MVTO_BATCH", DbType.String, 2, a2000025Instance.Tip_Mvto_Batch)
                                    .AddParameter("P_COD_CIA", DbType.Int32, 2, a2000025Instance.Cod_Cia)
                                    .AddParameter("P_NUM_POLIZA", DbType.String, 13, a2000025Instance.Num_Poliza)
                                    .AddParameter("P_NUM_RIESGO", DbType.Int32, 7, a2000025Instance.Num_Riesgo)
                                    .AddParameter("p_cod_lista", DbType.Int32, 3, a2000025Instance.Cod_Lista)
                                    .AddParameter("p_num_ocurrencia", DbType.Int32, 5, a2000025Instance.Num_Ocurrencia)
                                    .AddParameter("p_cod_campo", DbType.String, 30, a2000025Instance.Cod_Campo)
                                    .AddParameter("p_val_campo", DbType.String, 80, a2000025Instance.Val_Campo)
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
