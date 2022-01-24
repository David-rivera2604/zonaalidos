using System;
using System.Collections.Generic;

namespace Architect.API.Tron.Contracts.Poliza.API
{
    /// <summary>
    ///  Datos fijos de la póliza (A2000030)
    /// </summary>
    public class Poliza
    {
        
        /// <summary>
        ///  Fecha de contabilización inicial
        /// </summary>
        public DateTime fec_emision { get; set; }

        /// <summary>
        ///  Póliza
        /// </summary>
        public string num_poliza { get; set; }

        /// <summary>
        ///  Presupuesto
        /// </summary>
        public string num_presupuesto { get; set; }

        /// <summary>
        ///  indica si ha ocurrido un error tratando de emitir.
        /// </summary>
        public bool error { get; set; }

        /// <summary>
        ///  En caso de falla indica la razón de la misma.
        /// </summary>
        public string razon { get; set; }


        /// <summary>
        ///  Coberturas de la póliza (A2000040)
        /// </summary>
        public List<API.Cobertura> Coberturas { get; set; }

        /// <summary>
        ///  Recibos/cuotas de una póliza (A2990700)
        /// </summary>
        public List<API.Recibo> Recibos { get; set; }

    }

}