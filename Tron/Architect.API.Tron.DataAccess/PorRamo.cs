using Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia;
using Architect.DataFactory;
using Architect.Utilities.Contracts;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess
{
    public static class PorRamo
    {

        public static string EM_K_ALTA_BAJA_POLIZA_WEB_MCR(string json, IDbConnection connection = null)
        {
            string result = string.Empty;

            List<DataFactory.Contracts.Parameter> parameters = Database.ParameterList()
                .AddParameter("v_json_str", DbType.String, 4000, json)
                .AddParameter("v_est_salida", DbType.String, 4000, result, ParameterDirection.Output).Parameters;

            Database.Procedure("EM_K_ALTA_BAJA_POLIZA_WEB_MCR.p_inicio")
                        .AddParameter(parameters)
                        .Execute(connection, "Tron");
            result = parameters.Find(r => r.Name == "v_est_salida").Value.ToString();

            return result;
        }


        /// <summary>
        /// Proceso de cobro automático de recibos por la WEB
        /// </summary>
        public static Contracts.Batch.Respuesta p_proceso_cobro(int cod_cia, string session_id, string json, IDbConnection connection = null)
        {
            Contracts.Batch.Respuesta result = new Contracts.Batch.Respuesta();
            string[] jsonArray = { json };

            var ArrayBindSize = jsonArray.Select(_ => _.Length).ToArray();
            var ArrayBindStatus = Enumerable.Repeat(0, jsonArray.Count()).ToArray();

            //                .AddParameter("RC1", DbType.RefCursor, 0, null, ParameterDirection.InputOutput)

            Database.Procedure("gc_k_pagos_web.p_proceso_cobro_net")
                    .AddParameter("p_cod_cia", DbType.Int32, 22, cod_cia)
                    .AddParameter("p_session_id", DbType.String, 13, session_id)
                    .AddParameter("p_array", DbType.String, 4000, json)
                    .Query(connection, "Tron", new Action<IDataReader>((reader) =>
                    {
                        result = new Contracts.Batch.Respuesta()
                        {
                            codigo_respuesta = reader.StringValue("codigo_respuesta"),
                            mensaje_respuesta = reader.StringValue("mensaje_respuesta"),
                            id_report = reader.StringValue("id_report")
                        };
                    }));
            return result;
        }

        public static Architect.API.Tron.Contracts.Vistas.Recibo Informacion_de_un_Recibo(int cod_cia, int cod_agt, string tip_docum, string cod_docum, string num_poliza, Int64 num_recibo, IDbConnection connection = null)
        {
            List<DataFactory.Contracts.Parameter> parameters = new List<DataFactory.Contracts.Parameter>();
            Architect.API.Tron.Contracts.Vistas.Recibo result = null;
            string filter = string.Empty;

            if (cod_agt > 0)
            {
                filter = " AND a30.COD_AGT = :COD_AGT";
                parameters = Database.ParameterList().AddParameter("COD_AGT", DbType.Decimal, 7, cod_agt).Parameters;
            }
            else
            {
                filter += " AND a30.TIP_DOCUM = :TIP_DOCUM AND a30.COD_DOCUM = :COD_DOCUM";
                parameters = Database.ParameterList()
                        .AddParameter("TIP_DOCUM", DbType.String, 3, tip_docum)
                        .AddParameter("COD_DOCUM", DbType.String, 20, cod_docum).Parameters;
            }


            Database.Select(
@"WITH TERCEROS AS (
SELECT a1331.COD_CIA, a1331.TIP_DOCUM, a1331.COD_DOCUM, v1390.NOM_TERCERO, v1390.NOM2_TERCERO, v1390.APE1_TERCERO, v1390.APE2_TERCERO
     , a1331.TIP_TARJETA, a1331.COD_TARJETA, a1331.NUM_TARJETA, a1331.email, a1331.TXT_EMAIL, a1331.tlf_numero, a1331.TLF_MOVIL 
FROM (SELECT COD_CIA, '0' AS TIP_BENEF, TIP_DOCUM, COD_DOCUM FROM a2000030 a30 WHERE NUM_POLIZA = :NUM_POLIZA
      UNION
      SELECT COD_CIA, TIP_BENEF, TIP_DOCUM, COD_DOCUM FROM A2000060 a60 WHERE COD_CIA =1 AND NUM_POLIZA = :NUM_POLIZA AND TIP_BENEF = 21 ORDER BY 2 DESC) terc 
JOIN a1001331 a1331 ON a1331.COD_CIA=terc.COD_CIA AND a1331.TIP_DOCUM = terc.TIP_DOCUM AND a1331.COD_DOCUM = terc.COD_DOCUM
JOIN v1001390 v1390 ON v1390.COD_CIA=a1331.COD_CIA AND v1390.TIP_DOCUM = a1331.TIP_DOCUM AND v1390.COD_DOCUM = a1331.COD_DOCUM
FETCH FIRST ROW only)
SELECT a30.COD_RAMO, a1800.nom_ramo, a200.NOM_SECTOR, a1331.TIP_DOCUM, a1331.COD_DOCUM, a1331.NOM_TERCERO, a1331.NOM2_TERCERO, a1331.APE1_TERCERO, a1331.APE2_TERCERO, a1331.email, a1331.TXT_EMAIL, a1331.tlf_numero, a1331.TLF_MOVIL, a700.cod_mon, SUM(a700.imp_recibo) imp_recibo, a1331.TIP_TARJETA, a1331.COD_TARJETA, a1331.NUM_TARJETA
  FROM a2000030 a30
  JOIN A1001800 a1800 ON a1800.COD_CIA=a30.COD_CIA AND a1800.COD_RAMO = a30.COD_RAMO
  JOIN A1000200 a200 ON a200.COD_CIA=a30.COD_CIA AND a200.COD_SECTOR = a30.COD_SECTOR
  JOIN TERCEROS a1331 ON a1331.COD_CIA=a30.COD_CIA
  JOIN a2990700 a700 ON a700.COD_CIA=a30.COD_CIA AND a700.NUM_POLIZA= a30.NUM_POLIZA AND a700.num_spto = a30.num_spto AND a700.num_apli = a30.num_apli AND a700.num_poliza = a30.num_poliza AND a700.num_spto_apli = a30.num_spto_apli AND a700.NUM_RECIBO = :NUM_RECIBO AND a700.TIP_SITUACION = 'EP'
 WHERE a30.COD_CIA   = :COD_CIA
  AND a30.NUM_POLIZA = :NUM_POLIZA" + filter +
@" AND a30.mca_spto_anulado   = 'N'
  AND a30.mca_poliza_anulada = 'N'
 GROUP BY a30.COD_RAMO, a1800.nom_ramo, a200.NOM_SECTOR, a1331.TIP_DOCUM, a1331.COD_DOCUM, a1331.NOM_TERCERO, a1331.NOM2_TERCERO, a1331.APE1_TERCERO, a1331.APE2_TERCERO, a1331.email, a1331.TXT_EMAIL, a1331.tlf_numero, a1331.TLF_MOVIL, a700.cod_mon, a1331.TIP_TARJETA, a1331.COD_TARJETA, a1331.NUM_TARJETA")
                        .AddParameter("NUM_POLIZA", DbType.AnsiString, 13, num_poliza)
                        .AddParameter("NUM_POLIZA", DbType.AnsiString, 13, num_poliza)
                        .AddParameter("NUM_RECIBO", DbType.Decimal, 11, num_recibo)
                        .AddParameter("COD_CIA", DbType.Decimal, 5, cod_cia)
                        .AddParameter("NUM_POLIZA", DbType.AnsiString, 13, num_poliza)
                        .AddParameter(parameters)
                        .Query(connection, "Tron", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = new Architect.API.Tron.Contracts.Vistas.Recibo()
                            {
                                COD_RAMO = reader.IntegerValue("COD_RAMO"),
                                NOM_RAMO = reader.StringValue("NOM_RAMO"),
                                NOM_SECTOR = reader.StringValue("NOM_SECTOR"),
                                TIP_DOCUM = reader.StringValue("TIP_DOCUM"),
                                COD_DOCUM = reader.StringValue("COD_DOCUM"),
                                NOM_TERCERO = reader.StringValue("NOM_TERCERO"),
                                NOM2_TERCERO = reader.StringValue("NOM2_TERCERO"),
                                APE1_TERCERO = reader.StringValue("APE1_TERCERO"),
                                APE2_TERCERO = reader.StringValue("APE2_TERCERO"),
                                EMAIL = reader.StringValue("EMAIL"),
                                TXT_EMAIL = reader.StringValue("TXT_EMAIL"),
                                TLF_NUMERO = reader.StringValue("TLF_NUMERO"),
                                TLF_MOVIL = reader.StringValue("TLF_MOVIL"),
                                COD_MON = reader.IntegerValue("COD_MON"),
                                IMP_RECIBO = reader.DoubleValue("IMP_RECIBO"),
                                TIP_TARJETA = reader.IntegerValue("TIP_TARJETA"),
                                COD_TARJETA = reader.IntegerValue("COD_TARJETA"),
                                NUM_TARJETA = reader.StringValue("NUM_TARJETA"),
                            };
                        }));
            return result;
        }

        /// <summary>
        /// Coberturas por número de contrato de pólizas grupo o flotas.
        /// </summary>
        public static List<Contracts.Ramo.G2990026> Coberturas_por_contrato2(int cod_ramo, int num_contrato)
        {
            List<Contracts.Ramo.G2990026> result = new List<Contracts.Ramo.G2990026>();

            Database.Select("SELECT COD_COB, MCA_OBLIGATORIO " +
                             " FROM G2990026 " +
                            " WHERE COD_CIA=1" +
                              " AND COD_RAMO=:COD_RAMO" +
                              " AND NUM_CONTRATO=:NUM_CONTRATO" +
                              " AND MCA_INH = 'N'" +
                            " ORDER BY COD_COB ASC")
                .AddParameter("cod_ramo", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_ramo)
                .AddParameter("num_contrato", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_contrato)
                .Query("Tron", new Action<IDataReader>((reader) =>
                {
                    result.Add(new Contracts.Ramo.G2990026()
                    {
                        COD_COB = reader.IntegerValue("cod_cob"),
                        MCA_OBLIGATORIO = reader.StringValue("MCA_OBLIGATORIO")
                    });
                }));

            return result;
        }

        /// <summary>
        /// COBERTURAS DEL RAMO
        /// </summary>
        public static List<Architect.API.Tron.Contracts.Ramo.a1002150> Coberturas(int cod_cia, int cod_ramo, int cod_modalidad, DateTime fec_validez, string cod_cobExcludeFilter, string cod_cobincludeFilter)
        {
            List<Architect.API.Tron.Contracts.Ramo.a1002150> result = new List<Architect.API.Tron.Contracts.Ramo.a1002150>();
            string filter = string.Empty;
            string filter2 = string.Empty;

            if (!string.IsNullOrEmpty(cod_cobincludeFilter))
            {
                filter = string.Format("   AND cod_cob IN ({0})", cod_cobincludeFilter);
            }
            if (!string.IsNullOrEmpty(cod_cobExcludeFilter))
            {
                filter2 = string.Format("   AND cod_cob NOT IN ({0})", cod_cobExcludeFilter);
            }
            Database.Select("SELECT COD_COB, NOM_COB, MCA_OBLIGATORIO" +
                             " FROM a1002150" +
                            " WHERE cod_cia = :cod_cia" +
                            "   AND cod_ramo = :cod_ramo" +
                            "   AND cod_modalidad = :cod_modalidad" +
                            "   AND fec_validez <= :fec_validez" +
                            filter + filter2 +
                            " ORDER BY num_secu")
                    .AddParameter("cod_cia", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                    .AddParameter("cod_ramo", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_ramo)
                    .AddParameter("cod_modalidad", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_modalidad)
                    .AddParameter("fec_validez", Architect.DataFactory.Enumerations.DbType.Date, 7, fec_validez)
                    .Query("Tron", new Action<IDataReader>((reader) =>
                    {
                        result.Add(new Architect.API.Tron.Contracts.Ramo.a1002150()
                        {
                            NUM_POLIZA = string.Empty,
                            COD_COB = reader.IntegerValue("cod_cob"),
                            NOM_COB = reader.StringValue("nom_cob"),
                            MCA_OBLIGATORIO = reader.StringValue("MCA_OBLIGATORIO"),
                            SUMA_ASEG = 0,
                            IMP_ANUAL = 0,
                            IMP_IVA = 0,
                            IMP_FRACC = 0,
                            IMP_TOTAL = 0,
                            COD_FRANQUICIA = 0,
                            NOM_FRANQUICIA = string.Empty,
                            TXT_ERROR = string.Empty
                        });
                    }));

            return result;
        }

        /// <summary>
        /// PARAMETOS DE CONTRATOS DE POLIZAS GRUPO
        /// </summary>
        public static List<Architect.API.Tron.Contracts.Batch.p_lee_g2990000> AgenteyCuadroDeComision(int cod_cia, int cod_ramo, int num_contrato)
        {
            List<Architect.API.Tron.Contracts.Batch.p_lee_g2990000> result = new List<Architect.API.Tron.Contracts.Batch.p_lee_g2990000>();

            Database.Select("SELECT cod_agt, cod_cuadro_com" +
                             " FROM g2990000" +
                            " WHERE cod_cia = :cod_cia" +
                            "   AND cod_ramo = :cod_ramo" +
                            "   AND num_contrato = :num_contrato")
                    .AddParameter("cod_cia", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                    .AddParameter("cod_ramo", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_ramo)
                    .AddParameter("num_contrato", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_contrato)
                    .Query("Tron", new Action<IDataReader>((reader) =>
                    {
                        result.Add(new Architect.API.Tron.Contracts.Batch.p_lee_g2990000()
                        {
                            cod_agt = reader.StringValue("cod_agt"),
                            cod_cuadro_com = reader.StringValue("cod_cuadro_com")
                        });
                    }));
            return result;
        }

        /// <summary>
        /// FORMAS DE PAGO/PLANES DE PAGO DEL RAMO
        /// </summary>
        public static List<Architect.API.Tron.Contracts.Ramo.A1001403> FrecuenciaDePago(int cod_cia, int cod_ramo, int cod_mon)
        {
            List<Architect.API.Tron.Contracts.Ramo.A1001403> result = new List<Architect.API.Tron.Contracts.Ramo.A1001403>();

            Database.Select("SELECT a.cod_fracc_pago, b.nom_fracc_pago, c.pct_fracc_pago" +
                             " FROM a1001403 a" +
                             " LEFT JOIN A1001402 b" +
                               " ON b.cod_cia = a.cod_cia AND b.cod_fracc_pago=a.cod_fracc_pago" +
                             " LEFT JOIN a2990020_mcr c" +
                               " ON c.cod_cia = a.cod_cia AND c.cod_ramo=a.cod_ramo AND c.num_poliza_grupo=9999999999999 AND c.num_contrato=99999 AND (c.cod_mon = a.cod_mon OR c.cod_mon = 99) AND c.cod_fracc_pago=a.cod_fracc_pago AND c.mca_colectivo = 'N' AND nvl(c.mca_inh, 'N') = 'N'" +
                            " WHERE a.cod_cia = :cod_cia" +
                              " AND a.cod_ramo = :cod_ramo" +
                              " AND a.cod_mon = :cod_mon" +
                              " AND a.cod_fracc_pago IN (1,2,4,12)" +
                              " AND a.COD_NIVEL1 = 99 AND a.COD_NIVEL2 = 999 AND a.COD_NIVEL3 = 9999 " +
                            " ORDER BY a.cod_fracc_pago asc")
                    .AddParameter("cod_cia", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                    .AddParameter("cod_ramo", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_ramo)
                    .AddParameter("cod_mon", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_mon)
                    .Query("Tron", new Action<IDataReader>((reader) =>
                    {
                        result.Add(new Architect.API.Tron.Contracts.Ramo.A1001403()
                        {
                            cod_fracc_pago = reader.IntegerValue("cod_fracc_pago"),
                            nom_fracc_pago = reader.StringValue("nom_fracc_pago"),
                            pct_fracc_pago = reader.DoubleValue("pct_fracc_pago")
                        });
                    }));

            return result;
        }

        public static List<Contracts.Ramo.A1001403> MM_FrecuenciaDePago(double primaAnual, string num_poliza_grupo, int num_contrato)
        {
            List<Contracts.Ramo.A1001403> result = new List<Contracts.Ramo.A1001403>();

            if (num_poliza_grupo == null)
                num_poliza_grupo = string.Empty;
            if (num_contrato == 0)
                num_contrato = int.MinValue;

            //em_k_cotizador_web_302_mcr.p_genera_fraccionamiento_pago

            Database.Select(@"
      SELECT a.cod_ramo,
             a.cod_mon,
             a.num_poliza_grupo,
             a.num_contrato,
             a.cod_fracc_pago,
             b.nom_fracc_pago,
             a.pct_fracc_pago,
             :P_PRIMA_ANUAL * a.pct_fracc_pago / 100 MONTO_RECARGO
      FROM   a2990020_mcr a, A1001402 b
      WHERE  a.cod_cia = 1
      AND    (a.num_poliza_grupo IN (:P_NUM_POLIZA_GRUPO, '9999999999999'))
      AND    (a.num_contrato IN (:NUM_CONTRATO, 99999))
      AND    a.cod_ramo = 302
      AND    a.cod_mon = 1 --OR  a.cod_mon = 99 or  a.cod_mon = 2)
      AND    a.cod_fracc_pago IN (1, 2, 4, 6, 12)
      AND    a.mca_colectivo = 'N'
      AND    nvl(a.mca_inh, 'N') = 'N'
      AND    a.cod_cia = b.cod_cia
      AND    a.cod_fracc_pago = b.cod_fracc_pago
      ORDER  BY a.cod_fracc_pago, a.cod_mon ASC")
                    .AddParameter("P_PRIMA_ANUAL", DbType.Double, 22, primaAnual)
                    .AddParameter("P_NUM_POLIZA_GRUPO", DbType.String, 13, num_poliza_grupo)
                    .AddParameter("NUM_CONTRATO", DbType.Int32, 22, num_contrato)
                    .Query("Tron", new Action<IDataReader>((reader) =>
                    {
                        result.Add(new Contracts.Ramo.A1001403()
                        {
                            cod_fracc_pago = reader.IntegerValue("cod_fracc_pago"),
                            nom_fracc_pago = reader.StringValue("nom_fracc_pago"),
                            pct_fracc_pago = reader.DoubleValue("pct_fracc_pago"),
                            monto_recargo = reader.DoubleValue("monto_recargo")
                        });
                    }));

            return result;
        }

        public static List<Architect.API.Tron.Contracts.Ramo.ta301003> AutomobileCoverageSelection(int cod_cia, string num_poliza_grupo, int num_contrato, int num_subcontrato, int cod_ramo, int cod_mon, int cod_marca, int cod_modelo, int anio_sub_modelo, int cod_tip_vehi, int cod_uso_vehi, int mca_sexo, int cod_zona_circul, int edad, int cod_plan_auto, int tip_valoracion)
        {
            List<Architect.API.Tron.Contracts.Ramo.ta301003> result = new List<Architect.API.Tron.Contracts.Ramo.ta301003>();

            Database.Select("SELECT DISTINCT a.cod_cob, a.mca_obligatoria " +
                              "FROM ta301003 a " +
                             "WHERE a.cod_cia = :cod_cia " +
                               "AND a.num_poliza_grupo IN (:num_poliza_grupo, '9999999999999') " +
                               "AND a.num_contrato IN (:num_contrato, '99999') " +
                               "AND a.num_subcontrato IN (:num_subcontrato, '99999') " +
                               "AND a.cod_marca IN (:cod_marca, '999') " +
                               "AND a.cod_modelo IN (:cod_modelo, '999') " +
                               "AND a.cod_sub_modelo IN ('999') " +
                               "AND a.anio IN (:anio_veh ,'9999') " +
                               "AND a.cod_tip_vehi IN (:cod_tip_vehi, '999') " +
                               "AND a.cod_uso_vehi IN (:cod_uso_vehi, '999') " +
                               "AND a.mca_sexo IN (:mca_sexo, '9') " +
                               "AND a.cod_zona_circul  IN (:cod_zona_circul, '9999') " +
                               "AND :edad BETWEEN a.edad_desde AND a.edad_hasta " +
                               "AND a.cod_ramo = :cod_ramo " +
                               "AND a.cod_plan = :cod_plan " +
                               "AND a.cod_mon  = :cod_mon " +
                               "AND a.tip_valoracion  = :tip_valoracion " +
                               "AND a.mca_inh = 'N' " +
                               "AND a.fec_validez <= SYSDATE " +
                            "ORDER BY a.cod_cob")
                    .AddParameter("cod_cia", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                    .AddParameter("num_poliza_grupo", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza_grupo)
                    .AddParameter("num_contrato", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_contrato)
                    .AddParameter("num_subcontrato", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_subcontrato)
                    .AddParameter("cod_marca", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_marca)
                    .AddParameter("cod_modelo", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_modelo)
                    .AddParameter("anio_veh", Architect.DataFactory.Enumerations.DbType.Int32, 22, anio_sub_modelo)
                    .AddParameter("cod_tip_vehi", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_tip_vehi)
                    .AddParameter("cod_uso_vehi", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_uso_vehi)
                    .AddParameter("mca_sexo", Architect.DataFactory.Enumerations.DbType.String, 1, mca_sexo.ToString())
                    .AddParameter("cod_zona_circul", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_zona_circul)
                    .AddParameter("edad", Architect.DataFactory.Enumerations.DbType.Int32, 22, edad)
                    .AddParameter("cod_ramo", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_ramo)
                    .AddParameter("cod_plan", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_plan_auto)
                    .AddParameter("cod_mon", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_mon)
                    .AddParameter("tip_valoracion", Architect.DataFactory.Enumerations.DbType.Int32, 22, tip_valoracion)
                    .Query("Tron", new Action<IDataReader>((reader) =>
                    {
                        result.Add(new Architect.API.Tron.Contracts.Ramo.ta301003()
                        {
                            mca_obligatoria = reader.StringValue("mca_obligatoria"),
                            cod_cob = reader.IntegerValue("cod_cob")
                        });
                    }));

            return result;
        }

        public static void Execute()
        {
            //IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron");
            //Database.Procedure("dc_k_consulta_web.p_devuelve_consulta")
            //                               .AddParameter("p_cod_cia", Architect.DataFactory.Enumerations.DbType.Int32, 22, 1)
            //                               .AddParameter("p_session_id", Architect.DataFactory.Enumerations.DbType.String, 0, "9999999")
            //                               .AddParameter("p_cod_usr", Architect.DataFactory.Enumerations.DbType.String, 0, null)
            //                               .AddParameter("p_tip_parametro", Architect.DataFactory.Enumerations.DbType.String, 0, "D")
            //                               .AddParameter("p_tip_docum", Architect.DataFactory.Enumerations.DbType.String, 0, "CJU")
            //                               .AddParameter("p_parametro", Architect.DataFactory.Enumerations.DbType.String, 0, "3101118990")
            //                               .AddParameter("p_rol_usr_web", Architect.DataFactory.Enumerations.DbType.String, 0, null)
            //                               .AddParameter("p_grupo_cliente", Architect.DataFactory.Enumerations.DbType.String, 0, null)
            //                               .AddParameter("p_dev_consulta", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
            //                               .AddParameter("p_errores", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
            //                               .Query(currentConnection, new Action<IDataReader>((reader) =>
            //                               {
            //                                   salida = reader.StringValue("nom_cob");
            //                               }));
            //DataTable data = Database.Procedure("dc_k_consulta_web.p_devuelve_consulta")
            //                                .AddParameter("p_cod_cia", Architect.DataFactory.Enumerations.DbType.Int32, 22, 1)
            //                                .AddParameter("p_session_id", Architect.DataFactory.Enumerations.DbType.String, 0, "9999999")
            //                                .AddParameter("p_cod_usr", Architect.DataFactory.Enumerations.DbType.String, 0, null)
            //                                .AddParameter("p_tip_parametro", Architect.DataFactory.Enumerations.DbType.String, 0, "D")
            //                                .AddParameter("p_tip_docum", Architect.DataFactory.Enumerations.DbType.String, 0, "CJU")
            //                                .AddParameter("p_parametro", Architect.DataFactory.Enumerations.DbType.String, 0, "3101118990")
            //                                .AddParameter("p_rol_usr_web", Architect.DataFactory.Enumerations.DbType.String, 0, null)
            //                                .AddParameter("p_grupo_cliente", Architect.DataFactory.Enumerations.DbType.String, 0, null)
            //                                .AddParameter("p_dev_consulta", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
            //                                .AddParameter("p_errores", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
            //                                .Query("Tron");



            //DataTable data = Database.Procedure("DC_K_CONSULTA_WEB.P_DEVUELVE_DETALLE_RIESGO")
            //                                .AddParameter("p_cod_cia", Architect.DataFactory.Enumerations.DbType.Int32, 0, 1)
            //                                .AddParameter("p_session_id", Architect.DataFactory.Enumerations.DbType.String, 0, "9999999")
            //                                .AddParameter("P_COD_USR", Architect.DataFactory.Enumerations.DbType.String, 0, null)
            //                                .AddParameter("NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 0, "3021810101880")
            //                                .AddParameter("P_NUM_RIESGO", Architect.DataFactory.Enumerations.DbType.Int32, 0, 1)
            //                                .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 0, null)
            //                                .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 0, null)
            //                                .AddParameter("p_num_riesgo_out", Architect.DataFactory.Enumerations.DbType.Int32, 0, null, ParameterDirection.Output)
            //                                .AddParameter("p_nom_tomador", Architect.DataFactory.Enumerations.DbType.String, 256, null, ParameterDirection.Output)
            //                                .AddParameter("p_nom_riesgo", Architect.DataFactory.Enumerations.DbType.String, 256, null, ParameterDirection.Output)
            //                                .AddParameter("p_mca_baja_riesgo", Architect.DataFactory.Enumerations.DbType.String, 256, null, ParameterDirection.Output)
            //                                .AddParameter("p_mca_vigente", Architect.DataFactory.Enumerations.DbType.String, 256, null, ParameterDirection.Output)
            //                                .AddParameter("p_cursor_cobertura", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
            //                                .AddParameter("p_datos_prima", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
            //                                .AddParameter("p_errores", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
            //                                .Query(null, "Tron");

            //currentConnection.Close();
        }

        /// </summary>
        public static int FrecuenciaDePagoPorContrato(int cod_cia, int cod_ramo, int num_contrato, int cod_agt)
        {
            int result = 0;

            Database.Select("SELECT cod_fracc_pago" +
                             " FROM g2990000" +
                            " WHERE cod_cia = :cod_cia" +
                            "   AND cod_ramo = :cod_ramo" +
                            "   AND num_contrato = :num_contrato" +
                            "   AND cod_agt = :cod_agt")
                    .AddParameter("cod_cia", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                    .AddParameter("cod_ramo", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_ramo)
                    .AddParameter("num_contrato", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_contrato)
                    .AddParameter("cod_agt", DbType.Decimal, 5, cod_agt)
                    .Query("Tron", new Action<IDataReader>((reader) =>
                    {
                        result = reader.IntegerValue("cod_fracc_pago");
                    }));
            return result;
        }

        /// <summary>
        /// em_k_tables_contract_mcr.retrieve_a1002150
        /// </summary>
        public static List<LookUpValue> CoberturasPorRamo(int cod_cia, int cod_ramo, int cod_modalidad, string cob_ExcludeFilter, string excluir_comercial, string poliza_grupo, IDbConnection connection = null)
        {
            List<LookUpValue> result = new List<LookUpValue>();

            string p_cob_ExcludeFilter = "";
            string p_cob_IncludeFilter = "";

            if (!String.IsNullOrEmpty(cob_ExcludeFilter))
            {
                p_cob_ExcludeFilter = cob_ExcludeFilter;
            }
            if (!String.IsNullOrEmpty(excluir_comercial))
            {
                p_cob_ExcludeFilter += "," + excluir_comercial;
            }
            if (!String.IsNullOrEmpty(poliza_grupo))
            {
                p_cob_IncludeFilter = poliza_grupo;
            }

            Database.Procedure("em_k_tables_contract_mcr.retrieve_a1002150")
                .AddParameter("p_cod_cia", DbType.Int32, 22, cod_cia)
                .AddParameter("p_cod_ramo", DbType.Int32, 22, cod_ramo)
                .AddParameter("p_cod_modalidad", DbType.Int32, 22, cod_modalidad)
                .AddParameter("p_fec_validez", DbType.String, 18, DateTime.Now.ToString("yyyyMMdd"))
                .AddParameter("p_cob_ExcludeFilter", DbType.String, 512, p_cob_ExcludeFilter)
                .AddParameter("p_cob_IncludeFilter", DbType.String, 512, p_cob_IncludeFilter)
                .AddParameter("RC1", DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                .Query(null, "Tron", new Action<IDataReader>((reader) =>
                {
                    result.Add(new LookUpValue()
                    {
                        Code = reader.IntegerValue("COD_COB").ToString(),
                        Description = reader.StringValue("NOM_COB")
                    });
                }));
            return result;
        }

        /// <summary>
        /// Realiza el cambio de tarjeta para el cliente de una póliza.
        /// </summary>
        public static Contracts.Batch.Respuesta p_cambio_tarjeta(int cod_cia, string session_id, string json, IDbConnection connection = null)
        {
            Contracts.Batch.Respuesta result = new Contracts.Batch.Respuesta();

            Database.Procedure("gc_k_cambiar_tarjeta_web_mcr.p_cambio_tarjeta_net")
                    .AddParameter("p_cod_cia", DbType.Int32, 22, cod_cia)
                    .AddParameter("p_session_id", DbType.String, 13, session_id)
                    .AddParameter("p_array", DbType.String, 4000, json)
                    .Query(connection, "Tron", new Action<IDataReader>((reader) =>
                    {
                        result = new Contracts.Batch.Respuesta()
                        {
                            codigo_respuesta = reader.StringValue("codigo_respuesta"),
                            mensaje_respuesta = reader.StringValue("mensaje_respuesta"),
                            id_report = reader.StringValue("id_report")
                        };
                    }));
            return result;
        }




        public static string p_reemplaza_benef(int cod_cia, string numPolizaGrupo, string numPoliza, int numRiesgo, string tipDocum, string codDocum, IDbConnection connection = null)
        {
            string result = string.Empty;
            Database.Procedure("em_k_cambio_benef_est_mcr.p_reemplaza_benef")
                    .AddParameter("p_cod_cia", DbType.Int32, 22, cod_cia)
                    .AddParameter("p_num_poliza_grupo", DbType.String, 13, numPolizaGrupo)
                    .AddParameter("p_num_poliza", DbType.String, 13, numPoliza)
                    .AddParameter("p_num_riesgo", DbType.Int32, 22, numRiesgo)
                    .AddParameter("p_tip_benef", Architect.DataFactory.Enumerations.DbType.String, 2, "21")
                    .AddParameter("p_tip_docum", Architect.DataFactory.Enumerations.DbType.String, 3, tipDocum)
                    .AddParameter("p_cod_docum", Architect.DataFactory.Enumerations.DbType.String, 20, codDocum)
                    .AddParameter("p_mca_ejecuta_batch", Architect.DataFactory.Enumerations.DbType.String, 1, "S")
                    .AddParameter("p_mca_primer_ep", Architect.DataFactory.Enumerations.DbType.String, 1, "N")
                    .AddParameter("p_msj_salida", DbType.RefCursor, 0, null, ParameterDirection.Output)
                    .AddParameter("p_errores", DbType.RefCursor, 0, null, ParameterDirection.Output)
                    .Query(connection, "Tron", new Action<System.Data.IDataReader, string>((reader, key) =>
                    {
                        switch (key)
                        {
                            case "p_msj_salida":
                                 result = reader.GetValue(0).ToString();
                                break;
                            case "p_errores":
                                 result = reader.GetValue(0).ToString();
                                break;
                        }
                    }));

            return result;
        }
    }
}