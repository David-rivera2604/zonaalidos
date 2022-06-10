using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Bayer
{
    /// <summary>
    /// Solicitud de inclusión
    /// </summary>
    public class InclusionRequest : Base.Policy
    {

        /// <summary>
        /// N° de póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string MainPolicyId { get; set; }
        /// <summary>
        /// Nombre del contratante.
        /// </summary>
        [DataMember(), JsonProperty()] public string ContractorName { get; set; }

        /// <summary>
        /// Descripción del contratante.
        /// </summary>
        [DataMember(), JsonProperty()] public string ContractorDesc { get; set; }

        /// <summary>
        /// Fecha de ingreso a póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime IssueDate { get; set; }
        /// <summary>
        /// Vida.
        /// </summary>
        [DataMember(), JsonProperty()] public string IsLife { get; set; }
        /// <summary>
        /// Salud.
        /// </summary>
        [DataMember(), JsonProperty()] public string IsHealth { get; set; }
        /// <summary>
        /// Tipo de identificación.
        /// </summary>
        [DataMember(), JsonProperty()] public int DocumentType { get; set; }
        /// <summary>
        /// Identificación.
        /// </summary>
        [DataMember(), JsonProperty()] public string DocumentNumber { get; set; }
        /// <summary>
        /// Nombres.
        /// </summary>
        [DataMember(), JsonProperty()] public string FirstName { get; set; }
        /// <summary>
        /// Apellidos.
        /// </summary>
        [DataMember(), JsonProperty()] public string LastName { get; set; }
        /// <summary>
        /// Sexo.
        /// </summary>
        [DataMember(), JsonProperty()] public int Gender { get; set; }
        /// <summary>
        /// Descripción del código del sexo.
        /// </summary>
        [DataMember(), JsonProperty()] public string GenderDesc { get; set; }
        /// <summary>
        /// Fecha de nacimiento.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime BirthDate { get; set; }
        /// <summary>
        /// Nacionalidad.
        /// </summary>
        [DataMember(), JsonProperty()] public int CountryOfNationality { get; set; }
        /// <summary>
        /// Descripción del código de la nacionalidad.
        /// </summary>
        [DataMember(), JsonProperty()] public string CountryOfNationalityDesc { get; set; }
        /// <summary>
        /// Seguro Social.
        /// </summary>
        [DataMember(), JsonProperty()] public string SocialSecurity { get; set; }
        /// <summary>
        /// Miembro dominante.
        /// </summary>
        [DataMember(), JsonProperty()] public int DominantMember { get; set; }
        /// <summary>
        /// Tipo de teléfono.
        /// </summary>
        [DataMember(), JsonProperty()] public int PhoneType { get; set; }
        /// <summary>
        /// Teléfono.
        /// </summary>
        [DataMember(), JsonProperty()] public string PhoneNumber { get; set; }
        /// <summary>
        /// Fecha de Ingreso a trabajar.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime DateEntryWork { get; set; }
        /// <summary>
        /// Estado civil.
        /// </summary>
        [DataMember(), JsonProperty()] public int CivilStatus { get; set; }
        /// <summary>
        /// Descripción del código del Estado civil.
        /// </summary>
        [DataMember(), JsonProperty()] public string CivilStatusDesc { get; set; }
        /// <summary>
        /// Salario mensual.
        /// </summary>
        [DataMember(), JsonProperty()] public double MonthlySalary { get; set; }
        /// <summary>
        /// Correo electrónico.
        /// </summary>
        [DataMember(), JsonProperty()] public string PrimaryEmailAddress { get; set; }
        /// <summary>
        /// Ocupación.
        /// </summary>
        [DataMember(), JsonProperty()] public string Occupation { get; set; }
        /// <summary>
        /// Estatura.
        /// </summary>
        [DataMember(), JsonProperty()] public double Height { get; set; }
        /// <summary>
        /// Peso.
        /// </summary>
        [DataMember(), JsonProperty()] public double Weight { get; set; }
        /// <summary>
        /// Suma asegurada.
        /// </summary>
        [DataMember(), JsonProperty()] public double InsuredAmount { get; set; }
        /// <summary>
        /// Médico de cabecera.
        /// </summary>
        [DataMember(), JsonProperty()] public string Doctor { get; set; }
        /// <summary>
        /// Provincia.
        /// </summary>
        [DataMember(), JsonProperty()] public int Province { get; set; }
        /// <summary>
        /// Descripción de la Provincia.
        /// </summary>
        [DataMember(), JsonProperty()] public string ProvinceDesc { get; set; }
        /// <summary>
        /// Cantón.
        /// </summary>
        [DataMember(), JsonProperty()] public int Canton { get; set; }
        /// <summary>
        /// Descripción del Cantón.
        /// </summary>
        [DataMember(), JsonProperty()] public string CantonDesc { get; set; }
        /// <summary>
        /// Distrito.
        /// </summary>
        [DataMember(), JsonProperty()] public int District { get; set; }
        /// <summary>
        /// Descripción del Distrito.
        /// </summary>
        [DataMember(), JsonProperty()] public string DistrictDesc { get; set; }
        /// <summary>
        /// Dirección.
        /// </summary>
        [DataMember(), JsonProperty()] public string AddressDetail { get; set; }
        /// <summary>
        /// Banco.
        /// </summary>
        [DataMember(), JsonProperty()] public int RefundBankCode { get; set; }
        /// <summary>
        /// Descripción del Banco.
        /// </summary>
        [DataMember(), JsonProperty()] public string RefundBankDesc { get; set; }
        /// <summary>
        /// N° cuenta SINPE.
        /// </summary>
        [DataMember(), JsonProperty()] public string RefundBankAccount { get; set; }
        /// <summary>
        /// Tipo de cuenta.
        /// </summary>
        [DataMember(), JsonProperty()] public int RefundBankAccountType { get; set; }
        /// <summary>
        /// Moneda de cuenta.
        /// </summary>
        [DataMember(), JsonProperty()] public int RefundBankAccountCurrency { get; set; }
        /// <summary>
        /// Modo.
        /// </summary>
        [DataMember(), JsonProperty()] public List<Beneficiario> beneficiarios { get; set; }
        /// <summary>
        /// Modo.
        /// </summary>
        [DataMember(), JsonProperty()] public List<Dependiente> Dependientes { get; set; }

        /// <summary>
        /// Indica que el usuario quiere firma de forma digital la solicitud
        /// </summary>
        [DataMember(), JsonProperty()] public bool HasDigitalSignature { get; set; }

        /// <summary>
        /// Fecha de continuidad.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime ContinuityDate { get; set; }

        /// <summary>
        /// Número de empleado
        /// </summary>
        [DataMember(), JsonProperty()] public string EmployeeNumber { get; set; }

    }

    /// <summary>
    /// Beneficiarios de la solictud de inclusión
    /// </summary>
    public class Beneficiario
    {

        /// <summary>
        /// Identificación única.
        /// </summary>
        [DataMember(), JsonProperty()] public int beneficiariosId { get; set; }

        /// <summary>
        /// Tipo de identificación.
        /// </summary>
        [DataMember(), JsonProperty()] public int BDocumentType { get; set; }
        /// <summary>
        /// Identificación.
        /// </summary>
        [DataMember(), JsonProperty()] public string BDocumentNumber { get; set; }
        /// <summary>
        /// Nombres.
        /// </summary>
        [DataMember(), JsonProperty()] public string BFirstName { get; set; }
        /// <summary>
        /// Apellidos.
        /// </summary>
        [DataMember(), JsonProperty()] public string BLastName { get; set; }
        /// <summary>
        /// Fecha de nacimiento.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime BBirthDate { get; set; }
        /// <summary>
        /// Parentesco.
        /// </summary>
        [DataMember(), JsonProperty()] public int BRelationship { get; set; }
        /// <summary>
        /// Descripción del parentesco.
        /// </summary>
        [DataMember(), JsonProperty()] public string BRelationshipDesc { get; set; }
        /// <summary>
        /// Porcentaje.
        /// </summary>
        [DataMember(), JsonProperty()] public int BParticipationRate { get; set; }


    }

    /// <summary>
    /// Dependientes de la solictud de inclusión
    /// </summary>
    public class Dependiente
    {

        /// <summary>
        /// Identificación única.
        /// </summary>
        [DataMember(), JsonProperty()] public int dependientesId { get; set; }

        /// <summary>
        /// Tipo de identificación.
        /// </summary>
        [DataMember(), JsonProperty()] public int DDocumentType { get; set; }
        /// <summary>
        /// Identificación.
        /// </summary>
        [DataMember(), JsonProperty()] public string DDocumentNumber { get; set; }
        /// <summary>
        /// Nombres.
        /// </summary>
        [DataMember(), JsonProperty()] public string DFirstName { get; set; }
        /// <summary>
        /// Apellidos.
        /// </summary>
        [DataMember(), JsonProperty()] public string DLastName { get; set; }
        /// <summary>
        /// Fecha de nacimiento.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime DBirthDate { get; set; }
        /// <summary>
        /// Parentesco.
        /// </summary>
        [DataMember(), JsonProperty()] public int DRelationship { get; set; }
        /// <summary>
        /// Descripción del parentesco.
        /// </summary>
        [DataMember(), JsonProperty()] public string DRelationshipDesc { get; set; }

        /// <summary>
        /// Fecha de inclusión.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime DInclusionDate { get; set; }


    }


}
