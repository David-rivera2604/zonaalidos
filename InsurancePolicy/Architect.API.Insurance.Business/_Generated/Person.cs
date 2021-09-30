using System;
using System.Collections.Generic;
using Architect.Utilities.Extensions;

namespace Architect.API.Insurance.Business.Policy
{
    public static partial class Person
    {

        public static Architect.API.Insurance.Contracts.Policy.Person Create(int companyId, int userId, Architect.API.Insurance.Contracts.Policy.Person item)
        {
            Architect.API.Insurance.Contracts.Policy.Person result = item;

            if (result.Id.IsEmpty())
                result.Id = Architect.API.Insurance.DataAccess.Policy.Person.RetrieveLastKey() + 1;

            result.CompanyId = companyId;
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;

            if (Architect.API.Insurance.DataAccess.Policy.Person.Create(result) > 0)
            {
                MapLookups(companyId, result);
				Core.Business.General.ChangeSet.Create(2006, result.Id, companyId, "Creación", string.Format("Se creó un registro con la identificación '{0}'", result.Id), userId, result);                
            }
            return result;
        }

        public static List<Architect.API.Insurance.Contracts.Policy.Person> Retrieve(int companyId, string filter)
        {
            List<Architect.API.Insurance.Contracts.Policy.Person> result = Architect.API.Insurance.DataAccess.Policy.Person.RetrieveAll(companyId, filter);

            foreach (Architect.API.Insurance.Contracts.Policy.Person item in result)
            {
                MapLookups(companyId, item);
            }

            return result;
        }

        public static Architect.API.Insurance.Contracts.Policy.Person RetrieveById(int companyId, int id)
        {
            Architect.API.Insurance.Contracts.Policy.Person result = Architect.API.Insurance.DataAccess.Policy.Person.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        public static Architect.API.Insurance.Contracts.Policy.Person Update(int companyId, int userId, int id, Architect.API.Insurance.Contracts.Policy.Person item)
        {
            Architect.API.Insurance.Contracts.Policy.Person result = item;

            result.Id = id;
            result.CompanyId = companyId;
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;

            if (Architect.API.Insurance.DataAccess.Policy.Person.Update(result) > 0)
            {
				MapLookups(companyId, result);
                Core.Business.General.ChangeSet.Create(2006, item.Id, companyId, "Modificación", string.Format("Se modificó el registro con la identificación '{0}'", result.Id), userId, result);
			}
            return result;
        }

        public static bool Delete(int companyId, int userId, int id)
        {
            Architect.API.Insurance.Contracts.Policy.Person result = Architect.API.Insurance.DataAccess.Policy.Person.Retrieve(id, companyId);
            int affectedRows = 0;
            if (result.IsNotEmpty())
            {
                affectedRows = Architect.API.Insurance.DataAccess.Policy.Person.Delete(id, companyId);
                if (affectedRows > 0)
                {
                    Core.Business.General.ChangeSet.Create(2006, id, companyId, "Eliminar", string.Format("Se eliminó el registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return affectedRows > 0;
        }

        public static List<Core.Contracts.General.Error> Validate(Architect.API.Insurance.Contracts.Policy.Person source, bool isnew)
        {
            string group = "Person";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if (!isnew && source.Id.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el identificación" });

            //DocumentType:

            //DocumentNumber:

            //FirstName:

            //MiddleName:

            //LastName:

            //SecondLastName:

            //BirthDate:

            //Gender:

            //CivilStatus:

            //Height:

            //Weight:

            //BloodPressureSystolic:

            //BloodPressureDiastolic:

            //Occupation:

            //RetirementModality:

            //RetirementCause:

            //CountryOfNationality:

            //CountryOfBirth:

            //PrimaryEmailAddress:

            //SecondaryEmailAddress:

            //Province:

            //Canton:

            //District:

            //AddressDetail:

            //PhoneNumberMobile:

            //PhoneNumberHome:

            //PhoneNumberOffice:

            //InclusionDate:

            //Reference:

            //CustomData:

            return result;
        }

        private static void MapLookups(int companyId, Architect.API.Insurance.Contracts.Policy.Person item)
        {
            if (item.IsNotEmpty())
            {
                if (item.DocumentType.IsNotEmpty())
                    item.DocumentTypeDesc = Core.Business.Common.Lkp("DocumentType", companyId).Find(x => x.Code == item.DocumentType.ToString()).Description;
                if (item.Gender.IsNotEmpty())
                    item.GenderDesc = Core.Business.Common.Lkp("Gender", companyId).Find(x => x.Code == item.Gender.ToString()).Description;
                if (item.CivilStatus.IsNotEmpty())
                    item.CivilStatusDesc = Core.Business.Common.Lkp("CivilStatus", companyId).Find(x => x.Code == item.CivilStatus.ToString()).Description;
                if (item.RetirementModality.IsNotEmpty())
                    item.RetirementModalityDesc = Core.Business.Common.Lkp("RetirementModality", companyId).Find(x => x.Code == item.RetirementModality.ToString()).Description;
                if (item.CountryOfNationality.IsNotEmpty())
                    item.CountryOfNationalityDesc = Core.Business.Common.Lkp("Pais", companyId).Find(x => x.Code == item.CountryOfNationality.ToString()).Description;
                if (item.CountryOfBirth.IsNotEmpty())
                    item.CountryOfBirthDesc = Core.Business.Common.Lkp("Pais", companyId).Find(x => x.Code == item.CountryOfBirth.ToString()).Description;
                if (item.Province.IsNotEmpty())
                    item.ProvinceDesc = Core.Business.Common.Lkp("CR_Provincia", companyId).Find(x => x.Code == item.Province.ToString()).Description;
                if (item.Canton.IsNotEmpty())
                    item.CantonDesc = Core.Business.Common.Lkp("CR_Canton", companyId).Find(x => x.Code == item.Canton.ToString()).Description;
                if (item.District.IsNotEmpty())
                    item.DistrictDesc = Core.Business.Common.Lkp("CR_Distritos", companyId).Find(x => x.Code == item.District.ToString()).Description;

            }
        }

    }
}
