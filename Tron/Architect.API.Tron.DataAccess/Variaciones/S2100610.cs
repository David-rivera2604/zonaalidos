using Architect.DataFactory;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Variaciones
{
    public static class S2100610
    {
        public static bool Create(Architect.API.Tron.Contracts.Variaciones.s2100610 s2100610Instance)
        {
            bool result = false;
            int affected = 0;
            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                affected = Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_INSERT_S2100610")
                                    .AddParameter("P_FEC_TRATAMIENTO", DbType.Date, 0, s2100610Instance.Fec_Tratamiento)
                                    .AddParameter("P_TIP_MVTO_BATCH", DbType.String, 2, s2100610Instance.Tip_Mvto_Batch)
                                    .AddParameter("P_COD_CIA", DbType.Int32, 2, s2100610Instance.Cod_Cia)
                                    .AddParameter("P_NUM_POLIZA", DbType.String, 13, s2100610Instance.Num_Poliza)
                                    .AddParameter("P_NUM_RIESGO", DbType.Int32, 7, s2100610Instance.Num_Riesgo)
                                    .AddParameter("P_COD_ACCESORIO", DbType.Int32, 4, s2100610Instance.Cod_Accesorio)
                                    .AddParameter("P_MCA_SELECCION", DbType.String, 1, s2100610Instance.Mca_Seleccion)
                                    .AddParameter("P_TXT_ACCESORIO", DbType.String, 30, s2100610Instance.Txt_Accesorio)
                                    .AddParameter("P_IMP_ACCESORIO", DbType.Double, 12, s2100610Instance.Imp_Accesorio)
                                    .AddParameter("P_TASA_ACCESORIO", DbType.Double, 12, s2100610Instance.Tasa_Accesorio)
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
