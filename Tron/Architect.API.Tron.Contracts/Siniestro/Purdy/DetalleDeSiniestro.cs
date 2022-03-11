using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Siniestro.Purdy
{
    /// <summary>
    /// Información complementaria por parte de Purdy sobre un siniestro
    /// </summary>
    public class DetalleDeSiniestro
    {
        /// <summary>
        /// Monto mano de obra
        /// </summary>
        public double MontoManoDeObra { get; set; }
        /// <summary>
        /// Monto de repuestos 
        /// </summary>
        public double MontoDeRepuestos { get; set; }
        /// <summary>
        /// Monto total 
        /// </summary>
        public double MontoTotal  { get; set; }
        /// <summary>
        /// Monto otros rubros
        /// </summary>
        public double MontoOtrosRubros { get; set; }
        /// <summary>
        /// Monto deducible
        /// </summary>
        public double MontoDeducible { get; set; }
        /// <summary>
        /// Monto recuperado 
        /// </summary>
        public double MontoRecuperado { get; set; }
        /// <summary>
        /// Fecha de último pago 
        /// </summary>
        public DateTime? FechaUltimoPago  { get; set; }
        /// <summary>
        /// Fecha de recuperación 
        /// </summary>
        public DateTime? FechaRecuperación { get; set; }
        /// <summary>
        /// Estado de expediente 
        /// </summary>
        public string EstadoExpediente { get; set; }
        /// <summary>
        /// Número de póliza
        /// </summary>
        public string NumeroDePoliza { get; set; }
        /// <summary>
        /// Número de siniestro
        /// </summary>
        public Int64 NumeroDeSiniestro { get; set; }
        /// <summary>
        /// Tipo de expediente
        /// </summary>
        public int TipoDeExpediente { get; set; }
    }
}
