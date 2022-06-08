using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AvisosDeCobro.Parameters
{
    /// <summary>
    /// Parámetros para aviso cobros para la consulta.
    /// </summary>
    public class AvisoCobroConsultaParametros : AvisoCobroBaseParametros
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
