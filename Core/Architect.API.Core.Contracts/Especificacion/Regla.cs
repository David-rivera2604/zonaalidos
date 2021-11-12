using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Contracts.Especificacion
{
    public class Regla
    {
        public int? Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Condicion { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
        public string Grupo { get; set; } = string.Empty;
        public string Campo { get; set; } = string.Empty;

    }
}
