using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AvisosDeCobro
{
    /// <summary>
    /// Aviso de consulta
    /// </summary>
    public class AvisoConsultaResponse : AvisosBaseResponse
    {
        /// <summary>
        /// Total de recibos
        /// </summary>
        public double Total_Recivos { get; set; }

        /// <summary>
        /// Estatus del aviso
        /// </summary>
        public string Estatus { get; set; }
    }
}
