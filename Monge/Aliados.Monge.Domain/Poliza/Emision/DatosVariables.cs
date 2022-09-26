using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Emision
{
    /// <summary>
    /// Datos variables específicos del producto a emitir
    /// </summary>
    public class DatosVariables
    {
        /// <summary>
        /// Nombre del dato o campo variable.
        /// </summary>
        [Required()] public string nombre { get; set; }
        /// <summary>
        /// Valor para el datos o campo variable.
        /// </summary>
        [Required()] public string valor { get; set; }

    }
}
