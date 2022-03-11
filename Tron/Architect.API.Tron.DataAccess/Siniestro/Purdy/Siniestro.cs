using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Siniestro.Purdy
{
    /// <summary>
    /// Operaciones de siniestros exclusivas para Purdy
    /// </summary>
    public class Siniestro
    {

        /// <summary>
        /// Recupera una lista de siniestros por agente para un rango de fecha de ocurrencia.
        /// </summary>
        /// <param name="startDate">Fecha inicial de ocurrencia del siniestro.</param>
        /// <param name="endDate">Fecha final de ocurrencia del siniestro.</param>
        /// <param name="cod_agt">Código de agente.</param>
        /// <returns>Lista de siniestros.</returns>
        public static List<Contracts.Siniestro.Purdy.Siniestro> Retrieve(DateTime startDate, DateTime endDate, int cod_agt)
        {
            List<Contracts.Siniestro.Purdy.Siniestro> result = new List<Contracts.Siniestro.Purdy.Siniestro>();
            Contracts.Siniestro.Purdy.Siniestro siniestro = null;
            int companyId = Int32.Parse(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]);
            Database.Select(@"
SELECT a900.FEC_DENU_SINI, a900.HORA_DENU_SINI, a900.NUM_SINI, a1000.NUM_EXP, a1000.TIP_EXP, G90.NOM_EXP, a900.TIP_EST_SINI, G31A.NOM_VALOR NOM_TIP_EST_SINI,
       a900.NUM_POLIZA, A2020.VAL_CAMPO NUM_MATRICULA, A2020b.VAL_CAMPO IMP_VR,
       a900.TIP_DOCUM_ASEG, a900.COD_DOCUM_ASEG, A1399A.NOM_TERCERO NOM_ASEG,  A1399A.APE1_TERCERO APE_ASEG, A1331.EMAIL EMAIL_ASEG, A1331.TLF_NUMERO,
       a971.TXT_RELATO,
       a900.COD_CAUSA_SINI, G200.NOM_CAUSA,
       (SELECT SUM(a700.IMP_RECIBO) FROM A2990700 a700 WHERE a700.COD_CIA=1 AND a700.NUM_POLIZA=a900.NUM_POLIZA AND a700.NUM_SPTO=a900.NUM_SPTO AND a700.NUM_APLI=a900.NUM_APLI AND a700.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND a700.TIP_SITUACION IN ('CT') ) TOT_PRI_COB,
       (SELECT SUM(a700.IMP_RECIBO) FROM A2990700 a700 WHERE a700.COD_CIA=1 AND a700.NUM_POLIZA=a900.NUM_POLIZA AND a700.NUM_SPTO=a900.NUM_SPTO AND a700.NUM_APLI=a900.NUM_APLI AND a700.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND a700.TIP_SITUACION IN ('CT') AND a700.FEC_EFEC_RECIBO<=a900.FEC_SINI) TOT_PRI_COB_ALPER,
       (SELECT SUM(a700.IMP_RECIBO) FROM A2990700 a700 WHERE a700.COD_CIA=1 AND a700.NUM_POLIZA=a900.NUM_POLIZA AND a700.NUM_SPTO=a900.NUM_SPTO AND a700.NUM_APLI=a900.NUM_APLI AND a700.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND a700.TIP_SITUACION IN ('EP') AND a700.FEC_EFEC_RECIBO<=a900.FEC_SINI) TOT_PRI_PEN_ALPER,
       (SELECT SUM(a700.IMP_RECIBO) FROM A2990700 a700 WHERE a700.COD_CIA=1 AND a700.NUM_POLIZA=a900.NUM_POLIZA AND a700.NUM_SPTO=a900.NUM_SPTO AND a700.NUM_APLI=a900.NUM_APLI AND a700.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND a700.TIP_SITUACION IN ('EP') ) TOT_PRI_PEN,
       (SELECT MAX(a700.FEC_REMESA) FROM A2990700 a700 WHERE a700.COD_CIA=1 AND a700.NUM_POLIZA=a900.NUM_POLIZA AND a700.NUM_SPTO=a900.NUM_SPTO AND a700.NUM_APLI=a900.NUM_APLI AND a700.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND a700.TIP_SITUACION IN ('CT') ) FEC_ULT_PRIMA_COB 
  FROM a7000900 a900
  JOIN A7001000 a1000 ON a1000.COD_CIA=a900.COD_CIA AND a1000.NUM_SINI=a900.NUM_SINI
  LEFT JOIN G1010031 G31A ON G31A.COD_CAMPO ='TIP_EST_SINI' AND G31A.COD_VALOR = a900.TIP_EST_SINI AND G31A.COD_IDIOMA='ES'
  LEFT JOIN A1001399 A1399A ON A1399A.COD_CIA=a900.COD_CIA AND A1399A.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1399A.COD_DOCUM = a900.COD_DOCUM_ASEG
  LEFT JOIN A1001331 A1331 ON A1331.COD_CIA=a900.COD_CIA AND A1331.TIP_DOCUM = a900.TIP_DOCUM_ASEG AND  A1331.COD_DOCUM = a900.COD_DOCUM_ASEG  
  LEFT JOIN G7000200 G200 ON G200.COD_CIA = G200.COD_CIA AND G200.TIP_CAUSA = 1 AND G200.COD_CAUSA = a900.COD_CAUSA_SINI
  LEFT JOIN A2000020 A2020 ON A2020.COD_CIA=a900.COD_CIA AND A2020.NUM_POLIZA=a900.NUM_POLIZA AND A2020.NUM_SPTO=0 AND A2020.NUM_APLI=0 AND A2020.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020.NUM_RIESGO=a900.NUM_RIESGO AND A2020.COD_CAMPO='NUM_MATRICULA'
  LEFT JOIN A2000020 A2020b ON A2020b.COD_CIA=a900.COD_CIA AND A2020b.NUM_POLIZA=a900.NUM_POLIZA AND A2020b.NUM_SPTO=0 AND A2020b.NUM_APLI=0 AND A2020b.NUM_SPTO_APLI=a900.NUM_SPTO_APLI AND A2020b.NUM_RIESGO=a900.NUM_RIESGO AND A2020b.COD_CAMPO='IMP_VR'
  LEFT JOIN A7000971 a971 ON a971.COD_CIA=a900.COD_CIA  AND a971.NUM_SINI=a900.NUM_SINI
  LEFT JOIN G7000090 G90 ON G90.COD_CIA = a1000.COD_CIA AND G90.TIP_EXP = a1000.TIP_EXP
  LEFT JOIN G1010031 G31A ON G31A.COD_CAMPO ='TIP_EST_EXP' AND G31A.COD_VALOR = a1000.TIP_EST_EXP AND G31A.COD_IDIOMA='ES' 
  WHERE a900.COD_CIA=:companyId AND a900.COD_AGT=:cod_agt AND a900.FEC_SINI >= :startDate AND a900.FEC_SINI <= :endDate 
 ORDER BY a900.FEC_SINI")
                        .AddParameter("companyId", DbType.Decimal, 5, companyId)
                        .AddParameter("cod_agt", DbType.Decimal, 5, cod_agt)
                        .AddParameter("startDate", DbType.DateTime, 9, startDate)
                        .AddParameter("endDate", DbType.DateTime, 9, endDate)
                        .Query(null, "Tron", new Action<System.Data.IDataReader>((reader) =>
                        {
                            siniestro = new Contracts.Siniestro.Purdy.Siniestro()
                            {
                                FechaDeIngresoDeAviso = reader.DateTimeValue("FEC_DENU_SINI"),
                                MesDeSiniestro = reader.DateTimeValue("FEC_DENU_SINI").Month,
                                NoSiniestro = reader.Integer64Value("NUM_SINI"),
                                Expediente = reader.IntegerValue("NUM_EXP"),
                                Estado = reader.StringValue("NOM_TIP_EST_SINI"),
                                TipoDeIndemnizacion = string.Empty,
                                NoPoliza = reader.StringValue("NUM_POLIZA"),
                                Matricula = reader.StringValue("NUM_MATRICULA"),
                                CedulaAsegurado = reader.StringValue("COD_DOCUM_ASEG"),
                                NombreAsegurado = string.Format("{0} {1}", reader.StringValue("NOM_ASEG"), reader.StringValue("APE_ASEG")),
                                TipoCobertura = string.Empty,
                                DetalleSiniestro = reader.StringValue("TXT_RELATO"),
                                CorreoAsegurado = reader.StringValue("EMAIL_ASEG"),
                                TelefonoAsegurado = reader.StringValue("TLF_NUMERO"),
                                ValorAsegurado = Convert.ToDouble("0" + reader.StringValue("IMP_VR")),
                                TotalDePrimaCobradas = reader.DoubleValue("TOT_PRI_COB"),
                                MontoDePrimasDelPeriodo = reader.DoubleValue("TOT_PRI_COB_ALPER"),
                                TotalPrimasPendientesDelPeriodo = reader.DoubleValue("TOT_PRI_PEN_ALPER"),
                                PrimasPendientesDeCobro = reader.DoubleValue("TOT_PRI_PEN"),
                                FechaUltimaPrimaCobrada = reader.DateTimeValue("FEC_ULT_PRIMA_COB"),
                                Deducible = 0
                            };
                            if (siniestro.FechaUltimaPrimaCobrada == DateTime.MinValue)
                                siniestro.FechaUltimaPrimaCobrada = null;

                            result.Add(siniestro);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de siniestros por agente para un rango de fecha de ocurrencia.
        /// </summary>
        /// <param name="cod_agt">Código de agente.</param>
        /// <returns>Lista de siniestros.</returns>
        public static List<Contracts.Siniestro.Purdy.Siniestro> Retrieve(int cod_agt)
        {
            List<Contracts.Siniestro.Purdy.Siniestro> result = new List<Contracts.Siniestro.Purdy.Siniestro>();
            Contracts.Siniestro.Purdy.Siniestro siniestro = null;
            int companyId = Int32.Parse(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]);
            Database.Select(@"
SELECT a900.NUM_POLIZA, a900.NUM_SINI, a1000.NUM_EXP, a1000.TIP_EXP, a900.TIP_EST_SINI, G31A.NOM_VALOR NOM_TIP_EST_SINI, a1000.TIP_EST_EXP, G31B.NOM_VALOR NOM_TIP_EST_EXP       
  FROM a7000900 a900
  JOIN A7001000 a1000 ON a1000.COD_CIA=a900.COD_CIA AND a1000.NUM_SINI=a900.NUM_SINI
  LEFT JOIN G1010031 G31A ON G31A.COD_CAMPO ='TIP_EST_SINI' AND G31A.COD_VALOR = a900.TIP_EST_SINI AND G31A.COD_IDIOMA='ES'   
  LEFT JOIN G1010031 G31B ON G31B.COD_CAMPO ='TIP_EST_EXP' AND G31B.COD_VALOR = a1000.TIP_EST_EXP AND G31B.COD_IDIOMA='ES'      
  WHERE a900.COD_CIA=:companyId AND a900.COD_AGT=:cod_agt
 ORDER BY a900.FEC_SINI")
                        .AddParameter("companyId", DbType.Decimal, 5, companyId)
                        .AddParameter("cod_agt", DbType.Decimal, 5, cod_agt)
                        .Query(null, "Tron", new Action<System.Data.IDataReader>((reader) =>
                        {
                            siniestro = new Contracts.Siniestro.Purdy.Siniestro()
                            {
                                NoSiniestro = reader.Integer64Value("NUM_SINI"),
                                Expediente = reader.IntegerValue("NUM_EXP"),
                                Estado = reader.StringValue("NOM_TIP_EST_SINI"),
                                NoPoliza = reader.StringValue("NUM_POLIZA")
                            };

                            result.Add(siniestro);
                        }));
            return result;
        }

    }
}
