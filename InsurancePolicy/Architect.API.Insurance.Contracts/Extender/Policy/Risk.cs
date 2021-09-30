using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    public partial class Risk
    {
        /// <summary>
        /// Información del asegurado principal.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskRoles PrimaryInsured { get; set; }
        /// <summary>
        /// Cuestionarios vinculados a una póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public List<RiskQuestionnaires> Questionary { get; set; }
        /// <summary>
        /// Información de los prestamos vinculados a una póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskOverdraft Overdraft { get; set; }
        /// <summary>
        /// Información de los beneficiarios vinculados a una póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public List<RiskRoles> Beneficiaries { get; set; }
        /// <summary>
        /// Archivos adjuntos.
        /// </summary>
        [DataMember(), JsonProperty()] public List<API.Core.Contracts.General.AttachmentView> Attachments { get; set; }
        /// <summary>
        /// Alias del producto.
        /// </summary>
        [DataMember(), JsonProperty()] public string ProductAlias { get; set; }

        /// <summary>
        /// Descripción para ramo
        /// </summary>
        [DataMember(), JsonProperty()] public string LineOfBusinessDesc { get; set; }

        /// <summary>
        /// Descripción para producto.
        /// </summary>
        [DataMember(), JsonProperty()] public string ProductDesc { get; set; }
    }
}

