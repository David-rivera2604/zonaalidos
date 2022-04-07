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
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_NEGOCIO_MIGRADO", quoteInfo.MCA_NEGOCIO_MIGRADO == 1 ? "S" : "N", 2, 2, "PEND"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_CIA_ORI", quoteInfo.COD_CIA_ORI.ToString(), 2, 3));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "FEC_EMISION_ORI", quoteInfo.FEC_EMISION_ORI.ToString("ddMMyyyy"), 2, 4));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_MONTO_ORI", quoteInfo.IMP_MONTO_ORI.ToString(), 2, 5));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "IMP_SLD_ACTUAL", quoteInfo.IMP_SLD_ACTUAL.ToString(), 2, 6));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "NUM_PRESTAMO", quoteInfo.NUM_PRESTAMO.ToString(), 2, 7));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "FEC_NACIMIENTO", quoteInfo.FEC_NACIMIENTO.ToString(("ddMMyyyy")), 2, 10));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "MCA_SEXO", quoteInfo.MCA_SEXO.ToString(), 2, 11, "PEND"));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "NUM_EDAD_ASEGURADO", quoteInfo.FEC_NACIMIENTO.Age().ToString(), 2, 12));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "TIP_NEGOCIO", quoteInfo.TIP_NEGOCIO.ToString(), 2, 13, "PEND"));
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
                ocurrencias.Add(Util.Ocurrencia(datosFijos, index, "COD_ENF_EXC", enfermedadexcluida.COD_ENF_EXC.ToString(), 1, "PEND"));
                ocurrencias.Add(Util.Ocurrencia(datosFijos, index, "TXT_OBS_ENF_EXC", enfermedadexcluida.TXT_OBS_ENF_EXC, 2));
                ocurrencias.Add(Util.Ocurrencia(datosFijos, index, "COD_TIP_EXC", enfermedadexcluida.COD_TIP_EXC.ToString(), 3, "PEND"));
                ocurrencias.Add(Util.Ocurrencia(datosFijos, index, "FEC_INI_EXC", enfermedadexcluida.FEC_INI_EXC.ToString("ddMMyyyy"), 4));
                ocurrencias.Add(Util.Ocurrencia(datosFijos, index, "FEC_FIN_EXC", enfermedadexcluida.FEC_FIN_EXC.ToString("ddMMyyyy"), 5));
                index++;
            }
            return ocurrencias;
        }

    }
}
