using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Architect.API.Tron.Business.Cotizacion
{
    internal static class HogarTotalConvertTo
    {

        internal static Architect.API.Tron.Contracts.Presupuesto.DatoFijo Tron(Contracts.Cotizacion.HogarTotal quoteInfo, bool isCoope, int branch, int agentCode, string userName)
        {

            Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos = DatosFijos(quoteInfo, isCoope, branch, agentCode, userName);

            datosFijos.Riesgos = Util.DatosDelRiesgo(datosFijos, "Cotizador hogar total");
            datosFijos.Terceros = Util.Terceros(datosFijos);
            datosFijos.Coberturas = Coberturas(quoteInfo, datosFijos);
            datosFijos.DatosVariables = DatosVariable(quoteInfo, datosFijos);

            return datosFijos;
        }

        internal static Architect.API.Tron.Contracts.Presupuesto.DatoFijo DatosFijos(Contracts.Cotizacion.HogarTotal quoteInfo, bool isCoope, int branch, int agentCode, string userName)
        {

            //Datos fijos del presupuesto
            Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos = new Architect.API.Tron.Contracts.Presupuesto.DatoFijo()
            {
                cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]),
                num_poliza = string.Empty,
                num_spto = 0,
                num_apli = 0,
                num_spto_apli = 0,
                cod_sector = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.HogarTotal.cod_sector"]),
                cod_ramo = branch,
                fec_validez = DateTime.MinValue,
                fec_emision = DateTime.MinValue,
                fec_emision_spto = DateTime.MinValue,
                fec_efec_poliza = quoteInfo.iniciodevigencia,
                fec_vcto_poliza = quoteInfo.findevigencia,
                fec_efec_spto = DateTime.MinValue,
                fec_vcto_spto = DateTime.MinValue,
                tip_duracion = 0,
                num_riesgos = 0,
                cod_mon = quoteInfo.moneda,
                cod_fracc_pago = quoteInfo.fraccionamientodepago,
                cant_renovaciones = 0,
                num_renovaciones = 0,
                tip_coaseguro = 0,
                num_contrato = quoteInfo.contrato,
                num_subcontrato = quoteInfo.subcontrato,
                num_poliza_grupo = quoteInfo.polizagrupo,
                num_secu_grupo = 0,
                cod_spto = 0,
                sub_cod_spto = 0,
                txt_motivo_spto = string.Empty,
                cod_cuadro_com = 0,
                cod_agt = 0,
                pct_agt = 0,
                cod_org = 0,
                cod_asesor = 0,
                cod_nivel1 = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_nivel1"]),
                cod_nivel2 = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_nivel2"]),
                cod_nivel3 = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_nivel3"]),
                cod_compensacion = 0,
                pct_regulariza = 0,
                cod_indice = 0,
                anios_max_duracion = 0,
                meses_max_duracion = 0,
                dias_max_duracion = 0,
                cod_agt2 = 0,
                pct_agt2 = 0,
                cod_agt3 = 0,
                pct_agt3 = 0,
                cod_agt4 = 0,
                pct_agt4 = 0,
                duracion_pago_prima = 0,
                cod_ejecutivo = 0,
                fec_autorizacion = DateTime.MinValue,
                num_spto_anulado = 0,
                fec_spto_anulado = DateTime.MinValue,
                cod_nivel3_captura = 0,
                fec_actu = DateTime.MinValue,
                cod_dst_agt = 0,
                num_spto_publico = 0,
                fec_tratamiento = DateTime.MinValue,
                num_orden = 0
            };

            //Si el usuario es de Coopeservidores
            if (isCoope)
            {
                if (quoteInfo.moneda == 1) //Colones
                {
                    datosFijos.num_poliza_grupo = "2011910190700";
                    datosFijos.num_contrato = 90700;
                }
                else if (quoteInfo.moneda == 2) //Dolares
                {
                    datosFijos.num_poliza_grupo = "2011910191100";
                    datosFijos.num_contrato = 91100;
                }

                //Obtener información del agente y cuadro comisión
                foreach (Architect.API.Tron.Contracts.Batch.p_lee_g2990000 item in Architect.API.Tron.DataAccess.PorRamo.AgenteyCuadroDeComision(datosFijos.cod_cia, datosFijos.cod_ramo, datosFijos.num_contrato))
                {
                    datosFijos.cod_agt = Convert.ToInt32(item.cod_agt);
                    datosFijos.cod_cuadro_com = Convert.ToInt32(item.cod_cuadro_com);
                }
            }
            else
            {
                if (quoteInfo.polizagrupo.IsNotEmpty())
                {
                    datosFijos.num_poliza_grupo = quoteInfo.polizagrupo;
                    datosFijos.num_contrato = quoteInfo.contrato;
                    datosFijos.num_subcontrato = quoteInfo.subcontrato;
                }
                else
                {
                    datosFijos.num_poliza_grupo = String.Empty;
                    datosFijos.num_contrato = int.MinValue;
                    datosFijos.num_subcontrato = 0;
                }


                datosFijos.cod_cuadro_com = 100;
                datosFijos.cod_agt = agentCode;
            }
            datosFijos.txt_motivo_spto = "Cotización realizada desde la zona de aliados, por: " + userName;

            return datosFijos;
        }

        internal static List<Architect.API.Tron.Contracts.Presupuesto.Cobertura> Coberturas(Contracts.Cotizacion.HogarTotal quoteInfo, Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos)
        {

            List<Architect.API.Tron.Contracts.Presupuesto.Cobertura> coberturas = new List<Architect.API.Tron.Contracts.Presupuesto.Cobertura>();

            foreach (Contracts.Comun.Cobertura item in from c in quoteInfo.coberturas where c.seleccionado select c)
            {
                coberturas.Add(Util.Cobertura(datosFijos, item.codigo));
            }

            //coberturas.Add(CovertQuoteToTron_Cobertura(datosFijos, 2002));
            //coberturas.Add(CovertQuoteToTron_Cobertura(datosFijos, 2024));
            //coberturas.Add(CovertQuoteToTron_Cobertura(datosFijos, 2027));

            return coberturas;
        }

        private static List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable> DatosVariable(Contracts.Cotizacion.HogarTotal quoteInfo, Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos)
        {
            List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable> datosVariables = new List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable>();
            int num_riesgo = datosFijos.Riesgos.FirstOrDefault().num_riesgo;


            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_PAIS", quoteInfo.pais));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_ESTADO", quoteInfo.provincia.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_PROV", quoteInfo.canton.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_LOCALIDAD", quoteInfo.distrito.ToString()));

            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_TIPO_OCUP_RGO", quoteInfo.ocupaciondelriesgo.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "TIP_SUSCRIPCION", quoteInfo.tipodesuscripcion.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "NUM_PISOS_EDIF", quoteInfo.numerodepisosedificacion.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_TIP_EDIF", quoteInfo.tipodeestrucdelaedificacion.ToString()));

            Util.Ocurrencias(datosVariables, num_riesgo, "NUM_MED_ROB", datosFijos, "COD_TIP_MED_ROB", quoteInfo.medidasdeseguridad);

            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COB_PDR_MESES", quoteInfo.mesesaampararporperdrentas.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_EDIFICIO", quoteInfo.sAEdificio.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_MOBILIARIO", quoteInfo.sAMobiliario.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_OBJ_VALIOSO", quoteInfo.sAObjetosvaliosos.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_DOMOS_TOTAL", quoteInfo.sADomocristalmarmolgranito.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_GAS_ALQ", quoteInfo.sAGastosalquiler.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_PER_REN", quoteInfo.sAPerdidaderentas.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_SA_RC", quoteInfo.sARespcivil.ToString()));

            // Coberturas
            //COB, A-INCENDIO
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_INCENDIO",
                                 quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2002 || c.codigo == 2010)) > 0 ? "S" : "N"));
            //COB. B-NATURALEZA CATASTRÓF
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_NC",
                                 quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2024 || c.codigo == 2025 || c.codigo == 2026 || c.codigo == 2055 || c.codigo == 2056 || c.codigo == 2057)) > 0 ? "S" : "N"));
            //COB. C-DAÑOS POR AGUA
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_DPA",
                                 quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2004 || c.codigo == 2012)) > 0 ? "S" : "N"));
            //COB. D-DOMO,CRIST,MÁRM,GRAN.
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_DCMG",
                                 quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2007)) > 0 ? "S" : "N"));
            //COB. E-ROBO
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_ROB",
                                 quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2014)) > 0 ? "S" : "N"));
            //COB. F-GASTOS DE ALQUILER
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_GPA",
                                 quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2017)) > 0 ? "S" : "N"));
            //COB, G-PÉRDIDA DE RENTAS
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_PDR",
                                 quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2018)) > 0 ? "S" : "N"));
            //COB. H-RESPONSABILIDAD CIVIL
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_RESP_CIVIL",
                                 quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2034)) > 0 ? "S" : "N"));
            //COB. Q-ASIST. EN LA VIVIENDA
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COB_AV",
                                 quoteInfo.coberturas.Count(c => c.seleccionado == true && (c.codigo == 2027)) > 0 ? "S" : "N"));

            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "NUM_DES_BIEN", "0"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_ACTUALIZA_VAL_REN", "N"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "NUM_PISO", "0"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "PCT_AJUSTE_GEN", quoteInfo.descuento.ToString()));



            return datosVariables;
        }

    }
}
