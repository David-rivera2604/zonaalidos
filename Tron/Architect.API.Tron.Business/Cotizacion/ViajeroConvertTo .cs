using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Architect.API.Tron.Business.Cotizacion
{
    internal static class ViajeroConvertTo
    {

        internal static Architect.API.Tron.Contracts.Presupuesto.DatoFijo Tron(Contracts.Cotizacion.Viajero quoteInfo, int branch, int agentCode, string userName)
        {

            Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos = DatosFijos(quoteInfo, branch, agentCode, userName);

            datosFijos.Riesgos = Util.DatosDelRiesgo(datosFijos, "Cotizador Seguro de Viaje", quoteInfo.cantidad_riesgos);
            datosFijos.Terceros = Util.Terceros(datosFijos);
            datosFijos.Coberturas = Coberturas(quoteInfo, datosFijos);
            datosFijos.DatosVariables = DatosVariable(quoteInfo, datosFijos);

            return datosFijos;
        }

        internal static Architect.API.Tron.Contracts.Presupuesto.DatoFijo DatosFijos(Contracts.Cotizacion.Viajero quoteInfo, int branch, int agentCode, string userName)
        {

            //Datos fijos del presupuesto
            Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos = new Architect.API.Tron.Contracts.Presupuesto.DatoFijo()
            {
                cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]),
                num_poliza = string.Empty,
                num_spto = 0,
                num_apli = 0,
                num_spto_apli = 0,
                cod_sector = 4,//Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.HogarTotal.cod_sector"]),
                cod_ramo = branch,
                fec_validez = DateTime.MinValue,
                fec_emision = DateTime.MinValue,
                fec_emision_spto = DateTime.MinValue,
                fec_efec_poliza = quoteInfo.fec_efec_poliza,
                fec_vcto_poliza = quoteInfo.fec_vcto_poliza,
                fec_efec_spto = DateTime.MinValue,
                fec_vcto_spto = DateTime.MinValue,
                tip_duracion = 0,
                num_riesgos = 0,
                cod_mon = quoteInfo.cod_mon,
                cod_fracc_pago = quoteInfo.cod_fracc_pago,
                cant_renovaciones = 0,
                num_renovaciones = 0,
                tip_coaseguro = 0,
                num_contrato = int.MinValue,
                num_subcontrato = int.MinValue,
                num_poliza_grupo = string.Empty,
                num_secu_grupo = 0,
                cod_spto = 0,
                sub_cod_spto = 0,
                txt_motivo_spto = string.Empty,
                cod_cuadro_com = 0,
                cod_agt = 0,
                pct_agt = 0,
                cod_org = 0,
                cod_asesor = 0,
                cod_nivel1 = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_nivel1"]),
                cod_nivel2 = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_nivel2"]),
                cod_nivel3 = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_nivel3"]),
                cod_compensacion = 0,
                pct_regulariza = 0,
                cod_indice = 0,
                anios_max_duracion = 0,
                meses_max_duracion = 0,
                dias_max_duracion = 0,
                cod_agt2 = 0,
                pct_agt2 = 0,
                cod_agt3 = 0,
                pct_agt3 = 0,
                cod_agt4 = 0,
                pct_agt4 = 0,
                duracion_pago_prima = 0,
                cod_ejecutivo = 0,
                fec_autorizacion = DateTime.MinValue,
                num_spto_anulado = 0,
                fec_spto_anulado = DateTime.MinValue,
                cod_nivel3_captura = 0,
                fec_actu = DateTime.MinValue,
                cod_dst_agt = 0,
                num_spto_publico = 0,
                fec_tratamiento = DateTime.MinValue,
                num_orden = 0,
                hora_desde = Convert.ToString(DateTime.Today.Hour)
            };

           datosFijos.cod_cuadro_com = 100;
           datosFijos.cod_agt = agentCode;
            
           datosFijos.txt_motivo_spto = "Cotización realizada desde la zona de aliados, por: " + userName;

            return datosFijos;
        }

        internal static List<Architect.API.Tron.Contracts.Presupuesto.Cobertura> Coberturas(Contracts.Cotizacion.Viajero quoteInfo, Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos)
        {

            List<Architect.API.Tron.Contracts.Presupuesto.Cobertura> coberturas = new List<Architect.API.Tron.Contracts.Presupuesto.Cobertura>();

            foreach (Architect.API.Tron.Contracts.Comun.Cobertura item in from c in quoteInfo.coberturas where c.seleccionado select c)
            {

                for (int i = 1; i <= quoteInfo.cantidad_riesgos; i++)
                {
                    coberturas.Add(Util.Cobertura(datosFijos, item.codigo, i));
                }
  
            }

            return coberturas;
        }

        private static List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable> DatosVariable(Contracts.Cotizacion.Viajero quoteInfo, Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos)
        {
            List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable> datosVariables = new List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable>();

            //Numero de Dias
            TimeSpan difFechas = quoteInfo.fec_vcto_poliza - quoteInfo.fec_efec_poliza;
            int dias = difFechas.Days + 1;

            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "TIP_PLAN", quoteInfo.TIP_PLAN,1,1));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "FEC_VIAJE", quoteInfo.FEC_VIAJE.ToString("ddMMyyyy"), 1, 2));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "NUM_DIA", Convert.ToString(dias), 1, 3));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "DES_DESTINO", quoteInfo.DES_DESTINO_DESC, 1, 4));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "CANAL_VENTA", "TWB", 1, 5));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "TIP_VIAJE", quoteInfo.TIP_VIAJE, 1, 6));

            DateTime nacimiento;
            int edad;

            for (int i = 1; i <= quoteInfo.cantidad_riesgos; i++)
            {
                switch(i)
                {
                    case 1:
                        //Edad 
                        nacimiento = quoteInfo.FEC_NACIMIENTO; //Fecha de nacimiento
                        edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "FEC_NACIMIENTO", quoteInfo.FEC_NACIMIENTO.ToString("ddMMyyyy"), 2, 2));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "VAL_EDAD", Convert.ToString(edad), 2, 3));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "COD_MODALIDAD", Convert.ToString(quoteInfo.COD_MODALIDAD), 2, 99));

                        break;
                    case 2:
                        //Edad 
                        nacimiento = quoteInfo.FEC_NACIMIENTO2; //Fecha de nacimiento
                        edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "FEC_NACIMIENTO", quoteInfo.FEC_NACIMIENTO2.ToString("ddMMyyyy"), 2, 2));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "VAL_EDAD", Convert.ToString(edad), 2, 3));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "COD_MODALIDAD", Convert.ToString(quoteInfo.COD_MODALIDAD), 2, 99));

                        break;
                    case 3:
                        //Edad 
                        nacimiento = quoteInfo.FEC_NACIMIENTO3; //Fecha de nacimiento
                        edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "FEC_NACIMIENTO", quoteInfo.FEC_NACIMIENTO3.ToString("ddMMyyyy"), 2, 2));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "VAL_EDAD", Convert.ToString(edad), 2, 3));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "COD_MODALIDAD", Convert.ToString(quoteInfo.COD_MODALIDAD), 2, 99));

                        break;
                    case 4:
                        //Edad 
                        nacimiento = quoteInfo.FEC_NACIMIENTO4; //Fecha de nacimiento
                        edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "FEC_NACIMIENTO", quoteInfo.FEC_NACIMIENTO4.ToString("ddMMyyyy"), 2, 2));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "VAL_EDAD", Convert.ToString(edad), 2, 3));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "COD_MODALIDAD", Convert.ToString(quoteInfo.COD_MODALIDAD), 2, 99));

                        break;
                    case 5:
                        //Edad 
                        nacimiento = quoteInfo.FEC_NACIMIENTO5; //Fecha de nacimiento
                        edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "FEC_NACIMIENTO", quoteInfo.FEC_NACIMIENTO5.ToString("ddMMyyyy"), 2, 2));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "VAL_EDAD", Convert.ToString(edad), 2, 3));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "COD_MODALIDAD", Convert.ToString(quoteInfo.COD_MODALIDAD), 2, 99));

                        break;
                    case 6:
                        //Edad 
                        nacimiento = quoteInfo.FEC_NACIMIENTO6; //Fecha de nacimiento
                        edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "FEC_NACIMIENTO", quoteInfo.FEC_NACIMIENTO6.ToString("ddMMyyyy"), 2, 2));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "VAL_EDAD", Convert.ToString(edad), 2, 3));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "COD_MODALIDAD", Convert.ToString(quoteInfo.COD_MODALIDAD), 2, 99));

                        break;
                    case 7:
                        //Edad 
                        nacimiento = quoteInfo.FEC_NACIMIENTO7; //Fecha de nacimiento
                        edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "FEC_NACIMIENTO", quoteInfo.FEC_NACIMIENTO7.ToString("ddMMyyyy"), 2, 2));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "VAL_EDAD", Convert.ToString(edad), 2, 3));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "COD_MODALIDAD", Convert.ToString(quoteInfo.COD_MODALIDAD), 2, 99));

                        break;
                    case 8:
                        //Edad 
                        nacimiento = quoteInfo.FEC_NACIMIENTO8; //Fecha de nacimiento
                        edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "FEC_NACIMIENTO", quoteInfo.FEC_NACIMIENTO8.ToString("ddMMyyyy"), 2, 2));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "VAL_EDAD", Convert.ToString(edad), 2, 3));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "COD_MODALIDAD", Convert.ToString(quoteInfo.COD_MODALIDAD), 2, 99));

                        break;
                    case 9:
                        //Edad 
                        nacimiento = quoteInfo.FEC_NACIMIENTO9; //Fecha de nacimiento
                        edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "FEC_NACIMIENTO", quoteInfo.FEC_NACIMIENTO9.ToString("ddMMyyyy"), 2, 2));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "VAL_EDAD", Convert.ToString(edad), 2, 3));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "COD_MODALIDAD", Convert.ToString(quoteInfo.COD_MODALIDAD), 2, 99));

                        break;
                    case 10:
                        //Edad 
                        nacimiento = quoteInfo.FEC_NACIMIENTO10; //Fecha de nacimiento
                        edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "FEC_NACIMIENTO", quoteInfo.FEC_NACIMIENTO10.ToString("ddMMyyyy"), 2, 2));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "VAL_EDAD", Convert.ToString(edad), 2, 3));
                        datosVariables.Add(Util.DatoVariable(datosFijos, i, "COD_MODALIDAD", Convert.ToString(quoteInfo.COD_MODALIDAD), 2, 99));

                        break;
                }
            }

                return datosVariables;
        }

        

    }
}
