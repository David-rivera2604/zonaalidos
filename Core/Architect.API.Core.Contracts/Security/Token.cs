using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Información el token
    /// </summary>
    [DataContract]
    public class Token
    {
        /// <summary>
        /// Identificación del usuario.
        /// </summary>
        [DataMember(), JsonProperty()]
        public int UserId { get; set; }
        /// <summary>
        /// Sucursal a la que pertenece el usuario.
        /// </summary>
        [DataMember(), JsonProperty()]
        public int BranchOffice { get; set; }
        /// <summary>
        /// Nivel de seguridad.
        /// </summary>
        [DataMember(), JsonProperty()]
        public int SecurityLevel { get; set; }
        /// <summary>
        /// Identificación del usuario supervisor.
        /// </summary>
        [DataMember(), JsonProperty()]
        public int ManagerId { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()]
        public int CompanyId { get; set; }
        /// <summary>
        /// Roles asociados al usuario del token.
        /// </summary>
        [DataMember(), JsonProperty()]
        public string Roles { get; set; }
        /// <summary>
        /// Fecha de expiración del token.
        /// </summary>
        [DataMember(), JsonProperty()]
        public System.DateTime Expires { get; set; }
        /// <summary>
        /// Código de agente.
        /// </summary>
        [DataMember(), JsonProperty()]
        public int AgentCode { get; set; }
        /// <summary>
        /// Código de sub agente.
        /// </summary>
        [DataMember(), JsonProperty()]
        public int SubAgentCode { get; set; }
        /// <summary>
        /// Descripción para tipo de documento.
        /// </summary>
        [DataMember(), JsonProperty()]
        public string IdentificationType { get; set; }
        /// <summary>
        /// Documento o número de identificación.
        /// </summary>
        [DataMember(), JsonProperty()]
        public string Identification { get; set; }
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        [DataMember(), JsonProperty()]
        public string UserName { get; set; }

        public List<SettingItem> Settings { get; set; }

    }

}
