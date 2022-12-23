using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
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
        [Required()] public string document_id { get; set; }
        /// <summary>
        /// Datos generales del producto a emitir.
        /// </summary>
        [Required()] public DatosGenerales Datos_Generales { get; set; }
        /// <summary>
        /// Datos variables específicos del producto a emitir.
        /// </summary>
        [Required()] public List<DatosVariables> Datos_Variables { get; set; }
        /// <summary>
        /// Información del cliente y figuras dentro de la póliza.
        /// </summary>
        [Required()] public List<Tercero> Terceros { get; set; }
        /// <summary>
        /// Coberturas a incluir en la póliza
        /// </summary>
        [Required()] public List<Cobertura> Coberturas { get; set; }

    }

}
