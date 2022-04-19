using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Comun
{
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
        /// Código.
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
        [DataMember(), JsonProperty()] public string decucible { get; set; }
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
