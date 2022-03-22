using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Ramo
{
    /// <summary>
    /// COBERTURAS DE CONTRATOS DE POLIZAS GRUPO O FLOTAS. (Implementación parcial)
    /// </summary>
    [Serializable(), DataContract()]
    public partial class G2990026
    {
        /// <summary>
        /// CAPITAL. 
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_COB { get; set; }
        /// <summary>
        /// OBLIGATORIO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_OBLIGATORIO { get; set; }

    }
}

