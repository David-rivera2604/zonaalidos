using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Robots
{
    /// <summary>
    /// Citas de Inscripción:
    /// </summary>
    public class EnrollmentAppointments
    {
        /// <summary>
        /// Tomo
        /// </summary>
        public string Tome { get; set; }

        /// <summary>
        /// Asiento
        /// </summary>
        public string Seat { get; set; }

        /// <summary>
        /// Secuencia
        /// </summary>
        public string Sequence { get; set; }

        /// <summary>
        /// Fecha
        /// </summary>
        public DateTime Date { get; set; }
    }

}