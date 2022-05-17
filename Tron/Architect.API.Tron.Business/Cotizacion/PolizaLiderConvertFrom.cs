using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Tron.Business.Cotizacion
{
    internal static class PolizaLiderConvertFrom
    {
        internal static Contracts.Cotizacion.PolizaLider Quote(Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {
            Contracts.Cotizacion.PolizaLider result = DatosFijos(tronQuoteInfo);
            result = DatosVariable(result, tronQuoteInfo);
            return result;
        }

        private static Contracts.Cotizacion.PolizaLider DatosFijos(Architect.API.Tron.Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {
            return new Contracts.Cotizacion.PolizaLider()
            {
                cod_mon = tronQuoteInfo.cod_mon,
                cod_fracc_pago = tronQuoteInfo.cod_fracc_pago,
                fec_efec_poliza = tronQuoteInfo.fec_efec_poliza,
                fec_vcto_poliza = tronQuoteInfo.fec_vcto_poliza,
                
                //Equi_EspeSA = quoteInfo.Equi_EspeSA,

                //mca_HogarTotal = quoteInfo.mca_HogarTotal == 1 ? "S" : "N",
            };

        }

        private static Contracts.Cotizacion.PolizaLider DatosVariable(Contracts.Cotizacion.PolizaLider quoteInfo, Architect.API.Tron.Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {
            foreach (Contracts.Presupuesto.DatoVariable item in tronQuoteInfo.DatosVariables)
            {
                switch (item.cod_campo)
                {
                    case "COD_PLAN_AUTO": // PLAN
                        quoteInfo.COD_PLAN_AUTO = Convert.ToInt32(item.val_campo);
                        break;
                    case "COD_MARCA": // MARCA DEL VEHICULO
                        quoteInfo.COD_MARCA = Convert.ToInt32(item.val_campo);
                        break;
                    case "COD_TIP_VEHI": // CLASE DE VEHICULO
                        quoteInfo.COD_TIP_VEHI = Convert.ToInt32(item.val_campo);
                        break;
                    case "COD_USO_VEHI": // USO DEL VEHICULO
                        quoteInfo.COD_USO_VEHI = Convert.ToInt32(item.val_campo);
                        break;
                    case "ANIO_SUB_MODELO": // AÑO VEHÍCULO
                        quoteInfo.ANIO_SUB_MODELO = Convert.ToInt32(item.val_campo);
                        break;
                    case "MCA_VR": // ASEGURAR A VALOR REAL?
                        quoteInfo.MCA_VR = item.val_campo == "VR" ? "1" : "2";
                        break;
                    case "MCA_DESC_CLIENTE_NUEVO": // CLIENTE NUEVO?
                        quoteInfo.MCA_DESC_CLIENTE_NUEVO = item.val_campo == "S" ? 1 : 2;
                        break;
                    case "MCA_AUTO_GPS": // UBICACIÓN POR GPS
                        quoteInfo.MCA_DESC_CLIENTE_NUEVO = item.val_campo == "SN" ? 1 : 2;
                        break;
                    case "IMP_AUTO_RC": // SUMA ASEG. RESP.CIVIL
                        quoteInfo.Resp_civilSA = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_AUTO_GMO": // SUMA ASEG. GASTOS MED. OCUP.
                        quoteInfo.Gast_medicSA = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_AUTO_ACO": // SUMA ASEG. GASTOS MED. COND.
                        quoteInfo.Acc_ConducSA = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_VR": // IMPORTE A VALOR REAL
                        quoteInfo.Valor_VehiSA = Convert.ToInt32(item.val_campo);
                        break;
                    case "IMP_AUTO_CRI": // SUMA ASEG. ROTURA DE CRISTALES
                        quoteInfo.IMP_AUTO_CRI = Convert.ToInt32(item.val_campo);
                        break;
                    case "MCA_CERO_KM": // CERO KMS?                   
                        quoteInfo.MCA_CERO_KM = item.val_campo == "S" ? 1 : 2;
                        break;
                    case "PCT_DCTO_AUTO_PAR": // % DCTO. VOLUMEN - PARTICULAR
                        quoteInfo.PCT_DCTO_AUTO_PAR = Convert.ToInt32(item.val_campo);
                        break;
                    case "COD_MODELO": // MODELO DEL VEHICULO
                        quoteInfo.COD_MODELO = Convert.ToInt32(item.val_campo);
                        break;

                    case "NUM_SOLICITUD": // SOLICITUD / CRUCE COBRANZAS
                    case "TXT_DET_COND": // CONDICIONES DE VEHICULO
                    case "TXT_DET_COND1": // DET. CONDICIONES DE VEHICULO
                    case "PCT_DCTO_COL": // % DCTO. COLABORADOR                   
                    case "PCT_DCTO_AUTO_COR": // % DCTO. CORPORATIVO
                    case "COD_COLOR": // COLOR DEL VEHICULO                    
                    case "NUM_MATRICULA": // NUMERO DE MATRICULA
                    case "PCT_DCTO_AUTO_COM": // % DCTO. VOLUMEN - COMERCIAL
                    case "NUM_MOTOR": // NUMERO DEL MOTOR
                    case "NUM_CREDITO": // NÚMERO DE OPERACION
                    case "VAL_CAPACIDAD": // CAPACIDAD DEL VEHICULO
                    case "DES_TIP_CILINDRAJE": // CILINDRAJE
                    case "VAL_PESO": // PESO (Kgms)
                    case "COD_CHASSIS": // CHASSIS                    
                    case "MCA_AUTO_GPS_CMS": // GPS CON CONV. DEL MINISTERIO                                   
                    case "MCA_PRA": // ASEGURAR A PRIMER RIESGO ABS?
                    case "IMP_PRA": // IMPORTE A PRIMER RIESGO ABS.
                    case "MCA_AUTO_RC": // SUSCRIBE COBA - RESP.CIVIL?                    
                    case "MCA_AUTO_GMO": // SUSCRIBE COBB - GAST.MED.OCUP?                    
                    case "MCA_AUTO_ACO": // SUSCRIBE COBC -ACC..COND?                    
                    case "MCA_AUTO_CYV": // SUSCRIBE COBE - COLIS.Y VUELC?
                    case "MCA_AUTO_RAD": // SUSCRIBE COBF - RIESG,ADICION?
                    case "MCA_AUTO_ROB": // SUSCRIBE COBG - ROBO Y HURTO?
                    case "MCA_AUTO_MAP": // SUSCRIBE COBERTURA MAPFRE?
                    case "MCA_AUTO_CRI": // SUSCRIBE ROTURA DE CRISTALES?                    
                    case "MCA_AUTO_CAM": // SUSCRIBE AYUDA EN CAMINO?                    
                    case "MCA_AUTO_TAXI": // SUSCRIBE TRASLADO AL AEROPUERT
                    case "MCA_AUTO_SUST": // SUSCRIBE AUTO SUSTITUTO
                    case "PCT_AJUSTE_GEN": // PORCENTAJE AJUSTE COMERCIAL
                    case "COD_MODALIDAD": // MODALIDAD
                    case "MCA_COLECTIVO": // ¿COLECTIVO?
                    case "MCA_MANTPRIM": // ¿COLECTIVO MANTIENE PRIMA?

                        break;
                }
            }
            return quoteInfo;
        }


        internal static Contracts.Cotizacion.PolizaLider Quote(Contracts.Cotizacion.PolizaLider quoteInfo, Architect.API.Tron.Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {
            quoteInfo.Errors = new List<Core.Contracts.General.Error>();
            if (tronQuoteInfo.Coberturas != null)
            {
                if (tronQuoteInfo.Coberturas?.Count == 1)
                {
                    quoteInfo.Error = tronQuoteInfo.Coberturas[0].txt_error;
                }

                foreach (Architect.API.Tron.Contracts.Presupuesto.Cobertura item in tronQuoteInfo.Coberturas)
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
                            itemQuote.deducible = item.nom_franquicia;
                            itemQuote.error = item.txt_error;
                            if (quoteInfo.presupuesto.IsEmpty())
                            {
                                quoteInfo.presupuesto = item.num_poliza;
                            }
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

            if (tronQuoteInfo.Recibos != null)
            {
                double importeAnual = 0;
                bool setvalues = true;
                quoteInfo.plandepago = new List<Contracts.Comun.PlanDePago>();
                foreach (Architect.API.Tron.Contracts.Presupuesto.Recibo item in tronQuoteInfo.Recibos)
                {
                    importeAnual = item.imp_recibo;
                    quoteInfo.plandepago.Add(new Contracts.Comun.PlanDePago()
                    {
                        cuota = item.num_cuota,
                        fechadesde = item.fec_efec_recibo,
                        fechahasta = item.fec_vcto_recibo,
                        primaneta = item.imp_neta + item.imp_recargo,
                        iVA = item.imp_imptos,
                        recargoporfraccionamiento = item.imp_interes,
                        importetotal = item.imp_recibo
                    });
                    if (setvalues)
                    {
                        quoteInfo.resumen = new Contracts.Cotizacion.resumen()
                        {
                            cuotas = tronQuoteInfo.Recibos.Count,
                            primaneta = item.imp_neta + item.imp_recargo,
                            iVA = item.imp_imptos,
                            recargoporfraccionamiento = item.imp_interes,
                            importetotal = item.imp_recibo
                        };
                        setvalues = false;
                    }
                }

                if (quoteInfo.cod_fracc_pago == 1)
                {
                    double amount = 0;
                    quoteInfo.plandepagoporfrecuencia = new List<Contracts.Cotizacion.plandepagoporfrecuencia>();
                    foreach (Architect.API.Tron.Contracts.Ramo.A1001403 item in Architect.API.Tron.DataAccess.PorRamo.FrecuenciaDePago(tronQuoteInfo.cod_cia, tronQuoteInfo.cod_ramo, tronQuoteInfo.cod_mon))
                    {
                        amount = (importeAnual / item.cod_fracc_pago) + ((importeAnual / item.cod_fracc_pago) * (item.pct_fracc_pago / 100));
                        quoteInfo.plandepagoporfrecuencia.Add(new Contracts.Cotizacion.plandepagoporfrecuencia()
                        {
                            codigo = item.cod_fracc_pago,
                            frecuencia = item.nom_fracc_pago,
                            recardoporfraccionamiento = item.pct_fracc_pago,
                            importetotal = amount
                        });
                    }
                }

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
                    //if (quoteInfo.Mensaje.IndexOf(']') > 0)
                    //{
                    //    quoteInfo.Mensaje = quoteInfo.Mensaje.Substring(quoteInfo.Mensaje.IndexOf(']') + 1).Trim();
                    //}
                    //if (quoteInfo.Mensaje.IndexOf('<') > 0)
                    //{
                    //    quoteInfo.Mensaje = quoteInfo.Mensaje.Substring(0, quoteInfo.Mensaje.IndexOf('<')).Trim();
                    //}
                    quoteInfo.Mensaje = quoteInfo.Mensaje.Capitalize();
                }
                if (quoteInfo.Mensaje.ToLower().Contains("cobertura"))
                {
                    quoteInfo.Errors.Add(new Core.Contracts.General.Error() { Key = "Table", Group = "coberturasTbl", Message = quoteInfo.Mensaje });
                    quoteInfo.Mensaje = string.Empty;
                }
            }

            return quoteInfo;
        }
    }
}
