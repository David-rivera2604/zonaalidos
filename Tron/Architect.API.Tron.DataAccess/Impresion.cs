using Architect.DataFactory;
using Architect.Utilities.Extensions;
using Architect.Utilities.Helpers;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;


namespace Architect.API.Tron.DataAccess
{
    public static class Impresion
    {
        public static async Task<string> AvisoDeCobroDetalle(int num_aviso)
        {
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron");
            Database.Procedure("dc_k_consulta_web_avisos_mcr.p_imprime_aviso")
                    .AddParameter("p_num_aviso", Architect.DataFactory.Enumerations.DbType.String, 7, num_aviso.ToString())
                    .AddParameter("p_id_report", Architect.DataFactory.Enumerations.DbType.String, 22, 0, ParameterDirection.Output)
                    .AddParameter("p_errores", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                    .Execute(currentConnection, "Tron");

            string reportId = await ReportIdentify(currentConnection, Convert.ToString(num_aviso));
            currentConnection.Close();
            return reportId;
        }

        public static async Task<string> AvisoDeCobro(int cod_cia, int num_aviso)
        {
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron");
            Database.Procedure("TRON2000.em_k_jrp_factura_aviso_mcr.p_lista")
                    .AddParameter("p_cod_cia", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                    .AddParameter("p_num_aviso", Architect.DataFactory.Enumerations.DbType.String, 7, num_aviso.ToString())
                    .Execute(currentConnection, "Tron");

            string reportId = await ReportIdentify(currentConnection, Convert.ToString(num_aviso));
            currentConnection.Close();
            return reportId;
        }
        public static async Task<string> Poliza(int cod_cia, string num_poliza, string procedureName, int num_riesgo = 1)
        {
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron");
            string reportId = string.Empty;   

            switch (procedureName)
            {
                case "em_p_certificado_401_za":

                    Database.Procedure(procedureName)
                             .AddParameter("p_num_poliza", Architect.DataFactory.Enumerations.DbType.String, 22, num_poliza)
                             .AddParameter("p_num_spto", Architect.DataFactory.Enumerations.DbType.Int32, 15, 0)
                             .AddParameter("p_id_report", Architect.DataFactory.Enumerations.DbType.String, 22, reportId, ParameterDirection.InputOutput)
                             .Execute(currentConnection, "Tron", new Action<DbCommand>((command) =>
                             {
                                 reportId = (command.Parameters["p_id_report"].Value.ToString());
                             }));

                    break;

                case "em_p_certificado_117_za":

                    Database.Procedure(procedureName)
                            .AddParameter("p_num_poliza", Architect.DataFactory.Enumerations.DbType.String, 22, num_poliza)
                            .AddParameter("p_num_spto", Architect.DataFactory.Enumerations.DbType.Int32, 15, 0)
                            .AddParameter("p_id_report", Architect.DataFactory.Enumerations.DbType.String, 22, reportId, ParameterDirection.InputOutput)
                            .Execute(currentConnection, "Tron", new Action<DbCommand>((command) =>
                            {
                                reportId = (command.Parameters["p_id_report"].Value.ToString());
                            }));

                    currentConnection.Close();
                    break;

                default:
                    Database.Procedure(procedureName)
                    .AddParameter("JBCOD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                    .AddParameter("JBNUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 15, num_poliza)
                    .AddParameter("JBNUM_RIESGO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_riesgo)
                    .Execute(currentConnection, "Tron");
                    reportId = await ReportIdentify(currentConnection, num_poliza);
                    currentConnection.Close();
                    break;
            }

            return reportId;
        }

        public static async Task<string> Recibo(int cod_cia, int num_recibo)
        {
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron");
            Database.Procedure("em_k_jrp_reimpfactura_mcr.p_lista")
                    .AddParameter("p_cod_cia", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                    .AddParameter("p_num_recibo", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_recibo)
                    .Execute(currentConnection, "Tron");

            string reportId = await ReportIdentify(currentConnection, Convert.ToString(num_recibo));
            currentConnection.Close();
            return reportId;
        }

        public static async Task<string> Acreedor(int cod_cia, string num_poliza)
        {
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron");
            Database.Procedure("em_k_jrp_anexo_acreencia_mcr.p_lista")
                    .AddParameter("p_cod_cia", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                    .AddParameter("p_num_poliza_grupo", Architect.DataFactory.Enumerations.DbType.String, 13, string.Empty)
                    .AddParameter("p_num_poliza", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                    .AddParameter("p_id_fichero", Architect.DataFactory.Enumerations.DbType.String, 22, 0, ParameterDirection.Output)
                    .Execute(currentConnection, "Tron");

            string reportId = await ReportIdentify(currentConnection, num_poliza);
            currentConnection.Close();
            return reportId;
        }

        public static async Task<string> DepositoDePrima(int cod_cia, int num_recibo, bool cobradosHoy = true)
        {
            string procName = cobradosHoy ? "em_k_jrp_liscomp_mcr.p_lista" : "em_k_jrp_re_liscomp_mcr.p_lista";
            IDbConnection currentConnection = Database.OpenConnection("Tron");
            Database.Procedure(procName)
                 .AddParameter("p_cod_cia", DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                 .AddParameter("p_cod_cajero", DataFactory.Enumerations.DbType.String, 8, null)
                 .AddParameter("p_num_bloquetes", DataFactory.Enumerations.DbType.Int32, 12, null)
                 .AddParameter("p_num_recibo", DataFactory.Enumerations.DbType.Int32, 22, num_recibo)
                 .Execute(currentConnection, "Tron");

            string reportId = await ReportIdentify(currentConnection, Convert.ToString(num_recibo));
            currentConnection.Close();
            return reportId;
        }

        private static async Task<string> ReportIdentify(IDbConnection currentConnection, string p_parametro = "")
        {
            string result = null;
            int maxRetries = 3;
            int attempt = 0;
            int waitMilliseconds = 1000; // Espera 1/5 segundo entre reintentos

            while (string.IsNullOrEmpty(result) && attempt < maxRetries)
            {

                try
                {
                    string query = "SELECT id_report " +
                                        "FROM tronweb_reports " +
                                    "WHERE id_report = " +
                                            "(SELECT id_report " +
                                                "FROM (SELECT id_report " +
                                                        "FROM tronweb_reports " +
                                             "WHERE cod_cia = 1 " +
                                                            "AND cod_user = :cod_user " +
                                                            "AND trunc(fec_created) = TO_DATE(:fecha, 'DD/MM/YY') " +
                                                            "ORDER BY fec_created DESC) " +
                                            "WHERE ROWNUM = 1) " +
                                   "AND clb_data LIKE :parametro";

                    var command = Database.Select(query)
                    .AddParameter("cod_user", Architect.DataFactory.Enumerations.DbType.String, 20, "TRON2000")
                    .AddParameter("fecha", Architect.DataFactory.Enumerations.DbType.String, 8, DateTime.Today.ToString("dd/MM/yy"))
                    .AddParameter("parametro", Architect.DataFactory.Enumerations.DbType.String, 200, "%" + p_parametro + "%");

                    command.Query("Tron", new Action<IDataReader>((reader) =>
                    {
                        result = Convert.ToString(reader.IntegerValue("id_report"));
                    }));

                }
                catch (Exception ex)
                {
                    Utilities.Log.WarningLog("Generacion.Tron.PDF", "Parametro: " + p_parametro + " Error:" + ex.Message);
                    result = null;
                }

                if (string.IsNullOrEmpty(result))
                {
                    attempt++;
                    await Task.Delay(waitMilliseconds);  // espera antes de volver a intentar
                }
            }

            return result;
        }


    }
}