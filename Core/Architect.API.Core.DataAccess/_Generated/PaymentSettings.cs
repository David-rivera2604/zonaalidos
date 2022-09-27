using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// .
    /// </summary>
    public sealed partial class PaymentSettings
    {

        /// <summary>
        /// Crea un registro en la tabla PaymentSettings.
        /// </summary>
        /// <param name="paymentsettingsItem">Instancia de PaymentSettings</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.PaymentSettings paymentsettingsItem, IDbConnection connection = null)
        {
            if (paymentsettingsItem.UpdateDate.IsEmpty())
            {
                paymentsettingsItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO PaymentSettings (Id, CompanyId, UserId, Currency, ClientId, SecretKey, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :UserId, :Currency, :ClientId, :SecretKey, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, paymentsettingsItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, paymentsettingsItem.CompanyId)
                            .AddParameter("UserId", DbType.Decimal, 9, paymentsettingsItem.UserId)
                            .AddParameter("Currency", DbType.Decimal, 5, paymentsettingsItem.Currency)
                            .AddParameter("ClientId", DbType.AnsiString, 80, paymentsettingsItem.ClientId)
                            .AddParameter("SecretKey", DbType.AnsiString, 80, paymentsettingsItem.SecretKey)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, paymentsettingsItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, paymentsettingsItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla PaymentSettings.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="paymentsettingsItems">Lista de instancia de PaymentSettings</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.PaymentSettings> paymentsettingsItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.PaymentSettings item in paymentsettingsItems)
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
        /// Recupera un registro en la tabla PaymentSettings por medio de su clave primaria.
        /// </summary>
        /// <param name="id">.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de PaymentSettings</returns>
        public static Architect.API.Core.Contracts.General.PaymentSettings Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.PaymentSettings result = null;
            Database.Select("SELECT Id, PaymentSettings.CompanyId, PaymentSettings.UserId, Currency, ClientId, SecretKey, PaymentSettings.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, PaymentSettings.UpdateDate " +
                              "FROM PaymentSettings LEFT JOIN UserMember um ON um.UserId = PaymentSettings.UpdateUserCode " +
                             "WHERE PaymentSettings.Id=:Id AND PaymentSettings.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToPaymentSettings(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla PaymentSettings.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de PaymentSettings</returns>
        public static List<Architect.API.Core.Contracts.General.PaymentSettings> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.PaymentSettings> result = new List<Architect.API.Core.Contracts.General.PaymentSettings>();
            Database.Select("SELECT Id, PaymentSettings.CompanyId, PaymentSettings.UserId, Currency, ClientId, SecretKey, PaymentSettings.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, PaymentSettings.UpdateDate " +
                              "FROM PaymentSettings LEFT JOIN UserMember um ON um.UserId = PaymentSettings.UpdateUserCode " +
                             "WHERE PaymentSettings.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToPaymentSettings(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla PaymentSettings.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de PaymentSettings</returns>
        public static List<Architect.API.Core.Contracts.General.PaymentSettings> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.PaymentSettings> result = new List<Architect.API.Core.Contracts.General.PaymentSettings>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, PaymentSettings.CompanyId, PaymentSettings.UserId, Currency, ClientId, SecretKey, PaymentSettings.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, PaymentSettings.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY PaymentSettings.Id DESC) RowNumber " +
                              "FROM PaymentSettings LEFT JOIN UserMember um ON um.UserId = PaymentSettings.UpdateUserCode " +
                             "WHERE PaymentSettings.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToPaymentSettings(reader));
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
                result += " UPPER(PaymentSettings.UserId) LIKE '%" + filter.ToUpper() + "%' ";

                result += ")";
                if (condition.IsNotEmpty())
                {
                    result += Database.FilterFactory(condition, "PaymentSettings");
                }				
            }
            return result;
        }

        /// <summary>
        /// Último valor asignado a clave única de la tabla PaymentSettings.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM PaymentSettings")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla PaymentSettings por medio de su clave primaria.
        /// </summary>
        /// <param name="paymentsettingsItem">Instancia de PaymentSettings</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.PaymentSettings paymentsettingsItem, IDbConnection connection = null)
        {
            if (paymentsettingsItem.UpdateDate.IsEmpty())
            {
                paymentsettingsItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE PaymentSettings " +
                                      "SET CompanyId=:CompanyId, UserId=:UserId, Currency=:Currency, ClientId=:ClientId, SecretKey=:SecretKey, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, paymentsettingsItem.CompanyId)
                                .AddParameter("UserId", DbType.Decimal, 9, paymentsettingsItem.UserId)
                                .AddParameter("Currency", DbType.Decimal, 5, paymentsettingsItem.Currency)
                                .AddParameter("ClientId", DbType.AnsiString, 80, paymentsettingsItem.ClientId)
                                .AddParameter("SecretKey", DbType.AnsiString, 80, paymentsettingsItem.SecretKey)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, paymentsettingsItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, paymentsettingsItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, paymentsettingsItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla PaymentSettings por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="paymentsettingsItems">Lista de instancia de PaymentSettings</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.PaymentSettings> paymentsettingsItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.PaymentSettings item in paymentsettingsItems)
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
        /// Elimina un registro en la tabla PaymentSettings por medio de su clave primaria.
        /// </summary>
        /// <param name="id">.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM PaymentSettings " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla PaymentSettings por medio de su clave primaria.
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
        /// Recupera la cantidad de registros existentes en la tabla PaymentSettings por medio de su clave primaria.
        /// </summary>
        /// <param name="id">.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM PaymentSettings " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla PaymentSettings que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM PaymentSettings " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'PaymentSettings'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.PaymentSettings DataReaderToPaymentSettings(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.PaymentSettings item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.PaymentSettings();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.UserId = reader.IntegerValue("UserId");
            item.Currency = reader.IntegerValue("Currency");
            item.ClientId = reader.StringValue("ClientId");
            item.SecretKey = reader.StringValue("SecretKey");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

