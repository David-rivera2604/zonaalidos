using Architect.Utilities;
using Architect.Utilities.Extensions;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Architect.DataFactory
{
    public class Database : IDisposable
    {
        #region Properties Environment

        public string Statement { get; set; }
        public List<Contracts.Parameter> Parameters { get; set; }
        public string StatementType { get; set; }
        public double CacheExpiration { get; set; }
        public bool IsCaching { get; private set; }

        public bool ForBuild { get; private set; }

        public string CachePrefix { get; private set; }
        public string ConnectionStringName { get; private set; }

        #endregion Properties Environment

        #region Methods Data



        public static Database Command(string statement)
        {
            var result = new Database() { StatementType = "Command", Statement = statement };
            return result;
        }

        public static Database Insert(string statement)
        {
            var result = new Database() { StatementType = "Insert", Statement = statement };
            return result;
        }

        public static Database Insert(string tableName, Enumerations.ExecuteMode mode)
        {
            var result = new Database() { StatementType = "Insert", Statement = tableName, ForBuild = true };
            return result;
        }

        public static Database Select(string statement)
        {
            var result = new Database() { StatementType = "Select", Statement = statement };
            return result;
        }

        public static Database Update(string statement)
        {
            var result = new Database() { StatementType = "Update", Statement = statement };
            return result;
        }
        public static Database Update(string tableName, Enumerations.ExecuteMode mode)
        {
            var result = new Database() { StatementType = "Update", Statement = tableName, ForBuild = true };
            return result;
        }
        public static Database Delete(string statement)
        {
            var result = new Database() { StatementType = "Delete", Statement = statement };

            return result;
        }
        public static Database Delete(string tableName, Enumerations.ExecuteMode mode)
        {
            var result = new Database() { StatementType = "Delete", Statement = tableName, ForBuild = true };

            return result;
        }

        public static Database Procedure(string statement)
        {
            var result = new Database() { StatementType = "Procedure", Statement = statement };

            return result;
        }

        #endregion Methods Data

        #region Cache

        public Database Cache(string prefix = "Data")
        {
            var minutesCaching = 10;
            if (!(ConfigurationManager.AppSettings["Architect.DataFactory.Cache.Expiration"] is null))
                minutesCaching = int.Parse(ConfigurationManager.AppSettings["Architect.DataFactory.Cache.Expiration"].ToString());
            this.Cache(true, minutesCaching, prefix);
            return this;
        }

        public Database Cache(bool isCaching, string prefix = "Data")
        {
            var minutesCaching = 10;
            if (!(ConfigurationManager.AppSettings["Architect.DataFactory.Cache.Expiration"] is null))
                minutesCaching = int.Parse(ConfigurationManager.AppSettings["Architect.DataFactory.Cache.Expiration"].ToString());
            this.Cache(isCaching, minutesCaching, prefix);
            return this;
        }

        public Database Cache(bool isCaching, double timeByCaching, string prefix = "Data")
        {
            this.CacheExpiration = timeByCaching;
            this.IsCaching = isCaching;
            this.CachePrefix = prefix;
            if (this.CachePrefix.IsEmpty())
            {
                this.CachePrefix = "Data";
            }
            return this;
        }

        #endregion Cache

        #region Parameters

        public static Database ParameterList()
        {
            var result = new Database() { StatementType = "Parameter", Statement = string.Empty, Parameters = new List<Contracts.Parameter>() };

            return result;
        }

        public Database AddParameter(List<Contracts.Parameter> parameters)
        {
            if (parameters != null)
            {
                if (Parameters == null)
                {
                    Parameters = new List<Contracts.Parameter>();
                }
                Parameters.AddRange(parameters);
            }
            return this;
        }

        public Database Filter(string name, Architect.DataFactory.Enumerations.DbType type, int size, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            if (Parameters == null)
            {
                Parameters = new List<Contracts.Parameter>();
            }
            if (type == Enumerations.DbType.String && value.IsNotEmpty() && value.ToString().Length > size)
            {
                value = value.ToString().Substring(0, size);
            }
            Parameters.Add(new Contracts.Parameter() { Name = name, Type = type, Size = size, Value = value, direction = direction, Filter = true });

            return this;
        }
        public Database Column(string name, Architect.DataFactory.Enumerations.DbType type, int size, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            return Parameter(name, type, size, value, direction);
        }

        public Database Parameter(string name, Architect.DataFactory.Enumerations.DbType type, int size, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            if (Parameters == null)
            {
                Parameters = new List<Contracts.Parameter>();
            }
            if (type == Enumerations.DbType.String && value.IsNotEmpty() && value.ToString().Length > size)
            {
                value = value.ToString().Substring(0, size);
            }
            Parameters.Add(new Contracts.Parameter() { Name = name, Type = type, Size = size, Value = value, direction = direction });

            return this;
        }

        public Database AddParameter(string name, Architect.DataFactory.Enumerations.DbType type, int size, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            if (Parameters == null)
            {
                Parameters = new List<Contracts.Parameter>();
            }
            Parameters.Add(new Contracts.Parameter() { Name = name, Type = type, Size = size, Value = value, direction = direction });

            return this;
        }

        /// <summary>
        ///  Tabla de conversions e DbType to OracleDbType
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private static OracleDbType DBParameterTypeConvert(Contracts.Parameter parameter)
        {
            OracleDbType result;
            switch (parameter.Type)
            {
                case Enumerations.DbType.Byte:
                case Enumerations.DbType.Boolean:
                case Enumerations.DbType.Currency:
                case Enumerations.DbType.Guid:
                case Enumerations.DbType.Object:
                case Enumerations.DbType.Time:
                case Enumerations.DbType.UInt16:
                case Enumerations.DbType.UInt32:
                case Enumerations.DbType.UInt64:
                case Enumerations.DbType.VarNumeric:
                case Enumerations.DbType.Xml:
                case Enumerations.DbType.DateTime2:
                case Enumerations.DbType.DateTimeOffset:
                case Enumerations.DbType.Single:
                case Enumerations.DbType.SByte:
                    Exception currentException2 = new Exception($"The data '{parameter.Type.ToString()}' type is not typed for conversion");
                    throw currentException2;
                case Enumerations.DbType.Binary:
                    result = OracleDbType.Blob;
                    break;
                case Enumerations.DbType.AnsiStringFixedLength:
                case Enumerations.DbType.StringFixedLength:
                    result = OracleDbType.Char;
                    break;

                case Enumerations.DbType.Decimal:
                    result = OracleDbType.Decimal;
                    break;

                case Enumerations.DbType.Double:
                    result = OracleDbType.Double;
                    break;

                case Enumerations.DbType.DateTime:
                case Enumerations.DbType.Date:
                    result = OracleDbType.Date;
                    break;

                case Enumerations.DbType.Int16:
                    result = OracleDbType.Int16;
                    break;

                case Enumerations.DbType.Int32:
                    result = OracleDbType.Int32;
                    break;

                case Enumerations.DbType.Int64:
                    result = OracleDbType.Int64;
                    break;

                case Enumerations.DbType.AnsiString:
                case Enumerations.DbType.String:
                case Enumerations.DbType.StringArray:
                    result = OracleDbType.Varchar2;
                    break;

                case Enumerations.DbType.RefCursor:
                    result = OracleDbType.RefCursor;
                    break;

                case Enumerations.DbType.Clob:
                    result = OracleDbType.Clob;
                    break;

                default:
                    Exception currentException = new Exception($"The data '{parameter.Type.ToString()}' type is not typed for conversion");
                    throw currentException;
            }
            return result;
        }

        private static object DBParameterValueConvert(object value)
        {
            object result = value;
            if (value is int && (int)value == int.MinValue)
            {
                result = DBNull.Value;
            }
            else if (value is string && ((string)value).IsEmpty())
            {
                result = DBNull.Value;
            }
            else if (value is DateTime && (DateTime)value == DateTime.MinValue)
            {
                result = DBNull.Value;
            }
            return result;
        }

        private static ParameterDirection DBParameterDirectionConvert(Contracts.Parameter parameter)
        {
            switch (parameter.direction)
            {
                case ParameterDirection.Input:
                    return ParameterDirection.Input;

                case ParameterDirection.Output:
                    return ParameterDirection.Output;

                case ParameterDirection.InputOutput:
                    return ParameterDirection.InputOutput;

                case ParameterDirection.ReturnValue:
                    return ParameterDirection.ReturnValue;

                default:
                    throw new Exception("Not presente dirección");
            }
        }

        public static DbParameter CreateRefCursorParameter()
        {
            OracleParameter refCursorParameter = new OracleParameter
            {
                ParameterName = "RC1",
                Direction = ParameterDirection.Output
            };
            return (DbParameter)refCursorParameter;
        }

        public static Enumerations.DbType DBParameterTypeConvertNative(string type)
        {
            Enumerations.DbType result;
            switch (type.ToLower())
            {
                case "binary":
                case "byte":
                case "boolean":
                case "currency":
                case "guid":
                case "object":
                case "time":
                case "uint16":
                case "uint32":
                case "uint64":
                case "varnumeric":
                case "ansistringfixedlength":
                case "stringfixedlength":
                case "xml":
                case "datetime2":
                case "datetimeoffset":
                case "single":
                case "sbyte":
                    throw new Exception(string.Format("The data '{0}' type is not typed for conversion", type.ToString()));
                case "number":
                case "decimal":
                    result = Enumerations.DbType.Decimal;
                    break;

                case "double":
                    result = Enumerations.DbType.Double;
                    break;

                case "dateTime":
                case "date":
                    result = Enumerations.DbType.Date;
                    break;

                case "int16":
                    result = Enumerations.DbType.Int16;
                    break;

                case "int32":
                    result = Enumerations.DbType.Int32;
                    break;

                case "int64":
                    result = Enumerations.DbType.Int64;
                    break;

                case "ansistring":
                case "string":
                    result = Enumerations.DbType.String;
                    break;

                case "ref cursor":
                    result = Enumerations.DbType.RefCursor;
                    break;

                default:
                    throw new Exception(string.Format("The data '{0}' type is not typed for conversion", type.ToString()));
            }
            return result;
        }

        public static OracleDbType DBParameterTypeConvert(string type)
        {
            OracleDbType result;
            switch (type)
            {
                case "Enumerations.DbType.Binary":
                case "Enumerations.DbType.Byte":
                case "Enumerations.DbType.Boolean":
                case "Enumerations.DbType.Currency":
                case "Enumerations.DbType.Guid":
                case "Enumerations.DbType.Object":
                case "Enumerations.DbType.Time":
                case "Enumerations.DbType.UInt16":
                case "Enumerations.DbType.UInt32":
                case "Enumerations.DbType.UInt64":
                case "Enumerations.DbType.VarNumeric":
                case "Enumerations.DbType.AnsiStringFixedLength":
                case "Enumerations.DbType.StringFixedLength":
                case "Enumerations.DbType.Xml":
                case "Enumerations.DbType.DateTime2":
                case "Enumerations.DbType.DateTimeOffset":
                case "Enumerations.DbType.Single":
                case "Enumerations.DbType.SByte":
                    throw new Exception(string.Format("The data '{0}' type is not typed for conversion", type.ToString()));

                case "Enumerations.DbType.Decimal":
                    result = OracleDbType.Decimal;
                    break;

                case "Enumerations.DbType.Double":
                    result = OracleDbType.Double;
                    break;

                case "Enumerations.DbType.DateTime":
                case "Enumerations.DbType.Date":
                    result = OracleDbType.Date;
                    break;

                case "Enumerations.DbType.Int16":
                    result = OracleDbType.Int16;
                    break;

                case "Enumerations.DbType.Int32":
                    result = OracleDbType.Int32;
                    break;

                case "Enumerations.DbType.Int64":
                    result = OracleDbType.Int64;
                    break;

                case "Enumerations.DbType.AnsiString":
                case "Enumerations.DbType.String":
                    result = OracleDbType.NVarchar2;
                    break;

                case "Enumerations.DbType.RefCursor":
                    result = OracleDbType.RefCursor;
                    break;

                default:
                    throw new Exception(string.Format("The data '{0}' type is not typed for conversion", type.ToString()));
            }
            return result;
        }

        #endregion Parameters

        #region Queries

        #region Queries

        public DataTable Query(string connectionStringName)
        {
            return Query(null, connectionStringName);
        }

        public DataTable Query(IDbConnection connection, string connectionStringName)
        {
            bool local = false;
            DataTable result;

            if (connection == null)
            {
                local = true;
                connection = OpenConnection(connectionStringName);
            }

            switch (StatementType)
            {
                case "Select":
                case "Procedure":
                    result = ExecuteQuery(this, connection, StatementType);
                    break;

                default:
                    Exception currentException = new Exception(string.Format("Tipo de instrucción ({0}) invalida para esta operación", StatementType));
                    throw currentException;
            }

            if (local)
            {
                connection.Close();
            }
            return result;
        }
        public DataSet MultiQuery(IDbConnection connection, string connectionStringName)
        {
            bool local = false;
            DataSet result;

            if (connection == null)
            {
                local = true;
                connection = OpenConnection(connectionStringName);
            }

            switch (StatementType)
            {
                case "Select":
                case "Procedure":
                    result = ExecuteMultiQuery(this, connection, StatementType);
                    break;

                default:
                    Exception currentException = new Exception(string.Format("Tipo de instrucción ({0}) invalida para esta operación", StatementType));
                    throw currentException;
            }

            if (local)
            {
                connection.Close();
            }
            return result;
        }

        public void Query(IDbConnection connection, string connectionStringName, Action<IDataReader> callBack, bool manyRows = true)
        {
            if (connection != null)
            {
                Query(connection, callBack, manyRows);
            }
            else
            {
                Query(connectionStringName, callBack, manyRows);
            }
        }

        public void Query(string connectionStringName, Action<IDataReader> callBack, bool manyRows = true)
        {
            this.ConnectionStringName = connectionStringName;
            IDbConnection local = OpenConnection(connectionStringName);
            Query(local, callBack, manyRows);
            local.Close();
        }

        private void Query(IDbConnection connection, Action<IDataReader> callBack, bool manyRows)
        {
            switch (StatementType)
            {
                case "Select":
                case "Procedure":
                    ExecuteQueryWithDataReader(this, connection, callBack, StatementType, manyRows);
                    break;

                default:
                    Exception currentException = new Exception(string.Format("Tipo de instrucción ({0}) invalida para esta operación", StatementType));
                    throw currentException;
            }
        }

        public void Query(IDbConnection connection, string connectionStringName, Action<IDataReader, string> callBack)
        {
            IDbConnection local = null;
            if (connection == null)
            {
                this.ConnectionStringName = connectionStringName;
                local = OpenConnection(connectionStringName);
                connection = local;
            }
            switch (StatementType)
            {
                case "Select":
                case "Procedure":
                    ExecuteQueryWithDataReader(this, connection, callBack, StatementType, true);
                    break;

                default:
                    Exception currentException = new Exception(string.Format("Tipo de instrucción ({0}) invalida para esta operación", StatementType));
                    throw currentException;
            }
            if (local != null)
            {
                local.Close();
            }

        }

        #endregion Queries

        #region QueriesScalar

        public T QueryScalar<T>(IDbConnection connection, string connectionStringName)
        {
            if (connection != null)
            {
                return QueryScalar<T>(connection);
            }
            else
            {
                return QueryScalar<T>(connectionStringName);
            }
        }

        public T QueryScalar<T>(string connectionStringName)
        {
            IDbConnection local = OpenConnection(connectionStringName);
            T result = QueryScalar<T>(local);
            local.Close();
            return result;
        }

        private T QueryScalar<T>(IDbConnection connection)
        {
            T result;

            switch (StatementType)
            {
                case "Select":
                    result = ExecuteQueryScalar<T>(this, connection);
                    break;

                default:
                    throw new Exception(string.Format("Tipo de instrucción ({0}) invalida para esta operación", StatementType));
            }

            return result;
        }

        #endregion QueriesScalar

        #endregion Queries

        #region Execute

        public int Execute(IDbConnection connection, string connectionStringName)
        {
            if (connection != null)
            {
                return Execute(connection);
            }
            else
            {
                return Execute(connectionStringName);
            }
        }

        public int Execute(IDbConnection connection, string connectionStringName, Action<DbCommand> callBack)
        {
            if (connection != null)
            {
                return Execute(connection, callBack);
            }
            else
            {
                IDbConnection local = OpenConnection(connectionStringName);
                int result = Execute(local, callBack);
                local.Close();
                return result;
            }
        }

        public int Execute(string connectionStringName)
        {
            IDbConnection local = OpenConnection(connectionStringName);
            int result = Execute(local);
            local.Close();
            return result;
        }

        private string InsertBuilder()
        {
            string fieldList = string.Empty;
            foreach (var item in Parameters)
            {
                if (fieldList.IsNotEmpty())
                    fieldList += ", ";
                fieldList += string.Format(":{0}", item.Name);
            }
            return string.Format("INSERT INTO {0} ({1}) VALUES({2})", Statement, fieldList.Replace(":", string.Empty), fieldList);
        }

        private string UpdateBuilder()
        {
            string fieldList = string.Empty;
            string filterList = string.Empty;
            foreach (var item in Parameters)
            {
                if (!item.Filter)
                {
                    if (fieldList.IsNotEmpty())
                        fieldList += ", ";
                    fieldList += string.Format("{0}=:{0}", item.Name);
                }
                else
                {
                    if (filterList.IsNotEmpty())
                        filterList += " AND ";
                    filterList += string.Format("{0}=:{0}", item.Name);
                }
            }
            return string.Format("UPDATE {0} SET {1} WHERE {2}", Statement, fieldList, filterList);
        }

        private string DeleteBuilder()
        {
            string filterList = string.Empty;
            foreach (var item in Parameters)
            {
                if (filterList.IsNotEmpty())
                    filterList += " AND ";
                filterList += string.Format("{0}=:{0}", item.Name);
            }
            return string.Format("DELETE FROM {0} WHERE {1}", Statement, filterList);
        }

        private int Execute(IDbConnection connection)
        {
            int result;
            switch (StatementType)
            {
                case "Insert":
                case "Command":
                    if (ForBuild)
                    {
                        Statement = InsertBuilder();
                    }
                    result = ExecuteNonQuery(connection);
                    break;

                case "Update":
                    if (ForBuild)
                    {
                        Statement = UpdateBuilder();
                    }
                    result = ExecuteNonQuery(connection);
                    break;

                case "Delete":
                    if (ForBuild)
                    {
                        Statement = DeleteBuilder();
                    }
                    result = ExecuteNonQuery(connection);
                    break;

                case "Procedure":
                    result = ExecuteNonQuery(connection, "Procedure");
                    break;

                default:
                    Exception currentException = new Exception(string.Format("Tipo de instrucción ({0}) invalida para esta operación", StatementType));
                    throw currentException;
            }
            return result;
        }

        private int Execute(IDbConnection connection, Action<DbCommand> callBack)
        {
            int result = 0;
            OracleCommand command;
            switch (StatementType)
            {
                case "Insert":
                case "Command":
                    command = ExecuteNonQueryReturnCommand(connection);
                    break;

                case "Update":
                    command = ExecuteNonQueryReturnCommand(connection);
                    break;

                case "Delete":
                    command = ExecuteNonQueryReturnCommand(connection);
                    break;

                case "Procedure":
                    command = ExecuteNonQueryReturnCommand(connection, "Procedure");
                    break;

                default:
                    Exception curentException = new Exception(string.Format("Tipo de instrucción ({0}) invalida para esta operación", StatementType));
                    throw curentException;
            }
            callBack.DynamicInvoke(command);
            return result;
        }

        #endregion Execute

        #region Method Private

        private int ExecuteNonQuery(IDbConnection connection, string CommandType = "Select")
        {
            Stopwatch watch = null;
            if (Handlers.UtilityHandler.AppSettingsCheck("Architect.DataFactory.Trace.Enabled"))
            {
                watch = new Stopwatch();
                watch.Start();
            }
            OracleCommand cmmd = new OracleCommand(Statement, (OracleConnection)connection);
            if (CommandType.Equals("Procedure"))
            {
                cmmd.CommandType = System.Data.CommandType.StoredProcedure;
            }
            if (Parameters?.Count > 0)
            {
                foreach (var item in Parameters)
                {
                    OracleParameter parameter = new OracleParameter(item.Name, DBParameterTypeConvert(item), item.Size, DBParameterValueConvert(item.Value), DBParameterDirectionConvert(item));
                    if (item.Type == Enumerations.DbType.StringArray)
                    {
                        parameter.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    }

                    cmmd.Parameters.Add(parameter);
                }
            }
            int result;
            try
            {
                result = cmmd.ExecuteNonQuery();
                if (Parameters != null && Parameters.Count > 0)
                {
                    foreach (Contracts.Parameter item in Parameters.Where(c => c.direction == ParameterDirection.InputOutput || c.direction == ParameterDirection.Output))
                    {
                        item.Value = cmmd.Parameters[item.Name].Value;
                    }
                }

            }
            catch (OracleException exOracle)
            {
                Exception temporalException = Exceptions.DataAccessException.Factory(exOracle, cmmd, string.Empty, CommandType);
                ClosedConnection(cmmd, connection);
                throw temporalException;
            }
            catch (Exception ex)
            {
                Exception temporalException = Exceptions.DataAccessException.Factory(ex, cmmd, string.Empty, CommandType);
                ClosedConnection(cmmd, connection);
                throw temporalException;
            }
            if (Handlers.UtilityHandler.AppSettingsCheck("Architect.DataFactory.Trace.Enabled"))
            {
                watch.Stop();
                Log.TraceLog("DataAccessLayer",
                    Handlers.UtilityHandler.MakeCommandSummary(cmmd) +
                    String.Format("  {0} Rows affected in {1} ms\n", result, watch.ElapsedMilliseconds), "datafactory");
            }
            return result;
        }

        private OracleCommand ExecuteNonQueryReturnCommand(IDbConnection connection, string CommandType = "Select")
        {
            OracleCommand cmmd = new OracleCommand(Statement, (OracleConnection)connection);
            if (CommandType.Equals("Procedure"))
            {
                cmmd.CommandType = System.Data.CommandType.StoredProcedure;
            }
            if (Parameters?.Count > 0)
            {
                foreach (var item in Parameters)
                {
                    OracleParameter parameter = new OracleParameter(item.Name, DBParameterTypeConvert(item), item.Size, DBParameterValueConvert(item.Value), DBParameterDirectionConvert(item));
                    if (item.Type == Enumerations.DbType.StringArray)
                    {
                        parameter.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    }
                    cmmd.Parameters.Add(parameter);
                }
            }
            try
            {
                int result = cmmd.ExecuteNonQuery();
            }
            catch (OracleException exOracle)
            {
                Exception temporalException = Exceptions.DataAccessException.Factory(exOracle, cmmd, string.Empty, CommandType);
                ClosedConnection(cmmd, connection);
                throw temporalException;
            }
            catch (Exception ex)
            {
                Exception temporalException = Exceptions.DataAccessException.Factory(ex, cmmd, string.Empty, CommandType);
                ClosedConnection(cmmd, connection);
                throw temporalException;
            }
            return cmmd;
        }

        /// <summary>
        /// Métodos para ejecutar consultas en la base de datos, con sobrecarga de la conexión.
        /// </summary>
        /// <param name="command">Comando que se desea ejecutar</param>
        /// <param name="connection">Instancia del objeto conexión</param>
        /// <returns></returns>
        private DataSet ExecuteMultiQuery(Database database, IDbConnection connection, string CommandType = "Select")
        {
            var key = string.Empty;
            Stopwatch watch = null;
            DataSet result = new DataSet();
            OracleCommand cmmd = new OracleCommand(Statement, (OracleConnection)connection);
            if (Handlers.UtilityHandler.AppSettingsCheck("Architect.DataFactory.Trace.Enabled"))
            {
                watch = new Stopwatch();
                watch.Start();
            }
            if (database.IsCaching)
            {
                key = string.Format("{1}.{0}", Architect.DataFactory.Handlers.UtilityHandler.GetMd5Hash(database.ConnectionStringName, Statement, database.Parameters), database.CachePrefix);
            }
            if (!database.IsCaching || Architect.Utilities.Cache.NotExist(key))
            {
                for (int attempts = 1; attempts <= 3; attempts++)
                {
                    try
                    {
                        if (CommandType.Equals("Procedure"))
                        {
                            cmmd.CommandType = System.Data.CommandType.StoredProcedure;
                        }
                        if (Parameters?.Count > 0)
                        {
                            bool haveRefCursor = false;
                            foreach (var item in Parameters)
                            {
                                OracleParameter parameter;
                                parameter = new OracleParameter(item.Name, DBParameterTypeConvert(item), item.Size, item.Value, DBParameterDirectionConvert(item));
                                if (item.Type == Enumerations.DbType.StringArray)
                                {
                                    parameter.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                                }
                                if (item.Type == Enumerations.DbType.RefCursor)
                                {
                                    haveRefCursor = true;
                                }

                                cmmd.Parameters.Add(parameter);
                            }
                            if (CommandType.Equals("Procedure") && !haveRefCursor)
                            {
                                cmmd.Parameters.Add(new OracleParameter("RC1", OracleDbType.RefCursor, ParameterDirection.Output));
                            }
                        }

           
                        OracleDataAdapter oda = new OracleDataAdapter(cmmd);
                        oda.Fill(result);

                        if (database.IsCaching)
                        {
                            Architect.Utilities.Cache.SetItem(key, result, database.CacheExpiration);
                        }
                        break;
                    }
                    catch (OracleException exOracle)
                    {
                        if ((exOracle.Message.StartsWith("ORA-03135:") ||
                             exOracle.Message.StartsWith("ORA-03113:") ||
                             exOracle.Message.IndexOf("End-of-file on communication channel", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                             exOracle.Message.IndexOf("fin de archivo en el canal de comunicación", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                             exOracle.Message.IndexOf("TNS:packet writer failure", StringComparison.CurrentCultureIgnoreCase) > -1) && attempts < 3)
                        {
                            MethodInfo magicMethod = connection.GetType().GetMethod("ClearAllPools");
                            for (int connectAttempts = 1; connectAttempts <= 3; connectAttempts++)
                            {
                                cmmd.Connection = null;
                                if (connection.State == ConnectionState.Open)
                                    connection.Close();

                                if (magicMethod.IsNotEmpty())
                                    magicMethod.Invoke(connection, new Object[] { });

                                Log.WarningLog("DataAccessLayer", $"Retry due to disconnection for query on table '{result.Tables.Count}' ({attempts}/{connectAttempts}). {exOracle.Message}", "datafactory");
                                Thread.Sleep(1000);

                                try
                                {
                                    connection.Open();
                                    break;
                                }
                                catch (Exception ex2)
                                {
                                    if (connectAttempts >= 3)
                                    {
                                        var temporalException = Exceptions.DataAccessException.Factory(ex2, cmmd, result.Tables.Count.ToString(), "Query");
                                        ClosedConnection(cmmd, connection);
                                        throw temporalException;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Exception temporalException = Exceptions.DataAccessException.Factory(exOracle, cmmd, string.Empty, "Query");
                            ClosedConnection(cmmd, connection);
                            throw temporalException;
                        }
                    }
                    catch (Exception ex)
                    {
                        Exception temporalException;
                        if ((ex.Message.StartsWith("ORA-03135:") || ex.Message.StartsWith("ORA-03113:") || ex.Message.IndexOf("End-of-file on communication channel", StringComparison.CurrentCultureIgnoreCase) > -1 || ex.Message.IndexOf("fin de archivo en el canal de comunicación", StringComparison.CurrentCultureIgnoreCase) > -1 || ex.Message.IndexOf("TNS:packet writer failure", StringComparison.CurrentCultureIgnoreCase) > -1) && attempts < 3)
                        {
                            MethodInfo magicMethod = connection.GetType().GetMethod("ClearAllPools");
                            if (magicMethod.IsNotEmpty())
                                magicMethod.Invoke(connection, new Object[] { });
                            Log.WarningLog("DataAccessLayer", String.Format("Retry due to disconnection for '{3}' command on table '{2}' ({0}). {1}", attempts, ex.Message, result.Tables.Count, "Query"), "datafactory");

                            Thread.Sleep(500);

                            try
                            {
                                connection.Open();
                            }
                            catch (Exception ex2)
                            {
                                temporalException = Exceptions.DataAccessException.Factory(ex2, cmmd, result.Tables.Count.ToString(), "Query");
                                ClosedConnection(cmmd, connection);
                                throw temporalException;
                            }
                        }
                        else
                        {
                            temporalException = Exceptions.DataAccessException.Factory(ex, cmmd, result.Tables.Count.ToString(), "Query");
                            ClosedConnection(cmmd, connection);
                            throw temporalException;
                        }
                    }
                }

            }
            else
            {
                result = (DataSet)Architect.Utilities.Cache.GetItem(key);
            }
            if (Handlers.UtilityHandler.AppSettingsCheck("Architect.DataFactory.Trace.Enabled"))
            {
                watch.Stop();

                Log.TraceLog("DataAccessLayer",
                    Handlers.UtilityHandler.MakeCommandSummary(cmmd) +
                    $"  {result.Tables.Count} Tables in {watch.ElapsedMilliseconds} ms{((database.IsCaching ? " (Cache)" : ""))}\n", "datafactory");
            }
            return result;
        }


        /// <summary>
        /// Métodos para ejecutar consultas en la base de datos, con sobrecarga de la conexión.
        /// </summary>
        /// <param name="command">Comando que se desea ejecutar</param>
        /// <param name="connection">Instancia del objeto conexión</param>
        /// <returns></returns>
        private DataTable ExecuteQuery(Database database, IDbConnection connection, string CommandType = "Select")
        {
            var key = string.Empty;
            Stopwatch watch = null;
            DataTable result = new DataTable();
            OracleCommand cmmd = new OracleCommand(Statement, (OracleConnection)connection);
            if (Handlers.UtilityHandler.AppSettingsCheck("Architect.DataFactory.Trace.Enabled"))
            {
                watch = new Stopwatch();
                watch.Start();
            }
            if (database.IsCaching)
            {
                key = string.Format("{1}.{0}", Architect.DataFactory.Handlers.UtilityHandler.GetMd5Hash(database.ConnectionStringName, Statement, database.Parameters), database.CachePrefix);
            }
            if (!database.IsCaching || Architect.Utilities.Cache.NotExist(key))
            {
                for (int attempts = 1; attempts <= 3; attempts++)
                {
                    try
                    {
                        if (CommandType.Equals("Procedure"))
                        {
                            cmmd.CommandType = System.Data.CommandType.StoredProcedure;
                        }
                        if (Parameters?.Count > 0)
                        {
                            bool haveRefCursor = false;
                            foreach (var item in Parameters)
                            {
                                OracleParameter parameter;
                                parameter = new OracleParameter(item.Name, DBParameterTypeConvert(item), item.Size, item.Value, DBParameterDirectionConvert(item));
                                if (item.Type == Enumerations.DbType.StringArray)
                                {
                                    parameter.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                                }
                                if (item.Type == Enumerations.DbType.RefCursor)
                                {
                                    haveRefCursor = true;
                                }

                                cmmd.Parameters.Add(parameter);
                            }
                            if (CommandType.Equals("Procedure") && !haveRefCursor)
                            {
                                cmmd.Parameters.Add(new OracleParameter("RC1", OracleDbType.RefCursor, ParameterDirection.Output));
                            }
                        }

                        OracleDataAdapter oda = new OracleDataAdapter(cmmd);
                        oda.Fill(result);

                        if (database.IsCaching)
                        {
                            Architect.Utilities.Cache.SetItem(key, result, database.CacheExpiration);
                        }
                        break;
                    }
                    catch (OracleException exOracle)
                    {
                        if ((exOracle.Message.StartsWith("ORA-03135:") ||
                             exOracle.Message.StartsWith("ORA-03113:") ||
                             exOracle.Message.IndexOf("End-of-file on communication channel", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                             exOracle.Message.IndexOf("fin de archivo en el canal de comunicación", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                             exOracle.Message.IndexOf("TNS:packet writer failure", StringComparison.CurrentCultureIgnoreCase) > -1) && attempts < 3)
                        {
                            MethodInfo magicMethod = connection.GetType().GetMethod("ClearAllPools");
                            for (int connectAttempts = 1; connectAttempts <= 3; connectAttempts++)
                            {
                                cmmd.Connection = null;
                                if (connection.State == ConnectionState.Open)
                                    connection.Close();

                                if (magicMethod.IsNotEmpty())
                                    magicMethod.Invoke(connection, new Object[] { });

                                Log.WarningLog("DataAccessLayer", $"Retry due to disconnection for query on table '{result.TableName}' ({attempts}/{connectAttempts}). {exOracle.Message}", "datafactory");
                                Thread.Sleep(1000);

                                try
                                {
                                    connection.Open();
                                    break;
                                }
                                catch (Exception ex2)
                                {
                                    if (connectAttempts >= 3)
                                    {
                                        var temporalException = Exceptions.DataAccessException.Factory(ex2, cmmd, result.TableName, "Query");
                                        ClosedConnection(cmmd, connection);
                                        throw temporalException;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Exception temporalException = Exceptions.DataAccessException.Factory(exOracle, cmmd, string.Empty, "Query");
                            ClosedConnection(cmmd, connection);
                            throw temporalException;
                        }
                    }
                    catch (Exception ex)
                    {
                        Exception temporalException;
                        if ((ex.Message.StartsWith("ORA-03135:") || ex.Message.StartsWith("ORA-03113:") || ex.Message.IndexOf("End-of-file on communication channel", StringComparison.CurrentCultureIgnoreCase) > -1 || ex.Message.IndexOf("fin de archivo en el canal de comunicación", StringComparison.CurrentCultureIgnoreCase) > -1 || ex.Message.IndexOf("TNS:packet writer failure", StringComparison.CurrentCultureIgnoreCase) > -1) && attempts < 3)
                        {
                            MethodInfo magicMethod = connection.GetType().GetMethod("ClearAllPools");
                            if (magicMethod.IsNotEmpty())
                                magicMethod.Invoke(connection, new Object[] { });
                            Log.WarningLog("DataAccessLayer", String.Format("Retry due to disconnection for '{3}' command on table '{2}' ({0}). {1}", attempts, ex.Message, result.TableName, "Query"), "datafactory");

                            Thread.Sleep(500);

                            try
                            {
                                connection.Open();
                            }
                            catch (Exception ex2)
                            {
                                temporalException = Exceptions.DataAccessException.Factory(ex2, cmmd, result.TableName, "Query");
                                ClosedConnection(cmmd, connection);
                                throw temporalException;
                            }
                        }
                        else
                        {
                            temporalException = Exceptions.DataAccessException.Factory(ex, cmmd, result.TableName, "Query");
                            ClosedConnection(cmmd, connection);
                            throw temporalException;
                        }
                    }
                }

            }
            else
            {
                result = (DataTable)Architect.Utilities.Cache.GetItem(key);
            }
            if (Handlers.UtilityHandler.AppSettingsCheck("Architect.DataFactory.Trace.Enabled"))
            {
                watch.Stop();

                Log.TraceLog("DataAccessLayer",
                    Handlers.UtilityHandler.MakeCommandSummary(cmmd) +
                    $"  {result.Rows.Count} Rows in {watch.ElapsedMilliseconds} ms{((database.IsCaching ? " (Cache)" : ""))}\n", "datafactory");
            }
            return result;
        }

        /// <summary>
        /// Métodos para ejecutar queries en base de datos, con sobrecarga del connections
        /// </summary>
        /// <param name="command">Objeto commandos que se desea ejecutar</param>
        /// <param name="connection">Instancia del objeto connections</param>
        /// <returns></returns>
        private void ExecuteQueryWithDataReader(Database database, IDbConnection connection, Action<IDataReader> callBack, string CommandType = "Select", bool manyRows = true)
        {
            string key = string.Empty;

            Stopwatch watch = null;
            int rows = 0;

            OracleCommand cmmd = new OracleCommand(Statement, (OracleConnection)connection);

            if (database.IsCaching)
            {
                key = string.Format("{1}.{0}", Handlers.UtilityHandler.GetMd5Hash(database.ConnectionStringName, Statement, database.Parameters), database.CachePrefix);
            }
            if (!database.IsCaching || Utilities.Cache.NotExist(key))
            {
                for (int attempts = 1; attempts <= 3; attempts++)
                {
                    try
                    {
                        if (CommandType.Equals("Procedure"))
                        {
                            cmmd.CommandType = System.Data.CommandType.StoredProcedure;
                        }
                        if (Parameters?.Count > 0)
                        {
                            bool haveRefCursor = false;
                            foreach (var item in Parameters)
                            {
                                OracleParameter parameter;
                                if (item.Type == Enumerations.DbType.StringArray)
                                {
                                    parameter = new OracleParameter(item.Name, OracleDbType.Varchar2);

                                    parameter.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                                    parameter.Size = 1;
                                    parameter.ArrayBindSize = new int[1] { 517 };
                                    parameter.ArrayBindStatus = new OracleParameterStatus[1] { OracleParameterStatus.Success };


                                }
                                else
                                {
                                    parameter = new OracleParameter(item.Name, DBParameterTypeConvert(item), item.Size, DBParameterValueConvert(item.Value), DBParameterDirectionConvert(item));
                                }
                                cmmd.Parameters.Add(parameter);
                                if (item.Type == Enumerations.DbType.RefCursor)
                                {
                                    haveRefCursor = true;
                                }

                            }

                            if (CommandType.Equals("Procedure") && !haveRefCursor)
                            {
                                cmmd.Parameters.Add(new OracleParameter("RC1", OracleDbType.RefCursor, ParameterDirection.Output));
                            }
                        }
                        if (Handlers.UtilityHandler.AppSettingsCheck("Architect.DataFactory.Trace.Enabled"))
                        {
                            watch = new Stopwatch();
                            watch.Start();
                        }
                        using (var reader = cmmd.ExecuteReader())
                        {
                            if (Handlers.UtilityHandler.AppSettingsCheck("Architect.DataFactory.Trace.Enabled"))
                            {
                                watch.Stop();
                            }
                            if (database.IsCaching)
                            {
                                DataTable result = new DataTable();
                                result.Load(reader);
                                Architect.Utilities.Cache.SetItem(key, result, database.CacheExpiration);
                                if (result.Rows.Count > 0)
                                {
                                    DataTableReader read = result.CreateDataReader();
                                    while (read.Read())
                                    {
                                        callBack.DynamicInvoke(read);
                                        if (!manyRows)
                                        {
                                            break;
                                        }
                                    }
                                    rows = result.Rows.Count;
                                }
                            }
                            else
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        callBack.DynamicInvoke(reader);
                                        rows++;
                                        if (!manyRows)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                            reader.Close();
                        }
                        break;
                    }
                    catch (OracleException exOracle)
                    {
                        if ((exOracle.Message.StartsWith("ORA-03135:") ||
                             exOracle.Message.StartsWith("ORA-03113:") ||
                             exOracle.Message.IndexOf("End-of-file on communication channel", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                             exOracle.Message.IndexOf("fin de archivo en el canal de comunicación", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                             exOracle.Message.IndexOf("TNS:packet writer failure", StringComparison.CurrentCultureIgnoreCase) > -1) && attempts < 3)
                        {
                            MethodInfo magicMethod = connection.GetType().GetMethod("ClearAllPools");
                            for (int connectAttempts = 1; connectAttempts <= 3; connectAttempts++)
                            {
                                cmmd.Connection = null;
                                if (connection.State == ConnectionState.Open)
                                    connection.Close();

                                if (magicMethod.IsNotEmpty())
                                    magicMethod.Invoke(connection, new Object[] { });

                                Log.WarningLog("DataAccessLayer", String.Format("Retry due to disconnection for query on table '{2}' ({0}/{3}). {1}", attempts, exOracle.Message, string.Empty, connectAttempts), "datafactory");
                                Thread.Sleep(1000);

                                try
                                {
                                    connection.Open();
                                    break;
                                }
                                catch (Exception ex2)
                                {
                                    if (connectAttempts >= 3)
                                    {
                                        var temporalException = Exceptions.DataAccessException.Factory(ex2, cmmd, string.Empty, "Query");
                                        ClosedConnection(cmmd, connection);
                                        throw temporalException;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Exception temporalException = Exceptions.DataAccessException.Factory(exOracle, cmmd, string.Empty, "Query");
                            ClosedConnection(cmmd, connection);
                            throw temporalException;
                        }
                    }
                    catch (Exception ex)
                    {
                        Exception temporalException;
                        if ((ex.Message.StartsWith("ORA-03135:") || ex.Message.StartsWith("ORA-03113:") || ex.Message.IndexOf("End-of-file on communication channel", StringComparison.CurrentCultureIgnoreCase) > -1 || ex.Message.IndexOf("fin de archivo en el canal de comunicación", StringComparison.CurrentCultureIgnoreCase) > -1 || ex.Message.IndexOf("TNS:packet writer failure", StringComparison.CurrentCultureIgnoreCase) > -1) && attempts < 3)
                        {
                            MethodInfo magicMethod = connection.GetType().GetMethod("ClearAllPools");
                            if (magicMethod.IsNotEmpty())
                                magicMethod.Invoke(connection, new Object[] { });
                            Log.WarningLog("DataAccessLayer", String.Format("Retry due to disconnection for '{3}' command on table '{2}' ({0}). {1}", attempts, ex.Message, string.Empty, "Query"), "datafactory");

                            Thread.Sleep(500);

                            try
                            {
                                connection.Open();
                            }
                            catch (Exception)
                            {
                                temporalException = Exceptions.DataAccessException.Factory(ex, cmmd, string.Empty, "Query");
                                ClosedConnection(cmmd, connection);
                                throw temporalException;
                            }
                        }
                        else
                        {
                            temporalException = Exceptions.DataAccessException.Factory(ex, cmmd, string.Empty, "Query");
                            ClosedConnection(cmmd, connection);
                            throw temporalException;
                        }
                    }
                }
                if (Handlers.UtilityHandler.AppSettingsCheck("Architect.DataFactory.Trace.Enabled"))
                {
                    Log.TraceLog("DataAccessLayer",
                       Handlers.UtilityHandler.MakeCommandSummary(cmmd) +
                       String.Format("  {0} Rows in {1} ms{2}\n", rows, watch.ElapsedMilliseconds, (database.IsCaching ? " (Cache)" : "")), "datafactory");
                }
            }
            else
            {
                DataTable result = (DataTable)Architect.Utilities.Cache.GetItem(key);
                var reader = result.CreateDataReader();
                while (reader.Read())
                {
                    callBack.DynamicInvoke(reader);
                }
            }
        }

        /// <summary>
        /// Métodos para ejecutar queries en base de datos, con sobrecarga del connections
        /// </summary>
        /// <param name="command">Objeto commandos que se desea ejecutar</param>
        /// <param name="connection">Instancia del objeto connections</param>
        /// <returns></returns>
        private void ExecuteQueryWithDataReader(Database database, IDbConnection connection, Action<IDataReader, string> callBack, string CommandType = "Select", bool manyRows = true)
        {
            string key = string.Empty;

            Stopwatch watch = null;
            int rows = 0;

            OracleCommand cmmd = new OracleCommand(Statement, (OracleConnection)connection);

            if (database.IsCaching)
            {
                key = string.Format("{1}.{0}", Architect.DataFactory.Handlers.UtilityHandler.GetMd5Hash(database.ConnectionStringName, Statement, database.Parameters), database.CachePrefix);
            }
            if (!database.IsCaching || Architect.Utilities.Cache.NotExist(key))
            {
                for (int attempts = 1; attempts <= 3; attempts++)
                {
                    try
                    {
                        if (CommandType.Equals("Procedure"))
                        {
                            cmmd.CommandType = System.Data.CommandType.StoredProcedure;
                        }
                        if (Parameters?.Count > 0)
                        {
                            bool haveRefCursor = false;
                            foreach (var item in Parameters)
                            {
                                OracleParameter parameter;
                                if (item.Type == Enumerations.DbType.StringArray)
                                {
                                    parameter = new OracleParameter(item.Name, OracleDbType.Varchar2);

                                    parameter.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                                    parameter.Size = 1;
                                    parameter.ArrayBindSize = new int[1] { 517 };
                                    parameter.ArrayBindStatus = new OracleParameterStatus[1] { OracleParameterStatus.Success };


                                }
                                else
                                {
                                    parameter = new OracleParameter(item.Name, DBParameterTypeConvert(item), item.Size, DBParameterValueConvert(item.Value), DBParameterDirectionConvert(item));
                                }
                                cmmd.Parameters.Add(parameter);
                                if (item.Type == Enumerations.DbType.RefCursor)
                                {
                                    haveRefCursor = true;
                                }

                            }

                            if (CommandType.Equals("Procedure") && !haveRefCursor)
                            {
                                cmmd.Parameters.Add(new OracleParameter("RC1", OracleDbType.RefCursor, ParameterDirection.Output));
                            }
                        }
                        if (Handlers.UtilityHandler.AppSettingsCheck("Architect.DataFactory.Trace.Enabled"))
                        {
                            watch = new Stopwatch();
                            watch.Start();
                        }
                        using (var reader = cmmd.ExecuteReader())
                        {
                            if (Handlers.UtilityHandler.AppSettingsCheck("Architect.DataFactory.Trace.Enabled"))
                            {
                                watch.Stop();
                            }
                            if (database.IsCaching)
                            {
                                DataTable result = new DataTable();
                                result.Load(reader);
                                Architect.Utilities.Cache.SetItem(key, result, database.CacheExpiration);
                                if (result.Rows.Count > 0)
                                {
                                    DataTableReader read = result.CreateDataReader();
                                    while (read.Read())
                                    {
                                        callBack.DynamicInvoke(read);
                                        if (!manyRows)
                                        {
                                            break;
                                        }
                                    }
                                    rows = result.Rows.Count;
                                }
                            }
                            else
                            {
                                var index = 1;
                                var currsors = Parameters.Where(c => c.Type == Enumerations.DbType.RefCursor && c.direction == ParameterDirection.Output).ToList<Architect.DataFactory.Contracts.Parameter>();

                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        callBack.DynamicInvoke(reader, currsors.FirstOrDefault().Name);
                                        rows++;
                                        if (!manyRows)
                                        {
                                            break;
                                        }
                                    }
                                }
                                while (reader.NextResult())
                                {
                                    while (reader.Read())
                                    {
                                        callBack.DynamicInvoke(reader, currsors[index].Name);
                                        rows++;
                                    }
                                    index++;
                                }
                            }
                            reader.Close();
                        }
                        break;
                    }
                    catch (OracleException exOracle)
                    {
                        if ((exOracle.Message.StartsWith("ORA-03135:") ||
                             exOracle.Message.StartsWith("ORA-03113:") ||
                             exOracle.Message.IndexOf("End-of-file on communication channel", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                             exOracle.Message.IndexOf("fin de archivo en el canal de comunicación", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                             exOracle.Message.IndexOf("TNS:packet writer failure", StringComparison.CurrentCultureIgnoreCase) > -1) && attempts < 3)
                        {
                            MethodInfo magicMethod = connection.GetType().GetMethod("ClearAllPools");
                            for (int connectAttempts = 1; connectAttempts <= 3; connectAttempts++)
                            {
                                cmmd.Connection = null;
                                if (connection.State == ConnectionState.Open)
                                    connection.Close();

                                if (magicMethod.IsNotEmpty())
                                    magicMethod.Invoke(connection, new Object[] { });

                                Log.WarningLog("DataAccessLayer", $"Retry due to disconnection for query on table '{string.Empty}' ({attempts}/{connectAttempts}). {exOracle.Message}", "datafactory");
                                Thread.Sleep(1000);

                                try
                                {
                                    connection.Open();
                                    break;
                                }
                                catch (Exception ex2)
                                {
                                    if (connectAttempts >= 3)
                                    {
                                        var temporalException = Exceptions.DataAccessException.Factory(ex2, cmmd, string.Empty, "Query");
                                        ClosedConnection(cmmd, connection);
                                        throw temporalException;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Exception temporalException = Exceptions.DataAccessException.Factory(exOracle, cmmd, string.Empty, "Query");
                            ClosedConnection(cmmd, connection);
                            throw temporalException;
                        }
                    }
                    catch (Exception ex)
                    {
                        Exception temporalException;
                        if ((ex.Message.StartsWith("ORA-03135:") || ex.Message.StartsWith("ORA-03113:") || ex.Message.IndexOf("End-of-file on communication channel", StringComparison.CurrentCultureIgnoreCase) > -1 || ex.Message.IndexOf("fin de archivo en el canal de comunicación", StringComparison.CurrentCultureIgnoreCase) > -1 || ex.Message.IndexOf("TNS:packet writer failure", StringComparison.CurrentCultureIgnoreCase) > -1) && attempts < 3)
                        {
                            MethodInfo magicMethod = connection.GetType().GetMethod("ClearAllPools");
                            if (magicMethod.IsNotEmpty())
                                magicMethod.Invoke(connection, new Object[] { });
                            Log.WarningLog("DataAccessLayer", String.Format("Retry due to disconnection for '{3}' command on table '{2}' ({0}). {1}", attempts, ex.Message, string.Empty, "Query"), "datafactory");

                            Thread.Sleep(500);

                            try
                            {
                                connection.Open();
                            }
                            catch (Exception)
                            {
                                temporalException = Exceptions.DataAccessException.Factory(ex, cmmd, string.Empty, "Query");
                                ClosedConnection(cmmd, connection);
                                throw temporalException;
                            }
                        }
                        else
                        {
                            temporalException = Exceptions.DataAccessException.Factory(ex, cmmd, string.Empty, "Query");
                            ClosedConnection(cmmd, connection);
                            throw temporalException;
                        }
                    }
                }
                if (Handlers.UtilityHandler.AppSettingsCheck("Architect.DataFactory.Trace.Enabled"))
                {
                    Log.TraceLog("DataAccessLayer",
                       Handlers.UtilityHandler.MakeCommandSummary(cmmd) +
                       $"  {rows} Rows in {watch.ElapsedMilliseconds} ms{(database.IsCaching ? " (Cache)" : "")}\n", "datafactory");
                }
            }
            else
            {
                DataTable result = (DataTable)Architect.Utilities.Cache.GetItem(key);
                var reader = result.CreateDataReader();
                while (reader.Read())
                {
                    callBack.DynamicInvoke(reader);
                }
            }
        }

        private T ExecuteQueryScalar<T>(Database database, IDbConnection connection)
        {
            var key = "";
            Stopwatch watch = null;
            T result = default(T);
            var method = $"ExecuteQueryScalar<{typeof(T).FullName}>";
            if (Handlers.UtilityHandler.AppSettingsCheck("Architect.DataFactory.Trace.Enabled"))
            {
                watch = new Stopwatch();
                watch.Start();
            }
            OracleCommand cmmd = new OracleCommand(Statement, (OracleConnection)connection);

            if (database.IsCaching)
            {
                key = $"{database.CachePrefix}.{Handlers.UtilityHandler.GetMd5Hash(database.ConnectionStringName, Statement, database.Parameters)}";
            }
            if (Parameters?.Count > 0)
            {
                foreach (var item in Parameters)
                {
                    OracleParameter parameter = new OracleParameter(item.Name, DBParameterTypeConvert(item), item.Size, item.Value, DBParameterDirectionConvert(item));
                    if (item.Type == Enumerations.DbType.StringArray)
                    {
                        parameter.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    }
                    cmmd.Parameters.Add(parameter);
                }
            }

            if (!database.IsCaching || Architect.Utilities.Cache.NotExist(key))
            {
                for (int attempts = 1; attempts <= 3; attempts++)
                {
                    try
                    {



                        result = (T)cmmd.ExecuteScalar();

                        if (Handlers.UtilityHandler.AppSettingsCheck("Architect.DataFactory.Trace.Enabled"))
                        {
                            watch.Stop();
                        }
                        if (database.IsCaching)
                        {
                            Architect.Utilities.Cache.SetItem(key, result, database.CacheExpiration);
                        }
                        break;
                    }
                    catch (OracleException exOracle)
                    {
                        if ((exOracle.Message.StartsWith("ORA-03135:") ||
                             exOracle.Message.StartsWith("ORA-03113:") ||
                             exOracle.Message.IndexOf("End-of-file on communication channel", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                             exOracle.Message.IndexOf("fin de archivo en el canal de comunicación", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                             exOracle.Message.IndexOf("TNS:packet writer failure", StringComparison.CurrentCultureIgnoreCase) > -1) && attempts < 3)
                        {
                            MethodInfo magicMethod = connection.GetType().GetMethod("ClearAllPools");
                            for (int connectAttempts = 1; connectAttempts <= 3; connectAttempts++)
                            {
                                cmmd.Connection = null;
                                if (connection.State == ConnectionState.Open)
                                    connection.Close();

                                if (magicMethod.IsNotEmpty())
                                    magicMethod.Invoke(connection, new Object[] { });

                                Log.WarningLog("DataAccessLayer", String.Format("Retry due to disconnection for query on table '{2}' ({0}/{3}). {1}", attempts, exOracle.Message, method, connectAttempts), "datafactory");
                                Thread.Sleep(1000);

                                try
                                {
                                    connection.Open();
                                    break;
                                }
                                catch (Exception ex2)
                                {
                                    if (connectAttempts >= 3)
                                    {
                                        var temporalException = Exceptions.DataAccessException.Factory(ex2, cmmd, method, method);
                                        ClosedConnection(cmmd, connection);
                                        throw temporalException;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Exception temporalException = Exceptions.DataAccessException.Factory(exOracle, cmmd, string.Empty, "Query");
                            ClosedConnection(cmmd, connection);
                            throw temporalException;
                        }
                    }
                    catch (Exception ex)
                    {
                        Exception temporalException;
                        if ((ex.Message.StartsWith("ORA-03135:") || ex.Message.StartsWith("ORA-03113:") || ex.Message.IndexOf("End-of-file on communication channel", StringComparison.CurrentCultureIgnoreCase) > -1 || ex.Message.IndexOf("fin de archivo en el canal de comunicación", StringComparison.CurrentCultureIgnoreCase) > -1 || ex.Message.IndexOf("TNS:packet writer failure", StringComparison.CurrentCultureIgnoreCase) > -1) && attempts < 3)
                        {
                            MethodInfo magicMethod = connection.GetType().GetMethod("ClearAllPools");
                            if (magicMethod.IsNotEmpty())
                                magicMethod.Invoke(connection, new Object[] { });
                            Log.WarningLog("DataAccessLayer", String.Format("Retry due to disconnection for '{3}' command on table '{2}' ({0}). {1}", attempts, ex.Message, method, method), "datafactory");

                            Thread.Sleep(500);

                            try
                            {
                                connection.Open();
                            }
                            catch (Exception ex2)
                            {
                                temporalException = Exceptions.DataAccessException.Factory(ex2, cmmd, method, method);
                                ClosedConnection(cmmd, connection);
                                throw temporalException;
                            }
                        }
                        else
                        {
                            temporalException = Exceptions.DataAccessException.Factory(ex, cmmd, method, method);
                            ClosedConnection(cmmd, connection);
                            throw temporalException;
                        }
                    }
                }


            }
            else
            {
                result = (T)Architect.Utilities.Cache.GetItem(key);
            }
            if (Handlers.UtilityHandler.AppSettingsCheck("Architect.DataFactory.Trace.Enabled"))
            {
                Log.TraceLog("DataAccessLayer",
                    $"{Handlers.UtilityHandler.MakeCommandSummary(cmmd)}{(string.Format("  Result {0} in {1} ms{2}\n", result, watch.ElapsedMilliseconds, database.IsCaching ? " (Cache)" : ""))}", "datafactory");
            }
            return result;
        }

        #endregion Method Private

        #region Native Method

        /// <summary>
        /// Permite crear una instancia de conexión en base a el connectionStrngName
        /// </summary>
        /// <param name="connectionStringName">Nombre de la OracleConnection a crear y buscar</param>
        /// <param name="OpenConnection">Si desea hacer la apertura de la conexión de una vez</param>
        /// <returns></returns>
        public static IDbConnection OpenConnection(string connectionStringName)
        {
            OracleConnection con = new OracleConnection();
            if (System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName] == null)
            {
                throw new Exception(String.Format("the ConnectionStringName '{0}' does not exist !!", connectionStringName));
            }
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;

            con.Open();
            if (con.State == ConnectionState.Open)
            {
                con.ClientId = "Aliados";
                con.ClientInfo = "Aliados";
                con.ModuleName = "Aliados";
            }

            return con;
        }
        public static void Bulk(string connectionStringName, string destinationTableName, DataTable data)
        {

            using (OracleBulkCopy bulk = new OracleBulkCopy(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
            {
                bulk.DestinationTableName = destinationTableName;
                bulk.WriteToServer(data);
                bulk.Close();
            }
        }

        public static void ClosedConnection(DbCommand command, IDbConnection currentConnection)
        {
            if (command != null)
                command.Connection = null;
            if (currentConnection.State == ConnectionState.Open)
                currentConnection.Close();
        }

        public static string FilterFactory(string filter, string prefix)
        {
            string result = filter.Substring(1);

            if (prefix.IsNotEmpty())
            {
                result = prefix + "." + result;
            }
            result = result.Replace(".in.", " IN ");
            result = result.Replace(".eq.", " = ");
            result = result.Replace(".neq.", " <> ");
            result = result.Replace(".gt.", " > ");
            result = result.Replace(".gte.", " >= ");
            result = result.Replace(".lt.", " = ");
            result = result.Replace(".lte.", " = ");
            result = result.Replace(".like.", " LIKE ");
            result = result.Replace(".and.", " AND ");
            result = result.Replace(".or.", " OR ");
            result = result.Replace(".not.", " NOT ");

            return " AND " + result;
        }

        #endregion Native Method

        #region Implements

        public void Dispose()
        {
            Statement = null;
            Parameters = null;
            StatementType = null;
        }

        #endregion Implements


    }
}