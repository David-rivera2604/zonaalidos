namespace Architect.GTI.Integrations.Domain.CargarDocumento.Request
{
    /// <summary>
    /// Información del receptor del documento electrónico.
    /// </summary>
    public class Receptor
    {
        /// <summary>
        /// Tipo de identificación del receptor.
        /// <para><b>Valores válidos:</b></para>
        /// <para>• <b>1</b> - Cédula física (9 dígitos): Solo números, sin cero al inicio y sin guiones.</para>
        /// <para>• <b>2</b> - Cédula jurídica (10 dígitos): Solo números, sin guiones.</para>
        /// <para>• <b>3</b> - DIMEX (11-12 dígitos): Solo números, sin guiones.</para>
        /// <para>• <b>4</b> - NITE (10 dígitos): Solo números, sin guiones.</para>
        /// <para>• <b>5</b> - Extranjero No Domiciliado (1-20 caracteres): Puede contener números y letras.</para>
        /// <para>• <b>6</b> - No Contribuyente (1-20 caracteres): Puede contener números y letras.</para>
        /// </summary>
        public int TipoIdent { get; set; }

        /// <summary>
        /// Número de identificación del receptor.
        /// </summary>
        public string Identificacion { get; set; }

        /// <summary>
        /// Nombre del receptor.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Correo electrónico del receptor.
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// Correos electrónicos en copia.
        /// </summary>
        public string Copia { get; set; }

        /// <summary>
        /// Destinatario adicional del documento.
        /// </summary>
        public string Destinatario { get; set; }

    }
}
