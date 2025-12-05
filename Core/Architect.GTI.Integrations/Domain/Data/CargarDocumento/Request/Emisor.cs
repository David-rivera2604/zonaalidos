namespace Architect.GTI.Integrations.Domain.CargarDocumento.Request
{
    /// <summary>
    /// Información del emisor del documento electrónico.
    /// </summary>
    public class Emisor
    {
        /// <summary>
        /// Tipo de identificación del emisor.
        /// </summary>
        public int TipoIdent { get; set; }

        /// <summary>
        /// Número de identificación del emisor.
        /// </summary>
        public string Identificacion { get; set; }

        /// <summary>
        /// Nombre legal del emisor.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Nombre comercial del emisor.
        /// </summary>
        public string NombComercial { get; set; }

        /// <summary>
        /// Código de provincia del emisor.
        /// </summary>
        public int Provincia { get; set; }

        /// <summary>
        /// Código de cantón del emisor.
        /// </summary>
        public int Canton { get; set; }

        /// <summary>
        /// Código de distrito del emisor.
        /// </summary>
        public int Distrito { get; set; }

        /// <summary>
        /// Dirección completa del emisor.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Código de área del teléfono del emisor.
        /// </summary>
        public int AreaTelefono { get; set; }

        /// <summary>
        /// Número de teléfono del emisor.
        /// </summary>
        public int NumTelefono { get; set; }

        /// <summary>
        /// Código de área del fax del emisor.
        /// </summary>
        public int AreaFax { get; set; }

        /// <summary>
        /// Número de fax del emisor.
        /// </summary>
        public int NumFax { get; set; }

        /// <summary>
        /// Correo electrónico del emisor.
        /// </summary>
        public string Correo { get; set; }
    }
}
