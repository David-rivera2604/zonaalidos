using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace Architect.API.Tron.Business.Cotizacion
{
    internal static class APIConvertTo
    {

        internal static Architect.API.Tron.Contracts.Presupuesto.DatoFijo Tron(Contracts.Presupuesto.API.Presupuesto quoteInfo, int agentCode, string userName)
        {

            Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos = DatosFijos(quoteInfo, agentCode, userName);

            datosFijos.Riesgos = Util.DatosDelRiesgo(datosFijos, "Riesgo nro. 1");
            foreach (Contracts.Presupuesto.API.Riesgo riesgo in quoteInfo.Riesgos)
            {
                datosFijos.Terceros = Terceros(datosFijos, riesgo);
                datosFijos.DetalleDeTerceros = DetalleDeTerceros(datosFijos, riesgo);
                datosFijos.Coberturas = Coberturas(datosFijos, riesgo);
                datosFijos.DesgloseEconomico = DesgloseEconomico(datosFijos, riesgo);
                datosFijos.DatosVariables = DatosVariable(datosFijos, riesgo);
                if (datosFijos.tip_docum.IsEmpty())
                {
                    datosFijos.tip_docum = riesgo.Terceros.First().tip_docum;
                    datosFijos.cod_docum = riesgo.Terceros.First().cod_docum;
                }
            }

            return datosFijos;
        }

        internal static Architect.API.Tron.Contracts.Presupuesto.DatoFijo DatosFijos(Contracts.Presupuesto.API.Presupuesto quoteInfo, int agentCode, string userName)
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
                cod_ramo = quoteInfo.cod_ramo,
                fec_validez = DateTime.MinValue,
                fec_emision = DateTime.MinValue,
                fec_emision_spto = DateTime.MinValue,
                fec_efec_poliza = quoteInfo.fec_efec_poliza,
                fec_vcto_poliza = quoteInfo.fec_vcto_poliza,
                fec_efec_spto = DateTime.MinValue,
                fec_vcto_spto = DateTime.MinValue,
                tip_duracion = 0,
                num_riesgos = 0,
                cod_mon = quoteInfo.cod_mon,
                cod_fracc_pago = quoteInfo.cod_fracc_pago,
                cant_renovaciones = 0,
                num_renovaciones = 0,
                tip_coaseguro = 0,
                num_secu_grupo = 0,
                cod_spto = 0,
                sub_cod_spto = 0,
                txt_motivo_spto = "Cotización realizada desde la zona de aliados, por: " + userName,
                cod_cuadro_com = 100,
                cod_agt = agentCode,
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
                num_orden = 0,
                num_poliza_grupo = string.Empty,
                num_contrato = int.MinValue,
                num_subcontrato = int.MinValue,
                tip_spto = "XX"
            };

            if (quoteInfo.num_contrato > 0)
            {
                datosFijos.num_contrato = quoteInfo.num_contrato;
                datosFijos.num_subcontrato = quoteInfo.num_subcontrato;
                datosFijos.num_poliza_grupo = quoteInfo.num_poliza_grupo;
            }

            return datosFijos;
        }

        internal static List<Architect.API.Tron.Contracts.Presupuesto.Tercero> Terceros(Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos, Contracts.Presupuesto.API.Riesgo riesgo)
        {
            List<Architect.API.Tron.Contracts.Presupuesto.Tercero> terceros = new List<Architect.API.Tron.Contracts.Presupuesto.Tercero>();

            foreach (Contracts.Presupuesto.API.Tercero tercero in riesgo.Terceros)
            {
                terceros.Add(Util.Tercero(datosFijos, tercero.tip_docum, tercero.cod_docum, Convert.ToInt32(tercero.tip_benef)));
            }
            return terceros;
        }

        internal static List<Architect.API.Tron.Contracts.Presupuesto.DetalleDeTercero> DetalleDeTerceros(Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos, Contracts.Presupuesto.API.Riesgo riesgo)
        {
            List<Architect.API.Tron.Contracts.Presupuesto.DetalleDeTercero> terceros = new List<Architect.API.Tron.Contracts.Presupuesto.DetalleDeTercero>();

            foreach (Contracts.Presupuesto.API.Tercero tercero in riesgo.Terceros)
            {
                terceros.Add(new Architect.API.Tron.Contracts.Presupuesto.DetalleDeTercero()
                {
                    tip_docum = tercero.tip_docum,
                    cod_docum = tercero.cod_docum,
                    nom_tercero = tercero.nom_tercero,
                    ape1_tercero = tercero.ape1_tercero,
                    ape2_tercero = tercero.ape2_tercero,
                    fec_nacimiento = tercero.fec_nacimiento,
                    mca_sexo = tercero.mca_sexo,
                    cod_est_civil = tercero.cod_est_civil,
                    tlf_numero = tercero.tlf_numero,
                    cod_pais = tercero.cod_pais,
                    cod_estado = tercero.cod_estado,
                    cod_prov = tercero.cod_prov,
                    cod_localidad = tercero.cod_localidad,
                    nom_domicilio1 = tercero.nom_domicilio1,
                    titular = (tercero.tip_benef == "2"),
                    email = tercero.email,
                    cod_act_tercero = int.MinValue,
                    mca_fisico = tercero.tip_docum.Equals("CJU", StringComparison.CurrentCultureIgnoreCase) ? "N" : "S",
                    tip_domicilio = int.MinValue,
                    tip_domicilio_com = int.MinValue,
                    cod_prov_com = int.MinValue,
                    tip_cargo = int.MinValue,
                    tip_act_economica = int.MinValue,
                    cod_ocupacion = int.MinValue,
                    cod_profesion = int.MinValue,
                    tip_etiqueta = int.MinValue,
                    cod_estado_com = int.MinValue,
                    cod_estado_etiqueta = int.MinValue,
                    cod_prov_etiqueta = int.MinValue,
                    tip_tarjeta = int.MinValue,
                    cod_tarjeta = int.MinValue,
                    cod_localidad_com = int.MinValue,
                    cod_localidad_etiqueta = int.MinValue,
                    cod_compensacion = int.MinValue,
                    cod_causa_inh_trc = int.MinValue,
                    cod_exp_carnet_con = int.MinValue
                });
            }

            return terceros;
        }

        internal static List<Architect.API.Tron.Contracts.Presupuesto.Cobertura> Coberturas(Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos, Contracts.Presupuesto.API.Riesgo riesgo)
        {
            List<Architect.API.Tron.Contracts.Presupuesto.Cobertura> coberturas = new List<Architect.API.Tron.Contracts.Presupuesto.Cobertura>();
            Architect.API.Tron.Contracts.Presupuesto.Cobertura coverageQuote = null;
            foreach (Contracts.Presupuesto.API.Cobertura cobertura in riesgo.Coberturas)
            {
                coverageQuote = Util.Cobertura(datosFijos, cobertura.cod_cob);
                coverageQuote.cod_mon_capital = datosFijos.cod_mon;
                coverageQuote.suma_aseg = cobertura.suma_aseg;
                coverageQuote.suma_aseg_spto = cobertura.suma_aseg;
                coverageQuote.tasa_cob = cobertura.tasa_cob;
                coverageQuote.num_secu = coberturas.Count() + 1;
                coberturas.Add(coverageQuote);
            }
            return coberturas;
        }

        internal static List<Architect.API.Tron.Contracts.Presupuesto.DesgloseEconomico> DesgloseEconomico(Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos, Contracts.Presupuesto.API.Riesgo riesgo)
        {
            List<Architect.API.Tron.Contracts.Presupuesto.DesgloseEconomico> desgloses = new List<Architect.API.Tron.Contracts.Presupuesto.DesgloseEconomico>();
            foreach (Contracts.Presupuesto.API.Cobertura cobertura in riesgo.Coberturas)
            {
                foreach (Contracts.Presupuesto.API.DesgloseEconomico desglose in cobertura.DesgloseEconomico)
                {
                    desgloses.Add(new Contracts.Presupuesto.DesgloseEconomico()
                    {
                        cod_cia = datosFijos.cod_cia,
                        num_poliza = datosFijos.num_poliza,
                        num_spto = datosFijos.num_spto,
                        num_apli = datosFijos.num_apli,
                        num_spto_apli = datosFijos.num_spto_apli,
                        num_riesgo = riesgo.num_riesgo,
                        num_periodo = 1,
                        cod_cob = cobertura.cod_cob,
                        cod_ramo = datosFijos.cod_ramo,
                        cod_desglose = desglose.cod_desglose,
                        cod_eco = desglose.cod_eco,
                        imp_acumulado_anual = desglose.imp_anual,
                        imp_anual = desglose.imp_anual,
                        imp_spto = desglose.imp_anual
                    });
                }
                desgloses.Add(new Contracts.Presupuesto.DesgloseEconomico()
                {
                    cod_cia = datosFijos.cod_cia,
                    num_poliza = datosFijos.num_poliza,
                    num_spto = datosFijos.num_spto,
                    num_apli = datosFijos.num_apli,
                    num_spto_apli = datosFijos.num_spto_apli,
                    num_riesgo = riesgo.num_riesgo,
                    num_periodo = 1,
                    cod_cob = cobertura.cod_cob,
                    cod_ramo = datosFijos.cod_ramo,
                    cod_desglose = 8,
                    cod_eco = 1,
                    imp_acumulado_anual = 0,
                    imp_anual = 0,
                    imp_spto = 0
                });
            }
            return desgloses;
        }

        private static List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable> DatosVariable(Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos, Contracts.Presupuesto.API.Riesgo riesgo)
        {
            List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable> datosVariables = new List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable>();
            Architect.API.Tron.Contracts.Presupuesto.DatoVariable item;

            foreach (Contracts.Presupuesto.API.DatoVariable dato in riesgo.DatosVariables)
            {
                item = Util.DatoVariable(datosFijos, riesgo.num_riesgo, dato.cod_campo, dato.val_campo, dato.cod_campo == "MCA_COLECTIVO" ? 1 : 3, 1, dato.txt_campo);
                item.num_secu = datosVariables.Count() + 1;
                datosVariables.Add(item);
            }

            return datosVariables;
        }

    }
}
