namespace Architect.GTI.Integrations.Domain.CargarDocumento.Request
{
    /// <summary>
    /// Representa una línea de detalle del documento (producto o servicio).
    /// </summary>
    public class Linea
    {
        /// <summary>
        /// Tipo de línea (producto o servicio).
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Código del producto o servicio.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Tipos de códigos asociados al producto o servicio.
        /// </summary>
        public int[] CodTipo { get; set; }

        /// <summary>
        /// Códigos de producto o servicio.
        /// </summary>
        public string[] CodProdServ { get; set; }

        /// <summary>
        /// Código de unidad de medida.
        /// </summary>
        public int UnidadMedida { get; set; }

        /// <summary>
        /// Descripción de la unidad comercial.
        /// </summary>
        public string UnidadComercial { get; set; }

        /// <summary>
        /// Cantidad de unidades del producto o servicio.
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Precio unitario del producto o servicio.
        /// </summary>
        public int PrecioUnitario { get; set; }

        /// <summary>
        /// Descripción detallada del producto o servicio.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Impuestos aplicados a esta línea.
        /// </summary>
        public Impuesto[] Impuestos { get; set; }
    }
}
