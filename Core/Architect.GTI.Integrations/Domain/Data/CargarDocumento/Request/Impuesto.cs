namespace Architect.GTI.Integrations.Domain.CargarDocumento.Request
{
    /// <summary>
    /// Representa un impuesto aplicado a una línea del documento.
    /// </summary>
    public class Impuesto
    {
        /// <summary>
        /// Código de tarifa del impuesto.
        /// </summary>
        public int CodigoTarifa { get; set; }

        /// <summary>
        /// Código del impuesto.
        /// </summary>
        public int CodigoImp { get; set; }

        /// <summary>
        /// Porcentaje del impuesto aplicado.
        /// </summary>
        public int PorcentajeImp { get; set; }

        /// <summary>
        /// Monto calculado del impuesto.
        /// </summary>
        public double MontoImp { get; set; }
    }
}
