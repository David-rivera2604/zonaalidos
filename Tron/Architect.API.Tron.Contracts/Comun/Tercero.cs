using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Comun
{ 
    /// <summary>
    /// Información de terceros reclacionados a una póliza.
    /// </summary>
    public class tercero
    {
        /// <summary>
        /// Tomador de la póliza.
        /// </summary>
        public const int TOMADOR = 0;
        
        /// <summary>
        /// Asegurado de la póliza.
        /// </summary>
        public const int ASEGURADO = 2;

        /// <summary>
        /// Asegurado adicional de la póliza.
        /// </summary>
        public const int ASEGURADO_ADICIONAL = 16;

        /// <summary>
        /// Beneficiario de la póliza.
        /// </summary>
        public const int BENEFICIARIO_6 = 6;

        /// <summary>
        /// Beneficiario de la póliza.
        /// </summary>
        public const int BENEFICIARIO = 62;

        /// <summary>
        /// Id.
        /// </summary>
        [DataMember(), JsonProperty()] public int tercerosId { get; set; }
        /// <summary>
        /// Tipo de tercero.
        /// </summary>
        [DataMember(), JsonProperty()] public int tipodetercero { get; set; }
        /// <summary>
        /// Descripción del tipo de tercero.
        /// </summary>
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
        /// <summary>
        /// Descripción del sexo.
        /// </summary>
        [DataMember(), JsonProperty()] public string tercerosMca_sexoDesc { get; set; }

        /// <summary>
        /// Estado Civil.
        /// </summary>
        [DataMember(), JsonProperty()] public string estadoCivil { get; set; }
        /// <summary>
        /// Descripción del estado civil.
        /// </summary>
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
        /// <summary>
        /// Descripción de la provincia.
        /// </summary>
        [DataMember(), JsonProperty()] public string TProvinciaDesc { get; set; }
        /// <summary>
        /// Cantón.
        /// </summary>
        [DataMember(), JsonProperty()] public int TCanton { get; set; }
        /// <summary>
        /// Descripción del canton.
        /// </summary>
        [DataMember(), JsonProperty()] public string TCantonDesc { get; set; }

        /// <summary>
        /// Distrito.
        /// </summary>
        [DataMember(), JsonProperty()] public int TDistrito { get; set; }
        /// <summary>
        /// Descripción del distrito.
        /// </summary>
        [DataMember(), JsonProperty()] public string TDistritoDesc { get; set; }
        /// <summary>
        /// Otra señas.
        /// </summary>
        [DataMember(), JsonProperty()] public string otrasenas { get; set; }
        /// <summary>
        /// El tomador es el mismo asegurado.
        /// </summary>
        [DataMember(), JsonProperty()] public int eltomadoreselmismoasegurado { get; set; } = 2;
        /// <summary>
        /// El asegurado es el mismo tomador.
        /// </summary>
        [DataMember(), JsonProperty()] public int elaseguradoeselmismotomador { get; set; } = 2;
        /// <summary>
        /// El asegurado es el conductor habitual.
        /// </summary>
        [DataMember(), JsonProperty()] public int elaseguradoeselconductorhabitual { get; set; } = 2;
        /// <summary>
        /// El asegurado es el mismo pagador.
        /// </summary>
        [DataMember(), JsonProperty()] public int elaseguradoeselmismopagador { get; set; } = 2;
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
        /// <summary>
        /// Descripción del parentesco.
        /// </summary>
        [DataMember(), JsonProperty()] public string parentescoDesc { get; set; }
        /// <summary>
        /// Porcentaje.
        /// </summary>
        [DataMember(), JsonProperty()] public int porcentaje { get; set; }
        /// <summary>
        /// Indica que el tercero no es editable.
        /// </summary>
        [DataMember(), JsonProperty()] public bool NoEditable { get; set; }

        /// <summary>
        /// Numero de Riesgo
        /// </summary>
        [DataMember(), JsonProperty()] public int numeroderiesgo { get; set; } = 1;

        /// <summary>
        /// El beneficiario es el mismo para todos los riesgos
        /// </summary>
        [DataMember(), JsonProperty()] public int elbeneficiarioeselmismotodoslosriesgos { get; set; } = 2;

        /// <summary>
        /// Indica que la dirección actual sera usada por la dirección por default.
        /// </summary>
        [DataMember(), JsonProperty()] public bool reutilizarestadireccion { get; set; }
    }

}
