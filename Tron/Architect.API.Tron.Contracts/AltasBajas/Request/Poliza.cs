using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AltasBajas.Request
{

    /// <summary>
    /// Solicitud de alta o baja de póliza con tipos de datos de entrada del API.
    /// </summary>
    public class Poliza : Base
    {
        /// <summary>
        /// Fecha de efecto del suplemento.
        /// </summary>
        public DateTime EFEC_SPTO { get; set; }

        /// <summary>
        /// Fecha de vencimiento del suplemento.
        /// </summary>
        public DateTime VCTO_SPTO { get; set; }

        /// <summary>
        /// Tipo de documento del asegurado.
        /// </summary>
        public string COD_DOCUM_ASEGType { get; set; }

        /// <summary>
        /// Fecha de nacimiento del asegurado.
        /// </summary>
        public DateTime NAC_ASEG { get; set; }

        /// <summary>
        /// Fecha de inicio del préstamo.
        /// </summary>
        public DateTime INI_PRESTAMO { get; set; }

        /// <summary>
        /// Fecha de vencimiento del préstamo.
        /// </summary>
        public DateTime VCTO_PRESTAMO { get; set; }

        /// <summary>
        /// Ocupación del asegurado.
        /// </summary>
        public int OCUPACION_ASEG { get; set; }

        /// <summary>
        /// Teléfono del asegurado.
        /// </summary>
        public string TLF_NUMERO_ASEG { get; set; }

        /// <summary>
        /// Colección de beneficiarios de la solicitud.
        /// </summary>
        public List<Beneficiario> Beneficiarios { get; set; }
    }
}


