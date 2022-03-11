using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.Policy
{
    /// <summary>
    /// Personas
    /// </summary>
    public sealed partial class Person
    {
        /// <summary>
        /// Crea un registro en la tabla Person.
        /// </summary>
        /// <param name="personItem">Instancia de Person</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Insurance.Contracts.Policy.Person personItem, IDbConnection connection = null)
        {
            if (personItem.UpdateDate.IsEmpty())
            {
                personItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO Person (Id, CompanyId, DocumentType, DocumentNumber, FirstName, MiddleName, LastName, SecondLastName, BirthDate, Gender, CivilStatus, Height, Weight, BloodPressureSystolic, BloodPressureDiastolic, Occupation, RetirementModality, RetirementCause, CountryOfNationality, CountryOfBirth, PrimaryEmailAddress, SecondaryEmailAddress, Province, Canton, District, AddressDetail, PhoneNumberMobile, PhoneNumberHome, PhoneNumberOffice, InclusionDate, Reference, CustomData, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :DocumentType, :DocumentNumber, :FirstName, :MiddleName, :LastName, :SecondLastName, :BirthDate, :Gender, :CivilStatus, :Height, :Weight, :BloodPressureSystolic, :BloodPressureDiastolic, :Occupation, :RetirementModality, :RetirementCause, :CountryOfNationality, :CountryOfBirth, :PrimaryEmailAddress, :SecondaryEmailAddress, :Province, :Canton, :District, :AddressDetail, :PhoneNumberMobile, :PhoneNumberHome, :PhoneNumberOffice, :InclusionDate, :Reference, :CustomData, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, personItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, personItem.CompanyId)
                            .AddParameter("DocumentType", DbType.Decimal, 8, personItem.DocumentType)
                            .AddParameter("DocumentNumber", DbType.AnsiString, 20, personItem.DocumentNumber)
                            .AddParameter("FirstName", DbType.AnsiString, 40, personItem.FirstName)
                            .AddParameter("MiddleName", DbType.AnsiString, 40, personItem.MiddleName)
                            .AddParameter("LastName", DbType.AnsiString, 40, personItem.LastName)
                            .AddParameter("SecondLastName", DbType.AnsiString, 40, personItem.SecondLastName)
                            .AddParameter("BirthDate", DbType.DateTime, 9, personItem.BirthDate)
                            .AddParameter("Gender", DbType.Decimal, 5, personItem.Gender)
                            .AddParameter("CivilStatus", DbType.Decimal, 5, personItem.CivilStatus)
                            .AddParameter("Height", DbType.Decimal, 5, personItem.Height)
                            .AddParameter("Weight", DbType.Decimal, 5, personItem.Weight)
                            .AddParameter("BloodPressureSystolic", DbType.Decimal, 3, personItem.BloodPressureSystolic)
                            .AddParameter("BloodPressureDiastolic", DbType.Decimal, 3, personItem.BloodPressureDiastolic)
                            .AddParameter("Occupation", DbType.AnsiString, 40, personItem.Occupation)
                            .AddParameter("RetirementModality", DbType.Decimal, 5, personItem.RetirementModality)
                            .AddParameter("RetirementCause", DbType.AnsiString, 40, personItem.RetirementCause)
                            .AddParameter("CountryOfNationality", DbType.Decimal, 5, personItem.CountryOfNationality)
                            .AddParameter("CountryOfBirth", DbType.Decimal, 5, personItem.CountryOfBirth)
                            .AddParameter("PrimaryEmailAddress", DbType.AnsiString, 80, personItem.PrimaryEmailAddress)
                            .AddParameter("SecondaryEmailAddress", DbType.AnsiString, 80, personItem.SecondaryEmailAddress)
                            .AddParameter("Province", DbType.Decimal, 5, personItem.Province)
                            .AddParameter("Canton", DbType.Decimal, 5, personItem.Canton)
                            .AddParameter("District", DbType.Decimal, 5, personItem.District)
                            .AddParameter("AddressDetail", DbType.AnsiString, 200, personItem.AddressDetail)
                            .AddParameter("PhoneNumberMobile", DbType.AnsiString, 20, personItem.PhoneNumberMobile)
                            .AddParameter("PhoneNumberHome", DbType.AnsiString, 20, personItem.PhoneNumberHome)
                            .AddParameter("PhoneNumberOffice", DbType.AnsiString, 20, personItem.PhoneNumberOffice)
                            .AddParameter("InclusionDate", DbType.DateTime, 9, personItem.InclusionDate)
                            .AddParameter("Reference", DbType.AnsiString, 36, personItem.Reference)
                            .AddParameter("CustomData", DbType.AnsiString, 2000, personItem.CustomData)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, personItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, personItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla Person.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="personItems">Lista de instancia de Person</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Insurance.Contracts.Policy.Person> personItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.Policy.Person item in personItems)
            {
                result.Add(Create(item, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla Person por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del rol.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Person</returns>
        public static Architect.API.Insurance.Contracts.Policy.Person Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Insurance.Contracts.Policy.Person result = null;
            Database.Select("SELECT Id, Person.CompanyId, DocumentType, DocumentNumber, Person.FirstName, MiddleName, Person.LastName, SecondLastName, Person.BirthDate, Gender, CivilStatus, Height, Weight, BloodPressureSystolic, BloodPressureDiastolic, Occupation, RetirementModality, RetirementCause, CountryOfNationality, CountryOfBirth, PrimaryEmailAddress, SecondaryEmailAddress, Province, Canton, District, AddressDetail, PhoneNumberMobile, PhoneNumberHome, PhoneNumberOffice, InclusionDate, Person.Reference, Person.CustomData, Person.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Person.UpdateDate " +
                              "FROM Person LEFT JOIN UserMember um ON um.UserId = Person.UpdateUserCode " +
                             "WHERE Person.Id=:Id AND Person.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToPerson(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Person.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Person</returns>
        public static List<Architect.API.Insurance.Contracts.Policy.Person> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Insurance.Contracts.Policy.Person> result = new List<Architect.API.Insurance.Contracts.Policy.Person>();
            Database.Select("SELECT Id, Person.CompanyId, DocumentType, DocumentNumber, Person.FirstName, MiddleName, Person.LastName, SecondLastName, Person.BirthDate, Gender, CivilStatus, Height, Weight, BloodPressureSystolic, BloodPressureDiastolic, Occupation, RetirementModality, RetirementCause, CountryOfNationality, CountryOfBirth, PrimaryEmailAddress, SecondaryEmailAddress, Province, Canton, District, AddressDetail, PhoneNumberMobile, PhoneNumberHome, PhoneNumberOffice, InclusionDate, Person.Reference, Person.CustomData, Person.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Person.UpdateDate " +
                              "FROM Person LEFT JOIN UserMember um ON um.UserId = Person.UpdateUserCode " +
                             "WHERE Person.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToPerson(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Person.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Person</returns>
        public static List<Architect.API.Insurance.Contracts.Policy.Person> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Insurance.Contracts.Policy.Person> result = new List<Architect.API.Insurance.Contracts.Policy.Person>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, Person.CompanyId, DocumentType, DocumentNumber, Person.FirstName, MiddleName, Person.LastName, SecondLastName, Person.BirthDate, Gender, CivilStatus, Height, Weight, BloodPressureSystolic, BloodPressureDiastolic, Occupation, RetirementModality, RetirementCause, CountryOfNationality, CountryOfBirth, PrimaryEmailAddress, SecondaryEmailAddress, Province, Canton, District, AddressDetail, PhoneNumberMobile, PhoneNumberHome, PhoneNumberOffice, InclusionDate, Person.Reference, Person.CustomData, Person.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Person.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY Person.Id DESC) RowNumber " +
                              "FROM Person LEFT JOIN UserMember um ON um.UserId = Person.UpdateUserCode " +
                             "WHERE Person.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToPerson(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Genera complemento del query para habilitar el filtro por columnas establecidas.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros.</param>
        /// <param name="where">Indica que el complement debe incluir el WHERE del comando.</param>
        /// <returns>Complemento del query</returns>
        public static string FilterBuilder(string filter, bool includeWhere = true)
        {
            string result = string.Empty;

            return result;
        }

        /// <summary>
        /// Último valor asignado a clave unica de la tabla Person.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM Person")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla Person por medio de su clave primaria.
        /// </summary>
        /// <param name="personItem">Instancia de Person</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Insurance.Contracts.Policy.Person personItem, IDbConnection connection = null)
        {
            if (personItem.UpdateDate.IsEmpty())
            {
                personItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE Person " +
                                      "SET CompanyId=:CompanyId, DocumentType=:DocumentType, DocumentNumber=:DocumentNumber, FirstName=:FirstName, MiddleName=:MiddleName, LastName=:LastName, SecondLastName=:SecondLastName, BirthDate=:BirthDate, Gender=:Gender, CivilStatus=:CivilStatus, Height=:Height, Weight=:Weight, BloodPressureSystolic=:BloodPressureSystolic, BloodPressureDiastolic=:BloodPressureDiastolic, Occupation=:Occupation, RetirementModality=:RetirementModality, RetirementCause=:RetirementCause, CountryOfNationality=:CountryOfNationality, CountryOfBirth=:CountryOfBirth, PrimaryEmailAddress=:PrimaryEmailAddress, SecondaryEmailAddress=:SecondaryEmailAddress, Province=:Province, Canton=:Canton, District=:District, AddressDetail=:AddressDetail, PhoneNumberMobile=:PhoneNumberMobile, PhoneNumberHome=:PhoneNumberHome, PhoneNumberOffice=:PhoneNumberOffice, InclusionDate=:InclusionDate, Reference=:Reference, CustomData=:CustomData, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, personItem.CompanyId)
                                .AddParameter("DocumentType", DbType.Decimal, 8, personItem.DocumentType)
                                .AddParameter("DocumentNumber", DbType.AnsiString, 20, personItem.DocumentNumber)
                                .AddParameter("FirstName", DbType.AnsiString, 40, personItem.FirstName)
                                .AddParameter("MiddleName", DbType.AnsiString, 40, personItem.MiddleName)
                                .AddParameter("LastName", DbType.AnsiString, 40, personItem.LastName)
                                .AddParameter("SecondLastName", DbType.AnsiString, 40, personItem.SecondLastName)
                                .AddParameter("BirthDate", DbType.DateTime, 9, personItem.BirthDate)
                                .AddParameter("Gender", DbType.Decimal, 5, personItem.Gender)
                                .AddParameter("CivilStatus", DbType.Decimal, 5, personItem.CivilStatus)
                                .AddParameter("Height", DbType.Decimal, 5, personItem.Height)
                                .AddParameter("Weight", DbType.Decimal, 5, personItem.Weight)
                                .AddParameter("BloodPressureSystolic", DbType.Decimal, 3, personItem.BloodPressureSystolic)
                                .AddParameter("BloodPressureDiastolic", DbType.Decimal, 3, personItem.BloodPressureDiastolic)
                                .AddParameter("Occupation", DbType.AnsiString, 40, personItem.Occupation)
                                .AddParameter("RetirementModality", DbType.Decimal, 5, personItem.RetirementModality)
                                .AddParameter("RetirementCause", DbType.AnsiString, 40, personItem.RetirementCause)
                                .AddParameter("CountryOfNationality", DbType.Decimal, 5, personItem.CountryOfNationality)
                                .AddParameter("CountryOfBirth", DbType.Decimal, 5, personItem.CountryOfBirth)
                                .AddParameter("PrimaryEmailAddress", DbType.AnsiString, 80, personItem.PrimaryEmailAddress)
                                .AddParameter("SecondaryEmailAddress", DbType.AnsiString, 80, personItem.SecondaryEmailAddress)
                                .AddParameter("Province", DbType.Decimal, 5, personItem.Province)
                                .AddParameter("Canton", DbType.Decimal, 5, personItem.Canton)
                                .AddParameter("District", DbType.Decimal, 5, personItem.District)
                                .AddParameter("AddressDetail", DbType.AnsiString, 200, personItem.AddressDetail)
                                .AddParameter("PhoneNumberMobile", DbType.AnsiString, 20, personItem.PhoneNumberMobile)
                                .AddParameter("PhoneNumberHome", DbType.AnsiString, 20, personItem.PhoneNumberHome)
                                .AddParameter("PhoneNumberOffice", DbType.AnsiString, 20, personItem.PhoneNumberOffice)
                                .AddParameter("InclusionDate", DbType.DateTime, 9, personItem.InclusionDate)
                                .AddParameter("Reference", DbType.AnsiString, 36, personItem.Reference)
                                .AddParameter("CustomData", DbType.AnsiString, 2000, personItem.CustomData)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, personItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, personItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, personItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Person por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="personItems">Lista de instancia de Person</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Insurance.Contracts.Policy.Person> personItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.Policy.Person item in personItems)
            {
                result.Add(Update(item, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Elimina un registro en la tabla Person por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del rol.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM Person " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Person por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única del rol.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Delete(List<int> idList, int companyId, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (int item in idList)
            {
                result.Add(Delete(item, companyId, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Person por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del rol.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Person " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Person que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Person " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'Person'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Insurance.Contracts.Policy.Person DataReaderToPerson(System.Data.IDataReader reader, Architect.API.Insurance.Contracts.Policy.Person item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Insurance.Contracts.Policy.Person();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.DocumentType = reader.IntegerValue("DocumentType");
            item.DocumentNumber = reader.StringValue("DocumentNumber");
            item.FirstName = reader.StringValue("FirstName");
            item.MiddleName = reader.StringValue("MiddleName");
            item.LastName = reader.StringValue("LastName");
            item.SecondLastName = reader.StringValue("SecondLastName");
            item.BirthDate = reader.DateTimeValue("BirthDate");
            item.Gender = reader.IntegerValue("Gender");
            item.CivilStatus = reader.IntegerValue("CivilStatus");
            item.Height = reader.DoubleValue("Height");
            item.Weight = reader.DoubleValue("Weight");
            item.BloodPressureSystolic = reader.IntegerValue("BloodPressureSystolic");
            item.BloodPressureDiastolic = reader.IntegerValue("BloodPressureDiastolic");
            item.Occupation = reader.StringValue("Occupation");
            item.RetirementModality = reader.IntegerValue("RetirementModality");
            item.RetirementCause = reader.StringValue("RetirementCause");
            item.CountryOfNationality = reader.IntegerValue("CountryOfNationality");
            item.CountryOfBirth = reader.IntegerValue("CountryOfBirth");
            item.PrimaryEmailAddress = reader.StringValue("PrimaryEmailAddress");
            item.SecondaryEmailAddress = reader.StringValue("SecondaryEmailAddress");
            item.Province = reader.IntegerValue("Province");
            item.Canton = reader.IntegerValue("Canton");
            item.District = reader.IntegerValue("District");
            item.AddressDetail = reader.StringValue("AddressDetail");
            item.PhoneNumberMobile = reader.StringValue("PhoneNumberMobile");
            item.PhoneNumberHome = reader.StringValue("PhoneNumberHome");
            item.PhoneNumberOffice = reader.StringValue("PhoneNumberOffice");
            item.InclusionDate = reader.DateTimeValue("InclusionDate");
            item.Reference = reader.StringValue("Reference");
            item.CustomData = reader.StringValue("CustomData");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }
    }
}