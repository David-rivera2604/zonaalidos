using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Tron.Business.Emision
{
    internal class MultirriesgoConvertFrom
    {
        internal static Contracts.Emision.Multirriesgo Quote(Contracts.Emision.Multirriesgo quoteInfo, Architect.API.Tron.Contracts.Poliza.DatoFijo tronQuoteInfo)
        {

            if (tronQuoteInfo.Calculado?.Coberturas != null)
            {
                if (tronQuoteInfo.Calculado.Coberturas.Count == 1)
                {
                    quoteInfo.Error = tronQuoteInfo.Calculado.Coberturas.First().TXT_ERROR;
                }
                foreach (Architect.API.Tron.Contracts.Poliza.CoberturaCalculada item in tronQuoteInfo.Calculado.Coberturas)
                {
                    foreach (Contracts.Comun.Cobertura itemQuote in quoteInfo.coberturas)
                    {
                        if (item.COD_COB == itemQuote.codigo)
                        {
                            itemQuote.seleccionado = true;

                            itemQuote.codigo = item.COD_COB;
                            itemQuote.nombre = item.NOM_COB;
                            itemQuote.capital = item.SUMA_ASEG;
                            itemQuote.primatotal = item.IMP_TOTAL;
                            itemQuote.deducible = item.NOM_FRANQUICIA;
                            itemQuote.error = item.TXT_ERROR;
                            if (quoteInfo.num_poliza.IsEmpty())
                            {
                                quoteInfo.num_poliza = item.NUM_POLIZA;
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
                        cuota = item.NUM_CUOTA,
                        fechadesde = item.FEC_EFEC_RECIBO,
                        fechahasta = item.FEC_VCTO_RECIBO,
                        primaneta = item.IMP_NETA,
                        iVA = item.IMP_IMPTOS,
                        recargoporfraccionamiento = item.IMP_RECARGO,
                        importetotal = item.IMP_RECIBO
                    });
                    if (setvalues)
                    {
                        quoteInfo.resumen = new Contracts.Cotizacion.resumen()
                        {
                            cuotas = tronQuoteInfo.Calculado.Recibos.Count,
                            primaneta = item.IMP_NETA,
                            iVA = item.IMP_IMPTOS,
                            recargoporfraccionamiento = item.IMP_INTERES,
                            importetotal = item.IMP_RECIBO
                        };
                        setvalues = false;
                    }
                }

                //if (quoteInfo.fraccionamientodepago == 1)
                //{
                //    double amount = 0;
                //    quoteInfo.plandepagoporfrecuencia = new List<Contracts.Cotizacion.plandepagoporfrecuencia>();
                //    foreach (Mapfre.Tron.Contracts.Tables.a1001403 item in Architect.API.Tron.DataAccess.PorRamo.FrecuenciaDePago(tronQuoteInfo.cod_cia, tronQuoteInfo.cod_ramo, tronQuoteInfo.cod_mon))
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
