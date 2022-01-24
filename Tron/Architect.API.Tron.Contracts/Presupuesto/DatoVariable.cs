namespace Architect.API.Tron.Contracts.Presupuesto
{
    /// <summary>
    ///  Datos variables del presupuesto
    /// </summary>
    /// <remarks> Tabla física P2000020 </remarks>
    public partial class DatoVariable
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
        ///  Periodo (para pólizas multi-anuales)
        /// </summary>
        public int num_periodo { get; set; }

        /// <summary>
        ///  Nivel de petición
        /// </summary>
        public int tip_nivel { get; set; }

        /// <summary>
        ///  Nombre del dato variable
        /// </summary>
        public string cod_campo { get; set; }

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
        ///  Ramo
        /// </summary>
        public int cod_ramo { get; set; }

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
    }
}