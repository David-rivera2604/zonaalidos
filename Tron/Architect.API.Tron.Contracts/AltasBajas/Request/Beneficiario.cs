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
        /// Texto visible del tipo de documento del beneficiario.
        /// </summary>
        public string COD_DOCUM_BENEFTypeDesc { get; set; }

        /// <summary>
        /// Texto visible del sexo del beneficiario.
        /// </summary>
        public string MCA_SEXO_BENEFDesc { get; set; }

        /// <summary>
        /// Texto visible del parentesco del beneficiario.
        /// </summary>
        public string TIP_RELACDesc { get; set; }

        /// <summary>
        /// Texto visible de la provincia del beneficiario.
        /// </summary>
        public string ESTADO_BENEFDesc { get; set; }

        /// <summary>
        /// Texto visible del cantón del beneficiario.
        /// </summary>
        public string PROVINCIA_BENEFDesc { get; set; }

        /// <summary>
        /// Texto visible del distrito del beneficiario.
        /// </summary>
        public string LOCALIDAD_BENEFDesc { get; set; }

        /// <summary>
        /// Fecha de nacimiento del beneficiario.
        /// </summary>
        public DateTime FEC_NAC_BENEF { get; set; }

        /// <summary>
        /// Tipo de documento del beneficiario.
        /// </summary>
        public string COD_DOCUM_BENEFType { get; set; }

        /// <summary>
        /// Código de la provincia del beneficiario, requerido para cargar sus cantones y distritos.
        /// </summary>
        public int ESTADO_BENEF { get; set; }
    }

}


