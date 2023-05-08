using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    public partial class ProcessCase
    {
        /// <summary>
        /// Adjuntos del un caso.
        /// </summary>
        public List<Contracts.General.Attachments> Attachments  { get; set; }

    }
}


