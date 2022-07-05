using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// ProcessSpecSLA
    /// </summary>
    public sealed partial class ProcessSpecSLA
    {

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecSLA.
        /// </summary>
        /// <param name="processspecslaItem">Instancia de ProcessSpecSLA</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.ProcessSpecSLA processspecslaItem, IDbConnection connection = null)
        {
            if (processspecslaItem.UpdateDate.IsEmpty())
            {
                processspecslaItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO ProcessSpecSLA (Id, CompanyId, Name, Description, Status, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :Name, :Description, :Status, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, processspecslaItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, processspecslaItem.CompanyId)
                            .AddParameter("Name", DbType.AnsiString, 80, processspecslaItem.Name)
                            .AddParameter("Description", DbType.AnsiString, 256, processspecslaItem.Description)
                            .AddParameter("Status", DbType.Decimal, 3, processspecslaItem.Status)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspecslaItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, processspecslaItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla ProcessSpecSLA.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspecslaItems">Lista de instancia de ProcessSpecSLA</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.ProcessSpecSLA> processspecslaItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessSpecSLA item in processspecslaItems)
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
        /// Recupera un registro en la tabla ProcessSpecSLA por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ProcessSpecSLA</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecSLA Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.ProcessSpecSLA result = null;
            Database.Select("SELECT Id, ProcessSpecSLA.CompanyId, Name, Description, Status, ProcessSpecSLA.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecSLA.UpdateDate " +
                              "FROM ProcessSpecSLA LEFT JOIN UserMember um ON um.UserId = ProcessSpecSLA.UpdateUserCode " +
                             "WHERE ProcessSpecSLA.Id=:Id AND ProcessSpecSLA.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToProcessSpecSLA(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecSLA.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecSLA</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecSLA> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecSLA> result = new List<Architect.API.Core.Contracts.General.ProcessSpecSLA>();
            Database.Select("SELECT Id, ProcessSpecSLA.CompanyId, Name, Description, Status, ProcessSpecSLA.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecSLA.UpdateDate " +
                              "FROM ProcessSpecSLA LEFT JOIN UserMember um ON um.UserId = ProcessSpecSLA.UpdateUserCode " +
                             "WHERE ProcessSpecSLA.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecSLA(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecSLA.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecSLA</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecSLA> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecSLA> result = new List<Architect.API.Core.Contracts.General.ProcessSpecSLA>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, ProcessSpecSLA.CompanyId, Name, Description, Status, ProcessSpecSLA.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecSLA.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY ProcessSpecSLA.Id DESC) RowNumber " +
                              "FROM ProcessSpecSLA LEFT JOIN UserMember um ON um.UserId = ProcessSpecSLA.UpdateUserCode " +
                             "WHERE ProcessSpecSLA.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecSLA(reader));
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

            if (filter.IsNotEmpty())
            {
                string condition = string.Empty;
                if (filter.IndexOf("|")>-1)
                {
                    condition = filter.Substring( filter.IndexOf("|"));
                    filter = filter.Substring(0, filter.IndexOf("|"));
                }			
                if (includeWhere)
                {
                    result = " WHERE ";
                }
                else
                {
                    result = " AND ";
                }

                result += "(";
                result += " UPPER(ProcessSpecSLA.Status) LIKE '%" + filter.ToUpper() + "%' ";

                result += ")";
                if (condition.IsNotEmpty())
                {
                    result += Database.FilterFactory(condition, "ProcessSpecSLA");
                }				
            }
            return result;
        }

        /// <summary>
        /// Último valor asignado a clave única de la tabla ProcessSpecSLA.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM ProcessSpecSLA")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecSLA por medio de su clave primaria.
        /// </summary>
        /// <param name="processspecslaItem">Instancia de ProcessSpecSLA</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.ProcessSpecSLA processspecslaItem, IDbConnection connection = null)
        {
            if (processspecslaItem.UpdateDate.IsEmpty())
            {
                processspecslaItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE ProcessSpecSLA " +
                                      "SET CompanyId=:CompanyId, Name=:Name, Description=:Description, Status=:Status, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, processspecslaItem.CompanyId)
                                .AddParameter("Name", DbType.AnsiString, 80, processspecslaItem.Name)
                                .AddParameter("Description", DbType.AnsiString, 256, processspecslaItem.Description)
                                .AddParameter("Status", DbType.Decimal, 3, processspecslaItem.Status)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspecslaItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, processspecslaItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, processspecslaItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecSLA por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspecslaItems">Lista de instancia de ProcessSpecSLA</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.ProcessSpecSLA> processspecslaItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessSpecSLA item in processspecslaItems)
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
        /// Elimina un registro en la tabla ProcessSpecSLA por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ProcessSpecSLA " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecSLA por medio de su clave primaria.
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
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecSLA por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecSLA " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecSLA que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecSLA " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista para selección de la tabla ProcessSpecSLA.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookUpValue</returns>
        public static List<Utilities.Contracts.LookUpValue> LookUp(int companyId, IDbConnection connection = null)
        {
            List<Utilities.Contracts.LookUpValue> result = new List<Utilities.Contracts.LookUpValue>();
            Database.Select("SELECT Id, Name " +
                              "FROM ProcessSpecSLA WHERE CompanyId=:CompanyId ORDER BY Name")
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
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'ProcessSpecSLA'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecSLA DataReaderToProcessSpecSLA(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.ProcessSpecSLA item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.ProcessSpecSLA();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.Name = reader.StringValue("Name");
            item.Description = reader.StringValue("Description");
            item.Status = reader.IntegerValue("Status");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

