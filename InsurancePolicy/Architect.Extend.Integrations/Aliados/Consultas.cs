using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Threading.Tasks;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.Extend.Integrations.Aliados
{
    /// <summary>
    /// Consultas de integración por parte de Tron.
    /// </summary>
    public static class Consultas
    {
        /// <summary>
        /// Permite recuperar la información de una persona en la tabla de tercero de tron por medio de su identificación.
        /// </summary>
        public async static Task<Architect.API.Insurance.Contracts.Policy.Insured> RiskRoles(string identificacion)
        {
            Architect.API.Insurance.Contracts.Policy.Insured result = null;


            try
            {
                //identificacion = "0000000000000000" + identificacion;
                //identificacion = identificacion.Substring(identificacion.Length - 10);
                Database.Select("SELECT DocumentType, DocumentNumber, FirstName, MiddleName, LastName, SecondLastName, BirthDate, Gender, CivilStatus, PrimaryEmailAddress, Province, Canton, District, AddressDetail, PhoneType, PhoneNumber, CountryOfNationality " +
                                  "FROM RiskRoles " +
                                 "WHERE REPLACE(DocumentNumber,'-','')=:COD_DOCUM " +
                                 "ORDER BY UpdateDate ASC")
                        .AddParameter("COD_DOCUM", DbType.AnsiString, 20, identificacion)
                        .Query(null, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = new Architect.API.Insurance.Contracts.Policy.Insured()
                            {
                                DocumentType = reader.IntegerValue("DocumentType"),
                                DocumentNumber = reader.StringValue("DocumentNumber"),
                                FirstName = reader.StringValue("FirstName").Capitalize(),
                                MiddleName = reader.StringValue("MiddleName").Capitalize(),
                                LastName = reader.StringValue("LastName").Capitalize(),
                                SecondLastName = reader.StringValue("SecondLastName").Capitalize(),
                                BirthDate = reader.DateTimeValue("BirthDate"),
                                Gender = reader.IntegerValue("Gender"),
                                CivilStatus = reader.IntegerValue("CivilStatus"),
                                PrimaryEmailAddress = reader.StringValue("PrimaryEmailAddress"),
                                Province = reader.IntegerValue("Province"),
                                Canton = reader.IntegerValue("Canton"),
                                District = reader.IntegerValue("District"),
                                AddressDetail = reader.StringValue("AddressDetail").Capitalize(),
                                PhoneType = reader.IntegerValue("PhoneType"),
                                PhoneNumber = reader.StringValue("PhoneNumber"),
                                CountryOfNationality = reader.IntegerValue("CountryOfNationality"),
                                Source = "Aliados"
                            };
                            if (result.PhoneNumber.Length > 4 && result.PhoneNumber.Length < 9)
                            {
                                result.PhoneNumber = result.PhoneNumber.Substring(0, 4) + '-' + result.PhoneNumber.Substring(4);
                            }
                            if (result.SecondLastName.IsEmpty() && result.LastName.IndexOf(" ") > -1)
                            {
                                result.SecondLastName = result.LastName.Substring(result.LastName.IndexOf(" ") + 1).Capitalize();
                                result.LastName = result.LastName.Substring(0, result.LastName.IndexOf(" "));
                            }

                        }));
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog("Tron.RiskRoles",
                                                         string.Format("Falla al tratar de consultar a identificación '{0}'", identificacion),
                                                         ex, "integrations");
            }
            return result;
        }


        /// <summary>
        /// Permite recuperar la información de una persona en la tabla de tercero de tron por medio de su identificación.
        /// </summary>
        public async static Task<Architect.API.Insurance.Contracts.Policy.Insured> ThirdParty(string identificacion)
        {
            Architect.API.Insurance.Contracts.Policy.Insured result = null;


            try
            {
                string id = "0000000000000000" + identificacion;
                id = id.Substring(id.Length - 10);
                Database.Select("SELECT Id, ThirdParty.CompanyId, DocumentType, DocumentNumber, ThirdParty.FirstName, MiddleName, ThirdParty.LastName, SecondLastName, ThirdParty.BirthDate, Gender, CivilStatus, Height, Weight, BloodPressureSystolic, BloodPressureDiastolic, Occupation, RetirementModality, RetirementCause, CountryOfNationality, CountryOfBirth, PrimaryEmailAddress, SecondaryEmailAddress, Province, Canton, District, AddressDetail, PhoneNumberMobile, PhoneNumberHome, PhoneNumberOffice, InclusionDate, ThirdParty.Reference, ThirdParty.CustomData, ThirdParty.UpdateUserCode, ThirdParty.UpdateDate, ThirdPartyType, ThirdPartyCode " +
                                  "FROM ThirdParty " +
                                 "WHERE REPLACE(DocumentNumber,'-','')=:DocumentNumberFrm OR REPLACE(DocumentNumber,'-','')=:DocumentNumber")
                        .AddParameter("DocumentNumberFrm", DbType.AnsiString, 20, id)
                        .AddParameter("DocumentNumber", DbType.AnsiString, 20, identificacion)
                        .Query(null, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = new Architect.API.Insurance.Contracts.Policy.Insured()
                            {
                                DocumentType = reader.IntegerValue("DocumentType"),
                                DocumentNumber = reader.StringValue("DocumentNumber"),
                                FirstName = reader.StringValue("FirstName").Capitalize(),
                                MiddleName = reader.StringValue("MiddleName").Capitalize(),
                                LastName = reader.StringValue("LastName").Capitalize(),
                                SecondLastName = reader.StringValue("SecondLastName").Capitalize(),
                                BirthDate = reader.DateTimeValue("BirthDate"),
                                Gender = reader.IntegerValue("Gender"),
                                CivilStatus = reader.IntegerValue("CivilStatus"),
                                PrimaryEmailAddress = reader.StringValue("PrimaryEmailAddress"),
                                Province = reader.IntegerValue("Province"),
                                Canton = reader.IntegerValue("Canton"),
                                District = reader.IntegerValue("District"),
                                AddressDetail = reader.StringValue("AddressDetail").Capitalize(),
                                PhoneNumber = reader.StringValue("PhoneNumberMobile"),
                                CountryOfNationality = reader.IntegerValue("CountryOfNationality"),
                                Source = "ThirdParty"
                            };
                            if (result.PhoneNumber.Length > 4 && result.PhoneNumber.Length < 9)
                            {
                                result.PhoneNumber = result.PhoneNumber.Substring(0, 4) + '-' + result.PhoneNumber.Substring(4);
                            }
                            if (result.SecondLastName.IsEmpty() && result.LastName.IndexOf(" ") > -1)
                            {
                                result.SecondLastName = result.LastName.Substring(result.LastName.IndexOf(" ") + 1).Capitalize();
                                result.LastName = result.LastName.Substring(0, result.LastName.IndexOf(" "));
                            }
                        }));
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog("Aliados.ThirdParty",
                                                         string.Format("Falla al tratar de consultar a identificación '{0}'", identificacion),
                                                         ex, "integrations");
            }
            return result;
        }

    }
}
