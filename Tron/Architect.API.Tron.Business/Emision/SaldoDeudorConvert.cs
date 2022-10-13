using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Emision
{
    internal static class SaldoDeudorConvert
    {

        internal static Contracts.Presupuesto.DatoFijo ToTron(Contracts.Emision.SaldoDeudor quoteInfo, int branch, int agentCode, string userName)
        {
            Contracts.Presupuesto.DatoFijo datosFijos = Util.DatosFijos(quoteInfo, branch, agentCode, userName, Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.SaldoDeudor.cod_sector", 1));

            datosFijos.num_poliza = quoteInfo.presupuesto;

            Util.Terceros_ToTron(quoteInfo.terceros, datosFijos, true);
            datosFijos.DatosVariables = new List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable>();

            return datosFijos;
        }

        internal static Contracts.Emision.SaldoDeudor FromTron(Contracts.Emision.SaldoDeudor quoteInfo, Contracts.Poliza.DatoFijo tronQuoteInfo)
        {

            quoteInfo.coberturas = FromTron_CoberturasResult(quoteInfo.coberturas, tronQuoteInfo);
            quoteInfo.plandepago = FromTron_RecibosResult(tronQuoteInfo);

            if (tronQuoteInfo.Coberturas?.Count == 1)
            {
                quoteInfo.Error = tronQuoteInfo.Calculado.Coberturas.First().TXT_ERROR;
            }
            if (tronQuoteInfo.Error_Emision == string.Empty)
            {
                if (tronQuoteInfo.Calculado.Coberturas?.Count > 0)
                {
                    quoteInfo.num_poliza = tronQuoteInfo.Calculado.Coberturas.First().NUM_POLIZA;
                }
            }          
            if (tronQuoteInfo.DatosDelProceso != null && tronQuoteInfo.DatosDelProceso.txt_error.IsNotEmpty())
            {
                quoteInfo.Error = tronQuoteInfo.DatosDelProceso.txt_error;
            }

            quoteInfo.Mensaje = ErrorParser(quoteInfo.Error);
            return quoteInfo;
        }

        internal static List<Contracts.Comun.Cobertura> FromTron_CoberturasResult(List<Contracts.Comun.Cobertura> coberturas, Contracts.Poliza.DatoFijo tronQuoteInfo, bool multiRiesgo = false)
        {
            List<Contracts.Comun.Cobertura> result = new List<Contracts.Comun.Cobertura>();
            if (tronQuoteInfo.Calculado?.Coberturas != null)
            {
                if (multiRiesgo)
                {
                    foreach (Contracts.Poliza.CoberturaCalculada item in tronQuoteInfo.Calculado.Coberturas.OrderBy(p => p.COD_COB))
                    {
                        result.Add(new Contracts.Comun.Cobertura()
                        {
                            seleccionado = true,
                            codigo = item.COD_COB,
                            nombre = item.NOM_COB,
                            capital = item.SUMA_ASEG,
                            primatotal = item.IMP_TOTAL,
                            deducible = item.NOM_FRANQUICIA,
                            error = item.TXT_ERROR
                        });
                    }
                }
                else
                {
                    foreach (Contracts.Poliza.CoberturaCalculada item in tronQuoteInfo.Calculado.Coberturas.OrderBy(p => p.COD_COB))
                    {
                        foreach (Contracts.Comun.Cobertura itemQuote in coberturas)
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
                        result = coberturas;
                    }
                }
            }


            return result;
        }

        internal static List<Contracts.Comun.PlanDePago> FromTron_RecibosResult(Contracts.Poliza.DatoFijo tronQuoteInfo)
        {
            List<Contracts.Comun.PlanDePago> plandepago = new List<Contracts.Comun.PlanDePago>();
            if (tronQuoteInfo.Calculado?.Recibos != null)
            {
                foreach (Contracts.Poliza.ReciboCalculado item in tronQuoteInfo.Calculado.Recibos)
                {
                    plandepago.Add(new Contracts.Comun.PlanDePago()
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
                }
            }
            return plandepago;
        }

        internal static string ErrorParser(string error)
        {
            string mensaje = error;
            if (mensaje != null)
            {
                if (mensaje.StartsWith("ORA-", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (mensaje.IndexOf(':') > 0)
                    {
                        mensaje = mensaje.Substring(mensaje.IndexOf(':') + 1).Trim();
                    }
                    mensaje = mensaje.Substring(0, 1).ToUpper() + mensaje.Substring(1).ToLower();
                }
            }
            return mensaje;
        }

    }

}
