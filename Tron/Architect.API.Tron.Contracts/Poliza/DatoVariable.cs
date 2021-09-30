namespace Architect.API.Tron.Contracts.Poliza
{
    /// <summary>
    ///  Datos variables de la póliza (A2000020)
    /// </summary>
    public partial class DatoVariable
    {
        /// <summary>
        ///  Póliza
        /// </summary>
        public string num_poliza { get; set; }

        /// <summary>
        ///  Código de compañía
        /// </summary>
        public int cod_cia { get; set; }

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
        ///  Código del dato variable
        /// </summary>
        public string cod_campo { get; set; }

        /// <summary>
        ///  Nombre del dato variable
        /// </summary>
        public string nom_campo { get; set; }

        /// <summary>
        ///  Periodo (para pólizas multianuales)
        /// </summary>
        public int num_periodo { get; set; }

        /// <summary>
        ///  Nivel de petición
        /// </summary>
        public int tip_nivel { get; set; }

        /// <summary>
        ///  Valor
        /// </summary>
        public string val_campo { get; set; }

        /// <summary>
        ///  Valor corto (diez primeras posiciones)
        /// </summary>
        public string val_cor_campo { get; set; }

        /// <summary>
        ///  Secuencia
        /// </summary>
        public int num_secu { get; set; }

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
        ///  Ramo
        /// </summary>
        public int cod_ramo { get; set; }
    }
}