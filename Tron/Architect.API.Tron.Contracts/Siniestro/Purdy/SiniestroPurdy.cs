using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Siniestro.Purdy
{
    /// <summary>
    /// Información detalle de un siniestro procesado por Purdy
    /// </summary>
    [Serializable(), DataContract()]
    public partial class SiniestroPurdy: SiniestroPurdyBase
    {
        /// <summary>
        /// Número de póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string NUM_POLIZA { get; set; }
        /// <summary>
        /// Tipo de expediente.
        /// </summary>
        [DataMember(), JsonProperty()] public int TIP_EXP { get; set; }
        /// <summary>
        /// Monto mano de obra
        /// </summary>
        [DataMember(), JsonProperty()] public double MONTO_MANO_OBRA { get; set; }
        /// <summary>
        /// Monto de repuestos
        /// </summary>
        [DataMember(), JsonProperty()] public double MONTO_REPUESTOS { get; set; }
        /// <summary>
        /// Monto total
        /// </summary>
        [DataMember(), JsonProperty()] public double MONTO_TOTAL { get; set; }
        /// <summary>
        /// Monto otros rubros
        /// </summary>
        [DataMember(), JsonProperty()] public double MONTO_OTRO_RUBROS { get; set; }
        /// <summary>
        /// Monto deducible
        /// </summary>
        [DataMember(), JsonProperty()] public double MONTO_DEDUCIBLE { get; set; }
        /// <summary>
        /// Monto recuperado
        /// </summary>
        [DataMember(), JsonProperty()] public double MONTO_RECUPERADO { get; set; }
        /// <summary>
        /// Fecha de último pago
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FECHA_ULTIMO_PAGO { get; set; }
        /// <summary>
        /// Fecha de recuperación
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FECHA_RECUPERACION { get; set; }
        /// <summary>
        /// Estado de expediente
        /// </summary>
        [DataMember(), JsonProperty()] public int TIP_EST_EXP { get; set; }
    }
}

