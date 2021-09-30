namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Información del cliente
    /// </summary>
    public class ClientInformation
    {
        /// <summary>
        ///  Tipo del documento
        /// </summary>
        public string tip_docum { get; set; }

        /// <summary>
        ///  Documento
        /// </summary>
        public string cod_docum { get; set; }

        /// <summary>
        ///  Correo electrónico
        /// </summary>
        public string email { get; set; }
    }
}
