using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Presupuesto
{
    /// <summary>
    ///  Conceptos de desglose económico del presupuesto (p2100170)
    /// </summary>
    public partial class DesgloseEconomico
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
        ///  Numero de suplemento
        /// </summary>
        public int num_spto { get; set; }

        /// <summary>
        ///  Numero de aplicación
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
        ///  Concepto de desglose económico
        /// </summary>
        public int cod_desglose { get; set; }

        /// <summary>
        ///  Concepto económico de recibo
        /// </summary>
        public int cod_eco { get; set; }

        /// <summary>
        ///  No se usa
        /// </summary>
        public int num_bloque_estudio { get; set; }

        /// <summary>
        ///  Importe (acumulado anual
        /// </summary>
        public double imp_acumulado_anual { get; set; }

        /// <summary>
        ///  Importe del suplemento
        /// </summary>
        public double imp_spto { get; set; }

        /// <summary>
        ///  Importe no consumido
        /// </summary>
        public double imp_no_consumido { get; set; }

        /// <summary>
        ///  Importe anual
        /// </summary>
        public double imp_anual { get; set; }

        /// <summary>
        ///  Ramo
        /// </summary>
        public int cod_ramo { get; set; }
    }
}
