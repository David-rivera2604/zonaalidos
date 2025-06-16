using Architect.DataFactory;
using Architect.DataFactory.Enumerations;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.Security
{
    /// <summary>
    /// Auditoria de autenticación de usuarios e intentos de acceso al sistema.
    /// </summary>
    public sealed partial class AuthenticationTrace
    {

        /// <summary>
        /// Crea un registro en la tabla AuthenticationTrace.
        /// </summary>
        /// <param name="authenticationtraceItem">Instancia de AuthenticationTrace</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.Security.AuthenticationTrace authenticationtraceItem, IDbConnection connection = null)
        {
            if (authenticationtraceItem.UpdateDate.IsEmpty())
            {
                authenticationtraceItem.UpdateDate = DateTime.Now;
            }

            List<DataFactory.Contracts.Parameter> parameters = Database.ParameterList()
                            .AddParameter("CompanyId", DbType.Decimal, 5, authenticationtraceItem.CompanyId)
                            .AddParameter("EffectDate", DbType.DateTime, 9, authenticationtraceItem.EffectDate)
                            .AddParameter("IPAddress", DbType.AnsiString, 20, authenticationtraceItem.IPAddress)
                            .AddParameter("UserName", DbType.AnsiString, 35, authenticationtraceItem.UserName)
                            .AddParameter("UserId", DbType.Decimal, 9, authenticationtraceItem.UserId)
                            .AddParameter("TraceType", DbType.Decimal, 5, authenticationtraceItem.TraceType)
                            .AddParameter("Reason", DbType.AnsiString, 60, authenticationtraceItem.Reason)
                            .AddParameter("UserAgent", DbType.AnsiString, 512, authenticationtraceItem.UserAgent)
                            .AddParameter("Id", DbType.Decimal, 9, 0, ParameterDirection.Output)
                            .Parameters;

            int rows = Database.Insert("INSERT INTO AuthenticationTrace (Id, CompanyId, EffectDate, IPAddress, UserName, UserId, TraceType, Reason, UserAgent) " +
                                       "VALUES((SELECT NVL(MAX(Id),0)+1 FROM AuthenticationTrace), :CompanyId, :EffectDate, :IPAddress, :UserName, :UserId, :TraceType, :Reason, :UserAgent) " +
                                       "RETURNING Id INTO :Id")
                                .AddParameter(parameters)
                                .Execute(connection, "Research");

            int id = Convert.ToInt32(parameters.Find(r => r.Name == "Id").Value.ToString());
            return id;
        }

        /// <summary>
        /// Crea una lista de registros en la tabla AuthenticationTrace.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="authenticationtraceItems">Lista de instancia de AuthenticationTrace</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.Security.AuthenticationTrace> authenticationtraceItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.Security.AuthenticationTrace item in authenticationtraceItems)
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
        /// Recupera un registro en la tabla AuthenticationTrace por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificador único.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de AuthenticationTrace</returns>
        public static Architect.API.Core.Contracts.Security.AuthenticationTrace Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.Security.AuthenticationTrace result = null;
            Database.Select("SELECT Id, CompanyId, EffectDate, IPAddress, UserName, UserId, TraceType, Reason, UserAgent " +
                              "FROM AuthenticationTrace " +
                             "WHERE Id=:Id AND AuthenticationTrace.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToAuthenticationTrace(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla AuthenticationTrace.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de AuthenticationTrace</returns>
        public static List<Architect.API.Core.Contracts.Security.AuthenticationTrace> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.Security.AuthenticationTrace> result = new List<Architect.API.Core.Contracts.Security.AuthenticationTrace>();
            Database.Select("SELECT Id, CompanyId, EffectDate, IPAddress, UserName, UserId, TraceType, Reason, UserAgent " +
                              "FROM AuthenticationTrace " +
                             "WHERE AuthenticationTrace.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToAuthenticationTrace(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla AuthenticationTrace.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de AuthenticationTrace</returns>
        public static List<Architect.API.Core.Contracts.Security.AuthenticationTrace> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.Security.AuthenticationTrace> result = new List<Architect.API.Core.Contracts.Security.AuthenticationTrace>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, CompanyId, EffectDate, IPAddress, UserName, UserId, TraceType, Reason, UserAgent " +
                                   ", ROW_NUMBER() OVER (ORDER BY AuthenticationTrace.Id DESC) RowNumber " +
                              "FROM AuthenticationTrace " +
                             "WHERE AuthenticationTrace.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToAuthenticationTrace(reader));
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
        /// Último valor asignado a clave única de la tabla AuthenticationTrace.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM AuthenticationTrace")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        public static int RetrieveLastKey(DataFactory.Session session)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM AuthenticationTrace")
                                .QueryScalar<Decimal>(session);
        }

        /// <summary>
        /// Actualiza un registro en la tabla AuthenticationTrace por medio de su clave primaria.
        /// </summary>
        /// <param name="authenticationtraceItem">Instancia de AuthenticationTrace</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.Security.AuthenticationTrace authenticationtraceItem, IDbConnection connection = null)
        {
            if (authenticationtraceItem.UpdateDate.IsEmpty())
            {
                authenticationtraceItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE AuthenticationTrace " +
                                      "SET CompanyId=:CompanyId, EffectDate=:EffectDate, IPAddress=:IPAddress, UserName=:UserName, UserId=:UserId, TraceType=:TraceType, Reason=:Reason, UserAgent=:UserAgent " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, authenticationtraceItem.CompanyId)
                                .AddParameter("EffectDate", DbType.DateTime, 9, authenticationtraceItem.EffectDate)
                                .AddParameter("IPAddress", DbType.AnsiString, 20, authenticationtraceItem.IPAddress)
                                .AddParameter("UserName", DbType.AnsiString, 35, authenticationtraceItem.UserName)
                                .AddParameter("UserId", DbType.Decimal, 9, authenticationtraceItem.UserId)
                                .AddParameter("TraceType", DbType.Decimal, 5, authenticationtraceItem.TraceType)
                                .AddParameter("Reason", DbType.AnsiString, 60, authenticationtraceItem.Reason)
                                .AddParameter("UserAgent", DbType.AnsiString, 512, authenticationtraceItem.UserAgent)
                                .AddParameter("Id", DbType.Decimal, 9, authenticationtraceItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla AuthenticationTrace por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="authenticationtraceItems">Lista de instancia de AuthenticationTrace</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.Security.AuthenticationTrace> authenticationtraceItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.Security.AuthenticationTrace item in authenticationtraceItems)
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
        /// Elimina un registro en la tabla AuthenticationTrace por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificador único.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM AuthenticationTrace " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla AuthenticationTrace por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificador único.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla AuthenticationTrace por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificador único.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM AuthenticationTrace " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla AuthenticationTrace que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM AuthenticationTrace " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'AuthenticationTrace'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.Security.AuthenticationTrace DataReaderToAuthenticationTrace(System.Data.IDataReader reader, Architect.API.Core.Contracts.Security.AuthenticationTrace item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.Security.AuthenticationTrace();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.EffectDate = reader.DateTimeValue("EffectDate");
            item.IPAddress = reader.StringValue("IPAddress");
            item.UserName = reader.StringValue("UserName");
            item.UserId = reader.IntegerValue("UserId");
            item.TraceType = reader.IntegerValue("TraceType");
            item.Reason = reader.StringValue("Reason");
            item.UserAgent = reader.StringValue("UserAgent");
            return item;
        }

    }

}

