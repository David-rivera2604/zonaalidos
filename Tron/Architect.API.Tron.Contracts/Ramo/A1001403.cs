using System;

namespace Architect.API.Tron.Contracts.Ramo
{
    /// <summary>
    ///  Formas de pago/planes de pago del ramo
    /// </summary>
    public class A1001403
    {
        /// <summary>
        ///  Moneda.
        /// </summary>
        public int cod_mon { get; set; }

        /// <summary>
        ///  Plan de pago
        /// </summary>
        public int cod_fracc_pago { get; set; }

        /// <summary>
        /// Descripción de la forma de pago/plan de pago. Esta columna proviene de la tabla A1001402
        /// </summary>
        public string nom_fracc_pago { get; set; }

        /// <summary>
        /// Fecha de validez.
        /// </summary>
        public DateTime fec_validez { get; set; }

        /// <summary>
        /// Nivel 1 de la estructura comercial.
        /// </summary>
        public int cod_nivel1 { get; set; }

        /// <summary>
        /// Nivel 2 de la estructura comercial.
        /// </summary>
        public int cod_nivel2 { get; set; }

        /// <summary>
        /// Código de nivel 3 oficina captura.
        /// </summary>
        public int cod_nivel3 { get; set; }

        /// <summary>
        /// Plan de pago del ramo por defecto.
        /// </summary>
        public string MCA_FRACC_PAGO_DEF { get; set; }

        /// <summary>
        /// Porcentaje de recargo por fraccionamiento de pago. Esta columna proviene de la tabla A2990020_MCR
        /// </summary>
        public double pct_fracc_pago { get; set; }

        public double monto_recargo { get; set; }


    }
}