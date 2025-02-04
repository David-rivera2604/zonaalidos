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
        public static List<Contracts.Pagos.Tarjeta> PendientesPorTokenizar(int cod_cia, int fetchRows, string cod_docum)
        {
            List<Contracts.Pagos.Tarjeta> result = new List<Contracts.Pagos.Tarjeta>();
            string filter = string.Empty;

            if (!string.IsNullOrEmpty(cod_docum))
            {
                filter = string.Format( " AND A99.COD_DOCUM='{0}'", cod_docum);
            }

            //TODO: Falta definir condición para saber que la tarjeta ya fue tokenizada
            Database.Select(@"
WITH CARDTOTOKEN AS (
SELECT DISTINCT B.REASON,A99.MCA_FISICO, A99.TIP_DOCUM, A99.COD_DOCUM, A99.NOM_TERCERO, A99.NOM2_TERCERO, A99.APE1_TERCERO, A99.APE2_TERCERO, 
       A99.TLF_MOVIL, A31.TLF_NUMERO, A31.FAX_NUMERO,A31.EMAIL, A31.EMAIL_COM, A31.TXT_EMAIL,
       TJ.TIP_TARJETA, A21.NOM_TIP_TARJETA, TJ.COD_TARJETA, A22.NOM_TARJETA, TJ.NUM_TARJETA NUM_TARJETA, TJ.FEC_VCTO_TARJETA,
       TJ.NUM_POLIZA, TJ.NUM_SPTO --, TJ.NUM_RIESGO
  FROM A1001399 A99
  LEFT JOIN A1001331 A31 ON A31.COD_CIA=A99.COD_CIA AND A31.TIP_DOCUM=A99.TIP_DOCUM AND A31.COD_DOCUM=A99.COD_DOCUM
  LEFT JOIN A1000802  TJ ON TJ.COD_CIA=A99.COD_CIA AND TJ.TIP_DOCUM=A99.TIP_DOCUM AND TJ.COD_DOCUM=A99.COD_DOCUM
  LEFT JOIN A5020021 A21 ON A21.TIP_TARJETA=TJ.TIP_TARJETA
  LEFT JOIN A5020022 A22 ON A22.COD_CIA=A99.COD_CIA AND A22.TIP_TARJETA=TJ.TIP_TARJETA AND A22.COD_TARJETA=TJ.COD_TARJETA  
  LEFT JOIN ALIADOS.BOVEDA B ON B.TIP_DOCUM=A99.TIP_DOCUM AND B.COD_DOCUM=A99.COD_DOCUM AND B.NUM_POLIZA=TJ.NUM_POLIZA AND B.NUM_SPTO=TJ.NUM_SPTO --AND B.NUM_RIESGO=TJ.NUM_RIESGO
 WHERE A99.COD_CIA=:cod_cia
   AND NOT TJ.NUM_TARJETA IS NULL 
   AND INSTR(TJ.NUM_TARJETA, '*')=0 
   AND (NOT A31.EMAIL IS NULL OR NOT A31.EMAIL_COM IS NULL OR NOT A31.TXT_EMAIL IS NULL )
)SELECT * FROM CARDTOTOKEN WHERE REASON IS NULL FETCH FIRST :fetchRows ROWS ONLY")
                    .AddParameter("cod_cia", DbType.Int32, 22, cod_cia)
                    .AddParameter("fetchRows", DbType.Int32, 22, fetchRows)
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
                             "WHERE TIP_DOCUM=:TIP_DOCUM AND COD_DOCUM=:COD_DOCUM AND NUM_POLIZA=:NUM_POLIZA AND NUM_SPTO=:NUM_SPTO")
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

        public static int UpdateRejectionCount(string tip_docum, string cod_docum, int numberOfRetries, string reasonLastRejected, int status, IDbConnection connection = null)
        {
            return (int)Database.Update("BOVEDA", DataFactory.Enumerations.ExecuteMode.CommandBuilder)
                            .Column("NumberOfRetries", DbType.Int32, 3, numberOfRetries)
                            .Column("ReasonLastRejected", DbType.AnsiString, 100, reasonLastRejected)
                            .Column("Status", DbType.Int32, 1, status)
                            .Column("UpdateDate", DbType.DateTime, 0, DateTime.Now)
                            .Filter("TIP_DOCUM", DbType.AnsiString, 3, tip_docum)
                            .Filter("COD_DOCUM", DbType.AnsiString, 20, cod_docum)
                            .Filter("STATUS", DbType.Int32, 1, 1)
                            .Execute(connection, "Research");
        }
    
        public static int UpdateRejectionCount(string tip_docum, string cod_docum, int numberOfRetries, string reasonLastRejected, IDbConnection connection = null)
        {
            return (int)Database.Update("BOVEDA", DataFactory.Enumerations.ExecuteMode.CommandBuilder)
                            .Column("NumberOfRetries", DbType.Int32, 3, numberOfRetries)
                            .Column("ReasonLastRejected", DbType.AnsiString, 100, reasonLastRejected)
                            .Column("UpdateDate", DbType.DateTime, 0, DateTime.Now)
                            .Filter("TIP_DOCUM", DbType.AnsiString, 3, tip_docum)
                            .Filter("COD_DOCUM", DbType.AnsiString, 20, cod_docum)
                            .Filter("STATUS", DbType.Int32, 1, 1)
                            .Execute(connection, "Research");
        }

        public static int RetrieveNumberOfRetries(string tip_docum, string cod_docum, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT NVL(NumberOfRetries, 0) " +
                              "FROM BOVEDA " +
                             "WHERE TIP_DOCUM=:TIP_DOCUM AND COD_DOCUM=:COD_DOCUM AND STATUS=1")
                            .AddParameter("TIP_DOCUM", DbType.AnsiString, 3, tip_docum)
                            .AddParameter("COD_DOCUM", DbType.AnsiString, 20, cod_docum)
                            .QueryScalar<Decimal>(connection, "Research");
        }
    
    }
}