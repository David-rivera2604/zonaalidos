namespace Architect.API.Tron.Contracts.Poliza.API
{
    /// <summary>
    ///  Coberturas de la póliza (A2000040)
    /// </summary>
    public class Cobertura
    {

        /// <summary>
        ///  Cobertura
        /// </summary>
        public int cod_cob { get; set; }

        /// <summary>
        /// Nombre de la cobertura
        /// </summary>
        public string nom_cob { get; set; }

        /// <summary>
        ///  Capital
        /// </summary>
        public double suma_aseg { get; set; }

        /// <summary>
        /// Importe anual.
        /// </summary>
        public double imp_anual { get; set; }

        /// <summary>
        /// Importe iva.
        /// </summary>
        public double imp_iva { get; set; }

        /// <summary>
        /// Importe por concepto de franquicia.
        /// </summary>
        public double imp_fracc { get; set; }

        /// <summary>
        /// Importe total.
        /// </summary>
        public double imp_total { get; set; }

        /// <summary>
        /// Código de franquicia.
        /// </summary>
        public int cod_franquicia { get; set; }

        /// <summary>
        /// Nombre de franquicia.
        /// </summary>
        public string nom_franquicia { get; set; }

    }
}