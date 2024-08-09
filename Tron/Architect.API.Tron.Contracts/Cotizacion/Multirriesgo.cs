using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Architect.API.Tron.Contracts.Cotizacion
{
    public class Multirriesgo : Quote
    {

        /// <summary>
        /// Moneda.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_mon { get; set; }
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
        /// Nombre del contratante.
        /// </summary>
        [DataMember(), JsonProperty()] public string nombredelcontratante { get; set; }
        /// <summary>
        /// País.
        /// </summary>
        [DataMember(), JsonProperty()] public string cod_pais { get; set; }
        /// <summary>
        /// Provincia.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_estado { get; set; }
        /// <summary>
        /// Cantón.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_prov { get; set; }
        /// <summary>
        /// Distrito.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_localidad { get; set; }
        /// <summary>
        /// Otras señas del riesgo.
        /// </summary>
        [DataMember(), JsonProperty()] public string otrassenasdelriesgo { get; set; }
        /// <summary>
        /// Ocupación del riesgo.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_tip_ocup { get; set; }
        /// <summary>
        /// Tipo.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_tip_edit { get; set; }
        /// <summary>
        /// Número de pisos.
        /// </summary>
        [DataMember(), JsonProperty()] public int num_pisos_edif { get; set; }
        /// <summary>
        /// Tipo de estructura.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_tipo_estruc { get; set; }
        /// <summary>
        /// Tipo de techo.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_tipo_techo { get; set; }
        /// <summary>
        /// Tipo de pared.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_tipo_pared { get; set; }
        /// <summary>
        /// Edificio.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_EDIFICIO { get; set; }
        /// <summary>
        /// Tipo de medida por robo.
        /// </summary>
        [DataMember(), JsonProperty()] public string cod_tip_med_rob { get; set; }
        /// <summary>
        /// Rotura domo, cristales, mármol y granito.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_DOMOS_TOTAL { get; set; }
        /// <summary>
        /// Gastos por alquiler.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_GAS_ALQ { get; set; }
        /// <summary>
        /// Perdida de rentas.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_PER_REN { get; set; }
        /// <summary>
        /// Meses a amparar.
        /// </summary>
        [DataMember(), JsonProperty()] public int COB_PDR_MESES { get; set; }
        /// <summary>
        /// Mercancía en tránsito.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_MER_TRA { get; set; }
        /// <summary>
        /// Tipo de medida por rotura de maquinaria.
        /// </summary>
        [DataMember(), JsonProperty()] public string cod_tip_med_rdm { get; set; }
        /// <summary>
        /// Interrupción de negocios.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_INT_NEG { get; set; }
        /// <summary>
        /// Meses a amparar.
        /// </summary>
        [DataMember(), JsonProperty()] public int COB_IDN_MESES { get; set; }
        /// <summary>
        /// Tipo de riesgos por interrupción de negocios.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_tip_rgo_idn { get; set; }
        /// <summary>
        /// Mobiliario.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_MOBILIARIO { get; set; }
        /// <summary>
        /// Maquinaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_MAQUINARIA { get; set; }
        /// <summary>
        /// Equipos electrónico (No Móvil).
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_EQUIP_ELEC { get; set; }
        /// <summary>
        /// Equipos electrónico (Móvil).
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_EQUIP_ELEC_M { get; set; }
        /// <summary>
        /// Mercadería.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_MERCADERIA { get; set; }
        /// <summary>
        /// Bienes temporalmente desplazados.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_BIE_TEM_DES { get; set; }
        /// <summary>
        /// Bienes a la interperie.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_BIE_INT { get; set; }
        /// <summary>
        /// Objetos de especial valor.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_OBJ_ESP_VAL { get; set; }
        /// <summary>
        /// Tipo de medida contra incendio.
        /// </summary>
        [DataMember(), JsonProperty()] public string cod_tip_med_inc { get; set; }
        /// <summary>
        /// ¿Posee extintores de incendio?.
        /// </summary>
        [DataMember(), JsonProperty()] public int MCA_EXTIN_INC { get; set; }
        /// <summary>
        /// Cuantos extintores de incendio.
        /// </summary>
        [DataMember(), JsonProperty()] public int NUM_EXTIN_INC { get; set; }
        /// <summary>
        /// Coberturas
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.Cobertura> coberturas { get; set; }
        /// <summary>
        /// plan de pago
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.PlanDePago> plandepago { get; set; }

        [DataMember(), JsonProperty()] public int contrato { get; set; }
        [DataMember(), JsonProperty()] public int subcontrato { get; set; }
        [DataMember(), JsonProperty()] public string polizagrupo { get; set; }
    }

}
