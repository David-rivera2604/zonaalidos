using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Información de un asegurado.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class Insured
    {
        /// <summary>
        /// Tipo de documento.
        /// </summary>
        /// <remarks>Lookup: DocumentType [2100].
        /// 1	Cédula nacional
        /// 2	Cédula de residencia
        /// 3	Pasaporte
        /// 4	Cédula jurídica
        /// </remarks>
        [DataMember(), JsonProperty()] public int DocumentType { get; set; }
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
        /// Nombre completo.
        /// </summary>
        [DataMember(), JsonProperty()] public string FullName { get; set; }
        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime BirthDate { get; set; }
        /// <summary>
        /// Sexo.
        /// </summary>
        /// <remarks>Lookup: Gender [2101].
        /// 1	Masculino
        /// 2	Femenino
        /// </remarks>
        [DataMember(), JsonProperty()] public int Gender { get; set; }
        /// <summary>
        /// Estado civil.
        /// </summary>
        /// <remarks>Lookup: CivilStatus [2103].
        /// 1	Casado(a)
        /// 2	Divorciado(a)
        /// 3	Soltero(a)
        /// 4	Viudo(a)
        /// 5	Otro
        /// 7	Acompañado(a)
        /// </remarks>
        [DataMember(), JsonProperty()] public int CivilStatus { get; set; }
        /// <summary>
        /// Dirección de correo electrónico (principal)
        /// </summary>
        [DataMember(), JsonProperty()] public string PrimaryEmailAddress { get; set; }
        /// <summary>
        /// Provincia.
        /// </summary>
        /// <remarks>Lookup: CR_Provincia [1001].</remarks>
        [DataMember(), JsonProperty()] public int Province { get; set; }
        /// <summary>
        /// Cantón.
        /// </summary>
        /// <remarks>Lookup: CR_Canton [1002].</remarks>
        [DataMember(), JsonProperty()] public int Canton { get; set; }
        /// <summary>
        /// Distrito.
        /// </summary>
        /// <remarks>Lookup: CR_Distritos [1003].</remarks>
        [DataMember(), JsonProperty()] public int District { get; set; }
        /// <summary>
        /// Dirección.
        /// </summary>
        [DataMember(), JsonProperty()] public string AddressDetail { get; set; }
        /// <summary>
        /// Tipo de teléfono.
        /// </summary>
        /// <remarks>Lookup: PhoneType [2109].
        /// 1	Celular
        /// 2	Habitación
        /// 3	Oficina
        /// 4	Fax
        /// </remarks>
        [DataMember(), JsonProperty()] public int PhoneType { get; set; }
        /// <summary>
        /// Número de teléfono.
        /// </summary>
        [DataMember(), JsonProperty()] public string PhoneNumber { get; set; }

        /// <summary>
        /// País de nacionalidad.
        /// </summary>
        [DataMember(), JsonProperty()] public int CountryOfNationality { get; set; }
        [DataMember(), JsonProperty()] public string CountryOfNationalityISO { get; set; }
        [DataMember(), JsonProperty()] public string Source { get; set; }
    }
}