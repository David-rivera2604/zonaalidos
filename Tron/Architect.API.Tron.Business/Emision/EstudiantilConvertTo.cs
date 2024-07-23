using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Architect.API.Tron.Business.Emision
{
    internal static class EstudiantilConvertTo
    {

        internal static Contracts.Presupuesto.DatoFijo Tron(Contracts.Emision.Estudiantil quoteInfo)
        {

            Contracts.Presupuesto.DatoFijo datosFijos = DatosFijos(quoteInfo, quoteInfo.cod_ramo);
            Terceros(quoteInfo, datosFijos);
            datosFijos.DatosVariables = DatosVariable(quoteInfo, datosFijos);

            return datosFijos;
        }

        internal static Contracts.Presupuesto.DatoFijo DatosFijos(Contracts.Emision.Estudiantil quoteInfo, int branch)
        {

            //Datos fijos del presupuesto
            Contracts.Presupuesto.DatoFijo datosFijos = new Contracts.Presupuesto.DatoFijo()
            {
                cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]),
                num_poliza = quoteInfo.presupuesto,
                num_spto = 0,
                num_apli = 0,
                num_spto_apli = 0,
                cod_sector = 4,//Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.HogarTotal.cod_sector"]),
                cod_ramo = branch,
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
                num_contrato = Int32.MinValue,//quoteInfo.contrato,
                num_subcontrato = Int32.MinValue,//quoteInfo.subcontrato,
                num_poliza_grupo = String.Empty, //quoteInfo.polizagrupo,
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

        internal static List<Contracts.Presupuesto.DatoVariable> DatosVariable(Contracts.Emision.Estudiantil quoteInfo, Contracts.Presupuesto.DatoFijo datosFijos)
        {
            List<Contracts.Presupuesto.DatoVariable> datosVariables = new List<Contracts.Presupuesto.DatoVariable>();

            //datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "OTRA_SENAS_RGO1", quoteInfo.otrassenas, 2, 5));

            return datosVariables;
        }

        internal static List<Contracts.Presupuesto.Tercero> Terceros(Contracts.Emision.Estudiantil quoteInfo, Contracts.Presupuesto.DatoFijo datosFijos)
        {
            datosFijos.Terceros = new List<Contracts.Presupuesto.Tercero>();
            datosFijos.DetalleDeTerceros = new List<Contracts.Presupuesto.DetalleDeTercero>();

            // Se verifica si existe un beneficio con el indicador que es el mismo para todos los riesgos.
            Contracts.Comun.tercero beneficiario = quoteInfo.terceros.Where(c => c.tipodetercero == Contracts.Comun.tercero.BENEFICIARIO && c.elbeneficiarioeselmismotodoslosriesgos == 1).FirstOrDefault();
            if (beneficiario != null)
            {
                quoteInfo.terceros.Remove(beneficiario);
            }

            foreach (Contracts.Comun.tercero item in quoteInfo.terceros)
            {
                if (item.tipodetercero != Contracts.Comun.tercero.TOMADOR)
                {

                    datosFijos.Terceros.Add(TerceroPresupuesto(datosFijos, item, item.tipodetercero));
                    if (beneficiario != null && item.tipodetercero == Contracts.Comun.tercero.ASEGURADO)
                    {
                        beneficiario.numeroderiesgo = item.numeroderiesgo;
                        datosFijos.Terceros.Add(TerceroPresupuesto(datosFijos, beneficiario, Contracts.Comun.tercero.BENEFICIARIO));

                        if (!datosFijos.DetalleDeTerceros.Exists(r => r.cod_docum == beneficiario.DocumentNumber))
                        {
                            datosFijos.DetalleDeTerceros.Add(CambioTerceroPresupuesto(datosFijos, beneficiario));
                        }
                    }
                }
                else
                {
                    if (item.eltomadoreselmismoasegurado == 1)
                    {
                        datosFijos.Terceros.Add(TerceroPresupuesto(datosFijos, item, Contracts.Comun.tercero.ASEGURADO));
                    }
                }

                datosFijos.DetalleDeTerceros.Add(CambioTerceroPresupuesto(datosFijos, item));
            }

            //En caso de existir un asegurado con el indicador de tomador
            Contracts.Comun.tercero aseguradoTomador = quoteInfo.terceros.Where(c => c.tipodetercero == Contracts.Comun.tercero.ASEGURADO && c.elaseguradoeselmismotomador == 1).FirstOrDefault();
            if (aseguradoTomador != null)
            {
                aseguradoTomador.tipodetercero = Contracts.Comun.tercero.TOMADOR;
                datosFijos.DetalleDeTerceros.Add(CambioTerceroPresupuesto(datosFijos, aseguradoTomador));
                aseguradoTomador.tipodetercero = Contracts.Comun.tercero.ASEGURADO;
            }


            return datosFijos.Terceros;
        }

        internal static Contracts.Presupuesto.Tercero TerceroPresupuesto(Contracts.Presupuesto.DatoFijo datosFijos, Contracts.Comun.tercero item, int tipodetercero)
        {
            Contracts.Presupuesto.Tercero result = new Contracts.Presupuesto.Tercero()
            {
                cod_cia = datosFijos.cod_cia,
                num_poliza = datosFijos.num_poliza,
                num_spto = datosFijos.num_spto,
                num_apli = datosFijos.num_apli,
                num_spto_apli = datosFijos.num_spto_apli,
                num_riesgo = item.numeroderiesgo,
                tip_benef = Convert.ToString(item.tipodetercero),
                num_secu = 1,
                tip_docum = item.DocumentNumberType.ToString().IdentificationType(),
                cod_docum = item.DocumentNumber.DocumentNumber(item.DocumentNumberType.ToString()),
                mca_principal = "N",
                mca_calculo = "N",
                mca_baja = "N",
                mca_vigente = "S",
                pct_participacion = 0,
                imp_cesion = 0,
                tip_relac = Convert.ToString(item.parentesco),
            };

            switch (tipodetercero)

            {
                case 0: //Titular.
                    result.tip_benef = "2"; //Asegurado
                    break;
                case 6: //Beneficiario pero esta opcion no esta disponible al dia de hoy.
                    result.tip_benef = "6";
                    result.tip_relac = Convert.ToString(item.parentesco);
                    result.pct_participacion = item.porcentaje;
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

        internal static Contracts.Presupuesto.DetalleDeTercero CambioTerceroPresupuesto(Contracts.Presupuesto.DatoFijo datosFijos, Contracts.Comun.tercero item)
        {
            Contracts.Presupuesto.DetalleDeTercero result = new Contracts.Presupuesto.DetalleDeTercero()
            {
                cod_cia = datosFijos.cod_cia,
                fec_tratamiento = DateTime.Today,
                tip_mvto_batch = "3",
                tip_docum = item.DocumentNumberType.ToString().IdentificationType(),
                cod_docum = item.DocumentNumber.DocumentNumber(item.DocumentNumberType.ToString()),
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
