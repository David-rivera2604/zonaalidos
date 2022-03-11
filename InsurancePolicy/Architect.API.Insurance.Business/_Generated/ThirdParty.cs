using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Insurance.Business.Policy
{
    /// <summary>
    /// Información centralizada de terceros (personas y empresas).
    /// </summary>
    public static partial class ThirdParty
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla ThirdParty.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ThirdParty</param>
        /// <returns>Instancia de ThirdParty creada o actualizada.</returns>
        public static Architect.API.Insurance.Contracts.Policy.ThirdPartyResult CreateOrUpdate(int companyId, int userId, Architect.API.Insurance.Contracts.Policy.ThirdParty item)
        {
            if (item.Id.IsEmpty() || Architect.API.Insurance.DataAccess.Policy.ThirdParty.Count(item.Id, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla ThirdParty.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ThirdParty</param>
        /// <returns>Instancia de ThirdParty creada.</returns>
        public static Architect.API.Insurance.Contracts.Policy.ThirdPartyResult Create(int companyId, int userId, Architect.API.Insurance.Contracts.Policy.ThirdParty item)
        {
            Architect.API.Insurance.Contracts.Policy.ThirdParty result = item;
            List<Core.Contracts.General.Error> errors = Architect.API.Insurance.Business.Policy.ThirdParty.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = Architect.API.Insurance.DataAccess.Policy.ThirdParty.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Insurance.DataAccess.Policy.ThirdParty.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(2006, result.Id, companyId, "Creación", string.Format("Se creó un registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Insurance.Contracts.Policy.ThirdPartyResult() { ThirdParty = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ThirdParty.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de ThirdParty.</returns>
        public static List<Architect.API.Insurance.Contracts.Policy.ThirdParty> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Insurance.Contracts.Policy.ThirdParty> result = Architect.API.Insurance.DataAccess.Policy.ThirdParty.RetrieveAll(companyId, Architect.API.Insurance.DataAccess.Policy.ThirdParty.FilterBuilder(filter, false), beginIndex, endIndex);

            foreach (Architect.API.Insurance.Contracts.Policy.ThirdParty item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla ThirdParty por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ThirdParty</returns>
        public static Architect.API.Insurance.Contracts.Policy.ThirdParty RetrieveById(int companyId, int id)
        {
            Architect.API.Insurance.Contracts.Policy.ThirdParty result = Architect.API.Insurance.DataAccess.Policy.ThirdParty.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla ThirdParty por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de ThirdParty</param>
        /// <returns>Instancia de ThirdParty actualizada.</returns>
        public static Architect.API.Insurance.Contracts.Policy.ThirdPartyResult Update(int companyId, int userId, int id, Architect.API.Insurance.Contracts.Policy.ThirdParty item)
        {
            Architect.API.Insurance.Contracts.Policy.ThirdParty result = null;
            List<Core.Contracts.General.Error> errors = Architect.API.Insurance.Business.Policy.ThirdParty.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Insurance.DataAccess.Policy.ThirdParty.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(2006, item.Id, companyId, "Modificación", string.Format("Se modificó el registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Insurance.Contracts.Policy.ThirdPartyResult() { ThirdParty = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla ThirdParty por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ThirdParty eliminada.</returns>
        public static Architect.API.Insurance.Contracts.Policy.ThirdPartyResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Insurance.Contracts.Policy.ThirdParty result = null;
            List<Core.Contracts.General.Error> errors = Architect.API.Insurance.Business.Policy.ThirdParty.Validate(companyId, new Architect.API.Insurance.Contracts.Policy.ThirdParty() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Insurance.DataAccess.Policy.ThirdParty.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Insurance.DataAccess.Policy.ThirdParty.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(2006, id, companyId, "Eliminar", string.Format("Se eliminó el registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Insurance.Contracts.Policy.ThirdPartyResult() { ThirdParty = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ThirdParty que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Insurance.DataAccess.Policy.ThirdParty.Count(Architect.API.Insurance.DataAccess.Policy.ThirdParty.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla ThirdParty.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="source">Instancia de ThirdParty</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Insurance.Contracts.Policy.ThirdParty source, bool isnew, bool isdelete)
        {
            string group = "ThirdParty";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el identificación" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Insurance.DataAccess.Policy.ThirdParty.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La identificación no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Insurance.DataAccess.Policy.ThirdParty.Count(source.Id, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La identificación ya está registrada" });
            }
            if (!isdelete)
            {

                //DocumentType:
                if (source.DocumentType.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "DocumentType", source.DocumentType.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "DocumentType", Message = "El valor indicado para el tipo de documento no es valido" });
                }

                //DocumentNumber:

                //FirstName:

                //MiddleName:

                //LastName:

                //SecondLastName:

                //BirthDate:

                //Gender:
                if (source.Gender.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "Gender", source.Gender.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Gender", Message = "El valor indicado para el sexo no es valido" });
                }

                //CivilStatus:
                if (source.CivilStatus.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "CivilStatus", source.CivilStatus.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "CivilStatus", Message = "El valor indicado para el estado civil no es valido" });
                }

                //Height:

                //Weight:

                //BloodPressureSystolic:

                //BloodPressureDiastolic:

                //Occupation:

                //RetirementModality:
                if (source.RetirementModality.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "RetirementModality", source.RetirementModality.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "RetirementModality", Message = "El valor indicado para el condición no es valido" });
                }

                //RetirementCause:

                //CountryOfNationality:
                if (source.CountryOfNationality.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "Pais", source.CountryOfNationality.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "CountryOfNationality", Message = "El valor indicado para el país de nacionalidad no es valido" });
                }

                //CountryOfBirth:
                if (source.CountryOfBirth.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "Pais", source.CountryOfBirth.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "CountryOfBirth", Message = "El valor indicado para el país de nacimiento no es valido" });
                }

                //PrimaryEmailAddress:

                //SecondaryEmailAddress:

                //Province:
                if (source.Province.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "CR_Provincia", source.Province.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Province", Message = "El valor indicado para el provincia no es valido" });
                }

                //Canton:
                if (source.Canton.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "CR_Canton", source.Canton.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Canton", Message = "El valor indicado para el cantón no es valido" });
                }

                //District:
                if (source.District.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "CR_Distritos", source.District.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "District", Message = "El valor indicado para el distrito no es valido" });
                }

                //AddressDetail:

                //PhoneNumberMobile:

                //PhoneNumberHome:

                //PhoneNumberOffice:

                //InclusionDate:

                //Reference:

                //CustomData:

                //ThirdPartyType:

                //ThirdPartyCode:
            }

            return result;
        }

        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="item">Instancia de ThirdParty</param>
        private static void MapLookups(int companyId, Architect.API.Insurance.Contracts.Policy.ThirdParty item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.DocumentType.IsNotEmpty())
                item.DocumentTypeDesc = Core.Business.Common.LkpDescription(companyId, "DocumentType", item.DocumentType.ToString());
            if (item.Gender.IsNotEmpty())
                item.GenderDesc = Core.Business.Common.LkpDescription(companyId, "Gender", item.Gender.ToString());
            if (item.CivilStatus.IsNotEmpty())
                item.CivilStatusDesc = Core.Business.Common.LkpDescription(companyId, "CivilStatus", item.CivilStatus.ToString());
            if (item.RetirementModality.IsNotEmpty())
                item.RetirementModalityDesc = Core.Business.Common.LkpDescription(companyId, "RetirementModality", item.RetirementModality.ToString());
            if (item.CountryOfNationality.IsNotEmpty())
                item.CountryOfNationalityDesc = Core.Business.Common.LkpDescription(companyId, "Pais", item.CountryOfNationality.ToString());
            if (item.CountryOfBirth.IsNotEmpty())
                item.CountryOfBirthDesc = Core.Business.Common.LkpDescription(companyId, "Pais", item.CountryOfBirth.ToString());
            if (item.Province.IsNotEmpty())
                item.ProvinceDesc = Core.Business.Common.LkpDescription(companyId, "CR_Provincia", item.Province.ToString());
            if (item.Canton.IsNotEmpty())
                item.CantonDesc = Core.Business.Common.LkpDescription(companyId, "CR_Canton", item.Canton.ToString());
            if (item.District.IsNotEmpty())
                item.DistrictDesc = Core.Business.Common.LkpDescription(companyId, "CR_Distritos", item.District.ToString());

        }

    }
}
