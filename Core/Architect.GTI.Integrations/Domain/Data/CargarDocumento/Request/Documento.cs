using System;

namespace Architect.GTI.Integrations.Domain.CargarDocumento.Request
{
    /// <summary>
    /// Representa un documento electrónico que se va a cargar en el sistema GTI.
    /// </summary>
    public class Documento
    {
        /// <summary>
        /// Información del emisor del documento electrónico.
        /// </summary>
        public Emisor Emisor { get; set; }

        /// <summary>
        /// Información del encabezado del documento electrónico.
        /// </summary>
        public Encabezado Encabezado { get; set; }

        /// <summary>
        /// Líneas de detalle del documento (productos o servicios).
        /// </summary>
        public Linea[] Lineas { get; set; }

        /// <summary>
        /// Otros cargos adicionales aplicados al documento.
        /// </summary>
        public object[] OtrosCargos { get; set; }

        /// <summary>
        /// Referencia a otros documentos relacionados.
        /// </summary>
        public object referencia { get; set; }

        /// <summary>
        /// Totales calculados del documento electrónico.
        /// </summary>
        public Totales Totales { get; set; }

        /// <summary>
        /// Información extra y configuraciones adicionales del documento.
        /// </summary>
        public Extra Extra { get; set; }
    }
}
