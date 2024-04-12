/// <summary>
///
/// </summary>

using System;

namespace Architect.API.Tron.Contracts.Batch
{
    public partial class CotizadorMapfreMasClass
    {
        /// <summary>
        ///
        /// </summary>
        public DateTime fec_efec_spto { get; set; } = DateTime.MinValue;

        /// <summary>
        ///
        /// </summary>
        public int mca_riesgo { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public string num_poliza { get; set; } = " ";

        /// <summary>
        ///
        /// </summary>
        public string tip_docum { get; set; } = " ";

        /// <summary>
        ///
        /// </summary>
        public string cod_docum { get; set; } = " ";

        /// <summary>
        ///
        /// </summary>
        public string nom_tercero { get; set; } = " ";

        /// <summary>
        ///
        /// </summary>
        public string ape1_tercero { get; set; } = " ";

        /// <summary>
        ///
        /// </summary>
        public DateTime fec_nacimiento { get; set; } = DateTime.MinValue;

        /// <summary>
        ///
        /// </summary>
        public string mca_sexo { get; set; } = " ";

        /// <summary>
        ///
        /// </summary>
        public int cod_agt { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public string tip_docum_sub_agt { get; set; } = "";

        /// <summary>
        ///
        /// </summary>
        public string cod_docum_sub_agt { get; set; } = "";

        /// <summary>
        ///
        /// </summary>
        public bool Sub_Agt { get; set; } = false;

        /// <summary>
        ///
        /// </summary>
        public int cod_mon { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public int cod_fracc_pago { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public DateTime fec_efec_poliza { get; set; } = DateTime.MinValue;

        /// <summary>
        ///
        /// </summary>
        public DateTime fec_vcto_poliza { get; set; } = DateTime.MinValue;

        /// <summary>
        ///
        /// </summary>
        public string num_placa { get; set; } = " ";

        /// <summary>
        ///
        /// </summary>
        public int cod_plan { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public int cod_marca { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public int cod_modelo { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public int cod_tip_vehi { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public int cod_uso_vehi { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public int anio_Veh { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public string Tip_Valoracion { get; set; } = " ";

        /// <summary>
        ///
        /// </summary>
        public string mca_desc_client_nuevo { get; set; } = " ";

        /// <summary>
        ///
        /// </summary>
        public string GPS { get; set; } = " ";

        /// <summary>
        ///
        /// </summary>
        public string mca_cero_km { get; set; } = " ";

        /// <summary>
        ///
        /// </summary>
        public int pct_dcto_auto_par { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public string mca_HogarTotal { get; set; } = " ";

        /// <summary>
        ///
        /// </summary>
        public double pct_dcto_HogarTotal { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public int edad { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public int cod_zona_circul { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public int cod_sub_modelo { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public double Resp_civilSA { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public double Gast_medicSA { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public double Acc_ConducSA { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public double ColisionYVuelcoSA { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public double RiesgosAdicionalesSA { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public double RoboSA { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public double Valor_VehiSA { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public double Equi_EspeSA { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public double Rotu_CristSA { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public double Auto_NeumSA { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public double Auto_MecaSA { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public string coberturas { get; set; } = " ";

        /// <summary>
        ///
        /// </summary>
        public int cod_color { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public string mca_auto_gps_cms { get; set; } = " ";

        /// <summary>
        ///
        /// </summary>
        public string mca_vr { get; set; } = "1";

        /// <summary>
        ///
        /// </summary>
        public double imp_vr { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public string mca_pra { get; set; } = " ";

        /// <summary>
        ///
        /// </summary>
        public int ded_auto_rc { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ded_auto_rad { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ded_auto_cyv { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ded_auto_rob { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ded_auto_cri { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ded_auto_eqesp { get; set; }

        /// <summary>
        ///
        /// </summary>
        public double pct_ajuste_gen { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        public string txt_motivo { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        public string num_poliza_grupo { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        public int num_contrato { get; set; } = default;

        /// <summary>
        ///
        /// </summary>
        public int num_subcontrato { get; set; } = default;

        /// <summary>
        ///
        /// </summary>
        public string mca_monitoreo_gps { get; set; } = " ";

        /// <summary>
        ///
        /// </summary>
        public string num_poliza_anterior { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        public string tip_gestor { get; set; } = "AG";

        /// <summary>
        ///
        /// </summary>
        public string cod_gestor { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        public int tip_benef_subAgente { get; set; } = default;

        /// <summary>
        ///
        /// </summary>
        public string p_mca_grupo_familiar { get; set; } = string.Empty;
        public string p_mca_auto_sust { get; set; } = "N";
        public string p_ded_auto_sust { get; set; } = "1";
        public string p_ext_garantia { get; set; } = "N";
        public string num_matricula { get; set; }
        public string num_motor { get; set; }
        public string cod_chassis { get; set; }
        public string rc_alcohol { get; set; } = "N";
        public string mc_cuotas_gratis { get; set; } = "N";
        public int num_cuotas_gratis { get; set; } = 0;
    }
}