using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Comun
{
    /// <summary>
    /// Detalle de una cobertura.
    /// </summary>
    public class Cobertura
    {

        /// <summary>
        /// Seleccionada.
        /// </summary>
        [DataMember(), JsonProperty()] public bool seleccionado { get; set; }
        /// <summary>
        /// Requerida.
        /// </summary>
        [DataMember(), JsonProperty()] public bool requerida { get; set; }
        /// <summary>
        /// Número de riesgo.
        /// </summary>
        [DataMember(), JsonProperty()] public int riesgo { get; set; } = 1;
        /// <summary>
        /// Código de cobertura.
        /// </summary>
        [DataMember(), JsonProperty()] public int codigo { get; set; }
        /// <summary>
        /// Nombre.
        /// </summary>
        [DataMember(), JsonProperty()] public string nombre { get; set; }
        /// <summary>
        /// Capital.
        /// </summary>
        [DataMember(), JsonProperty()] public double capital { get; set; }
        /// <summary>
        /// Prima total.
        /// </summary>
        [DataMember(), JsonProperty()] public double primatotal { get; set; }
        /// <summary>
        /// Deducible.
        /// </summary>
        [DataMember(), JsonProperty()] public string deducible { get; set; }
        /// <summary>
        /// Error.
        /// </summary>
        [DataMember(), JsonProperty()] public string error { get; set; }

        /// <summary>
        /// Indica si el capital es editable
        /// </summary>
        [DataMember(), JsonProperty()] public bool edtCapital{ get; set; }
    }

}
