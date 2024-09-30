using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Robots
{

    /// <summary>
    /// Gravamen
    /// </summary>
    public class Assessment
    {
        /// <summary>
        /// Tipo
        /// </summary>
        public string Type { get; set; }

        public List<EnrollmentAppointments> EnrollmentAppointments { get; set; }
    }
}