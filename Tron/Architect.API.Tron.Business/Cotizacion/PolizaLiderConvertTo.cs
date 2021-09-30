using Architect.Utilities.Extensions;
using System;
using System.Linq;

namespace Architect.API.Tron.Business.Cotizacion
{
    public static class PolizaLiderConvertTo
    {

        internal static Architect.API.Tron.Contracts.Batch.CotizadorPolizaLiderClass Tron(Contracts.Cotizacion.PolizaLider quoteInfo, bool isCoope, int branch, int agentCode, string userName, string identificationType, string identification)
        {
            if (identificationType == "0")
            {
                identificationType = string.Empty;
            }
            Architect.API.Tron.Contracts.Batch.CotizadorPolizaLiderClass datosFijos = new Architect.API.Tron.Contracts.Batch.CotizadorPolizaLiderClass()
            {
                tip_producto = "Lider",
                fec_efec_spto = quoteInfo.fec_efec_poliza,
                mca_riesgo = 1,
                tip_docum = "CNA",
                cod_docum = "999999999",
                nom_tercero = String.Empty,
                fec_nacimiento = DateTime.MinValue,
                mca_sexo = "1",
                cod_agt = agentCode,
                cod_mon = quoteInfo.cod_mon,
                cod_fracc_pago = quoteInfo.cod_fracc_pago,
                fec_efec_poliza = quoteInfo.fec_efec_poliza,
                fec_vcto_poliza = quoteInfo.fec_vcto_poliza,
                cod_plan = quoteInfo.COD_PLAN_AUTO,
                cod_marca = quoteInfo.COD_MARCA,
                cod_tip_vehi = quoteInfo.COD_TIP_VEHI,
                cod_uso_vehi = quoteInfo.COD_USO_VEHI,
                anio_Veh = quoteInfo.ANIO_SUB_MODELO,
                Tip_Valoracion = quoteInfo.MCA_VR == "1" ? "VR" : "PRA",
                mca_desc_client_nuevo = quoteInfo.MCA_DESC_CLIENTE_NUEVO == 1 ? "S" : "N",
                GPS = quoteInfo.MCA_AUTO_GPS == 1 ? "SN" : "NN",
                Resp_civilSA = quoteInfo.Resp_civilSA,
                Gast_medicSA = quoteInfo.Gast_medicSA,
                Acc_ConducSA = quoteInfo.Acc_ConducSA,
                Valor_VehiSA = quoteInfo.Valor_VehiSA,
                Equi_EspeSA = quoteInfo.Equi_EspeSA,
                Rotu_CristSA = quoteInfo.IMP_AUTO_CRI,
                mca_cero_km = quoteInfo.MCA_CERO_KM == 1 ? "S" : "N",
                pct_dcto_auto_par = quoteInfo.PCT_DCTO_AUTO_PAR,
                cod_modelo = quoteInfo.COD_MODELO,
                mca_HogarTotal = quoteInfo.mca_HogarTotal == 1 ? "S" : "N",
                txt_motivo = "Cotización realizada desde la zona de aliados, por: " + userName,
                cod_gestor = string.Empty,
                tip_docum_sub_agt = identificationType,
                cod_docum_sub_agt = identification
            };

            string selected = string.Empty;

            foreach (Architect.API.Tron.Contracts.Cotizacion.PolizaLiderCoberturas item in from c in quoteInfo.coberturas where c.seleccionado select c)
            {
                if (selected.IsNotEmpty())
                {
                    selected += ",";
                }
                selected += item.codigo.ToString();
            }

            datosFijos.coberturas = selected;

            //              If ConfigurationManager.AppSettings("MCR.HogarTotalProductDiscount.ON") Then
            //    If mca_HogarTotalRadioButtonList.SelectedItem.Value = "S" Then
            //        _class.pct_dcto_HogarTotal = ConfigurationManager.AppSettings("MCR.HogarTotalProductDiscount.Percentaje")
            //        '_class.pct_dcto_auto_par += _class.pct_dcto_HogarTotal
            //    End If
            //End If

            //< dx:ListEditItem Value = 'NN' Text = 'No' Selected = "true" />
            //< dx:ListEditItem Value = 'SN' Text = 'Si' />
            //  < dx:ListEditItem Value = 'SS' Text = 'Si / Con Convenio' />

            return datosFijos;
        }

    }
}
