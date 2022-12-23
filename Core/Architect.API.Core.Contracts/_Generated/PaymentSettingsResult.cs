using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    public partial class PaymentSettingsResult
    {
        /// <summary>
        /// .
        /// </summary>
        public PaymentSettings PaymentSettings { get; set; }
        /// <summary>
        /// Lista de notificaciones resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

