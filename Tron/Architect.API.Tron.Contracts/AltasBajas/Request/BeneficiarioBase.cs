using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AltasBajas.Request
{

    /// <summary>
    /// Modelo base con los datos comunes de un beneficiario.
    /// </summary>
    public abstract class BeneficiarioBase
    {

        /// <summary>
        /// Número de documento del beneficiario.
        /// </summary>
        public string COD_DOCUM_BENEF { get; set; }

        /// <summary>
        /// Primer nombre del beneficiario.
        /// </summary>
        public string NOM_TERCERO_BENEF { get; set; }

        /// <summary>
        /// Segundo nombre del beneficiario.
        /// </summary>
        public string NOM2_TERCERO_BENEF { get; set; }

        /// <summary>
        /// Primer apellido del beneficiario.
        /// </summary>
        public string APE1_TERCERO_BENEF { get; set; }

        /// <summary>
        /// Segundo apellido del beneficiario.
        /// </summary>
        public string APE2_TERCERO_BENEF { get; set; }

        /// <summary>
        /// Porcentaje de participación del beneficiario.
        /// </summary>
        public int PCT_PARTICIPACION { get; set; }

        /// <summary>
        /// Tipo de relación con el asegurado.
        /// </summary>
        public int TIP_RELAC { get; set; }

        /// <summary>
        /// Sexo del beneficiario.
        /// </summary>
        public string MCA_SEXO_BENEF { get; set; }

        /// <summary>
        /// Provincia del beneficiario.
        /// </summary>
        public int PROVINCIA_BENEF { get; set; }

        /// <summary>
        /// Localidad del beneficiario.
        /// </summary>
        public int LOCALIDAD_BENEF { get; set; }

        /// <summary>
        /// Teléfono del beneficiario.
        /// </summary>
        public string TLF_NUMERO_BENEF { get; set; }

        /// <summary>
        /// Correo electrónico del beneficiario.
        /// </summary>
        public string EMAIL_BENEF { get; set; }

    }

}


