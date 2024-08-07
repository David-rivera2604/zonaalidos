
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Cotizacion
{
    public class Quote
    {
        /// <summary>
        /// Ramo.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_ramo { get; set; }

        /// <summary>
        /// Mensajes o notificaciones.
        /// </summary>
        [DataMember(), JsonProperty()] public string Mensaje { get; set; }

        /// <summary>
        /// Detalle de un error.
        /// </summary>
        [DataMember(), JsonProperty()] public string Error { get; set; }

        /// <summary>
        /// No. de presupuesto.
        /// </summary>
        [DataMember(), JsonProperty()] public string presupuesto { get; set; }

        /// <summary>
        /// Resumen de la cotización
        /// </summary>
        [DataMember(), JsonProperty()] public resumen resumen { get; set; }

        /// <summary>
        /// Plan de pago proyectado por frecuencia
        /// </summary>
        [DataMember(), JsonProperty()] public List<plandepagoporfrecuencia> plandepagoporfrecuencia { get; set; }

        [DataMember(), JsonProperty()] public string Agente { get; set; }

        [DataMember(), JsonProperty()] public int cod_agt { get; set; }

        [DataMember(), JsonProperty()] public int cod_cuadro_com { get; set; }


        [DataMember(), JsonProperty()] public List<Core.Contracts.General.Error> Errors { get; set; }
    }

}