using Architect.API.Tron.Contracts.Comun;
using Architect.API.Tron.Contracts.Variaciones;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Tron.Business.Variaciones
{
    internal static class MapfreMasConvertFrom
    {
        internal static Contracts.Variaciones.MapfreMas Quote(Contracts.Poliza.DatoFijo tronQuoteInfo)
        {
            Contracts.Variaciones.MapfreMas quoteInfo = new Contracts.Variaciones.MapfreMas()
            {
                cod_cia = tronQuoteInfo.cod_cia,
                cod_ramo = tronQuoteInfo.cod_ramo,
                num_poliza = tronQuoteInfo.num_poliza,
                cod_mon = tronQuoteInfo.cod_mon,
                cod_fracc_pago = tronQuoteInfo.cod_fracc_pago,
                fec_efec_poliza = tronQuoteInfo.fec_efec_poliza,
                fec_vcto_poliza = tronQuoteInfo.fec_vcto_poliza,
                contrato = tronQuoteInfo.num_contrato,
                subcontrato = tronQuoteInfo.num_subcontrato,
                polizagrupo = tronQuoteInfo.num_poliza_grupo,
                MCA_FEC_EFEC_SYS = "N",
                cod_agt = tronQuoteInfo.cod_agt,
                cod_cuadro_com = tronQuoteInfo.cod_cuadro_com,
                coberturas = new List<Contracts.Comun.Cobertura>()
            };

            quoteInfo = DatosVariables(quoteInfo, tronQuoteInfo);

            foreach (Contracts.Poliza.Cobertura item in tronQuoteInfo.Coberturas)
            {
                quoteInfo.coberturas.Add(new Contracts.Comun.Cobertura()
                {
                    seleccionado = true,
                    requerida = true,
                    codigo = item.cod_cob,
                    nombre = item.nom_cob,
                    capital = item.suma_aseg,
                    primatotal = item.imp_total,
                    deducible = item.deducible,
                    riesgo = item.num_riesgo
                });
                switch (item.cod_cob)
                {
                    case 3005:
                        if (quoteInfo.IMP_AUTO_RAD.IsEmpty())
                        {
                            quoteInfo.IMP_AUTO_RAD = item.suma_aseg;
                        }
                        break;
                    case 3006:
                        if (quoteInfo.IMP_AUTO_ROB.IsEmpty())
                        {
                            quoteInfo.IMP_AUTO_ROB = item.suma_aseg;
                        }
                        break;
                    case 3009:
                        if (quoteInfo.IMP_AUTO_CRI.IsEmpty())
                        {
                            quoteInfo.IMP_AUTO_CRI = Convert.ToInt32(item.suma_aseg);
                        }
                        break;
                }
            }


            return DatosVariables(quoteInfo, tronQuoteInfo);
        }

        private static Contracts.Variaciones.MapfreMas DatosVariables(Contracts.Variaciones.MapfreMas quoteInfo, Architect.API.Tron.Contracts.Poliza.DatoFijo tronQuoteInfo)
        {
            foreach (Contracts.Poliza.DatoVariable item in tronQuoteInfo.DatosVariables)
            {
                switch (item.cod_campo)
                {
                    case "COD_ZONA_CIRCUL":
                        quoteInfo.cod_zona_circul = Convert.ToInt32(item.val_campo);
                        quoteInfo.cod_zona_circulDesc = item.txt_campo;
                        break;
                    case "NUM_SOLICITUD":
                        break;
                    case "TXT_DET_COND":
                        break;
                    case "TXT_DET_COND1":
                        break;
                    case "PCT_DCTO_COL":
                        break;
                    case "COD_MARCA":
                        quoteInfo.cod_marca = Convert.ToInt32(item.val_campo);
                        quoteInfo.cod_marcaDesc = item.txt_campo;
                        break;
                    case "COD_MODELO":
                        quoteInfo.cod_modelo = Convert.ToInt32(item.val_campo);
                        quoteInfo.cod_modeloDesc = item.txt_campo;
                        break;
                    case "COD_SUB_MODELO":
                        break;
                    case "PCT_DCTO_AUTO_COR":
                        break;
                    case "COD_COLOR":
                        quoteInfo.COD_COLOR = Convert.ToInt32(item.val_campo);
                        quoteInfo.COD_COLORDesc = item.txt_campo;
                        break;
                    case "PCT_DCTO_AUTO_PAR":
                        break;
                    case "ANIO_SUB_MODELO":
                        quoteInfo.ANIO_SUB_MODELO = Convert.ToInt32(item.val_campo);
                        break;
                    case "PCT_DCTO_AUTO_COM":
                        break;
                    case "NUM_MATRICULA":
                        quoteInfo.NUM_MATRICULA = item.val_campo;
                        break;
                    case "NUM_MOTOR":
                        quoteInfo.NUM_MOTOR = item.val_campo;
                        break;
                    case "VAL_CAPACIDAD":
                        quoteInfo.VAL_CAPACIDAD = Convert.ToInt32(item.val_campo);
                        break;
                    case "DES_TIP_CILINDRAJE":
                        quoteInfo.DES_TIP_CILINDRAJE = item.val_campo;
                        break;
                    case "VAL_PESO":
                        quoteInfo.VAL_PESO = Convert.ToInt32(item.val_campo);
                        break;
                    case "COD_CHASSIS":
                        quoteInfo.COD_CHASSIS = item.val_campo;
                        break;
                    case "COD_TIP_VEHI":
                        quoteInfo.cod_tip_vehi = Convert.ToInt32(item.val_campo);
                        quoteInfo.cod_tip_vehiDesc = item.txt_campo;
                        break;
                    case "COD_USO_VEHI":
                        quoteInfo.cod_uso_vehi = Convert.ToInt32(item.val_campo);
                        quoteInfo.cod_uso_vehiDesc = item.txt_campo;
                        break;
                    case "MCA_CERO_KM":
                        quoteInfo.MCA_CERO_KM = item.val_campo == "N" ? 2 : 1;
                        break;
                    case "MCA_AUTO_GPS":
                        quoteInfo.MCA_AUTO_GPS = item.val_campo == "N" ? 2 : 1;
                        break;
                    case "MCA_AUTO_GPS_CMS":
                        quoteInfo.MCA_AUTO_GPS_CMS = item.val_campo == "N" ? 2 : 1;
                        break;
                    case "MCA_MONITOREO_GPS":
                        quoteInfo.MCA_MONITOREO_GPS = item.val_campo == "N" ? 2 : 1;
                        break;
                    case "COD_PLAN_AUTO":
                        quoteInfo.COD_PLAN_AUTO = Convert.ToInt32(item.val_campo);
                        quoteInfo.COD_PLAN_AUTODesc = item.txt_campo;
                        break;
                    case "MCA_VR":
                        quoteInfo.MCA_VR = item.val_campo == "N" ? 2 : 1;
                        break;
                    case "IMP_VR":
                        quoteInfo.IMP_VR = Convert.ToDouble(item.val_campo);
                        break;
                    case "MCA_PRA":
                        quoteInfo.MCA_PRA = item.val_campo == "N" ? 2 : 1;
                        break;
                    case "IMP_PRA":
                        break;
                    case "MCA_AUTO_RC":
                        break;
                    case "IMP_AUTO_RC":
                        quoteInfo.IMP_AUTO_RC = Convert.ToInt32(item.val_campo);
                        break;
                    case "DED_AUTO_RC":
                        quoteInfo.DED_AUTO_RC = Convert.ToInt32(item.val_campo);
                        break;
                    case "MCA_AUTO_GMO":
                        break;
                    case "IMP_AUTO_GMO":
                        quoteInfo.IMP_AUTO_GMO = Convert.ToInt32(item.val_campo);
                        break;
                    case "MCA_AUTO_ACO":
                        break;
                    case "IMP_AUTO_ACO":
                        quoteInfo.IMP_AUTO_ACO = Convert.ToInt32(item.val_campo);
                        break;
                    case "MCA_AUTO_CYV":
                        break;
                    case "IMP_AUTO_CYV":
                        quoteInfo.IMP_AUTO_CYV = Convert.ToInt32(item.val_campo);
                        break;
                    case "DED_AUTO_CYV":
                        quoteInfo.DED_AUTO_CYV = Convert.ToInt32(item.val_campo);
                        quoteInfo.DED_AUTO_CYV_Desc = item.txt_campo;
                        break;
                    case "MCA_AUTO_RAD":
                        break;
                    case "IMP_AUTO_RAD":
                        quoteInfo.IMP_AUTO_RAD = Convert.ToInt32(item.val_campo);
                        break;
                    case "DED_AUTO_RAD":
                        quoteInfo.DED_AUTO_RAD = Convert.ToInt32(item.val_campo);
                        quoteInfo.DED_AUTO_RAD_Desc = item.txt_campo;
                        break;
                    case "MCA_AUTO_ROB":
                        break;
                    case "IMP_AUTO_ROB":
                        quoteInfo.IMP_AUTO_ROB = Convert.ToInt32(item.val_campo);
                        break;
                    case "DED_AUTO_ROB":
                        quoteInfo.DED_AUTO_ROB = Convert.ToInt32(item.val_campo);
                        quoteInfo.DED_AUTO_ROB_Desc = item.txt_campo;
                        break;
                    case "IMP_AUTO_EQESP":
                        quoteInfo.IMP_AUTO_EQESP = Convert.ToInt32(item.val_campo);
                        break;
                    case "DED_AUTO_EQESP":
                        quoteInfo.DED_AUTO_EQESP = Convert.ToInt32(item.val_campo);
                        break;
                    case "MCA_AUTO_NEUM":
                        break;
                    case "IMP_AUTO_NEUM":
                        quoteInfo.IMP_AUTO_NEUM = Convert.ToInt32(item.val_campo);
                        break;
                    case "MCA_AUTO_MECA":
                        break;
                    case "IMP_AUTO_MECA":
                        quoteInfo.IMP_AUTO_MECA = Convert.ToInt32(item.val_campo);
                        break;
                    case "MCA_AUTO_MAP":
                        break;
                    case "MCA_AUTO_CRI":
                        break;
                    case "IMP_AUTO_CRI":
                        quoteInfo.IMP_AUTO_CRI = Convert.ToInt32(item.val_campo);
                        break;
                    case "DED_AUTO_CRI":
                        quoteInfo.DED_AUTO_CRI = Convert.ToInt32(item.val_campo);
                        break;
                    case "MCA_AUTO_CAM":
                        break;
                    case "MCA_DESC_CLIENTE_NUEVO":
                        quoteInfo.MCA_DESC_CLIENTE_NUEVO = item.val_campo == "N" ? 2 : 1;
                        break;
                    case "TIP_BENEFICIO":
                        break;
                    case "PCT_AJUSTE_GEN":
                        if (item.val_campo != string.Empty)
                        {
                           // quoteInfo.PCT_AJUSTE_GEN = Convert.ToInt32(Convert.ToDecimal(item.val_campo));
                        }
                        break;
                    case "MCA_REEMISION":
                        break;
                    case "COD_MODALIDAD":
                        break;
                    case "COD_CERT_FIRMA_CLIENTE":
                        break;
                    case "MCA_AUTO_SUST":
                        break;
                    case "DED_AUTO_SUST":
                        break;
                    case "MCA_TIP_FIRMA":
                        break;
                    case "MCA_GARANTIA_EXTENDIDA":
                        break;
                    case "MCA_COLECTIVO":
                        break;
                }
            }
            return quoteInfo;
        }

        public static Contracts.Variaciones.MapfreMas SetTipoProducto(Contracts.Variaciones.MapfreMas quoteInfo)
        {
            switch (quoteInfo.COD_PLAN_AUTO)
            {
                case 31:
                    quoteInfo.tipo_prod = "basico";
                    quoteInfo.tipo_prodDesc = "Básico";
                    break;
                case 32:
                    quoteInfo.tipo_prod = "amplio";
                    quoteInfo.tipo_prodDesc = "Amplio";
                    break;
                case 33:
                    quoteInfo.tipo_prod = "plus";
                    quoteInfo.tipo_prodDesc = "Plus";
                    break;
                case 34:
                    quoteInfo.tipo_prod = "oro";
                    quoteInfo.tipo_prodDesc = "Oro";
                    break;
                case 35:
                    quoteInfo.tipo_prod = "plata";
                    quoteInfo.tipo_prodDesc = "Plata";
                    break;
                case 36:
                    quoteInfo.tipo_prod = "trebol";
                    quoteInfo.tipo_prodDesc = "Trebol";
                    break;
                case 37:
                    quoteInfo.tipo_prod = "trebolrc";
                    quoteInfo.tipo_prodDesc = "Trébol RC";
                    break;
            }

            return quoteInfo;
        }

        internal static Contracts.Variaciones.MapfreMas Quote(Contracts.Variaciones.MapfreMas quoteInfo, Architect.API.Tron.Contracts.Poliza.DatoFijo tronQuoteInfo)
        {
            int riesgo = 0;
            if (tronQuoteInfo.Coberturas != null)
            {
                if (tronQuoteInfo.Coberturas?.Count == 1)
                {
                    quoteInfo.Error = tronQuoteInfo.Coberturas[0].txt_error;
                }
                foreach (Architect.API.Tron.Contracts.Poliza.Cobertura item in tronQuoteInfo.Coberturas)
                {
                    foreach (Contracts.Comun.Cobertura itemQuote in quoteInfo.coberturas)
                    {
                        if (item.cod_cob == itemQuote.codigo)
                        {
                            itemQuote.seleccionado = true;

                            itemQuote.codigo = item.cod_cob;
                            itemQuote.nombre = item.nom_cob;
                            itemQuote.capital = item.suma_aseg;
                            itemQuote.primatotal = item.imp_total;
                            itemQuote.deducible = item.deducible;
                            itemQuote.riesgo = item.num_riesgo;
                            itemQuote.error = item.txt_error;
                            if (quoteInfo.presupuesto.IsEmpty())
                            {
                                quoteInfo.presupuesto = item.num_poliza;
                            }

                            riesgo = item.num_riesgo;
                            break;
                        }
                        else if (!itemQuote.seleccionado)
                        {
                            itemQuote.capital = 0;
                            itemQuote.primatotal = 0;
                            itemQuote.deducible = string.Empty;
                            itemQuote.error = string.Empty;
                        }
                    }

                }
            }

            if (tronQuoteInfo.Calculado?.Recibos != null)
            {
                double importeAnual = 0;
                bool setvalues = true;
                quoteInfo.plandepago = new List<Contracts.Comun.PlanDePago>();
                foreach (Architect.API.Tron.Contracts.Poliza.ReciboCalculado item in tronQuoteInfo.Calculado.Recibos)
                {
                    importeAnual = item.IMP_RECIBO;
                    quoteInfo.plandepago.Add(new Contracts.Comun.PlanDePago()
                    {
                        recibo = item.NUM_RECIBO,
                        cuota = item.NUM_CUOTA,
                        numspto = item.NUM_SPTO,
                        tipsituacion = item.TIP_SITUACION,
                        fechadesde = item.FEC_EFEC_RECIBO,
                        fechahasta = item.FEC_VCTO_RECIBO,
                        primaneta = item.IMP_NETA,
                        iVA = item.IMP_IMPTOS,
                        recargoporfraccionamiento = item.IMP_INTERES,
                        importetotal = item.IMP_RECIBO
                    });
                    //if (setvalues)
                    //{
                    //    quoteInfo.resumen = new Contracts.Cotizacion.resumen()
                    //    {
                    //        cuotas = tronQuoteInfo.Recibos.Count,
                    //        primaneta = item.imp_neta + item.imp_recargo,
                    //        iVA = item.imp_imptos,
                    //        recargoporfraccionamiento = item.imp_interes,
                    //        importetotal = item.imp_recibo
                    //    };
                    //    setvalues = false;
                    //}
                }

                //if (quoteInfo.cod_fracc_pago == 1)
                //{
                //    double amount = 0;
                //    quoteInfo.plandepagoporfrecuencia = new List<Contracts.Cotizacion.plandepagoporfrecuencia>();
                //    foreach (Architect.API.Tron.Contracts.Ramo.A1001403 item in Architect.API.Tron.DataAccess.PorRamo.FrecuenciaDePago(tronQuoteInfo.cod_cia, tronQuoteInfo.cod_ramo, tronQuoteInfo.cod_mon))
                //    {
                //        amount = (importeAnual / item.cod_fracc_pago) + ((importeAnual / item.cod_fracc_pago) * (item.pct_fracc_pago / 100));
                //        quoteInfo.plandepagoporfrecuencia.Add(new Contracts.Cotizacion.plandepagoporfrecuencia()
                //        {
                //            codigo = item.cod_fracc_pago,
                //            frecuencia = item.nom_fracc_pago,
                //            recardoporfraccionamiento = item.pct_fracc_pago,
                //            importetotal = amount
                //        });
                //    }
                //}

            }

            // RANGO DE MESES DEBE ESTAR ENTRE 1 Y 12 MESES &lt;COB_PDR_MESES&gt;</txt_error>
            if (tronQuoteInfo.DatosDelProceso != null && tronQuoteInfo.DatosDelProceso.txt_error.IsNotEmpty())
            {
                quoteInfo.Error = tronQuoteInfo.DatosDelProceso.txt_error;
            }
            if (quoteInfo.Error != null)
            {
                quoteInfo.Mensaje = quoteInfo.Error;
                if (quoteInfo.Mensaje.StartsWith("ORA-", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (quoteInfo.Mensaje.IndexOf(':') > 0)
                    {
                        quoteInfo.Mensaje = quoteInfo.Mensaje.Substring(quoteInfo.Mensaje.IndexOf(':') + 1).Trim();
                    }

                    quoteInfo.Mensaje = quoteInfo.Mensaje.Substring(0, 1).ToUpper() + quoteInfo.Mensaje.Substring(1).ToLower();
                }
            }

            if (tronQuoteInfo.Terceros != null)
            {
                Terceros(quoteInfo, tronQuoteInfo);
            }

            quoteInfo.AvailableCoverages = getAvailableCoverages(quoteInfo.num_poliza, riesgo);

            return GetEnableSumaAsegurada(quoteInfo);
        }

        public static Contracts.Variaciones.MapfreMas GetEnableSumaAsegurada(Contracts.Variaciones.MapfreMas quoteInfo)
        {
            List<g1010031> SumAseguradaTotales = Architect.API.Tron.DataAccess.Variaciones.VariacionIssue.GetSumaAseguradaPorRamo(quoteInfo.cod_cia, quoteInfo.cod_ramo);
            List<g1010031> SumAseguradaPoliza = new List<g1010031>();

            foreach(var item in quoteInfo.coberturas)
            {
                var find = SumAseguradaTotales.Where(s => s.cod_cob == item.codigo);

                if (find.Any())
                {
                    SumAseguradaPoliza.AddRange(find);
                }
            }

            foreach(var item in SumAseguradaPoliza)
            {
                switch (item.cod_campo)
                {
                    case "IMP_AUTO_RC":
                        quoteInfo.AUTO_RC = true;
                        break;
                    case "IMP_AUTO_CYV":
                        quoteInfo.AUTO_CYV = true;
                        break;
                    case "IMP_AUTO_ROB":
                        quoteInfo.AUTO_ROB = true;
                        break;
                    case "IMP_AUTO_GMO":
                        quoteInfo.AUTO_GMO = true;
                        break;
                    case "IMP_AUTO_ACO":
                        quoteInfo.AUTO_ACO = true;
                        break;
                    case "IMP_AUTO_RAD":
                        quoteInfo.AUTO_RAD = true;
                        break;
                    case "IMP_AUTO_EQESP":
                        quoteInfo.AUTO_EQESP = true;
                        break;
                    case "IMP_AUTO_CRI":
                        quoteInfo.AUTO_CRI = true;
                        break;
                    case "IMP_AUTO_NEUM":
                        quoteInfo.AUTO_NEUM = true;
                        break;
                    case "IMP_AUTO_MECA":
                        quoteInfo.AUTO_MECA = true;
                        break;
                }
            }

            return quoteInfo;
        }

        private static List<Cobertura> getAvailableCoverages(string num_poliza, int riesgo)
        {
            List<Cobertura> coberturas = new List<Cobertura>();

            coberturas.Add(new Cobertura
            {
                codigo = 1060,
                nombre = "ASISTENCIAS",
                capital = 0,
                primatotal = 0,
                deducible = "",
                riesgo = riesgo,
                requerida = false,
                seleccionado = true
            });

            coberturas.Add(new Cobertura
            {
                codigo = 3010,
                nombre = "COBL - AYUDA EN CAMINO",
                capital = 0,
                primatotal = 0,
                deducible = "",
                riesgo = riesgo,
                requerida = false,
                seleccionado = true
            });

            coberturas.Add(new Cobertura
            {
                codigo = 3016,
                nombre = "TRASLADO AL AEROPUERTO",
                capital = 0,
                primatotal = 0,
                deducible = "",
                riesgo = riesgo,
                requerida = false,
                seleccionado = true
            });

            return coberturas;
        }

        internal static List<Contracts.Comun.tercero> Terceros(Contracts.Variaciones.MapfreMas quoteInfo, Contracts.Poliza.DatoFijo datosFijos)
        {
            quoteInfo.terceros = new List<Contracts.Comun.tercero>();

            foreach (Contracts.Poliza.Tercero item in datosFijos.Terceros)
            {

                Contracts.Comun.tercero tercero = new Contracts.Comun.tercero()
                {
                    numeroderiesgo = item.num_riesgo,
                    tipodetercero = int.Parse(item.tip_benef),
                    tipodeterceroDesc = item.nom_benef,
                    DocumentNumber = item.tip_docum + "-" + item.cod_docum,
                    vencimientodecesion = item.fec_vcto_cesion,
                    importedecesion = item.imp_cesion,
                    numerodeprestamo = item.num_prestamo,
                    nombre = item.nom_completo,
                    numerodetelefono = item.tlf_numero,
                    correoelectronico = item.email,
                    fechadenacimiento = (!string.IsNullOrEmpty(item.fec_nacimiento) && item.fec_nacimiento.Length >= 10) ? Convert.ToDateTime(item.fec_nacimiento) : DateTime.MinValue
                };

                quoteInfo.terceros.Add(tercero);

            }


            return quoteInfo.terceros;
        }
    }
}
