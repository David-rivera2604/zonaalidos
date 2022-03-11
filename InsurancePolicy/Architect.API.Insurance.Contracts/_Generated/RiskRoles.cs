using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Información de asegurados y/o beneficiarios de una póliza.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class RiskRoles
    {
        /// <summary>
        /// Identificación única del rol.
        /// </summary>
        [DataMember(), JsonProperty()] public int RoleId { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Identificación única de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int PolicyId { get; set; }
        /// <summary>
        /// Tipo de rol. 2 Asegurado, 3 Beneficiarios
        /// </summary>
        [DataMember(), JsonProperty()] public int Type { get; set; }
        /// <summary>
        /// Tipo de documento.
        /// </summary>
        [DataMember(), JsonProperty()] public int DocumentType { get; set; }
        /// <summary>
        /// Descripción para tipo de documento.
        /// </summary>
        [DataMember(), JsonProperty()] public string DocumentTypeDesc { get; set; }
        /// <summary>
        /// Documento o número de identificación.
        /// </summary>
        [DataMember(), JsonProperty()] public string DocumentNumber { get; set; }
        /// <summary>
        /// Primer nombre.
        /// </summary>
        [DataMember(), JsonProperty()] public string FirstName { get; set; }
        /// <summary>
        /// Segundo nombre.
        /// </summary>
        [DataMember(), JsonProperty()] public string MiddleName { get; set; }
        /// <summary>
        /// Primer apellido.
        /// </summary>
        [DataMember(), JsonProperty()] public string LastName { get; set; }
        /// <summary>
        /// Segundo apellido.
        /// </summary>
        [DataMember(), JsonProperty()] public string SecondLastName { get; set; }
        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime BirthDate { get; set; }
        /// <summary>
        /// Sexo.
        /// </summary>
        [DataMember(), JsonProperty()] public int Gender { get; set; }
        /// <summary>
        /// Descripción para sexo.
        /// </summary>
        [DataMember(), JsonProperty()] public string GenderDesc { get; set; }
        /// <summary>
        /// Estado civil.
        /// </summary>
        [DataMember(), JsonProperty()] public int CivilStatus { get; set; }
        /// <summary>
        /// Descripción para estado civil.
        /// </summary>
        [DataMember(), JsonProperty()] public string CivilStatusDesc { get; set; }
        /// <summary>
        /// Estatura.
        /// </summary>
        [DataMember(), JsonProperty()] public double Height { get; set; }
        /// <summary>
        /// Peso.
        /// </summary>
        [DataMember(), JsonProperty()] public double Weight { get; set; }
        /// <summary>
        /// Presión arterial sistólica.
        /// </summary>
        [DataMember(), JsonProperty()] public int BloodPressureSystolic { get; set; }
        /// <summary>
        /// Presión arterial diastólica.
        /// </summary>
        [DataMember(), JsonProperty()] public int BloodPressureDiastolic { get; set; }
        /// <summary>
        /// Ocupación.
        /// </summary>
        [DataMember(), JsonProperty()] public string Occupation { get; set; }
        /// <summary>
        /// Condición de retiro.
        /// </summary>
        [DataMember(), JsonProperty()] public int RetirementModality { get; set; }
        /// <summary>
        /// Descripción para condición de retiro.
        /// </summary>
        [DataMember(), JsonProperty()] public string RetirementModalityDesc { get; set; }
        /// <summary>
        /// Causa del pensionamiento
        /// </summary>
        [DataMember(), JsonProperty()] public string RetirementCause { get; set; }
        /// <summary>
        /// País de nacionalidad.
        /// </summary>
        [DataMember(), JsonProperty()] public int CountryOfNationality { get; set; }
        /// <summary>
        /// Descripción para país de nacionalidad.
        /// </summary>
        [DataMember(), JsonProperty()] public string CountryOfNationalityDesc { get; set; }
        /// <summary>
        /// País de nacimiento.
        /// </summary>
        [DataMember(), JsonProperty()] public int CountryOfBirth { get; set; }
        /// <summary>
        /// Descripción para país de nacimiento.
        /// </summary>
        [DataMember(), JsonProperty()] public string CountryOfBirthDesc { get; set; }
        /// <summary>
        /// Lkp: Interno, Corporativo y externo
        /// </summary>
        [DataMember(), JsonProperty()] public int ClientType { get; set; }
        /// <summary>
        /// Descripción para lkp: interno, corporativo y externo
        /// </summary>
        [DataMember(), JsonProperty()] public string ClientTypeDesc { get; set; }
        /// <summary>
        /// Parentesco de los beneficiarios.
        /// </summary>
        [DataMember(), JsonProperty()] public int Relationship { get; set; }
        /// <summary>
        /// Descripción para parentesco de los beneficiarios.
        /// </summary>
        [DataMember(), JsonProperty()] public string RelationshipDesc { get; set; }
        /// <summary>
        /// Porcentaje de participación del beneficiario.
        /// </summary>
        [DataMember(), JsonProperty()] public int ParticipationRate { get; set; }
        /// <summary>
        /// Dirección de correo electrónico (principal)
        /// </summary>
        [DataMember(), JsonProperty()] public string PrimaryEmailAddress { get; set; }
        /// <summary>
        /// Tipo dirección.
        /// </summary>
        [DataMember(), JsonProperty()] public int TypeOfAddress { get; set; }
        /// <summary>
        /// Descripción para tipo dirección.
        /// </summary>
        [DataMember(), JsonProperty()] public string TypeOfAddressDesc { get; set; }
        /// <summary>
        /// Provincia.
        /// </summary>
        [DataMember(), JsonProperty()] public int Province { get; set; }
        /// <summary>
        /// Descripción para provincia.
        /// </summary>
        [DataMember(), JsonProperty()] public string ProvinceDesc { get; set; }
        /// <summary>
        /// Cantón.
        /// </summary>
        [DataMember(), JsonProperty()] public int Canton { get; set; }
        /// <summary>
        /// Descripción para cantón.
        /// </summary>
        [DataMember(), JsonProperty()] public string CantonDesc { get; set; }
        /// <summary>
        /// Distrito.
        /// </summary>
        [DataMember(), JsonProperty()] public int District { get; set; }
        /// <summary>
        /// Descripción para distrito.
        /// </summary>
        [DataMember(), JsonProperty()] public string DistrictDesc { get; set; }
        /// <summary>
        /// Dirección.
        /// </summary>
        [DataMember(), JsonProperty()] public string AddressDetail { get; set; }
        /// <summary>
        /// Tipo de teléfono.
        /// </summary>
        [DataMember(), JsonProperty()] public int PhoneType { get; set; }
        /// <summary>
        /// Descripción para tipo de teléfono.
        /// </summary>
        [DataMember(), JsonProperty()] public string PhoneTypeDesc { get; set; }
        /// <summary>
        /// Número de teléfono.
        /// </summary>
        [DataMember(), JsonProperty()] public string PhoneNumber { get; set; }
        /// <summary>
        /// Tipo de teléfono secundario.
        /// </summary>
        [DataMember(), JsonProperty()] public int SecondaryPhoneType { get; set; }
        /// <summary>
        /// Número de teléfono secundario.
        /// </summary>
        [DataMember(), JsonProperty()] public string SeondaryPhoneNumber { get; set; }
        /// <summary>
        /// Número de cuenta bancaria.
        /// </summary>
        [DataMember(), JsonProperty()] public string BankAccount { get; set; }
        /// <summary>
        /// Fecha de inclusión.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime InclusionDate { get; set; }
        /// <summary>
        /// Fecha de exclusión.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime ExclusionDate { get; set; }
        /// <summary>
        /// Edad en la inclusión.
        /// </summary>
        [DataMember(), JsonProperty()] public int AgeAtInclusion { get; set; }
        /// <summary>
        /// Identificado de uso genérico.
        /// </summary>
        [DataMember(), JsonProperty()] public string Reference { get; set; }
        /// <summary>
        /// Datos personalizables.
        /// </summary>
        [DataMember(), JsonProperty()] public string CustomData { get; set; }
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

