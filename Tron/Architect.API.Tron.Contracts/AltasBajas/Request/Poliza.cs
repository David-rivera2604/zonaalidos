using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AltasBajas.Request
{

    public class Poliza : Base
    {
        public DateTime EFEC_SPTO { get; set; }
        public DateTime VCTO_SPTO { get; set; }
        public string COD_DOCUM_ASEGType { get; set; }
        public DateTime NAC_ASEG { get; set; }
        public DateTime INI_PRESTAMO { get; set; }
        public DateTime VCTO_PRESTAMO { get; set; }

    }
}


