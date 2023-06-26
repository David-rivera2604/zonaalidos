using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Cotizacion
{
    public class Viajero : GenericQuote
    {
        /// <summary>
        /// Plan.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_PLAN { get; set; }
        [DataMember(), JsonProperty()] public string TIP_PLAN_DESC { get; set; }
        /// <summary>
        /// Tipo de viaje.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_VIAJE { get; set; }
        [DataMember(), JsonProperty()] public string TIP_VIAJE_DESC { get; set; }
        /// <summary>
        /// Fecha de inicio del viaje.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_VIAJE { get; set; }
        /// <summary>
        /// Lugar de destino.
        /// </summary>
        [DataMember(), JsonProperty()] public string DES_DESTINO { get; set; }
        [DataMember(), JsonProperty()] public string DES_DESTINO_DESC { get; set; }
        /// <summary>
        /// Pais Procedencia.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_PAIS_ORIGEN { get; set; } = "CRI";
        [DataMember(), JsonProperty()] public string PAIS_ORIGEN_DESC { get; set; } = "COSTA RICA";
        /// <summary>
        /// Fecha de nacimiento.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_NACIMIENTO { get; set; }
        [DataMember(), JsonProperty()] public DateTime FEC_NACIMIENTO2 { get; set; }
        [DataMember(), JsonProperty()] public DateTime FEC_NACIMIENTO3 { get; set; }
        [DataMember(), JsonProperty()] public DateTime FEC_NACIMIENTO4 { get; set; }
        [DataMember(), JsonProperty()] public DateTime FEC_NACIMIENTO5 { get; set; }
        [DataMember(), JsonProperty()] public DateTime FEC_NACIMIENTO6 { get; set; }
        [DataMember(), JsonProperty()] public DateTime FEC_NACIMIENTO7 { get; set; }
        [DataMember(), JsonProperty()] public DateTime FEC_NACIMIENTO8 { get; set; }
        [DataMember(), JsonProperty()] public DateTime FEC_NACIMIENTO9 { get; set; }
        [DataMember(), JsonProperty()] public DateTime FEC_NACIMIENTO10 { get; set; }

        /// <summary>
        /// Modalidad.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_MODALIDAD { get; set; }
        [DataMember(), JsonProperty()] public string COD_MODALIDAD_DES { get; set; }
        /// <summary>
        /// Cantidad Riesgos.
        /// </summary>
        [DataMember(), JsonProperty()] public int cantidad_riesgos { get; set; }

    }

}
