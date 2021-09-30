using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    ///  Información de los beneficiarios vinculados a una póliza.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class RiskBeneficiaryView
    {
        /// <summary>
        /// Nombre completo de beneficiario.
        /// </summary>
        [DataMember(), JsonProperty()] public string FullName { get; set; }
        /// <summary>
        /// Documento o número de identificación.
        /// </summary>
        [DataMember(), JsonProperty()] public string DocumentNumber { get; set; }
        /// <summary>
        /// Descripción para perentesco de los beneficiarios.
        /// </summary>
        [DataMember(), JsonProperty()] public string RelationshipDesc { get; set; }
        /// <summary>
        /// Porcentaje de participación del beneficiario.
        /// </summary>
        [DataMember(), JsonProperty()] public int ParticipationRate { get; set; }


        /// <summary>
        /// Dirección.
        /// </summary>
        [DataMember(), JsonProperty()] public string FullAddress { get; set; }
        /// <summary>
        /// Número de teléfono.
        /// </summary>
        [DataMember(), JsonProperty()] public string Phone { get; set; }

        /// <summary>
        /// Dirección de correo electrónico
        /// </summary>
        [DataMember(), JsonProperty()] public string Email { get; set; }
    }
}

