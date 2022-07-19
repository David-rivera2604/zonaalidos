namespace Architect.API.Insurance.Business.Enumerations
{
    /// <summary>
    /// Estado de una póliza.
    /// </summary>
    enum PolicyStatus : int
    {
        /// <summary>
        /// Incompleta.
        /// </summary>
        Incomplete = 1,
        /// <summary>
        /// En revisión, estado manejado pro personal de Mapfre o RRHH de Bayer según el caso.
        /// </summary>
        InReview = 2,
        /// <summary>
        /// Declinada.
        /// </summary>
        Declined = 3,
        /// <summary>
        /// Por aceptar, estado manejado por el aliado (coope) o previo a firma digital de la solicitud.
        /// </summary>
        ToBeAccepted = 4,
        /// <summary>
        /// Pendiente por complementos, estado donde el aliado complementa documentos solicitados.
        /// </summary>
        ComplementRequest = 5,
        /// <summary>
        /// Pendiente por firma
        /// </summary>
        PendingBySignature = 6,
        /// <summary>
        /// Alta.
        /// </summary>
        InForce = 10,
        /// <summary>
        /// Baja.
        /// </summary>
        Cancel = 11,
        /// <summary>
        /// Declinada, por expirar el tiempo para firma.
        /// </summary>
        DeclinedDuToSignatureExpiration = 31,
        /// <summary>
        /// Rechazada.
        /// </summary>
        RejectedBySigner = 32
    }
}
