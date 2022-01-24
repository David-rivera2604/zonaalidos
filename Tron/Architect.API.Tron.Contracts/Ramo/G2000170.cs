using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Ramo
{
    /// <summary>
    /// CONCEPTOS DE DESGLOSE.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class G2000170
    {
        /// <summary>
        /// CODIGO DE COMPAÑIA.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_CIA { get; set; }
        /// <summary>
        /// CONCEPTO DE DESGLOSE ECONOMICO.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_DESGLOSE { get; set; }
        /// <summary>
        /// NOMBRE DEL CONCEPTO DE DESGLOSE.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_DESGLOSE { get; set; }
        /// <summary>
        /// NOMBRE CORTO DEL CONCEPTO DE DESGLOSE.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_COR_DESGLOSE { get; set; }
        /// <summary>
        /// AMBITO DE USO.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_AMBITO { get; set; }
        /// <summary>
        /// SI SE VA A REALIZAR ESTUDIO DE IMPORTES.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_ESTUDIO { get; set; }
        /// <summary>
        /// BASE CALCULO (PRIMA, CAPITAL, BLOQUE, .).
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_BASE_CALCULO { get; set; }
        /// <summary>
        /// FORMA DE CALCULO.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_CALCULO { get; set; }
        /// <summary>
        /// TANTO PORCIENTO O PORMIL QUE DETERMINARA EL CALCULO.
        /// </summary>
        [DataMember(), JsonProperty()] public Int64 TASA_CALCULO { get; set; }
        /// <summary>
        /// IMPORTE DE LA TARIFA.
        /// </summary>
        [DataMember(), JsonProperty()] public Int64 IMP_CALCULO { get; set; }
        /// <summary>
        /// PROCEDIMIENTO QUE DETERMINA EL CALCULO.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_CALCULO { get; set; }
        /// <summary>
        /// SI EN EL SUPLEMENTO SE DEVUELVE O NO EL IMPORTE.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEVUELVE { get; set; }
        /// <summary>
        /// EL CONCEPTO ES PRORRATEABLE (SE APLICAN CRITERIOS DE TIEMPO EN EL CALCULO).
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_APLICA_PRORRATA { get; set; }
        /// <summary>
        /// EL CALCULO SIEMPRE ES AUTOMATICO AUNQUE LA POLIZA CALCULE DE FORMA MANUAL.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_CALCULO_AUTOMATICO { get; set; }
        /// <summary>
        /// CONCEPTO ECONOMICO DE RECIBO.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_ECO { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL COBERTURA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_C0 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL COBERTURA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_C1 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL COBERTURA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_C2 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL COBERTURA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_C3 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL COBERTURA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_C4 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL COBERTURA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_C5 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL COBERTURA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_C6 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL COBERTURA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_C7 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL COBERTURA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_C8 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL COBERTURA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_C9 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL RIESGO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_R0 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL RIESGO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_R1 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL RIESGO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_R2 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL RIESGO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_R3 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL RIESGO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_R4 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL POLIZA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_P0 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL POLIZA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_P1 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL POLIZA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_P2 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL POLIZA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_P3 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL POLIZA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_P4 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL TOTAL.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_T0 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL TOTAL.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_T1 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL TOTAL.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_T2 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL TOTAL.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_T3 { get; set; }
        /// <summary>
        /// SE ACUMULA EL IMPORTE RESULTANTE A ESTE BLOQUE DE NIVEL TOTAL.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DEPOSITA_CALCULO_T4 { get; set; }
        /// <summary>
        /// USUARIO QUE ACTUALIZO LA FILA.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_USR { get; set; }
        /// <summary>
        /// FECHA DE LA ULTIMA ACTUALIZACION DEL REGISTRO.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_ACTU { get; set; }
        /// <summary>
        /// FECHA DE VALIDEZ.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_VALIDEZ { get; set; }
        /// <summary>
        /// PROCEDIMIENTO QUE DETERMINA EL IMPORTE NO CONSUMIDO.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_NO_CONSUMIDO { get; set; }
    }
}

