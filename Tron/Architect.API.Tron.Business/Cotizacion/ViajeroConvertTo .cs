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

            datosFijos.Riesgos = Util.DatosDelRiesgo(datosFijos, "Cotizador Seguro de Viaje");
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

            foreach (Architect.API.Tron.Contracts.Cotizacion.Viajerocoberturas item in from c in quoteInfo.coberturas where c.seleccionado select c)
            {

                coberturas.Add(Util.Cobertura(datosFijos, item.codigo));
                    
            }

            return coberturas;
        }

        private static List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable> DatosVariable(Contracts.Cotizacion.Viajero quoteInfo, Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos)
        {
            List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable> datosVariables = new List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable>();

            //Numero de Dias
            TimeSpan difFechas = quoteInfo.fec_vcto_poliza - quoteInfo.fec_efec_poliza;
            int dias = difFechas.Days;

            //Edad 
            DateTime nacimiento = quoteInfo.FEC_NACIMIENTO; //Fecha de nacimiento
            int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;

            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "TIP_PLAN", quoteInfo.TIP_PLAN,1,1));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "FEC_VIAJE", quoteInfo.FEC_VIAJE.ToString("dd/MM/yyyy"), 1, 2));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "NUM_DIA", Convert.ToString(dias), 1, 3));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "DES_DESTINO", quoteInfo.DES_DESTINO, 1, 4));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "CANAL_VENTA", "TWB", 1, 5));
            datosVariables.Add(Util.DatoVariable(datosFijos, 0, "TIP_VIAJE", quoteInfo.TIP_VIAJE, 1, 6));
            datosVariables.Add(Util.DatoVariable(datosFijos, 1, "FEC_NACIMIENTO", quoteInfo.FEC_NACIMIENTO.ToString("dd/MM/yyyy"), 2, 2));
            datosVariables.Add(Util.DatoVariable(datosFijos, 1, "VAL_EDAD", Convert.ToString(edad), 2, 3));
            datosVariables.Add(Util.DatoVariable(datosFijos, 1, "COD_MODALIDAD",Convert.ToString(quoteInfo.COD_MODALIDAD), 2, 99));

      
            return datosVariables;
        }

    }
}
