namespace Architect.API.Tron.Contracts.Poliza
{
    /// <summary>
    ///  Coberturas de la póliza (A2000040)
    /// </summary>
    public partial class Cobertura
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
        ///  Cobertura
        /// </summary>
        public int cod_cob { get; set; }

        /// <summary>
        ///  Secuencia
        /// </summary>
        public int num_secu { get; set; }

        /// <summary>
        ///  Capital
        /// </summary>
        public double suma_aseg { get; set; }

        /// <summary>
        ///  Importe por unidad
        /// </summary>
        public double imp_unidad { get; set; }

        /// <summary>
        ///  Porcentaje de capital que tomara de la cobertura relacionada
        /// </summary>
        public double pct_participacion { get; set; }

        /// <summary>
        ///  Moneda del capital
        /// </summary>
        public int cod_mon_capital { get; set; }

        /// <summary>
        ///  Importe correspondiente a la liquidación por siniestro
        /// </summary>
        public double suma_aseg_baja_stro { get; set; }

        /// <summary>
        ///  Capital del suplemento
        /// </summary>
        public double suma_aseg_spto { get; set; }

        /// <summary>
        ///  Tasa aplicada al calcular la prima de la cobertura
        /// </summary>
        public double tasa_cob { get; set; }

        /// <summary>
        ///  Franquicia
        /// </summary>
        public int cod_franquicia { get; set; }

        /// <summary>
        ///  Limite
        /// </summary>
        public int cod_limite { get; set; }

        /// <summary>
        ///  Capital superior en caso de limite doble
        /// </summary>
        public double suma_aseg_sup { get; set; }

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
        ///  La cobertura esta dada de baja
        /// </summary>
        public string mca_baja_cob { get; set; }

        /// <summary>
        ///  Sección de reaseguro (política de distribución)
        /// </summary>
        public int cod_secc_reas { get; set; }

        /// <summary>
        ///  Importe del agravante/deducción
        /// </summary>
        public double imp_agr { get; set; }

        /// <summary>
        ///  Importe de agravante/deducción relacionado
        /// </summary>
        public double imp_agr_rel { get; set; }

        /// <summary>
        ///  Importe de agravante/deducción del suplemento
        /// </summary>
        public double imp_agr_spto { get; set; }

        /// <summary>
        ///  Importe de agravante/deducción relacionado del suplemento
        /// </summary>
        public double imp_agr_rel_spto { get; set; }

        /// <summary>
        ///  Mes base para la re-valorización de capitales en la renovación
        /// </summary>
        public int mes_base_regulariza { get; set; }

        /// <summary>
        ///  Año base para la re-valorización de capitales en la renovación
        /// </summary>
        public int anio_base_regulariza { get; set; }

        /// <summary>
        ///  Porcentaje sobre tasa de enfermedad (vida)
        /// </summary>
        public double pct_enfermedad { get; set; }

        /// <summary>
        ///  Duración de aplicación del porcentaje de sobre tasa de profesión (vida)
        /// </summary>
        public int duracion_profesion { get; set; }

        /// <summary>
        ///  Porcentaje sobre tasa de profesión (vida)
        /// </summary>
        public double pct_profesion { get; set; }

        /// <summary>
        ///  Duración de aplicación del porcentaje de sobre tasa de enfermedad (vida)
        /// </summary>
        public int duracion_enfermedad { get; set; }

        /// <summary>
        ///  Importe mínimo de franquicia
        /// </summary>
        public double val_franquicia_min { get; set; }

        /// <summary>
        ///  Importe máximo de franquicia
        /// </summary>
        public double val_franquicia_max { get; set; }

        /// <summary>
        ///  Ramo
        /// </summary>
        public int cod_ramo { get; set; }

        /// <summary>
        ///  Importe de los accesorios correspondiente a la liquidación por siniestro
        /// </summary>
        public double suma_aseg_baja_stro_acc { get; set; }
    }
}