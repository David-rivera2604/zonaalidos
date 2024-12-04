using System;

namespace Architect.API.Tron.Contracts.Poliza
{
    /// <summary>
    ///  Terceros de la póliza (A2000060)
    /// </summary>
    public partial class Tercero
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
        ///  Forma en la que interviene
        /// </summary>
        public string tip_benef { get; set; }

        /// <summary>
        ///  Secuencia
        /// </summary>
        public int num_secu { get; set; }

        /// <summary>
        ///  Tipo del documento del tercero
        /// </summary>
        public string tip_docum { get; set; }

        /// <summary>
        ///  Documento del tercero
        /// </summary>
        public string cod_docum { get; set; }

        /// <summary>
        ///  Tercero principal del riesgo
        /// </summary>
        public string mca_principal { get; set; }

        /// <summary>
        ///  Tercero por el que se ha calculado el riesgo
        /// </summary>
        public string mca_calculo { get; set; }

        /// <summary>
        ///  La fila esta dada de baja
        /// </summary>
        public string mca_baja { get; set; }

        /// <summary>
        ///  Fila vigente
        /// </summary>
        public string mca_vigente { get; set; }

        /// <summary>
        ///  Porcentaje de capital que tomara de la cobertura relacionada
        /// </summary>
        public double pct_participacion { get; set; }

        /// <summary>
        ///  Fecha de vencimiento de la financiación del riesgo
        /// </summary>
        public DateTime fec_vcto_cesion { get; set; }

        /// <summary>
        ///  Importe financiado
        /// </summary>
        public double imp_cesion { get; set; }

        /// <summary>
        ///  Número asociado a la financiación del riesgo
        /// </summary>
        public string num_prestamo { get; set; }

        /// <summary>
        ///  Tipo de relación
        /// </summary>
        public string tip_relac { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string nom_completo { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string nom_benef { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string fec_nacimiento { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string tlf_numero { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string email { get; set; }
    }
}