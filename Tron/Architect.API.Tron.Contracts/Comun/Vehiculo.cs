using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Comun
{
    /// <summary>
    /// Información de l vehiculo
    /// </summary>
    public class vehiculo
    {
        /// <summary>
        /// Vehiculo ID
        /// </summary>
        [DataMember(), JsonProperty()] public int vehiculoId { get; set; }

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
        /// Cilindraje del vehículo.
        /// </summary>
        [DataMember(), JsonProperty()] public string DES_TIP_CILINDRAJE { get; set; }
        /// <summary>
        /// Peso del vehículo.
        /// </summary>
        [DataMember(), JsonProperty()] public int VAL_PESO { get; set; }
        /// <summary>
        /// Color del vehículo.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_COLOR { get; set; }
        [DataMember(), JsonProperty()] public string COD_COLORDesc { get; set; }
        /// <summary>
        /// Capacidad del vehículo.
        /// </summary>
        [DataMember(), JsonProperty()] public int VAL_CAPACIDAD { get; set; }
    }

}
