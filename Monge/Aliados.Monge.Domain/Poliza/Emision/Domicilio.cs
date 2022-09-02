using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Emision
{
    /// <summary>
    /// Información del domicilio.
    /// </summary>
    public class Domicilio
    {
        /// <summary>
        /// Número de nivel para la información del domicilio.
        /// </summary>
        [Required()] public int nivel { get; set; }
        /// <summary>
        /// Valor asociado al nivel.
        /// </summary>
        [Required()] public string valor { get; set; }
    }
}
