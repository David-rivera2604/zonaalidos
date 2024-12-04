using Architect.DataFactory;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Variaciones
{
    public static class S2000030
    {
        public static bool Create(Architect.API.Tron.Contracts.Variaciones.s2000030 s2000030Instance)
        {
            bool result = false;
            int affected = 0;
            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                affected = Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_INSERT_S2000030")
                                    .AddParameter("P_FEC_TRATAMIENTO", DbType.Date, 0, s2000030Instance.Fec_Tratamiento)
                                    .AddParameter("P_TIP_MVTO_BATCH", DbType.String, 2, s2000030Instance.Tip_Mvto_Batch)
                                    .AddParameter("P_COD_CIA", DbType.Int32, 2, s2000030Instance.Cod_Cia)
                                    .AddParameter("P_COD_RAMO", DbType.Int32, 3, s2000030Instance.Cod_Ramo)
                                    .AddParameter("P_NUM_POLIZA", DbType.String, 13, s2000030Instance.Num_Poliza)
                                    .AddParameter("P_FEC_EFEC_SPTO", DbType.Date, 0, s2000030Instance.Fec_Efec_Spto)
                                    .AddParameter("P_FEC_VCTO_SPTO", DbType.Date, 0, s2000030Instance.Fec_Vcto_Spto)
                                    .AddParameter("P_NOM_PRG_SELECCION", DbType.String, 30, s2000030Instance.Nom_Prg_Seleccion)
                                    .AddParameter("P_NUM_POLIZA_CLIENTE", DbType.String, 13, s2000030Instance.Num_Poliza_Cliente)
                                    .AddParameter("P_NUM_POLIZA_GRUPO", DbType.String, 13, s2000030Instance.Num_Poliza_Grupo)
                                    .AddParameter("P_NUM_CONTRATO", DbType.Int32, 5, s2000030Instance.Num_Contrato)
                                    .AddParameter("P_TIP_COASEGURO", DbType.Int32, 1, s2000030Instance.Tip_Coaseguro)
                                    .AddParameter("P_COD_CUADRO_COA", DbType.String, 10, s2000030Instance.Cod_Cuadro_Coa)
                                    .AddParameter("P_TIP_DOCUM", DbType.String, 3, s2000030Instance.Tip_Docum)
                                    .AddParameter("P_COD_DOCUM", DbType.String, 20, s2000030Instance.Cod_Docum)
                                    .AddParameter("P_COD_DST_AGT", DbType.String, 5, s2000030Instance.Cod_Dst_Agt)
                                    .AddParameter("P_COD_AGT", DbType.Int32, 6, s2000030Instance.Cod_Agt)
                                    .AddParameter("P_COD_CUADRO_COM", DbType.Int32, 3, s2000030Instance.Cod_Cuadro_Com)
                                    .AddParameter("P_PCT_AGT", DbType.Double, 10, s2000030Instance.Pct_Agt)
                                    .AddParameter("P_COD_AGT2", DbType.Int32, 6, s2000030Instance.Cod_Agt2)
                                    .AddParameter("P_PCT_AGT2", DbType.Double, 10, s2000030Instance.Pct_Agt2)
                                    .AddParameter("P_COD_AGT3", DbType.Int32, 6, s2000030Instance.Cod_Agt3)
                                    .AddParameter("P_PCT_AGT3", DbType.Double, 10, s2000030Instance.Pct_Agt3)
                                    .AddParameter("P_COD_AGT4", DbType.Int32, 6, s2000030Instance.Cod_Agt4)
                                    .AddParameter("P_PCT_AGT4", DbType.Double, 10, s2000030Instance.Pct_Agt4)
                                    .AddParameter("P_COD_NIVEL3", DbType.Int32, 4, s2000030Instance.Cod_Nivel3)
                                    .AddParameter("P_COD_FRACC_PAGO", DbType.Int32, 5, s2000030Instance.Cod_Fracc_Pago)
                                    .AddParameter("P_TIP_GESTOR", DbType.String, 2, s2000030Instance.Tip_Gestor)
                                    .AddParameter("P_COD_GESTOR", DbType.String, 13, s2000030Instance.Cod_Gestor)
                                    .AddParameter("P_IMP_CUOTA_INICIAL", DbType.String, 12, s2000030Instance.Imp_Cuota_Inicial)
                                    .AddParameter("P_NUM_POLIZA_CLIENTE_N", DbType.String, 13, s2000030Instance.Num_Poliza_Cliente_N)
                                    .AddParameter("P_NUM_POLIZA_GRUPO_N", DbType.String, 13, s2000030Instance.Num_Poliza_Grupo_N)
                                    .AddParameter("P_NUM_CONTRATO_N", DbType.Int32, 5, s2000030Instance.Num_Contrato_N)
                                    .AddParameter("P_TIP_COASEGURO_N", DbType.Int32, 1, s2000030Instance.Tip_Coaseguro_N)
                                    .AddParameter("P_TIP_DOCUM_N", DbType.String, 3, s2000030Instance.Tip_Docum_N)
                                    .AddParameter("P_COD_DOCUM_N", DbType.String, 20, s2000030Instance.Cod_Docum_N)
                                    .AddParameter("P_COD_AGT_N", DbType.Int32, 6, s2000030Instance.Cod_Agt_N)
                                    .AddParameter("P_COD_CUADRO_COM_N", DbType.Int32, 3, s2000030Instance.Cod_Cuadro_Com_N)
                                    .AddParameter("P_PCT_AGT_N", DbType.Double, 10, s2000030Instance.Pct_Agt_N)
                                    .AddParameter("P_COD_AGT2_N", DbType.Int32, 6, s2000030Instance.Cod_Agt2_N)
                                    .AddParameter("P_PCT_AGT2_N", DbType.Double, 10, s2000030Instance.Pct_Agt2_N)
                                    .AddParameter("P_COD_AGT3_N", DbType.Int32, 6, s2000030Instance.Cod_Agt3_N)
                                    .AddParameter("P_PCT_AGT3_N", DbType.Double, 10, s2000030Instance.Pct_Agt3_N)
                                    .AddParameter("P_COD_AGT4_N", DbType.Int32, 6, s2000030Instance.Cod_Agt4_N)
                                    .AddParameter("P_PCT_AGT4_N", DbType.Double, 10, s2000030Instance.Pct_Agt4_N)
                                    .AddParameter("P_COD_NIVEL3_N", DbType.Int32, 4, s2000030Instance.Cod_Nivel3_N)
                                    .AddParameter("P_COD_FRACC_PAGO_N", DbType.Int32, 5, s2000030Instance.Cod_Fracc_Pago_N)
                                    .AddParameter("P_TIP_GESTOR_N", DbType.String, 2, s2000030Instance.Tip_Gestor_N)
                                    .AddParameter("P_COD_GESTOR_N", DbType.String, 13, s2000030Instance.Cod_Gestor_N)
                                    .AddParameter("P_NUM_SECU_CTA_TAR", DbType.Int32, 4, s2000030Instance.Num_Secu_Cta_Tar)
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
