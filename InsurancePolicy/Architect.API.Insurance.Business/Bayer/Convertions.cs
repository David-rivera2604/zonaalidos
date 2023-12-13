using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Insurance.Business.Bayer
{
    /// <summary>
    /// Procesamiento de las solicitudes de inclusión
    /// </summary>
    internal static class Convertions
    {

        /// <summary>
        /// Convierte la planilla de requerimiento a un objeto tipo póliza.
        /// </summary>
        internal static Contracts.Policy.Risk InclusionToRisk(Contracts.Bayer.InclusionRequest inclusionInfo)
        {
            return new Contracts.Policy.Risk()
            {
                Id = inclusionInfo.Id,
                CompanyId = 0,
                OriginType = 0,
                LineOfBusinessCode = 1,
                ProductCode = 0,
                PolicyId = 0,
                Currency = 0,
                ModuleCode = 0,
                PaymentFrequency = 0,
                IssueDate = inclusionInfo.IssueDate,
                EffectiveDate = inclusionInfo.EffectiveDate,
                EndingDate = DateTime.MinValue,
                InsuredAmount = inclusionInfo.InsuredAmount,
                AnnualPremium = 0,
                MonthlyPremium = 0,
                Surcharge = 0,
                Status = 2,
                CancellationDate = DateTime.MinValue,
                ReasonForStatus = 0,
                CertificateId = 0,
                Comments = string.Empty,
                Reference = string.Empty,
                BranchOffice = 0,
                ExecutiveUserCode = 0,
                ProductAlias = string.Empty,
                CustomData = string.Empty,
                PrimaryInsured = null,
                Beneficiaries = null,
            };

        }

        /// <summary>
        /// Convierte la planilla de requerimiento a un objeto tipo asegurado principal.
        /// </summary>
        internal static Contracts.Policy.RiskRoles InclusionToPrimaryInsured(Contracts.Bayer.InclusionRequest inclusionInfo)
        {
            return new Contracts.Policy.RiskRoles()
            {
                RoleId = 2,
                CompanyId = 0,
                PolicyId = inclusionInfo.Id,
                Type = 2,
                DocumentType = inclusionInfo.DocumentType,
                DocumentNumber = inclusionInfo.DocumentNumber,
                FirstName = inclusionInfo.FirstName,
                MiddleName = string.Empty,
                LastName = inclusionInfo.LastName,
                SecondLastName = string.Empty,
                BirthDate = inclusionInfo.BirthDate,
                Gender = inclusionInfo.Gender,
                CivilStatus = inclusionInfo.CivilStatus,
                Height = inclusionInfo.Height,
                Weight = inclusionInfo.Weight,
                BloodPressureSystolic = 0,
                BloodPressureDiastolic = 0,
                Occupation = inclusionInfo.Occupation,
                RetirementModality = 0,
                RetirementCause = string.Empty,
                CountryOfNationality = inclusionInfo.CountryOfNationality,
                CountryOfBirth = 0,
                ClientType = 0,
                Relationship = 0,
                ParticipationRate = 0,
                PrimaryEmailAddress = inclusionInfo.PrimaryEmailAddress,
                TypeOfAddress = 0,
                Province = inclusionInfo.Province,
                Canton = inclusionInfo.Canton,
                District = inclusionInfo.District,
                AddressDetail = inclusionInfo.AddressDetail,
                PhoneType = inclusionInfo.PhoneType,
                PhoneNumber = inclusionInfo.PhoneNumber,
                BankAccount = string.Empty,
                InclusionDate = DateTime.MinValue,
                ExclusionDate = DateTime.MinValue,
                AgeAtInclusion = 0,
                CustomData = string.Empty
            };
        }

        /// <summary>
        /// Convierte la planilla de requerimiento a un objeto tipo información particular de bayer.
        /// </summary>
        internal static Contracts.Policy.RiskBayer InclusionToRiskBayer(int companyId, Contracts.Bayer.InclusionRequest inclusionInfo)
        {
            return new Contracts.Policy.RiskBayer()
            {
                Id = inclusionInfo.Id,
                MainPolicyId = inclusionInfo.MainPolicyId,
                IssueDate = inclusionInfo.IssueDate,
                ContractorName = inclusionInfo.ContractorName,
                ContractorDesc = Core.Business.Common.LkpDescription(companyId, "BayerPolizas", inclusionInfo.ContractorName),
                IsLife = inclusionInfo.IsLife,
                IsHealth = inclusionInfo.IsHealth,
                SocialSecurity = inclusionInfo.SocialSecurity,
                DominantMember = inclusionInfo.DominantMember,
                DateEntryWork = inclusionInfo.DateEntryWork,
                MonthlySalary = inclusionInfo.MonthlySalary,
                ContinuityDate = inclusionInfo.ContinuityDate,
                HasDigitalSignature = inclusionInfo.HasDigitalSignature,
                Doctor = inclusionInfo.Doctor,
                RefundBankCode = inclusionInfo.RefundBankCode,
                RefundBankAccount = inclusionInfo.RefundBankAccount,
                RefundBankAccountType = inclusionInfo.RefundBankAccountType,
                RefundBankAccountCurrency = inclusionInfo.RefundBankAccountCurrency,
                EmployeeNumber = inclusionInfo.EmployeeNumber,
                UpdateUserCode = 0,
                UpdateDate = DateTime.MinValue
            };

        }

        /// <summary>
        /// Convierte la planilla de requerimiento a un objeto tipo beneficiario.
        /// </summary>
        internal static Contracts.Policy.RiskRoles InclusionToBeneficiary(Contracts.Bayer.Beneficiario beneficiario)
        {
            return new Contracts.Policy.RiskRoles()
            {
                RoleId = 0,
                CompanyId = 0,
                PolicyId = 0,
                Type = 100,
                DocumentType = 0,
                DocumentNumber = beneficiario.BDocumentNumber,
                FirstName = beneficiario.BFirstName,
                MiddleName = string.Empty,
                LastName = beneficiario.BLastName,
                SecondLastName = string.Empty,
                BirthDate = beneficiario.BBirthDate,
                Gender = 0,
                CivilStatus = 0,
                Height = 0,
                Weight = 0,
                BloodPressureSystolic = 0,
                BloodPressureDiastolic = 0,
                Occupation = string.Empty,
                RetirementModality = 0,
                RetirementCause = string.Empty,
                CountryOfNationality = 0,
                CountryOfBirth = 0,
                ClientType = 0,
                Relationship = beneficiario.BRelationship,
                ParticipationRate = beneficiario.BParticipationRate,
                PrimaryEmailAddress = string.Empty,
                TypeOfAddress = 0,
                Province = 0,
                Canton = 0,
                District = 0,
                AddressDetail = string.Empty,
                PhoneType = 0,
                PhoneNumber = string.Empty,
                BankAccount = string.Empty,
                InclusionDate = DateTime.MinValue,
                ExclusionDate = DateTime.MinValue,
                AgeAtInclusion = 0,
                CustomData = string.Empty
            };
        }

        /// <summary>
        /// Convierte la planilla de requerimiento a un objeto tipo dependiente.
        /// </summary>
        internal static Contracts.Policy.RiskRoles InclusionToDependiente(Contracts.Bayer.Dependiente dependiente)
        {
            return new Contracts.Policy.RiskRoles()
            {
                RoleId = 0,
                CompanyId = 0,
                PolicyId = 0,
                Type = 90,
                DocumentType = 0,
                DocumentNumber = dependiente.DDocumentNumber,
                FirstName = dependiente.DFirstName,
                MiddleName = string.Empty,
                LastName = dependiente.DLastName,
                SecondLastName = string.Empty,
                BirthDate = dependiente.DBirthDate,
                Gender = 0,
                CivilStatus = 0,
                Height = 0,
                Weight = 0,
                BloodPressureSystolic = 0,
                BloodPressureDiastolic = 0,
                Occupation = string.Empty,
                RetirementModality = 0,
                RetirementCause = string.Empty,
                CountryOfNationality = 0,
                CountryOfBirth = 0,
                ClientType = 0,
                Relationship = dependiente.DRelationship,
                ParticipationRate = 0,
                PrimaryEmailAddress = string.Empty,
                TypeOfAddress = 0,
                Province = 0,
                Canton = 0,
                District = 0,
                AddressDetail = string.Empty,
                PhoneType = 0,
                PhoneNumber = string.Empty,
                BankAccount = string.Empty,
                InclusionDate = dependiente.DInclusionDate,
                ExclusionDate = DateTime.MinValue,
                AgeAtInclusion = 0,
                CustomData = string.Empty
            };
        }


        /// <summary>
        /// Convierte un objeto tipo poliza a un tipo planilla de requerimiento.
        /// </summary>
        internal static Contracts.Bayer.InclusionRequest RiskToInclusion(Contracts.Policy.Risk risk)
        {
            return new Contracts.Bayer.InclusionRequest()
            {
                Id = risk.Id,
                IssueDate = risk.IssueDate,
                EffectiveDate = risk.EffectiveDate,
                InsuredAmount = risk.InsuredAmount,
                Status = risk.Status,
                StatusDesc = risk.StatusDesc,
                Reference = risk.Reference
            };
        }

        /// <summary>
        /// Convierte un objeto tipo asegurado principal a un tipo planilla de requerimiento.
        /// </summary>
        internal static Contracts.Bayer.InclusionRequest PrimaryInsuredToInclusion(Contracts.Policy.Risk risk, Contracts.Bayer.InclusionRequest inclusionInfo)
        {
            inclusionInfo.DocumentType = risk.PrimaryInsured.DocumentType;
            inclusionInfo.DocumentNumber = risk.PrimaryInsured.DocumentNumber;
            inclusionInfo.FirstName = risk.PrimaryInsured.FirstName;
            inclusionInfo.LastName = risk.PrimaryInsured.LastName;
            inclusionInfo.BirthDate = risk.PrimaryInsured.BirthDate;
            inclusionInfo.Gender = risk.PrimaryInsured.Gender;
            inclusionInfo.CivilStatus = risk.PrimaryInsured.CivilStatus;
            inclusionInfo.Height = risk.PrimaryInsured.Height;
            inclusionInfo.Weight = risk.PrimaryInsured.Weight;
            inclusionInfo.Occupation = risk.PrimaryInsured.Occupation;
            inclusionInfo.CountryOfNationality = risk.PrimaryInsured.CountryOfNationality;
            inclusionInfo.PrimaryEmailAddress = risk.PrimaryInsured.PrimaryEmailAddress;
            inclusionInfo.Province = risk.PrimaryInsured.Province;
            inclusionInfo.Canton = risk.PrimaryInsured.Canton;
            inclusionInfo.District = risk.PrimaryInsured.District;
            inclusionInfo.AddressDetail = risk.PrimaryInsured.AddressDetail;
            inclusionInfo.PhoneType = risk.PrimaryInsured.PhoneType;
            inclusionInfo.PhoneNumber = risk.PrimaryInsured.PhoneNumber;

            return inclusionInfo;
        }

        /// <summary>
        /// Convierte un objeto tipo información particular de bayer a un tipo planilla de requerimiento.
        /// </summary>
        internal static Contracts.Bayer.InclusionRequest RiskBayerToInclusion(Contracts.Policy.RiskBayer riskBayer, Contracts.Bayer.InclusionRequest inclusionInfo)
        {

            inclusionInfo.MainPolicyId = riskBayer.MainPolicyId;
            inclusionInfo.IssueDate = riskBayer.IssueDate;
            inclusionInfo.ContractorName = riskBayer.ContractorName;
            inclusionInfo.IsLife = riskBayer.IsLife;
            inclusionInfo.IsHealth = riskBayer.IsHealth;
            inclusionInfo.SocialSecurity = riskBayer.SocialSecurity;
            inclusionInfo.DominantMember = riskBayer.DominantMember;
            inclusionInfo.DateEntryWork = riskBayer.DateEntryWork;
            inclusionInfo.MonthlySalary = riskBayer.MonthlySalary;
            inclusionInfo.ContinuityDate = riskBayer.ContinuityDate;
            inclusionInfo.HasDigitalSignature = riskBayer.HasDigitalSignature;
            inclusionInfo.Doctor = riskBayer.Doctor;
            inclusionInfo.RefundBankCode = riskBayer.RefundBankCode;
            inclusionInfo.RefundBankAccount = riskBayer.RefundBankAccount;
            inclusionInfo.RefundBankAccountType = riskBayer.RefundBankAccountType;
            inclusionInfo.RefundBankAccountCurrency = riskBayer.RefundBankAccountCurrency;
            inclusionInfo.EmployeeNumber = riskBayer.EmployeeNumber;


            return inclusionInfo;

        }

        /// <summary>
        /// Convierte una lista de roles de la pólizas a una lista de beneficiarrio para la planilla de requerimiento.
        /// </summary>
        internal static List<Contracts.Bayer.Beneficiario> BeneficiaryToInclusion(List<Contracts.Policy.RiskRoles> beneficiaries)
        {
            List<Contracts.Bayer.Beneficiario> result = null;

            if (beneficiaries.IsNotEmpty())
            {
                foreach (Contracts.Policy.RiskRoles beneficiario in beneficiaries.Where(s => s.Type == 100))
                {
                    if (result.IsEmpty())
                    {
                        result = new List<Contracts.Bayer.Beneficiario>();
                    }
                    result.Add(new Contracts.Bayer.Beneficiario()
                    {
                        beneficiariosId = beneficiario.RoleId,
                        BDocumentType = beneficiario.DocumentType,
                        BDocumentNumber = beneficiario.DocumentNumber,
                        BFirstName = beneficiario.FirstName,
                        BLastName = beneficiario.LastName,
                        BBirthDate = beneficiario.BirthDate,
                        BRelationship = beneficiario.Relationship,
                        BRelationshipDesc = beneficiario.RelationshipDesc,
                        BParticipationRate = beneficiario.ParticipationRate
                    });
                }
            }
            return result;
        }

        /// <summary>
        /// Convierte una lista de roles de la pólizas a una lista de dependientes para la planilla de requerimiento.
        /// </summary>
        internal static List<Contracts.Bayer.Dependiente> DependencyToInclusion(List<Contracts.Policy.RiskRoles> dependencies)
        {
            List<Contracts.Bayer.Dependiente> result = null;

            if (dependencies.IsNotEmpty())
            {
                foreach (Contracts.Policy.RiskRoles beneficiario in dependencies.Where(s => s.Type == 90))
                {
                    if (result.IsEmpty())
                    {
                        result = new List<Contracts.Bayer.Dependiente>();
                    }
                    result.Add(new Contracts.Bayer.Dependiente()
                    {
                        dependientesId = beneficiario.RoleId,
                        DDocumentType = beneficiario.DocumentType,
                        DDocumentNumber = beneficiario.DocumentNumber,
                        DFirstName = beneficiario.FirstName,
                        DLastName = beneficiario.LastName,
                        DBirthDate = beneficiario.BirthDate,
                        DRelationship = beneficiario.Relationship,
                        DRelationshipDesc = beneficiario.RelationshipDesc,
                        DInclusionDate = beneficiario.InclusionDate
                    });
                }
            }
            return result;
        }

    }
}
