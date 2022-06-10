using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.GastosMedicos
{
    /// <summary>
    /// Información de beneficios  de un asegurado en gastos medicos.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class Dependientes
    {
        /// <summary>
        /// Primer nombre.
        /// </summary>
        [DataMember(), JsonProperty()] public string nombre { get; set; }
        /// <summary>
        /// identificacion.
        /// </summary>
        [DataMember(), JsonProperty()] public string identificacion { get; set; }
        /// <summary>
        /// fechaNacimiento.
        /// </summary>
        [DataMember(), JsonProperty()] public string fechaNacimiento { get; set; }


    }
}
