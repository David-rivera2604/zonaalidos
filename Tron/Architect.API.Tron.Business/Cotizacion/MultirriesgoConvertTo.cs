using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Architect.API.Tron.Business.Cotizacion
{
    public static class MultirriesgoConvertTo
    {

        internal static Architect.API.Tron.Contracts.Presupuesto.DatoFijo Tron(Contracts.Cotizacion.Multirriesgo quoteInfo, bool isCoope, int branch, int agentCode, string userName)
        {
            Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos = DatosFijos(quoteInfo, isCoope, branch, agentCode, userName);
            datosFijos.Riesgos = Util.DatosDelRiesgo(datosFijos, "Cotizador MultiRiesgo Empresas");
            datosFijos.Terceros = Util.Terceros(datosFijos);
            datosFijos.Coberturas = Coberturas(quoteInfo, datosFijos);
            datosFijos.DatosVariables = DatosVariable(quoteInfo, datosFijos);

            return datosFijos;
        }

        private static Architect.API.Tron.Contracts.Presupuesto.DatoFijo DatosFijos(Contracts.Cotizacion.Multirriesgo quoteInfo, bool isCoope, int branch, int agentCode, string userName)
        {

            //Datos fijos del presupuesto
            Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos = new Architect.API.Tron.Contracts.Presupuesto.DatoFijo()
            {
                cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]),
                cod_sector = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.HogarTotal.cod_sector"]),
                cod_ramo = branch,
                num_poliza = string.Empty,
                num_spto = 0,
                num_apli = 0,
                num_spto_apli = 0,
                cod_nivel1 = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_nivel1"]),
                cod_nivel2 = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_nivel2"]),
                cod_nivel3 = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_nivel3"]),
                num_poliza_grupo = string.Empty,
                num_contrato = int.MinValue,
                cod_agt = agentCode,
                cod_cuadro_com = 0,
                cod_fracc_pago = quoteInfo.cod_fracc_pago,
                cod_mon = quoteInfo.cod_mon,
                fec_efec_poliza = quoteInfo.fec_efec_poliza,
                fec_vcto_poliza = quoteInfo.fec_vcto_poliza,
                //fec_validez = DateTime.MinValue,
                //fec_emision = DateTime.MinValue,
                //fec_emision_spto = DateTime.MinValue,

                //fec_efec_spto = DateTime.MinValue,
                //fec_vcto_spto = DateTime.MinValue,
                //tip_duracion = 0,
                //num_riesgos = 0,
                //

                //cant_renovaciones = 0,
                //num_renovaciones = 0,
                //tip_coaseguro = 0,
                //
                //
                //num_secu_grupo = 0,
                //cod_spto = 0,
                //sub_cod_spto = 0,
                //txt_motivo_spto = string.Empty,
                //pct_agt = 0,
                //cod_org = 0,
                //cod_asesor = 0,
                //cod_compensacion = 0,
                //pct_regulariza = 0,
                //cod_indice = 0,
                //anios_max_duracion = 0,
                //meses_max_duracion = 0,
                //dias_max_duracion = 0,
                //cod_agt2 = 0,
                //pct_agt2 = 0,
                //cod_agt3 = 0,
                //pct_agt3 = 0,
                //cod_agt4 = 0,
                //pct_agt4 = 0,
                //duracion_pago_prima = 0,
                //cod_ejecutivo = 0,
                //fec_autorizacion = DateTime.MinValue,
                //num_spto_anulado = 0,
                //fec_spto_anulado = DateTime.MinValue,
                //cod_nivel3_captura = 0,
                //fec_actu = DateTime.MinValue,
                //cod_dst_agt = 0,
                //num_spto_publico = 0,
                //num_subcontrato = 0,
                //fec_tratamiento = DateTime.MinValue,
                //num_orden = 0
            };

            //Si el usuario es de Coopeservidores
            if (isCoope)
            {
                if (quoteInfo.cod_mon == 1) //Colones
                {
                    datosFijos.num_poliza_grupo = "2021910190800";
                    datosFijos.num_contrato = 90800;
                }
                else if (quoteInfo.cod_mon == 2) //Dolares
                {
                    datosFijos.num_poliza_grupo = "2021910191200";
                    datosFijos.num_contrato = 91200;
                }

                //Obtener informacion del agente y cuadro comision
                foreach (Architect.API.Tron.Contracts.Batch.p_lee_g2990000 item in Architect.API.Tron.DataAccess.PorRamo.AgenteyCuadroDeComision(datosFijos.cod_cia, datosFijos.cod_ramo, datosFijos.num_contrato))
                {
                    datosFijos.cod_agt = Convert.ToInt32(item.cod_agt);
                    datosFijos.cod_cuadro_com = Convert.ToInt32(item.cod_cuadro_com);
                }
            }
            else
            {
                if (agentCode == 999999)
                {
                    datosFijos.cod_cuadro_com = 0;
                }
                else
                {
                    datosFijos.cod_cuadro_com = 100;

                }
            }
            datosFijos.txt_motivo_spto = "Cotización realizada desde la zona de aliados, por: " + userName;

            return datosFijos;
        }

        private static List<Architect.API.Tron.Contracts.Presupuesto.Cobertura> Coberturas(Contracts.Cotizacion.Multirriesgo quoteInfo, Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos)
        {

            List<Architect.API.Tron.Contracts.Presupuesto.Cobertura> coberturas = new List<Architect.API.Tron.Contracts.Presupuesto.Cobertura>();

            foreach (Architect.API.Tron.Contracts.Cotizacion.MultirriesgoCoberturas item in from c in quoteInfo.coberturas where c.seleccionado select c)
            {
                coberturas.Add(Util.Cobertura(datosFijos, item.codigo));
            }
            return coberturas;
        }

        internal static List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable> DatosVariable(Contracts.Cotizacion.Multirriesgo quoteInfo, Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos)
        {
            List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable> datosVariables = new List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable>();
            int num_riesgo = datosFijos.Riesgos.FirstOrDefault().num_riesgo;


            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_PAIS", quoteInfo.cod_pais));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_ESTADO", quoteInfo.cod_estado.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_PROV", quoteInfo.cod_prov.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_LOCALIDAD", quoteInfo.cod_localidad.ToString()));

            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "NUM_PISOS_EDIF", quoteInfo.num_pisos_edif.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_TIPO_ESTRUC", quoteInfo.cod_tipo_estruc.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_TIPO_TECHO", quoteInfo.cod_tipo_techo.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_TIPO_PARED", quoteInfo.cod_tipo_pared.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "OTRA_SENAS_RGO1", quoteInfo.otrassenasdelriesgo));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_OCU_POLIZA", "S"));

            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_TIP_EDIF", quoteInfo.cod_tip_edit.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_EXTIN_INC", quoteInfo.MCA_EXTIN_INC.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "NUM_EXTIN_INC", quoteInfo.NUM_EXTIN_INC.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_TIP_RGO_IDN", quoteInfo.cod_tip_rgo_idn.ToString()));



            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_TIPO_OCUP_RGO", quoteInfo.cod_tip_ocup.ToString()));



            if (quoteInfo.cod_tip_ocup.ToString().Length >= 8)
            {
                datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_CLASE_RGO_INC", quoteInfo.cod_tip_ocup.ToString().Substring(6, 1)));
                datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_CLASE_RGO_ROB", quoteInfo.cod_tip_ocup.ToString().Substring(7, 1)));
            }

            // Coberturas
            //2001 Cobertura de edificio
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_EDIFICIO", quoteInfo.IMP_EDIFICIO.ToString()));

            //2009 Cobertura de contenido

            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_MOBILIARIO", quoteInfo.IMP_MOBILIARIO.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_MERCADERIA", quoteInfo.IMP_MERCADERIA.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_BIE_TEM_DES", quoteInfo.IMP_BIE_TEM_DES.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_BIE_INT", quoteInfo.IMP_BIE_INT.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_OBJ_ESP_VAL", quoteInfo.IMP_OBJ_ESP_VAL.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_CONTENIDO", (quoteInfo.IMP_MOBILIARIO +
                                                                                           quoteInfo.IMP_MERCADERIA +
                                                                                           quoteInfo.IMP_BIE_TEM_DES +
                                                                                           quoteInfo.IMP_BIE_INT +
                                                                                           quoteInfo.IMP_OBJ_ESP_VAL).ToString()));

            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_MAQUINARIA", quoteInfo.IMP_MAQUINARIA.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_EQUIP_ELEC", quoteInfo.IMP_EQUIP_ELEC.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_EQUIP_ELEC_M", quoteInfo.IMP_EQUIP_ELEC_M.ToString()));



            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_INCENDIO",
                   quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2002 || c.codigo == 2010)) > 0 ? "S" : "N"));

            Util.Ocurrencias(datosVariables, num_riesgo, "NUM_MED_INC", datosFijos, "COD_TIP_MED_INC", quoteInfo.cod_tip_med_inc);


            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_TERR",
                quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2024 || c.codigo == 2025 || c.codigo == 2026 ||
                                                                           c.codigo == 2055 || c.codigo == 2056 || c.codigo == 2057)) > 0 ? "S" : "N"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_INUN",
                quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2024 || c.codigo == 2025 || c.codigo == 2026 ||
                                                                           c.codigo == 2055 || c.codigo == 2056 || c.codigo == 2057)) > 0 ? "S" : "N"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_DESL",
                quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2024 || c.codigo == 2025 || c.codigo == 2026 ||
                                                                           c.codigo == 2055 || c.codigo == 2056 || c.codigo == 2057)) > 0 ? "S" : "N"));


            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_DPA",
                quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2004 || c.codigo == 2012)) > 0 ? "S" : "N"));

            //2008 Cobertura de robo
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_ROB",
                   quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2008)) > 0 ? "S" : "N"));

            Util.Ocurrencias(datosVariables, num_riesgo, "NUM_MED_ROB", datosFijos, "COD_TIP_MED_ROB", quoteInfo.cod_tip_med_rob);


            //2007 Cobertura de Rotura domo,crist, marmol y gra
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_DCMG",
                   quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2007)) > 0 ? "S" : "N"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_DOMOS_TOTAL", quoteInfo.IMP_DOMOS_TOTAL.ToString()));



            //2017 Cobertura de gastos por alquiler
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_GPA",
                   quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2017)) > 0 ? "S" : "N"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_GAS_ALQ", quoteInfo.IMP_GAS_ALQ.ToString()));


            //2018 Cobertura de perdida de rentas
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_PDR",
                   quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2018)) > 0 ? "S" : "N"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COB_PDR_MESES", quoteInfo.COB_PDR_MESES.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_PER_REN", quoteInfo.IMP_PER_REN.ToString()));

            //2019 Cobertura de bienes refrigerados o congelados
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_BR",
                    quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2019)) > 0 ? "S" : "N"));
            Util.Ocurrencias(datosVariables, num_riesgo, "NUM_TIP_BR", datosFijos, "COD_TIP_BR", string.Empty);
            Util.Ocurrencias(datosVariables, num_riesgo, "NUM_MED_BR", datosFijos, "COD_TIP_MED_BR", quoteInfo.cod_tip_med_rob);
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_BIE_REF", "0"));
            

            //2020 Cobertura de Mercancía en tránsito
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_MET",
                   quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2020)) > 0 ? "S" : "N"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_MER_TRA", quoteInfo.IMP_MER_TRA.ToString()));

            //2021 Cobertura de rotura de maquinaria
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_RDM",
                   quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2021)) > 0 ? "S" : "N"));

            Util.Ocurrencias(datosVariables, num_riesgo, "NUM_MED_RDM", datosFijos, "COD_TIP_MED_RDM", quoteInfo.cod_tip_med_rdm);

            //2022 Cobertura de equipos electronicos
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_EE",
                   quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2022)) > 0 ? "S" : "N"));

            //2023 Cobertura de Interrupción de negocios
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_IDN",
                   quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2023)) > 0 ? "S" : "N"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COB_IDN_MESES", quoteInfo.COB_IDN_MESES.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_INT_NEG", quoteInfo.IMP_INT_NEG.ToString()));

            //2027 Cobertura de asistencia en la empresa
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_AE",
                   quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2027)) > 0 ? "S" : "N"));

            return datosVariables;
        }

    }
}
