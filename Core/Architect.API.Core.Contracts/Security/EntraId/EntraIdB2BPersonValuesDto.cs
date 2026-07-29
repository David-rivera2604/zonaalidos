using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.Security.EntraId
{
    public class EntraIdB2BPersonValuesDto
    {
        public string PersonnelNumber { get; set; }
        public string CCC_Numero_Ordinal { get; set; }
        public string CCC_Fecha_Activacion { get; set; }
        public string CCC_Ordinal { get; set; }
        public string CCC_ID_HR_Type { get; set; }
        public string CCC_Id_Funcion { get; set; }
        public string CCC_DES_FUNCION { get; set; }
        public string FirstName { get; set; }
        public string CCC_Apellido1 { get; set; }
        public string CCC_Apellido2 { get; set; }
        public string CCC_Nif { get; set; }
        public string CCC_ID_Tipo_Documento { get; set; }
        public string CCC_ID_Nivel_Puesto { get; set; }
        public string CCC_Nivel_Puesto { get; set; }
        public string PersonalTitle { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string CCC_Provincia { get; set; }
        public string CCC_Pais { get; set; }
        public string CCC_Codigo_Pais { get; set; }
        public string ZIPCode { get; set; }
        public string CCC_ID_Unidad_Negocio { get; set; }
        public string CCC_Unidad_Negocio { get; set; }
        public string CCC_ID_Entidad { get; set; }
        public string CompanyMember { get; set; }
        public string CCC_Responsable { get; set; }
        public string CCC_Departamento { get; set; }
        public string CCC_ID_Departamento { get; set; }
        public string CCC_Reingreso { get; set; }
        public string CCC_Centro_Trabajo { get; set; }
        public string CCC_Nombre_Centro_Trabajo { get; set; }
        public string CCC_Direccion_Larga { get; set; }
        public string CCC_ID_Centro_Coste { get; set; }
        public string CCC_Nombre_Centro_Coste { get; set; }
        public int? Gender { get; set; }
        public string CCC_Fecha_Ultima_Actualizacion { get; set; }
        public string CCC_Cargo { get; set; }
        public string CCC_Concurrencia { get; set; }
        public string CCC_Agencia { get; set; }
        public string Phone { get; set; }
        public string CCC_Phone_Ext { get; set; }
        public string CCC_Email_Ext { get; set; }
        public string CCC_ID_Puesto_Local { get; set; }
        public string CCC_Puesto_Local { get; set; }
        public string CCC_Fecnac { get; set; }
        public string CCC_Fingreso { get; set; }
        public string CCC_Unidad_Negocio_MAPFRE { get; set; }

        public object CCC_Acceso_Correo { get; set; }
        public bool? IsExternal { get; set; }
        public object CCC_Colaborar { get; set; }
        public object CCC_Acceso_Sistemas { get; set; }
        public string CCC_Acceso_App_Cloud { get; set; }
        public bool? IsTemporaryDeactivated { get; set; }
        public bool? IsInActive { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> ExtraValues { get; set; }
    }
}
