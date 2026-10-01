using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Comun
{
    /// <summary>
    /// Información del documento requerido
    /// </summary>
    public class DocumentoRequerido
    {

        /// <summary>
        /// Id.
        /// </summary>
        [DataMember(), JsonProperty()] public int documentosrequeridosId { get; set; }
        /// <summary>
        /// Estado.
        /// </summary>
        [DataMember(), JsonProperty()] public string DStored { get; set; }
        /// <summary>
        /// Tipo de documento.
        /// </summary>
        [DataMember(), JsonProperty()] public string tipo { get; set; }
        /// <summary>
        /// Archivo.
        /// </summary>
        [DataMember(), JsonProperty()] public string DNombre { get; set; }
        /// <summary>
        /// Archivo separado.
        /// </summary>
        [DataMember(), JsonProperty()] public string DArchivoEsperado { get; set; }
        /// <summary>
        /// Grupo.
        /// </summary>
        [DataMember(), JsonProperty()] public string Grupo { get; set; }
        /// <summary>
        /// Fecha.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime DFecha { get; set; }
        /// <summary>
        /// Tamaño.
        /// </summary>
        [DataMember(), JsonProperty()] public int DTamano { get; set; }
        /// <summary>
        /// Descripción del documento.
        /// </summary>
        [DataMember(), JsonProperty()] public string DDescripcion { get; set; }

    }

}
