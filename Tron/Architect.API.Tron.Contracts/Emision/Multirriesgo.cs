using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Architect.API.Tron.Contracts.Emision
{
    public class Multirriesgo : Cotizacion.Multirriesgo
    {
        /// <summary>
        /// No. de póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string num_poliza { get; set; }

        /// <summary>
        /// Año de construcción.
        /// </summary>
        [DataMember(), JsonProperty()] public int anodeconstruccion { get; set; }

        /// <summary>
        /// Terceros.
        /// </summary>
        [DataMember(), JsonProperty()] public List<MultirriesgoTerceros> terceros { get; set; }
        /// <summary>
        /// Documentos requeridos.
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.DocumentoRequerido> documentosrequeridos { get; set; }
    }

    public class MultirriesgoTerceros : Comun.tercero
    {


        /// <summary>
        /// Sexo.
        /// </summary>
        [DataMember(), JsonProperty()] public int mca_sexo { get; set; }
      
        /// <summary>
        /// País.
        /// </summary>
        [DataMember(), JsonProperty()] public string tercerosCod_pais { get; set; }
      


    }

}
