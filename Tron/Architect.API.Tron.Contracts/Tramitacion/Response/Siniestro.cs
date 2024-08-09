using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Tramitacion.Response
{
    public class Siniestro
    {
        public string ID_TIP_RESPUESTA { get; set; }
        public string num_sini { get; set; }
        public string nom_exp { get; set; }
        public string nom_plan { get; set; }
        public List<Nivel> nivel { get; set; }
    }
}
