using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Archivos adjuntos.
    /// </summary>
    public sealed partial class Attachments
    {

        /// <summary>
        /// Crea un registro en la tabla Attachments.
        /// </summary>
        /// <param name="attachmentsItem">Instancia de Attachments</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.Attachments attachmentsItem, IDbConnection connection = null)
        {
            if (attachmentsItem.UpdateDate.IsEmpty())
            {
                attachmentsItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO Attachments (Id, CompanyId, EntityType, EntitySubType, EntityId, DocumentType, Description, FileName, FileSize, FileContent, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :EntityType, :EntitySubType, :EntityId, :DocumentType, :Description, :FileName, :FileSize, :FileContent, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, attachmentsItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, attachmentsItem.CompanyId)
                            .AddParameter("EntityType", DbType.Decimal, 5, attachmentsItem.EntityType)
                            .AddParameter("EntitySubType", DbType.Decimal, 5, attachmentsItem.EntitySubType)
                            .AddParameter("EntityId", DbType.Decimal, 18, attachmentsItem.EntityId)
                            .AddParameter("DocumentType", DbType.Decimal, 5, attachmentsItem.DocumentType)
                            .AddParameter("Description", DbType.AnsiString, 120, attachmentsItem.Description)
                            .AddParameter("FileName", DbType.AnsiString, 80, attachmentsItem.FileName)
                            .AddParameter("FileSize", DbType.Decimal, 9, attachmentsItem.FileSize)
                            .AddParameter("FileContent", DbType.AnsiString, 9, attachmentsItem.FileContent)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, attachmentsItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, attachmentsItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla Attachments.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="attachmentsItems">Lista de instancia de Attachments</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.Attachments> attachmentsItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.Attachments item in attachmentsItems)
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
        /// Recupera un registro en la tabla Attachments por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Attachments</returns>
        public static Architect.API.Core.Contracts.General.Attachments Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.Attachments result = null;
            Database.Select("SELECT Id, Attachments.CompanyId, EntityType, EntitySubType, EntityId, DocumentType, Description, FileName, FileSize, FileContent, Attachments.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Attachments.UpdateDate " +
                              "FROM Attachments LEFT JOIN UserMember um ON um.UserId = Attachments.UpdateUserCode " +
                             "WHERE Attachments.Id=:Id AND Attachments.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToAttachments(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Attachments.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Attachments</returns>
        public static List<Architect.API.Core.Contracts.General.Attachments> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Attachments> result = new List<Architect.API.Core.Contracts.General.Attachments>();
            Database.Select("SELECT Id, Attachments.CompanyId, EntityType, EntitySubType, EntityId, DocumentType, Description, FileName, FileSize, FileContent, Attachments.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Attachments.UpdateDate " +
                              "FROM Attachments LEFT JOIN UserMember um ON um.UserId = Attachments.UpdateUserCode " +
                             "WHERE Attachments.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToAttachments(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Attachments.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Attachments</returns>
        public static List<Architect.API.Core.Contracts.General.Attachments> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Attachments> result = new List<Architect.API.Core.Contracts.General.Attachments>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, Attachments.CompanyId, EntityType, EntitySubType, EntityId, DocumentType, Description, FileName, FileSize, FileContent, Attachments.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Attachments.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY Attachments.Id DESC) RowNumber " +
                              "FROM Attachments LEFT JOIN UserMember um ON um.UserId = Attachments.UpdateUserCode " +
                             "WHERE Attachments.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToAttachments(reader));
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
        /// Último valor asignado a clave única de la tabla Attachments.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM Attachments")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla Attachments por medio de su clave primaria.
        /// </summary>
        /// <param name="attachmentsItem">Instancia de Attachments</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.Attachments attachmentsItem, IDbConnection connection = null)
        {
            if (attachmentsItem.UpdateDate.IsEmpty())
            {
                attachmentsItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE Attachments " +
                                      "SET CompanyId=:CompanyId, EntityType=:EntityType, EntitySubType=:EntitySubType, EntityId=:EntityId, DocumentType=:DocumentType, Description=:Description, FileName=:FileName, FileSize=:FileSize, FileContent=:FileContent, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, attachmentsItem.CompanyId)
                                .AddParameter("EntityType", DbType.Decimal, 5, attachmentsItem.EntityType)
                                .AddParameter("EntitySubType", DbType.Decimal, 5, attachmentsItem.EntitySubType)
                                .AddParameter("EntityId", DbType.Decimal, 18, attachmentsItem.EntityId)
                                .AddParameter("DocumentType", DbType.Decimal, 5, attachmentsItem.DocumentType)
                                .AddParameter("Description", DbType.AnsiString, 120, attachmentsItem.Description)
                                .AddParameter("FileName", DbType.AnsiString, 80, attachmentsItem.FileName)
                                .AddParameter("FileSize", DbType.Decimal, 9, attachmentsItem.FileSize)
                                .AddParameter("FileContent", DbType.AnsiString, 9, attachmentsItem.FileContent)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, attachmentsItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, attachmentsItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, attachmentsItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Attachments por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="attachmentsItems">Lista de instancia de Attachments</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.Attachments> attachmentsItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.Attachments item in attachmentsItems)
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
        /// Elimina un registro en la tabla Attachments por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM Attachments " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Attachments por medio de su clave primaria.
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
        /// Recupera la cantidad de registros existentes en la tabla Attachments por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Attachments " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Attachments que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Attachments " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'Attachments'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.Attachments DataReaderToAttachments(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.Attachments item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.Attachments();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.EntityType = reader.IntegerValue("EntityType");
            item.EntitySubType = reader.IntegerValue("EntitySubType");
            item.EntityId = reader.Integer64Value("EntityId");
            item.DocumentType = reader.IntegerValue("DocumentType");
            item.Description = reader.StringValue("Description");
            item.FileName = reader.StringValue("FileName");
            item.FileSize = reader.IntegerValue("FileSize");
            item.FileContent = reader.StringValue("FileContent");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

