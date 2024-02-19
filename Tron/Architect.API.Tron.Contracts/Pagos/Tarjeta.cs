using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Pagos
{
    public class Tarjeta
    {

        public bool MCA_FISICO { get; set; }
        public string TIP_DOCUM { get; set; }
        public string COD_DOCUM { get; set; }
        public string NOM_TERCERO { get; set; }
        public string NOM2_TERCERO { get; set; }
        public string APE1_TERCERO { get; set; }
        public string APE2_TERCERO { get; set; }
        public string TLF_MOVIL { get; set; }
        public string TLF_NUMERO { get; set; }
        public string FAX_NUMERO { get; set; }
        public string EMAIL { get; set; }
        public string EMAIL_COM { get; set; }
        public string TXT_EMAIL { get; set; }
        public int TIP_TARJETA { get; set; }
        public string NOM_TIP_TARJETA { get; set; }
        public int COD_TARJETA { get; set; }
        public string NOM_TARJETA { get; set; }
        public string NUM_TARJETA { get; set; }
        public DateTime FEC_VCTO_TARJETA { get; set; }
    }
}
