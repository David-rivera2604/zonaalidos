using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Navegación permitidas por rol de usuario..
    /// </summary>
    [Serializable(), DataContract()]
    public partial class RoleMemberNavigation
    {
        /// <summary>
        /// Identificación
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Identificación Rol.
        /// </summary>
        [DataMember(), JsonProperty()] public int RoleId { get; set; }
        [DataMember(), JsonProperty()] public string RoleDesc { get; set; }

        /// <summary>
        /// Código que identifica el registro de navegación.
        /// </summary>
        [DataMember(), JsonProperty()] public string Code { get; set; }
        [DataMember(), JsonProperty()] public string CodeDesc { get; set; }
        /// <summary>
        /// Permite o no el acceso al registro de navegación.
        /// </summary>
        [DataMember(), JsonProperty()] public bool Allow { get; set; }
        /// <summary>
        /// Nivel de seguridad.
        /// </summary>
        [DataMember(), JsonProperty()] public int SecurityLevel { get; set; }
        /// <summary>
        /// Agregar.
        /// </summary>
        [DataMember(), JsonProperty()] public bool CreateAction { get; set; }
        /// <summary>
        /// Ver.
        /// </summary>
        [DataMember(), JsonProperty()] public bool ReadAction { get; set; }
        /// <summary>
        /// Actualizar
        /// </summary>
        [DataMember(), JsonProperty()] public bool UpdateAction { get; set; }
        /// <summary>
        /// Eliminar.
        /// </summary>
        [DataMember(), JsonProperty()] public bool DeleteAction { get; set; }
        /// <summary>
        /// Listar.
        /// </summary>
        [DataMember(), JsonProperty()] public bool ListAction { get; set; }
        /// <summary>
        /// Imprimir.
        /// </summary>
        [DataMember(), JsonProperty()] public bool PrintAction { get; set; }
        /// <summary>
        /// Usuario que actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int UpdateUserCode { get; set; }
        /// <summary>
        /// Nombre del usuario que actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public string UpdateUserName { get; set; }
        /// <summary>
        /// Fecha que se actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime UpdateDate { get; set; }
    }
}

