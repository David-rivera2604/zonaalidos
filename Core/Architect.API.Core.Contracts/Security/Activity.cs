using System.Collections.Generic;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Registro de la ultima actividad de un usuario en la aplicación.
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// Identificación unica.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Token de acceso
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        ///  Nombre de la compañia propietaria.
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Identificación del usuario.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Usuario o correo electronico
        /// </summary>
        public string EMail { get; set; }
        /// <summary>
        /// Dirección IP/Nombre de la maquina donde se hizo la solicitud.
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// Fecha y hora de la primera actividad en el servidor
        /// </summary>
        public System.DateTime InitDateTime { get; set; }
        /// <summary>
        /// Fecha y hora de la última actividad en el servidor
        /// </summary>
        public System.DateTime LastDateTime { get; set; }

        /// <summary>
        /// Indica que la sesión se encuentra expirada
        /// </summary>
        public bool Expired { get; set; }

        /// <summary>
        /// Información sobre el dispositivo de consulta que efectúa una petición de red.
        /// </summary>
        public string UserAgent { get; set; }

        public string Navigation { get; set; }

        public System.DateTime ErrorTime { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDetail { get; set; }

        public List<ActivityTrack> ActivityTracks { get; set; }
    }

    public class ActivityTrack
    {
        public System.DateTime LastDateTime { get; set; }
        public string Summary { get; set; }
    }

}
