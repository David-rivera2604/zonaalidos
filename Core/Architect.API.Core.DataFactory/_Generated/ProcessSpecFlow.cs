using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Especificación de un proceso.
    /// </summary>
    public static partial class ProcessSpecFlow
    {

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="processspecflowItem">Instancia de ProcessSpecFlow</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.ProcessSpecFlow processspecflowItem, IDbConnection connection = null)
        {
            if (processspecflowItem.UpdateDate.IsEmpty())
            {
                processspecflowItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO ProcessSpecFlow (Id, CompanyId, Name, Description, Alias, MailServer, ReferenceCaption1, ReferenceCaption2, ReferenceCaption3, ReferenceCaption4, ReferenceCaption5, Status, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :Name, :Description, :Alias, :MailServer, :ReferenceCaption1, :ReferenceCaption2, :ReferenceCaption3, :ReferenceCaption4, :ReferenceCaption5, :Status, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, processspecflowItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, processspecflowItem.CompanyId)
                            .AddParameter("Name", DbType.AnsiString, 80, processspecflowItem.Name)
                            .AddParameter("Description", DbType.AnsiString, 256, processspecflowItem.Description)
                            .AddParameter("Alias", DbType.AnsiString, 30, processspecflowItem.Alias)
                            .AddParameter("MailServer", DbType.Decimal, 5, processspecflowItem.MailServer)
                            .AddParameter("ReferenceCaption1", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption1)
                            .AddParameter("ReferenceCaption2", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption2)
                            .AddParameter("ReferenceCaption3", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption3)
                            .AddParameter("ReferenceCaption4", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption4)
                            .AddParameter("ReferenceCaption5", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption5)
                            .AddParameter("Status", DbType.Decimal, 3, processspecflowItem.Status)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspecflowItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, processspecflowItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla ProcessSpecFlow.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspecflowItems">Lista de instancia de ProcessSpecFlow</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.ProcessSpecFlow> processspecflowItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessSpecFlow item in processspecflowItems)
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
        /// Recupera un registro en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ProcessSpecFlow</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecFlow Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.ProcessSpecFlow result = null;
            Database.Select("SELECT Id, ProcessSpecFlow.CompanyId, Name, Description, Alias, MailServer, ReferenceCaption1, ReferenceCaption2, ReferenceCaption3, ReferenceCaption4, ReferenceCaption5, Status, ProcessSpecFlow.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecFlow.UpdateDate " +
                              "FROM ProcessSpecFlow LEFT JOIN UserMember um ON um.UserId = ProcessSpecFlow.UpdateUserCode " +
                             "WHERE ProcessSpecFlow.Id=:Id AND ProcessSpecFlow.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToProcessSpecFlow(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecFlow</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecFlow> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecFlow> result = new List<Architect.API.Core.Contracts.General.ProcessSpecFlow>();
            Database.Select("SELECT Id, ProcessSpecFlow.CompanyId, Name, Description, Alias, MailServer, ReferenceCaption1, ReferenceCaption2, ReferenceCaption3, ReferenceCaption4, ReferenceCaption5, Status, ProcessSpecFlow.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecFlow.UpdateDate " +
                              "FROM ProcessSpecFlow LEFT JOIN UserMember um ON um.UserId = ProcessSpecFlow.UpdateUserCode " +
                             "WHERE ProcessSpecFlow.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecFlow(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecFlow</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecFlow> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecFlow> result = new List<Architect.API.Core.Contracts.General.ProcessSpecFlow>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, ProcessSpecFlow.CompanyId, Name, Description, Alias, MailServer, ReferenceCaption1, ReferenceCaption2, ReferenceCaption3, ReferenceCaption4, ReferenceCaption5, Status, ProcessSpecFlow.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecFlow.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY ProcessSpecFlow.Id DESC) RowNumber " +
                              "FROM ProcessSpecFlow LEFT JOIN UserMember um ON um.UserId = ProcessSpecFlow.UpdateUserCode " +
                             "WHERE ProcessSpecFlow.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecFlow(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Genera complemento de la consulta para habilitar el filtro por columnas establecidas.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros.</param>
        /// <param name="where">Indica que el complemento debe incluir el WHERE del comando.</param>
        /// <returns>Complemento de la consulta</returns>
        public static string FilterBuilder(string filter, bool includeWhere = true)
        {
            string result = string.Empty;

            if (filter.IsNotEmpty())
            {
                if (includeWhere)
                {
                    result = " WHERE ";
                }
                else
                {
                    result = " AND ";
                }

                result += "(";
                result += " UPPER(ProcessSpecFlow.Status) LIKE '%" + filter.ToUpper() + "%' ";

                result += ")";
            }
            return result;
        }

        /// <summary>
        /// Último valor asignado a clave única de la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM ProcessSpecFlow")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <param name="processspecflowItem">Instancia de ProcessSpecFlow</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.ProcessSpecFlow processspecflowItem, IDbConnection connection = null)
        {
            if (processspecflowItem.UpdateDate.IsEmpty())
            {
                processspecflowItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE ProcessSpecFlow " +
                                      "SET CompanyId=:CompanyId, Name=:Name, Description=:Description, Alias=:Alias, MailServer=:MailServer, ReferenceCaption1=:ReferenceCaption1, ReferenceCaption2=:ReferenceCaption2, ReferenceCaption3=:ReferenceCaption3, ReferenceCaption4=:ReferenceCaption4, ReferenceCaption5=:ReferenceCaption5, Status=:Status, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, processspecflowItem.CompanyId)
                                .AddParameter("Name", DbType.AnsiString, 80, processspecflowItem.Name)
                                .AddParameter("Description", DbType.AnsiString, 256, processspecflowItem.Description)
                                .AddParameter("Alias", DbType.AnsiString, 30, processspecflowItem.Alias)
                                .AddParameter("MailServer", DbType.Decimal, 5, processspecflowItem.MailServer)
                                .AddParameter("ReferenceCaption1", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption1)
                                .AddParameter("ReferenceCaption2", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption2)
                                .AddParameter("ReferenceCaption3", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption3)
                                .AddParameter("ReferenceCaption4", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption4)
                                .AddParameter("ReferenceCaption5", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption5)
                                .AddParameter("Status", DbType.Decimal, 3, processspecflowItem.Status)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspecflowItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, processspecflowItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, processspecflowItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspecflowItems">Lista de instancia de ProcessSpecFlow</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.ProcessSpecFlow> processspecflowItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessSpecFlow item in processspecflowItems)
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
        /// Elimina un registro en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ProcessSpecFlow " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única del proceso.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecFlow " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecFlow que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecFlow " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista para selección de la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookUpValue</returns>
        public static List<Utilities.Contracts.LookUpValue> LookUp(int companyId, IDbConnection connection = null)
        {
            List<Utilities.Contracts.LookUpValue> result = new List<Utilities.Contracts.LookUpValue>();
            Database.Select("SELECT Id, Name " +
                              "FROM ProcessSpecFlow WHERE CompanyId=:CompanyId ORDER BY Name")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                            {
                                result.Add(new Utilities.Contracts.LookUpValue()
                                {
                                    Code = reader.StringValue("Id"),
                                    Description = reader.StringValue("Name")
                                });
                            }));
            return result;
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'ProcessSpecFlow'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecFlow DataReaderToProcessSpecFlow(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.ProcessSpecFlow item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.ProcessSpecFlow();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.Name = reader.StringValue("Name");
            item.Description = reader.StringValue("Description");
            item.Alias = reader.StringValue("Alias");
            item.MailServer = reader.IntegerValue("MailServer");
            item.ReferenceCaption1 = reader.StringValue("ReferenceCaption1");
            item.ReferenceCaption2 = reader.StringValue("ReferenceCaption2");
            item.ReferenceCaption3 = reader.StringValue("ReferenceCaption3");
            item.ReferenceCaption4 = reader.StringValue("ReferenceCaption4");
            item.ReferenceCaption5 = reader.StringValue("ReferenceCaption5");
            item.Status = reader.IntegerValue("Status");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

