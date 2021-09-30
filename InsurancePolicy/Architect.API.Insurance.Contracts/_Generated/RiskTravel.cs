using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
        /// <summary>
        /// Información particular para seguros de viaje
        /// </summary>
    [Serializable(), DataContract()]
    public partial class RiskTravel
    {
        /// <summary>
        /// Identificación única de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Inicio del viaje.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime StartTravel { get; set; }
        /// <summary>
        /// Finalización del viaje.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime EndTravel { get; set; }
        /// <summary>
        /// Destinos del viaje
        /// </summary>
        [DataMember(), JsonProperty()] public string TravelDestinations { get; set; }
        /// <summary>
        /// Descripción para destinos del viaje
        /// </summary>
        [DataMember(), JsonProperty()] public string TravelDestinationsDesc { get; set; }
        /// <summary>
        /// Período de viaje.
        /// </summary>
        [DataMember(), JsonProperty()] public int TravelPeriod { get; set; }
        /// <summary>
        /// Descripción para período de viaje.
        /// </summary>
        [DataMember(), JsonProperty()] public string TravelPeriodDesc { get; set; }
        /// <summary>
        /// Usuario que actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int UpdateUserCode { get; set; }
        /// <summary>
        /// Nombre del usuario que actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public string UpdateUserName { get; set; }
        /// <summary>
        /// Fecha que se actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime UpdateDate { get; set; }
    }
}

