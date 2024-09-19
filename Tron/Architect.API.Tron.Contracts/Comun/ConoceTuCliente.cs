using Architect.API.Core.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Architect.API.Tron.Contracts.Comun
{
    /// <summary>
    /// Conozca a su cliente
    /// </summary>
    public class ConoceTuCliente 
    {
        /// <summary>
        /// Conozca a su cliente Juridico
        /// </summary>
        [DataMember(), JsonProperty()] public KycJuridico Juridico { get; set; }

        /// <summary>
        /// CConozca a su cliente Persona
        /// </summary>
        [DataMember(), JsonProperty()] public Kycpersona Persona { get; set; }

    }

}
