using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Emision
{
    public class Viajero : Cotizacion.Viajero
    {
        /// <summary>
        /// No. de póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string num_poliza { get; set; }
        /// <summary>
        /// envio_asistencia Panama.
        /// </summary>
        [DataMember(), JsonProperty()] public string envio_asistencia { get; set; }
        /// <summary>
        /// <summary>
        /// Numero de Riesgo.
        /// </summary>
        [DataMember(), JsonProperty()] public int num_riesgo { get; set; }
        /// Terceros
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.tercero> terceros { get; set; }

        /// <summary>
        /// Documentos requeridos
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.DocumentoRequerido> documentosrequeridos { get; set; }


    }
  

}


