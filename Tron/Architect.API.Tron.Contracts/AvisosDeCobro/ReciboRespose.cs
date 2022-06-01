using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AvisosDeCobro
{
    /// <summary>
    /// Recibo
    /// </summary>
    public class ReciboRespose
    {
        /// <summary>
        /// Total del recibo
        /// </summary>
        public double Imp_Recibo { get; set; }

        /// <summary>
        /// Recibo.
        /// </summary>
        public int Num_Recibo { get; set; }

        /// <summary>
        /// Efecto del recibo
        /// </summary>
        public DateTime Fec_Efec_Recibo { get; set; }

        /// <summary>
        /// Estatus
        /// </summary>
        public string Estatus { get; set; }

        /// <summary>
        /// Descripción del riesgo
        /// </summary>
        public string Nom_Riesgo { get; set; }


        /// <summary>
        /// Tipo de documento del asegurado
        /// </summary>
        public string Tip_Docum_Aseg { get; set; }

        /// <summary>
        /// Documento del asegurado
        /// </summary>
        public string Cod_Docum_Aseg { get; set; }

        /// <summary>
        /// Nombre del asegurado
        /// </summary>
        public string Nom_Asegurado { get; set; }

        /// <summary>
        /// Póliza
        /// </summary>
        public string Num_Poliza { get; set; }

        /// <summary>
        /// Moneda
        /// </summary>
        public int Cod_Mon { get; set; }
    }
}
