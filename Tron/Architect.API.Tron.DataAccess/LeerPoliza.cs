using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;

namespace Architect.API.Tron.DataAccess
{
    /// <summary>
    /// Funciones para el cotizador web para la lectura de pólizas (EM_K_MAPFRE_BATCH_CONTRACT_MCR).
    /// </summary>
    public static class LeerPoliza
    {

        public static Architect.API.Tron.Contracts.Poliza.DatoFijo Poliza(int cod_cia, string num_poliza, int num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection, bool loadChilds = false, string filter = "full")
        {
            Architect.API.Tron.Contracts.Poliza.DatoFijo a2000030Instance = PP_Lee_A2000030(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);

            if (a2000030Instance!= null && loadChilds)
            {
                if (filter == "full")
                {
                    a2000030Instance.Riesgos = PP_Lee_A2000031(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);
                    a2000030Instance.DatosVariables = PP_Lee_A2000020(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);
                    a2000030Instance.Ocurrencias = PP_Lee_A2000025(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);
                    a2000030Instance.DesgloseEconomico = PP_Lee_A2100170(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);
                    a2000030Instance.Coberturas = PP_Lee_A2000040(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);
                    a2000030Instance.Terceros = PP_Lee_A2000060(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);
                    a2000030Instance.Recibos = PP_Lee_A2990700(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);
                }

                if (filter == "full" || filter == "onlyresult")
                {
                    a2000030Instance.Calculado = new Contracts.Poliza.Calculado()
                    {
                        Coberturas = PP_Lee_A2000040_Result(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection),
                        Recibos = PP_Lee_A2990700_Result(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection)
                    };
                }
            }
            return a2000030Instance;
        }

        public static Architect.API.Tron.Contracts.Poliza.DatoFijo PolizaVariaciones(int cod_cia, string num_poliza, int? num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection, bool loadChilds = false, string filter = "full")
        {
            Architect.API.Tron.Contracts.Poliza.DatoFijo a2000030Instance = PP_Lee_A2000030(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);

            if (a2000030Instance != null && loadChilds)
            {
                if (filter == "full")
                {
                    //a2000030Instance.Riesgos = PP_Lee_A2000031(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);
                    a2000030Instance.DatosVariables = PP_Lee_A2000020(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);
                    //a2000030Instance.Ocurrencias = PP_Lee_A2000025(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);
                    //a2000030Instance.DesgloseEconomico = PP_Lee_A2100170(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);
                    a2000030Instance.Coberturas = PP_Lee_A2000040_ZA(cod_cia, num_poliza, currentConnection);
                    //a2000030Instance.Coberturas = PP_Lee_A2000040(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);
                    a2000030Instance.Terceros = PP_Lee_A2000060_ZA(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);
                    a2000030Instance.Recibos = PP_Lee_A2990700(cod_cia, num_poliza, null, num_apli, num_spto_apli, currentConnection);
                }

                if (filter == "full" || filter == "onlyresult")
                {
                    a2000030Instance.Calculado = new Contracts.Poliza.Calculado()
                    {
                        //Coberturas = PP_Lee_A2000040_Result(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection),
                        Recibos = PP_Lee_A2990700_Result_ZA(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection)
                    };
                }
            }
            return a2000030Instance;
        }

        /// <summary>
        /// Datos fijos de la póliza
        /// </summary>
        private static Architect.API.Tron.Contracts.Poliza.DatoFijo PP_Lee_A2000030(int cod_cia, string num_poliza, int num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection)
        {
            Architect.API.Tron.Contracts.Poliza.DatoFijo result = null;
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2000030")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto_apli)
                                           .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                                           .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                                           {
                                               result = new Architect.API.Tron.Contracts.Poliza.DatoFijo()
                                               {
                                                   cod_cia = reader.IntegerValue("cod_cia"),
                                                   cod_sector = reader.IntegerValue("cod_sector"),
                                                   cod_ramo = reader.IntegerValue("cod_ramo"),
                                                   num_poliza = reader.StringValue("num_poliza"),
                                                   num_spto = reader.IntegerValue("num_spto"),
                                                   num_apli = reader.IntegerValue("num_apli"),
                                                   num_spto_apli = reader.IntegerValue("num_spto_apli"),
                                                   fec_validez = reader.DateTimeValue("fec_validez"),
                                                   fec_emision = reader.DateTimeValue("fec_emision"),
                                                   fec_emision_spto = reader.DateTimeValue("fec_emision_spto"),
                                                   fec_efec_poliza = reader.DateTimeValue("fec_efec_poliza"),
                                                   fec_vcto_poliza = reader.DateTimeValue("fec_vcto_poliza"),
                                                   fec_efec_spto = reader.DateTimeValue("fec_efec_spto"),
                                                   fec_vcto_spto = reader.DateTimeValue("fec_vcto_spto"),
                                                   tip_duracion = reader.IntegerValue("tip_duracion"),
                                                   num_riesgos = reader.IntegerValue("num_riesgos"),
                                                   cod_mon = reader.IntegerValue("cod_mon"),
                                                   cod_fracc_pago = reader.IntegerValue("cod_fracc_pago"),
                                                   cant_renovaciones = reader.IntegerValue("cant_renovaciones"),
                                                   num_renovaciones = reader.IntegerValue("num_renovaciones"),
                                                   tip_coaseguro = reader.IntegerValue("tip_coaseguro"),
                                                   num_presupuesto = reader.StringValue("num_presupuesto"),
                                                   num_poliza_anterior = reader.StringValue("num_poliza_anterior"),
                                                   num_poliza_cliente = reader.StringValue("num_poliza_cliente"),
                                                   num_contrato = reader.IntegerValue("num_contrato"),
                                                   num_poliza_grupo = reader.StringValue("num_poliza_grupo"),
                                                   num_secu_grupo = reader.IntegerValue("num_secu_grupo"),
                                                   cod_spto = reader.IntegerValue("cod_spto"),
                                                   sub_cod_spto = reader.IntegerValue("sub_cod_spto"),
                                                   cod_tip_spto = reader.StringValue("cod_tip_spto"),
                                                   tip_spto = reader.StringValue("tip_spto"),
                                                   txt_motivo_spto = reader.StringValue("txt_motivo_spto"),
                                                   tip_docum = reader.StringValue("tip_docum"),
                                                   cod_docum = reader.StringValue("cod_docum"),
                                                   cod_cuadro_com = reader.IntegerValue("cod_cuadro_com"),
                                                   cod_agt = reader.IntegerValue("cod_agt"),
                                                   pct_agt = reader.IntegerValue("pct_agt"),
                                                   cod_org = reader.IntegerValue("cod_org"),
                                                   cod_asesor = reader.IntegerValue("cod_asesor"),
                                                   cod_nivel1 = reader.IntegerValue("cod_nivel1"),
                                                   cod_nivel2 = reader.IntegerValue("cod_nivel2"),
                                                   cod_nivel3 = reader.IntegerValue("cod_nivel3"),
                                                   cod_compensacion = reader.IntegerValue("cod_compensacion"),
                                                   tip_gestor = reader.StringValue("tip_gestor"),
                                                   cod_gestor = reader.StringValue("cod_gestor"),
                                                   mca_regulariza = reader.StringValue("mca_regulariza"),
                                                   tip_regulariza = reader.StringValue("tip_regulariza"),
                                                   pct_regulariza = reader.IntegerValue("pct_regulariza"),
                                                   cod_indice = reader.IntegerValue("cod_indice"),
                                                   anios_max_duracion = reader.IntegerValue("anios_max_duracion"),
                                                   meses_max_duracion = reader.IntegerValue("meses_max_duracion"),
                                                   dias_max_duracion = reader.IntegerValue("dias_max_duracion"),
                                                   cod_agt2 = reader.IntegerValue("cod_agt2"),
                                                   pct_agt2 = reader.IntegerValue("pct_agt2"),
                                                   cod_agt3 = reader.IntegerValue("cod_agt3"),
                                                   pct_agt3 = reader.IntegerValue("pct_agt3"),
                                                   cod_agt4 = reader.IntegerValue("cod_agt4"),
                                                   pct_agt4 = reader.IntegerValue("pct_agt4"),
                                                   duracion_pago_prima = reader.IntegerValue("duracion_pago_prima"),
                                                   cod_envio = reader.StringValue("cod_envio"),
                                                   cod_ejecutivo = reader.IntegerValue("cod_ejecutivo"),
                                                   mca_tomadores_alt = reader.StringValue("mca_tomadores_alt"),
                                                   mca_reaseguro_manual = reader.StringValue("mca_reaseguro_manual"),
                                                   mca_prorrata = reader.StringValue("mca_prorrata"),
                                                   mca_prima_manual = reader.StringValue("mca_prima_manual"),
                                                   mca_provisional = reader.StringValue("mca_provisional"),
                                                   fec_autorizacion = reader.DateTimeValue("fec_autorizacion"),
                                                   mca_poliza_anulada = reader.StringValue("mca_poliza_anulada"),
                                                   mca_spto_anulado = reader.StringValue("mca_spto_anulado"),
                                                   num_spto_anulado = reader.IntegerValue("num_spto_anulado"),
                                                   fec_spto_anulado = reader.DateTimeValue("fec_spto_anulado"),
                                                   mca_spto_tmp = reader.StringValue("mca_spto_tmp"),
                                                   mca_datos_minimos = reader.StringValue("mca_datos_minimos"),
                                                   mca_impresion = reader.StringValue("mca_impresion"),
                                                   mca_exclusivo = reader.StringValue("mca_exclusivo"),
                                                   cod_usr = reader.StringValue("cod_usr"),
                                                   cod_nivel3_captura = reader.IntegerValue("cod_nivel3_captura"),
                                                   fec_actu = reader.DateTimeValue("fec_actu"),
                                                   mca_reaseguro_marco = reader.StringValue("mca_reaseguro_marco"),
                                                   tip_poliza_tr = reader.StringValue("tip_poliza_tr"),
                                                   num_poliza_siguiente = reader.StringValue("num_poliza_siguiente"),
                                                   cod_dst_agt = reader.IntegerValue("cod_dst_agt"),
                                                   cod_cuadro_coa = reader.StringValue("cod_cuadro_coa"),
                                                   tip_rea = reader.StringValue("tip_rea"),
                                                   num_spto_publico = reader.IntegerValue("num_spto_publico"),
                                                   val_mca_int = reader.StringValue("val_mca_int"),
                                                   hora_desde = reader.StringValue("hora_desde"),
                                                   num_subcontrato = reader.IntegerValue("num_subcontrato"),
                                                   cod_negocio = reader.StringValue("cod_negocio"),
                                                   num_secu_cta_tar = reader.IntegerValue("num_secu_cta_tar")
                                               };
                                           }));
            return result;
        }

        /// <summary>
        /// Datos fijos de la póliza
        /// </summary>
        private static Architect.API.Tron.Contracts.Poliza.DatoFijo PP_Lee_A2000030(int cod_cia, string num_poliza, int? num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection)
        {
            Architect.API.Tron.Contracts.Poliza.DatoFijo result = null;
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2000030")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto_apli)
                                           .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                                           .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                                           {
                                               result = new Architect.API.Tron.Contracts.Poliza.DatoFijo()
                                               {
                                                   cod_cia = reader.IntegerValue("cod_cia"),
                                                   cod_sector = reader.IntegerValue("cod_sector"),
                                                   cod_ramo = reader.IntegerValue("cod_ramo"),
                                                   num_poliza = reader.StringValue("num_poliza"),
                                                   num_spto = reader.IntegerValue("num_spto"),
                                                   num_apli = reader.IntegerValue("num_apli"),
                                                   num_spto_apli = reader.IntegerValue("num_spto_apli"),
                                                   fec_validez = reader.DateTimeValue("fec_validez"),
                                                   fec_emision = reader.DateTimeValue("fec_emision"),
                                                   fec_emision_spto = reader.DateTimeValue("fec_emision_spto"),
                                                   fec_efec_poliza = reader.DateTimeValue("fec_efec_poliza"),
                                                   fec_vcto_poliza = reader.DateTimeValue("fec_vcto_poliza"),
                                                   fec_efec_spto = reader.DateTimeValue("fec_efec_spto"),
                                                   fec_vcto_spto = reader.DateTimeValue("fec_vcto_spto"),
                                                   tip_duracion = reader.IntegerValue("tip_duracion"),
                                                   num_riesgos = reader.IntegerValue("num_riesgos"),
                                                   cod_mon = reader.IntegerValue("cod_mon"),
                                                   cod_fracc_pago = reader.IntegerValue("cod_fracc_pago"),
                                                   cant_renovaciones = reader.IntegerValue("cant_renovaciones"),
                                                   num_renovaciones = reader.IntegerValue("num_renovaciones"),
                                                   tip_coaseguro = reader.IntegerValue("tip_coaseguro"),
                                                   num_presupuesto = reader.StringValue("num_presupuesto"),
                                                   num_poliza_anterior = reader.StringValue("num_poliza_anterior"),
                                                   num_poliza_cliente = reader.StringValue("num_poliza_cliente"),
                                                   num_contrato = reader.IntegerValue("num_contrato"),
                                                   num_poliza_grupo = reader.StringValue("num_poliza_grupo"),
                                                   num_secu_grupo = reader.IntegerValue("num_secu_grupo"),
                                                   cod_spto = reader.IntegerValue("cod_spto"),
                                                   sub_cod_spto = reader.IntegerValue("sub_cod_spto"),
                                                   cod_tip_spto = reader.StringValue("cod_tip_spto"),
                                                   tip_spto = reader.StringValue("tip_spto"),
                                                   txt_motivo_spto = reader.StringValue("txt_motivo_spto"),
                                                   tip_docum = reader.StringValue("tip_docum"),
                                                   cod_docum = reader.StringValue("cod_docum"),
                                                   cod_cuadro_com = reader.IntegerValue("cod_cuadro_com"),
                                                   cod_agt = reader.IntegerValue("cod_agt"),
                                                   pct_agt = reader.IntegerValue("pct_agt"),
                                                   cod_org = reader.IntegerValue("cod_org"),
                                                   cod_asesor = reader.IntegerValue("cod_asesor"),
                                                   cod_nivel1 = reader.IntegerValue("cod_nivel1"),
                                                   cod_nivel2 = reader.IntegerValue("cod_nivel2"),
                                                   cod_nivel3 = reader.IntegerValue("cod_nivel3"),
                                                   cod_compensacion = reader.IntegerValue("cod_compensacion"),
                                                   tip_gestor = reader.StringValue("tip_gestor"),
                                                   cod_gestor = reader.StringValue("cod_gestor"),
                                                   mca_regulariza = reader.StringValue("mca_regulariza"),
                                                   tip_regulariza = reader.StringValue("tip_regulariza"),
                                                   pct_regulariza = reader.IntegerValue("pct_regulariza"),
                                                   cod_indice = reader.IntegerValue("cod_indice"),
                                                   anios_max_duracion = reader.IntegerValue("anios_max_duracion"),
                                                   meses_max_duracion = reader.IntegerValue("meses_max_duracion"),
                                                   dias_max_duracion = reader.IntegerValue("dias_max_duracion"),
                                                   cod_agt2 = reader.IntegerValue("cod_agt2"),
                                                   pct_agt2 = reader.IntegerValue("pct_agt2"),
                                                   cod_agt3 = reader.IntegerValue("cod_agt3"),
                                                   pct_agt3 = reader.IntegerValue("pct_agt3"),
                                                   cod_agt4 = reader.IntegerValue("cod_agt4"),
                                                   pct_agt4 = reader.IntegerValue("pct_agt4"),
                                                   duracion_pago_prima = reader.IntegerValue("duracion_pago_prima"),
                                                   cod_envio = reader.StringValue("cod_envio"),
                                                   cod_ejecutivo = reader.IntegerValue("cod_ejecutivo"),
                                                   mca_tomadores_alt = reader.StringValue("mca_tomadores_alt"),
                                                   mca_reaseguro_manual = reader.StringValue("mca_reaseguro_manual"),
                                                   mca_prorrata = reader.StringValue("mca_prorrata"),
                                                   mca_prima_manual = reader.StringValue("mca_prima_manual"),
                                                   mca_provisional = reader.StringValue("mca_provisional"),
                                                   fec_autorizacion = reader.DateTimeValue("fec_autorizacion"),
                                                   mca_poliza_anulada = reader.StringValue("mca_poliza_anulada"),
                                                   mca_spto_anulado = reader.StringValue("mca_spto_anulado"),
                                                   num_spto_anulado = reader.IntegerValue("num_spto_anulado"),
                                                   fec_spto_anulado = reader.DateTimeValue("fec_spto_anulado"),
                                                   mca_spto_tmp = reader.StringValue("mca_spto_tmp"),
                                                   mca_datos_minimos = reader.StringValue("mca_datos_minimos"),
                                                   mca_impresion = reader.StringValue("mca_impresion"),
                                                   mca_exclusivo = reader.StringValue("mca_exclusivo"),
                                                   cod_usr = reader.StringValue("cod_usr"),
                                                   cod_nivel3_captura = reader.IntegerValue("cod_nivel3_captura"),
                                                   fec_actu = reader.DateTimeValue("fec_actu"),
                                                   mca_reaseguro_marco = reader.StringValue("mca_reaseguro_marco"),
                                                   tip_poliza_tr = reader.StringValue("tip_poliza_tr"),
                                                   num_poliza_siguiente = reader.StringValue("num_poliza_siguiente"),
                                                   cod_dst_agt = reader.IntegerValue("cod_dst_agt"),
                                                   cod_cuadro_coa = reader.StringValue("cod_cuadro_coa"),
                                                   tip_rea = reader.StringValue("tip_rea"),
                                                   num_spto_publico = reader.IntegerValue("num_spto_publico"),
                                                   val_mca_int = reader.StringValue("val_mca_int"),
                                                   hora_desde = reader.StringValue("hora_desde"),
                                                   num_subcontrato = reader.IntegerValue("num_subcontrato"),
                                                   cod_negocio = reader.StringValue("cod_negocio"),
                                                   num_secu_cta_tar = reader.IntegerValue("num_secu_cta_tar")
                                               };
                                           }));
            return result;
        }

        /// <summary>
        ///  Riesgos de la póliza
        /// </summary>
        private static List<Architect.API.Tron.Contracts.Poliza.Riesgo> PP_Lee_A2000031(int cod_cia, string num_poliza, int num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection)
        {
            List<Architect.API.Tron.Contracts.Poliza.Riesgo> result = new List<Architect.API.Tron.Contracts.Poliza.Riesgo>();
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2000031")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto_apli)
                                           .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                                           .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                                           {
                                               result.Add(new Architect.API.Tron.Contracts.Poliza.Riesgo()
                                               {
                                                   cod_cia = reader.IntegerValue("cod_cia"),
                                                   num_poliza = reader.StringValue("num_poliza"),
                                                   num_spto = reader.IntegerValue("num_spto"),
                                                   num_apli = reader.IntegerValue("num_apli"),
                                                   num_spto_apli = reader.IntegerValue("num_spto_apli"),
                                                   num_riesgo = reader.IntegerValue("num_riesgo"),
                                                   tip_spto = reader.StringValue("tip_spto"),
                                                   cod_modalidad = reader.IntegerValue("cod_modalidad"),
                                                   nom_riesgo = reader.StringValue("nom_riesgo"),
                                                   fec_efec_riesgo = reader.DateTimeValue("fec_efec_riesgo"),
                                                   fec_vcto_riesgo = reader.DateTimeValue("fec_vcto_riesgo"),
                                                   mca_baja_riesgo = reader.StringValue("mca_baja_riesgo"),
                                                   mca_vigente = reader.StringValue("mca_vigente"),
                                                   mca_exclusivo = reader.StringValue("mca_exclusivo"),
                                                   cod_usr_exclusivo = reader.StringValue("cod_usr_exclusivo"),
                                                   num_certificado = reader.IntegerValue("num_certificado"),
                                                   nom_certificado = reader.StringValue("nom_certificado")
                                               });
                                           }));
            return result;
        }

        /// <summary>
        ///  Datos variables de la póliza
        /// </summary>
        private static List<Architect.API.Tron.Contracts.Poliza.DatoVariable> PP_Lee_A2000020(int cod_cia, string num_poliza, int num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection)
        {
            List<Architect.API.Tron.Contracts.Poliza.DatoVariable> result = new List<Architect.API.Tron.Contracts.Poliza.DatoVariable>();
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2000020")
                .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_apli)
                .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto_apli)
                .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                {
                    result.Add(new Architect.API.Tron.Contracts.Poliza.DatoVariable()
                    {
                        cod_cia = reader.IntegerValue("cod_cia"),
                        num_poliza = reader.StringValue("num_poliza"),
                        num_spto = reader.IntegerValue("num_spto"),
                        num_apli = reader.IntegerValue("num_apli"),
                        num_spto_apli = reader.IntegerValue("num_spto_apli"),
                        num_riesgo = reader.IntegerValue("num_riesgo"),
                        num_periodo = reader.IntegerValue("num_periodo"),
                        tip_nivel = reader.IntegerValue("tip_nivel"),
                        cod_campo = reader.StringValue("cod_campo"),
                        val_campo = reader.StringValue("val_campo"),
                        val_cor_campo = reader.StringValue("val_cor_campo"),
                        num_secu = reader.IntegerValue("num_secu"),
                        txt_campo = reader.StringValue("txt_campo"),
                        mca_baja_riesgo = reader.StringValue("mca_baja_riesgo"),
                        mca_vigente = reader.StringValue("mca_vigente"),
                        mca_vigente_apli = reader.StringValue("mca_vigente_apli"),
                        cod_ramo = reader.IntegerValue("cod_ramo")
                    });
                }));
            return result;
        }

        /// <summary>
        ///  Datos variables de la póliza
        /// </summary>
        private static List<Architect.API.Tron.Contracts.Poliza.DatoVariable> PP_Lee_A2000020(int cod_cia, string num_poliza, int? num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection)
        {
            List<Architect.API.Tron.Contracts.Poliza.DatoVariable> result = new List<Architect.API.Tron.Contracts.Poliza.DatoVariable>();
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2000020")
                .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_apli)
                .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto_apli)
                .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                {
                    result.Add(new Architect.API.Tron.Contracts.Poliza.DatoVariable()
                    {
                        cod_cia = reader.IntegerValue("cod_cia"),
                        num_poliza = reader.StringValue("num_poliza"),
                        num_spto = reader.IntegerValue("num_spto"),
                        num_apli = reader.IntegerValue("num_apli"),
                        num_spto_apli = reader.IntegerValue("num_spto_apli"),
                        num_riesgo = reader.IntegerValue("num_riesgo"),
                        num_periodo = reader.IntegerValue("num_periodo"),
                        tip_nivel = reader.IntegerValue("tip_nivel"),
                        cod_campo = reader.StringValue("cod_campo"),
                        val_campo = reader.StringValue("val_campo"),
                        val_cor_campo = reader.StringValue("val_cor_campo"),
                        num_secu = reader.IntegerValue("num_secu"),
                        txt_campo = reader.StringValue("txt_campo"),
                        mca_baja_riesgo = reader.StringValue("mca_baja_riesgo"),
                        mca_vigente = reader.StringValue("mca_vigente"),
                        mca_vigente_apli = reader.StringValue("mca_vigente_apli"),
                        cod_ramo = reader.IntegerValue("cod_ramo")
                    });
                }));
            return result;
        }

        /// <summary>
        ///  Ocurrencias de la póliza
        /// </summary>
        private static List<Architect.API.Tron.Contracts.Poliza.Ocurrencia> PP_Lee_A2000025(int cod_cia, string num_poliza, int num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection)
        {
            List<Architect.API.Tron.Contracts.Poliza.Ocurrencia> result = new List<Architect.API.Tron.Contracts.Poliza.Ocurrencia>();
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2000025")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto_apli)
                                           .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                                           .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                                           {
                                               result.Add(new Architect.API.Tron.Contracts.Poliza.Ocurrencia()
                                               {
                                                   cod_cia = reader.IntegerValue("cod_cia"),
                                                   num_poliza = reader.StringValue("num_poliza"),
                                                   num_spto = reader.IntegerValue("num_spto"),
                                                   num_apli = reader.IntegerValue("num_apli"),
                                                   num_spto_apli = reader.IntegerValue("num_spto_apli"),
                                                   num_riesgo = reader.IntegerValue("num_riesgo"),
                                                   num_periodo = reader.IntegerValue("num_periodo"),
                                                   cod_lista = reader.IntegerValue("cod_lista"),
                                                   num_ocurrencia = reader.IntegerValue("num_ocurrencia"),
                                                   num_secu = reader.IntegerValue("num_secu"),
                                                   cod_campo = reader.StringValue("cod_campo"),
                                                   val_campo = reader.StringValue("val_campo"),
                                                   txt_campo = reader.StringValue("txt_campo"),
                                                   mca_baja_riesgo = reader.StringValue("mca_baja_riesgo"),
                                                   mca_vigente = reader.StringValue("mca_vigente"),
                                                   mca_vigente_apli = reader.StringValue("mca_vigente_apli"),
                                                   mca_baja_ocurrencia = reader.StringValue("mca_baja_ocurrencia"),
                                                   imp_ocurrencia = reader.IntegerValue("imp_ocurrencia")
                                               });
                                           }));
            return result;
        }

        /// <summary>
        ///  Coberturas de la póliza
        /// </summary>
        private static List<Architect.API.Tron.Contracts.Poliza.Cobertura> PP_Lee_A2000040(int cod_cia, string num_poliza, int num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection)
        {
            List<Architect.API.Tron.Contracts.Poliza.Cobertura> result = new List<Architect.API.Tron.Contracts.Poliza.Cobertura>();
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2000040")
                .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_apli)
                .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto_apli)
                .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                {
                    result.Add(new Architect.API.Tron.Contracts.Poliza.Cobertura()
                    {
                        cod_cia = reader.IntegerValue("cod_cia"),
                        num_poliza = reader.StringValue("num_poliza"),
                        num_spto = reader.IntegerValue("num_spto"),
                        num_apli = reader.IntegerValue("num_apli"),
                        num_spto_apli = reader.IntegerValue("num_spto_apli"),
                        num_riesgo = reader.IntegerValue("num_riesgo"),
                        num_periodo = reader.IntegerValue("num_periodo"),
                        num_secu = reader.IntegerValue("num_secu"),
                        cod_cob = reader.IntegerValue("cod_cob"),
                        suma_aseg = reader.DoubleValue("suma_aseg"),
                        imp_unidad = reader.IntegerValue("imp_unidad"),
                        pct_participacion = reader.IntegerValue("pct_participacion"),
                        cod_mon_capital = reader.IntegerValue("cod_mon_capital"),
                        suma_aseg_baja_stro = reader.IntegerValue("suma_aseg_baja_stro"),
                        suma_aseg_spto = reader.DoubleValue("suma_aseg_spto"),
                        tasa_cob = reader.DoubleValue("tasa_cob"),
                        cod_franquicia = reader.IntegerValue("cod_franquicia"),
                        cod_limite = reader.IntegerValue("cod_limite"),
                        suma_aseg_sup = reader.IntegerValue("suma_aseg_sup"),
                        mca_baja_riesgo = reader.StringValue("mca_baja_riesgo"),
                        mca_vigente = reader.StringValue("mca_vigente"),
                        mca_vigente_apli = reader.StringValue("mca_vigente_apli"),
                        mca_baja_cob = reader.StringValue("mca_baja_cob"),
                        cod_secc_reas = reader.IntegerValue("cod_secc_reas"),
                        imp_agr = reader.IntegerValue("imp_agr"),
                        imp_agr_rel = reader.IntegerValue("imp_agr_rel"),
                        imp_agr_spto = reader.IntegerValue("imp_agr_spto"),
                        imp_agr_rel_spto = reader.IntegerValue("imp_agr_rel_spto"),
                        mes_base_regulariza = reader.IntegerValue("mes_base_regulariza"),
                        anio_base_regulariza = reader.IntegerValue("anio_base_regulariza"),
                        pct_enfermedad = reader.IntegerValue("pct_enfermedad"),
                        duracion_profesion = reader.IntegerValue("duracion_profesion"),
                        pct_profesion = reader.IntegerValue("pct_profesion"),
                        duracion_enfermedad = reader.IntegerValue("duracion_enfermedad"),
                        val_franquicia_min = reader.IntegerValue("val_franquicia_min"),
                        val_franquicia_max = reader.IntegerValue("val_franquicia_max"),
                        cod_ramo = reader.IntegerValue("cod_ramo"),
                        suma_aseg_baja_stro_acc = reader.IntegerValue("suma_aseg_baja_stro_acc")
                    });
                }));
            return result;
        }

        /// <summary>
        ///  Coberturas de la póliza
        /// </summary>
        public static List<Architect.API.Tron.Contracts.Poliza.Cobertura> PP_Lee_A2000040_ZA(int cod_cia, string num_poliza, IDbConnection currentConnection)
        {
            List<Architect.API.Tron.Contracts.Poliza.Cobertura> result = new List<Architect.API.Tron.Contracts.Poliza.Cobertura>();
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2000040_ZA")
                .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                {
                    result.Add(new Architect.API.Tron.Contracts.Poliza.Cobertura()
                    {
                        cod_cia = reader.IntegerValue("cod_cia"),
                        num_poliza = reader.StringValue("num_poliza"),
                        num_spto = reader.IntegerValue("num_spto"),
                        num_apli = reader.IntegerValue("num_apli"),
                        num_spto_apli = reader.IntegerValue("num_spto_apli"),
                        num_riesgo = reader.IntegerValue("num_riesgo"),
                        cod_ramo = reader.IntegerValue("cod_ramo"),
                        cod_cob = reader.IntegerValue("cod_cob"),
                        num_secu = reader.IntegerValue("num_secu"),
                        nom_cob = reader.StringValue("nombre"),
                        suma_aseg = reader.DoubleValue("capital"),
                        imp_total = reader.DoubleValue("prima_total"),
                        cod_franquicia = reader.IntegerValue("cod_franquicia"),
                        tip_vehi = reader.StringValue("tip_vehi"),
                        cod_modalidad = reader.StringValue("cod_modalidad"),
                        deducible = reader.StringValue("deducible"),
                        fec_validez = reader.DateTimeValue("fec_validez")

                        //num_periodo = reader.IntegerValue("num_periodo"),
                        //imp_unidad = reader.IntegerValue("imp_unidad"),
                        //pct_participacion = reader.IntegerValue("pct_participacion"),
                        //cod_mon_capital = reader.IntegerValue("cod_mon_capital"),
                        //suma_aseg_baja_stro = reader.IntegerValue("suma_aseg_baja_stro"),
                        //suma_aseg_spto = reader.DoubleValue("suma_aseg_spto"),
                        //tasa_cob = reader.DoubleValue("tasa_cob"),
                        //cod_limite = reader.IntegerValue("cod_limite"),
                        //suma_aseg_sup = reader.IntegerValue("suma_aseg_sup"),
                        //mca_baja_riesgo = reader.StringValue("mca_baja_riesgo"),
                        //mca_vigente = reader.StringValue("mca_vigente"),
                        //mca_vigente_apli = reader.StringValue("mca_vigente_apli"),
                        //mca_baja_cob = reader.StringValue("mca_baja_cob"),
                        //cod_secc_reas = reader.IntegerValue("cod_secc_reas"),
                        //imp_agr = reader.IntegerValue("imp_agr"),
                        //imp_agr_rel = reader.IntegerValue("imp_agr_rel"),
                        //imp_agr_spto = reader.IntegerValue("imp_agr_spto"),
                        //imp_agr_rel_spto = reader.IntegerValue("imp_agr_rel_spto"),
                        //mes_base_regulariza = reader.IntegerValue("mes_base_regulariza"),
                        //anio_base_regulariza = reader.IntegerValue("anio_base_regulariza"),
                        //pct_enfermedad = reader.IntegerValue("pct_enfermedad"),
                        //duracion_profesion = reader.IntegerValue("duracion_profesion"),
                        //pct_profesion = reader.IntegerValue("pct_profesion"),
                        //duracion_enfermedad = reader.IntegerValue("duracion_enfermedad"),
                        //val_franquicia_min = reader.IntegerValue("val_franquicia_min"),
                        //val_franquicia_max = reader.IntegerValue("val_franquicia_max"),
                        //suma_aseg_baja_stro_acc = reader.IntegerValue("suma_aseg_baja_stro_acc")
                    });
                }));
            return result;
        }

        /// <summary>
        ///  Terceros de la póliza
        /// </summary>
        private static List<Architect.API.Tron.Contracts.Poliza.Tercero> PP_Lee_A2000060(int cod_cia, string num_poliza, int num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection)
        {
            List<Architect.API.Tron.Contracts.Poliza.Tercero> result = new List<Architect.API.Tron.Contracts.Poliza.Tercero>();
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2000060")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto_apli)
                                           .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                                           .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                                           {
                                               result.Add(new Architect.API.Tron.Contracts.Poliza.Tercero()
                                               {
                                                   cod_cia = reader.IntegerValue("cod_cia"),
                                                   num_poliza = reader.StringValue("num_poliza"),
                                                   num_spto = reader.IntegerValue("num_spto"),
                                                   num_apli = reader.IntegerValue("num_apli"),
                                                   num_spto_apli = reader.IntegerValue("num_spto_apli"),
                                                   num_riesgo = reader.IntegerValue("num_riesgo"),
                                                   tip_benef = reader.StringValue("tip_benef"),
                                                   num_secu = reader.IntegerValue("num_secu"),
                                                   tip_docum = reader.StringValue("tip_docum"),
                                                   cod_docum = reader.StringValue("cod_docum"),
                                                   mca_principal = reader.StringValue("mca_principal"),
                                                   mca_calculo = reader.StringValue("mca_calculo"),
                                                   mca_baja = reader.StringValue("mca_baja"),
                                                   mca_vigente = reader.StringValue("mca_vigente"),
                                                   pct_participacion = reader.IntegerValue("pct_participacion"),
                                                   fec_vcto_cesion = reader.DateTimeValue("fec_vcto_cesion"),
                                                   imp_cesion = reader.IntegerValue("imp_cesion"),
                                                   num_prestamo = reader.StringValue("num_prestamo"),
                                                   tip_relac = reader.StringValue("tip_relac")
                                               });
                                           }));
            return result;
        }

        /// <summary>
        ///  Terceros de la póliza para variaciones
        /// </summary>
        private static List<Architect.API.Tron.Contracts.Poliza.Tercero> PP_Lee_A2000060_ZA(int cod_cia, string num_poliza, int? num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection)
        {
            List<Architect.API.Tron.Contracts.Poliza.Tercero> result = new List<Architect.API.Tron.Contracts.Poliza.Tercero>();
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2000060_ZA")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto_apli)
                                           .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                                           .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                                           {
                                               result.Add(new Architect.API.Tron.Contracts.Poliza.Tercero()
                                               {
                                                   cod_cia = reader.IntegerValue("cod_cia"),
                                                   num_poliza = reader.StringValue("num_poliza"),
                                                   num_spto = reader.IntegerValue("num_spto"),
                                                   num_apli = reader.IntegerValue("num_apli"),
                                                   num_spto_apli = reader.IntegerValue("num_spto_apli"),
                                                   num_riesgo = reader.IntegerValue("num_riesgo"),
                                                   tip_benef = reader.StringValue("tip_benef"),
                                                   num_secu = reader.IntegerValue("num_secu"),
                                                   tip_docum = reader.StringValue("tip_docum"),
                                                   cod_docum = reader.StringValue("cod_docum"),
                                                   mca_principal = reader.StringValue("mca_principal"),
                                                   mca_calculo = reader.StringValue("mca_calculo"),
                                                   mca_baja = reader.StringValue("mca_baja"),
                                                   mca_vigente = reader.StringValue("mca_vigente"),
                                                   pct_participacion = reader.IntegerValue("pct_participacion"),
                                                   fec_vcto_cesion = reader.DateTimeValue("fec_vcto_cesion"),
                                                   imp_cesion = reader.IntegerValue("imp_cesion"),
                                                   num_prestamo = reader.StringValue("num_prestamo"),
                                                   tip_relac = reader.StringValue("tip_relac"),
                                                   nom_benef = reader.StringValue("nom_benef"),
                                                   nom_completo = reader.StringValue("nom_completo"),
                                                   fec_nacimiento = reader.StringValue("fec_nacimiento"),
                                                   tlf_numero = reader.StringValue("tlf_numero"),
                                                   email = reader.StringValue("email")
                                               });
                                           }));
            return result;
        }

        /// <summary>
        /// Recibos/cuotas de una póliza
        /// </summary>
        private static List<Architect.API.Tron.Contracts.Poliza.Recibo> PP_Lee_A2990700(int cod_cia, string num_poliza, int num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection)
        {
            List<Architect.API.Tron.Contracts.Poliza.Recibo> result = new List<Architect.API.Tron.Contracts.Poliza.Recibo>();
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2990700")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto_apli)
                                           .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                                           .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                                           {
                                               result.Add(new Architect.API.Tron.Contracts.Poliza.Recibo()
                                               {
                                                   cod_cia = reader.IntegerValue("cod_cia"),
                                                   num_poliza = reader.StringValue("num_poliza"),
                                                   num_spto = reader.IntegerValue("num_spto"),
                                                   num_apli = reader.IntegerValue("num_apli"),
                                                   num_spto_apli = reader.IntegerValue("num_spto_apli"),
                                                   num_cuota = reader.IntegerValue("num_cuota"),
                                                   num_recibo = reader.IntegerValue("num_recibo"),
                                                   tip_recibo = reader.StringValue("tip_recibo"),
                                                   fec_efec_recibo = reader.DateTimeValue("fec_efec_recibo"),
                                                   fec_vcto_recibo = reader.DateTimeValue("fec_vcto_recibo"),
                                                   tip_gestor = reader.StringValue("tip_gestor"),
                                                   cod_gestor = reader.StringValue("cod_gestor"),
                                                   fec_emision_spto = reader.DateTimeValue("fec_emision_spto"),
                                                   tip_situacion = reader.StringValue("tip_situacion"),
                                                   tip_remesa = reader.StringValue("tip_remesa"),
                                                   fec_remesa = reader.DateTimeValue("fec_remesa"),
                                                   fec_ctable = reader.DateTimeValue("fec_ctable"),
                                                   fec_valor = reader.DateTimeValue("fec_valor"),
                                                   cod_mon = reader.IntegerValue("cod_mon"),
                                                   val_cambio = reader.DoubleValue("val_cambio"),
                                                   imp_recibo = reader.DoubleValue("imp_recibo"),
                                                   imp_neta = reader.DoubleValue("imp_neta"),
                                                   imp_recargo = reader.DoubleValue("imp_recargo"),
                                                   imp_imptos = reader.DoubleValue("imp_imptos"),
                                                   imp_boni = reader.DoubleValue("imp_boni"),
                                                   imp_comis = reader.DoubleValue("imp_comis"),
                                                   tip_coaseguro = reader.IntegerValue("tip_coaseguro"),
                                                   cod_nivel3 = reader.IntegerValue("cod_nivel3"),
                                                   cod_agt = reader.IntegerValue("cod_agt"),
                                                   num_impresion = reader.IntegerValue("num_impresion"),
                                                   ctrl_moroso = reader.StringValue("ctrl_moroso"),
                                                   txt_aux1 = reader.StringValue("txt_aux1"),
                                                   txt_aux2 = reader.StringValue("txt_aux2"),
                                                   fec_actu = reader.DateTimeValue("fec_actu"),
                                                   imp_total_comis = reader.DoubleValue("imp_total_comis"),
                                                   mca_ca = reader.StringValue("mca_ca"),
                                                   mca_cv = reader.StringValue("mca_cv"),
                                                   num_aviso = reader.StringValue("num_aviso"),
                                                   tip_docum_pago = reader.StringValue("tip_docum_pago"),
                                                   cod_docum_pago = reader.StringValue("cod_docum_pago"),
                                                   imp_interes = reader.DoubleValue("imp_interes"),
                                                   imp_imptos_interes = reader.DoubleValue("imp_imptos_interes"),
                                                   num_mvto_cv = reader.IntegerValue("num_mvto_cv"),
                                                   mca_dcto_comis = reader.StringValue("mca_dcto_comis"),
                                                   fec_vcto_pago = reader.DateTimeValue("fec_vcto_pago"),
                                                   num_mvto_ca = reader.IntegerValue("num_mvto_ca")
                                               });
                                           }));
            return result;
        }

        /// <summary>
        /// Recibos/cuotas de una póliza
        /// </summary>
        private static List<Architect.API.Tron.Contracts.Poliza.Recibo> PP_Lee_A2990700(int cod_cia, string num_poliza, int? num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection)
        {
            List<Architect.API.Tron.Contracts.Poliza.Recibo> result = new List<Architect.API.Tron.Contracts.Poliza.Recibo>();
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2990700")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto_apli)
                                           .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                                           .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                                           {
                                               result.Add(new Architect.API.Tron.Contracts.Poliza.Recibo()
                                               {
                                                   cod_cia = reader.IntegerValue("cod_cia"),
                                                   num_poliza = reader.StringValue("num_poliza"),
                                                   num_spto = reader.IntegerValue("num_spto"),
                                                   num_apli = reader.IntegerValue("num_apli"),
                                                   num_spto_apli = reader.IntegerValue("num_spto_apli"),
                                                   num_cuota = reader.IntegerValue("num_cuota"),
                                                   num_recibo = reader.IntegerValue("num_recibo"),
                                                   tip_recibo = reader.StringValue("tip_recibo"),
                                                   fec_efec_recibo = reader.DateTimeValue("fec_efec_recibo"),
                                                   fec_vcto_recibo = reader.DateTimeValue("fec_vcto_recibo"),
                                                   tip_gestor = reader.StringValue("tip_gestor"),
                                                   cod_gestor = reader.StringValue("cod_gestor"),
                                                   fec_emision_spto = reader.DateTimeValue("fec_emision_spto"),
                                                   tip_situacion = reader.StringValue("tip_situacion"),
                                                   tip_remesa = reader.StringValue("tip_remesa"),
                                                   fec_remesa = reader.DateTimeValue("fec_remesa"),
                                                   fec_ctable = reader.DateTimeValue("fec_ctable"),
                                                   fec_valor = reader.DateTimeValue("fec_valor"),
                                                   cod_mon = reader.IntegerValue("cod_mon"),
                                                   val_cambio = reader.DoubleValue("val_cambio"),
                                                   imp_recibo = reader.DoubleValue("imp_recibo"),
                                                   imp_neta = reader.DoubleValue("imp_neta"),
                                                   imp_recargo = reader.DoubleValue("imp_recargo"),
                                                   imp_imptos = reader.DoubleValue("imp_imptos"),
                                                   imp_boni = reader.DoubleValue("imp_boni"),
                                                   imp_comis = reader.DoubleValue("imp_comis"),
                                                   tip_coaseguro = reader.IntegerValue("tip_coaseguro"),
                                                   cod_nivel3 = reader.IntegerValue("cod_nivel3"),
                                                   cod_agt = reader.IntegerValue("cod_agt"),
                                                   num_impresion = reader.IntegerValue("num_impresion"),
                                                   ctrl_moroso = reader.StringValue("ctrl_moroso"),
                                                   txt_aux1 = reader.StringValue("txt_aux1"),
                                                   txt_aux2 = reader.StringValue("txt_aux2"),
                                                   fec_actu = reader.DateTimeValue("fec_actu"),
                                                   imp_total_comis = reader.DoubleValue("imp_total_comis"),
                                                   mca_ca = reader.StringValue("mca_ca"),
                                                   mca_cv = reader.StringValue("mca_cv"),
                                                   num_aviso = reader.StringValue("num_aviso"),
                                                   tip_docum_pago = reader.StringValue("tip_docum_pago"),
                                                   cod_docum_pago = reader.StringValue("cod_docum_pago"),
                                                   imp_interes = reader.DoubleValue("imp_interes"),
                                                   imp_imptos_interes = reader.DoubleValue("imp_imptos_interes"),
                                                   num_mvto_cv = reader.IntegerValue("num_mvto_cv"),
                                                   mca_dcto_comis = reader.StringValue("mca_dcto_comis"),
                                                   fec_vcto_pago = reader.DateTimeValue("fec_vcto_pago"),
                                                   num_mvto_ca = reader.IntegerValue("num_mvto_ca")
                                               });
                                           }));
            return result;
        }

        /// <summary>
        ///  Coberturas de la póliza
        /// </summary>
        private static List<Architect.API.Tron.Contracts.Poliza.CoberturaCalculada> PP_Lee_A2000040_Result(int cod_cia, string num_poliza, int num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection)
        {
            List<Architect.API.Tron.Contracts.Poliza.CoberturaCalculada> result = new List<Architect.API.Tron.Contracts.Poliza.CoberturaCalculada>();
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2000040_RESULT")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto_apli)
                                           .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                                           .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                                           {
                                               result.Add(new Architect.API.Tron.Contracts.Poliza.CoberturaCalculada()
                                               {
                                                   NUM_POLIZA = reader.StringValue("NUM_POLIZA"),
                                                   COD_COB = reader.IntegerValue("COD_COB"),
                                                   NOM_COB = reader.StringValue("NOM_COB"),
                                                   SUMA_ASEG = reader.DoubleValue("SUMA_ASEG"),
                                                   IMP_ANUAL = reader.DoubleValue("IMP_ANUAL"),
                                                   IMP_IVA = reader.DoubleValue("IMP_IVA"),
                                                   IMP_FRACC = reader.DoubleValue("IMP_FRACC"),
                                                   IMP_TOTAL = reader.DoubleValue("IMP_TOTAL"),
                                                   COD_FRANQUICIA = reader.IntegerValue("COD_FRANQUICIA"),
                                                   NOM_FRANQUICIA = reader.StringValue("NOM_FRANQUICIA"),
                                                   TXT_ERROR = reader.StringValue("TXT_ERROR")
                                               }
                                               );
                                           }));
            return result;
        }

        /// <summary>
        /// Recibos/cuotas de una póliza
        /// </summary>
        private static List<Architect.API.Tron.Contracts.Poliza.ReciboCalculado> PP_Lee_A2990700_Result(int cod_cia, string num_poliza, int num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection)
        {
            List<Architect.API.Tron.Contracts.Poliza.ReciboCalculado> result = new List<Architect.API.Tron.Contracts.Poliza.ReciboCalculado>();
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2990700_RESULT")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto_apli)
                                           .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                                           .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                                           {
                                               result.Add(new Architect.API.Tron.Contracts.Poliza.ReciboCalculado()
                                               {
                                                   NUM_RECIBO = reader.IntegerValue("NUM_RECIBO"),
                                                   FEC_EFEC_RECIBO = reader.DateTimeValue("FEC_EFEC_RECIBO"),
                                                   FEC_VCTO_RECIBO = reader.DateTimeValue("FEC_VCTO_RECIBO"),
                                                   TIP_SITUACION = reader.StringValue("TIP_SITUACION"),
                                                   IMP_RECIBO = reader.DoubleValue("IMP_RECIBO"),
                                                   IMP_NETA = reader.DoubleValue("IMP_NETA"),
                                                   IMP_RECARGO = reader.DoubleValue("IMP_RECARGO"),
                                                   IMP_IMPTOS = reader.DoubleValue("IMP_IMPTOS"),
                                                   IMP_INTERES = reader.DoubleValue("IMP_INTERES")
                                               });
                                           }));
            return result;
        }

        /// <summary>
        /// Recibos/cuotas de una póliza
        /// </summary>
        public static List<Architect.API.Tron.Contracts.Poliza.ReciboCalculado> PP_Lee_A2990700_Result_ZA(int cod_cia, string num_poliza, int? num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection)
        {
            List<Architect.API.Tron.Contracts.Poliza.ReciboCalculado> result = new List<Architect.API.Tron.Contracts.Poliza.ReciboCalculado>();
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2990700_RESULT_ZA")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto_apli)
                                           .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                                           .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                                           {
                                               result.Add(new Architect.API.Tron.Contracts.Poliza.ReciboCalculado()
                                               {
                                                   NUM_RECIBO = reader.IntegerValue("NUM_RECIBO"),
                                                   NUM_CUOTA = reader.IntegerValue("NUM_CUOTA"),
                                                   NUM_SPTO = reader.IntegerValue("NUM_SPTO"),
                                                   FEC_EFEC_RECIBO = reader.DateTimeValue("FEC_EFEC_RECIBO"),
                                                   FEC_VCTO_RECIBO = reader.DateTimeValue("FEC_VCTO_RECIBO"),
                                                   TIP_SITUACION = reader.StringValue("TIP_SITUACION"),
                                                   IMP_RECIBO = reader.DoubleValue("IMP_RECIBO"),
                                                   IMP_NETA = reader.DoubleValue("IMP_NETA"),
                                                   IMP_RECARGO = reader.DoubleValue("IMP_RECARGO"),
                                                   IMP_IMPTOS = reader.DoubleValue("IMP_IMPTOS"),
                                                   IMP_INTERES = reader.DoubleValue("IMP_INTERES")
                                               });
                                           }));
            return result;
        }

        internal static List<Contracts.Poliza.DesgloseEconomico> PP_Lee_A2100170(int cod_cia, string num_poliza, int num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection)
        {
            List<Contracts.Poliza.DesgloseEconomico> result = new List<Contracts.Poliza.DesgloseEconomico>();
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2100170")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto_apli)
                                           .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                                           .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                                           {
                                               result.Add(new Contracts.Poliza.DesgloseEconomico()
                                               {
                                                   cod_cia = reader.IntegerValue("cod_cia"),
                                                   num_poliza = reader.StringValue("num_poliza"),
                                                   num_spto = reader.IntegerValue("num_spto"),
                                                   num_apli = reader.IntegerValue("num_apli"),
                                                   num_spto_apli = reader.IntegerValue("num_spto_apli"),
                                                   num_riesgo = reader.IntegerValue("num_riesgo"),
                                                   num_periodo = reader.IntegerValue("num_periodo"),
                                                   cod_cob = reader.IntegerValue("cod_cob"),
                                                   cod_desglose = reader.IntegerValue("cod_desglose"),
                                                   cod_eco = reader.IntegerValue("cod_eco"),
                                                   num_bloque_estudio = reader.IntegerValue("num_bloque_estudio"),
                                                   imp_acumulado_anual = reader.IntegerValue("imp_acumulado_anual"),
                                                   imp_spto = reader.IntegerValue("imp_spto"),
                                                   imp_no_consumido = reader.IntegerValue("imp_no_consumido"),
                                                   imp_anual = reader.IntegerValue("imp_anual"),
                                                   cod_ramo = reader.IntegerValue("cod_ramo")
                                               });
                                           }));
            return result;
        }

        internal static List<Contracts.Poliza.DesgloseEconomico> PP_Lee_A2100170(int cod_cia, string num_poliza, int? num_spto, int num_apli, int num_spto_apli, IDbConnection currentConnection)
        {
            List<Contracts.Poliza.DesgloseEconomico> result = new List<Contracts.Poliza.DesgloseEconomico>();
            Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_LEE_A2100170")
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, cod_cia)
                                           .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                                           .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                                           .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_apli)
                                           .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto_apli)
                                           .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                                           .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                                           {
                                               result.Add(new Contracts.Poliza.DesgloseEconomico()
                                               {
                                                   cod_cia = reader.IntegerValue("cod_cia"),
                                                   num_poliza = reader.StringValue("num_poliza"),
                                                   num_spto = reader.IntegerValue("num_spto"),
                                                   num_apli = reader.IntegerValue("num_apli"),
                                                   num_spto_apli = reader.IntegerValue("num_spto_apli"),
                                                   num_riesgo = reader.IntegerValue("num_riesgo"),
                                                   num_periodo = reader.IntegerValue("num_periodo"),
                                                   cod_cob = reader.IntegerValue("cod_cob"),
                                                   cod_desglose = reader.IntegerValue("cod_desglose"),
                                                   cod_eco = reader.IntegerValue("cod_eco"),
                                                   num_bloque_estudio = reader.IntegerValue("num_bloque_estudio"),
                                                   imp_acumulado_anual = reader.IntegerValue("imp_acumulado_anual"),
                                                   imp_spto = reader.IntegerValue("imp_spto"),
                                                   imp_no_consumido = reader.IntegerValue("imp_no_consumido"),
                                                   imp_anual = reader.IntegerValue("imp_anual"),
                                                   cod_ramo = reader.IntegerValue("cod_ramo")
                                               });
                                           }));
            return result;
        }

        /// <summary>
        /// Datos fijos de la póliza
        /// </summary>
        public static Architect.API.Tron.Contracts.Poliza.DatoFijo Lee_A2000030(int cod_cia, string num_poliza, int num_spto, int num_apli, int num_spto_apli)
        {
            Architect.API.Tron.Contracts.Poliza.DatoFijo a2000030Instance = null;
            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                a2000030Instance = PP_Lee_A2000030(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);

                currentConnection?.Close();
            }

            return a2000030Instance;
        }

        /// <summary>
        /// Datos fijos de la póliza
        /// </summary>
        public static Architect.API.Tron.Contracts.Poliza.DatoFijo Lee_A2000030(int cod_cia, string num_poliza, int? num_spto, int num_apli, int num_spto_apli)
        {
            Architect.API.Tron.Contracts.Poliza.DatoFijo a2000030Instance = null;
            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                a2000030Instance = PP_Lee_A2000030(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);

                currentConnection?.Close();
            }

            return a2000030Instance;
        }

        /// <summary>
        ///  Datos variables de la póliza
        /// </summary>
        public static List<Architect.API.Tron.Contracts.Poliza.DatoVariable> Lee_A2000020(int cod_cia, string num_poliza, int num_spto, int num_apli, int num_spto_apli)
        {
            List<Architect.API.Tron.Contracts.Poliza.DatoVariable> DatosVariables = null;

            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                DatosVariables = PP_Lee_A2000020(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);

                currentConnection?.Close();
            }

            return DatosVariables;
        }

        /// <summary>
        ///  Datos variables de la póliza
        /// </summary>
        public static List<Architect.API.Tron.Contracts.Poliza.DatoVariable> Lee_A2000020(int cod_cia, string num_poliza, int? num_spto, int num_apli, int num_spto_apli)
        {
            List<Architect.API.Tron.Contracts.Poliza.DatoVariable> DatosVariables = null;

            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                DatosVariables = PP_Lee_A2000020(cod_cia, num_poliza, num_spto, num_apli, num_spto_apli, currentConnection);

                currentConnection?.Close();
            }

            return DatosVariables;
        }
    }
}
