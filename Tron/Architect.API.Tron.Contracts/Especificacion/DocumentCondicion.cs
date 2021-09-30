using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Especificacion
{
    public class DocumentCondicion
    {
        public string Role { get; set; } = string.Empty;

        public string Condicion { get; set; } = string.Empty;

        public List<Documento> Detalles { get; set; }
    }
}
