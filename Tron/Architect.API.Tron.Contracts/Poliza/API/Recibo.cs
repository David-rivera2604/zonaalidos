using System;

namespace Architect.API.Tron.Contracts.Poliza.API
{
    /// <summary>
    ///  Recibos/cuotas de una póliza (A2990700)
    /// </summary>
    public class Recibo
    {

        /// <summary>
        ///  Cuota
        /// </summary>
        public int num_cuota { get; set; }

        /// <summary>
        ///  Recibo
        /// </summary>
        public int num_recibo { get; set; }

        /// <summary>
        ///  Efecto del recibo
        /// </summary>
        public DateTime fec_efec_recibo { get; set; }

        /// <summary>
        ///  Vencimiento del recibo
        /// </summary>
        public DateTime fec_vcto_recibo { get; set; }

        /// <summary>
        ///  Total del recibo
        /// </summary>
        public double imp_recibo { get; set; }

        /// <summary>
        ///  Prima neta
        /// </summary>
        public double imp_neta { get; set; }

        /// <summary>
        ///  Impuestos
        /// </summary>
        public double imp_imptos { get; set; }

        /// <summary>
        ///  Recargos
        /// </summary>
        public double imp_recargo { get; set; }

        /// <summary>
        ///  Intereses
        /// </summary>
        public double imp_interes { get; set; }

    }
}