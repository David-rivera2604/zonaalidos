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
        [DataMember(), JsonProperty()] public List<MultirriesgoDocumentosrequeridos> documentosrequeridos { get; set; }
    }

    public class MultirriesgoTerceros
    {

        /// <summary>
        /// Id.
        /// </summary>
        [DataMember(), JsonProperty()] public int tercerosId { get; set; }
        /// <summary>
        /// Tipo de tercero.
        /// </summary>
        [DataMember(), JsonProperty()] public int tipodetercero { get; set; }
        /// <summary>
        /// Tipo de identificación.
        /// </summary>
        [DataMember(), JsonProperty()] public int DocumentNumberType { get; set; }
        /// <summary>
        /// Identificación.
        /// </summary>
        [DataMember(), JsonProperty()] public string DocumentNumber { get; set; }
        /// <summary>
        /// Nombre.
        /// </summary>
        [DataMember(), JsonProperty()] public string nombre { get; set; }
        /// <summary>
        /// Apellido 1.
        /// </summary>
        [DataMember(), JsonProperty()] public string apellido1 { get; set; }
        /// <summary>
        /// Apellido 2.
        /// </summary>
        [DataMember(), JsonProperty()] public string apellido2 { get; set; }
        /// <summary>
        /// Fecha de nacimiento.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime fechadenacimiento { get; set; }
        /// <summary>
        /// Sexo.
        /// </summary>
        [DataMember(), JsonProperty()] public int mca_sexo { get; set; }
        /// <summary>
        /// Estado Civil.
        /// </summary>
        [DataMember(), JsonProperty()] public string estadoCivil { get; set; }
        /// <summary>
        /// Número de teléfono.
        /// </summary>
        [DataMember(), JsonProperty()] public string numerodetelefono { get; set; }
        /// <summary>
        /// Correo electrónico.
        /// </summary>
        [DataMember(), JsonProperty()] public string correoelectronico { get; set; }
        /// <summary>
        /// País.
        /// </summary>
        [DataMember(), JsonProperty()] public string tercerosCod_pais { get; set; }
        /// <summary>
        /// Provincia.
        /// </summary>
        [DataMember(), JsonProperty()] public int TProvincia { get; set; }
        /// <summary>
        /// Cantón.
        /// </summary>
        [DataMember(), JsonProperty()] public int TCanton { get; set; }
        /// <summary>
        /// Distrito.
        /// </summary>
        [DataMember(), JsonProperty()] public int TDistrito { get; set; }
        /// <summary>
        /// Otra señas.
        /// </summary>
        [DataMember(), JsonProperty()] public string otrasenas { get; set; }
        /// <summary>
        /// El tomador es el mismo asegurado.
        /// </summary>
        [DataMember(), JsonProperty()] public int eltomadoreselmismoasegurado { get; set; }
        /// <summary>
        /// Número de prestamo.
        /// </summary>
        [DataMember(), JsonProperty()] public string numerodeprestamo { get; set; }
        /// <summary>
        /// Importe de cesión.
        /// </summary>
        [DataMember(), JsonProperty()] public double importedecesion { get; set; }
        /// <summary>
        /// Vencimiento de cesión.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime vencimientodecesion { get; set; }
        /// <summary>
        /// Porcentaje acredor.
        /// </summary>
        [DataMember(), JsonProperty()] public int porcentajeacredor { get; set; }


    }
    public class MultirriesgoDocumentosrequeridos
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
        /// Archivoeseperado.
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
