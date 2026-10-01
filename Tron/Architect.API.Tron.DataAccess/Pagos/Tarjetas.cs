using Architect.DataFactory;
using Architect.DataFactory.Enumerations;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;

using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Pagos
{
    public static class Tarjetas
    {

        /// <summary>
        /// Extrae la información de tarjetas a ser tokenizadas.
        /// </summary>
        public static List<Contracts.Pagos.Tarjeta> PendientesPorTokenizar(int cod_cia, int fetchRows, string filter)
        {
            List<Contracts.Pagos.Tarjeta> result = new List<Contracts.Pagos.Tarjeta>();

            Database.Procedure("em_k_Mapfre_Query_Contract_mcr.p_tokeniza_tarjeta")
                    .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                    .Query("Tron", new Action<IDataReader>((reader) =>
                    {
                        result.Add(new Architect.API.Tron.Contracts.Pagos.Tarjeta()
                        {
                            MCA_FISICO = reader.StringValue("MCA_FISICO") == "S",
                            TIP_DOCUM = reader.StringValue("TIP_DOCUM"),
                            COD_DOCUM = reader.StringValue("COD_DOCUM"),
                            NOM_TERCERO = reader.StringValue("NOM_TERCERO"),
                            NOM2_TERCERO = reader.StringValue("NOM2_TERCERO"),
                            APE1_TERCERO = reader.StringValue("APE1_TERCERO"),
                            APE2_TERCERO = reader.StringValue("APE2_TERCERO"),
                            TLF_MOVIL = reader.StringValue("TLF_MOVIL"),
                            TLF_NUMERO = reader.StringValue("TLF_NUMERO"),
                            FAX_NUMERO = reader.StringValue("FAX_NUMERO"),
                            EMAIL = reader.StringValue("EMAIL"),
                            EMAIL_COM = reader.StringValue("EMAIL_COM"),
                            TXT_EMAIL = reader.StringValue("TXT_EMAIL"),
                            TIP_TARJETA = reader.IntegerValue("TIP_TARJETA"),
                            NOM_TIP_TARJETA = reader.StringValue("NOM_TIP_TARJETA"),
                            COD_TARJETA = reader.IntegerValue("COD_TARJETA"),
                            NOM_TARJETA = reader.StringValue("NOM_TARJETA"),
                            NUM_TARJETA = reader.StringValue("NUM_TARJETA"),
                            FEC_VCTO_TARJETA = reader.DateTimeValue("FEC_VCTO_TARJETA"),
                            NUM_POLIZA = reader.StringValue("NUM_POLIZA"),
                            NUM_SPTO = reader.IntegerValue("NUM_SPTO")
                        });
                    }));

            return result;
        }

        public static int CreateBoveda(string num_poliza, int num_spto, string TIP_DOCUM, string COD_DOCUM, string CARD, string TOKEN, string CLIENTID, bool STATUS, string REASON, IDbConnection connection = null)
        {
            int result = 0;

            int recordCount = (int)Database.Select("SELECT COUNT(COD_DOCUM) " +
                              "FROM BOVEDA " +
                             "WHERE TIP_DOCUM=:TIP_DOCUM AND COD_DOCUM=:COD_DOCUM AND NUM_POLIZA=:NUM_POLIZA AND NUM_SPTO=:NUM_SPTO AND STATUS<9")
                            .AddParameter("TIP_DOCUM", DbType.AnsiString, 3, TIP_DOCUM)
                            .AddParameter("COD_DOCUM", DbType.AnsiString, 20, COD_DOCUM)
                            .AddParameter("NUM_POLIZA", DbType.String, 13, num_poliza)
                            .AddParameter("NUM_SPTO", DbType.Int32, 22, num_spto)
                            .QueryScalar<Decimal>(connection, "Research");

            if (recordCount == 0)
            {
                result = Database.Insert("BOVEDA", ExecuteMode.CommandBuilder)
                                .Column("TIP_DOCUM", DbType.AnsiString, 3, TIP_DOCUM)
                                .Column("COD_DOCUM", DbType.AnsiString, 20, COD_DOCUM)
                                .Column("CARD", DbType.AnsiString, 80, CARD)
                                .Column("TOKEN", DbType.AnsiString, 120, TOKEN)
                                .Column("CLIENTID", DbType.AnsiString, 80, CLIENTID)
                                .Column("STATUS", DbType.Int32, 1, STATUS ? 1 : 0)
                                .Column("REASON", DbType.AnsiString, 100, REASON)
                                .Column("UpdateDate", DbType.DateTime, 0, DateTime.Now)
                                .Column("NUM_POLIZA", DbType.String, 13, num_poliza)
                                .Column("NUM_SPTO", DbType.Int32, 22, num_spto)
                                .Execute(connection, "Research");
            }
            else
            {
                result = Database.Update("BOVEDA", ExecuteMode.CommandBuilder)
                                .Column("CARD", DbType.AnsiString, 80, CARD)
                                .Column("TOKEN", DbType.AnsiString, 120, TOKEN)
                                .Column("CLIENTID", DbType.AnsiString, 80, CLIENTID)
                                .Column("STATUS", DbType.Int32, 1, STATUS ? 1 : 0)
                                .Column("REASON", DbType.AnsiString, 100, REASON)
                                .Column("UpdateDate", DbType.DateTime, 0, DateTime.Now)
                                .Filter("TIP_DOCUM", DbType.AnsiString, 3, TIP_DOCUM)
                                .Filter("COD_DOCUM", DbType.AnsiString, 20, COD_DOCUM)
                                .Filter("NUM_POLIZA", DbType.String, 13, num_poliza)
                                .Filter("NUM_SPTO", DbType.Int32, 22, num_spto)
                                .Execute(connection, "Research");
            }
            return result;
        }

        public static int UpdateRejectionCount(string num_poliza, string tip_docum, string cod_docum, int numberOfRetries, string reasonLastRejected, int status, DateTime nextCollectAttempt, IDbConnection connection = null)
        {
            string statement = @"UPDATE BOVEDA 
SET NumberOfRetries=:NumberOfRetries, ReasonLastRejected=:ReasonLastRejected, Status=:Status, NextCollectAttempt=:NextCollectAttempt, UpdateDate=:UpdateDate 
WHERE TIP_DOCUM=:TIP_DOCUM AND COD_DOCUM=:COD_DOCUM AND NUM_POLIZA=:NUM_POLIZA AND STATUS>0 AND STATUS<9";

            return Database.Update(statement)
                            .AddParameter("NumberOfRetries", DbType.Int32, 3, numberOfRetries)
                            .AddParameter("ReasonLastRejected", DbType.AnsiString, 100, reasonLastRejected)
                            .AddParameter("Status", DbType.Int32, 1, status)
                            .AddParameter("NextCollectAttempt", DbType.DateTime, 0, nextCollectAttempt)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, DateTime.Now)
                            .AddParameter("TIP_DOCUM", DbType.AnsiString, 3, tip_docum)
                            .AddParameter("COD_DOCUM", DbType.AnsiString, 20, cod_docum)
                            .AddParameter("NUM_POLIZA", DbType.String, 13, num_poliza)
                            .Execute(connection, "Research");
        }

        public static int UpdateRejectionCount(string num_poliza, string tip_docum, string cod_docum, int numberOfRetries, string reasonLastRejected, IDbConnection connection = null)
        {
            string statement = @"UPDATE BOVEDA 
SET NumberOfRetries=:NumberOfRetries, ReasonLastRejected=:ReasonLastRejected, UpdateDate=:UpdateDate 
WHERE TIP_DOCUM=:TIP_DOCUM AND COD_DOCUM=:COD_DOCUM AND NUM_POLIZA=:NUM_POLIZA AND STATUS>0 AND STATUS<9";

            return Database.Update(statement)
                            .AddParameter("NumberOfRetries", DbType.Int32, 3, numberOfRetries)
                            .AddParameter("ReasonLastRejected", DbType.AnsiString, 100, reasonLastRejected)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, DateTime.Now)
                            .AddParameter("TIP_DOCUM", DbType.AnsiString, 3, tip_docum)
                            .AddParameter("COD_DOCUM", DbType.AnsiString, 20, cod_docum)
                            .AddParameter("NUM_POLIZA", DbType.String, 13, num_poliza)
                            .Execute(connection, "Research");
        }

        public static int RetrieveNumberOfRetries(string num_poliza, string tip_docum, string cod_docum, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT NVL(NumberOfRetries, 0) FROM BOVEDA WHERE TIP_DOCUM=:TIP_DOCUM AND COD_DOCUM=:COD_DOCUM AND NUM_POLIZA=:NUM_POLIZA AND STATUS>0 AND STATUS<9")
                            .AddParameter("TIP_DOCUM", DbType.AnsiString, 3, tip_docum)
                            .AddParameter("COD_DOCUM", DbType.AnsiString, 20, cod_docum)
                            .AddParameter("NUM_POLIZA", DbType.String, 13, num_poliza)
                            .QueryScalar<Decimal>(connection, "Research");
        }

        public static int Cancel_Previous_Tokens(string num_poliza, string tip_docum, string cod_docum, IDbConnection connection = null)
        {
            return (int)Database.Update("BOVEDA", DataFactory.Enumerations.ExecuteMode.CommandBuilder)
                            .Column("STATUS", DbType.Int32, 3, 9)
                            .Column("UpdateDate", DbType.DateTime, 0, DateTime.Now)
                            .Filter("TIP_DOCUM", DbType.AnsiString, 3, tip_docum)
                            .Filter("COD_DOCUM", DbType.AnsiString, 20, cod_docum)
                            .Filter("NUM_POLIZA", DbType.String, 13, num_poliza)
                            .FilterCustom("STATUS", DbType.Int32, 1, 9, "<")
                            .Execute(connection, "Research");
        }

    }
}