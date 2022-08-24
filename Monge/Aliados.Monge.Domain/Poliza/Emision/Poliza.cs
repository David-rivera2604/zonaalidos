using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Emision
{
    /// <summary>
    /// Coberturas a incluir en la póliza
    /// </summary>
    public class Poliza
    {
        public string Document_id { get; set; }
        public DatosGenerales Datos_Generales { get; set; }
        public DatosVariables Datos_Variables { get; set; }
        public List<Tercero> Terceros { get; set; }
        public List<Cobertura> Coberturas { get; set; }
        public DatosPais Datos_Pais { get; set; }
    }

}
