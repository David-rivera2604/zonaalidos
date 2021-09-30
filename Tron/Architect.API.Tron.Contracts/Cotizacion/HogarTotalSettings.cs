using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Cotizacion
{
    public class HogarTotalSettings
    {
        [DataMember(), JsonProperty()] public CuadroComisiones CuadroComisionesColones{ get; set; }

        /// <summary>
        ///  Cuadro de comisiones
        /// </summary>
        [DataMember(), JsonProperty()] public CuadroComisiones CuadroComisionesDolares { get; set; }

    }

    public class CuadroComisiones
    {

        /// <summary>
        ///  Agente
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_agt { get; set; }

        /// <summary>
        ///  Cuadro de comisiones
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_cuadro_com { get; set; }

    }

}