using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Architect.API.Tron.Contracts.Comun;
using Architect.Utilities.Extensions;

namespace Architect.API.Tron.Business.Emision
{
    internal static class HogarTotalConvertTo
    {

        internal static Architect.API.Tron.Contracts.Presupuesto.DatoFijo Tron(Contracts.Emision.HogarTotal quoteInfo)
        {

            Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos = DatosFijos(quoteInfo, quoteInfo.cod_ramo);
            Terceros(quoteInfo, datosFijos);
            datosFijos.DatosVariables = DatosVariable(quoteInfo, datosFijos);

            return datosFijos;
        }

        internal static Architect.API.Tron.Contracts.Presupuesto.DatoFijo DatosFijos(Contracts.Emision.HogarTotal quoteInfo, int branch)
        {

            //Datos fijos del presupuesto
            Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos = new Architect.API.Tron.Contracts.Presupuesto.DatoFijo()
            {
                cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]),
                num_poliza = quoteInfo.presupuesto,
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
                cod_cuadro_com = quoteInfo.cod_cuadro_com,
                cod_agt = quoteInfo.cod_agt,
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


            return datosFijos;
        }
        internal static List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable> DatosVariable(Contracts.Emision.HogarTotal quoteInfo, Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos)
        {
            List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable> datosVariables = new List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable>();
            int num_riesgo = 1;
            var propiedad = quoteInfo.propiedad[0];



            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "OTRA_SENAS_RGO1", propiedad.otrassenas, 2, 5));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "FOLIO_RGO1", propiedad.numerodefolio, 2, 6));
            if (propiedad.alturaedificio.IsNotEmpty())
            {
                datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "FOLIO_RGO2", propiedad.alturaedificio.ToString(), 2, 7, string.Format("{0} METRO(S)", propiedad.alturaedificio)));
            }
            else
            {
                datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "FOLIO_RGO2", "N/A", 2, 7, "N/A"));
            }
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "NUM_PISO", propiedad.numerodepiso.ToString(), 2, 10));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "ANO_CONST", propiedad.anodeconstruccion.ToString(), 2, 13));
            if (propiedad.alturaedificio.IsNotEmpty())
            {
                datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "NUM_METROS_CONSTRUIDOS", propiedad.alturaedificio.ToString(), 2, 15, string.Format("{0} METROS", propiedad.numerodefoliomadre)));
            }
            else
            {
                datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "NUM_METROS_CONSTRUIDOS", "0", 2, 15, "0"));
            }
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "ALTURA_EDIF", propiedad.alturaedificio.ToString(), 2, 16));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_SUB_ROB", "N", 2, 65));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "TIP_PLAN_ASIST", Convert.ToString(propiedad.tipoplan), 3, 99, ""));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_COLECTIVO", "N", 1, 900, "INDIVIDUAL"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "CERCA_RI_MAR_LAG_TA_CI", propiedad.CERCA_RI_MAR_LAG_TA_CI == 1 ? "S" : "N"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "DISTANCIA_MTS", propiedad.DISTANCIA_MTS.ToString()));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "INS_ELECT_ENTUB", propiedad.INS_ELECT_ENTUB == 1 ? "S" : "N"));

            return datosVariables;

        }

        internal static List<Architect.API.Tron.Contracts.Presupuesto.Tercero> Terceros(Contracts.Emision.HogarTotal quoteInfo, Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos)
        {
            datosFijos.Terceros = new List<Architect.API.Tron.Contracts.Presupuesto.Tercero>();
            datosFijos.DetalleDeTerceros = new List<Architect.API.Tron.Contracts.Presupuesto.DetalleDeTercero>();

            foreach (Contracts.Comun.tercero item in quoteInfo.terceros)
            {
                if (item.tipodetercero != 0)
                {
                    datosFijos.Terceros.Add(TerceroPresupuesto(datosFijos, item, item.tipodetercero));
                }
                else
                {
                    if (item.eltomadoreselmismoasegurado == 1)
                    {
                        datosFijos.Terceros.Add(TerceroPresupuesto(datosFijos, item, 2));
                    }
                }
                datosFijos.DetalleDeTerceros.Add(CambioTerceroPresupuesto(datosFijos, item));
            }
            return datosFijos.Terceros;
        }
        internal static Architect.API.Tron.Contracts.Presupuesto.Tercero TerceroPresupuesto(Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos, Contracts.Comun.tercero item, int tipodetercero)
        {
            Architect.API.Tron.Contracts.Presupuesto.Tercero result = new Architect.API.Tron.Contracts.Presupuesto.Tercero()
            {
                cod_cia = datosFijos.cod_cia,
                num_poliza = datosFijos.num_poliza,
                num_spto = datosFijos.num_spto,
                num_apli = datosFijos.num_apli,
                num_spto_apli = datosFijos.num_spto_apli,
                num_riesgo = 1,
                tip_benef = tipodetercero.ToString(),
                num_secu = 1,
                tip_docum = item.DocumentNumberType.ToString().IdentificationType(),
                cod_docum = Util.IdentificationFormat(item.DocumentNumberType, item.DocumentNumber),
                mca_principal = "N",
                mca_calculo = "N",
                mca_baja = "N",
                mca_vigente = "S",
                pct_participacion = 0,
                imp_cesion = 0
            };

            switch (tipodetercero)

            {
                case 0: //Titular.
                    result.tip_benef = "2"; //Asegurado
                    break;
                case 6: //Beneficiario pero esta opcion no esta disponible al dia de hoy.
                    result.tip_benef = "";
                    result.pct_participacion = item.porcentajeacredor;
                    break;
                case 8: //Acredor.
                    result.fec_vcto_cesion = item.vencimientodecesion;
                    result.imp_cesion = item.importedecesion;
                    result.num_prestamo = item.numerodeprestamo;
                    result.pct_participacion = item.porcentajeacredor;
                    break;
                case 10: //Desconocido.
                    result.mca_principal = "S";
                    break;
            }

            return result;
        }
        internal static Architect.API.Tron.Contracts.Presupuesto.DetalleDeTercero CambioTerceroPresupuesto(Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos, Contracts.Comun.tercero item)
        {
            Architect.API.Tron.Contracts.Presupuesto.DetalleDeTercero result = new Architect.API.Tron.Contracts.Presupuesto.DetalleDeTercero()
            {
                cod_cia = datosFijos.cod_cia,
                fec_tratamiento = DateTime.Today,
                tip_mvto_batch = "3",
                tip_docum = item.DocumentNumberType.ToString().IdentificationType(),
                cod_docum = Util.IdentificationFormat(item.DocumentNumberType, item.DocumentNumber),
                nom_tercero = item.nombre,
                ape1_tercero = item.apellido1,
                ape2_tercero = item.apellido2,
                fec_nacimiento = item.fechadenacimiento,
                mca_sexo = item.tercerosMca_sexo.ToString(),
                cod_est_civil = item.estadoCivil,
                tlf_numero = item.numerodetelefono,
                cod_pais = item.cod_pais,
                cod_estado = item.TProvincia,
                cod_prov = item.TCanton,
                cod_localidad = item.TDistrito,
                nom_domicilio1 = item.otrasenas,
                titular = (item.tipodetercero == 0),
                email = item.correoelectronico,

                cod_act_tercero = int.MinValue,
                mca_fisico = "S",
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
            };
            //Si es tipo de documento es cedula jurida
            if (result.tip_docum == "CJU")
            {
                result.mca_fisico = "N";
            }
            return result;
        }

    }
}
