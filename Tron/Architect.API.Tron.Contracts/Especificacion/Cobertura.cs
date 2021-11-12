using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Especificacion
{
    public class Cobertura
    {
        public int? Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Condicion { get; set; } = string.Empty;
        public string Exclusion { get; set; } = string.Empty;
    }
}
