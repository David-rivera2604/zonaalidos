using System;
using System.Collections.Generic;

namespace Architect.API.Tron.Contracts.Poliza
{
    /// <summary>
    ///  Información de la Cancelación
    /// </summary>
    public class Cancelacion
    {

        /// <summary>
        ///  Fecha de cancelación
        /// </summary>
        public DateTime Fec_Anulacion { get; set; }

        /// <summary>
        ///  Motivo de la cancelación
        /// </summary>
        public string Mot_Spto { get; set; }

    }

}