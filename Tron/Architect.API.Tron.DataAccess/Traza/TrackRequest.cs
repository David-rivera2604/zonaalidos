using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Traza
{
    /// <summary>
    /// Traza de solicitudes y respuestas.
    /// </summary>
    public sealed partial class TrackRequest
    {

        /// <summary>
        /// Crea un registro en la tabla TrackRequest.
        /// </summary>
        /// <param name="trackrequestItem">Instancia de TrackRequest</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Identificación unica del registro.</returns>
        public static int Create(Architect.API.Tron.Contracts.Traza.TrackRequest trackrequestItem, IDbConnection connection = null)
        {
            if (trackrequestItem.UpdateDate.IsEmpty())
            {
                trackrequestItem.UpdateDate = DateTime.Now;
            }

            List<DataFactory.Contracts.Parameter> parameters = Database.ParameterList()
                            .AddParameter("CompanyId", DbType.Decimal, 5, trackrequestItem.CompanyId)
                            .AddParameter("DocumentId", DbType.AnsiString, 40, trackrequestItem.DocumentId)
                            .AddParameter("RequestType", DbType.AnsiString, 40, trackrequestItem.RequestType)
                            .AddParameter("RequestBody", DbType.AnsiString, 4000, trackrequestItem.RequestBody)
                            .AddParameter("RequestTimeStamp", DbType.DateTime, 9, trackrequestItem.RequestTimeStamp)
                            .AddParameter("MessageId", DbType.AnsiString, 40, trackrequestItem.MessageId)
                            .AddParameter("ResponseStatus", DbType.Decimal, 5, trackrequestItem.ResponseStatus)
                            .AddParameter("ResponseText", DbType.AnsiString, 512, trackrequestItem.ResponseText)
                            .AddParameter("ResponseBody", DbType.AnsiString, 4000, trackrequestItem.ResponseBody)
                            .AddParameter("ResponseTimeStamp", DbType.DateTime, 9, trackrequestItem.ResponseTimeStamp)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, trackrequestItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, trackrequestItem.UpdateDate)
                            .AddParameter("Id", DbType.Decimal, 9, 0, ParameterDirection.Output)
                            .Parameters;

            int rows = Database.Insert("INSERT INTO TrackRequest (Id, CompanyId, DocumentId, RequestType, RequestBody, RequestTimeStamp, MessageId, ResponseStatus, ResponseText, ResponseBody, ResponseTimeStamp, UpdateUserCode, UpdateDate) " +
                                                 "VALUES((SELECT NVL(MAX(Id),0)+1 FROM TrackRequest), :CompanyId, :DocumentId, :RequestType, :RequestBody, :RequestTimeStamp, :MessageId, :ResponseStatus, :ResponseText, :ResponseBody, :ResponseTimeStamp, :UpdateUserCode, :UpdateDate) " +
                                                 " RETURNING Id INTO :Id")
                            .AddParameter(parameters)
                            .Execute(connection, "Research");
            int id = Convert.ToInt32(parameters.Find(r => r.Name == "Id").Value.ToString());

            return id;
        }

        /// <summary>
        /// Recupera un registro en la tabla TrackRequest por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del pago.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de TrackRequest</returns>
        public static Architect.API.Tron.Contracts.Traza.TrackRequest Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Tron.Contracts.Traza.TrackRequest result = null;
            Database.Select("SELECT Id, TrackRequest.CompanyId, DocumentId, RequestType, RequestBody, RequestTimeStamp, MessageId, ResponseStatus, ResponseText, ResponseBody, ResponseTimeStamp, TrackRequest.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, TrackRequest.UpdateDate " +
                              "FROM TrackRequest LEFT JOIN UserMember um ON um.UserId = TrackRequest.UpdateUserCode " +
                             "WHERE TrackRequest.Id=:Id AND TrackRequest.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToTrackRequest(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla TrackRequest.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de TrackRequest</returns>
        public static List<Architect.API.Tron.Contracts.Traza.TrackRequest> RetrieveAll(int companyId, string filter, List<Architect.DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Tron.Contracts.Traza.TrackRequest> result = new List<Architect.API.Tron.Contracts.Traza.TrackRequest>();
            Database.Select("SELECT Id, TrackRequest.CompanyId, DocumentId, RequestType, RequestBody, RequestTimeStamp, MessageId, ResponseStatus, ResponseText, ResponseBody, ResponseTimeStamp, TrackRequest.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, TrackRequest.UpdateDate " +
                              "FROM TrackRequest LEFT JOIN UserMember um ON um.UserId = TrackRequest.UpdateUserCode " +
                             "WHERE TrackRequest.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToTrackRequest(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla TrackRequest.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de TrackRequest</returns>
        public static List<Architect.API.Tron.Contracts.Traza.TrackRequest> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<Architect.DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Tron.Contracts.Traza.TrackRequest> result = new List<Architect.API.Tron.Contracts.Traza.TrackRequest>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, TrackRequest.CompanyId, DocumentId, RequestType, RequestBody, RequestTimeStamp, MessageId, ResponseStatus, ResponseText, ResponseBody, ResponseTimeStamp, TrackRequest.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, TrackRequest.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY TrackRequest.Id DESC) RowNumber " +
                              "FROM TrackRequest LEFT JOIN UserMember um ON um.UserId = TrackRequest.UpdateUserCode " +
                             "WHERE TrackRequest.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToTrackRequest(reader));
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
        /// Actualiza un registro en la tabla TrackRequest por medio de su clave primaria.
        /// </summary>
        /// <param name="trackrequestItem">Instancia de TrackRequest</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Tron.Contracts.Traza.TrackRequest trackrequestItem, IDbConnection connection = null)
        {
            if (trackrequestItem.UpdateDate.IsEmpty())
            {
                trackrequestItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE TrackRequest " +
                                      "SET CompanyId=:CompanyId, DocumentId=:DocumentId, RequestType=:RequestType, RequestBody=:RequestBody, RequestTimeStamp=:RequestTimeStamp, MessageId=:MessageId, ResponseStatus=:ResponseStatus, ResponseText=:ResponseText, ResponseBody=:ResponseBody, ResponseTimeStamp=:ResponseTimeStamp, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, trackrequestItem.CompanyId)
                                .AddParameter("DocumentId", DbType.AnsiString, 40, trackrequestItem.DocumentId)
                                .AddParameter("RequestType", DbType.AnsiString, 40, trackrequestItem.RequestType)
                                .AddParameter("RequestBody", DbType.AnsiString, 4000, trackrequestItem.RequestBody)
                                .AddParameter("RequestTimeStamp", DbType.DateTime, 9, trackrequestItem.RequestTimeStamp)
                                .AddParameter("MessageId", DbType.AnsiString, 40, trackrequestItem.MessageId)
                                .AddParameter("ResponseStatus", DbType.Decimal, 5, trackrequestItem.ResponseStatus)
                                .AddParameter("ResponseText", DbType.AnsiString, 512, trackrequestItem.ResponseText)
                                .AddParameter("ResponseBody", DbType.AnsiString, 4000, trackrequestItem.ResponseBody)
                                .AddParameter("ResponseTimeStamp", DbType.DateTime, 9, trackrequestItem.ResponseTimeStamp)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, trackrequestItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, trackrequestItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, trackrequestItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla TrackRequest por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="trackrequestItems">Lista de instancia de TrackRequest</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Tron.Contracts.Traza.TrackRequest> trackrequestItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Tron.Contracts.Traza.TrackRequest item in trackrequestItems)
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
        /// Elimina un registro en la tabla TrackRequest por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del pago.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM TrackRequest " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla TrackRequest por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única del pago.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla TrackRequest por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del pago.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM TrackRequest " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla TrackRequest que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<Architect.DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM TrackRequest " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'TrackRequest'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Tron.Contracts.Traza.TrackRequest DataReaderToTrackRequest(System.Data.IDataReader reader, Architect.API.Tron.Contracts.Traza.TrackRequest item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Tron.Contracts.Traza.TrackRequest();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.DocumentId = reader.StringValue("DocumentId");
            item.RequestType = reader.StringValue("RequestType");
            item.RequestBody = reader.StringValue("RequestBody");
            item.RequestTimeStamp = reader.DateTimeValue("RequestTimeStamp");
            item.MessageId = reader.StringValue("MessageId");
            item.ResponseStatus = reader.IntegerValue("ResponseStatus");
            item.ResponseText = reader.StringValue("ResponseText");
            item.ResponseBody = reader.StringValue("ResponseBody");
            item.ResponseTimeStamp = reader.DateTimeValue("ResponseTimeStamp");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }


        /// <summary>
        /// Actualiza un registro en la tabla TrackRequest por medio de su clave primaria.
        /// </summary>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update2(Architect.API.Tron.Contracts.Traza.TrackRequest trackrequestItem, IDbConnection connection = null)
        {
            if (trackrequestItem.UpdateDate.IsEmpty())
            {
                trackrequestItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE TrackRequest " +
                                      "SET MessageId=:MessageId, ResponseStatus=:ResponseStatus, ResponseText=:ResponseText, ResponseBody=:ResponseBody, ResponseTimeStamp=:ResponseTimeStamp, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("MessageId", DbType.AnsiString, 40, trackrequestItem.MessageId)
                                .AddParameter("ResponseStatus", DbType.Decimal, 5, trackrequestItem.ResponseStatus)
                                .AddParameter("ResponseText", DbType.AnsiString, 512, trackrequestItem.ResponseText)
                                .AddParameter("ResponseBody", DbType.AnsiString, 4000, trackrequestItem.ResponseBody)
                                .AddParameter("ResponseTimeStamp", DbType.DateTime, 9, trackrequestItem.ResponseTimeStamp)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, trackrequestItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, trackrequestItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, trackrequestItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Recupera un registro en la tabla TrackRequest por medio de su clave primaria.
        /// </summary>
        /// <returns>Instancia de TrackRequest</returns>
        public static Architect.API.Tron.Contracts.Traza.TrackRequest Retrieve(string documentId, int companyId, IDbConnection connection = null)
        {
            Architect.API.Tron.Contracts.Traza.TrackRequest result = null;
            Database.Select("SELECT Id, TrackRequest.CompanyId, DocumentId, RequestType, RequestBody, RequestTimeStamp, MessageId, ResponseStatus, ResponseText, ResponseBody, ResponseTimeStamp, TrackRequest.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, TrackRequest.UpdateDate " +
                              "FROM TrackRequest LEFT JOIN UserMember um ON um.UserId = TrackRequest.UpdateUserCode " +
                             "WHERE TrackRequest.DocumentId=:DocumentId AND TrackRequest.CompanyId=:CompanyId")
                        .AddParameter("DocumentId", DbType.AnsiString, 40, documentId)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToTrackRequest(reader);
                        }));
            return result;
        }


    }

}

