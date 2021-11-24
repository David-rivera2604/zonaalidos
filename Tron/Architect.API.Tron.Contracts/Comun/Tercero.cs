using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Comun
{ 
    public class tercero
    {

        /// <summary>
        /// Id.
        /// </summary>
        [DataMember(), JsonProperty()] public int tercerosId { get; set; }
        /// <summary>
        /// Tipo de tercero.
        /// </summary>
        [DataMember(), JsonProperty()] public int tipodetercero { get; set; }
        [DataMember(), JsonProperty()] public string tipodeterceroDesc { get; set; }

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
        [DataMember(), JsonProperty()] public int tercerosMca_sexo { get; set; }
        [DataMember(), JsonProperty()] public string tercerosMca_sexoDesc { get; set; }

        /// <summary>
        /// Estado Civil.
        /// </summary>
        [DataMember(), JsonProperty()] public string estadoCivil { get; set; }
        [DataMember(), JsonProperty()] public string estadoCivilDesc { get; set; }

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
        [DataMember(), JsonProperty()] public string cod_pais { get; set; }
        /// <summary>
        /// Provincia.
        /// </summary>
        [DataMember(), JsonProperty()] public int TProvincia { get; set; }
        [DataMember(), JsonProperty()] public string TProvinciaDesc { get; set; }
        /// <summary>
        /// Cantón.
        /// </summary>
        [DataMember(), JsonProperty()] public int TCanton { get; set; }
        [DataMember(), JsonProperty()] public string TCantonDesc { get; set; }

        /// <summary>
        /// Distrito.
        /// </summary>
        [DataMember(), JsonProperty()] public int TDistrito { get; set; }
        [DataMember(), JsonProperty()] public string TDistritoDesc { get; set; }
        /// <summary>
        /// Otra señas.
        /// </summary>
        [DataMember(), JsonProperty()] public string otrasenas { get; set; }
        /// <summary>
        /// El tomador es el mismo asegurado.
        /// </summary>
        [DataMember(), JsonProperty()] public int eltomadoreselmismoasegurado { get; set; }
        /// <summary>
        /// El asegurado es el conductor habitual.
        /// </summary>
        [DataMember(), JsonProperty()] public int elaseguradoeselconductorhabitual { get; set; }
        /// <summary>
        /// Número de préstamo.
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
        /// <summary>
        /// Parentesco.
        /// </summary>
        [DataMember(), JsonProperty()] public int parentesco { get; set; }
        [DataMember(), JsonProperty()] public string parentescoDesc { get; set; }
        /// <summary>
        /// Porcentaje.
        /// </summary>
        [DataMember(), JsonProperty()] public int porcentaje { get; set; }
        [DataMember(), JsonProperty()] public bool NoEditable { get; set; }

        //Numero de Riesgo
        [DataMember(), JsonProperty()] public int numeroderiesgo { get; set; } = 1;
    }

}
