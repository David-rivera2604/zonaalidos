using Architect.DataFactory;
using Microsoft.SqlServer.Server;
using System;
using System.Data;

namespace Architect.API.Tron.DataAccess
{
    public static class Impresion
    {
        public static string AvisoDeCobroDetalle(int num_aviso)
        {
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron");
            Database.Procedure("dc_k_consulta_web_avisos_mcr.p_imprime_aviso")
                    .AddParameter("p_num_aviso", Architect.DataFactory.Enumerations.DbType.String, 7, num_aviso.ToString())
                    .AddParameter("p_id_report", Architect.DataFactory.Enumerations.DbType.String, 22, 0, ParameterDirection.Output)
                    .AddParameter("p_errores", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                    .Execute(currentConnection, "Tron");

            string reportId = ReportIdentify(currentConnection);
            currentConnection.Close();
            return reportId;
        }

        public static string AvisoDeCobro(int cod_cia, int num_aviso)
        {
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron");
            Database.Procedure("TRON2000.em_k_jrp_factura_aviso_mcr.p_lista")
                    .AddParameter("p_cod_cia", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                    .AddParameter("p_num_aviso", Architect.DataFactory.Enumerations.DbType.String, 7, num_aviso.ToString())
                    .Execute(currentConnection, "Tron");

            string reportId = ReportIdentify(currentConnection);
            currentConnection.Close();
            return reportId;
        }
        public static string Poliza(int cod_cia, string num_poliza, string procedureName, int num_riesgo = 1)
        {
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron");
            Database.Procedure(procedureName)
                    .AddParameter("JBCOD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                    .AddParameter("JBNUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 15, num_poliza)
                    .AddParameter("JBNUM_RIESGO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_riesgo)
                    .Execute(currentConnection, "Tron");

            string reportId = ReportIdentify(currentConnection);
            currentConnection.Close();
            return reportId;
        }

        public static string Recibo(int cod_cia, int num_recibo)
        {
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron");
            Database.Procedure("em_k_jrp_reimpfactura_mcr.p_lista")
                    .AddParameter("p_cod_cia", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                    .AddParameter("p_num_recibo", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_recibo)
                    .Execute(currentConnection, "Tron");

            string reportId = ReportIdentify(currentConnection);
            currentConnection.Close();
            return reportId;
        }

        public static string DepositoDePrima(int cod_cia, int num_recibo, bool cobradosHoy = true)
        {
            string procName = cobradosHoy ? "em_k_jrp_liscomp_mcr.p_lista" : "em_k_jrp_re_liscomp_mcr.p_lista";
            IDbConnection currentConnection = Database.OpenConnection("Tron");
            Database.Procedure(procName)
                 .AddParameter("p_cod_cia", DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                 .AddParameter("p_cod_cajero", DataFactory.Enumerations.DbType.String, 8, null)
                 .AddParameter("p_num_bloquetes", DataFactory.Enumerations.DbType.Int32, 12, null)
                 .AddParameter("p_num_recibo", DataFactory.Enumerations.DbType.Int32, 22, num_recibo)
                 .Execute(currentConnection, "Tron");

            string reportId = ReportIdentify(currentConnection);
            currentConnection.Close();
            return reportId;
        }

        private static string ReportIdentify(IDbConnection currentConnection)
        {
            return Database.Select("SELECT id_report" +
                             " FROM (SELECT id_report FROM tronweb_reports " +
                                    " WHERE fec_created >= TO_DATE('" + DateTime.Today.ToString("dd/MM/yy") + "', 'DD/MM/YY') ORDER BY fec_created DESC)" +
                            " WHERE ROWNUM = 1")
                            .QueryScalar<Decimal>(currentConnection, "Tron").ToString();
        }

    }
}