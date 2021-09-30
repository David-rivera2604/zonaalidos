using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Etiquetas
    /// </summary>
    public static partial class Labels
    {

        /// <summary>
        /// Crea un registro en la tabla Labels.
        /// </summary>
        /// <param name="labelsItem">Instancia de Labels</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.Labels labelsItem, IDbConnection connection = null)
        {
            if (labelsItem.UpdateDate.IsEmpty())
            {
                labelsItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO Labels (Id, CompanyId, EntityType, EntityId, LabelId, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :EntityType, :EntityId, :LabelId, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, labelsItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, labelsItem.CompanyId)
                            .AddParameter("EntityType", DbType.Decimal, 5, labelsItem.EntityType)
                            .AddParameter("EntityId", DbType.Decimal, 18, labelsItem.EntityId)
                            .AddParameter("LabelId", DbType.Decimal, 5, labelsItem.LabelId)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, labelsItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, labelsItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla Labels.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="labelsItems">Lista de instancia de Labels</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.Labels> labelsItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.Labels item in labelsItems)
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
        /// Recupera un registro en la tabla Labels por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Labels</returns>
        public static Architect.API.Core.Contracts.General.Labels Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.Labels result = null;
            Database.Select("SELECT Id, Labels.CompanyId, EntityType, EntityId, LabelId, Labels.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Labels.UpdateDate " +
                              "FROM Labels LEFT JOIN UserMember um ON um.UserId = Labels.UpdateUserCode " +
                             "WHERE Labels.Id=:Id AND Labels.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToLabels(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Labels.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Labels</returns>
        public static List<Architect.API.Core.Contracts.General.Labels> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Labels> result = new List<Architect.API.Core.Contracts.General.Labels>();
            Database.Select("SELECT Id, Labels.CompanyId, EntityType, EntityId, LabelId, Labels.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Labels.UpdateDate " +
                              "FROM Labels LEFT JOIN UserMember um ON um.UserId = Labels.UpdateUserCode " +
                             "WHERE Labels.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToLabels(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Labels.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Labels</returns>
        public static List<Architect.API.Core.Contracts.General.Labels> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Labels> result = new List<Architect.API.Core.Contracts.General.Labels>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, Labels.CompanyId, EntityType, EntityId, LabelId, Labels.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Labels.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY Labels.Id DESC) RowNumber " +
                              "FROM Labels LEFT JOIN UserMember um ON um.UserId = Labels.UpdateUserCode " +
                             "WHERE Labels.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToLabels(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Genera complemento del query para habilitar el filtro por columnas establecidas.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros.</param>
        /// <param name="where">Indica que el complement debe incluir el WHERE del comando.</param>
        /// <returns>Complemento del query</returns>
        public static string FilterBuilder(string filter, bool includeWhere = true)
        {
            string result = string.Empty;


            return result;
        }

        /// <summary>
        /// Último valor asignado a clave unica de la tabla Labels.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM Labels")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla Labels por medio de su clave primaria.
        /// </summary>
        /// <param name="labelsItem">Instancia de Labels</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.Labels labelsItem, IDbConnection connection = null)
        {
            if (labelsItem.UpdateDate.IsEmpty())
            {
                labelsItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE Labels " +
                                      "SET CompanyId=:CompanyId, EntityType=:EntityType, EntityId=:EntityId, LabelId=:LabelId, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, labelsItem.CompanyId)
                                .AddParameter("EntityType", DbType.Decimal, 5, labelsItem.EntityType)
                                .AddParameter("EntityId", DbType.Decimal, 18, labelsItem.EntityId)
                                .AddParameter("LabelId", DbType.Decimal, 5, labelsItem.LabelId)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, labelsItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, labelsItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, labelsItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Labels por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="labelsItems">Lista de instancia de Labels</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.Labels> labelsItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.Labels item in labelsItems)
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
        /// Elimina un registro en la tabla Labels por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM Labels " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Labels por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla Labels por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Labels " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Labels que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Labels " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'Labels'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.Labels DataReaderToLabels(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.Labels item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.Labels();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.EntityType = reader.IntegerValue("EntityType");
            item.EntityId = reader.Integer64Value("EntityId");
            item.LabelId = reader.IntegerValue("LabelId");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

