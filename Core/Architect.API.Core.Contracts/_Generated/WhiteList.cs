using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    [Serializable(), DataContract()]
    public partial class WhiteList
    {
        /// <summary>
        /// Identificador único.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Dirección IP/Nombre de la maquina donde se hizo la solicitud.
        /// </summary>
        [DataMember(), JsonProperty()] public string IPAddress { get; set; }
        [DataMember(), JsonProperty()] public DateTime DateUpdate { get; set; }
    }
}

