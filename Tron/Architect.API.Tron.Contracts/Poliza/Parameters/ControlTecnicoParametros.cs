using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Poliza.Parameters
{
    public class ControlTecnicoParametros
    {
        public int num_spto { get; set; }
        public int cod_error { get; set; }
        public string tip_autoriza { get; set; }
        public string observacion { get; set; }
        public string correo1 { get; set; }
        public string correo2 { get; set; }
    }
}
