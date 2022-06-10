using Architect.Utilities.Extensions;
using System.Collections.Generic;

namespace Architect.API.Insurance.Business.Policy
{
    public static partial class RiskRoles
    {
        public static List<Core.Contracts.General.Error> Validate(Contracts.Policy.RiskRoles source,
                                                                  string group,
                                                                  int companyId,
                                                                  Contracts.Policy.Risk risk)
        {
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();
            string prefix = string.Empty;

            if (source.Type == 100)
            {
                prefix = "B";
            }

            //DocumentType:
            if (source.DocumentType.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error()
                { Group = group, Key = prefix + "DocumentType", Message = "Debe indicar el tipo de identificación" });
            }

            //DocumentNumber:
            if (source.DocumentNumber.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error()
                { Group = group, Key = prefix + "DocumentNumber", Message = "Debe indicar la identificación" });
            }
            if (source.Type == 2 && source.DocumentType.IsNotEmpty() && source.DocumentNumber.IsNotEmpty())
            {
                if (Risk.RetrieveByDocumentNumber(companyId,
                                                  risk.LineOfBusinessCode,
                                                  risk.ProductCode,
                                                  risk.Id,
                                                  source.DocumentType,
                                                  source.DocumentNumber) != null)
                {
                    result.Add(new Core.Contracts.General.Error()
                    {
                        Group = group,
                        Key = prefix + "DocumentNumber",
                        Message = "El asegurado ya tiene registrada una póliza para este producto"
                    });
                }
            }

            //FirstName:
            if (source.FirstName.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error()
                { Group = group, Key = prefix + "FirstName", Message = "Debe indicar el primer nombre" });
            }

            //LastName:
            if (source.LastName.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error()
                { Group = group, Key = prefix + "LastName", Message = "Debe indicar el primer apellido" });
            }

            //BirthDate:
            if ((source.Type == 2 || (source.Type == 100 && risk.RestrictionLevel > 2))
                && source.BirthDate.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error()
                { Group = group, Key = prefix + "BirthDate", Message = "Debe indicar la fecha de nacimiento" });
            }

            //Gender:
            if (source.Type == 2 && source.Gender.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error()
                { Group = group, Key = prefix + "Gender", Message = "Debe indicar el sexo" });
            }

            //CivilStatus:
            if (risk.RestrictionLevel > 1 && source.Type == 2 && source.CivilStatus.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error()
                { Group = group, Key = prefix + "CivilStatus", Message = "Debe indicar el estado civil" });
            }

            //PhoneNumber:
            if (source.PhoneNumber.IsNotEmpty() && source.PhoneNumber.Length != 9)
            {
                result.Add(new Core.Contracts.General.Error()
                { Group = group, Key = prefix + "PhoneNumber", Message = "Debe indicar 8 dígitos" });
            }

            switch (source.Type)
            {
                case 2: //PrimaryInsured

                    //Height:
                    if (risk.RestrictionLevel > 1 && source.BirthDate.IsNotEmpty() && source.BirthDate.Age() > 64 && source.Height.IsEmpty())
                        result.Add(new Core.Contracts.General.Error()
                        {
                            Group = group,
                            Key = "Height",
                            Message = "Para mayores de 65 años se debe indicar la estatura"
                        });

                    //Weight:
                    if (risk.RestrictionLevel > 1 && source.BirthDate.IsNotEmpty() && source.BirthDate.Age() > 64 && source.Weight.IsEmpty())
                        result.Add(new Core.Contracts.General.Error()
                        {
                            Group = group,
                            Key = "Weight",
                            Message = "Para mayores de 65 años se debe indicar la peso"
                        });

                    //PrimaryEmailAddress: email: 'Debe indicar un correo electrónico valido'
                    if (source.PrimaryEmailAddress.IsEmpty())
                        result.Add(new Core.Contracts.General.Error()
                        {
                            Group = group,
                            Key = "PrimaryEmailAddress",
                            Message = "Debe indicar el correo electrónico"
                        });

                    //Province:
                    if (risk.RestrictionLevel > 1 && source.Province.IsEmpty())
                        result.Add(new Core.Contracts.General.Error()
                        { Group = group, Key = "Province", Message = "Debe indicar la provincia" });

                    //Canton:
                    if (risk.RestrictionLevel > 1 && source.Province.IsEmpty())
                        result.Add(new Core.Contracts.General.Error()
                        { Group = group, Key = "Canton", Message = "Debe indicar el cantón" });

                    //District:
                    if (risk.RestrictionLevel > 1 && source.District.IsEmpty())
                        result.Add(new Core.Contracts.General.Error()
                        { Group = group, Key = "District", Message = "Debe indicar el distrito" });

                    //Province:
                    if (risk.RestrictionLevel > 1 && source.AddressDetail.IsEmpty())
                        result.Add(new Core.Contracts.General.Error()
                        { Group = group, Key = "AddressDetail", Message = "Debe indicar la dirección" });
                    break;

                case 100: //Beneficiary

                    //Relationship:
                    if (source.Relationship.IsEmpty())
                        result.Add(new Core.Contracts.General.Error()
                        { Group = group, Key = prefix + "Relationship", Message = "Debe indicar el parentesco" });

                    //ParticipationRate:
                    if (source.ParticipationRate.IsEmpty())
                        result.Add(new Core.Contracts.General.Error()
                        { Group = group, Key = prefix + "ParticipationRate", Message = "Debe indicar la participación" });
                    break;
            }

            return result;
        }
    }
}
