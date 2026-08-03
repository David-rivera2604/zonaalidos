using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AltasBajas.Request
{

    /// <summary>
    /// Solicitud con formato de salida hacia el procedimiento almacenado de altas y bajas.
    /// </summary>
    public class SPCall: Base
    {
        /// <summary>
        /// Tipo de proceso: N para alta y A para baja.
        /// </summary>
        [StringLength(1)]
        public string TIP_DE_PROCESO { get; set; }

        /// <summary>
        /// Fecha de efecto del suplemento en formato DD/MM/AAAA.
        /// </summary>
        public string FEC_EFEC_SPTO { get; set; }

        /// <summary>
        /// Fecha de vencimiento del suplemento en formato DD/MM/AAAA.
        /// </summary>
        public string FEC_VCTO_SPTO { get; set; }

        /// <summary>
        /// Tipo de documento del asegurado.
        /// </summary>
        [StringLength(3)]
        public string TIP_DOCUM_ASEG { get; set; }

        /// <summary>
        /// Fecha de nacimiento del asegurado en formato DD/MM/AAAA.
        /// </summary>
        public string FEC_NAC_ASEG { get; set; }

        /// <summary>
        /// Fecha de inicio del préstamo en formato DD/MM/AAAA.
        /// </summary>
        public string FEC_INI_PRESTAMO { get; set; }

        /// <summary>
        /// Fecha de vencimiento del préstamo en formato DD/MM/AAAA.
        /// </summary>
        public string FEC_VCTO_PRESTAMO { get; set; }

        /// <summary>
        /// Ocupación del asegurado.
        /// </summary>
        public int OCUPACION_ASEG { get; set; }

        /// <summary>
        /// Teléfono del asegurado.
        /// </summary>
        public string TLF_NUMERO_ASEG { get; set; }

        /// <summary>
        /// Colección de beneficiarios en el formato requerido por el procedimiento almacenado.
        /// </summary>
        public List<SPCallBeneficiario> BENEFICIARIOS { get; set; }
    }
}
