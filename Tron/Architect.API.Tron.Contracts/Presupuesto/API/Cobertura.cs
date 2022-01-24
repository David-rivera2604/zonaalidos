using System.Collections.Generic;
using System.Xml.Serialization;

namespace Architect.API.Tron.Contracts.Presupuesto.API
{
    /// <summary>
    ///  Coberturas del presupuesto (P2000040)
    /// </summary>
    public class Cobertura
    {

        /// <summary>
        ///  Cobertura
        /// </summary>
        public int cod_cob { get; set; }

        /// <summary>
        ///  Capital
        /// </summary>
        public double suma_aseg { get; set; }

        /// <summary>
        ///  Tasa aplicada al calcular la prima de la cobertura
        /// </summary>
        public double tasa_cob { get; set; }

        /// <summary>
        /// Conceptos de desglose económico del presupuesto (P2100170)
        /// </summary>
        public List<API.DesgloseEconomico> DesgloseEconomico { get; set; }
    }
}