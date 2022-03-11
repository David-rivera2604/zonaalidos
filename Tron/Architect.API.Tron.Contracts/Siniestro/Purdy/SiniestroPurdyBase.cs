using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Siniestro.Purdy
{
    /// <summary>
    /// Información detalle de un siniestro procesado por Purdy
    /// </summary>
    [Serializable(), DataContract()]
    public partial class SiniestroPurdyBase
    {
        /// <summary>
        /// Número de siniestro.
        /// </summary>
        [DataMember(), JsonProperty()] public Int64 NUM_SINI { get; set; }
        /// <summary>
        /// Número de expediente.
        /// </summary>
        [DataMember(), JsonProperty()] public int NUM_EXP { get; set; }    
    }
}

