using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Cancelacion
{

    public class SolicitudDeCancelacion
    {
        public string document_id { get; set; }
        public string codigo_causa { get; set; }
        public string descripcion_causa { get; set; }
        public string nombre_vendedor { get; set; }
        public string identificacion_vendedor { get; set; }
        public string num_poliza { get; set; }
    }

}
