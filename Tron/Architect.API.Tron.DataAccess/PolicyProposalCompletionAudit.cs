using System.Data;
using Architect.DataFactory;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess
{
    /// <summary>
    /// Persists security-relevant workflow events without retaining capability secrets.
    /// </summary>
    public static class PolicyProposalCompletionAudit
    {
        /// <summary>
        /// Appends an audit event using an optional caller-owned database connection.
        /// </summary>
        /// <param name="audit">Audit event to persist.</param>
        /// <param name="connection">Optional open Research connection or transaction scope.</param>
        /// <returns>The affected-row count reported by the data factory.</returns>
        public static int Append(Contracts.InsuredCompletion.PolicyProposalCompletionAudit audit, IDbConnection connection = null)
        {
            return Database.Insert("INSERT INTO PolicyProposalCompletionAudit (Id, InvitationId, EventType, ActorType, OccurredAtUtc, RemoteAddress, UserAgent, CorrelationId) " +
                                   "VALUES(:Id, :InvitationId, :EventType, :ActorType, :OccurredAtUtc, :RemoteAddress, :UserAgent, :CorrelationId)")
                .AddParameter("Id", DbType.Decimal, 9, audit.Id)
                .AddParameter("InvitationId", DbType.Decimal, 9, audit.InvitationId)
                .AddParameter("EventType", DbType.AnsiString, 32, audit.EventType)
                .AddParameter("ActorType", DbType.AnsiString, 16, audit.ActorType)
                .AddParameter("OccurredAtUtc", DbType.DateTime, 0, audit.OccurredAtUtc)
                .AddParameter("RemoteAddress", DbType.AnsiString, 64, audit.RemoteAddress)
                .AddParameter("UserAgent", DbType.AnsiString, 512, audit.UserAgent)
                .AddParameter("CorrelationId", DbType.AnsiString, 64, audit.CorrelationId)
                .Execute(connection, "Research");
        }
    }
}
