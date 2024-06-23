using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AltasBajas.Request
{

    public class SPCall: Base
    {
        [StringLength(1)]
        public string TIP_DE_PROCESO { get; set; }
        /// <summary>
        /// Fecha manejada como string en formato DD/MM/AAAA
        /// </summary>
        public string FEC_EFEC_SPTO { get; set; }
        /// <summary>
        /// Fecha manejada como string en formato DD/MM/AAAA
        /// </summary>
        public string FEC_VCTO_SPTO { get; set; }

        /// Fecha manejada como string en formato DD/MM/AAAA
        /// </summary>
        public string FEC_NAC_ASEG { get; set; }

        /// <summary>
        /// Fecha manejada como string en formato DD/MM/AAAA
        /// </summary>
        public string FEC_INI_PRESTAMO { get; set; }
        /// <summary>
        /// Fecha manejada como string en formato DD/MM/AAAA
        /// </summary>
        public string FEC_VCTO_PRESTAMO { get; set; }

    }

}
