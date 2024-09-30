using System.Collections.Generic;

namespace Architect.API.Tron.Contracts.Robots
{
    /// <summary>
    /// Contrato de retorno
    /// </summary>
    ///
    public class CivilRegistrationRequest
    {
        /// <summary>
        /// Citas de inscripción
        /// </summary>
        public EnrollmentAppointments EnrollmentAppointments { get; set; }

        /// <summary>
        /// Características Generales del Vehículo
        /// </summary>
        public GeneralCharacteristicsVehicle GeneralCharacteristicsVehicle { get; set; }

        /// <summary>
        /// Características del motor
        /// </summary>
        public Engine Engine { get; set; }

        /// <summary>
        /// Calidad(es) del(os) Propietario(s)
        /// </summary>
        public List<Owner> Owners { get; set; }

        /// <summary>
        /// Assessment
        /// </summary>
        public List<Assessment> Assessments { get; set; }

        /// <summary>
        /// Tipo de query
        /// </summary>
        public Enumerations.Type IdentificationType { get; set; }

        /// <summary>
        /// Valor de busqueda
        /// </summary>
        public string Identification { get; set; }

        /// <summary>
        /// Valor referencial
        /// </summary>
        public string Reference { get; set; }

    }
}