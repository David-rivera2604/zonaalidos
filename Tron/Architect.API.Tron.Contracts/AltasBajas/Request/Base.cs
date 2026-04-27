using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AltasBajas.Request
{

    /// <summary>
    /// Modelo base con los datos comunes requeridos para solicitudes de altas y bajas de póliza.
    /// </summary>
    public abstract class Base
    {
        /// <summary>
        /// Número de póliza de grupo.
        /// </summary>
        [StringLength(13)]
        public string NUM_POLIZA_GRUPO { get; set; }

        /// <summary>
        /// Número de contrato asociado.
        /// </summary>
        public int NUM_CONTRATO { get; set; }

        /// <summary>
        /// Código del ramo.
        /// </summary>
        public int RAMO { get; set; }

        /// <summary>
        /// Número de documento del asegurado.
        /// </summary>
        [StringLength(20)]
        public string COD_DOCUM_ASEG { get; set; }

        /// <summary>
        /// Nombre del asegurado.
        /// </summary>
        [StringLength(20)]
        public string NOM_TERCERO_ASEG { get; set; }

        /// <summary>
        /// Apellido del asegurado.
        /// </summary>
        [StringLength(20)]
        public string APE_TERCERO_ASEG { get; set; }

        /// <summary>
        /// Sexo del asegurado.
        /// </summary>
        [StringLength(1)]
        public string MCA_SEXO_ASEG { get; set; }

        /// <summary>
        /// Nacionalidad del asegurado.
        /// </summary>
        [StringLength(5)]
        public string NACIONALIDAD_ASEG { get; set; }

        /// <summary>
        /// Código de estado o provincia.
        /// </summary>
        public int COD_ESTADO { get; set; }

        /// <summary>
        /// Código de provincia.
        /// </summary>
        public int COD_PROVINCIA { get; set; }

        /// <summary>
        /// Código de localidad.
        /// </summary>
        public int COD_LOCALIDAD { get; set; }

        /// <summary>
        /// Dirección del asegurado.
        /// </summary>
        [StringLength(180)]
        public string DOMICILIO { get; set; }

        /// <summary>
        /// Número de préstamo.
        /// </summary>
        [StringLength(30)]
        public string NUM_PRESTAMO { get; set; }

        /// <summary>
        /// Monto de suma asegurada.
        /// </summary>
        public double IMP_SUMA_ASEG { get; set; }

        /// <summary>
        /// Monto de suma asegurada para VC.
        /// </summary>
        public double IMP_SUM_ASEG_VC { get; set; }

        /// <summary>
        /// Monto de prima informada.
        /// </summary>
        public double IMP_PRIMA_INFORMADA { get; set; }

        /// <summary>
        /// Monto de prima facturada.
        /// </summary>
        public Nullable<double> IMP_PRIMA_FACT { get; set; }

        /// <summary>
        /// Identificador del crédito estudiantil.
        /// </summary>
        public int ID_CRED_ESTUDIANTE { get; set; }

        /// <summary>
        /// Indicador de asistencia.
        /// </summary>
        [StringLength(1)]
        public string MCA_ASISTENCIA { get; set; }

        /// <summary>
        /// Monto de suma por muerte.
        /// </summary>
        public double IMP_SUMA_MUERTE { get; set; }

        /// <summary>
        /// Código del plan AP.
        /// </summary>
        public string COD_PLAN_AP { get; set; }
    }

}
