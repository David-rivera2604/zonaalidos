using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AltasBajas.Request
{

    public abstract class Base
    {
        [StringLength(13)]
        public string NUM_POLIZA_GRUPO { get; set; }
        public int NUM_CONTRATO { get; set; }
        public int RAMO { get; set; }

        [StringLength(20)]
        public string COD_DOCUM_ASEG { get; set; }
        [StringLength(20)]
        public string NOM_TERCERO_ASEG { get; set; }
        [StringLength(20)]
        public string APE_TERCERO_ASEG { get; set; }
        [StringLength(1)]
        public string MCA_SEXO_ASEG { get; set; }
        [StringLength(5)]
        public string NACIONALIDAD_ASEG { get; set; }
        public int COD_ESTADO { get; set; }
        public int COD_PROVINCIA { get; set; }
        public int COD_LOCALIDAD { get; set; }
        [StringLength(180)]
        public string DOMICILIO { get; set; }
        [StringLength(30)]
        public string NUM_PRESTAMO { get; set; }
        public double IMP_SUMA_ASEG { get; set; }
        public double IMP_PRIMA_INFORMADA { get; set; }
        public int ID_CRED_ESTUDIANTE { get; set; }
        [StringLength(1)]
        public string MCA_ASISTENCIA { get; set; }
        public double IMP_SUMA_MUERTE { get; set; }

        public string COD_PLAN_AP { get; set; }
    }

}
