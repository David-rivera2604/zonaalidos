using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Architect.API.Tron.Contracts.AvisosDeCobro.Parameters
{
    /// <summary>
    /// Parámetros la consulta recibos para incluir en aviso de cobro
    /// </summary>
    public class RecibosParametros
    {
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

        /// <summary>
        ///  Tipo de documento del tomador
        /// </summary>
        public string Tip_Docum { get; set; }

        /// <summary>
        ///  Documento del tomador
        /// </summary>
        public string Cod_Docum { get; set; }

        /// <summary>
        ///  Tipo de fraccionamiento
        /// </summary>
        public Nullable<int> Cod_Fracc_Pago { get; set; }

        /// <summary>
        /// Tipo de documento del acreedor
        /// </summary>
        public string Tip_Docum_Acreedor { get; set; }

        /// <summary>
        /// Documento del acreedor
        /// </summary>
        public string Cod_Docum_Acreedor { get; set; }
    }

}
