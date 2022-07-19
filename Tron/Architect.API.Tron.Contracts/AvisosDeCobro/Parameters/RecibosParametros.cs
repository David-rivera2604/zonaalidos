using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Architect.API.Tron.Contracts.AvisosDeCobro.Parameters
{
    /// <summary>
    /// Parámetros la consulta recibos para incluir en aviso de cobro
    /// </summary>
    public class RecibosParametros : AvisoCobroBaseParametros
    {
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
