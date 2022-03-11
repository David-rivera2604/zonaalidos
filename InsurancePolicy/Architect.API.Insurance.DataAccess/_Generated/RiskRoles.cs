using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.Policy
{
    /// <summary>
    /// Información de asegurados y/o beneficiarios de una póliza.
    /// </summary>
    public sealed partial class RiskRoles
    {
        /// <summary>
        /// Crea un registro en la tabla RiskRoles.
        /// </summary>
        /// <param name="riskrolesItem">Instancia de RiskRoles</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Insurance.Contracts.Policy.RiskRoles riskrolesItem, IDbConnection connection = null)
        {
            if (riskrolesItem.UpdateDate.IsEmpty())
            {
                riskrolesItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert(@"INSERT INTO RiskRoles
                                              (RoleId, PolicyId, Type, DocumentType, DocumentNumber, FirstName, MiddleName, LastName, SecondLastName, BirthDate, Gender, CivilStatus, Height, Weight, BloodPressureSystolic, BloodPressureDiastolic, Occupation, RetirementModality, RetirementCause, CountryOfNationality, CountryOfBirth, ClientType, Relationship, ParticipationRate, PrimaryEmailAddress, TypeOfAddress, Province, Canton, District, AddressDetail, PhoneType, PhoneNumber, CompanyId, CustomData, UpdateUserCode, UpdateDate, BankAccount, InclusionDate, ExclusionDate, AgeAtInclusion)
                                        VALUES(:RoleId, :PolicyId, :Type, :DocumentType, :DocumentNumber, :FirstName, :MiddleName, :LastName, :SecondLastName, :BirthDate, :Gender, :CivilStatus, :Height, :Weight, :BloodPressureSystolic, :BloodPressureDiastolic, :Occupation, :RetirementModality, :RetirementCause, :CountryOfNationality, :CountryOfBirth, :ClientType, :Relationship, :ParticipationRate, :PrimaryEmailAddress, :TypeOfAddress, :Province, :Canton, :District, :AddressDetail, :PhoneType, :PhoneNumber, :CompanyId, :CustomData, :UpdateUserCode, :UpdateDate, :BankAccount, :InclusionDate, :ExclusionDate, :AgeAtInclusion)")
                             .AddParameter("RoleId", DbType.Decimal, 9, riskrolesItem.RoleId)
                             .AddParameter("PolicyId", DbType.Decimal, 9, riskrolesItem.PolicyId)
                             .AddParameter("Type", DbType.Decimal, 9, riskrolesItem.Type)
                             .AddParameter("DocumentType", DbType.Decimal, 8, riskrolesItem.DocumentType)
                             .AddParameter("DocumentNumber", DbType.AnsiString, 20, riskrolesItem.DocumentNumber)
                             .AddParameter("FirstName", DbType.AnsiString, 40, riskrolesItem.FirstName)
                             .AddParameter("MiddleName", DbType.AnsiString, 40, riskrolesItem.MiddleName)
                             .AddParameter("LastName", DbType.AnsiString, 40, riskrolesItem.LastName)
                             .AddParameter("SecondLastName", DbType.AnsiString, 40, riskrolesItem.SecondLastName)
                             .AddParameter("BirthDate", DbType.DateTime, 9, riskrolesItem.BirthDate)
                             .AddParameter("Gender", DbType.Decimal, 5, riskrolesItem.Gender)
                             .AddParameter("CivilStatus", DbType.Decimal, 5, riskrolesItem.CivilStatus)
                             .AddParameter("Height", DbType.Decimal, 5, riskrolesItem.Height)
                             .AddParameter("Weight", DbType.Decimal, 5, riskrolesItem.Weight)
                             .AddParameter("BloodPressureSystolic", DbType.Decimal, 3, riskrolesItem.BloodPressureSystolic)
                             .AddParameter("BloodPressureDiastolic", DbType.Decimal, 3, riskrolesItem.BloodPressureDiastolic)
                             .AddParameter("Occupation", DbType.AnsiString, 40, riskrolesItem.Occupation)
                             .AddParameter("RetirementModality", DbType.Decimal, 5, riskrolesItem.RetirementModality)
                             .AddParameter("RetirementCause", DbType.AnsiString, 40, riskrolesItem.RetirementCause)
                             .AddParameter("CountryOfNationality", DbType.Decimal, 5, riskrolesItem.CountryOfNationality)
                             .AddParameter("CountryOfBirth", DbType.Decimal, 5, riskrolesItem.CountryOfBirth)
                             .AddParameter("ClientType", DbType.Decimal, 9, riskrolesItem.ClientType)
                             .AddParameter("Relationship", DbType.Decimal, 5, riskrolesItem.Relationship)
                             .AddParameter("ParticipationRate", DbType.Decimal, 3, riskrolesItem.ParticipationRate)
                             .AddParameter("PrimaryEmailAddress", DbType.AnsiString, 80, riskrolesItem.PrimaryEmailAddress)
                             .AddParameter("TypeOfAddress", DbType.Decimal, 5, riskrolesItem.TypeOfAddress)
                             .AddParameter("Province", DbType.Decimal, 5, riskrolesItem.Province)
                             .AddParameter("Canton", DbType.Decimal, 5, riskrolesItem.Canton)
                             .AddParameter("District", DbType.Decimal, 5, riskrolesItem.District)
                             .AddParameter("AddressDetail", DbType.AnsiString, 120, riskrolesItem.AddressDetail)
                             .AddParameter("PhoneType", DbType.Decimal, 5, riskrolesItem.PhoneType)
                             .AddParameter("PhoneNumber", DbType.AnsiString, 20, riskrolesItem.PhoneNumber)
                             .AddParameter("CompanyId", DbType.Decimal, 5, riskrolesItem.CompanyId)
                             .AddParameter("CustomData", DbType.AnsiString, 2000, riskrolesItem.CustomData)
                             .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskrolesItem.UpdateUserCode)
                             .AddParameter("UpdateDate", DbType.DateTime, 0, riskrolesItem.UpdateDate)
                             .AddParameter("BankAccount", DbType.AnsiString, 22, riskrolesItem.BankAccount)
                             .AddParameter("InclusionDate", DbType.DateTime, 9, riskrolesItem.InclusionDate)
                             .AddParameter("ExclusionDate", DbType.DateTime, 9, riskrolesItem.ExclusionDate)
                             .AddParameter("AgeAtInclusion", DbType.Decimal, 3, riskrolesItem.AgeAtInclusion)
                             .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla RiskRoles.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="riskrolesItems">Lista de instancia de RiskRoles</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Insurance.Contracts.Policy.RiskRoles> riskrolesItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.Policy.RiskRoles item in riskrolesItems)
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
        /// Último valor asignado a clave unica de la tabla RiskRoles.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT NVL(MAX(RoleId),0) " +
                                     "FROM RiskRoles")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla RiskRoles por medio de su clave primaria.
        /// </summary>
        /// <param name="riskrolesItem">Instancia de RiskRoles</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Insurance.Contracts.Policy.RiskRoles riskrolesItem, IDbConnection connection = null)
        {
            if (riskrolesItem.UpdateDate.IsEmpty())
            {
                riskrolesItem.UpdateDate = DateTime.Now;
            }
            return Database.Update(@"UPDATE RiskRoles 
                                        SET PolicyId=:PolicyId, Type=:Type, DocumentType=:DocumentType, DocumentNumber=:DocumentNumber, FirstName=:FirstName, MiddleName=:MiddleName, LastName=:LastName, SecondLastName=:SecondLastName, BirthDate=:BirthDate, Gender=:Gender, CivilStatus=:CivilStatus, Height=:Height, Weight=:Weight, BloodPressureSystolic=:BloodPressureSystolic, BloodPressureDiastolic=:BloodPressureDiastolic, Occupation=:Occupation, RetirementModality=:RetirementModality, RetirementCause=:RetirementCause, CountryOfNationality=:CountryOfNationality, CountryOfBirth=:CountryOfBirth, ClientType=:ClientType, Relationship=:Relationship, ParticipationRate=:ParticipationRate, PrimaryEmailAddress=:PrimaryEmailAddress, TypeOfAddress=:TypeOfAddress, Province=:Province, Canton=:Canton, District=:District, AddressDetail=:AddressDetail, PhoneType=:PhoneType, PhoneNumber=:PhoneNumber, CompanyId=:CompanyId, CustomData=:CustomData, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate, BankAccount=:BankAccount, InclusionDate=:InclusionDate, ExclusionDate=:ExclusionDate, AgeAtInclusion=:AgeAtInclusion 
                                      WHERE RoleId=:RoleId")
                                .AddParameter("PolicyId", DbType.Decimal, 9, riskrolesItem.PolicyId)
                                .AddParameter("Type", DbType.Decimal, 9, riskrolesItem.Type)
                                .AddParameter("DocumentType", DbType.Decimal, 8, riskrolesItem.DocumentType)
                                .AddParameter("DocumentNumber", DbType.AnsiString, 20, riskrolesItem.DocumentNumber)
                                .AddParameter("FirstName", DbType.AnsiString, 40, riskrolesItem.FirstName)
                                .AddParameter("MiddleName", DbType.AnsiString, 40, riskrolesItem.MiddleName)
                                .AddParameter("LastName", DbType.AnsiString, 40, riskrolesItem.LastName)
                                .AddParameter("SecondLastName", DbType.AnsiString, 40, riskrolesItem.SecondLastName)
                                .AddParameter("BirthDate", DbType.DateTime, 9, riskrolesItem.BirthDate)
                                .AddParameter("Gender", DbType.Decimal, 5, riskrolesItem.Gender)
                                .AddParameter("CivilStatus", DbType.Decimal, 5, riskrolesItem.CivilStatus)
                                .AddParameter("Height", DbType.Decimal, 5, riskrolesItem.Height)
                                .AddParameter("Weight", DbType.Decimal, 5, riskrolesItem.Weight)
                                .AddParameter("BloodPressureSystolic", DbType.Decimal, 3, riskrolesItem.BloodPressureSystolic)
                                .AddParameter("BloodPressureDiastolic", DbType.Decimal, 3, riskrolesItem.BloodPressureDiastolic)
                                .AddParameter("Occupation", DbType.AnsiString, 40, riskrolesItem.Occupation)
                                .AddParameter("RetirementModality", DbType.Decimal, 5, riskrolesItem.RetirementModality)
                                .AddParameter("RetirementCause", DbType.AnsiString, 40, riskrolesItem.RetirementCause)
                                .AddParameter("CountryOfNationality", DbType.Decimal, 5, riskrolesItem.CountryOfNationality)
                                .AddParameter("CountryOfBirth", DbType.Decimal, 5, riskrolesItem.CountryOfBirth)
                                .AddParameter("ClientType", DbType.Decimal, 9, riskrolesItem.ClientType)
                                .AddParameter("Relationship", DbType.Decimal, 5, riskrolesItem.Relationship)
                                .AddParameter("ParticipationRate", DbType.Decimal, 3, riskrolesItem.ParticipationRate)
                                .AddParameter("PrimaryEmailAddress", DbType.AnsiString, 80, riskrolesItem.PrimaryEmailAddress)
                                .AddParameter("TypeOfAddress", DbType.Decimal, 5, riskrolesItem.TypeOfAddress)
                                .AddParameter("Province", DbType.Decimal, 5, riskrolesItem.Province)
                                .AddParameter("Canton", DbType.Decimal, 5, riskrolesItem.Canton)
                                .AddParameter("District", DbType.Decimal, 5, riskrolesItem.District)
                                .AddParameter("AddressDetail", DbType.AnsiString, 120, riskrolesItem.AddressDetail)
                                .AddParameter("PhoneType", DbType.Decimal, 5, riskrolesItem.PhoneType)
                                .AddParameter("PhoneNumber", DbType.AnsiString, 20, riskrolesItem.PhoneNumber)
                                .AddParameter("CompanyId", DbType.Decimal, 5, riskrolesItem.CompanyId)
                                .AddParameter("CustomData", DbType.AnsiString, 2000, riskrolesItem.CustomData)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskrolesItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, riskrolesItem.UpdateDate)
                                .AddParameter("BankAccount", DbType.AnsiString, 22, riskrolesItem.BankAccount)
                                .AddParameter("InclusionDate", DbType.DateTime, 9, riskrolesItem.InclusionDate)
                                .AddParameter("ExclusionDate", DbType.DateTime, 9, riskrolesItem.ExclusionDate)
                                .AddParameter("AgeAtInclusion", DbType.Decimal, 3, riskrolesItem.AgeAtInclusion)
                                .AddParameter("RoleId", DbType.Decimal, 9, riskrolesItem.RoleId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla RiskRoles por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="riskrolesItems">Lista de instancia de RiskRoles</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Insurance.Contracts.Policy.RiskRoles> riskrolesItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.Policy.RiskRoles item in riskrolesItems)
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
        /// Elimina un registro en la tabla RiskRoles por medio de su clave primaria.
        /// </summary>
        /// <param name="roleid">Identificación única del rol.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int roleid, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM RiskRoles " +
                                    "WHERE RoleId=:RoleId AND CompanyId=:CompanyId")
                                .AddParameter("RoleId", DbType.Decimal, 9, roleid)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla RiskRoles por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="roleidList">Lista de Identificación única del rol.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Delete(List<int> roleidList, int companyId, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (int item in roleidList)
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
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'RiskRoles'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Insurance.Contracts.Policy.RiskRoles DataReaderToRiskRoles(System.Data.IDataReader itemRow, Architect.API.Insurance.Contracts.Policy.RiskRoles item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Insurance.Contracts.Policy.RiskRoles();
            }

            item.RoleId = itemRow.IntegerValue("RoleId");
            item.PolicyId = itemRow.IntegerValue("PolicyId");
            item.Type = itemRow.IntegerValue("Type");
            item.DocumentType = itemRow.IntegerValue("DocumentType");
            item.DocumentNumber = itemRow.StringValue("DocumentNumber");
            item.FirstName = itemRow.StringValue("FirstName");
            item.MiddleName = itemRow.StringValue("MiddleName");
            item.LastName = itemRow.StringValue("LastName");
            item.SecondLastName = itemRow.StringValue("SecondLastName");
            item.BirthDate = itemRow.DateTimeValue("BirthDate");
            item.Gender = itemRow.IntegerValue("Gender");
            item.CivilStatus = itemRow.IntegerValue("CivilStatus");
            item.Height = itemRow.IntegerValue("Height");
            item.Weight = itemRow.IntegerValue("Weight");
            item.BloodPressureSystolic = itemRow.IntegerValue("BloodPressureSystolic");
            item.BloodPressureDiastolic = itemRow.IntegerValue("BloodPressureDiastolic");
            item.Occupation = itemRow.StringValue("Occupation");
            item.RetirementModality = itemRow.IntegerValue("RetirementModality");
            item.RetirementCause = itemRow.StringValue("RetirementCause");
            item.CountryOfNationality = itemRow.IntegerValue("CountryOfNationality");
            item.CountryOfBirth = itemRow.IntegerValue("CountryOfBirth");
            item.ClientType = itemRow.IntegerValue("ClientType");
            item.Relationship = itemRow.IntegerValue("Relationship");
            item.ParticipationRate = itemRow.IntegerValue("ParticipationRate");
            item.PrimaryEmailAddress = itemRow.StringValue("PrimaryEmailAddress");
            item.TypeOfAddress = itemRow.IntegerValue("TypeOfAddress");
            item.Province = itemRow.IntegerValue("Province");
            item.Canton = itemRow.IntegerValue("Canton");
            item.District = itemRow.IntegerValue("District");
            item.AddressDetail = itemRow.StringValue("AddressDetail");
            item.PhoneType = itemRow.IntegerValue("PhoneType");
            item.PhoneNumber = itemRow.StringValue("PhoneNumber");
            item.CompanyId = itemRow.IntegerValue("CompanyId");
            item.CustomData = itemRow.StringValue("CustomData");
            item.UpdateUserCode = itemRow.IntegerValue("UpdateUserCode");
            item.UpdateUserName = itemRow.StringValue("UpdateUserName");
            item.UpdateDate = itemRow.DateTimeValue("UpdateDate");
            item.BankAccount = itemRow.StringValue("BankAccount");
            item.InclusionDate = itemRow.DateTimeValue("InclusionDate");
            item.ExclusionDate = itemRow.DateTimeValue("ExclusionDate");
            item.AgeAtInclusion = itemRow.IntegerValue("AgeAtInclusion");

            return item;
        }
    }
}