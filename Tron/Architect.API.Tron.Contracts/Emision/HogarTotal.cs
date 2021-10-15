using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Emision
{
    public class HogarTotal: Cotizacion.HogarTotal
    {
        /// <summary>
        /// No. de póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string num_poliza { get; set; }
        /// <summary>
        /// Tipo plan.
        /// </summary>
        [DataMember(), JsonProperty()] public int tipoplan { get; set; }

        /// <summary>
        /// Número de folio.
        /// </summary>
        [DataMember(), JsonProperty()] public string numerodefolio { get; set; }
        /// <summary>
        /// Número de folio madre.
        /// </summary>
        [DataMember(), JsonProperty()] public string numerodefoliomadre { get; set; }
        /// <summary>
        /// Año de construcción.
        /// </summary>
        [DataMember(), JsonProperty()] public int anodeconstruccion { get; set; }
        /// <summary>
        /// Altura edificio.
        /// </summary>
        [DataMember(), JsonProperty()] public int alturaedificio { get; set; }
        /// <summary>
        /// Número metros construidos.
        /// </summary>
        [DataMember(), JsonProperty()] public int numerometrosconstruidos { get; set; }
        /// <summary>
        /// Número de piso.
        /// </summary>
        [DataMember(), JsonProperty()] public int numerodepiso { get; set; }


        /// <summary>
        /// Correo principal.
        /// </summary>
        [DataMember(), JsonProperty()] public string correoprincipal { get; set; }
        /// <summary>
        /// Correo copia 1.
        /// </summary>
        [DataMember(), JsonProperty()] public string correocopia1 { get; set; }
        /// <summary>
        /// Correo copia 2.
        /// </summary>
        [DataMember(), JsonProperty()] public string correocopia2 { get; set; }

        /// <summary>
        /// Terceros
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.tercero> terceros { get; set; }

        /// <summary>
        /// Documentos requeridos
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.DocumentoRequerido> documentosrequeridos { get; set; }
    }

}