using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess
{
    /// <summary>
    /// .
    /// </summary>
    public static partial class PolicyProposal
    {

        /// <summary>
        /// Recupera una lista de registros en la tabla PolicyProposal.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="status">Estado del presupuesto.</param>
        /// <returns>Lista de instancias de PolicyProposal</returns>
        public static List<Architect.API.Tron.Contracts.PolicyProposal> RetrieveByStatus(int companyId, int status)
        {
            List<Architect.API.Tron.Contracts.PolicyProposal> result = new List<Architect.API.Tron.Contracts.PolicyProposal>();
            Database.Select("SELECT Id, SigningRequestId, ProposalId, SignedRequest1, SigningRequest2Id, SignedRequest2, SigningRequest3Id, SignedRequest3" +
                             " FROM PolicyProposal " +
                             "WHERE CompanyId=:CompanyId AND Status=:Status")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter("Status", DbType.Decimal, 5, status)
                        .Query(null, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Architect.API.Tron.Contracts.PolicyProposal()
                            {
                                Id = reader.IntegerValue("Id"),
                                SigningRequestId = reader.StringValue("SigningRequestId"),
                                ProposalId = reader.StringValue("ProposalId"),
                                SignedRequest1 = reader.IntegerValue("SignedRequest1") == 1,
                                SigningRequest2Id = reader.StringValue("SigningRequest2Id"),
                                SignedRequest2 = reader.IntegerValue("SignedRequest2") == 1,
                                SigningRequest3Id = reader.StringValue("SigningRequest3Id"),
                                SignedRequest3 = reader.IntegerValue("SignedRequest3") == 1
                            }
                            );
                        }));
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla PolicyProposal por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de PolicyProposal</returns>
        public static Architect.API.Tron.Contracts.PolicyProposal RetrieveByProposalId(string proposalId, int companyId, IDbConnection connection = null)
        {
            Architect.API.Tron.Contracts.PolicyProposal result = null;
            Database.Select("SELECT ProposalData, SigningType, Id " +
                              "FROM PolicyProposal " +
                             "WHERE CompanyId=:CompanyId AND ProposalId=:ProposalId")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter("ProposalId", DbType.AnsiString, 13, proposalId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = new Architect.API.Tron.Contracts.PolicyProposal()
                            {
                                ProposalData = reader.StringValue("ProposalData"),
                                SigningType = reader.StringValue("SigningType"),
                                Id = reader.IntegerValue("Id")
                            };
                        }));
            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla PolicyProposal por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la solcitud.</param>
        /// <param name="status">Estado del presupuesto.</param>
        /// <param name="signingRequestId">.</param>
        /// <param name="userCode">Usuario que actualizo por última vez el registro.</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update_Status(int id, int status, string signingRequestId, int userCode)
        {
            return Database.Update("UPDATE PolicyProposal " +
                                      "SET Status=:Status, SigningRequestId=:SigningRequestId, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("Status", DbType.Decimal, 5, status)
                                .AddParameter("SigningRequestId", DbType.AnsiString, 40, signingRequestId)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, userCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, DateTime.Now)
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .Execute(null, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla PolicyProposal por medio de su clave primaria.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="policyId"></param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="status">Estado del presupuesto.</param>
        /// <param name="userCode">Usuario que actualizo por última vez el registro.</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update_Status(string proposalId, string policyId, int companyId, int status, int userCode)
        {
            return Database.Update("UPDATE PolicyProposal " +
                                      "SET Status=:Status, PolicyId=:PolicyId, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE CompanyId=:CompanyId AND ProposalId=:ProposalId")
                                .AddParameter("Status", DbType.Decimal, 5, status)
                                .AddParameter("PolicyId", DbType.AnsiString, 13, policyId)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, userCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, DateTime.Now)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .AddParameter("ProposalId", DbType.AnsiString, 13, proposalId)
                                .Execute(null, "Research");
        }

        /// <summary>
        /// Cambia el estado de una solicitud únicamente cuando conserva el estado esperado dentro de la compañía indicada.
        /// </summary>
        /// <param name="id">Identificador NUMBER(9) de la solicitud.</param>
        /// <param name="companyId">Compañía propietaria de la solicitud.</param>
        /// <param name="expectedStatus">Estado que debe conservar la solicitud antes del cambio.</param>
        /// <param name="nextStatus">Estado que se asignará a la solicitud.</param>
        /// <param name="userId">Usuario responsable de la transición.</param>
        /// <param name="signingRequestId">Identificador externo de firma que se conservará cuando se indique.</param>
        /// <param name="policyId">Identificador de póliza que se conservará cuando se indique.</param>
        /// <param name="connection">Instancia de una conexión compartida.</param>
        /// <returns><c>true</c> si se actualizó una única solicitud.</returns>
        public static bool TryTransition(
            int id,
            int companyId,
            int expectedStatus,
            int nextStatus,
            int userId,
            string signingRequestId = null,
            string policyId = null,
            IDbConnection connection = null)
        {
            int updated = Database.Update("UPDATE PolicyProposal " +
                                          "SET Status=:NextStatus, " +
                                              "SigningRequestId=NVL(:SigningRequestId, SigningRequestId), " +
                                              "PolicyId=NVL(:PolicyId, PolicyId), " +
                                              "UpdateUserCode=:UserId, UpdateDate=:UpdateDate " +
                                        "WHERE Id=:Id AND CompanyId=:CompanyId AND Status=:ExpectedStatus")
                .AddParameter("NextStatus", DbType.Decimal, 5, nextStatus)
                .AddParameter("SigningRequestId", DbType.AnsiString, 40, signingRequestId)
                .AddParameter("PolicyId", DbType.AnsiString, 13, policyId)
                .AddParameter("UserId", DbType.Decimal, 9, userId)
                .AddParameter("UpdateDate", DbType.DateTime, 0, DateTime.Now)
                .AddParameter("Id", DbType.Decimal, 9, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                .AddParameter("ExpectedStatus", DbType.Decimal, 5, expectedStatus)
                .Execute(connection, "Research");

            return updated == 1;
        }

        /// <summary>
        /// Guarda la instantánea definitiva y cambia el estado solo si la solicitud conserva el estado esperado.
        /// </summary>
        /// <param name="id">Identificador NUMBER(9) de la solicitud.</param>
        /// <param name="companyId">Compañía propietaria de la solicitud.</param>
        /// <param name="expectedStatus">Estado que debe conservar la solicitud antes del cambio.</param>
        /// <param name="nextStatus">Estado que se asignará a la solicitud.</param>
        /// <param name="proposalData">Instantánea JSON que se almacenará.</param>
        /// <param name="userId">Usuario responsable de la transición.</param>
        /// <param name="connection">Conexión transaccional compartida.</param>
        /// <returns><c>true</c> si se actualizó una única solicitud.</returns>
        public static bool TrySaveSnapshotAndTransition(
            int id,
            int companyId,
            int expectedStatus,
            int nextStatus,
            string proposalData,
            int userId,
            IDbConnection connection)
        {
            int updated = Database.Update("UPDATE PolicyProposal " +
                                          "SET ProposalData=:ProposalData, Status=:NextStatus, " +
                                              "UpdateUserCode=:UserId, UpdateDate=:UpdateDate " +
                                        "WHERE Id=:Id AND CompanyId=:CompanyId AND Status=:ExpectedStatus")
                .AddParameter("ProposalData", DbType.Clob, 0, proposalData)
                .AddParameter("NextStatus", DbType.Decimal, 5, nextStatus)
                .AddParameter("UserId", DbType.Decimal, 9, userId)
                .AddParameter("UpdateDate", DbType.DateTime, 0, DateTime.Now)
                .AddParameter("Id", DbType.Decimal, 9, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                .AddParameter("ExpectedStatus", DbType.Decimal, 5, expectedStatus)
                .Execute(connection, "Research");

            return updated == 1;
        }

        /// <summary>
        /// Actualiza la instantánea y el correo del asegurado sin modificar ningún otro dato de la solicitud.
        /// </summary>
        /// <param name="id">Identificador técnico de la solicitud.</param>
        /// <param name="companyId">Compañía propietaria de la solicitud.</param>
        /// <param name="proposalData">Instantánea JSON con el correo corregido.</param>
        /// <param name="recipientEmail">Correo actualizado del asegurado.</param>
        /// <param name="userId">Usuario responsable del cambio.</param>
        /// <returns><c>true</c> cuando la solicitud aún está pendiente por complementos.</returns>
        public static bool TryUpdateRecipientEmailAndSnapshot(int id, int companyId, string proposalData, string recipientEmail, int userId)
        {
            int updated = Database.Update("UPDATE PolicyProposal SET ProposalData=:ProposalData, PrimaryEmailAddress=:RecipientEmail, " +
                                          "UpdateUserCode=:UserId, UpdateDate=:UpdateDate " +
                                          "WHERE Id=:Id AND CompanyId=:CompanyId AND Status=:Status")
                .AddParameter("ProposalData", DbType.Clob, 0, proposalData)
                .AddParameter("RecipientEmail", DbType.AnsiString, 80, recipientEmail)
                .AddParameter("UserId", DbType.Decimal, 9, userId)
                .AddParameter("UpdateDate", DbType.DateTime, 0, DateTime.Now)
                .AddParameter("Id", DbType.Decimal, 9, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                .AddParameter("Status", DbType.Decimal, 5, Contracts.PolicyProposalStatus.PendientePorComplementos)
                .Execute(null, "Research");
            return updated == 1;
        }

        /// <summary>
        /// Elimina un registro en la tabla PolicyProposal por medio del numero de propuesta.
        /// </summary>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(string proposalId, int companyId)
        {
            return Database.Delete("DELETE FROM PolicyProposal " +
                                    "WHERE CompanyId=:CompanyId AND ProposalId=:ProposalId")
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .AddParameter("ProposalId", DbType.AnsiString, 13, proposalId)
                                .Execute(null, "Research");
        }
    }

}

