using System;
using System.Data;
using Architect.API.Tron.Contracts.InsuredCompletion;
using Architect.DataFactory;
using Architect.Utilities.Extensions;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess
{
    /// <summary>
    /// Provides transactional persistence for invitation issuance and completion state changes in Research.
    /// Secret and session values accepted by this type must already be one-way hash verifiers.
    /// </summary>
    public static class PolicyProposalInvitation
    {
        /// <summary>Obtains the next numeric identifier from the invitation Oracle sequence.</summary>
        /// <returns>A <c>NUMBER(9)</c>-compatible invitation identifier.</returns>
        public static int NextId(IDbConnection connection = null)
        {
            int result = 0;
            Database.Select("SELECT SEQ_POLICYPROPOSALINVITATION.NEXTVAL AS Id FROM DUAL")
                .Query(connection, "Research", new Action<IDataReader>(reader => result = reader.IntegerValue("Id")));
            return result;
        }

        /// <summary>
        /// Revokes active invitations for the same proposal and persists the supplied replacement atomically.
        /// </summary>
        /// <param name="invitation">Replacement invitation containing only hashed secret material.</param>
        public static void CreateActiveAndRevokePrior(Contracts.InsuredCompletion.PolicyProposalInvitation invitation)
        {
            using (Session session = new Session("Research"))
            {
                try
                {
                    RevokeActiveForProposal(
                        invitation.CompanyId,
                        invitation.ProposalId,
                        invitation.CreatedAtUtc,
                        session.dbConnection);
                    Create(invitation, session.dbConnection);
                    session.CommitAndClose();
                }
                catch
                {
                    session.RollbackAndClose();
                    throw;
                }
            }
        }

        /// <summary>
        /// Inserts one invitation record using an optional caller-owned database connection.
        /// </summary>
        /// <param name="invitation">Invitation to persist.</param>
        /// <param name="connection">Optional open Research connection or transaction scope.</param>
        /// <returns>The affected-row count reported by the data factory.</returns>
        public static int Create(Contracts.InsuredCompletion.PolicyProposalInvitation invitation, IDbConnection connection = null)
        {
            return Database.Insert("INSERT INTO PolicyProposalInvitation (Id, CompanyId, PolicyProposalId, ProposalId, RecipientEmail, CompletionPath, CompletionFlow, SecretHash, SessionHash, Status, ExpiresAtUtc, SessionExpiresAtUtc, CreatedAtUtc, CompletedAtUtc, RevokedAtUtc, SendCount, RowVersion) " +
                                   "VALUES(:Id, :CompanyId, :PolicyProposalId, :ProposalId, :RecipientEmail, :CompletionPath, :CompletionFlow, :SecretHash, :SessionHash, :Status, :ExpiresAtUtc, :SessionExpiresAtUtc, :CreatedAtUtc, :CompletedAtUtc, :RevokedAtUtc, :SendCount, :RowVersion)")
                .AddParameter("Id", DbType.Decimal, 9, invitation.Id)
                .AddParameter("CompanyId", DbType.Decimal, 9, invitation.CompanyId)
                .AddParameter("PolicyProposalId", DbType.Decimal, 9, invitation.PolicyProposalId)
                .AddParameter("ProposalId", DbType.AnsiString, 40, invitation.ProposalId)
                .AddParameter("RecipientEmail", DbType.AnsiString, 320, invitation.RecipientEmail)
                .AddParameter("CompletionPath", DbType.AnsiString, 512, invitation.CompletionPath)
                .AddParameter("CompletionFlow", DbType.AnsiString, 64, invitation.CompletionFlow)
                .AddParameter("SecretHash", DbType.AnsiString, 64, invitation.SecretHash)
                .AddParameter("SessionHash", DbType.AnsiString, 64, invitation.SessionHash)
                .AddParameter("Status", DbType.AnsiString, 16, invitation.Status.ToString())
                .AddParameter("ExpiresAtUtc", DbType.DateTime, 0, invitation.ExpiresAtUtc)
                .AddParameter("SessionExpiresAtUtc", DbType.DateTime, 0, invitation.SessionExpiresAtUtc)
                .AddParameter("CreatedAtUtc", DbType.DateTime, 0, invitation.CreatedAtUtc)
                .AddParameter("CompletedAtUtc", DbType.DateTime, 0, invitation.CompletedAtUtc)
                .AddParameter("RevokedAtUtc", DbType.DateTime, 0, invitation.RevokedAtUtc)
                .AddParameter("SendCount", DbType.Decimal, 3, invitation.SendCount)
                .AddParameter("RowVersion", DbType.Decimal, 10, invitation.RowVersion)
                .Execute(connection, "Research");
        }

        /// <summary>
        /// Retrieves an invitation by its SHA-256 secret verifier, never by a plain-text secret.
        /// </summary>
        /// <param name="secretHash">Persisted invitation-secret hash.</param>
        /// <param name="connection">Optional open Research connection or transaction scope.</param>
        /// <returns>The matching invitation, or <c>null</c> when it does not exist.</returns>
        public static Contracts.InsuredCompletion.PolicyProposalInvitation RetrieveBySecretHash(string secretHash, IDbConnection connection = null)
        {
            Contracts.InsuredCompletion.PolicyProposalInvitation result = null;

            Database.Select("SELECT Id, CompanyId, PolicyProposalId, ProposalId, RecipientEmail, CompletionPath, CompletionFlow, SecretHash, SessionHash, Status, ExpiresAtUtc, SessionExpiresAtUtc, CreatedAtUtc, CompletedAtUtc, RevokedAtUtc, SendCount, RowVersion " +
                            "FROM PolicyProposalInvitation WHERE SecretHash=:SecretHash")
                .AddParameter("SecretHash", DbType.AnsiString, 64, secretHash)
                .Query(connection, "Research", new Action<IDataReader>(reader => result = DataReaderToInvitation(reader)));

            return result;
        }

        /// <summary>
        /// Retrieves an invitation by its restricted-session verifier without accepting a plain-text cookie value.
        /// </summary>
        /// <param name="sessionHash">Persisted SHA-256 session verifier.</param>
        /// <param name="connection">Optional open Research connection or transaction scope.</param>
        /// <returns>The matching invitation, or <c>null</c> when it does not exist.</returns>
        public static Contracts.InsuredCompletion.PolicyProposalInvitation RetrieveBySessionHash(string sessionHash, IDbConnection connection = null)
        {
            Contracts.InsuredCompletion.PolicyProposalInvitation result = null;

            Database.Select("SELECT Id, CompanyId, PolicyProposalId, ProposalId, RecipientEmail, CompletionPath, CompletionFlow, SecretHash, SessionHash, Status, ExpiresAtUtc, SessionExpiresAtUtc, CreatedAtUtc, CompletedAtUtc, RevokedAtUtc, SendCount, RowVersion " +
                            "FROM PolicyProposalInvitation WHERE SessionHash=:SessionHash")
                .AddParameter("SessionHash", DbType.AnsiString, 64, sessionHash)
                .Query(connection, "Research", new Action<IDataReader>(reader => result = DataReaderToInvitation(reader)));

            return result;
        }

        /// <summary>
        /// Recupera la invitación más reciente de una solicitud usando su clave técnica.
        /// </summary>
        /// <param name="companyId">Compañía propietaria de la solicitud.</param>
        /// <param name="policyProposalId">Identificador técnico de la solicitud.</param>
        /// <param name="connection">Conexión opcional hacia Research.</param>
        /// <returns>Última invitación creada, o <c>null</c> si aún no existe.</returns>
        public static Contracts.InsuredCompletion.PolicyProposalInvitation RetrieveLatestByPolicyProposalId(
            int companyId,
            int policyProposalId,
            IDbConnection connection = null)
        {
            Contracts.InsuredCompletion.PolicyProposalInvitation result = null;
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, CompanyId, PolicyProposalId, ProposalId, RecipientEmail, CompletionPath, CompletionFlow, SecretHash, SessionHash, Status, ExpiresAtUtc, SessionExpiresAtUtc, CreatedAtUtc, CompletedAtUtc, RevokedAtUtc, SendCount, RowVersion " +
                            "FROM PolicyProposalInvitation WHERE CompanyId=:CompanyId AND PolicyProposalId=:PolicyProposalId ORDER BY Id DESC" +
                            ") WHERE ROWNUM = 1")
                .AddParameter("CompanyId", DbType.Decimal, 9, companyId)
                .AddParameter("PolicyProposalId", DbType.Decimal, 9, policyProposalId)
                .Query(connection, "Research", new Action<IDataReader>(reader => result = DataReaderToInvitation(reader)));
            return result;
        }

        /// <summary>
        /// Revokes all active invitations for one proposal and clears their restricted-session verifiers.
        /// </summary>
        /// <param name="companyId">Company that owns the proposal.</param>
        /// <param name="proposalId">Proposal whose active invitations are superseded.</param>
        /// <param name="revokedAtUtc">UTC instant used for the revocation record.</param>
        /// <param name="connection">Optional open Research connection or transaction scope.</param>
        /// <returns>The number of revoked invitations.</returns>
        public static int RevokeActiveForProposal(int companyId, string proposalId, DateTime revokedAtUtc, IDbConnection connection = null)
        {
            return Database.Update("UPDATE PolicyProposalInvitation " +
                                   "SET Status=:Status, RevokedAtUtc=:RevokedAtUtc, SessionHash=:SessionHash, SessionExpiresAtUtc=:SessionExpiresAtUtc, RowVersion=RowVersion+1 " +
                                   "WHERE CompanyId=:CompanyId AND ProposalId=:ProposalId AND Status='Active'")
                .AddParameter("Status", DbType.AnsiString, 16, InvitationStatus.Revoked.ToString())
                .AddParameter("RevokedAtUtc", DbType.DateTime, 0, revokedAtUtc)
                .AddParameter("SessionHash", DbType.AnsiString, 64, null)
                .AddParameter("SessionExpiresAtUtc", DbType.DateTime, 0, null)
                .AddParameter("CompanyId", DbType.Decimal, 9, companyId)
                .AddParameter("ProposalId", DbType.AnsiString, 40, proposalId)
                .Execute(connection, "Research");
        }

        /// <summary>
        /// Revoca las invitaciones activas de una solicitud mediante su clave técnica.
        /// </summary>
        /// <param name="companyId">Compañía propietaria de la solicitud.</param>
        /// <param name="policyProposalId">Identificador técnico de la solicitud.</param>
        /// <param name="revokedAtUtc">Instante UTC de la revocación.</param>
        /// <param name="connection">Conexión opcional hacia Research.</param>
        /// <returns>Cantidad de invitaciones revocadas.</returns>
        public static int RevokeActiveForPolicyProposal(int companyId, int policyProposalId, DateTime revokedAtUtc, IDbConnection connection = null)
        {
            return Database.Update("UPDATE PolicyProposalInvitation " +
                                   "SET Status=:Status, RevokedAtUtc=:RevokedAtUtc, SessionHash=:SessionHash, SessionExpiresAtUtc=:SessionExpiresAtUtc, RowVersion=RowVersion+1 " +
                                   "WHERE CompanyId=:CompanyId AND PolicyProposalId=:PolicyProposalId AND Status='Active'")
                .AddParameter("Status", DbType.AnsiString, 16, InvitationStatus.Revoked.ToString())
                .AddParameter("RevokedAtUtc", DbType.DateTime, 0, revokedAtUtc)
                .AddParameter("SessionHash", DbType.AnsiString, 64, null)
                .AddParameter("SessionExpiresAtUtc", DbType.DateTime, 0, null)
                .AddParameter("CompanyId", DbType.Decimal, 9, companyId)
                .AddParameter("PolicyProposalId", DbType.Decimal, 9, policyProposalId)
                .Execute(connection, "Research");
        }

        /// <summary>
        /// Completa una invitación activa y vigente dentro de su alcance de compañía y propuesta, e invalida su sesión técnica.
        /// </summary>
        /// <param name="invitationId">Identificador numérico de la invitación autorizada.</param>
        /// <param name="companyId">Compañía asociada a la invitación autorizada.</param>
        /// <param name="proposalId">Propuesta asociada a la invitación autorizada.</param>
        /// <param name="completedAtUtc">Instante UTC de la emisión aceptada.</param>
        /// <param name="connection">Conexión opcional abierta hacia Research.</param>
        /// <returns><c>true</c> cuando exactamente una invitación cambió a completada.</returns>
        public static bool CompleteActiveInvitation(
            int invitationId,
            int companyId,
            string proposalId,
            DateTime completedAtUtc,
            IDbConnection connection = null)
        {
            int updated = Database.Update("UPDATE PolicyProposalInvitation " +
                                          "SET Status=:Status, CompletedAtUtc=:CompletedAtUtc, SessionHash=:SessionHash, SessionExpiresAtUtc=:SessionExpiresAtUtc, RowVersion=RowVersion+1 " +
                                          "WHERE Id=:Id AND CompanyId=:CompanyId AND ProposalId=:ProposalId AND Status='Active' AND ExpiresAtUtc>:CompletedAtUtc")
                .AddParameter("Status", DbType.AnsiString, 16, InvitationStatus.Completed.ToString())
                .AddParameter("CompletedAtUtc", DbType.DateTime, 0, completedAtUtc)
                .AddParameter("SessionHash", DbType.AnsiString, 64, null)
                .AddParameter("SessionExpiresAtUtc", DbType.DateTime, 0, null)
                .AddParameter("Id", DbType.Decimal, 9, invitationId)
                .AddParameter("CompanyId", DbType.Decimal, 9, companyId)
                .AddParameter("ProposalId", DbType.AnsiString, 40, proposalId)
                .Execute(connection, "Research");

            return updated == 1;
        }

        /// <summary>
        /// Stores a restricted-session verifier only when the invitation remains active, unexpired, and at its expected version.
        /// </summary>
        /// <param name="invitation">Invitation snapshot used to enforce optimistic concurrency.</param>
        /// <param name="sessionHash">SHA-256 verifier of the transient session secret.</param>
        /// <param name="utcNow">UTC instant used to reject an invitation that expired during the exchange race.</param>
        /// <param name="sessionExpiresAtUtc">UTC instant after which the session is unusable.</param>
        /// <param name="connection">Optional open Research connection or transaction scope.</param>
        /// <returns><c>true</c> only when exactly one active invitation was updated.</returns>
        public static bool CreateOrRenewSession(
            Contracts.InsuredCompletion.PolicyProposalInvitation invitation,
            string sessionHash,
            DateTime utcNow,
            DateTime sessionExpiresAtUtc,
            IDbConnection connection = null)
        {
            int updated = Database.Update("UPDATE PolicyProposalInvitation " +
                                          "SET SessionHash=:SessionHash, SessionExpiresAtUtc=:SessionExpiresAtUtc, RowVersion=RowVersion+1 " +
                                          "WHERE Id=:Id AND Status='Active' AND ExpiresAtUtc>:UtcNow AND RowVersion=:RowVersion")
                .AddParameter("SessionHash", DbType.AnsiString, 64, sessionHash)
                .AddParameter("SessionExpiresAtUtc", DbType.DateTime, 0, sessionExpiresAtUtc)
                .AddParameter("Id", DbType.Decimal, 9, invitation.Id)
                .AddParameter("UtcNow", DbType.DateTime, 0, utcNow)
                .AddParameter("RowVersion", DbType.Decimal, 10, invitation.RowVersion)
                .Execute(connection, "Research");

            return updated == 1;
        }

        /// <summary>
        /// Slides a session's expiration only when its verifier, invitation state, and both expiry windows remain valid.
        /// </summary>
        /// <param name="invitation">Invitation that owns the restricted session.</param>
        /// <param name="sessionHash">Persisted SHA-256 session verifier.</param>
        /// <param name="utcNow">UTC instant used to reject expired state.</param>
        /// <param name="sessionExpiresAtUtc">New UTC sliding expiration instant.</param>
        /// <param name="connection">Optional open Research connection or transaction scope.</param>
        /// <returns><c>true</c> only when exactly one current session was renewed.</returns>
        public static bool RenewSession(
            Contracts.InsuredCompletion.PolicyProposalInvitation invitation,
            string sessionHash,
            DateTime utcNow,
            DateTime sessionExpiresAtUtc,
            IDbConnection connection = null)
        {
            int updated = Database.Update("UPDATE PolicyProposalInvitation " +
                                          "SET SessionExpiresAtUtc=:SessionExpiresAtUtc, RowVersion=RowVersion+1 " +
                                          "WHERE Id=:Id AND SessionHash=:SessionHash AND Status='Active' " +
                                          "AND ExpiresAtUtc>:UtcNow AND SessionExpiresAtUtc>:UtcNow")
                .AddParameter("SessionExpiresAtUtc", DbType.DateTime, 0, sessionExpiresAtUtc)
                .AddParameter("Id", DbType.Decimal, 9, invitation.Id)
                .AddParameter("SessionHash", DbType.AnsiString, 64, sessionHash)
                .AddParameter("UtcNow", DbType.DateTime, 0, utcNow)
                .Execute(connection, "Research");

            return updated == 1;
        }

        /// <summary>
        /// Atomically records the completed payload and audit event while transitioning an active unexpired invitation.
        /// </summary>
        /// <param name="invitation">Invitation whose row version must still be current.</param>
        /// <param name="completion">Consent-bearing completed form payload.</param>
        /// <param name="audit">Security event for the accepted completion.</param>
        /// <exception cref="ArgumentException">Thrown when the values reference different invitations.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the invitation is no longer active or current.</exception>
        public static void SaveCompletionAndComplete(
            Contracts.InsuredCompletion.PolicyProposalInvitation invitation,
            Contracts.InsuredCompletion.PolicyProposalCompletion completion,
            Contracts.InsuredCompletion.PolicyProposalCompletionAudit audit)
        {
            if (invitation.Id != completion.InvitationId || invitation.Id != audit.InvitationId)
            {
                throw new ArgumentException("La entrega y la auditoría deben corresponder a la misma invitación.");
            }

            using (Session session = new Session("Research"))
            {
                try
                {
                    int updated = MarkCompleted(invitation, completion.CompletedAtUtc, session.dbConnection);
                    if (updated != 1)
                    {
                        throw new InvalidOperationException("La invitación no está activa o cambió durante la entrega.");
                    }

                    PolicyProposalCompletion.Create(completion, session.dbConnection);
                    PolicyProposalCompletionAudit.Append(audit, session.dbConnection);
                    session.CommitAndClose();
                }
                catch
                {
                    session.RollbackAndClose();
                    throw;
                }
            }
        }

        private static int MarkCompleted(
            Contracts.InsuredCompletion.PolicyProposalInvitation invitation,
            DateTime completedAtUtc,
            IDbConnection connection)
        {
            return Database.Update("UPDATE PolicyProposalInvitation " +
                                   "SET Status=:Status, CompletedAtUtc=:CompletedAtUtc, SessionHash=:SessionHash, SessionExpiresAtUtc=:SessionExpiresAtUtc, RowVersion=RowVersion+1 " +
                                   "WHERE Id=:Id AND Status='Active' AND ExpiresAtUtc>:CompletedAtUtc AND RowVersion=:RowVersion")
                .AddParameter("Status", DbType.AnsiString, 16, InvitationStatus.Completed.ToString())
                .AddParameter("CompletedAtUtc", DbType.DateTime, 0, completedAtUtc)
                .AddParameter("SessionHash", DbType.AnsiString, 64, null)
                .AddParameter("SessionExpiresAtUtc", DbType.DateTime, 0, null)
                .AddParameter("Id", DbType.Decimal, 9, invitation.Id)
                .AddParameter("RowVersion", DbType.Decimal, 10, invitation.RowVersion)
                .Execute(connection, "Research");
        }

        private static Contracts.InsuredCompletion.PolicyProposalInvitation DataReaderToInvitation(IDataReader reader)
        {
            int id = reader.IntegerValue("Id");

            return Contracts.InsuredCompletion.PolicyProposalInvitation.Restore(
                id,
                reader.IntegerValue("CompanyId"),
                reader.IntegerValue("PolicyProposalId"),
                reader.StringValue("ProposalId"),
                reader.StringValue("RecipientEmail"),
                reader.StringValue("SecretHash"),
                reader.StringValue("SessionHash"),
                (InvitationStatus)Enum.Parse(typeof(InvitationStatus), reader.StringValue("Status"), true),
                reader.DateTimeValue("ExpiresAtUtc"),
                reader.DateTimeValue("SessionExpiresAtUtc").IsEmpty() ? (DateTime?)null : reader.DateTimeValue("SessionExpiresAtUtc"),
                reader.DateTimeValue("CreatedAtUtc"),
                reader.DateTimeValue("CompletedAtUtc").IsEmpty() ? (DateTime?)null : reader.DateTimeValue("CompletedAtUtc"),
                reader.DateTimeValue("RevokedAtUtc").IsEmpty() ? (DateTime?)null : reader.DateTimeValue("RevokedAtUtc"),
                reader.IntegerValue("SendCount"),
                reader.IntegerValue("RowVersion"),
                reader.StringValue("CompletionPath"),
                reader.StringValue("CompletionFlow"));
        }
    }
}
