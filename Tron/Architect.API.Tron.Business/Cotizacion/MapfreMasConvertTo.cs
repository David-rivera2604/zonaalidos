using Architect.Utilities.Extensions;
using System.Linq;

namespace Architect.API.Tron.Business.Cotizacion
{
    internal static class MapfreMasConvertTo
    {

        const int TIPBENEF_SUBAGENTE = 37;
        const bool C_IsSubAgent = false; //ROL

        internal static Architect.API.Tron.Contracts.Batch.CotizadorMapfreMasClass Tron(Contracts.Cotizacion.MapfreMas quoteInfo, int branch, int agentCode, string userName, string identificationType, string identification, string roles)
        {

            Architect.API.Tron.Contracts.Batch.CotizadorMapfreMasClass result = new Architect.API.Tron.Contracts.Batch.CotizadorMapfreMasClass()
            {
                fec_efec_spto = quoteInfo.fec_efec_poliza,
                mca_riesgo = 1,
                nom_tercero = string.Empty,
                mca_sexo = quoteInfo.mca_sexo.ToString(),
                cod_agt = agentCode,
                cod_mon = quoteInfo.cod_mon,
                cod_fracc_pago = quoteInfo.cod_fracc_pago,
                fec_efec_poliza = quoteInfo.fec_efec_poliza,
                fec_vcto_poliza = quoteInfo.fec_vcto_poliza,
                cod_plan = quoteInfo.COD_PLAN_AUTO,
                cod_marca = quoteInfo.cod_marca,
                cod_tip_vehi = quoteInfo.cod_tip_vehi,
                cod_uso_vehi = quoteInfo.cod_uso_vehi,
                anio_Veh = quoteInfo.ANIO_SUB_MODELO,
                Tip_Valoracion = "VR",
                mca_desc_client_nuevo = quoteInfo.MCA_DESC_CLIENTE_NUEVO == 1 ? "S" : "N",
                GPS = quoteInfo.MCA_AUTO_GPS == 1 ? "SS" : "SN",
                Resp_civilSA = quoteInfo.IMP_AUTO_RC,
                Gast_medicSA = quoteInfo.IMP_AUTO_GMO,
                Acc_ConducSA = quoteInfo.IMP_AUTO_ACO,
                ColisionYVuelcoSA = quoteInfo.IMP_AUTO_CYV,
                RiesgosAdicionalesSA = quoteInfo.IMP_AUTO_RAD,
                RoboSA = quoteInfo.IMP_AUTO_ROB,
                Valor_VehiSA = quoteInfo.IMP_VR,
                Equi_EspeSA = quoteInfo.IMP_AUTO_EQESP,
                Rotu_CristSA = quoteInfo.IMP_AUTO_CRI,
                coberturas = string.Empty,
                mca_cero_km = quoteInfo.MCA_CERO_KM == 1 ? "S" : "N",
                cod_modelo = quoteInfo.cod_modelo,
                mca_HogarTotal = "N",
                Auto_NeumSA = quoteInfo.IMP_AUTO_NEUM,
                Auto_MecaSA = quoteInfo.IMP_AUTO_MECA,
                cod_zona_circul = quoteInfo.cod_zona_circul,
                cod_sub_modelo = quoteInfo.cod_sub_modelo == 0 ? 999 : quoteInfo.cod_sub_modelo,
                edad = quoteInfo.edad,
                mca_auto_gps_cms = quoteInfo.MCA_AUTO_GPS_CMS == 1 ? "SS" : "SN",
                mca_vr = "SS" ,
                imp_vr = quoteInfo.IMP_VR,
                mca_pra = quoteInfo.MCA_PRA == 1 ? "SS" : "SN",
                ded_auto_rc = quoteInfo.DED_AUTO_RC,
                ded_auto_rad = quoteInfo.DED_AUTO_RAD,
                ded_auto_cyv = quoteInfo.DED_AUTO_CYV,
                ded_auto_rob = quoteInfo.DED_AUTO_ROB,
                ded_auto_cri = quoteInfo.DED_AUTO_CRI,
                ded_auto_eqesp = quoteInfo.DED_AUTO_EQESP,
                pct_ajuste_gen = quoteInfo.PCT_AJUSTE_GEN,
                mca_monitoreo_gps = quoteInfo.MCA_MONITOREO_GPS == 1 ? "SS" : "SN",
                tip_benef_subAgente = TIPBENEF_SUBAGENTE,
                cod_docum = "999999999",
                tip_docum = "CNA",
                tip_docum_sub_agt = identificationType,
                cod_docum_sub_agt = identification,
                Sub_Agt = C_IsSubAgent,
                num_contrato = quoteInfo.contrato,
                num_subcontrato = quoteInfo.subcontrato,
                num_poliza_grupo = quoteInfo.polizagrupo,
                txt_motivo = "Cotización realizada desde la zona de aliados, por: " + userName,
                num_matricula = quoteInfo.NUM_MATRICULA,
                num_motor = quoteInfo.NUM_MOTOR,
                cod_chassis = quoteInfo.COD_CHASSIS,
                p_ext_garantia = quoteInfo.ext_garantia == 1 ? "S" : "N"
            };

            //result.tip_docum = tip_documComboBox.Value
            //result.cod_docum = cod_documTextBox.Value
            //result.nom_tercero = IIf(String.IsNullOrEmpty(HiddenCotizador("nom_tercero")), " ", HiddenCotizador("nom_tercero"))
            //result.fec_nacimiento = fec_nacimientoDateEdit.Value

            if (roles.Contain("Purdy"))
            {
                if (result.cod_tip_vehi == 5 || result.cod_tip_vehi == 17 || result.cod_tip_vehi == 18)
                {
                    result.p_mca_auto_sust = "N";
                }
                else
                {
                    result.p_mca_auto_sust = "S";
                    result.p_ded_auto_sust = quoteInfo.DedudAutoSust.ToString();
                }

                result.rc_alcohol = quoteInfo.rc_alcohol;
            }

            if (quoteInfo.coberturas.IsNotEmpty())
            {
                foreach (Contracts.Comun.Cobertura cover in quoteInfo.coberturas.Where(r => r.seleccionado))
                {
                    if (result.coberturas.IsNotEmpty())
                    {
                        result.coberturas += ",";
                    }
                    result.coberturas += cover.codigo.ToString();
                }
            }
            return result;
        }

    }
}
