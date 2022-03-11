using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Campos personalizados.
    /// </summary>
    public sealed partial class CustomFields
    {

        /// <summary>
        /// Crea un registro en la tabla CustomFields.
        /// </summary>
        /// <param name="customfieldsItem">Instancia de CustomFields</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.CustomFields customfieldsItem, IDbConnection connection = null)
        {
            if (customfieldsItem.UpdateDate.IsEmpty())
            {
                customfieldsItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO CustomFields (Id, CompanyId, EntityType, Name, Caption, DataType, Precision, Scale, IsRequired, DisplayOrder, Specification, RecordStatus, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :EntityType, :Name, :Caption, :DataType, :Precision, :Scale, :IsRequired, :DisplayOrder, :Specification, :RecordStatus, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, customfieldsItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, customfieldsItem.CompanyId)
                            .AddParameter("EntityType", DbType.Decimal, 5, customfieldsItem.EntityType)
                            .AddParameter("Name", DbType.AnsiString, 40, customfieldsItem.Name)
                            .AddParameter("Caption", DbType.AnsiString, 80, customfieldsItem.Caption)
                            .AddParameter("DataType", DbType.Decimal, 5, customfieldsItem.DataType)
                            .AddParameter("Precision", DbType.Decimal, 3, customfieldsItem.Precision)
                            .AddParameter("Scale", DbType.Decimal, 2, customfieldsItem.Scale)
                            .AddParameter("IsRequired", DbType.Decimal, 1, customfieldsItem.IsRequired ? 1 : 0)
                            .AddParameter("DisplayOrder", DbType.Decimal, 9, customfieldsItem.DisplayOrder)
                            .AddParameter("Specification", DbType.AnsiString, 2048, customfieldsItem.Specification)
                            .AddParameter("RecordStatus", DbType.Decimal, 5, customfieldsItem.RecordStatus)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, customfieldsItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, customfieldsItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla CustomFields.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="customfieldsItems">Lista de instancia de CustomFields</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.CustomFields> customfieldsItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.CustomFields item in customfieldsItems)
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
        /// Recupera un registro en la tabla CustomFields por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de CustomFields</returns>
        public static Architect.API.Core.Contracts.General.CustomFields Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.CustomFields result = null;
            Database.Select("SELECT Id, CustomFields.CompanyId, EntityType, Name, Caption, DataType, Precision, Scale, IsRequired, DisplayOrder, Specification, CustomFields.RecordStatus, CustomFields.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, CustomFields.UpdateDate " +
                              "FROM CustomFields LEFT JOIN UserMember um ON um.UserId = CustomFields.UpdateUserCode " +
                             "WHERE CustomFields.Id=:Id AND CustomFields.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToCustomFields(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla CustomFields.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de CustomFields</returns>
        public static List<Architect.API.Core.Contracts.General.CustomFields> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.CustomFields> result = new List<Architect.API.Core.Contracts.General.CustomFields>();
            Database.Select("SELECT Id, CustomFields.CompanyId, EntityType, Name, Caption, DataType, Precision, Scale, IsRequired, DisplayOrder, Specification, CustomFields.RecordStatus, CustomFields.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, CustomFields.UpdateDate " +
                              "FROM CustomFields LEFT JOIN UserMember um ON um.UserId = CustomFields.UpdateUserCode " +
                             "WHERE CustomFields.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToCustomFields(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla CustomFields.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de CustomFields</returns>
        public static List<Architect.API.Core.Contracts.General.CustomFields> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.CustomFields> result = new List<Architect.API.Core.Contracts.General.CustomFields>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, CustomFields.CompanyId, EntityType, Name, Caption, DataType, Precision, Scale, IsRequired, DisplayOrder, Specification, CustomFields.RecordStatus, CustomFields.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, CustomFields.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY CustomFields.Id DESC) RowNumber " +
                              "FROM CustomFields LEFT JOIN UserMember um ON um.UserId = CustomFields.UpdateUserCode " +
                             "WHERE CustomFields.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToCustomFields(reader));
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
        /// Último valor asignado a clave única de la tabla CustomFields.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM CustomFields")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla CustomFields por medio de su clave primaria.
        /// </summary>
        /// <param name="customfieldsItem">Instancia de CustomFields</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.CustomFields customfieldsItem, IDbConnection connection = null)
        {
            if (customfieldsItem.UpdateDate.IsEmpty())
            {
                customfieldsItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE CustomFields " +
                                      "SET CompanyId=:CompanyId, EntityType=:EntityType, Name=:Name, Caption=:Caption, DataType=:DataType, Precision=:Precision, Scale=:Scale, IsRequired=:IsRequired, DisplayOrder=:DisplayOrder, Specification=:Specification, RecordStatus=:RecordStatus, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, customfieldsItem.CompanyId)
                                .AddParameter("EntityType", DbType.Decimal, 5, customfieldsItem.EntityType)
                                .AddParameter("Name", DbType.AnsiString, 40, customfieldsItem.Name)
                                .AddParameter("Caption", DbType.AnsiString, 80, customfieldsItem.Caption)
                                .AddParameter("DataType", DbType.Decimal, 5, customfieldsItem.DataType)
                                .AddParameter("Precision", DbType.Decimal, 3, customfieldsItem.Precision)
                                .AddParameter("Scale", DbType.Decimal, 2, customfieldsItem.Scale)
                                .AddParameter("IsRequired", DbType.Decimal, 1, customfieldsItem.IsRequired ? 1 : 0)
                                .AddParameter("DisplayOrder", DbType.Decimal, 9, customfieldsItem.DisplayOrder)
                                .AddParameter("Specification", DbType.AnsiString, 2048, customfieldsItem.Specification)
                                .AddParameter("RecordStatus", DbType.Decimal, 5, customfieldsItem.RecordStatus)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, customfieldsItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, customfieldsItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, customfieldsItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla CustomFields por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="customfieldsItems">Lista de instancia de CustomFields</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.CustomFields> customfieldsItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.CustomFields item in customfieldsItems)
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
        /// Elimina un registro en la tabla CustomFields por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM CustomFields " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla CustomFields por medio de su clave primaria.
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
        /// Recupera la cantidad de registros existentes en la tabla CustomFields por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM CustomFields " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla CustomFields que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM CustomFields " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'CustomFields'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.CustomFields DataReaderToCustomFields(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.CustomFields item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.CustomFields();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.EntityType = reader.IntegerValue("EntityType");
            item.Name = reader.StringValue("Name");
            item.Caption = reader.StringValue("Caption");
            item.DataType = reader.IntegerValue("DataType");
            item.Precision = reader.IntegerValue("Precision");
            item.Scale = reader.IntegerValue("Scale");
            item.IsRequired = reader.IntegerValue("IsRequired") == 1;
            item.DisplayOrder = reader.IntegerValue("DisplayOrder");
            item.Specification = reader.StringValue("Specification");
            item.RecordStatus = reader.IntegerValue("RecordStatus");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

