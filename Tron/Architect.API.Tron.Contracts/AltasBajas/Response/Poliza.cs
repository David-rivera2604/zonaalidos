using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AltasBajas.Response
{

    enum EnumTip_Respuesta
    {
        Terminado_Correctament = 1,
        Terminado_Correctament_Retenida_ControlTecnico = 2,
        Error_Estructura = 3,
        Error_Data = 4
    }

    public class Poliza
    {
        public int ID_TIP_RESPUESTA { get; set; }
        public string NUM_POLIZA { get; set; }
        /// <summary>
        /// Fecha manejada como string en formato DD/MM/AAAA
        /// </summary>
        public string FEC_EFEC_SPTO { get; set; }
        /// <summary>
        /// Fecha manejada como string en formato DD/MM/AAAA
        /// </summary>
        public string FEC_VCTO_SPTO { get; set; }
        public List<RECIBO> RECIBOS { get; set; }
        public string COBERTURAS { get; set; }
        public string PRIMA_TOTAL { get; set; }
        public string OBSERVACION { get; set; }

        public string ERROR { get; set; }
    }

    public class RECIBO
    {
        public string NUM_RECIBO { get; set; }
        public string MONTO { get; set; }
    }

}
