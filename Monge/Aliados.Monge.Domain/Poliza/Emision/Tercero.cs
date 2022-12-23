using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Emision
{
    /// <summary>
    /// Información del cliente y figuras dentro de la póliza
    /// </summary>
    public class Tercero
    {
        /// <summary>
        /// Tipo de tercero. Lista de valores: 0 Tomador(a), 2 Asegurado(a), 6 Beneficiario(a), 8 Acreedor(a)
        /// </summary>
        [Required()] public int tipodetercero { get; set; }
        /// <summary>
        /// Número de Riesgo
        /// </summary>
        [Required()] public int numeroderiesgo { get; set; }
        /// <summary>
        /// Tipo de identificación. Lista de valores: 1	Cédula, 2 DIMEX, 3 Pasaporte, 4 Cédula jurídica
        /// </summary>
        [Required()] public int tipoDocumentacion { get; set; }
        /// <summary>
        /// Identificación.
        /// </summary>
        [Required()] public string numeroDocumentacion { get; set; }
        public string DocumentacionTributaria { get; set; }
        /// <summary>
        /// Nombre.
        /// </summary>
        [Required()] public string nombre { get; set; }
        /// <summary>
        /// Pimer apellido.
        /// </summary>
        [Required()] public string apellido1 { get; set; }
        /// <summary>
        /// Segundo apellido.
        /// </summary>
        public string apellido2 { get; set; }
        /// <summary>
        /// Fecha de nacimiento.
        /// </summary>
        [Required()] public DateTime fechadenacimiento { get; set; }
        /// <summary>
        /// Sexo. Lista de valores: 0 Femenino, 1 Masculino
        /// </summary>
        [Required()] public string tercerosMca_sexo { get; set; }
        /// <summary>
        /// Estado Civil. Lista de valores: C Casado(a), D Divorciado(a), S Soltero(a), CL Unión Libre, V Viudo(a)
        /// </summary>
        public string estadoCivil { get; set; }
        /// <summary>
        /// Número de teléfono.
        /// </summary>
        public string numerodetelefono { get; set; }
        /// <summary>
        /// Correo electrónico.
        /// </summary>
        public string correoelectronico { get; set; }
         /// <summary>
        /// Número de préstamo.
        /// </summary>
        public string numerodeprestamo { get; set; }
        /// <summary>
        /// Importe de cesión.
        /// </summary>
        public int importedecesion { get; set; }
        /// <summary>
        /// Vencimiento de cesión.
        /// </summary>
        public DateTime vencimientodecesion { get; set; }
        /// <summary>
        /// Porcentaje acredor.
        /// </summary>
        public int porcentajeacredor { get; set; }
        /// <summary>
        /// Parentesco. Lista de valores: 1 Padre, 2 Madre, 3 Hijo(a), 4 Amigo(a), 5 Cuñado(a), 6 Sobrino(a), 7 Hermano(a), 8 Primo(a), 9 Conyugue, 11 Otro, 10 Asegurado principal, 12 Tío(a)
        /// </summary>
        public string parentesco { get; set; }
        /// <summary>
        /// Porcentaje.
        /// </summary>
        public int porcentaje { get; set; }
        /// <summary>
        /// Información del domicilio.
        /// </summary>
        [Required()] public List<Domicilio> domicilio { get; set; }
    }
}
