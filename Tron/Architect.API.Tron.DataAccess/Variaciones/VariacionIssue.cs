using Architect.API.Tron.Contracts.Ramo;
using Architect.API.Tron.Contracts.Variaciones;
using Architect.API.Tron.DataAccess.Pagos;
using Architect.DataFactory;
using Architect.Utilities.Extensions;
using Architect.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Variaciones
{
    public static class VariacionIssue
    {
        public static VariacionIssueResult Issue(int cod_cia, string num_poliza, DateTime fec_tratamiento, string tip_mvto_batch, string mca_anulada, string mca_fracc_pago, string mca_fec_efec_sys, DateTime? fec_efec_cancel = null, string txt_motivo = "")
        {
            VariacionIssueResult variacionIssueResult = new VariacionIssueResult();

            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.P_EM_K_BATCH_SPTO")
                                    .AddParameter("p_cod_cia", DbType.Int32, 2, cod_cia)
                                    .AddParameter("p_num_poliza", DbType.String, 13, num_poliza)
                                    .AddParameter("p_fec_tratamiento", DbType.Date, 0, fec_tratamiento)
                                    .AddParameter("p_tip_mvto_batch", DbType.String, 2, tip_mvto_batch)
                                    .AddParameter("p_mca_anula", DbType.String, 1, mca_anulada)
                                    .AddParameter("p_mca_fracc_pago", DbType.String, 1, mca_fracc_pago)
                                    .AddParameter("p_mca_fec_efec_sys", DbType.String, 1, mca_fec_efec_sys)
                                    .AddParameter("p_fec_efec_cancel", DbType.Date, 0, fec_efec_cancel)
                                    .AddParameter("p_txt_motivo", DbType.String, 30, txt_motivo)
                                    .AddParameter("rc1", DbType.RefCursor, 0, null, ParameterDirection.Output)
                                    .AddParameter("rc2", DbType.RefCursor, 0, null, ParameterDirection.Output)
                        .Query(currentConnection, "Tron", new Action<System.Data.IDataReader, string>((reader, key) =>
                        {
                            switch (key)
                            {
                                case "rc1":

                                    variacionIssueResult.ProcessResult.Add(new VariacionIssueProcessResult()
                                    {
                                        num_poliza = reader.StringValue("num_presupuesto"),
                                        num_riesgo = reader.IntegerValue("num_riesgo"),
                                        num_poliza_definitivo = reader.StringValue("num_poliza_definitivo"),
                                        txt_error = reader.StringValue("txt_error"),
                                        txt_ruta_error = reader.StringValue("txt_ruta_error")
                                    });

                                    break;
                                case "rc2":
                                    variacionIssueResult.Recibos.Add(new Receipt()
                                    {
                                        num_poliza = reader.StringValue("num_poliza"),
                                        num_spto = reader.IntegerValue("num_spto"),
                                        imp_recibo_spto = reader.DoubleValue("imp_recibo_spto"),
                                        num_cuota= reader.IntegerValue("num_cuota"),
                                        num_recibo = reader.IntegerValue("num_recibo"),
                                        fec_efec_recibo = reader.DateTimeValue("fec_efec_recibo"),
                                        fec_vcto_recibo = reader.DateTimeValue("fec_vcto_recibo"),
                                        tip_situacion = reader.StringValue("tip_situacion"),
                                        cod_mon = reader.IntegerValue("cod_mon"),
                                        imp_recibo = reader.DoubleValue("imp_recibo"),
                                        imp_neta = reader.DoubleValue("imp_neta"),
                                        imp_recargo = reader.DoubleValue("imp_recargo"),
                                        imp_imptos = reader.DoubleValue("imp_imptos"),
                                        imp_boni = reader.DoubleValue("imp_boni"),
                                        imp_comis = reader.DoubleValue("imp_comis"),
                                        tip_coaseguro = reader.IntegerValue("tip_coaseguro"),
                                        cod_agt = reader.IntegerValue("cod_agt"),
                                        imp_total_comis = reader.DoubleValue("imp_total_comis"),
                                        imp_interes = reader.DoubleValue("imp_interes"),
                                        imp_imptos_interes= reader.DoubleValue("imp_imptos_interes"),
                                        fec_vcto_pago = reader.DateTimeValue("fec_vcto_pago")

                                    });
                                

                                    break;
                            }
                        }));
                currentConnection.Close();
            }

            if(variacionIssueResult.ProcessResult?.Count > 0)
            {
                variacionIssueResult.ProcessResult = variacionIssueResult.ProcessResult
                                                                         .GroupBy(r => r.txt_error)
                                                                         .Select(g => g.First())
                                                                         .ToList();
            }

            return variacionIssueResult;
        }

        public static List<Receipt> GetRecibos(int cod_cia, string num_poliza, int? num_spto, int? num_apli = null, int? num_spto_apli = null)
        {
            List<Receipt> receipts = new List<Receipt>();

            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.P_LEE_A2990700")
                                    .AddParameter("p_cod_cia", DbType.Int32, 2, cod_cia)
                                    .AddParameter("p_num_poliza", DbType.String, 13, num_poliza)
                                    .AddParameter("p_num_spto", DbType.Int32, 10, num_spto)
                                    .AddParameter("p_num_apli", DbType.Int32, 10, num_apli)
                                    .AddParameter("p_num_spto_apli", DbType.Int32, 10, num_spto_apli)
                                    .AddParameter("rc1", DbType.RefCursor, 0, null, ParameterDirection.Output)
                        .Query(currentConnection, "Tron", new Action<System.Data.IDataReader, string>((reader, key) =>
                        {
                            switch (key)
                            {
                                case "rc1":
                                    receipts.Add(new Receipt()
                                    {
                                        num_poliza = reader.StringValue("num_poliza"),
                                        num_spto = reader.IntegerValue("num_spto"),
                                        imp_recibo_spto = reader.DoubleValue("imp_recibo_spto"),
                                        num_cuota = reader.IntegerValue("num_cuota"),
                                        num_recibo = reader.IntegerValue("num_recibo"),
                                        fec_efec_recibo = reader.DateTimeValue("fec_efec_recibo"),
                                        fec_vcto_recibo = reader.DateTimeValue("fec_vcto_recibo"),
                                        tip_situacion = reader.StringValue("tip_situacion"),
                                        cod_mon = reader.IntegerValue("cod_mon"),
                                        imp_recibo = reader.DoubleValue("imp_recibo"),
                                        imp_neta = reader.DoubleValue("imp_neta"),
                                        imp_recargo = reader.DoubleValue("imp_recargo"),
                                        imp_imptos = reader.DoubleValue("imp_imptos"),
                                        imp_boni = reader.DoubleValue("imp_boni"),
                                        imp_comis = reader.DoubleValue("imp_comis"),
                                        tip_coaseguro = reader.IntegerValue("tip_coaseguro"),
                                        cod_agt = reader.IntegerValue("cod_agt"),
                                        imp_total_comis = reader.DoubleValue("imp_total_comis"),
                                        imp_interes = reader.DoubleValue("imp_interes"),
                                        imp_imptos_interes = reader.DoubleValue("imp_imptos_interes"),
                                        fec_vcto_pago = reader.DateTimeValue("fec_vcto_pago")

                                    });


                                    break;
                            }
                        }));
                currentConnection.Close();
            }

            return receipts;
        }

        public static (int, string) ManageAuthorizationCT(int cod_ramo, string num_poliza, string observacion, string mca_autoriza, int cod_error, double? id_proceso = null, string num_poliza_grupo = "")
        {
            int cod_salida = -1;
            string msj_salida = string.Empty;

            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                List<DataFactory.Contracts.Parameter> parameters = Database.ParameterList()
                                    .AddParameter("P_ID_PROCESO", DbType.Double, 10, id_proceso)
                                    .AddParameter("P_COD_RAMO", DbType.Int32, 3, cod_ramo)
                                    .AddParameter("P_NUM_POLIZA", DbType.String, 13, num_poliza)
                                    .AddParameter("P_TXT_OBSERVACION", DbType.String, 2000, observacion)
                                    .AddParameter("P_MCA_AUTORIZA", DbType.String, 1, mca_autoriza)
                                    .AddParameter("P_NUM_POLIZA_GRUPO", DbType.String, 13, num_poliza_grupo)
                                    .AddParameter("P_COD_ERROR", DbType.Int32, 4, cod_error)
                                    .AddParameter("P_COD_SALIDA", DbType.Int32, 4, cod_salida, ParameterDirection.Output)
                                    .AddParameter("P_MSJ_SALIDA", DbType.String, 250, msj_salida, ParameterDirection.Output)
                                    .Parameters;

                Database.Procedure("EM_K_AUT_RECH_CT_EST_MCR.P_PROCESO")
                                    .AddParameter(parameters)
                                    .Execute(currentConnection, "Tron");

                cod_salida = Convert.ToInt32(parameters.Find(r => r.Name == "P_COD_SALIDA").Value.ToString());
                msj_salida = parameters.Find(r => r.Name == "P_MSJ_SALIDA").Value.ToString();

                currentConnection.Close();
            }

            return (cod_salida, msj_salida);
        }

        public static List<g1010031> GetSumaAseguradaPorRamo(int cod_cia, int cod_ramo)
        {
            List<g1010031> receipts = new List<g1010031>();

            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.P_LEE_DV_SUM_RAMO")
                                    .AddParameter("p_cod_cia", DbType.Int32, 2, cod_cia)
                                    .AddParameter("p_cod_ramo", DbType.Int32, 3, cod_ramo)
                                    .AddParameter("rc1", DbType.RefCursor, 0, null, ParameterDirection.Output)
                        .Query(currentConnection, "Tron", new Action<System.Data.IDataReader, string>((reader, key) =>
                        {
                            switch (key)
                            {
                                case "rc1":
                                    receipts.Add(new g1010031()
                                    {
                                        cod_cia = reader.IntegerValue("cod_cia"),
                                        cod_ramo = reader.IntegerValue("cod_ramo"),
                                        cod_cob = reader.IntegerValue("cod_cob"),
                                        num_orden = reader.IntegerValue("num_orden"),
                                        cod_campo = reader.StringValue("nombre_dv")
                                    });
                                    break;
                            }
                        }));
                currentConnection.Close();
            }

            return receipts;
        }

        public static List<a1002150> getAllCoveragesByRamo(int cod_cia, int cod_ramo)
        {
            List<a1002150> receipts = new List<a1002150>();

            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.P_COBERTURAS")
                                    .AddParameter("p_cod_cia", DbType.Int32, 2, cod_cia)
                                    .AddParameter("p_cod_ramo", DbType.Int32, 3, cod_ramo)
                                    .AddParameter("rc1", DbType.RefCursor, 0, null, ParameterDirection.Output)
                        .Query(currentConnection, "Tron", new Action<System.Data.IDataReader, string>((reader, key) =>
                        {
                            switch (key)
                            {
                                case "rc1":
                                    receipts.Add(new a1002150()
                                    {
                                        //cod_cia = reader.IntegerValue("cod_cia"),
                                        //cod_ramo = reader.IntegerValue("cod_ramo"),
                                        COD_COB = reader.IntegerValue("cod_cob"),
                                        NOM_COB = reader.StringValue("nom_cob"),
                                        MCA_OBLIGATORIO = reader.StringValue("mca_obligatorio")
                                    });
                                    break;
                            }
                        }));
                currentConnection.Close();
            }

            return receipts;
        }

        public static bool DeleteTablesS(DateTime fec_tratamiento, string tip_mvto_batch, int cod_cia, string num_poliza)
        {
            bool result = false;
            int affected = 0;
            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                affected = Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_DELETE_TABLES_S")
                                    .AddParameter("P_FEC_TRATAMIENTO", DbType.Date, 0, fec_tratamiento)
                                    .AddParameter("P_TIP_MVTO_BATCH", DbType.String, 2, tip_mvto_batch)
                                    .AddParameter("P_COD_CIA", DbType.Int32, 2, cod_cia)
                                    .AddParameter("P_NUM_POLIZA", DbType.String, 13, num_poliza)
                                  .Execute(currentConnection, "Tron");

                currentConnection.Close();
            }
            if (affected != 0)
            {
                result = true;
            }
            return result;
        }

        public static List<Receipt> GetPlanPagosResumen(int cod_cia, string num_poliza, int? num_spto, int? num_apli, int? num_spto_apli)
        {
            List<Receipt> receipts = new List<Receipt>();

            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2990700_TOTAL_ZA")
                                    .AddParameter("p_cod_cia", DbType.Int32, 2, cod_cia)
                                    .AddParameter("p_num_poliza", DbType.String, 13, num_poliza)
                                    .AddParameter("p_num_spto", DbType.Int32, 10, num_spto)
                                    .AddParameter("p_num_apli", DbType.Int32, 10, num_apli)
                                    .AddParameter("p_num_spto_apli", DbType.Int32, 10, num_spto_apli)
                                    .AddParameter("rc1", DbType.RefCursor, 0, null, ParameterDirection.Output)
                        .Query(currentConnection, "Tron", new Action<System.Data.IDataReader, string>((reader, key) =>
                        {
                            switch (key)
                            {
                                case "rc1":
                                    receipts.Add(new Receipt()
                                    {
                                        fec_efec_recibo = reader.DateTimeValue("fec_efec_recibo"),
                                        fec_vcto_recibo = reader.DateTimeValue("fec_vcto_recibo"),
                                        tip_situacion = reader.StringValue("tip_situacion"),
                                        cod_mon = reader.IntegerValue("cod_mon"),
                                        imp_recibo = reader.DoubleValue("imp_recibo"),
                                        imp_neta = reader.DoubleValue("imp_neta"),
                                        imp_recargo = reader.DoubleValue("imp_recargo"),
                                        imp_imptos = reader.DoubleValue("imp_imptos"),
                                        imp_interes = reader.DoubleValue("imp_interes")
                                    });


                                    break;
                            }
                        }));
                currentConnection.Close();
            }

            return receipts;
        }
    }
}
