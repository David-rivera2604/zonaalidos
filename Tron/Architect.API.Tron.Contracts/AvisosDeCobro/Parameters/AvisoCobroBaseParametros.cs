using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AvisosDeCobro.Parameters
{
    /// <summary>
    /// Parámetros para aviso cobros para la consulta.
    /// </summary>
    public class AvisoCobroBaseParametros
    {
        /// <summary>
        ///  Código del agente
        /// </summary>
        [Required(ErrorMessage = "Debe indicar el agent")]
        public int Cod_Agt { get; set; }
        /// <summary>
        /// Fecha desde
        /// </summary>
        [Required(ErrorMessage = "Debe indicar la fecha desde")]
        public DateTime Fec_Efec_Rec_Desde { get; set; }

        /// <summary>
        /// Fecha hasta
        /// </summary>
        [Required(ErrorMessage = "Debe indicar la fecha hasta")]
        public DateTime Fec_Efec_Rec_Hasta { get; set; }

        /// <summary>
        ///  Número póliza grupo
        /// </summary>
        [Required(ErrorMessage = "Debe indicar el número de la póliza grupo")]
        public string Num_Poliza_Grupo { get; set; }

        /// <summary>
        ///  Número de contrato
        /// </summary>
        /// <remarks>
        /// Se debe indicar cero para buscar solo por póliza grupo
        /// </remarks>
        [Required(ErrorMessage = "Debe indicar el número del contrato")]
        [DefaultValue(0)]
        public int Num_Contrato { get; set; } = 0;

        /// <summary>
        ///  Código de la moneda
        /// </summary>
        [Required(ErrorMessage = "Debe indicar el código de la moneda")]
        public int Cod_Mon { get; set; }

    }
}
