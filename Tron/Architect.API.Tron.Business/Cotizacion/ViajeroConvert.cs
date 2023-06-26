using Architect.DocuSign.Integrations.Providers.Evicertia.Contracts;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Cotizacion
{
    public static class ViajeroConvert
    {

        public static Contracts.Presupuesto.DatoFijo ToTron(Contracts.Cotizacion.Viajero quoteInfo, int branch, int agentCode, string userName, int companyId)
        {

            Contracts.Presupuesto.DatoFijo datosFijos = Util.DatosFijos(quoteInfo, branch, agentCode, userName, 4);

            datosFijos.Riesgos = Util.DatosDelRiesgo(datosFijos, "Cotizador Seguro de Viaje", quoteInfo.cantidad_riesgos);
            datosFijos.Terceros = Util.Terceros(datosFijos);
            datosFijos.Coberturas = Util.Coberturas(quoteInfo, datosFijos, false, quoteInfo.cantidad_riesgos);

            datosFijos.DatosVariables = DatosVariable_ToTron(quoteInfo, datosFijos, companyId);

            return datosFijos;
        }

        private static List<Contracts.Presupuesto.DatoVariable> DatosVariable_ToTron(Contracts.Cotizacion.Viajero quoteInfo, Contracts.Presupuesto.DatoFijo datosFijos, int companyId)
        {
            List<Contracts.Presupuesto.DatoVariable> datosVariables = new List<Contracts.Presupuesto.DatoVariable>();

            //Número de Días
            TimeSpan difFechas = quoteInfo.fec_vcto_poliza - quoteInfo.fec_efec_poliza;
            int dias = difFechas.Days + 1;
            if (quoteInfo.PAIS_ORIGEN_DESC == String.Empty)
            {
                quoteInfo.PAIS_ORIGEN_DESC = Core.Business.Common.LkpDescription(companyId, "TRON_A1000101", quoteInfo.COD_PAIS_ORIGEN);
            }
            if (quoteInfo.DES_DESTINO_DESC == String.Empty)
            {
                quoteInfo.DES_DESTINO_DESC = Core.Business.Common.LkpDescription(companyId, "TRON_A1000101", quoteInfo.DES_DESTINO);
            }
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "TIP_PLAN", quoteInfo.TIP_PLAN, 1, 1));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "FEC_VIAJE", quoteInfo.FEC_VIAJE.ToString("ddMMyyyy"), 1, 2));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "NUM_DIA", Convert.ToString(dias), 1, 3));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "DES_DESTINO", quoteInfo.DES_DESTINO, 1, 4, quoteInfo.DES_DESTINO_DESC));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "CANAL_VENTA", "TWB", 1, 5));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "TIP_VIAJE", quoteInfo.TIP_VIAJE, 1, 6));

            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "ORI_ORIGEN", quoteInfo.COD_PAIS_ORIGEN, 1, 9, quoteInfo.PAIS_ORIGEN_DESC));


            for (int i = 1; i <= quoteInfo.cantidad_riesgos; i++)
            {
                switch (i)
                {
                    case 1:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO, quoteInfo.COD_MODALIDAD));
                        break;
                    case 2:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO2, quoteInfo.COD_MODALIDAD));
                        break;
                    case 3:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO3, quoteInfo.COD_MODALIDAD));
                        break;
                    case 4:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO4, quoteInfo.COD_MODALIDAD));
                        break;
                    case 5:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO5, quoteInfo.COD_MODALIDAD));
                        break;
                    case 6:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO6, quoteInfo.COD_MODALIDAD));
                        break;
                    case 7:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO7, quoteInfo.COD_MODALIDAD));
                        break;
                    case 8:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO8, quoteInfo.COD_MODALIDAD));
                        break;
                    case 9:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO9, quoteInfo.COD_MODALIDAD));
                        break;
                    case 10:
                        datosVariables.AddRange(DatosVariable_ToTron_por_riesgo(datosFijos, i, quoteInfo.FEC_NACIMIENTO10, quoteInfo.COD_MODALIDAD));
                        break;
                }
            }

            return datosVariables;
        }

        private static List<Contracts.Presupuesto.DatoVariable> DatosVariable_ToTron_por_riesgo(Contracts.Presupuesto.DatoFijo datosFijos, int num_riesgo, DateTime nacimiento, int cod_modalidad)
        {
            List<Contracts.Presupuesto.DatoVariable> datosVariables = new List<Contracts.Presupuesto.DatoVariable>();
            int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "FEC_NACIMIENTO", nacimiento.ToString("ddMMyyyy"), 2, 2));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "VAL_EDAD", edad.ToString(), 2, 3));
            datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, "COD_MODALIDAD", cod_modalidad.ToString(), 2, 99));
            return datosVariables;
        }

        internal static Contracts.Cotizacion.Viajero FromTron_Full(Contracts.Presupuesto.DatoFijo tronQuoteInfo)
        {
            Contracts.Cotizacion.Viajero quoteInfo = (Contracts.Cotizacion.Viajero)Util.GenericInfo_FromTron(tronQuoteInfo, new Contracts.Cotizacion.Viajero());

            return FromTron_DatosVariables(tronQuoteInfo, quoteInfo);
        }

        private static Contracts.Cotizacion.Viajero FromTron_DatosVariables(Contracts.Presupuesto.DatoFijo tronQuoteInfo, Contracts.Cotizacion.Viajero quoteInfo)
        {
            foreach (Contracts.Presupuesto.DatoVariable item in tronQuoteInfo.DatosVariables)
            {
                switch (item.cod_campo)
                {
                    case "TIP_PLAN":
                        quoteInfo.TIP_PLAN = item.val_campo;
                        break;
                    case "FEC_VIAJE":
                        quoteInfo.FEC_VIAJE = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                        break;
                    case "DES_DESTINO":
                        quoteInfo.DES_DESTINO_DESC = item.val_campo;
                        break;
                    case "TIP_VIAJE":
                        quoteInfo.TIP_VIAJE = item.val_campo;
                        break;

                    case "FEC_NACIMIENTO":
                        switch (item.num_riesgo)
                        {
                            case 1:
                                quoteInfo.FEC_NACIMIENTO = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 1;
                                break;
                            case 2:
                                quoteInfo.FEC_NACIMIENTO2 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 2;
                                break;
                            case 3:
                                quoteInfo.FEC_NACIMIENTO3 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 3;
                                break;
                            case 4:
                                quoteInfo.FEC_NACIMIENTO4 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 4;
                                break;
                            case 5:
                                quoteInfo.FEC_NACIMIENTO5 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 5;
                                break;
                            case 6:
                                quoteInfo.FEC_NACIMIENTO6 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 6;
                                break;
                            case 7:
                                quoteInfo.FEC_NACIMIENTO7 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 7;
                                break;
                            case 8:
                                quoteInfo.FEC_NACIMIENTO8 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 8;
                                break;
                            case 9:
                                quoteInfo.FEC_NACIMIENTO9 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 9;
                                break;
                            case 10:
                                quoteInfo.FEC_NACIMIENTO10 = DateTime.ParseExact(item.val_campo, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                                quoteInfo.cantidad_riesgos = 10;
                                break;
                        }

                        break;


                    case "NUM_DIA":
                    case "CANAL_VENTA":
                    case "VAL_EDAD":
                    case "COD_MODALIDAD":
                        break;
                }
            }
            return quoteInfo;
        }

    }
}
