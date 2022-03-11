using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Permite disponibilizar páginas y enlaces para un proceso.
    /// </summary>
    public sealed partial class ProcessSpecLink
    {

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecLink.
        /// </summary>
        /// <param name="processspeclinkItem">Instancia de ProcessSpecLink</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.ProcessSpecLink processspeclinkItem, IDbConnection connection = null)
        {
            if (processspeclinkItem.UpdateDate.IsEmpty())
            {
                processspeclinkItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO ProcessSpecLink (Id, FlowId, CompanyId, Name, Description, Icon, Type, LinkOrder, URL, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :FlowId, :CompanyId, :Name, :Description, :Icon, :Type, :LinkOrder, :URL, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, processspeclinkItem.Id)
                            .AddParameter("FlowId", DbType.Decimal, 9, processspeclinkItem.FlowId)
                            .AddParameter("CompanyId", DbType.Decimal, 5, processspeclinkItem.CompanyId)
                            .AddParameter("Name", DbType.AnsiString, 80, processspeclinkItem.Name)
                            .AddParameter("Description", DbType.AnsiString, 256, processspeclinkItem.Description)
                            .AddParameter("Icon", DbType.AnsiString, 40, processspeclinkItem.Icon)
                            .AddParameter("Type", DbType.Decimal, 3, processspeclinkItem.Type)
                            .AddParameter("LinkOrder", DbType.Decimal, 9, processspeclinkItem.LinkOrder)
                            .AddParameter("URL", DbType.AnsiString, 512, processspeclinkItem.URL)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspeclinkItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, processspeclinkItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla ProcessSpecLink.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspeclinkItems">Lista de instancia de ProcessSpecLink</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.ProcessSpecLink> processspeclinkItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessSpecLink item in processspeclinkItems)
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
        /// Recupera un registro en la tabla ProcessSpecLink por medio de su clave primaria.
        /// </summary>
        /// <param name="id">.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ProcessSpecLink</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecLink Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.ProcessSpecLink result = null;
            Database.Select("SELECT Id, FlowId, ProcessSpecLink.CompanyId, Name, Description, Icon, Type, LinkOrder, URL, ProcessSpecLink.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecLink.UpdateDate " +
                              "FROM ProcessSpecLink LEFT JOIN UserMember um ON um.UserId = ProcessSpecLink.UpdateUserCode " +
                             "WHERE ProcessSpecLink.Id=:Id AND ProcessSpecLink.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToProcessSpecLink(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecLink.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecLink</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecLink> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecLink> result = new List<Architect.API.Core.Contracts.General.ProcessSpecLink>();
            Database.Select("SELECT Id, FlowId, ProcessSpecLink.CompanyId, Name, Description, Icon, Type, LinkOrder, URL, ProcessSpecLink.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecLink.UpdateDate " +
                              "FROM ProcessSpecLink LEFT JOIN UserMember um ON um.UserId = ProcessSpecLink.UpdateUserCode " +
                             "WHERE ProcessSpecLink.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecLink(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecLink.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecLink</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecLink> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecLink> result = new List<Architect.API.Core.Contracts.General.ProcessSpecLink>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, FlowId, ProcessSpecLink.CompanyId, Name, Description, Icon, Type, LinkOrder, URL, ProcessSpecLink.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecLink.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY ProcessSpecLink.Id DESC) RowNumber " +
                              "FROM ProcessSpecLink LEFT JOIN UserMember um ON um.UserId = ProcessSpecLink.UpdateUserCode " +
                             "WHERE ProcessSpecLink.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecLink(reader));
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
        /// Último valor asignado a clave única de la tabla ProcessSpecLink.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM ProcessSpecLink")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecLink por medio de su clave primaria.
        /// </summary>
        /// <param name="processspeclinkItem">Instancia de ProcessSpecLink</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.ProcessSpecLink processspeclinkItem, IDbConnection connection = null)
        {
            if (processspeclinkItem.UpdateDate.IsEmpty())
            {
                processspeclinkItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE ProcessSpecLink " +
                                      "SET FlowId=:FlowId, CompanyId=:CompanyId, Name=:Name, Description=:Description, Icon=:Icon, Type=:Type, LinkOrder=:LinkOrder, URL=:URL, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("FlowId", DbType.Decimal, 9, processspeclinkItem.FlowId)
                                .AddParameter("CompanyId", DbType.Decimal, 5, processspeclinkItem.CompanyId)
                                .AddParameter("Name", DbType.AnsiString, 80, processspeclinkItem.Name)
                                .AddParameter("Description", DbType.AnsiString, 256, processspeclinkItem.Description)
                                .AddParameter("Icon", DbType.AnsiString, 40, processspeclinkItem.Icon)
                                .AddParameter("Type", DbType.Decimal, 3, processspeclinkItem.Type)
                                .AddParameter("LinkOrder", DbType.Decimal, 9, processspeclinkItem.LinkOrder)
                                .AddParameter("URL", DbType.AnsiString, 512, processspeclinkItem.URL)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspeclinkItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, processspeclinkItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, processspeclinkItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecLink por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspeclinkItems">Lista de instancia de ProcessSpecLink</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.ProcessSpecLink> processspeclinkItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessSpecLink item in processspeclinkItems)
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
        /// Elimina un registro en la tabla ProcessSpecLink por medio de su clave primaria.
        /// </summary>
        /// <param name="id">.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ProcessSpecLink " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecLink por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de .</param>
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
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecLink por medio de su clave primaria.
        /// </summary>
        /// <param name="id">.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecLink " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecLink que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecLink " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista para selección de la tabla ProcessSpecLink.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookUpValue</returns>
        public static List<Utilities.Contracts.LookUpValue> LookUp(int companyId, IDbConnection connection = null)
        {
            List<Utilities.Contracts.LookUpValue> result = new List<Utilities.Contracts.LookUpValue>();
            Database.Select("SELECT Id, Name " +
                              "FROM ProcessSpecLink WHERE CompanyId=:CompanyId ORDER BY Name")
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
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'ProcessSpecLink'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecLink DataReaderToProcessSpecLink(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.ProcessSpecLink item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.ProcessSpecLink();
            }
            item.Id = reader.IntegerValue("Id");
            item.FlowId = reader.IntegerValue("FlowId");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.Name = reader.StringValue("Name");
            item.Description = reader.StringValue("Description");
            item.Icon = reader.StringValue("Icon");
            item.Type = reader.IntegerValue("Type");
            item.LinkOrder = reader.IntegerValue("LinkOrder");
            item.URL = reader.StringValue("URL");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

