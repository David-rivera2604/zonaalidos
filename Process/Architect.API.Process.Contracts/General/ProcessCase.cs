using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

namespace Architect.API.Process.Contracts.General
{
    public partial class ProcessCase
    {
        /// <summary>
        /// Adjuntos del un caso.
        /// </summary>
        public List<Core.Contracts.General.Attachments> Attachments  { get; set; }

    }
}


