using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Cotizacion
{
    public static class EstudiantilConvert
    {

        public static Contracts.Presupuesto.DatoFijo ToTron(Contracts.Cotizacion.Estudiantil quoteInfo, int branch, int agentCode, string userName)
        {

            Contracts.Presupuesto.DatoFijo datosFijos = Util.DatosFijos(quoteInfo, branch, agentCode, userName, 1);

            datosFijos.Riesgos = Util.DatosDelRiesgo(datosFijos, "Cotizador Seguro de Estudiantil",1,194);
            datosFijos.Terceros = new List<Contracts.Presupuesto.Tercero>();
            datosFijos.Terceros.Add(Util.Tercero(datosFijos,"CNA", "999999999", 0,0,0,DateTime.MinValue,0,string.Empty,string.Empty));
            datosFijos.Terceros.Add(Util.Tercero(datosFijos, "CNA", "999999999", 2,1, 0, DateTime.MinValue, 0, string.Empty,"10"));
            datosFijos.Coberturas = Util.Coberturas(quoteInfo, datosFijos, false, 1);
            datosFijos.DatosVariables = DatosVariable_ToTron(quoteInfo, datosFijos);

            return datosFijos;
        }

        private static List<Contracts.Presupuesto.DatoVariable> DatosVariable_ToTron(Contracts.Cotizacion.Estudiantil quoteInfo, Contracts.Presupuesto.DatoFijo datosFijos)
        {
            List<Contracts.Presupuesto.DatoVariable> datosVariables = new List<Contracts.Presupuesto.DatoVariable>();

            int edad = DateTime.Today.AddTicks(-quoteInfo.FEC_NACIMIENTO.Ticks).Year - 1;

            datosVariables.Add(Util.DatoVariable(datosFijos, 1, "FEC_NACIMIENTO", quoteInfo.FEC_NACIMIENTO.ToString("ddMMyyyy"),2,1, quoteInfo.FEC_NACIMIENTO.ToString("dd/MM/yyyy")));
            datosVariables.Add(Util.DatoVariable(datosFijos, 1, "VAL_EDAD_ACTUARIAL", edad.ToString(), 2, 2));
            datosVariables.Add(Util.DatoVariable(datosFijos, 1, "MCA_SEXO", quoteInfo.MCA_SEXO, 2, 3));
            datosVariables.Add(Util.DatoVariable(datosFijos, 1, "TXT_CRED_ESTUD", quoteInfo.TXT_CRED_ESTUD, 2, 4));
            datosVariables.Add(Util.DatoVariable(datosFijos, 1, "COD_PLAN_AP", quoteInfo.COD_PLAN_AP.ToString(), 2, 5,quoteInfo.NOM_PLAN_AP));
            datosVariables.Add(Util.DatoVariable(datosFijos, 1, "COD_MODALIDAD", "19401", 2,99, "ACCIDENTES PER. ESCOLARES"));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "MCA_COLECTIVO", "N", 1, 900, "INDIVIDUAL "));

            return datosVariables;
        }

       
        internal static Contracts.Cotizacion.Estudiantil FromTron_Full(Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {
            Contracts.Cotizacion.Estudiantil quoteInfo = (Contracts.Cotizacion.Estudiantil)Util.GenericInfo_FromTron(tronQuoteInfo, new Contracts.Cotizacion.Estudiantil());

            return FromTron_DatosVariables(tronQuoteInfo, quoteInfo);
        }

        private static Contracts.Cotizacion.Estudiantil FromTron_DatosVariables(Contracts.Presupuesto.DatoFijo tronQuoteInfo, Contracts.Cotizacion.Estudiantil quoteInfo)
        {
            var cultureInfo = new CultureInfo("de-DE");
            foreach (Contracts.Presupuesto.DatoVariable item in tronQuoteInfo.DatosVariables)
            {
                switch (item.cod_campo)
                {
                    
                    case "FEC_NACIMIENTO":
                       // quoteInfo.FEC_NACIMIENTO = Convert.ToDateTime(item.val_campo);
                        break;
                    case "COD_PLAN_AP":
                        quoteInfo.COD_PLAN_AP = Convert.ToInt32(item.val_campo);
                        break;
                    case "MCA_SEXO":
                        quoteInfo.MCA_SEXO = item.val_campo;
                        break;
                    case "TXT_CRED_ESTUD":
                        quoteInfo.TXT_CRED_ESTUD = item.val_campo;
                        break;
                }
            }
            return quoteInfo;
        }

    }
}
