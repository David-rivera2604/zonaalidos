using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Tareas vinculadas a un paso o estado de un proceso.
    /// </summary>
    public static partial class ProcessSpecTask
    {

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecTask.
        /// </summary>
        /// <param name="processspectaskItem">Instancia de ProcessSpecTask</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.ProcessSpecTask processspectaskItem, IDbConnection connection = null)
        {
            if (processspectaskItem.UpdateDate.IsEmpty())
            {
                processspectaskItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO ProcessSpecTask (Id, StepId, CompanyId, Name, Description, SLATimeOut, IsRequired, IsSelected, TaskOrder, Type, Action, SubStatus, SubLabel, PreScript, PostScript, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :StepId, :CompanyId, :Name, :Description, :SLATimeOut, :IsRequired, :IsSelected, :TaskOrder, :Type, :Action, :SubStatus, :SubLabel, :PreScript, :PostScript, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, processspectaskItem.Id)
                            .AddParameter("StepId", DbType.Decimal, 9, processspectaskItem.StepId)
                            .AddParameter("CompanyId", DbType.Decimal, 5, processspectaskItem.CompanyId)
                            .AddParameter("Name", DbType.AnsiString, 80, processspectaskItem.Name)
                            .AddParameter("Description", DbType.AnsiString, 256, processspectaskItem.Description)
                            .AddParameter("SLATimeOut", DbType.Decimal, 9, processspectaskItem.SLATimeOut)
                            .AddParameter("IsRequired", DbType.Decimal, 1, processspectaskItem.IsRequired ? 1 : 0)
                            .AddParameter("IsSelected", DbType.Decimal, 1, processspectaskItem.IsSelected ? 1 : 0)
                            .AddParameter("TaskOrder", DbType.Decimal, 9, processspectaskItem.TaskOrder)
                            .AddParameter("Type", DbType.Decimal, 3, processspectaskItem.Type)
                            .AddParameter("Action", DbType.AnsiString, 9, processspectaskItem.Action)
                            .AddParameter("SubStatus", DbType.Decimal, 3, processspectaskItem.SubStatus)
                            .AddParameter("SubLabel", DbType.AnsiString, 80, processspectaskItem.SubLabel)
                            .AddParameter("PreScript", DbType.AnsiString, 9, processspectaskItem.PreScript)
                            .AddParameter("PostScript", DbType.AnsiString, 9, processspectaskItem.PostScript)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspectaskItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, processspectaskItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla ProcessSpecTask.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspectaskItems">Lista de instancia de ProcessSpecTask</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.ProcessSpecTask> processspectaskItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessSpecTask item in processspectaskItems)
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
        /// Recupera un registro en la tabla ProcessSpecTask por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la tarea.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ProcessSpecTask</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecTask Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.ProcessSpecTask result = null;
            Database.Select("SELECT Id, StepId, ProcessSpecTask.CompanyId, Name, Description, SLATimeOut, IsRequired, IsSelected, TaskOrder, Type, Action, SubStatus, SubLabel, PreScript, PostScript, ProcessSpecTask.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecTask.UpdateDate " +
                              "FROM ProcessSpecTask LEFT JOIN UserMember um ON um.UserId = ProcessSpecTask.UpdateUserCode " +
                             "WHERE ProcessSpecTask.Id=:Id AND ProcessSpecTask.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToProcessSpecTask(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecTask.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecTask</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecTask> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecTask> result = new List<Architect.API.Core.Contracts.General.ProcessSpecTask>();
            Database.Select("SELECT Id, StepId, ProcessSpecTask.CompanyId, Name, Description, SLATimeOut, IsRequired, IsSelected, TaskOrder, Type, Action, SubStatus, SubLabel, PreScript, PostScript, ProcessSpecTask.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecTask.UpdateDate " +
                              "FROM ProcessSpecTask LEFT JOIN UserMember um ON um.UserId = ProcessSpecTask.UpdateUserCode " +
                             "WHERE ProcessSpecTask.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecTask(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecTask.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecTask</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecTask> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecTask> result = new List<Architect.API.Core.Contracts.General.ProcessSpecTask>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, StepId, ProcessSpecTask.CompanyId, Name, Description, SLATimeOut, IsRequired, IsSelected, TaskOrder, Type, Action, SubStatus, SubLabel, PreScript, PostScript, ProcessSpecTask.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecTask.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY ProcessSpecTask.Id DESC) RowNumber " +
                              "FROM ProcessSpecTask LEFT JOIN UserMember um ON um.UserId = ProcessSpecTask.UpdateUserCode " +
                             "WHERE ProcessSpecTask.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecTask(reader));
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
                result += " UPPER(ProcessSpecTask.StepId) LIKE '%" + filter.ToUpper() + "%' ";

                result += ")";
            }
            return result;
        }

        /// <summary>
        /// Último valor asignado a clave unica de la tabla ProcessSpecTask.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM ProcessSpecTask")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecTask por medio de su clave primaria.
        /// </summary>
        /// <param name="processspectaskItem">Instancia de ProcessSpecTask</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.ProcessSpecTask processspectaskItem, IDbConnection connection = null)
        {
            if (processspectaskItem.UpdateDate.IsEmpty())
            {
                processspectaskItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE ProcessSpecTask " +
                                      "SET StepId=:StepId, CompanyId=:CompanyId, Name=:Name, Description=:Description, SLATimeOut=:SLATimeOut, IsRequired=:IsRequired, IsSelected=:IsSelected, TaskOrder=:TaskOrder, Type=:Type, Action=:Action, SubStatus=:SubStatus, SubLabel=:SubLabel, PreScript=:PreScript, PostScript=:PostScript, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("StepId", DbType.Decimal, 9, processspectaskItem.StepId)
                                .AddParameter("CompanyId", DbType.Decimal, 5, processspectaskItem.CompanyId)
                                .AddParameter("Name", DbType.AnsiString, 80, processspectaskItem.Name)
                                .AddParameter("Description", DbType.AnsiString, 256, processspectaskItem.Description)
                                .AddParameter("SLATimeOut", DbType.Decimal, 9, processspectaskItem.SLATimeOut)
                                .AddParameter("IsRequired", DbType.Decimal, 1, processspectaskItem.IsRequired ? 1 : 0)
                                .AddParameter("IsSelected", DbType.Decimal, 1, processspectaskItem.IsSelected ? 1 : 0)
                                .AddParameter("TaskOrder", DbType.Decimal, 9, processspectaskItem.TaskOrder)
                                .AddParameter("Type", DbType.Decimal, 3, processspectaskItem.Type)
                                .AddParameter("Action", DbType.AnsiString, 9, processspectaskItem.Action)
                                .AddParameter("SubStatus", DbType.Decimal, 3, processspectaskItem.SubStatus)
                                .AddParameter("SubLabel", DbType.AnsiString, 80, processspectaskItem.SubLabel)
                                .AddParameter("PreScript", DbType.AnsiString, 9, processspectaskItem.PreScript)
                                .AddParameter("PostScript", DbType.AnsiString, 9, processspectaskItem.PostScript)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspectaskItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, processspectaskItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, processspectaskItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecTask por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspectaskItems">Lista de instancia de ProcessSpecTask</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.ProcessSpecTask> processspectaskItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessSpecTask item in processspectaskItems)
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
        /// Elimina un registro en la tabla ProcessSpecTask por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la tarea.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ProcessSpecTask " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecTask por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única de la tarea.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecTask por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la tarea.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecTask " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecTask que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecTask " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista para selección de la tabla ProcessSpecTask.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookUpValue</returns>
        public static List<Utilities.Contracts.LookUpValue> LookUp(int companyId, IDbConnection connection = null)
        {
            List<Utilities.Contracts.LookUpValue> result = new List<Utilities.Contracts.LookUpValue>();
            Database.Select("SELECT Id, Name " +
                              "FROM ProcessSpecTask WHERE CompanyId=:CompanyId ORDER BY Name")
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
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'ProcessSpecTask'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecTask DataReaderToProcessSpecTask(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.ProcessSpecTask item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.ProcessSpecTask();
            }
            item.Id = reader.IntegerValue("Id");
            item.StepId = reader.IntegerValue("StepId");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.Name = reader.StringValue("Name");
            item.Description = reader.StringValue("Description");
            item.SLATimeOut = reader.IntegerValue("SLATimeOut");
            item.IsRequired = reader.IntegerValue("IsRequired") == 1;
            item.IsSelected = reader.IntegerValue("IsSelected") == 1;
            item.TaskOrder = reader.IntegerValue("TaskOrder");
            item.Type = reader.IntegerValue("Type");
            item.Action = reader.StringValue("Action");
            item.SubStatus = reader.IntegerValue("SubStatus");
            item.SubLabel = reader.StringValue("SubLabel");
            item.PreScript = reader.StringValue("PreScript");
            item.PostScript = reader.StringValue("PostScript");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

