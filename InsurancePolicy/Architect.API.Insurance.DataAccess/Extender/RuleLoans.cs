using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.Policy
{
    public sealed partial class RuleLoans
    {

        /// <summary>
        /// Recupera una lista de registros en la tabla RuleLoans.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="documentNumber">Documento o número de identificación.</param>
        /// <returns>Lista de instancias de RuleLoans</returns>
        public static List<Contracts.Policy.RuleLoans> RetrieveByDocumentNumber(int companyId, string documentNumber, IDbConnection connection = null)
        {
            var result = new List<Contracts.Policy.RuleLoans>();
            Database.Select(@"SELECT LoanNumber, CompanyId, DocumentNumber, FullName, BirthDate, Gender, StartTerm, EndTerm, Duration, Amount, Balance 
                               FROM RuleLoans 
                              WHERE DocumentNumber=:DocumentNumber AND CompanyId=:CompanyId ORDER BY EndTerm")
                        .AddParameter("DocumentNumber", DbType.AnsiString, 20, documentNumber)
                        .AddParameter("CompanyId", DbType.Decimal, 5,  companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add( DataReaderToRuleLoans(reader));
                        }));
            return result;
        }

        public static int Truncate(IDbConnection connection = null)
        {
            return Database.Command("TRUNCATE TABLE RuleLoans") 
                    .Execute(connection, "Research"); 
        }
    }
}