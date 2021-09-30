using System;

namespace Architect.API.Tron.Contracts.Poliza
{
    public partial class ReciboCalculado
    {
        /// <summary>
        ///
        /// </summary>
        public int NUM_CUOTA { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int NUM_RECIBO { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime FEC_EFEC_RECIBO { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime FEC_VCTO_RECIBO { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string TIP_SITUACION { get; set; }

        /// <summary>
        ///
        /// </summary>
        public double IMP_RECIBO { get; set; }

        /// <summary>
        ///
        /// </summary>
        public double IMP_NETA { get; set; }

        /// <summary>
        ///
        /// </summary>
        public double IMP_IMPTOS { get; set; }

        /// <summary>
        ///
        /// </summary>
        public double IMP_RECARGO { get; set; }

        /// <summary>
        ///
        /// </summary>
        public double IMP_INTERES { get; set; }
    }
}