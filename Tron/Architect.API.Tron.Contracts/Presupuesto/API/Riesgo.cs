using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Architect.API.Tron.Contracts.Presupuesto.API
{
    /// <summary>
    ///  Riesgos del presupuesto (P2000031)
    /// </summary>
    public class Riesgo
    {

        /// <summary>
        ///  Riesgo
        /// </summary>
        public int num_riesgo { get; set; }

        /// <summary>
        ///  Descripción del riesgo
        /// </summary>
        public string nom_riesgo { get; set; }

        /// <summary>
        /// Datos variables del presupuesto
        /// </summary>
        public List<API.DatoVariable> DatosVariables { get; set; }

        /// <summary>
        ///  Ocurrencias del presupuesto (P2000025)
        /// </summary>
        public List<API.Ocurrencia> Ocurrencias { get; set; }

        /// <summary>
        ///  Terceros del presupuesto (P2000060)
        /// </summary>
        public List<API.Tercero> Terceros { get; set; }

        /// <summary>
        ///  Coberturas del presupuesto (P2000040)
        /// </summary>
        public List<API.Cobertura> Coberturas { get; set; }

    }
}