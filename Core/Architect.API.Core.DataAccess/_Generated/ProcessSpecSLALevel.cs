using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// ProcessSpecSLALevel
    /// </summary>
    public sealed partial class ProcessSpecSLALevel
    {

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecSLALevel.
        /// </summary>
        /// <param name="processspecslalevelItem">Instancia de ProcessSpecSLALevel</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.ProcessSpecSLALevel processspecslalevelItem, IDbConnection connection = null)
        {
            if (processspecslalevelItem.UpdateDate.IsEmpty())
            {
                processspecslalevelItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO ProcessSpecSLALevel (Id, CompanyId, SLA, MailForSLAExpiration, MailForSLAExpirationCustom, MailForSLAExpirationTmpl, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :SLA, :MailForSLAExpiration, :MailForSLAExpirationCustom, :MailForSLAExpirationTmpl, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, processspecslalevelItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, processspecslalevelItem.CompanyId)
                            .AddParameter("SLA", DbType.Decimal, 5, processspecslalevelItem.SLA)
                            .AddParameter("MailForSLAExpiration", DbType.Decimal, 5, processspecslalevelItem.MailForSLAExpiration)
                            .AddParameter("MailForSLAExpirationCustom", DbType.AnsiString, 256, processspecslalevelItem.MailForSLAExpirationCustom)
                            .AddParameter("MailForSLAExpirationTmpl", DbType.Decimal, 5, processspecslalevelItem.MailForSLAExpirationTmpl)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspecslalevelItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, processspecslalevelItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla ProcessSpecSLALevel.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspecslalevelItems">Lista de instancia de ProcessSpecSLALevel</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.ProcessSpecSLALevel> processspecslalevelItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessSpecSLALevel item in processspecslalevelItems)
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
        /// Recupera un registro en la tabla ProcessSpecSLALevel por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ProcessSpecSLALevel</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecSLALevel Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.ProcessSpecSLALevel result = null;
            Database.Select("SELECT Id, ProcessSpecSLALevel.CompanyId, SLA, MailForSLAExpiration, MailForSLAExpirationCustom, MailForSLAExpirationTmpl, ProcessSpecSLALevel.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecSLALevel.UpdateDate " +
                              "FROM ProcessSpecSLALevel LEFT JOIN UserMember um ON um.UserId = ProcessSpecSLALevel.UpdateUserCode " +
                             "WHERE ProcessSpecSLALevel.Id=:Id AND ProcessSpecSLALevel.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToProcessSpecSLALevel(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecSLALevel.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecSLALevel</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecSLALevel> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecSLALevel> result = new List<Architect.API.Core.Contracts.General.ProcessSpecSLALevel>();
            Database.Select("SELECT Id, ProcessSpecSLALevel.CompanyId, SLA, MailForSLAExpiration, MailForSLAExpirationCustom, MailForSLAExpirationTmpl, ProcessSpecSLALevel.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecSLALevel.UpdateDate " +
                              "FROM ProcessSpecSLALevel LEFT JOIN UserMember um ON um.UserId = ProcessSpecSLALevel.UpdateUserCode " +
                             "WHERE ProcessSpecSLALevel.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecSLALevel(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecSLALevel.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecSLALevel</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecSLALevel> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecSLALevel> result = new List<Architect.API.Core.Contracts.General.ProcessSpecSLALevel>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, ProcessSpecSLALevel.CompanyId, SLA, MailForSLAExpiration, MailForSLAExpirationCustom, MailForSLAExpirationTmpl, ProcessSpecSLALevel.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecSLALevel.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY ProcessSpecSLALevel.Id DESC) RowNumber " +
                              "FROM ProcessSpecSLALevel LEFT JOIN UserMember um ON um.UserId = ProcessSpecSLALevel.UpdateUserCode " +
                             "WHERE ProcessSpecSLALevel.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecSLALevel(reader));
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
        /// Último valor asignado a clave única de la tabla ProcessSpecSLALevel.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM ProcessSpecSLALevel")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecSLALevel por medio de su clave primaria.
        /// </summary>
        /// <param name="processspecslalevelItem">Instancia de ProcessSpecSLALevel</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.ProcessSpecSLALevel processspecslalevelItem, IDbConnection connection = null)
        {
            if (processspecslalevelItem.UpdateDate.IsEmpty())
            {
                processspecslalevelItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE ProcessSpecSLALevel " +
                                      "SET CompanyId=:CompanyId, SLA=:SLA, MailForSLAExpiration=:MailForSLAExpiration, MailForSLAExpirationCustom=:MailForSLAExpirationCustom, MailForSLAExpirationTmpl=:MailForSLAExpirationTmpl, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, processspecslalevelItem.CompanyId)
                                .AddParameter("SLA", DbType.Decimal, 5, processspecslalevelItem.SLA)
                                .AddParameter("MailForSLAExpiration", DbType.Decimal, 5, processspecslalevelItem.MailForSLAExpiration)
                                .AddParameter("MailForSLAExpirationCustom", DbType.AnsiString, 256, processspecslalevelItem.MailForSLAExpirationCustom)
                                .AddParameter("MailForSLAExpirationTmpl", DbType.Decimal, 5, processspecslalevelItem.MailForSLAExpirationTmpl)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspecslalevelItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, processspecslalevelItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, processspecslalevelItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecSLALevel por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspecslalevelItems">Lista de instancia de ProcessSpecSLALevel</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.ProcessSpecSLALevel> processspecslalevelItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessSpecSLALevel item in processspecslalevelItems)
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
        /// Elimina un registro en la tabla ProcessSpecSLALevel por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ProcessSpecSLALevel " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecSLALevel por medio de su clave primaria.
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
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecSLALevel por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecSLALevel " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecSLALevel que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecSLALevel " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'ProcessSpecSLALevel'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecSLALevel DataReaderToProcessSpecSLALevel(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.ProcessSpecSLALevel item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.ProcessSpecSLALevel();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.SLA = reader.IntegerValue("SLA");
            item.MailForSLAExpiration = reader.IntegerValue("MailForSLAExpiration");
            item.MailForSLAExpirationCustom = reader.StringValue("MailForSLAExpirationCustom");
            item.MailForSLAExpirationTmpl = reader.IntegerValue("MailForSLAExpirationTmpl");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

