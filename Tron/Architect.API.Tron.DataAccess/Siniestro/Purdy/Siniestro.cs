using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
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

            Database.Procedure("dc_k_consulta_web_avisos_mcr.p_consulta_siniestros_purdy")
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
