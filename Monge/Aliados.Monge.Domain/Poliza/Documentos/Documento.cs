using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Documentos
{
    public class Documento
    {
        public string codigo_documento { get; set; }
        public string nombre_documento { get; set; }
        public string peso_documento { get; set; }
        public string documento_base64 { get; set; }
    }
}
