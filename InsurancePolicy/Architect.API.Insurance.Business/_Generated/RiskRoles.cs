using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Insurance.Business.Policy
{
    public partial class RiskRoles
    {
        public static Contracts.Policy.RiskRoles Mapper(Contracts.Policy.RiskRoles target, Contracts.Policy.RiskRoles source)
        {
            //target.RoleId = source.RoleId;
            // target.PolicyId = source.PolicyId;
            target.Type = source.Type;
            target.DocumentType = source.DocumentType;
            target.DocumentNumber = source.DocumentNumber;
            target.FirstName = source.FirstName;
            target.MiddleName = source.MiddleName;
            target.LastName = source.LastName;
            target.SecondLastName = source.SecondLastName;
            target.BirthDate = source.BirthDate;
            target.Gender = source.Gender;
            target.CivilStatus = source.CivilStatus;
            target.Height = source.Height;
            target.Weight = source.Weight;
            target.BloodPressureSystolic = source.BloodPressureSystolic;
            target.BloodPressureDiastolic = source.BloodPressureDiastolic;
            target.Occupation = source.Occupation;
            target.RetirementModality = source.RetirementModality;
            target.RetirementCause = source.RetirementCause;
            target.CountryOfNationality = source.CountryOfNationality;
            target.CountryOfBirth = source.CountryOfBirth;
            target.ClientType = source.ClientType;
            target.Relationship = source.Relationship;
            target.ParticipationRate = source.ParticipationRate;
            target.PrimaryEmailAddress = source.PrimaryEmailAddress;
            target.TypeOfAddress = source.TypeOfAddress;
            target.Province = source.Province;
            target.Canton = source.Canton;
            target.District = source.District;
            target.AddressDetail = source.AddressDetail;
            target.PhoneType = source.PhoneType;
            target.PhoneNumber = source.PhoneNumber;
            target.CompanyId = source.CompanyId;
            target.CustomData = source.CustomData;
            target.BankAccount = source.BankAccount;
            target.InclusionDate = source.InclusionDate;
            target.ExclusionDate = source.ExclusionDate;
            target.AgeAtInclusion = source.AgeAtInclusion;
            //target.UpdateUserCode = source.UpdateUserCode;
            //target.UpdateDate = source.UpdateDate;
            return target;
        }
        public static Contracts.Policy.RiskBeneficiaryView Mapper2BeneficiaryView(Contracts.Policy.RiskRoles source, int companyId)
        {
            Contracts.Policy.RiskBeneficiaryView target = null;
            List<Core.Contracts.General.LookupValue> values = null;
            if (source != null)
            {
                target = new Contracts.Policy.RiskBeneficiaryView();
                target.FullName = string.Format("{0} {1} {2} {3}", source.FirstName, source.MiddleName, source.LastName, source.SecondLastName).Trim();
                target.DocumentNumber = source.DocumentNumber;
                target.RelationshipDesc = source.RelationshipDesc;
                target.ParticipationRate = source.ParticipationRate;
                target.Phone = source.PhoneNumber;
                target.Email = source.PrimaryEmailAddress;
                target.FullAddress = string.Empty;
                if (source.Province.IsNotEmpty())
                {
                    values = Core.Business.Common.Lkp("CR_Provincia", companyId);
                    if (target.FullAddress.IsNotEmpty()) {
                        target.FullAddress += ", ";
                    }
                    target.FullAddress += values.Find(x => x.Code == source.Province.ToString()).Description;
                }
                if (source.Canton.IsNotEmpty())
                {
                    values = Core.Business.Common.LkpChild("CR_Canton", source.Province, 0, companyId);
                    if (target.FullAddress.IsNotEmpty())
                    {
                        target.FullAddress += ", ";
                    }
                    target.FullAddress += values.Find(x => x.Code == source.Canton.ToString()).Description;
                }
                if (source.District.IsNotEmpty())
                {
                    values = Core.Business.Common.LkpChild("CR_Distritos", source.Canton, 0, companyId);
                    if (target.FullAddress.IsNotEmpty())
                    {
                        target.FullAddress += ", ";
                    }
                    target.FullAddress += values.Find(x => x.Code == source.District.ToString()).Description;
                }
                if (target.FullAddress.IsNotEmpty())
                {
                    target.FullAddress += ", ";
                }
                target.FullAddress += source.AddressDetail;


            }
            return target;
        }
        public static Contracts.Policy.RiskBeneficiaryInfoView Mapper2View(List<Contracts.Policy.RiskRoles> source, int companyId)
        {
            Contracts.Policy.RiskBeneficiaryInfoView target = new Contracts.Policy.RiskBeneficiaryInfoView();
            target.Beneficiary1 = new Contracts.Policy.RiskBeneficiaryView();
            target.Beneficiary2 = new Contracts.Policy.RiskBeneficiaryView();
            target.Beneficiary3 = new Contracts.Policy.RiskBeneficiaryView();
            target.Beneficiary4 = new Contracts.Policy.RiskBeneficiaryView();
            target.Beneficiary5 = new Contracts.Policy.RiskBeneficiaryView();
            int index = 1;
            foreach (Contracts.Policy.RiskRoles item in source)
            {
                switch (index)
                {
                    case 1:
                        target.Beneficiary1 = Mapper2BeneficiaryView(item,  companyId);
                        break;
                    case 2:
                        target.Beneficiary2 = Mapper2BeneficiaryView(item, companyId);
                        break;
                    case 3:
                        target.Beneficiary3 = Mapper2BeneficiaryView(item, companyId);
                        break;
                    case 4:
                        target.Beneficiary4 = Mapper2BeneficiaryView(item, companyId);
                        break;
                    case 5:
                        target.Beneficiary5 = Mapper2BeneficiaryView(item, companyId);
                        break;
                }
                index++;
            }
            return target;
        }
        public static Contracts.Policy.RiskRolesView Mapper2View(Contracts.Policy.RiskRoles source)
        {
            Contracts.Policy.RiskRolesView target = null;
            if (source != null)
            {
                target = new Contracts.Policy.RiskRolesView();
                target.RoleId = source.RoleId;
                target.PolicyId = source.PolicyId;
                target.Type = source.Type;
                target.DocumentType = source.DocumentType;
                target.DocumentNumber = source.DocumentNumber;
                target.FirstName = source.FirstName;
                target.MiddleName = source.MiddleName;
                target.LastName = source.LastName;
                target.SecondLastName = source.SecondLastName;
                target.FullName = string.Format("{0} {1} {2} {3}", source.FirstName, source.MiddleName, source.LastName, source.SecondLastName).Trim();
                target.BirthDate = source.BirthDate;
                target.Gender = source.Gender;
                target.CivilStatus = source.CivilStatus;
                target.Height = source.Height;
                target.Weight = source.Weight;
                target.BloodPressureSystolic = source.BloodPressureSystolic;
                target.BloodPressureDiastolic = source.BloodPressureDiastolic;
                target.Occupation = source.Occupation;
                target.RetirementModality = source.RetirementModality;
                target.RetirementCause = source.RetirementCause;
                target.CountryOfNationality = source.CountryOfNationality;
                target.CountryOfBirth = source.CountryOfBirth;
                target.ClientType = source.ClientType;
                target.Relationship = source.Relationship;
                target.ParticipationRate = source.ParticipationRate;
                target.PrimaryEmailAddress = source.PrimaryEmailAddress;
                target.TypeOfAddress = source.TypeOfAddress;
                target.Province = source.Province;
                target.Canton = source.Canton;
                target.District = source.District;
                target.AddressDetail = source.AddressDetail;
                target.PhoneType = source.PhoneType;
                target.PhoneNumber = source.PhoneNumber;
                target.UpdateUserCode = source.UpdateUserCode;
                target.UpdateDate = source.UpdateDate;
                target.BankAccount = source.BankAccount;
                target.InclusionDate = source.InclusionDate;
                target.ExclusionDate = source.ExclusionDate;
                target.AgeAtInclusion = source.AgeAtInclusion;
            }
            return target;
        }
    }
}
