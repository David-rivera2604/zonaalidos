using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Pagos
{
    public static class Recibos
    {

        /// <summary>
        /// Extrae la información de recibos a recobro.
        /// </summary>
        public static List<Contracts.Pagos.Recibo> Recobro(int cod_cia, string filter)
        {
            List<Contracts.Pagos.Recibo> result = new List<Contracts.Pagos.Recibo>();
            if (!string.IsNullOrEmpty(filter))
            {
                filter = " AND A.NUM_POLIZA IN ('" + filter.Replace(",", "','") + "') ";
            }

            Database.Select(
$@"SELECT C.NUM_RECIBO, C.FEC_EFEC_RECIBO, SUM(C.IMP_RECIBO) IMP_RECIBO, A400.COD_MON_ISO NOM_MON, A.NUM_POLIZA, A.COD_AGT, a1800.nom_ramo, a200.NOM_SECTOR, COALESCE(a60.TIP_DOCUM, A.TIP_DOCUM) TIP_DOCUM, COALESCE(a60.COD_DOCUM, A.COD_DOCUM) COD_DOCUM, A99.NOM_TERCERO, A99.NOM2_TERCERO, A99.APE1_TERCERO, A99.APE2_TERCERO,
  		                A1331.TLF_NUMERO, A1331.TLF_NUMERO_COM, A1331.EMAIL, A1331.EMAIL_COM, A1331.TXT_EMAIL, B.TOKEN
    FROM A2000030 A
    LEFT JOIN (
        SELECT DISTINCT a60.TIP_DOCUM, a60.COD_DOCUM, a60.NUM_POLIZA 
        FROM A2000060 a60  JOIN ALIADOS.BOVEDA B ON  B.NUM_POLIZA=a60.NUM_POLIZA WHERE COD_CIA =1 AND a60.NUM_POLIZA = B.NUM_POLIZA AND TIP_BENEF = 21                                 
    ) a60 ON A.NUM_POLIZA = a60.NUM_POLIZA
    JOIN ALIADOS.BOVEDA B ON B.TIP_DOCUM=COALESCE(a60.TIP_DOCUM, A.TIP_DOCUM) AND B.COD_DOCUM=COALESCE(a60.COD_DOCUM, A.COD_DOCUM) AND B.NUM_POLIZA=A.NUM_POLIZA AND B.NUM_SPTO<=A.NUM_SPTO AND B.STATUS>0 AND B.NextCollectAttempt<=TRUNC(:fec_efect_recibo2) 
    JOIN A2990700 C 
        ON C.NUM_RECIBO = (SELECT MIN(R.NUM_RECIBO)
                            FROM A2990700 R
                            WHERE R.COD_CIA = A.COD_CIA
                            AND R.NUM_POLIZA = A.NUM_POLIZA
                            AND R.NUM_SPTO <= A.NUM_SPTO
                            AND R.NUM_APLI = A.NUM_APLI
                            AND R.NUM_SPTO_APLI = A.NUM_SPTO_APLI
                            AND R.TIP_SITUACION IN ('RE','EP')
                            AND R.TIP_GESTOR IN ('TA')
                            AND R.NUM_RECIBO IN ({filter}))
    JOIN A1001399 A99 ON A99.COD_CIA  = A.COD_CIA AND A99.TIP_DOCUM = COALESCE(a60.TIP_DOCUM, A.TIP_DOCUM) AND A99.COD_DOCUM = COALESCE(a60.COD_DOCUM, A.COD_DOCUM)
    JOIN A1001331 A1331 ON A1331.COD_CIA  = A.COD_CIA AND A1331.TIP_DOCUM = COALESCE(a60.TIP_DOCUM, A.TIP_DOCUM) AND A1331.COD_DOCUM = COALESCE(a60.COD_DOCUM, A.COD_DOCUM)
    JOIN A1000400 A400 ON A400.COD_MON = C.COD_MON
    JOIN A1001800 a1800 ON a1800.COD_CIA=A.COD_CIA AND a1800.COD_RAMO = A.COD_RAMO
    JOIN A1000200 a200 ON a200.COD_CIA=A.COD_CIA AND a200.COD_SECTOR = A.COD_SECTOR 
    WHERE A.COD_CIA = :cod_cia 
        AND A.MCA_POLIZA_ANULADA  = 'N'
        AND A.NUM_SPTO = ( SELECT MAX(A230.NUM_SPTO)
                            FROM A2000030 A230
                            WHERE A230.COD_CIA    = A.COD_CIA
                            AND A230.NUM_POLIZA = A.NUM_POLIZA )
    GROUP BY A.NUM_POLIZA, A.COD_AGT, a1800.nom_ramo, a200.NOM_SECTOR, COALESCE(a60.TIP_DOCUM, A.TIP_DOCUM), COALESCE(a60.COD_DOCUM, A.COD_DOCUM), A99.NOM_TERCERO, A99.NOM2_TERCERO, A99.APE1_TERCERO, A99.APE2_TERCERO,
   			A1331.TLF_NUMERO, A1331.TLF_NUMERO_COM, A1331.EMAIL, A1331.EMAIL_COM, A1331.TXT_EMAIL, C.NUM_RECIBO, C.FEC_EFEC_RECIBO, A400.COD_MON_ISO, B.TOKEN")
                    .AddParameter("cod_cia", DbType.Int32, 22, cod_cia)
                    .Query("Tron", new Action<IDataReader>((reader) =>
                    {
                        result.Add(new Architect.API.Tron.Contracts.Pagos.Recibo()
                        {
                            NUM_RECIBO = reader.IntegerValue("NUM_RECIBO"),
                            FEC_EFEC_RECIBO = reader.DateTimeValue("FEC_EFEC_RECIBO"),
                            IMP_RECIBO = reader.DoubleValue("IMP_RECIBO"),
                            NOM_MON = reader.StringValue("NOM_MON"),
                            NUM_POLIZA = reader.StringValue("NUM_POLIZA"),
                            COD_AGT = reader.IntegerValue("COD_AGT"),
                            NOM_RAMO = reader.StringValue("NOM_RAMO"),
                            NOM_SECTOR = reader.StringValue("NOM_SECTOR"),
                            TIP_DOCUM = reader.StringValue("TIP_DOCUM"),
                            COD_DOCUM = reader.StringValue("COD_DOCUM"),
                            NOM_TERCERO = reader.StringValue("NOM_TERCERO"),
                            NOM2_TERCERO = reader.StringValue("NOM2_TERCERO"),
                            APE1_TERCERO = reader.StringValue("APE1_TERCERO"),
                            APE2_TERCERO = reader.StringValue("APE2_TERCERO"),
                            TLF_NUMERO = reader.StringValue("TLF_NUMERO"),
                            TLF_NUMERO_COM = reader.StringValue("TLF_NUMERO_COM"),
                            EMAIL = reader.StringValue("EMAIL"),
                            EMAIL_COM = reader.StringValue("EMAIL_COM"),
                            TXT_EMAIL = reader.StringValue("TXT_EMAIL"),
                            TOKEN = reader.StringValue("TOKEN")
                        });
                    }));

            return result;
        }

        /// <summary>
        /// Extrae la información de recibos para pago recurrentes.
        /// </summary>
        public static List<Contracts.Pagos.Recibo> PendientesRecurrentesAlCobro(int cod_cia, DateTime fec_efect_recibo, int fetchRows, string filter)
        {
            List<Contracts.Pagos.Recibo> result = new List<Contracts.Pagos.Recibo>();
            if (!string.IsNullOrEmpty(filter))
            {
                filter = " AND A.NUM_POLIZA IN ('" + filter.Replace(",", "','") + "') ";
            }

            Database.Select(
@"SELECT C.NUM_RECIBO, C.FEC_EFEC_RECIBO, SUM(C.IMP_RECIBO) IMP_RECIBO, A400.COD_MON_ISO NOM_MON, A.NUM_POLIZA, A.COD_AGT, a1800.nom_ramo, a200.NOM_SECTOR, COALESCE(a60.TIP_DOCUM, A.TIP_DOCUM) TIP_DOCUM, COALESCE(a60.COD_DOCUM, A.COD_DOCUM) COD_DOCUM, A99.NOM_TERCERO, A99.NOM2_TERCERO, A99.APE1_TERCERO, A99.APE2_TERCERO,
  		                A1331.TLF_NUMERO, A1331.TLF_NUMERO_COM, A1331.EMAIL, A1331.EMAIL_COM, A1331.TXT_EMAIL, B.TOKEN
    FROM A2000030 A
    LEFT JOIN (
        SELECT DISTINCT a60.TIP_DOCUM, a60.COD_DOCUM, a60.NUM_POLIZA 
        FROM A2000060 a60  JOIN ALIADOS.BOVEDA B ON  B.NUM_POLIZA=a60.NUM_POLIZA WHERE COD_CIA =1 AND a60.NUM_POLIZA = B.NUM_POLIZA AND TIP_BENEF = 21                                 
    ) a60 ON A.NUM_POLIZA = a60.NUM_POLIZA
    JOIN ALIADOS.BOVEDA B ON B.TIP_DOCUM=COALESCE(a60.TIP_DOCUM, A.TIP_DOCUM) AND B.COD_DOCUM=COALESCE(a60.COD_DOCUM, A.COD_DOCUM) AND B.NUM_POLIZA=A.NUM_POLIZA AND B.NUM_SPTO<=A.NUM_SPTO AND B.STATUS>0 AND B.NextCollectAttempt<=TRUNC(:fec_efect_recibo2) 
    JOIN A2990700 C 
        ON C.NUM_RECIBO = (SELECT MIN(R.NUM_RECIBO)
                            FROM A2990700 R
                            WHERE R.COD_CIA = A.COD_CIA
                            AND R.NUM_POLIZA = A.NUM_POLIZA
                            AND R.NUM_SPTO <= A.NUM_SPTO
                            AND R.NUM_APLI = A.NUM_APLI
                            AND R.NUM_SPTO_APLI = A.NUM_SPTO_APLI
                            AND R.TIP_SITUACION IN ('RE','EP')
                            AND R.TIP_GESTOR IN ('TA')
                            AND TRUNC(R.FEC_EFEC_RECIBO) <= TRUNC(:fec_efect_recibo))
    JOIN A1001399 A99 ON A99.COD_CIA  = A.COD_CIA AND A99.TIP_DOCUM = COALESCE(a60.TIP_DOCUM, A.TIP_DOCUM) AND A99.COD_DOCUM = COALESCE(a60.COD_DOCUM, A.COD_DOCUM)
    JOIN A1001331 A1331 ON A1331.COD_CIA  = A.COD_CIA AND A1331.TIP_DOCUM = COALESCE(a60.TIP_DOCUM, A.TIP_DOCUM) AND A1331.COD_DOCUM = COALESCE(a60.COD_DOCUM, A.COD_DOCUM)
    JOIN A1000400 A400 ON A400.COD_MON = C.COD_MON
    JOIN A1001800 a1800 ON a1800.COD_CIA=A.COD_CIA AND a1800.COD_RAMO = A.COD_RAMO
    JOIN A1000200 a200 ON a200.COD_CIA=A.COD_CIA AND a200.COD_SECTOR = A.COD_SECTOR 
    WHERE A.COD_CIA = :cod_cia " + filter +
        @" AND A.MCA_POLIZA_ANULADA  = 'N'
        AND A.NUM_SPTO = ( SELECT MAX(A230.NUM_SPTO)
                            FROM A2000030 A230
                            WHERE A230.COD_CIA    = A.COD_CIA
                            AND A230.NUM_POLIZA = A.NUM_POLIZA )
    GROUP BY A.NUM_POLIZA, A.COD_AGT, a1800.nom_ramo, a200.NOM_SECTOR, COALESCE(a60.TIP_DOCUM, A.TIP_DOCUM), COALESCE(a60.COD_DOCUM, A.COD_DOCUM), A99.NOM_TERCERO, A99.NOM2_TERCERO, A99.APE1_TERCERO, A99.APE2_TERCERO,
   			A1331.TLF_NUMERO, A1331.TLF_NUMERO_COM, A1331.EMAIL, A1331.EMAIL_COM, A1331.TXT_EMAIL, C.NUM_RECIBO, C.FEC_EFEC_RECIBO, A400.COD_MON_ISO, B.TOKEN
    FETCH FIRST :fetchRows ROWS ONLY")
                    .AddParameter("fec_efect_recibo2", DbType.Date, 0, fec_efect_recibo)
                    .AddParameter("fec_efect_recibo", DbType.Date, 0, fec_efect_recibo)
                    .AddParameter("cod_cia", DbType.Int32, 22, cod_cia)
                    .AddParameter("fetchRows", DbType.Int32, 22, fetchRows)
                    .Query("Tron", new Action<IDataReader>((reader) =>
                    {
                        result.Add(new Architect.API.Tron.Contracts.Pagos.Recibo()
                        {
                            NUM_RECIBO = reader.IntegerValue("NUM_RECIBO"),
                            FEC_EFEC_RECIBO = reader.DateTimeValue("FEC_EFEC_RECIBO"),
                            IMP_RECIBO = reader.DoubleValue("IMP_RECIBO"),
                            NOM_MON = reader.StringValue("NOM_MON"),
                            NUM_POLIZA = reader.StringValue("NUM_POLIZA"),
                            COD_AGT = reader.IntegerValue("COD_AGT"),
                            NOM_RAMO = reader.StringValue("NOM_RAMO"),
                            NOM_SECTOR = reader.StringValue("NOM_SECTOR"),
                            TIP_DOCUM = reader.StringValue("TIP_DOCUM"),
                            COD_DOCUM = reader.StringValue("COD_DOCUM"),
                            NOM_TERCERO = reader.StringValue("NOM_TERCERO"),
                            NOM2_TERCERO = reader.StringValue("NOM2_TERCERO"),
                            APE1_TERCERO = reader.StringValue("APE1_TERCERO"),
                            APE2_TERCERO = reader.StringValue("APE2_TERCERO"),
                            TLF_NUMERO = reader.StringValue("TLF_NUMERO"),
                            TLF_NUMERO_COM = reader.StringValue("TLF_NUMERO_COM"),
                            EMAIL = reader.StringValue("EMAIL"),
                            EMAIL_COM = reader.StringValue("EMAIL_COM"),
                            TXT_EMAIL = reader.StringValue("TXT_EMAIL"),
                            TOKEN = reader.StringValue("TOKEN")
                        });
                    }));

            return result;
        }

        // <summary>
        /// Extrae la información de un recibo con pago recurrente.
        /// </summary>
        public static Contracts.Pagos.Recibo ReciboAlCobro(int cod_cia, int num_recibo)
        {
            Contracts.Pagos.Recibo result = new Contracts.Pagos.Recibo();
            string filter = string.Empty;

            Database.Select(@"SELECT C.NUM_RECIBO, C.FEC_EFEC_RECIBO, SUM(C.IMP_RECIBO) IMP_RECIBO, A400.COD_MON_ISO NOM_MON, A.NUM_POLIZA, a1800.nom_ramo, A.TIP_DOCUM, A.COD_DOCUM, A99.NOM_TERCERO, A99.NOM2_TERCERO, A99.APE1_TERCERO, A99.APE2_TERCERO,
  		                             A1331.TLF_NUMERO, A1331.TLF_NUMERO_COM, A1331.EMAIL, A1331.EMAIL_COM, A1331.TXT_EMAIL, B.TOKEN
                                FROM A2000030 A
                                JOIN ALIADOS.BOVEDA B ON B.TIP_DOCUM=A.TIP_DOCUM AND B.COD_DOCUM=A.COD_DOCUM AND B.STATUS=1 
                                JOIN A2990700 C 
                                    ON C.COD_CIA  = A.COD_CIA
                                    AND C.NUM_SPTO  <= A.NUM_SPTO
                                    AND C.NUM_APLI   = A.NUM_APLI
                                    AND C.NUM_POLIZA  = A.NUM_POLIZA
                                    AND C.NUM_SPTO_APLI = A.NUM_SPTO_APLI
                                    AND C.TIP_SITUACION IN ('RE','EP')    
                                    AND C.TIP_GESTOR IN ('TA')
                                    AND C.NUM_RECIBO = :num_recibo
                                JOIN A1001399 A99 ON A99.COD_CIA  = A.COD_CIA AND A99.TIP_DOCUM = A.TIP_DOCUM AND A99.COD_DOCUM = A.COD_DOCUM
                                JOIN A1001331 A1331 ON A1331.COD_CIA  = A.COD_CIA AND A1331.TIP_DOCUM = A.TIP_DOCUM AND A1331.COD_DOCUM = A.COD_DOCUM
                                JOIN A1000400 A400 ON A400.COD_MON = C.COD_MON
                                JOIN A1001800 a1800 ON a1800.COD_CIA=A.COD_CIA AND a1800.COD_RAMO = A.COD_RAMO
                                WHERE A.COD_CIA = :cod_cia
                                    AND A.MCA_POLIZA_ANULADA  = 'N'
                                    AND A.NUM_SPTO = ( SELECT MAX(A230.NUM_SPTO)
                                                        FROM A2000030 A230
                                                        WHERE A230.COD_CIA    = A.COD_CIA
                                                        AND A230.NUM_POLIZA = A.NUM_POLIZA )
                                GROUP BY A.NUM_POLIZA, a1800.nom_ramo, A.TIP_DOCUM, A.COD_DOCUM, A99.NOM_TERCERO, A99.NOM2_TERCERO, A99.APE1_TERCERO, A99.APE2_TERCERO,
   			                            A1331.TLF_NUMERO, A1331.TLF_NUMERO_COM, A1331.EMAIL, A1331.EMAIL_COM, A1331.TXT_EMAIL, C.NUM_RECIBO, C.FEC_EFEC_RECIBO, A400.COD_MON_ISO, B.TOKEN")
                    .AddParameter("num_recibo", DbType.Int32, 22, num_recibo)
                    .AddParameter("cod_cia", DbType.Int32, 22, cod_cia)
                    .Query("Tron", new Action<IDataReader>((reader) =>
                    {
                        result = new Architect.API.Tron.Contracts.Pagos.Recibo()
                        {
                            NUM_RECIBO = reader.IntegerValue("NUM_RECIBO"),
                            FEC_EFEC_RECIBO = reader.DateTimeValue("FEC_EFEC_RECIBO"),
                            IMP_RECIBO = reader.DoubleValue("IMP_RECIBO"),
                            NOM_MON = reader.StringValue("NOM_MON"),
                            NUM_POLIZA = reader.StringValue("NUM_POLIZA"),
                            NOM_RAMO = reader.StringValue("NOM_RAMO"),
                            TIP_DOCUM = reader.StringValue("TIP_DOCUM"),
                            COD_DOCUM = reader.StringValue("COD_DOCUM"),
                            NOM_TERCERO = reader.StringValue("NOM_TERCERO"),
                            NOM2_TERCERO = reader.StringValue("NOM2_TERCERO"),
                            APE1_TERCERO = reader.StringValue("APE1_TERCERO"),
                            APE2_TERCERO = reader.StringValue("APE2_TERCERO"),
                            TLF_NUMERO = reader.StringValue("TLF_NUMERO"),
                            TLF_NUMERO_COM = reader.StringValue("TLF_NUMERO_COM"),
                            EMAIL = reader.StringValue("EMAIL"),
                            EMAIL_COM = reader.StringValue("EMAIL_COM"),
                            TXT_EMAIL = reader.StringValue("TXT_EMAIL"),
                            TOKEN = reader.StringValue("TOKEN")
                        };
                    }));

            return result;
        }


        // <summary>
        /// Extrae la información de los recibos de un ramo pagados a la una fecha.
        /// </summary>
        public static List<Contracts.Pagos.Recibo> RecibosCobradoPorRamo(int cod_ramo, DateTime fec_cobro)
        {
            List<Contracts.Pagos.Recibo> result = new List<Contracts.Pagos.Recibo>();

            Database.Select(@"SELECT a1600.FEC_ASTO, a1600.NUM_RECIBO, a1600.NUM_POLIZA, a1600.NUM_SPTO
  FROM A5021600 a1600
  JOIN A2990700 A700 ON A700.NUM_RECIBO = a1600.NUM_RECIBO AND A700.TIP_SITUACION = 'CT' 
  WHERE a1600.COD_CIA = 1 AND a1600.COD_RAMO = :cod_ramo AND a1600.TIP_ACTU = 'CT' AND TRUNC(a1600.FEC_ASTO) = TRUNC(:fec_cobro)")
                .AddParameter("cod_ramo", DbType.Int32, 22, cod_ramo)
                .AddParameter("fec_cobro", DbType.Date, 0, fec_cobro)
                .Query("Tron", new Action<IDataReader>((reader) =>
                {
                    result.Add(new Architect.API.Tron.Contracts.Pagos.Recibo()
                    {
                        FEC_EFEC_RECIBO = reader.DateTimeValue("FEC_ASTO"),
                        NUM_RECIBO = reader.IntegerValue("NUM_RECIBO"),
                        NUM_POLIZA = reader.StringValue("NUM_POLIZA")
                    });
                }));

            return result;
        }


        public static int Get_NumSpto(Int64 num_recibo,  IDbConnection connection = null)
        {

            return (int)Database.Select(
@"SELECT C.NUM_SPTO 
   FROM A2990700 C 
  WHERE c.NUM_RECIBO=:num_recibo FETCH FIRST 5 ROWS ONLY")
                     .AddParameter("num_recibo", DbType.Int32, 22, num_recibo)
                     .QueryScalar<Decimal>(connection, "Research");
        }

        public static Contracts.Pagos.Recibo PrimerReciboAlCobroPorPoliza(string num_poliza)
        {
            Contracts.Pagos.Recibo result = null;
            string filter = string.Empty;

            Database.Select(
@"SELECT C.NUM_RECIBO, C.FEC_EFEC_RECIBO, FEC_VCTO_RECIBO, SUM(C.IMP_RECIBO) IMP_RECIBO, A400.COD_MON_ISO NOM_MON, A.NUM_POLIZA, A.COD_AGT, a1800.nom_ramo, a200.NOM_SECTOR, A.TIP_DOCUM, A.COD_DOCUM, A99.NOM_TERCERO, A99.NOM2_TERCERO, A99.APE1_TERCERO, A99.APE2_TERCERO,
  		    A1331.TLF_NUMERO, A1331.TLF_NUMERO_COM, A1331.EMAIL, A1331.EMAIL_COM, A1331.TXT_EMAIL
    FROM A2000030 A
    JOIN A2990700 C 
        ON C.COD_CIA  = A.COD_CIA
        AND C.NUM_SPTO  <= A.NUM_SPTO
        AND C.NUM_APLI   = A.NUM_APLI
        AND C.NUM_POLIZA  = A.NUM_POLIZA
        AND C.NUM_SPTO_APLI = A.NUM_SPTO_APLI
        AND C.TIP_SITUACION IN ('RE','EP')
JOIN A1001399 A99 ON A99.COD_CIA  = A.COD_CIA AND A99.TIP_DOCUM = A.TIP_DOCUM AND A99.COD_DOCUM = A.COD_DOCUM
JOIN A1001331 A1331 ON A1331.COD_CIA  = A.COD_CIA AND A1331.TIP_DOCUM = A.TIP_DOCUM AND A1331.COD_DOCUM = A.COD_DOCUM
JOIN A1000400 A400 ON A400.COD_MON = C.COD_MON
JOIN A1001800 a1800 ON a1800.COD_CIA=A.COD_CIA AND a1800.COD_RAMO = A.COD_RAMO
JOIN A1000200 a200 ON a200.COD_CIA=A.COD_CIA AND a200.COD_SECTOR = A.COD_SECTOR 
WHERE A.COD_CIA = :cod_cia
  AND A.NUM_POLIZA = :num_poliza 
  AND A.MCA_POLIZA_ANULADA  = 'N'
    AND A.NUM_SPTO = ( SELECT MAX(A230.NUM_SPTO)
                        FROM A2000030 A230
                        WHERE A230.COD_CIA    = A.COD_CIA
                        AND A230.NUM_POLIZA = A.NUM_POLIZA )
GROUP BY A.NUM_POLIZA, A.COD_AGT, a1800.nom_ramo, a200.NOM_SECTOR, A.TIP_DOCUM, A.COD_DOCUM, A99.NOM_TERCERO, A99.NOM2_TERCERO, A99.APE1_TERCERO, A99.APE2_TERCERO,
        A1331.TLF_NUMERO, A1331.TLF_NUMERO_COM, A1331.EMAIL, A1331.EMAIL_COM, A1331.TXT_EMAIL, C.NUM_RECIBO, C.FEC_EFEC_RECIBO, FEC_VCTO_RECIBO, A400.COD_MON_ISO
ORDER BY C.FEC_EFEC_RECIBO
FETCH FIRST 1 ROWS ONLY")
                    .AddParameter("cod_cia", DbType.Int32, 22, 1)
                    .AddParameter("num_poliza", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                    .Query("Tron", new Action<IDataReader>((reader) =>
                    {
                        result = new Architect.API.Tron.Contracts.Pagos.Recibo()
                        {
                            NUM_RECIBO = reader.IntegerValue("NUM_RECIBO"),
                            FEC_EFEC_RECIBO = reader.DateTimeValue("FEC_EFEC_RECIBO"),
                            FEC_VCTO_RECIBO = reader.DateTimeValue("FEC_VCTO_RECIBO"),
                            IMP_RECIBO = reader.DoubleValue("IMP_RECIBO"),
                            NOM_MON = reader.StringValue("NOM_MON"),
                            NUM_POLIZA = reader.StringValue("NUM_POLIZA"),
                            NOM_RAMO = reader.StringValue("NOM_RAMO"),
                            TIP_DOCUM = reader.StringValue("TIP_DOCUM"),
                            COD_DOCUM = reader.StringValue("COD_DOCUM"),
                            NOM_TERCERO = reader.StringValue("NOM_TERCERO"),
                            NOM2_TERCERO = reader.StringValue("NOM2_TERCERO"),
                            APE1_TERCERO = reader.StringValue("APE1_TERCERO"),
                            APE2_TERCERO = reader.StringValue("APE2_TERCERO"),
                            TLF_NUMERO = reader.StringValue("TLF_NUMERO"),
                            TLF_NUMERO_COM = reader.StringValue("TLF_NUMERO_COM"),
                            EMAIL = reader.StringValue("EMAIL"),
                            EMAIL_COM = reader.StringValue("EMAIL_COM"),
                            TXT_EMAIL = reader.StringValue("TXT_EMAIL")
                        };
                    }));

            return result;
        }

    }
}