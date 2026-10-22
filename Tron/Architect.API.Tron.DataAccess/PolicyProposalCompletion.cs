using System.Data;
using Architect.DataFactory;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess
{
    /// <summary>
    /// Persists consent-bearing completion payloads for the restricted insured workflow.
    /// </summary>
    public static class PolicyProposalCompletion
    {
        /// <summary>
        /// Inserts a completion payload using an optional caller-owned database connection.
        /// </summary>
        /// <param name="completion">Completion value to persist.</param>
        /// <param name="connection">Optional open Research connection or transaction scope.</param>
        /// <returns>The affected-row count reported by the data factory.</returns>
        public static int Create(Contracts.InsuredCompletion.PolicyProposalCompletion completion, IDbConnection connection = null)
        {
            return Database.Insert("INSERT INTO PolicyProposalCompletion (InvitationId, FormVersion, PayloadJson, ConsentTextVersion, ConsentAccepted, CompletedAtUtc, RowVersion) " +
                                   "VALUES(:InvitationId, :FormVersion, :PayloadJson, :ConsentTextVersion, :ConsentAccepted, :CompletedAtUtc, :RowVersion)")
                .AddParameter("InvitationId", DbType.Decimal, 9, completion.InvitationId)
                .AddParameter("FormVersion", DbType.AnsiString, 64, completion.FormVersion)
                .AddParameter("PayloadJson", DbType.Clob, 0, completion.PayloadJson)
                .AddParameter("ConsentTextVersion", DbType.AnsiString, 64, completion.ConsentTextVersion)
                .AddParameter("ConsentAccepted", DbType.Decimal, 1, completion.ConsentAccepted ? 1 : 0)
                .AddParameter("CompletedAtUtc", DbType.DateTime, 0, completion.CompletedAtUtc)
                .AddParameter("RowVersion", DbType.Decimal, 10, completion.RowVersion)
                .Execute(connection, "Research");
        }
    }
}
