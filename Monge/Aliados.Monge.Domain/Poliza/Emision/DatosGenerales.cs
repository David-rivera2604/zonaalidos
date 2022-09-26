using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Emision
{
    /// <summary>
    /// Datos generales del producto a emitir
    /// </summary>
    public class DatosGenerales
    {

        /// <summary>
        /// Código de país a quien va dirigida la solicitud. Lista de valores: ISO 3166-1 alfa-2, sistema de códigos de dos letras.
        /// </summary>
        [Required()] public string pais { get; set; }
        /// <summary>
        /// Código del producto usando para emitir la póliza. Lista de valores: 441-EF SEGUR VIAJE ESTUDIO FAMILIAR, 441-EI SEGUR VIAJE ESTUDIO INDIVIDUAL, 441-ET SEGUR VIAJE ESTUDIO TERCERO, 441-NF SEGUR VIAJE NACIONAL FAMILIAR, 441-NI SEGUR VIAJE NACIONAL INDIVIDUAL, 441-NT SEGUR VIAJE NACIONAL TERCERO, 441-PF SEGUR VIAJE PLACER FAMILIAR, 441-PI SEGUR VIAJE PLACER INDIVIDUAL, 441-PT SEGUR VIAJE PLACER TERCERO, 441-RF SEGUR VIAJE RECEPTIVO FAMILIAR, 441-RI SEGUR VIAJE RECEPTIVO INDIVIDUAL, 441-RT SEGUR VIAJE RECEPTIVO TERCERO
        /// </summary>
        [Required()] public string cod_producto { get; set; }
        /// <summary>
        ///  Moneda. Lista de valores: 2 DOLARES
        /// </summary>
        [Required()] public int moneda { get; set; }
        /// <summary>
        ///  Plan de pago. Lista de valores: 101 PLAN DE PAGO ANUAL
        /// </summary>
        [Required()] public int cod_fracc_pago { get; set; }
        /// <summary>
        ///  Efecto de la póliza.
        /// </summary>
        [Required()] public DateTime fec_efec_poliza { get; set; }
        /// <summary>
        ///  Vencimiento de la póliza.
        /// </summary>
        [Required()] public DateTime fec_vcto_poliza { get; set; }
        /// <summary>
        ///  Modalidad de vida. Lista de valores: 44110 BRONCE, 44111 BRONCE PLUS, 44113 GOLD PLUS, 44114 PLATINUM PLUS, 44115 PREMIUM, 44112 SILVER PLUS
        /// </summary>
        [Required()] public int cod_modalidad { get; set; }
        /// <summary>
        /// Número de la factura.
        /// </summary>
        public string numero_factura { get; set; }
        /// <summary>
        /// Nombre del vendedor.
        /// </summary>
        public string nombre_vendedor { get; set; }
        /// <summary>
        /// Identificación del vendedor.
        /// </summary>
        public string identificacion_vendedor { get; set; }
        /// <summary>
        /// Información de la tienda.
        /// </summary>
        public Tienda tienda { get; set; }
    }
}
