
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
        /// Moneda.
        /// </summary>

        /// <summary>
        /// Mansajes o notificaciones.
        /// </summary>
        [DataMember(), JsonProperty()] public string Mensaje { get; set; }

        /// <summary>
        /// Mansajes o notificaciones.
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

        [DataMember(), JsonProperty()] public List<Core.Contracts.General.Error> Errors { get; set; }
    }

    public class resumen
    {
        /// <summary>
        /// Prima neta.
        /// </summary>
        [DataMember(), JsonProperty()] public double primaneta { get; set; }
        /// <summary>
        /// IVA.
        /// </summary>
        [DataMember(), JsonProperty()] public double iVA { get; set; }
        /// <summary>
        /// Recardo por fraccionamiento.
        /// </summary>
        [DataMember(), JsonProperty()] public double recardoporfraccionamiento { get; set; }
        /// <summary>
        /// Importe total.
        /// </summary>
        [DataMember(), JsonProperty()] public double importetotal { get; set; }
        /// <summary>
        /// Cuota.
        /// </summary>
        [DataMember(), JsonProperty()] public int cuotas { get; set; }
    }
}