using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AltasBajas.Request
{

    /// <summary>
    /// Datos del beneficiario en el formato requerido por el procedimiento almacenado.
    /// </summary>
    public class SPCallBeneficiario : BeneficiarioBase
    {

        /// <summary>
        /// Fecha de nacimiento del beneficiario en formato DIAMESAÑO (ejemplo: 07122004).
        /// </summary>
        public string FEC_NAC_BENEF { get; set; }

        /// <summary>
        /// Tipo de beneficiario.
        /// </summary>
        public int TIP_BENEF { get; set; }

    }

}


