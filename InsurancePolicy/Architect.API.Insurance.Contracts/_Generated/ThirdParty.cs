using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Información centralizada de terceros (personas y empresas). (OJO)
    /// </summary>
    [Serializable(), DataContract()]
    public partial class ThirdParty
    {
        /// <summary>
        /// Identificación única del rol.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
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
        /// Dirección de correo electrónico (principal)
        /// </summary>
        [DataMember(), JsonProperty()] public string PrimaryEmailAddress { get; set; }
        /// <summary>
        /// Dirección de correo electrónico (complemento)
        /// </summary>
        [DataMember(), JsonProperty()] public string SecondaryEmailAddress { get; set; }
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
        /// Número de teléfono del celular.
        /// </summary>
        [DataMember(), JsonProperty()] public string PhoneNumberMobile { get; set; }
        /// <summary>
        /// Número de teléfono de la casa.
        /// </summary>
        [DataMember(), JsonProperty()] public string PhoneNumberHome { get; set; }
        /// <summary>
        /// Número de teléfono del trabajo.
        /// </summary>
        [DataMember(), JsonProperty()] public string PhoneNumberOffice { get; set; }
        /// <summary>
        /// Fecha de inclusión.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime InclusionDate { get; set; }
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
        [DataMember(), JsonProperty()] public int ThirdPartyType { get; set; }
        [DataMember(), JsonProperty()] public string ThirdPartyCode { get; set; }
    }
}

