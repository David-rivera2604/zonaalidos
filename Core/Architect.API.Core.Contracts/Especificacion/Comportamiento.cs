using System;
using System.Linq;

namespace Architect.API.Core.Contracts.Especificacion
{
    public class Comportamiento
    {
        public string Descripcion { get; set; } = string.Empty;
        public string Condicion { get; set; } = string.Empty;
        public string Accion { get; set; } = string.Empty;
    }
}
