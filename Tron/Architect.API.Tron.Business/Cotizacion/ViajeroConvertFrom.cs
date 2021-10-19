using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Architect.API.Tron.Business.Cotizacion
{
    internal class ViajeroConvertFrom
    {
        internal static Contracts.Cotizacion.Viajero Quote(Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {
            Contracts.Cotizacion.Viajero data = DatosFijos(tronQuoteInfo);
            data = DatosVariables(data, tronQuoteInfo);
            return data;
        }

        private static Contracts.Cotizacion.Viajero DatosFijos(Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {

            return new Contracts.Cotizacion.Viajero()
            {
                fec_efec_poliza = tronQuoteInfo.fec_efec_poliza,
                fec_vcto_poliza = tronQuoteInfo.fec_vcto_poliza,
                cod_mon = tronQuoteInfo.cod_mon,
                cod_fracc_pago = tronQuoteInfo.cod_fracc_pago
            };
        }

        private static Contracts.Cotizacion.Viajero DatosVariables(Contracts.Cotizacion.Viajero quoteInfo, Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {
            foreach (Contracts.Presupuesto.DatoVariable item  in tronQuoteInfo.DatosVariables)
            {
                switch (item.cod_campo)
                {
                    case "TIP_PLAN": //	TIP_PLAN
                        quoteInfo.TIP_PLAN = item.val_campo;
                        quoteInfo.TIP_PLAN_DESC = item.txt_campo;
                        break;
                    case "FEC_VIAJE": // FEC_VIAJE
                        quoteInfo.FEC_VIAJE = Convert.ToDateTime(item.val_campo);
                        break;
                    case "DES_DESTINO": // DES_DESTINO
                        quoteInfo.DES_DESTINO = item.val_campo;
                        quoteInfo.DES_DESTINO = item.txt_campo;
                        break;
                    case "TIP_VIAJE": // TIP_VIAJE
                        quoteInfo.TIP_VIAJE = item.val_campo;
                        quoteInfo.TIP_VIAJE_DESC = item.txt_campo;
                        break;
                    case "FEC_NACIMIENTO": // FEC_NACIMIENTO
                        quoteInfo.FEC_NACIMIENTO = Convert.ToDateTime(item.val_campo);
               
                        break;
                    case "COD_MODALIDAD": // COD_MODALIDAD
                        quoteInfo.COD_MODALIDAD = Convert.ToInt32(item.val_campo);
                        quoteInfo.COD_MODALIDAD_DES = item.txt_campo;
                        break;
                 
                }
            }
            return quoteInfo;
        }

        internal static Contracts.Cotizacion.Viajero Quote(Contracts.Cotizacion.Viajero quoteInfo, Architect.API.Tron.Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {

            if (tronQuoteInfo.Coberturas != null)
            {
                if (tronQuoteInfo.Coberturas?.Count == 1)
                {
                    quoteInfo.Error = tronQuoteInfo.Coberturas[0].txt_error;
                }
                foreach (Architect.API.Tron.Contracts.Presupuesto.Cobertura item in tronQuoteInfo.Coberturas)
                {
                    foreach (Architect.API.Tron.Contracts.Cotizacion.Viajerocoberturas itemQuote in quoteInfo.coberturas)
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
                quoteInfo.plandepago = new List<Contracts.Cotizacion.Viajeroplandepago>();
                foreach (Architect.API.Tron.Contracts.Presupuesto.Recibo item in tronQuoteInfo.Recibos)
                {
                    importeAnual = item.imp_recibo;
                    quoteInfo.plandepago.Add(new Contracts.Cotizacion.Viajeroplandepago()
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
                    foreach (Architect.API.Tron.Contracts.Tables.a1001403 item in Architect.API.Tron.DataAccess.PorRamo.FrecuenciaDePago(tronQuoteInfo.cod_cia, tronQuoteInfo.cod_ramo, tronQuoteInfo.cod_mon))
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
                    quoteInfo.Mensaje = quoteInfo.Mensaje.Substring(0, 1).ToUpper() + quoteInfo.Mensaje.Substring(1).ToLower();
                }
            }

            return quoteInfo;
        }
    }
}
