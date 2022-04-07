
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Cotizacion
{
    public class GenericQuote
    {
        /// <summary>
        /// Moneda.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_mon { get; set; }
        /// <summary>
        /// Fraccionamiento de pago.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_fracc_pago { get; set; }
        /// <summary>
        /// Inicio de vigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime fec_efec_poliza { get; set; }
        /// <summary>
        /// Fin de vigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime fec_vcto_poliza { get; set; }

        /// <summary>
        ///  Contrato
        /// </summary>
        [DataMember(), JsonProperty()] public int num_contrato { get; set; }

        /// <summary>
        ///  Número de sub-contrato
        /// </summary>
        [DataMember(), JsonProperty()] public int num_subcontrato { get; set; }

        /// <summary>
        ///  póliza grupo
        /// </summary>
        [DataMember(), JsonProperty()] public string num_poliza_grupo { get; set; }

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
        /// Coberturas
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.Cobertura> coberturas { get; set; }
        /// <summary>
        /// Plan de pago
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.PlanDePago> plandepago { get; set; }

        /// <summary>
        /// Plan de pago proyectado por frecuencia
        /// </summary>
        [DataMember(), JsonProperty()] public List<plandepagoporfrecuencia> plandepagoporfrecuencia { get; set; }

        [DataMember(), JsonProperty()] public string Agente { get; set; }

        [DataMember(), JsonProperty()] public List<Core.Contracts.General.Error> Errors { get; set; }
    }

}