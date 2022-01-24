using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Architect.API.Tron.Contracts.Presupuesto.API
{
    /// <summary>
    ///  Datos fijos (P2000030)
    /// </summary>
    public class Presupuesto
    {

        /// <summary>
        ///  Ramo
        /// </summary>
        public int cod_ramo { get; set; }

        /// <summary>
        ///  Efecto de la póliza
        /// </summary>
        public DateTime fec_efec_poliza { get; set; }

        /// <summary>
        ///  Vencimiento de la póliza
        /// </summary>
        public DateTime fec_vcto_poliza { get; set; }

        /// <summary>
        ///  Moneda
        /// </summary>
        public int cod_mon { get; set; }

        /// <summary>
        ///  Plan de pago
        /// </summary>
        public int cod_fracc_pago { get; set; }

        /// <summary>
        ///  Contrato
        /// </summary>
        public int num_contrato { get; set; }

        /// <summary>
        ///  Número de sub-contrato
        /// </summary>       
        public int num_subcontrato { get; set; }

        /// <summary>
        ///  póliza grupo
        /// </summary>
        public string num_poliza_grupo { get; set; }

        /// <summary>
        ///  Riesgos del presupuesto (P2000031)
        /// </summary>
        public List<API.Riesgo> Riesgos { get; set; }

    }
}