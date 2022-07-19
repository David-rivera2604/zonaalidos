using Architect.DataFactory;
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
        /// Recupera una lista de registros en la tabla RiskRoles.
        /// </summary>
        /// <param name="policyid"></param>
        /// <returns>Lista de instancias de RiskRoles</returns>
        public static List<Contracts.Policy.RiskRoles> RetrieveByPolicyId(int policyid, IDbConnection connection = null)
        {
            var result = new List<Contracts.Policy.RiskRoles>();
            Database.Select(@"Select RoleId, PolicyId, Type, DocumentType, DocumentNumber, RiskRoles.FirstName, MiddleName, RiskRoles.LastName, SecondLastName, BirthDate, Gender, CivilStatus, Height, Weight, BloodPressureSystolic, BloodPressureDiastolic, Occupation, RetirementModality, RetirementCause, CountryOfNationality, CountryOfBirth, ClientType, Relationship, ParticipationRate, PrimaryEmailAddress, TypeOfAddress, Province, Canton, District, AddressDetail, PhoneType, PhoneNumber, RiskRoles.CompanyId, RiskRoles.CustomData, RiskRoles.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RiskRoles.UpdateDate, BankAccount, InclusionDate, ExclusionDate, AgeAtInclusion
                                FROM RiskRoles LEFT JOIN UserMember um ON um.UserId = RiskRoles.UpdateUserCode
                               WHERE PolicyId=:PolicyId")
                        .AddParameter("PolicyId", DbType.Decimal, 9, policyid)
                       .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                       {
                           result.Add(DataReaderToRiskRoles(reader));
                       }));
            return result;
        }

        /// <summary>
        /// Elimina un registro en la tabla RiskRoles por medio de su clave primaria.
        /// </summary>
        /// <param name="policyid"></param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int DeleteByPolicyId(int policyid, IDbConnection connection = null)
        {
            return Database.Delete(@"DELETE FROM RiskRoles 
                                      WHERE PolicyId=:PolicyId")
                               .AddParameter("PolicyId", DbType.Decimal, 9, policyid)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla RiskRoles.
        /// </summary>
        /// <param name="policyid"></param>
        /// <param name="companyid"></param>
        /// <returns>Lista de instancias de RiskRoles</returns>
        public static List<Contracts.Policy.RiskRoles> RetrieveByPolicyIdCompanyId(int policyid, int companyid, IDbConnection connection = null)
        {
            var result = new List<Contracts.Policy.RiskRoles>();
            Database.Select(@"Select RoleId, PolicyId, Type, DocumentType, DocumentNumber, RiskRoles.FirstName, MiddleName, RiskRoles.LastName, SecondLastName, RiskRoles.BirthDate, Gender, CivilStatus, Height, Weight, BloodPressureSystolic, BloodPressureDiastolic, Occupation, RetirementModality, RetirementCause, CountryOfNationality, CountryOfBirth, ClientType, Relationship, ParticipationRate, PrimaryEmailAddress, TypeOfAddress, Province, Canton, District, AddressDetail, PhoneType, RiskRoles.PhoneNumber, RiskRoles.CompanyId, RiskRoles.CustomData, RiskRoles.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RiskRoles.UpdateDate, BankAccount, InclusionDate, ExclusionDate, AgeAtInclusion 
                                FROM RiskRoles LEFT JOIN UserMember um ON um.UserId = RiskRoles.UpdateUserCode 
                               WHERE PolicyId=:PolicyId AND RiskRoles.CompanyId=:CompanyId")
                        .AddParameter("PolicyId", DbType.Decimal, 9, policyid)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                       .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                       {
                           result.Add(DataReaderToRiskRoles(reader));
                       }));
            return result;
        }

        /// <summary>
        /// Elimina un registro en la tabla RiskRoles por medio de su clave primaria.
        /// </summary>
        /// <param name="policyid"></param>
        /// <param name="companyid"></param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int DeleteByPolicyIdCompanyId(int policyid, int companyid, IDbConnection connection = null)
        {
            return Database.Delete(@"DELETE FROM RiskRoles 
                                      WHERE PolicyId=:PolicyId AND CompanyId=:CompanyId")
                                .AddParameter("PolicyId", DbType.Decimal, 9, policyid)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                               .Execute(connection, "Research");
        }

        /// <summary>
        /// Elimina un registro en la tabla RiskRoles por medio de su clave primaria.
        /// </summary>
        /// <param name="policyid"></param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int policyid, IDbConnection connection = null)
        {
            return Database.Delete(@"DELETE FROM RiskRoles 
                                      WHERE PolicyId=:PolicyId ")
                                .AddParameter("PolicyId", DbType.Decimal, 9, policyid)
                               .Execute(connection, "Research");
        }
    }
}