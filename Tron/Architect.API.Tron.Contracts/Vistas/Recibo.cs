using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Vistas
{
    public class Recibo
    {
        public int COD_RAMO { get; set; }
        public string NOM_RAMO { get; set; }
        public string TIP_DOCUM { get; set; }
        public string COD_DOCUM { get; set; }
        public string NOM_TERCERO { get; set; }
        public string NOM2_TERCERO { get; set; }
        public string APE1_TERCERO { get; set; }
        public string APE2_TERCERO { get; set; }
        public string EMAIL { get; set; }
        public string TXT_EMAIL { get; set; }
        public string TLF_NUMERO { get; set; }
        public string TLF_MOVIL { get; set; }
        public int COD_MON{ get; set; }
        public double IMP_RECIBO { get; set; }
        public int TIP_TARJETA { get; set; }
        public int COD_TARJETA { get; set; }
        public string NUM_TARJETA { get; set; }

    }
}
