using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.GastosMedicos
{
    // <summary>
    /// Información de un asegurado de gastos medicos en Medical.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class AseguradoGastosMedicosMD
    {
        /// <summary>
        /// Primer nombre.
        /// </summary>
        [DataMember(), JsonProperty()] public string Exitoso { get; set; }
        /// <summary>
        /// Segundo nombre.
        /// </summary>
        [DataMember(), JsonProperty()] public string Razon { get; set; }
        /// <summary>
        /// Poliza
        /// </summary>
        [DataMember(), JsonProperty()] public AseguradoMD Asegurado { get; set; }
        /// <summary>
        /// Dependientes
        /// </summary>
        [DataMember(), JsonProperty()] public List<DependientesMD> Dependientes { get; set; }


    }
}
