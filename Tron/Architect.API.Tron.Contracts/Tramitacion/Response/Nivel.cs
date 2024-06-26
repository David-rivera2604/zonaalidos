using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Tramitacion.Response
{    
    public class Nivel
    {
        public string nom_nivel { get; set; }
        public List<Tramite> tramite { get; set; }
    }

}
