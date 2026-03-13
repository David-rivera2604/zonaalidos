using Architect.API.Tron.Contracts.Emision;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Cotizacion
{
    public class MapfreMas : Quote
    {

        /// <summary>
        /// Edad.
        /// </summary>
        [DataMember(), JsonProperty()] public int edad { get; set; }
        /// <summary>
        /// Sexo.
        /// </summary>
        [DataMember(), JsonProperty()] public int mca_sexo { get; set; }
        /// <summary>
        /// Descripción del Sexo.
        /// </summary>
        [DataMember(), JsonProperty()] public string mca_sexoDesc { get; set; }
        /// <summary>
        /// Moneda.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_mon { get; set; }
        [DataMember(), JsonProperty()] public string cod_monDesc { get; set; }
        /// <summary>
        /// Fraccionamiento de pago.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_fracc_pago { get; set; }
        /// <summary>
        /// Inicio de vigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime fec_efec_poliza { get; set; }
        /// <summary>
        /// Fin de vigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime fec_vcto_poliza { get; set; }
        /// <summary>
        /// Tipo de producto.
        /// </summary>
        [DataMember(), JsonProperty()] public string tipo_prod { get; set; }
        [DataMember(), JsonProperty()] public string tipo_prodDesc { get; set; }
        /// <summary>
        /// Plan.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_PLAN_AUTO { get; set; }
        [DataMember(), JsonProperty()] public string COD_PLAN_AUTODesc { get; set; }
        /// <summary>
        /// Zona de circulación.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_zona_circul { get; set; }
        [DataMember(), JsonProperty()] public string cod_zona_circulDesc { get; set; }
        /// <summary>
        /// Marca.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_marca { get; set; }
        [DataMember(), JsonProperty()] public string cod_marcaDesc { get; set; }
        /// <summary>
        /// Modelo.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_modelo { get; set; }
        [DataMember(), JsonProperty()] public string cod_modeloDesc { get; set; }



        /// <summary>
        /// Sub Modelo.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_sub_modelo { get; set; }
        [DataMember(), JsonProperty()] public string cod_sub_modeloDesc { get; set; }



        /// <summary>
        /// Año del vehículo.
        /// </summary>
        [DataMember(), JsonProperty()] public int ANIO_SUB_MODELO { get; set; }
        /// <summary>
        /// Número de placa.
        /// </summary>
        [DataMember(), JsonProperty()] public string NUM_MATRICULA { get; set; }
        /// <summary>
        /// Número de Chasis.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_CHASSIS { get; set; }
        /// <summary>
        /// Motor del vehículo.
        /// </summary>
        [DataMember(), JsonProperty()] public string NUM_MOTOR { get; set; }
        /// <summary>
        /// Clase del vehículo.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_tip_vehi { get; set; }
        [DataMember(), JsonProperty()] public string cod_tip_vehiDesc { get; set; }
        /// <summary>
        /// Uso del vehículo.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_uso_vehi { get; set; }
        [DataMember(), JsonProperty()] public string cod_uso_vehiDesc { get; set; }
        /// <summary>
        /// ¿Es cero km?.
        /// </summary>
        [DataMember(), JsonProperty()] public int MCA_CERO_KM { get; set; }
        /// <summary>
        /// ¿Tiene GPS?.
        /// </summary>
        [DataMember(), JsonProperty()] public int MCA_AUTO_GPS { get; set; }
        /// <summary>
        /// ¿GPS con convenio del ministerio?.
        /// </summary>
        [DataMember(), JsonProperty()] public int MCA_AUTO_GPS_CMS { get; set; }
        /// <summary>
        /// ¿GPS con monitoreo?.
        /// </summary>
        [DataMember(), JsonProperty()] public int MCA_MONITOREO_GPS { get; set; }
        /// <summary>
        /// ¿Asegurar a primer riesgo ABS?.
        /// </summary>
        [DataMember(), JsonProperty()] public int MCA_PRA { get; set; }
        /// <summary>
        /// ¿Asegurar a valor real?.
        /// </summary>
        [DataMember(), JsonProperty()] public int MCA_VR { get; set; }
        /// <summary>
        /// Valor del vehículo asegurado.
        /// </summary>
        [DataMember(), JsonProperty()] public double IMP_VR { get; set; }
        /// <summary>
        /// ¿Es cliente nuevo?.
        /// </summary>
        [DataMember(), JsonProperty()] public int MCA_DESC_CLIENTE_NUEVO { get; set; }
        /// <summary>
        /// Porcentaje de ajuste comercial.
        /// </summary>
        [DataMember(), JsonProperty()] public int PCT_AJUSTE_GEN { get; set; }
        /// <summary>
        /// Responsabilidad civil.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_AUTO_RC { get; set; }
        /// <summary>
        /// Deducible responsabilidad civil.
        /// </summary>
        [DataMember(), JsonProperty()] public int DED_AUTO_RC { get; set; }
        /// <summary>
        /// Gastos médicos de ocupantes.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_AUTO_GMO { get; set; }
        /// <summary>
        /// Accidentes al conductor.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_AUTO_ACO { get; set; }
        /// <summary>
        /// Colisión y vuelco.
        /// </summary>
        [DataMember(), JsonProperty()] public double IMP_AUTO_CYV { get; set; }
        /// <summary>
        /// Deducible colisión y vuelco.
        /// </summary>
        [DataMember(), JsonProperty()] public int DED_AUTO_CYV { get; set; }
        /// <summary>
        /// Riesgos adicionales.
        /// </summary>
        [DataMember(), JsonProperty()] public double IMP_AUTO_RAD { get; set; }
        /// <summary>
        /// Deducible riesgos adicionales.
        /// </summary>
        [DataMember(), JsonProperty()] public int DED_AUTO_RAD { get; set; }
        /// <summary>
        /// Robo.
        /// </summary>
        [DataMember(), JsonProperty()] public double IMP_AUTO_ROB { get; set; }
        /// <summary>
        /// Deducible robo.
        /// </summary>
        [DataMember(), JsonProperty()] public int DED_AUTO_ROB { get; set; }
        /// <summary>
        /// Equipo especial.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_AUTO_EQESP { get; set; }
        /// <summary>
        /// Deducible equipo especial.
        /// </summary>
        [DataMember(), JsonProperty()] public int DED_AUTO_EQESP { get; set; }
        /// <summary>
        /// Garantía de neumáticos.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_AUTO_NEUM { get; set; }
        /// <summary>
        /// Avería mecánica.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_AUTO_MECA { get; set; }
        /// <summary>
        /// Rotura de cristales.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_AUTO_CRI { get; set; }
        /// <summary>
        /// Deducible rotura de cristales.
        /// </summary>
        [DataMember(), JsonProperty()] public int DED_AUTO_CRI { get; set; }
        /// <summary>
        /// Auto sustituto.
        /// </summary>
        [DataMember(), JsonProperty()] public int AutoSust { get; set; }
        /// <summary>
        /// Deducible auto sustituto.
        /// </summary>
        [DataMember(), JsonProperty()] public int DedudAutoSust { get; set; }

        /// <summary>
        /// Deducible auto sustituto Connect.
        /// </summary>
        [DataMember(), JsonProperty()] public int DedudAutoSustConnect { get; set; }
        /// <summary>
        /// Coberturas
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.Cobertura> coberturas { get; set; }
        /// <summary>
        /// plan de pago
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.PlanDePago> plandepago { get; set; }
        /// <summary>
        /// plan de pago vigencia completa
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.PlanDePago> plandepagoFull { get; set; }
        [DataMember(), JsonProperty()] public int contrato { get; set; }
        [DataMember(), JsonProperty()] public string contratoDesc { get; set; }
        [DataMember(), JsonProperty()] public int subcontrato { get; set; }
        [DataMember(), JsonProperty()] public string polizagrupo { get; set; }
        /// <summary>
        /// Extensión de garantía.
        /// </summary>
        [DataMember(), JsonProperty()] public int ext_garantia { get; set; }
        [DataMember(), JsonProperty()] public string rc_alcohol { get; set; } = "N";
        [DataMember(), JsonProperty()] public string mc_cuotas_gratis { get; set; } = "N";
        [DataMember(), JsonProperty()] public int num_cuotas_gratis { get; set; }


        [DataMember(), JsonProperty()] public string nombredelcontratante { get; set; }

        [DataMember(), JsonProperty()] public string COD_TIP_COM_VEHI { get; set; } = "1";

    }

}
