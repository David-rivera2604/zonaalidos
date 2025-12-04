using System;

namespace Architect.API.Core.Contracts.Traza
{
    /// <summary>
    /// Traza de solicitudes y respuestas.
    /// </summary>
    public partial class TrackRequest
    {
        /// <summary>
        /// Identificación única del pago.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Identificador único de MONGE enviado en la solicitud.
        /// </summary>
        public string DocumentId { get; set; }
        /// <summary>
        /// Tipo de solicitud.
        /// </summary>
        public string RequestType { get; set; }
        /// <summary>
        /// JSON de la solicitud.
        /// </summary>
        public string RequestBody { get; set; }
        /// <summary>
        /// Fecha y hora de la solicitud.
        /// </summary>
        public DateTime RequestTimeStamp { get; set; }
        /// <summary>
        /// Identificador único en MAPRE de la solicitud.
        /// </summary>
        public string MessageId { get; set; }
        /// <summary>
        /// Código de respuesta.
        /// </summary>
        public int ResponseStatus { get; set; }
        /// <summary>
        /// Detalle de la respuesta.
        /// </summary>
        public string ResponseText { get; set; }
        /// <summary>
        /// JSON de la respuesta.
        /// </summary>
        public string ResponseBody { get; set; }
        /// <summary>
        /// Fecha y hora de la respuesta.
        /// </summary>
        public DateTime ResponseTimeStamp { get; set; }
        /// <summary>
        /// Usuario que actualizo por última vez el registro.
        /// </summary>
        public int UpdateUserCode { get; set; }
        /// <summary>
        /// Nombre del usuario que actualizo por última vez el registro.
        /// </summary>
        public string UpdateUserName { get; set; }
        /// <summary>
        /// Fecha que se actualizo por última vez el registro.
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}

