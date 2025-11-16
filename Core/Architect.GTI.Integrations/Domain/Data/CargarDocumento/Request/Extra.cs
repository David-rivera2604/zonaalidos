namespace Architect.GTI.Integrations.Domain.CargarDocumento.Request
{
    /// <summary>
    /// Información extra y configuraciones adicionales del documento.
    /// </summary>
    public class Extra
    {
        /// <summary>
        /// Indica si el documento utiliza la versión 4.4 del formato de Hacienda.
        /// </summary>
        public bool EsVersion_4_4 { get; set; }
    }
}
