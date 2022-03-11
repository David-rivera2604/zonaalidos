using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Core.Contracts.Especificacion
{
    /// <summary>
    /// Permite definir el comportamiento de un producto de TRON para la cotización y emisión 
    /// </summary>
    public class Producto
    {

        public List<Regla> Reglas { get; set; }

    }
}
