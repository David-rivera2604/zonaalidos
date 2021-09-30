/// <summary>
///  Formas de pago/planes de pago del ramo
/// </summary>

namespace Architect.API.Tron.Contracts.Tables
{
    public class a1001403
    {
        /// <summary>
        ///  Plan de pago
        /// </summary>
        public int cod_fracc_pago { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string nom_fracc_pago { get; set; }

        /// <summary>
        /// Esta column proviene de la tabla A2990020_MCR
        /// </summary>
        public double pct_fracc_pago { get; set; }

    }
}