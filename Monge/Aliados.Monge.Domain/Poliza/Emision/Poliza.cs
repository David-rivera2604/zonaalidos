using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Emision
{
    /// <summary>
    /// Datos necesario para la emisión de una póliza
    /// </summary>
    public class Poliza
    {
        /// <summary>
        /// Identificador único de la solicitud.
        /// </summary>
        public string document_id { get; set; }
        /// <summary>
        /// Datos generales del producto a emitir.
        /// </summary>
        public DatosGenerales Datos_Generales { get; set; }
        /// <summary>
        /// Datos variables específicos del producto a emitir.
        /// </summary>
        public DatosVariables Datos_Variables { get; set; }
        /// <summary>
        /// Información del cliente y figuras dentro de la póliza.
        /// </summary>
        public List<Tercero> Terceros { get; set; }
        /// <summary>
        /// Coberturas a incluir en la póliza
        /// </summary>
        public List<Cobertura> Coberturas { get; set; }
        /// <summary>
        /// Información adicional particulares de una país.
        /// </summary>
        public List<DatosPais> Datos_Pais { get; set; }
    }

}
