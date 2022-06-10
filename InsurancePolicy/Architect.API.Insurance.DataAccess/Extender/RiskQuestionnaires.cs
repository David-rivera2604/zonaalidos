using Architect.DataFactory;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.Policy
{
    public sealed partial class RiskQuestionnaires
    {
        /// <summary>
        /// Recupera una lista de registros en la tabla RiskQuestionnaires.
        /// </summary>
        /// <param name="policyid"></param>
        /// <returns>Lista de instancias de RiskQuestionnaires</returns>
        public static List<Contracts.Policy.RiskQuestionnaires> RetrieveByPolicyId(int policyid, IDbConnection connection = null)
        {
            var result = new List<Contracts.Policy.RiskQuestionnaires>();

            Database.Select(@"SELECT Id, PolicyId, Type, QuestionId, Confirmation, Diagnosis, Treatment, Doctor, When, RiskQuestionnaires.CompanyId, RiskQuestionnaires.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RiskQuestionnaires.UpdateDate
                                FROM RiskQuestionnaires LEFT JOIN UserMember um ON um.UserId = RiskQuestionnaires.UpdateUserCode
                               WHERE PolicyId=:PolicyId")
                      .AddParameter("PolicyId", DbType.Decimal, 9, policyid)
                      .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                      {
                          result.Add(DataReaderToRiskQuestionnaires(reader));
                      }));

            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla RiskQuestionnaires.
        /// </summary>
        /// <param name="policyid"></param>
        /// <param name="companyid"></param>
        /// <returns>Lista de instancias de RiskQuestionnaires</returns>
        public static List<Contracts.Policy.RiskQuestionnaires> RetrieveByPolicyIdCompanyId(int policyid, int companyid, IDbConnection connection = null)
        {
            var result = new List<Contracts.Policy.RiskQuestionnaires>();

            Database.Select(@"Select Id, PolicyId, Type, QuestionId, Confirmation, Diagnosis, Treatment, Doctor, When, RiskQuestionnaires.CompanyId, RiskQuestionnaires.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RiskQuestionnaires.UpdateDate
                                FROM RiskQuestionnaires LEFT JOIN UserMember um ON um.UserId = RiskQuestionnaires.UpdateUserCode
                               WHERE PolicyId=:PolicyId AND RiskQuestionnaires.CompanyId=:CompanyId")
                      .AddParameter("PolicyId", DbType.Decimal, 9, policyid)
                       .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                      .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                      {
                          result.Add(DataReaderToRiskQuestionnaires(reader));
                      }));

            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla RiskQuestionnaires basado en el número de documento de un asegurado.
        /// </summary>
        /// <param name="documentNumber">Número de documento del asegurado</param>
        /// <param name="questionIdBegin">Identificador de la pregunta inicial</param>
        /// <param name="questionIdFinish">Identificador de la pregunta final</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <returns>Lista de instancias de RiskQuestionnaires</returns>
        public static List<Contracts.Policy.RiskQuestionnaires> RetrieveByDocumentNumber(string documentNumber, int questionIdBegin, int questionIdFinish, int companyId, IDbConnection connection = null)
        {
            DataTable rows = null;
            var result = new List<Contracts.Policy.RiskQuestionnaires>();
            documentNumber = "0000000000000000" + documentNumber;
            documentNumber = documentNumber.Substring(documentNumber.Length - 10);
            {
                Database.Select(@"SELECT Id, PolicyId, Type, QuestionId, Confirmation, Diagnosis, Treatment, Doctor, When, RiskQuestionnaires.CompanyId, RiskQuestionnaires.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RiskQuestionnaires.UpdateDate
                                    FROM RiskQuestionnaires LEFT JOIN UserMember um ON um.UserId = RiskQuestionnaires.UpdateUserCode
                                   WHERE RiskQuestionnaires.CompanyId=:CompanyId
                                     AND PolicyId in (SELECT PolicyId  FROM RiskRoles WHERE REPLACE(DocumentNumber,'-','')=:DocumentNumber AND RiskRoles.CompanyId=RiskQuestionnaires.CompanyId)
                                     AND TRUNC(RiskQuestionnaires.UpdateDate)=TRUNC(:Today)
                                     AND QuestionId BETWEEN :questionIdBegin AND :questionIdFinish
                                ORDER BY PolicyId DESC, QuestionId ASC
                             FETCH FIRST :RowCount ROWS ONLY")
                    .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                    .AddParameter("DocumentNumber", DbType.AnsiString, 20, documentNumber)
                    .AddParameter("Today", DbType.DateTime, 0, DateTime.Today)
                    .AddParameter("questionIdBegin", DbType.Decimal, 9, questionIdBegin)
                    .AddParameter("questionIdFinish", DbType.Decimal, 9, questionIdFinish)
                    .AddParameter("RowCount", DbType.Decimal, 9, questionIdFinish - questionIdBegin + 1)
                     .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                     {
                         result.Add(DataReaderToRiskQuestionnaires(reader));
                     }));
            }

            return result;
        }

        /// <summary>
        /// Elimina un registro en la tabla RiskQuestionnaires por medio de su clave primaria.
        /// </summary>
        /// <param name="policyid"></param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int DeleteByPolicyId(int policyid, IDbConnection connection = null)
        {
            return Database.Delete(@"DELETE FROM RiskQuestionnaires
                                      WHERE PolicyId=:PolicyId")
                               .AddParameter("PolicyId", DbType.Decimal, 9, policyid)
                               .Execute(connection, "Research");
        }

        /// <summary>
        /// Elimina un registro en la tabla RiskQuestionnaires por medio de su clave primaria.
        /// </summary>
        /// <param name="policyid"></param>
        /// <param name="companyid"></param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int DeleteByPolicyIdCompanyId(int policyid, int companyid, IDbConnection connection = null)
        {
            return Database.Delete(@"DELETE FROM RiskQuestionnaires
                                      WHERE PolicyId=:PolicyId AND CompanyId=:CompanyId")
                                  .AddParameter("PolicyId", DbType.Decimal, 9, policyid)
                                  .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                              .Execute(connection, "Research");
        }
    }
}