using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.ManualClaims
{
    /// <summary>
    /// .
    /// </summary>
    public sealed partial class ClaimDocumentRequest
    {

        /// <summary>
        /// Crea un registro en la tabla ClaimDocumentRequest.
        /// </summary>
        /// <param name="claimdocumentrequestItem">Instancia de ClaimDocumentRequest</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest claimdocumentrequestItem, IDbConnection connection = null)
        {
            if (claimdocumentrequestItem.UpdateDate.IsEmpty())
            {
                claimdocumentrequestItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO ClaimDocumentRequest (Id, CompanyId, ClaimInternalId, DocumentType, Description, RequestDate, DueDate, ReceivedDate, Status, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :ClaimInternalId, :DocumentType, :Description, :RequestDate, :DueDate, :ReceivedDate, :Status, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, claimdocumentrequestItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, claimdocumentrequestItem.CompanyId)
                            .AddParameter("ClaimInternalId", DbType.Decimal, 9, claimdocumentrequestItem.ClaimInternalId)
                            .AddParameter("DocumentType", DbType.Decimal, 5, claimdocumentrequestItem.DocumentType)
                            .AddParameter("Description", DbType.AnsiString, 256, claimdocumentrequestItem.Description)
                            .AddParameter("RequestDate", DbType.DateTime, 9, claimdocumentrequestItem.RequestDate)
                            .AddParameter("DueDate", DbType.DateTime, 9, claimdocumentrequestItem.DueDate)
                            .AddParameter("ReceivedDate", DbType.DateTime, 9, claimdocumentrequestItem.ReceivedDate)
                            .AddParameter("Status", DbType.Decimal, 5, claimdocumentrequestItem.Status)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, claimdocumentrequestItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, claimdocumentrequestItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla ClaimDocumentRequest.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="claimdocumentrequestItems">Lista de instancia de ClaimDocumentRequest</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest> claimdocumentrequestItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest item in claimdocumentrequestItems)
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
        /// Recupera un registro en la tabla ClaimDocumentRequest por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del siniestro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ClaimDocumentRequest</returns>
        public static Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest result = null;
            Database.Select("SELECT Id, ClaimDocumentRequest.CompanyId, ClaimInternalId, DocumentType, Description, RequestDate, DueDate, ReceivedDate, Status, ClaimDocumentRequest.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ClaimDocumentRequest.UpdateDate " +
                              "FROM ClaimDocumentRequest LEFT JOIN UserMember um ON um.UserId = ClaimDocumentRequest.UpdateUserCode " +
                             "WHERE ClaimDocumentRequest.Id=:Id AND ClaimDocumentRequest.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToClaimDocumentRequest(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ClaimDocumentRequest.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ClaimDocumentRequest</returns>
        public static List<Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest> result = new List<Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest>();
            Database.Select("SELECT Id, ClaimDocumentRequest.CompanyId, ClaimInternalId, DocumentType, Description, RequestDate, DueDate, ReceivedDate, Status, ClaimDocumentRequest.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ClaimDocumentRequest.UpdateDate " +
                              "FROM ClaimDocumentRequest LEFT JOIN UserMember um ON um.UserId = ClaimDocumentRequest.UpdateUserCode " +
                             "WHERE ClaimDocumentRequest.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToClaimDocumentRequest(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ClaimDocumentRequest.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ClaimDocumentRequest</returns>
        public static List<Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest> result = new List<Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, ClaimDocumentRequest.CompanyId, ClaimInternalId, DocumentType, Description, RequestDate, DueDate, ReceivedDate, Status, ClaimDocumentRequest.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ClaimDocumentRequest.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY ClaimDocumentRequest.Id DESC) RowNumber " +
                              "FROM ClaimDocumentRequest LEFT JOIN UserMember um ON um.UserId = ClaimDocumentRequest.UpdateUserCode " +
                             "WHERE ClaimDocumentRequest.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToClaimDocumentRequest(reader));
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
        /// Último valor asignado a clave única de la tabla ClaimDocumentRequest.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM ClaimDocumentRequest")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla ClaimDocumentRequest por medio de su clave primaria.
        /// </summary>
        /// <param name="claimdocumentrequestItem">Instancia de ClaimDocumentRequest</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest claimdocumentrequestItem, IDbConnection connection = null)
        {
            if (claimdocumentrequestItem.UpdateDate.IsEmpty())
            {
                claimdocumentrequestItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE ClaimDocumentRequest " +
                                      "SET CompanyId=:CompanyId, ClaimInternalId=:ClaimInternalId, DocumentType=:DocumentType, Description=:Description, RequestDate=:RequestDate, DueDate=:DueDate, ReceivedDate=:ReceivedDate, Status=:Status, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, claimdocumentrequestItem.CompanyId)
                                .AddParameter("ClaimInternalId", DbType.Decimal, 9, claimdocumentrequestItem.ClaimInternalId)
                                .AddParameter("DocumentType", DbType.Decimal, 5, claimdocumentrequestItem.DocumentType)
                                .AddParameter("Description", DbType.AnsiString, 256, claimdocumentrequestItem.Description)
                                .AddParameter("RequestDate", DbType.DateTime, 9, claimdocumentrequestItem.RequestDate)
                                .AddParameter("DueDate", DbType.DateTime, 9, claimdocumentrequestItem.DueDate)
                                .AddParameter("ReceivedDate", DbType.DateTime, 9, claimdocumentrequestItem.ReceivedDate)
                                .AddParameter("Status", DbType.Decimal, 5, claimdocumentrequestItem.Status)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, claimdocumentrequestItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, claimdocumentrequestItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, claimdocumentrequestItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ClaimDocumentRequest por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="claimdocumentrequestItems">Lista de instancia de ClaimDocumentRequest</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest> claimdocumentrequestItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest item in claimdocumentrequestItems)
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
        /// Elimina un registro en la tabla ClaimDocumentRequest por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del siniestro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ClaimDocumentRequest " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ClaimDocumentRequest por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única del siniestro.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla ClaimDocumentRequest por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del siniestro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ClaimDocumentRequest " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ClaimDocumentRequest que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ClaimDocumentRequest " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'ClaimDocumentRequest'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest DataReaderToClaimDocumentRequest(System.Data.IDataReader reader, Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Insurance.Contracts.ManualClaims.ClaimDocumentRequest();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.ClaimInternalId = reader.IntegerValue("ClaimInternalId");
            item.DocumentType = reader.IntegerValue("DocumentType");
            item.Description = reader.StringValue("Description");
            item.RequestDate = reader.DateTimeValue("RequestDate");
            item.DueDate = reader.DateTimeValue("DueDate");
            item.ReceivedDate = reader.DateTimeValue("ReceivedDate");
            item.Status = reader.IntegerValue("Status");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

