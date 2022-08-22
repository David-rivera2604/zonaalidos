using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Emision
{
    /// <summary>
    /// para casos cuando un país requiera información adicional, posterior a estar integrados, esta sección servirá para pasar datos equivalentes a lo que el país solicite sin modificar la estructura definida en principio, en caso no solicitarse se enviaran vacíos.
    /// </summary>
    public class DatosPais
    {
        public string cod_etiqueta1 { get; set; }
        public string desc_etiqueta1 { get; set; }
        public string cod_etiqueta2 { get; set; }
        public string desc_etiqueta2 { get; set; }
        public string desc_generica { get; set; }
    }
}
