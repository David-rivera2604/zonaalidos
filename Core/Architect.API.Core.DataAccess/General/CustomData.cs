using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Custom Data..
    /// </summary>
    public sealed partial class CustomData
    {

        /// <summary>
        /// Crea un registro en la tabla CustomData.
        /// </summary>
        /// <param name="CustomDataItem">Instancia de CustomData</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.CustomData CustomDataItem, IDbConnection connection = null)
        {
            if (CustomDataItem.UpdateDate.IsEmpty())
            {
                CustomDataItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO CustomData (Id, CompanyId, EntityType, EntitySubType, EntityId, Data, Key1, Key2, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :EntityType, :EntitySubType, :EntityId, :Data, :Key1, :Key2, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, CustomDataItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, CustomDataItem.CompanyId)
                            .AddParameter("EntityType", DbType.Decimal, 5, CustomDataItem.EntityType)
                            .AddParameter("EntitySubType", DbType.Decimal, 5, CustomDataItem.EntitySubType)
                            .AddParameter("EntityId", DbType.Decimal, 18, CustomDataItem.EntityId)
                            .AddParameter("Data", DbType.Clob, 0, CustomDataItem.Data)
                            .AddParameter("Key1", DbType.AnsiString, 80, CustomDataItem.Key1)
                            .AddParameter("Key2", DbType.AnsiString, 80, CustomDataItem.Key2)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, CustomDataItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, CustomDataItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla CustomData.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="CustomDataItems">Lista de instancia de CustomData</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.CustomData> CustomDataItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.CustomData item in CustomDataItems)
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
        /// Recupera un registro en la tabla CustomData por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de CustomData</returns>
        public static Architect.API.Core.Contracts.General.CustomData Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.CustomData result = null;
            Database.Select("SELECT Id, CustomData.CompanyId, EntityType, EntitySubType, EntityId, Data, Key1, Key2, CustomData.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, CustomData.UpdateDate " +
                              "FROM CustomData LEFT JOIN UserMember um ON um.UserId = CustomData.UpdateUserCode " +
                             "WHERE CustomData.Id=:Id AND CustomData.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToCustomData(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla CustomData.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de CustomData</returns>
        public static List<Architect.API.Core.Contracts.General.CustomData> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.CustomData> result = new List<Architect.API.Core.Contracts.General.CustomData>();
            Database.Select("SELECT Id, CustomData.CompanyId, EntityType, EntitySubType, EntityId, Data, Key1, Key2, CustomData.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, CustomData.UpdateDate " +
                              "FROM CustomData LEFT JOIN UserMember um ON um.UserId = CustomData.UpdateUserCode " +
                             "WHERE CustomData.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToCustomData(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla CustomData.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de CustomData</returns>
        public static List<Architect.API.Core.Contracts.General.CustomData> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.CustomData> result = new List<Architect.API.Core.Contracts.General.CustomData>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, CustomData.CompanyId, EntityType, EntitySubType, EntityId, Data, Key1, Key2, CustomData.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, CustomData.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY CustomData.Id DESC) RowNumber " +
                              "FROM CustomData LEFT JOIN UserMember um ON um.UserId = CustomData.UpdateUserCode " +
                             "WHERE CustomData.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToCustomData(reader));
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
        /// Último valor asignado a clave única de la tabla CustomData.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM CustomData")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla CustomData por medio de su clave primaria.
        /// </summary>
        /// <param name="CustomDataItem">Instancia de CustomData</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.CustomData CustomDataItem, IDbConnection connection = null)
        {
            if (CustomDataItem.UpdateDate.IsEmpty())
            {
                CustomDataItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE CustomData " +
                                      "SET CompanyId=:CompanyId, EntityType=:EntityType, EntitySubType=:EntitySubType, EntityId=:EntityId, Data=:Data, Key1=:Key1, Key2=:Key2, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, CustomDataItem.CompanyId)
                                .AddParameter("EntityType", DbType.Decimal, 5, CustomDataItem.EntityType)
                                .AddParameter("EntitySubType", DbType.Decimal, 5, CustomDataItem.EntitySubType)
                                .AddParameter("EntityId", DbType.Decimal, 18, CustomDataItem.EntityId)
                                .AddParameter("Data", DbType.Clob, 0, CustomDataItem.Data)
                                .AddParameter("Key1", DbType.AnsiString, 80, CustomDataItem.Key1)
                                .AddParameter("Key2", DbType.AnsiString, 80, CustomDataItem.Key2)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, CustomDataItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, CustomDataItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, CustomDataItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla CustomData por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="CustomDataItems">Lista de instancia de CustomData</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.CustomData> CustomDataItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.CustomData item in CustomDataItems)
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
        /// Elimina un registro en la tabla CustomData por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM CustomData " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla CustomData por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única del registro.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla CustomData por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM CustomData " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla CustomData que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM CustomData " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'CustomData'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.CustomData DataReaderToCustomData(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.CustomData item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.CustomData();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.EntityType = reader.IntegerValue("EntityType");
            item.EntitySubType = reader.IntegerValue("EntitySubType");
            item.EntityId = reader.Integer64Value("EntityId");
            item.Data = reader.StringValue("Data");
            item.Key1 = reader.StringValue("Key1");
            item.Key2 = reader.StringValue("Key2");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

        public static Contracts.General.CustomData RetrieveByEntity(int entityType, int entitySubType, long entityId, int companyId, IDbConnection connection = null)
        {
            Contracts.General.CustomData result = new Contracts.General.CustomData();
            Database.Select(@"SELECT Id, CustomData.CompanyId, EntityType, EntitySubType, EntityId, Data, Key1, Key2, CustomData.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, CustomData.UpdateDate 
                                FROM CustomData LEFT JOIN UserMember um ON um.UserId = CustomData.UpdateUserCode 
                               WHERE EntityType=:EntityType AND EntitySubType=:EntitySubType AND EntityId=:EntityId AND CustomData.CompanyId=:CompanyId")
                        .AddParameter("EntityType", DbType.Decimal, 5, entityType)
                        .AddParameter("EntitySubType", DbType.Decimal, 5, entitySubType)
                        .AddParameter("EntityId", DbType.Decimal, 18, entityId)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToCustomData(reader);
                        }));

            return result;
        }


        public static int UpdateCustom(Architect.API.Core.Contracts.General.CustomData CustomDataItem, IDbConnection connection = null)
        {
            return Database.Update("UPDATE CustomData " +
                                      "SET Data=:Data, Key1=:Key1, Key2=:Key2, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE EntityType=:EntityType AND EntitySubType=:EntitySubType AND EntityId=:EntityId AND CustomData.CompanyId=:CompanyId")
                                .AddParameter("Data", DbType.Clob, 0, CustomDataItem.Data)
                                .AddParameter("Key1", DbType.AnsiString, 80, CustomDataItem.Key1)
                                .AddParameter("Key2", DbType.AnsiString, 80, CustomDataItem.Key2)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, CustomDataItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, DateTime.Now)
                                .AddParameter("EntityType", DbType.Decimal, 5, CustomDataItem.EntityType)
                                .AddParameter("EntitySubType", DbType.Decimal, 5, CustomDataItem.EntitySubType)
                                .AddParameter("EntityId", DbType.Decimal, 18, CustomDataItem.EntityId)
                                .AddParameter("CompanyId", DbType.Decimal, 5, CustomDataItem.CompanyId)
                                .Execute(connection, "Research");
        }

        public static int Delete(int entityType, int entitySubType, long entityId, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM CustomData " +
                                    "WHERE EntityType=:EntityType AND EntityId=:EntityId AND CustomData.CompanyId=:CompanyId")
                                .AddParameter("EntityType", DbType.Decimal, 5, entityType)
                                .AddParameter("EntitySubType", DbType.Decimal, 5, entitySubType)
                                .AddParameter("EntityId", DbType.Decimal, 18, entityId)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        public static Architect.API.Core.Contracts.General.CustomData Retrieve(int entityType, Int64 entityId, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.CustomData result = null;
            Database.Select("SELECT Id, CustomData.CompanyId, EntityType, EntitySubType, EntityId, Data, Key1, Key2, CustomData.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, CustomData.UpdateDate " +
                              "FROM CustomData LEFT JOIN UserMember um ON um.UserId = CustomData.UpdateUserCode " +
                             "WHERE EntityType =:EntityType AND EntityId =:EntityId AND CustomData.CompanyId =:CompanyId ORDER BY Id")
                        .AddParameter("EntityType", DbType.Decimal, 5, entityType)
                        .AddParameter("EntityId", DbType.Decimal, 18, entityId)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToCustomData(reader);
                        }));
            return result;
        }

    }

}