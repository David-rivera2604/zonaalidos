using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AltasBajas.Request
{

    /// <summary>
    /// Datos del beneficiario para solicitudes de altas y bajas.
    /// </summary>
    public class Beneficiario : BeneficiarioBase
    {
        /// <summary>
        /// Fecha de nacimiento del beneficiario.
        /// </summary>
        public DateTime FEC_NAC_BENEF { get; set; }

    }

}


