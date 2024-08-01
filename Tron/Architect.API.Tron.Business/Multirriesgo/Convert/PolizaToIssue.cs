using Architect.Utilities.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Tron.Business.Multirriesgo.Convert
{
    internal class PolizaToIssue
    {
        internal static Contracts.Emision.Multirriesgo Quote(Contracts.Emision.Multirriesgo quoteInfo, Contracts.Poliza.DatoFijo tronQuoteInfo)
        {

            if (tronQuoteInfo.Calculado?.Coberturas != null)
            {
                if (tronQuoteInfo.Calculado.Coberturas.Count == 1)
                {
                    quoteInfo.Error = tronQuoteInfo.Calculado.Coberturas.First().TXT_ERROR;
                }
                foreach (Contracts.Poliza.CoberturaCalculada item in tronQuoteInfo.Calculado.Coberturas)
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
                        recibo = item.NUM_RECIBO,
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
            }

            // RANGO DE MESES DEBE ESTAR ENTRE 1 Y 12 MESES &lt;COB_PDR_MESES&gt;</txt_error>
            if (tronQuoteInfo.DatosDelProceso != null && tronQuoteInfo.DatosDelProceso.txt_error.IsNotEmpty())
            {
                quoteInfo.Error = tronQuoteInfo.DatosDelProceso.txt_error;
            }
            if (quoteInfo.Error != null)
            {

                quoteInfo.Error = Backoffice.Emision.FormatoErrores.FormatearError(quoteInfo.Error);
                quoteInfo.Mensaje = quoteInfo.Error;
            }

            return quoteInfo;
        }

    }
}
