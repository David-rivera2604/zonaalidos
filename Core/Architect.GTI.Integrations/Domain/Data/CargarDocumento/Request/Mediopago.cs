namespace Architect.GTI.Integrations.Domain.CargarDocumento.Request
{
    /// <summary>
    /// Representa un medio de pago utilizado en la transacción.
    /// </summary>
    public class Mediopago
    {
        /// <summary>
        /// Tipo de medio de pago utilizado (1 efectivo, 2 tarjeta, 6 SINPE Móvil, 99 Otros).
        /// </summary>
        public string TipoMedioPago { get; set; }

        /// <summary>
        /// Monto total pagado con este medio de pago.
        /// </summary>
        public double TotalMedioPago { get; set; }
    }
}
