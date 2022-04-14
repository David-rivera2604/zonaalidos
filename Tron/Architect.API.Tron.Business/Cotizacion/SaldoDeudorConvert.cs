using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Architect.API.Tron.Business.Cotizacion
{
    internal static class SaldoDeudorConvert
    {

        internal static Contracts.Presupuesto.DatoFijo ToTron(Contracts.Cotizacion.SaldoDeudor quoteInfo, int branch, int agentCode, string userName)
        {

            Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos = Util.DatosFijos(quoteInfo, branch, agentCode, userName, Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.SaldoDeudor.cod_sector", 1));

            datosFijos.Riesgos = Util.DatosDelRiesgo(datosFijos, "Cotizador Saldo Deudor");
            datosFijos.Terceros = Util.Terceros(datosFijos);
            datosFijos.Coberturas = Util.Coberturas(quoteInfo, datosFijos);
            datosFijos.Coberturas.Where(s => s.cod_cob == 4001).FirstOrDefault().suma_aseg = quoteInfo.IMP_MONTO_ORI;
            datosFijos.DatosVariables = DatosVariable(quoteInfo, datosFijos);
            datosFijos.Ocurrencias = Ocurrencias(quoteInfo, datosFijos);

            return datosFijos;
        }

        private static List<Contracts.Presupuesto.DatoVariable> DatosVariable(Contracts.Cotizacion.SaldoDeudor quoteInfo, Contracts.Presupuesto.DatoFijo datosFijos)
        {
            List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable> datosVariables = new List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable>();
            int num_riesgo = datosFijos.Riesgos.FirstOrDefault().num_riesgo;

            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "FEC_VALIDEZ_TARIFA", DateTime.Today.ToString("ddMMyyyy"), 1, 1, "Date"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_MODALIDAD_RIESGO", quoteInfo.COD_MODALIDAD_RIESGO.ToString(), 2, 1, "PEND"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_NEGOCIO_MIGRADO", quoteInfo.MCA_NEGOCIO_MIGRADO, 2, 2, "PEND"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_CIA_ORI", quoteInfo.COD_CIA_ORI.ToString(), 2, 3));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "FEC_EMISION_ORI", quoteInfo.FEC_EMISION_ORI.ToString("ddMMyyyy"), 2, 4));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_MONTO_ORI", quoteInfo.IMP_MONTO_ORI.ToString(), 2, 5));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_SLD_ACTUAL", quoteInfo.IMP_SLD_ACTUAL.ToString(), 2, 6));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "NUM_PRESTAMO", quoteInfo.NUM_PRESTAMO.ToString(), 2, 7));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "FEC_NACIMIENTO", quoteInfo.FEC_NACIMIENTO.ToString(("ddMMyyyy")), 2, 10));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_SEXO", quoteInfo.MCA_SEXO, 2, 11, "PEND"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "NUM_EDAD_ASEGURADO", quoteInfo.FEC_NACIMIENTO.Age().ToString(), 2, 12));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "TIP_NEGOCIO", quoteInfo.TIP_NEGOCIO, 2, 13, "PEND"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_PRIMA_INFORMADA", quoteInfo.IMP_PRIMA_INFORMADA.ToString(), 2, 14));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_GASTOS_EMISION", quoteInfo.IMP_GASTOS_EMISION.ToString(), 2, 15));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "PCT_DTO_COMERCIAL", quoteInfo.PCT_DTO_COMERCIAL.ToString(), 2, 16));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "PCT_DCTO_TECNICO", quoteInfo.PCT_DCTO_TECNICO.ToString(), 2, 17));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "NUM_ENF_EXC", quoteInfo.enfermedadesexcluidas.Count().ToString(), 2, 18));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "FEC_PRIM_FINAN", quoteInfo.FEC_PRIM_FINAN.ToString("ddMMyyyy"), 2, 19));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_MODALIDAD", quoteInfo.COD_MODALIDAD_RIESGO.ToString(), 2, 99, "PEND"));

            return datosVariables;
        }

        private static List<Contracts.Presupuesto.Ocurrencia> Ocurrencias(Contracts.Cotizacion.SaldoDeudor quoteInfo, Contracts.Presupuesto.DatoFijo datosFijos)
        {
            List<Architect.API.Tron.Contracts.Presupuesto.Ocurrencia> ocurrencias = new List<Architect.API.Tron.Contracts.Presupuesto.Ocurrencia>();
            int index = 1;
            foreach (Architect.API.Tron.Contracts.Cotizacion.enfermedadesexcluidas enfermedadexcluida in quoteInfo.enfermedadesexcluidas)
            {
                ocurrencias.Add(Util.Ocurrencia(datosFijos, index, "COD_ENF_EXC", enfermedadexcluida.COD_ENF_EXC, 1, "PEND"));
                ocurrencias.Add(Util.Ocurrencia(datosFijos, index, "TXT_OBS_ENF_EXC", enfermedadexcluida.TXT_OBS_ENF_EXC, 2));
                ocurrencias.Add(Util.Ocurrencia(datosFijos, index, "COD_TIP_EXC", enfermedadexcluida.COD_TIP_EXC, 3, "PEND"));
                ocurrencias.Add(Util.Ocurrencia(datosFijos, index, "FEC_INI_EXC", enfermedadexcluida.FEC_INI_EXC.ToString("ddMMyyyy"), 4));
                ocurrencias.Add(Util.Ocurrencia(datosFijos, index, "FEC_FIN_EXC", enfermedadexcluida.FEC_FIN_EXC.ToString("ddMMyyyy"), 5));
                index++;
            }
            return ocurrencias;
        }


        internal static Contracts.Cotizacion.SaldoDeudor FromTron(Contracts.Cotizacion.SaldoDeudor quoteInfo, Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {

            if (tronQuoteInfo.Coberturas != null)
            {
                if (tronQuoteInfo.Coberturas?.Count == 1)
                {
                    quoteInfo.Error = tronQuoteInfo.Coberturas[0].txt_error;
                }
                foreach (Contracts.Presupuesto.Cobertura item in tronQuoteInfo.Coberturas)
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
                            itemQuote.decucible = item.nom_franquicia;
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
                            itemQuote.decucible = string.Empty;
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

                if (quoteInfo.cod_fracc_pago == 11)
                {
                    double amount;
                    quoteInfo.plandepagoporfrecuencia = new List<Contracts.Cotizacion.plandepagoporfrecuencia>();
                    foreach (Contracts.Ramo.A1001403 item in DataAccess.PorRamo.FrecuenciaDePago(tronQuoteInfo.cod_cia, tronQuoteInfo.cod_ramo, tronQuoteInfo.cod_mon))
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
