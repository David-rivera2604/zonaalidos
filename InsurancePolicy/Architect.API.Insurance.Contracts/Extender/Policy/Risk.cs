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

        /// <summary>
        /// Nivel de restricción.
        /// </summary>
        [JsonIgnore()] public int RestrictionLevel { get; set; } = 9;

        /// <summary>
        /// Indica si el riesgo debe manejar suscripción.
        /// </summary>
        [JsonIgnore()] public string Undewriting { get; set; } = "enabled";

        /// <summary>
        /// Indica si el riesgo se debe almacenar en captura incompleta en caso de errores.
        /// </summary>
        [JsonIgnore()] public string DraftStorage { get; set; } = "enabled";

        /// <summary>
        /// Uso interno.
        /// </summary>
        [JsonIgnore()] public int RowNumber { get; set; }
        /// <summary>
        /// Uso interno.
        /// </summary>
        [JsonIgnore()] public string Behavior { get; set; }

        /// <summary>
        /// Información particular de Bayer.
        /// </summary>
        [DataMember(), JsonProperty()] public Contracts.Policy.RiskBayer Bayer { get; set; }

        /// <summary>
        /// Indica si el usuario puede firma de forma electrónica.
        /// </summary>
        [DataMember(), JsonProperty()] public bool HasDigitalSignature { get; set; }
        

    }
}

