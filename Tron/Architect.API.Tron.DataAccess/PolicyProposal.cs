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
        /// Crea un registro en la tabla PolicyProposal.
        /// </summary>
        /// <param name="policyproposalItem">Instancia de PolicyProposal</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Tron.Contracts.PolicyProposal policyproposalItem, IDbConnection connection = null)
        {
            if (policyproposalItem.UpdateDate.IsEmpty())
            {
                policyproposalItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO PolicyProposal (Id, CompanyId, AgentCode, ProposalId, InsuredId, InsuredName, Summary, IssueDate, ProposalData, SigningType, PrimaryEmailAddress, SigningRequestId, PolicyId, Status, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :AgentCode, :ProposalId, :InsuredId, :InsuredName, :Summary, :IssueDate, :ProposalData, :SigningType, :PrimaryEmailAddress, :SigningRequestId, :PolicyId, :Status, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, policyproposalItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, policyproposalItem.CompanyId)
                            .AddParameter("AgentCode", DbType.Decimal, 9, policyproposalItem.AgentCode)
                            .AddParameter("ProposalId", DbType.AnsiString, 13, policyproposalItem.ProposalId)
                            .AddParameter("InsuredId", DbType.AnsiString, 20, policyproposalItem.InsuredId)
                            .AddParameter("InsuredName", DbType.AnsiString, 120, policyproposalItem.InsuredName)
                            .AddParameter("Summary", DbType.AnsiString, 120, policyproposalItem.Summary)
                            .AddParameter("IssueDate", DbType.DateTime, 9, policyproposalItem.IssueDate)
                            .AddParameter("ProposalData", DbType.Clob, 0, policyproposalItem.ProposalData)
                            .AddParameter("SigningType", DbType.AnsiString, 3, policyproposalItem.SigningType)
                            .AddParameter("PrimaryEmailAddress", DbType.AnsiString, 80, policyproposalItem.PrimaryEmailAddress)
                            .AddParameter("SigningRequestId", DbType.AnsiString, 40, policyproposalItem.SigningRequestId)
                            .AddParameter("PolicyId", DbType.AnsiString, 13, policyproposalItem.PolicyId)
                            .AddParameter("Status", DbType.Decimal, 5, policyproposalItem.Status)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, policyproposalItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, policyproposalItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla PolicyProposal.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="policyproposalItems">Lista de instancia de PolicyProposal</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Tron.Contracts.PolicyProposal> policyproposalItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Tron.Contracts.PolicyProposal item in policyproposalItems)
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
        /// Recupera un registro en la tabla PolicyProposal por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la solcitud.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de PolicyProposal</returns>
        public static Architect.API.Tron.Contracts.PolicyProposal Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Tron.Contracts.PolicyProposal result = null;
            Database.Select("SELECT Id, PolicyProposal.CompanyId, AgentCode, ProposalId, InsuredId, InsuredName, Summary, IssueDate, ProposalData, SigningType, PrimaryEmailAddress, SigningRequestId, SignedRequest1, SigningRequest2Id, SignedRequest2, SigningRequest3Id, SignedRequest3, PolicyId, Status, PolicyProposal.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, PolicyProposal.UpdateDate " +
                              "FROM PolicyProposal LEFT JOIN UserMember um ON um.UserId = PolicyProposal.UpdateUserCode " +
                             "WHERE PolicyProposal.Id=:Id AND PolicyProposal.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToPolicyProposal(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla PolicyProposal.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de PolicyProposal</returns>
        public static List<Architect.API.Tron.Contracts.PolicyProposal> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Tron.Contracts.PolicyProposal> result = new List<Architect.API.Tron.Contracts.PolicyProposal>();
            Database.Select("SELECT Id, PolicyProposal.CompanyId, AgentCode, ProposalId, InsuredId, InsuredName, Summary, IssueDate, ProposalData, SigningType, PrimaryEmailAddress, SigningRequestId, SignedRequest1, SigningRequest2Id, SignedRequest2, SigningRequest3Id, SignedRequest3, PolicyId, Status, PolicyProposal.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, PolicyProposal.UpdateDate " +
                              "FROM PolicyProposal LEFT JOIN UserMember um ON um.UserId = PolicyProposal.UpdateUserCode " +
                             "WHERE PolicyProposal.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToPolicyProposal(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla PolicyProposal.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de PolicyProposal</returns>
        public static List<Architect.API.Tron.Contracts.PolicyProposal> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Tron.Contracts.PolicyProposal> result = new List<Architect.API.Tron.Contracts.PolicyProposal>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, PolicyProposal.CompanyId, AgentCode, ProposalId, InsuredId, InsuredName, Summary, IssueDate, ProposalData, SigningType, PrimaryEmailAddress, SigningRequestId, SignedRequest1, SigningRequest2Id, SignedRequest2, SigningRequest3Id, SignedRequest3, PolicyId, Status, PolicyProposal.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, PolicyProposal.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY PolicyProposal.Id DESC) RowNumber " +
                              "FROM PolicyProposal LEFT JOIN UserMember um ON um.UserId = PolicyProposal.UpdateUserCode " +
                             "WHERE PolicyProposal.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToPolicyProposal(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Genera complemento de la consulta para habilitar el filtro por columnas establecidas.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros.</param>
        /// <param name="includeWhere">Indica que el complemento debe incluir el WHERE del comando.</param>
        /// <returns>Complemento de la consulta</returns>
        public static string FilterBuilder(string filter, bool includeWhere = true)
        {
            string result = string.Empty;


            return result;
        }

        /// <summary>
        /// Último valor asignado a clave única de la tabla PolicyProposal.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM PolicyProposal")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla PolicyProposal por medio de su clave primaria.
        /// </summary>
        /// <param name="policyproposalItem">Instancia de PolicyProposal</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Tron.Contracts.PolicyProposal policyproposalItem, IDbConnection connection = null)
        {
            if (policyproposalItem.UpdateDate.IsEmpty())
            {
                policyproposalItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE PolicyProposal " +
                                      "SET CompanyId=:CompanyId, AgentCode=:AgentCode, ProposalId=:ProposalId, InsuredId=:InsuredId, InsuredName=:InsuredName, Summary=:Summary, IssueDate=:IssueDate, ProposalData=:ProposalData, SigningType=:SigningType, PrimaryEmailAddress=:PrimaryEmailAddress, SigningRequestId=:SigningRequestId, SignedRequest1=:SignedRequest1, SigningRequest2Id=:SigningRequest2Id, SignedRequest2=:SignedRequest2, SigningRequest3Id=:SigningRequest3Id, SignedRequest3=:SignedRequest3, PolicyId=:PolicyId, Status=:Status, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, policyproposalItem.CompanyId)
                                .AddParameter("AgentCode", DbType.Decimal, 9, policyproposalItem.AgentCode)
                                .AddParameter("ProposalId", DbType.AnsiString, 13, policyproposalItem.ProposalId)
                                .AddParameter("InsuredId", DbType.AnsiString, 20, policyproposalItem.InsuredId)
                                .AddParameter("InsuredName", DbType.AnsiString, 120, policyproposalItem.InsuredName)
                                .AddParameter("Summary", DbType.AnsiString, 120, policyproposalItem.Summary)
                                .AddParameter("IssueDate", DbType.DateTime, 9, policyproposalItem.IssueDate)
                                .AddParameter("ProposalData", DbType.Clob, 0, policyproposalItem.ProposalData)
                                .AddParameter("SigningType", DbType.AnsiString, 3, policyproposalItem.SigningType)
                                .AddParameter("PrimaryEmailAddress", DbType.AnsiString, 80, policyproposalItem.PrimaryEmailAddress)
                                .AddParameter("SigningRequestId", DbType.AnsiString, 40, policyproposalItem.SigningRequestId)
                                .AddParameter("SignedRequest1", DbType.Decimal, 1, policyproposalItem.SignedRequest1 ? 1 : 0)
                                .AddParameter("SigningRequest2Id", DbType.AnsiString, 40, policyproposalItem.SigningRequest2Id)
                                .AddParameter("SignedRequest2", DbType.Decimal, 1, policyproposalItem.SignedRequest2 ? 1 : 0)
                                .AddParameter("SigningRequest3Id", DbType.AnsiString, 40, policyproposalItem.SigningRequest3Id)
                                .AddParameter("SignedRequest3", DbType.Decimal, 1, policyproposalItem.SignedRequest3 ? 1 : 0)
                                .AddParameter("PolicyId", DbType.AnsiString, 13, policyproposalItem.PolicyId)
                                .AddParameter("Status", DbType.Decimal, 5, policyproposalItem.Status)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, policyproposalItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, policyproposalItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, policyproposalItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla PolicyProposal por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="policyproposalItems">Lista de instancia de PolicyProposal</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Tron.Contracts.PolicyProposal> policyproposalItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Tron.Contracts.PolicyProposal item in policyproposalItems)
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
        /// Elimina un registro en la tabla PolicyProposal por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la solcitud.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM PolicyProposal " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla PolicyProposal por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única de la solcitud.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla PolicyProposal por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la solcitud.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM PolicyProposal " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla PolicyProposal que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM PolicyProposal " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'PolicyProposal'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Tron.Contracts.PolicyProposal DataReaderToPolicyProposal(System.Data.IDataReader reader, Architect.API.Tron.Contracts.PolicyProposal item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Tron.Contracts.PolicyProposal();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.AgentCode = reader.IntegerValue("AgentCode");
            item.ProposalId = reader.StringValue("ProposalId");
            item.InsuredId = reader.StringValue("InsuredId");
            item.InsuredName = reader.StringValue("InsuredName");
            item.Summary = reader.StringValue("Summary");
            item.IssueDate = reader.DateTimeValue("IssueDate");
            item.ProposalData = reader.StringValue("ProposalData");
            item.SigningType = reader.StringValue("SigningType");
            item.PrimaryEmailAddress = reader.StringValue("PrimaryEmailAddress");
            item.SigningRequestId = reader.StringValue("SigningRequestId");
            item.SignedRequest1 = reader.IntegerValue("SignedRequest1") == 1;
            item.SigningRequest2Id = reader.StringValue("SigningRequest2Id");
            item.SignedRequest2 = reader.IntegerValue("SignedRequest2") == 1;
            item.SigningRequest3Id = reader.StringValue("SigningRequest3Id");
            item.SignedRequest3 = reader.IntegerValue("SignedRequest3") == 1;
            item.PolicyId = reader.StringValue("PolicyId");
            item.Status = reader.IntegerValue("Status");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}
