/// <summary>
///
/// </summary>

namespace Architect.API.Tron.Contracts.Poliza
{
    public partial class CoberturaCalculada
    {
        /// <summary>
        ///
        /// </summary>
        public string NUM_POLIZA { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int COD_COB { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string NOM_COB { get; set; }

        /// <summary>
        ///
        /// </summary>
        public double SUMA_ASEG { get; set; }

        /// <summary>
        ///
        /// </summary>
        public double IMP_ANUAL { get; set; }

        /// <summary>
        ///
        /// </summary>
        public double IMP_IVA { get; set; }

        /// <summary>
        ///
        /// </summary>
        public double IMP_FRACC { get; set; }

        /// <summary>
        ///
        /// </summary>
        public double IMP_TOTAL { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int COD_FRANQUICIA { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string NOM_FRANQUICIA { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string TXT_ERROR { get; set; }
    }
}