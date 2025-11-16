namespace Architect.GTI.Integrations.Domain.CargarDocumento.Request
{
    /// <summary>
    /// Totales calculados del documento electrónico.
    /// </summary>
    public class Totales
    {
        /// <summary>
        /// Total de servicios gravados con impuestos.
        /// </summary>
        public int TotalServGravado { get; set; }

        /// <summary>
        /// Total de servicios exentos de impuestos.
        /// </summary>
        public int TotalServExento { get; set; }

        /// <summary>
        /// Total de servicios exonerados de impuestos.
        /// </summary>
        public int TotalServExonerado { get; set; }

        /// <summary>
        /// Total de mercancías gravadas con impuestos.
        /// </summary>
        public int TotalMercaGravada { get; set; }

        /// <summary>
        /// Total de mercancías exentas de impuestos.
        /// </summary>
        public int TotalMercaExenta { get; set; }

        /// <summary>
        /// Total de mercancías exoneradas de impuestos.
        /// </summary>
        public int TotalMercaExonerada { get; set; }

        /// <summary>
        /// Total general gravado con impuestos (servicios + mercancías).
        /// </summary>
        public int TotalGravado { get; set; }

        /// <summary>
        /// Total general exento de impuestos (servicios + mercancías).
        /// </summary>
        public int TotalExento { get; set; }

        /// <summary>
        /// Total general exonerado de impuestos (servicios + mercancías).
        /// </summary>
        public int TotalExonerado { get; set; }

        /// <summary>
        /// Total de IVA devuelto.
        /// </summary>
        public int TotalIVADevuelto { get; set; }

        /// <summary>
        /// Total de venta antes de descuentos e impuestos.
        /// </summary>
        public int TotalVenta { get; set; }

        /// <summary>
        /// Total de descuentos aplicados.
        /// </summary>
        public int TotalDescuento { get; set; }

        /// <summary>
        /// Total de venta neta (después de descuentos, antes de impuestos).
        /// </summary>
        public int TotalVentaNeta { get; set; }

        /// <summary>
        /// Total de impuestos aplicados.
        /// </summary>
        public float TotalImpuesto { get; set; }

        /// <summary>
        /// Total del comprobante (venta neta + impuestos).
        /// </summary>
        public float TotalComprobante { get; set; }
    }
}
