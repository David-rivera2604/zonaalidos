using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Siniestro.Purdy
{
    /// <summary>
    /// Información de siniestros para Purdy
    /// </summary>
    public class Siniestro
    {

        /// <summary>
        /// Fecha de ingreso de aviso
        /// </summary>
        public DateTime FechaDeIngresoDeAviso { get; set; }
        /// <summary>
        /// Mes de siniestro
        /// </summary>
        public int MesDeSiniestro { get; set; }
        /// <summary>
        /// No. siniestro
        /// </summary>
        public Int64 NoSiniestro { get; set; }
        /// <summary>
        /// Expediente
        /// </summary>
        public int Expediente { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public string Estado { get; set; }
        /// <summary>
        /// Tipo de indemnización
        /// </summary>
        public string TipoDeIndemnizacion { get; set; }
        /// <summary>
        /// No. póliza
        /// </summary>
        public string NoPoliza { get; set; }
        /// <summary>
        /// Matricula
        /// </summary>
        public string Matricula { get; set; }
        /// <summary>
        /// Cédula asegurado
        /// </summary>
        public string CedulaAsegurado { get; set; }
        /// <summary>
        /// Nombre asegurado
        /// </summary>
        public string NombreAsegurado { get; set; }
        /// <summary>
        /// Tipo cobertura
        /// </summary>
        public string TipoCobertura { get; set; }
        /// <summary>
        /// Detalle siniestro
        /// </summary>
        public string DetalleSiniestro { get; set; }
        /// <summary>
        /// Correo asegurado
        /// </summary>
        public string CorreoAsegurado { get; set; }
        /// <summary>
        /// Teléfono asegurado
        /// </summary>
        public string TelefonoAsegurado { get; set; }
        /// <summary>
        /// Valor asegurado 
        /// </summary>
        public double ValorAsegurado { get; set; }
        /// <summary>
        /// Total de prima cobradas
        /// </summary>
        public double TotalDePrimaCobradas { get; set; }
        /// <summary>
        /// Monto de primas del periodo
        /// </summary>
        public double MontoDePrimasDelPeriodo { get; set; }
        /// <summary>
        /// Total primas pendientes del periodo
        /// </summary>
        public double TotalPrimasPendientesDelPeriodo { get; set; }
        /// <summary>
        /// Primas pendientes de cobro
        /// </summary>
        public double PrimasPendientesDeCobro { get; set; }
        /// <summary>
        /// Fecha ultima prima cobrada
        /// </summary>
        public DateTime? FechaUltimaPrimaCobrada { get; set; }
        /// <summary>
        /// Deducible
        /// </summary>
        public double Deducible { get; set; }

    }
}
