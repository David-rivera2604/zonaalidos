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
        /// Identificador NUMBER(9) de la solicitud guardada que se actualizará o procesará.
        /// </summary>
        public int? ProposalId { get; set; }

        /// <summary>
        /// Texto visible del ramo seleccionado, conservado en la solicitud para impresión.
        /// </summary>
        public string RAMODesc { get; set; }

        /// <summary>
        /// Texto visible del tipo de documento del asegurado.
        /// </summary>
        public string COD_DOCUM_ASEGTypeDesc { get; set; }

        /// <summary>
        /// Texto visible del sexo del asegurado.
        /// </summary>
        public string MCA_SEXO_ASEGDesc { get; set; }

        /// <summary>
        /// Texto visible de la ocupación del asegurado.
        /// </summary>
        public string OCUPACION_ASEGDesc { get; set; }

        /// <summary>
        /// Texto visible de la nacionalidad del asegurado.
        /// </summary>
        public string NACIONALIDAD_ASEGDesc { get; set; }

        /// <summary>
        /// Texto visible de la provincia del asegurado.
        /// </summary>
        public string COD_ESTADODesc { get; set; }

        /// <summary>
        /// Texto visible del cantón del asegurado.
        /// </summary>
        public string COD_PROVINCIADesc { get; set; }

        /// <summary>
        /// Texto visible del distrito del asegurado.
        /// </summary>
        public string COD_LOCALIDADDesc { get; set; }

        /// <summary>
        /// Texto visible del factor de prima cuando se selecciona desde un catálogo.
        /// </summary>
        public string IMP_PRIMA_FACTDesc { get; set; }

        /// <summary>
        /// Texto visible de la opción de asistencia seleccionada.
        /// </summary>
        public string MCA_ASISTENCIADesc { get; set; }

        /// <summary>
        /// Texto visible del plan de accidentes personales seleccionado.
        /// </summary>
        public string COD_PLAN_APDesc { get; set; }

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

        /// <summary>
        /// Modo de operación: Draft, SendLink, SendSignature, Complete o Issue.
        /// </summary>
        public string modo { get; set; } 

    }
}


