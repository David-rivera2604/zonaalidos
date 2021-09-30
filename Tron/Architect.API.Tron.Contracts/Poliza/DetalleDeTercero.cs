namespace Architect.API.Tron.Contracts.Poliza
{
    /// <summary>
    /// Terceros relacionados con la póliza (Tomadores, Asegurados, etc.) (A1001331)
    /// </summary>
    public partial class DetalleDeTercero
    {
        /// <summary>
        ///  País, primer nivel de la estructura geográfica
        /// </summary>
        public string cod_pais { get; set; }

        /// <summary>
        ///  Tipo del documento del tercero
        /// </summary>
        public string tip_docum { get; set; }

        /// <summary>
        ///  Documento del tercero
        /// </summary>
        public string cod_docum { get; set; }

        /// <summary>
        ///  Estado civil
        /// </summary>
        public string cod_est_civil { get; set; }

        /// <summary>
        ///  Segundo nivel de la estructura geográfica
        /// </summary>
        public string cod_estado { get; set; }

        /// <summary>
        ///  Tercer nivel de la estructura geográfica
        /// </summary>
        public string cod_prov { get; set; }

        /// <summary>
        ///  Cuarto nivel de la estructura geográfica
        /// </summary>
        public string cod_localidad { get; set; }
        
        /// <summary>
        ///  Domicilio (primera linea)
        /// </summary>
        public string nom_domicilio1 { get; set; }

        /// <summary>
        ///  Número de teléfono
        /// </summary>
        public string tlf_numero { get; set; }

        /// <summary>
        ///  Dirección de correo electrónico
        /// </summary>
        public string email { get; set; }
    }
}
