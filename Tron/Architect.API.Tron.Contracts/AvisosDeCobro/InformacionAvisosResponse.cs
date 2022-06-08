using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AvisosDeCobro
{
    /// <summary>
    /// Información de avisos
    /// </summary>
    public class InformacionAvisosResponse
    {

        /// <summary>
        /// Avisos
        /// </summary>
        public List<AvisoConsultaResponse> Avisos { get; set; }


        /// <summary>
        /// Recibos aviso
        /// </summary>
        public List<ReciboAvisoRespose> RecibosAviso { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> Errors { get; set; }
    }
}
