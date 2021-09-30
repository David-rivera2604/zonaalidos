using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Base
{
    /// <summary>
    /// Base de implementación para registros en la estri¿turas de polizas.
    /// </summary>
    public class Policy
    {
        /// <summary>
        /// Identificación única.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }

        /// <summary>
        /// Estado de la inclusion.
        /// </summary>
        [DataMember(), JsonProperty()] public int Status { get; set; }

        /// <summary>
        /// Descripción para estado.
        /// </summary>
        [DataMember(), JsonProperty()] public string StatusDesc { get; set; }

        /// <summary>
        /// Identificado de uso genérico.
        /// </summary>
        [DataMember(), JsonProperty()] public string Reference { get; set; }

        /// <summary>
        /// Notificación.
        /// </summary>
        [DataMember(), JsonProperty()] public string Message { get; set; }

        /// <summary>
        /// Errores reportados.
        /// </summary>
        [DataMember(), JsonProperty()] public List<Core.Contracts.General.Error> Errors { get; set; }

        /// <summary>
        /// Mode de trabajo.
        /// </summary>
        [DataMember(), JsonProperty()] public string Mode { get; set; }
    }
}
