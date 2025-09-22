using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Data;

namespace Architect.API.Tron.DataAccess
{

    /// <summary>
    /// em_k_cotizador_web_303_mcr
    /// </summary>
    public static class CotizadorMapfreMasPlusClass
    {
        public static Architect.API.Tron.Contracts.Presupuesto.DatoFijo P_Cotiza(Architect.API.Tron.Contracts.Batch.CotizadorMapfreMasClass p2000030Instance, IDbConnection currentConnection)
        {
            Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = new Architect.API.Tron.Contracts.Presupuesto.DatoFijo();
            Database.Procedure("em_k_cotizador_web_303_mcr.P_COTIZA")
                .AddParameter("P_TIP_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 3, p2000030Instance.tip_docum)
                .AddParameter("P_COD_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 20, p2000030Instance.cod_docum)
                .AddParameter("P_NOM_TERCERO", Architect.DataFactory.Enumerations.DbType.String, 180, p2000030Instance.nom_tercero)
                .AddParameter("P_APE1_TERCERO", Architect.DataFactory.Enumerations.DbType.String, 30, p2000030Instance.ape1_tercero)
                .AddParameter("P_FEC_NACIMIENTO", Architect.DataFactory.Enumerations.DbType.Date, 0, p2000030Instance.fec_nacimiento)
                .AddParameter("P_MCA_SEXO", Architect.DataFactory.Enumerations.DbType.String, 1, "9")
                .AddParameter("P_COD_AGT", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_agt)
                .AddParameter("P_COD_MON", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_mon)
                .AddParameter("P_COD_FRACC_PAGO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_fracc_pago)
                .AddParameter("P_FEC_EFEC_POLIZA", Architect.DataFactory.Enumerations.DbType.Date, 0, p2000030Instance.fec_efec_poliza)
                .AddParameter("P_FEC_VCTO_POLIZA", Architect.DataFactory.Enumerations.DbType.Date, 0, p2000030Instance.fec_vcto_poliza)
                .AddParameter("P_COD_PLAN", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_plan)
                .AddParameter("P_COD_MARCA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_marca)
                .AddParameter("P_COD_TIP_VEHI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_tip_vehi)
                .AddParameter("P_COD_USO_VEHI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_uso_vehi)
                .AddParameter("P_ANIO_VEH", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.anio_Veh)
                .AddParameter("P_TIP_VALORACION", Architect.DataFactory.Enumerations.DbType.String, 1, p2000030Instance.Tip_Valoracion)
                .AddParameter("P_MCA_DESC_CLIENT_NUEVO", Architect.DataFactory.Enumerations.DbType.String, 1, p2000030Instance.mca_desc_client_nuevo)
                .AddParameter("P_GPS", Architect.DataFactory.Enumerations.DbType.String, 3, p2000030Instance.GPS)
                .AddParameter("P_RESP_CIVILSA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.Resp_civilSA)
                .AddParameter("P_GAST_MEDICSA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.Gast_medicSA)
                .AddParameter("P_ACC_CONDUCSA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.Acc_ConducSA)
                .AddParameter("P_CYVSA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.ColisionYVuelcoSA)
                .AddParameter("P_RADSA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.RiesgosAdicionalesSA)
                .AddParameter("P_ROBSA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.RoboSA)
                .AddParameter("P_VALOR_VEHISA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.Valor_VehiSA)
                .AddParameter("P_EQUI_ESPESA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.Equi_EspeSA)
                .AddParameter("P_ROTU_CRISTSA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.Rotu_CristSA)
                .AddParameter("P_COBERTURAS", Architect.DataFactory.Enumerations.DbType.String, 180, p2000030Instance.coberturas)
                .AddParameter("P_MCA_CERO_KM", Architect.DataFactory.Enumerations.DbType.String, 1, p2000030Instance.mca_cero_km)
                .AddParameter("P_MODELO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_modelo)
                .AddParameter("P_PCT_DCTO_AUTO_PAR", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.pct_dcto_auto_par)
                .AddParameter("P_PCT_DCTO_HOGAR_TOTAL", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.pct_dcto_HogarTotal)
                .AddParameter("P_NUM_POLIZA_GRUPO", Architect.DataFactory.Enumerations.DbType.String, 13, p2000030Instance.num_poliza_grupo)
                .AddParameter("P_NUM_CONTRATO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.num_contrato)
                .AddParameter("P_NUM_SUBCONTRATO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.num_subcontrato)
                .AddParameter("P_AVERIA_NEUMSA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.Auto_MecaSA)
                .AddParameter("P_GARAN_MECASA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.Auto_NeumSA)
                .AddParameter("P_COD_ZONA_CIRCUL", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_zona_circul)
                .AddParameter("P_COD_SUB_MODELO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.cod_sub_modelo)
                .AddParameter("P_EDAD", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.edad)
                .AddParameter("P_MCA_AUTO_GPS_CMS", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.mca_auto_gps_cms)
                .AddParameter("P_MCA_VR", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.mca_vr)
                .AddParameter("P_IMP_VR", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.imp_vr)
                .AddParameter("P_MCA_PRA", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.mca_pra)
                .AddParameter("P_DED_AUTO_RC", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.ded_auto_rc)
                .AddParameter("P_DED_AUTO_RAD", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.ded_auto_rad)
                .AddParameter("P_DED_AUTO_CYV", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.ded_auto_cyv)
                .AddParameter("P_DED_AUTO_ROB", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.ded_auto_rob)
                .AddParameter("P_DED_AUTO_CRI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.ded_auto_cri)
                .AddParameter("P_DED_AUTO_EQESP", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.ded_auto_eqesp)
                .AddParameter("p_pct_dcto_auto_par", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2000030Instance.pct_ajuste_gen)
                .AddParameter("P_MCA_MONITOREO_GPS", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.mca_monitoreo_gps)
                .AddParameter("P_TXT_MOTIVO", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.txt_motivo)
                .AddParameter("P_NUM_POLIZA_ANTERIOR", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.num_poliza_anterior)
                .AddParameter("P_TIP_GESTOR", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.tip_gestor)
                .AddParameter("P_COD_GESTOR", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.cod_gestor)

                .AddParameter("P_MCA_AUTO_SUST", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.p_mca_auto_sust)
                .AddParameter("P_DED_AUTO_SUST", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.p_ded_auto_sust)
                 .AddParameter("P_MCA_AUTO_SUST_CONNECT", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.p_mca_auto_sust_connect)
                .AddParameter("P_DED_AUTO_SUST_CONNECT", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.p_ded_auto_sust_connect)
                .AddParameter("P_EXT_GARANTIA", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.p_ext_garantia)
                .AddParameter("P_RC_ALCOHOL", Architect.DataFactory.Enumerations.DbType.String, 0, p2000030Instance.rc_alcohol)
                .AddParameter("P_MCA_CUOTAS_GRATIS", Architect.DataFactory.Enumerations.DbType.String, 2, p2000030Instance.mc_cuotas_gratis)
                .AddParameter("P_NUM_CUOTAS_GRATIS", Architect.DataFactory.Enumerations.DbType.Int32, 3, p2000030Instance.num_cuotas_gratis)
                .AddParameter("P_COD_CUADRO_COM", Architect.DataFactory.Enumerations.DbType.Int32, 3, p2000030Instance.cod_cuadro_com)
                .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                {
                    if (result.Coberturas.IsEmpty())
                    {
                        result.Coberturas = new System.Collections.Generic.List<Contracts.Presupuesto.Cobertura>();
                    }
                    result.Coberturas.Add(new Architect.API.Tron.Contracts.Presupuesto.Cobertura()
                    {
                        num_poliza = reader.StringValue("num_poliza"),
                        cod_cob = reader.IntegerValue("cod_cob"),
                        nom_cob = reader.StringValue("nom_cob"),
                        suma_aseg = reader.Integer64Value("suma_aseg"),
                        imp_anual = reader.Integer64Value("imp_anual"),
                        imp_iva = reader.Integer64Value("imp_iva"),
                        imp_fracc = reader.Integer64Value("imp_fracc"),
                        imp_total = reader.Integer64Value("imp_total"),
                        cod_franquicia = reader.IntegerValue("cod_franquicia"),
                        nom_franquicia = reader.StringValue("nom_franquicia"),
                        txt_error = reader.StringValue("txt_error")
                    });
                }));
            return result;
        }

    }
}