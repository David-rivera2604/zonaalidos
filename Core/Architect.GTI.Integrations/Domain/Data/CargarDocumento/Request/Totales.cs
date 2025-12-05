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
        public double TotalServGravado { get; set; }

        /// <summary>
        /// Total de servicios exentos de impuestos.
        /// </summary>
        public double TotalServExento { get; set; }

        /// <summary>
        /// Total de servicios exonerados de impuestos.
        /// </summary>
        public double TotalServExonerado { get; set; }

        /// <summary>
        /// Total de mercancías gravadas con impuestos.
        /// </summary>
        public double TotalMercaGravada { get; set; }

        /// <summary>
        /// Total de mercancías exentas de impuestos.
        /// </summary>
        public double TotalMercaExenta { get; set; }

        /// <summary>
        /// Total de mercancías exoneradas de impuestos.
        /// </summary>
        public double TotalMercaExonerada { get; set; }

        /// <summary>
        /// Total general gravado con impuestos (servicios + mercancías).
        /// </summary>
        public double TotalGravado { get; set; }

        /// <summary>
        /// Total general exento de impuestos (servicios + mercancías).
        /// </summary>
        public double TotalExento { get; set; }

        /// <summary>
        /// Total general exonerado de impuestos (servicios + mercancías).
        /// </summary>
        public double TotalExonerado { get; set; }

        /// <summary>
        /// Total de IVA devuelto.
        /// </summary>
        public double TotalIVADevuelto { get; set; }

        /// <summary>
        /// Total de venta antes de descuentos e impuestos.
        /// </summary>
        public double TotalVenta { get; set; }

        /// <summary>
        /// Total de descuentos aplicados.
        /// </summary>
        public double TotalDescuento { get; set; }

        /// <summary>
        /// Total de venta neta (después de descuentos, antes de impuestos).
        /// </summary>
        public double TotalVentaNeta { get; set; }

        /// <summary>
        /// Total de impuestos aplicados.
        /// </summary>
        public double TotalImpuesto { get; set; }

        /// <summary>
        /// Total del comprobante (venta neta + impuestos).
        /// </summary>
        public double TotalComprobante { get; set; }
    }
}
