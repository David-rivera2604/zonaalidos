namespace Architect.API.Tron.Contracts.Poliza
{
    /// <summary>
    /// Ocurrencias de la póliza (A2000025)
    /// </summary>
    public partial class Ocurrencia
    {
        /// <summary>
        ///  Código de compañía
        /// </summary>
        public int cod_cia { get; set; }

        /// <summary>
        ///  Póliza
        /// </summary>
        public string num_poliza { get; set; }

        /// <summary>
        ///  Número de suplemento
        /// </summary>
        public int num_spto { get; set; }

        /// <summary>
        ///  Número de aplicación
        /// </summary>
        public int num_apli { get; set; }

        /// <summary>
        ///  Suplemento de la aplicación
        /// </summary>
        public int num_spto_apli { get; set; }

        /// <summary>
        ///  Riesgo
        /// </summary>
        public int num_riesgo { get; set; }

        /// <summary>
        ///  Periodo (para pólizas multianuales)
        /// </summary>
        public int num_periodo { get; set; }

        /// <summary>
        ///  Ocurrencia
        /// </summary>
        public int cod_lista { get; set; }

        /// <summary>
        ///  Número de ocurrencia
        /// </summary>
        public int num_ocurrencia { get; set; }

        /// <summary>
        ///  Secuencia
        /// </summary>
        public int num_secu { get; set; }

        /// <summary>
        ///  Nombre del dato variable
        /// </summary>
        public string cod_campo { get; set; }

        /// <summary>
        ///  Valor
        /// </summary>
        public string val_campo { get; set; }

        /// <summary>
        ///  Descripción
        /// </summary>
        public string txt_campo { get; set; }

        /// <summary>
        ///  El riesgo esta dado de baja
        /// </summary>
        public string mca_baja_riesgo { get; set; }

        /// <summary>
        ///  Fila vigente
        /// </summary>
        public string mca_vigente { get; set; }

        /// <summary>
        ///  Fila vigente (para aplicaciones)
        /// </summary>
        public string mca_vigente_apli { get; set; }

        /// <summary>
        ///  La ocurrencia esta dada de baja
        /// </summary>
        public string mca_baja_ocurrencia { get; set; }

        /// <summary>
        ///  Prima de la ocurrencia
        /// </summary>
        public double imp_ocurrencia { get; set; }
    }
}