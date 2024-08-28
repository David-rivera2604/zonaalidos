using System.Collections.Generic;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Información el token
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Identificación del usuario.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Sucursal a la que pertenece el usuario.
        /// </summary>
        public int BranchOffice { get; set; }
        /// <summary>
        /// Nivel de seguridad.
        /// </summary>
        public int SecurityLevel { get; set; }
        /// <summary>
        /// Identificación del usuario supervisor.
        /// </summary>
        public int ManagerId { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Roles asociados al usuario del token.
        /// </summary>
        public string Roles { get; set; }
        /// <summary>
        /// Fecha de expiración del token.
        /// </summary>
        public System.DateTime Expires { get; set; }
        /// <summary>
        /// Código de agente.
        /// </summary>
        public int AgentCode { get; set; }
        /// <summary>
        /// Código de sub agente.
        /// </summary>
        public int SubAgentCode { get; set; }
        /// <summary>
        /// Descripción para tipo de documento.
        /// </summary>
        public string IdentificationType { get; set; }
        /// <summary>
        /// Documento o número de identificación.
        /// </summary>
        public string Identification { get; set; }
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string UserName { get; set; }

        public List<SettingItem> Settings { get; set; }

    }

}
