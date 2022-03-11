using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Lista de valores disponibles.
    /// </summary>
    public sealed partial class Lookup
    {

        /// <summary>
        /// Crea un registro en la tabla Lookup.
        /// </summary>
        /// <param name="lookupItem">Instancia de Lookup</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.Lookup lookupItem, IDbConnection connection = null)
        {
            if (lookupItem.UpdateDate.IsEmpty())
            {
                lookupItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO Lookup (LookupId, CompanyId, Language, ParentLookupId, SubParentLookupId, Code, Description, QueryOrder, HomologousCode, ExtendNumberValue1, ExtendNumberValue2, ExtendStringValue1, ExtendStringValue2, RecordStatus, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:LookupId, :CompanyId, :Language, :ParentLookupId, :SubParentLookupId, :Code, :Description, :QueryOrder, :HomologousCode, :ExtendNumberValue1, :ExtendNumberValue2, :ExtendStringValue1, :ExtendStringValue2, :RecordStatus, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("LookupId", DbType.Decimal, 9, lookupItem.LookupId)
                            .AddParameter("CompanyId", DbType.Decimal, 5, lookupItem.CompanyId)
                            .AddParameter("Language", DbType.Decimal, 5, lookupItem.Language)
                            .AddParameter("ParentLookupId", DbType.Decimal, 9, lookupItem.ParentLookupId)
                            .AddParameter("SubParentLookupId", DbType.Decimal, 9, lookupItem.SubParentLookupId)
                            .AddParameter("Code", DbType.Decimal, 9, lookupItem.Code)
                            .AddParameter("Description", DbType.AnsiString, 255, lookupItem.Description)
                            .AddParameter("QueryOrder", DbType.Decimal, 5, lookupItem.QueryOrder)
                            .AddParameter("HomologousCode", DbType.AnsiString, 12, lookupItem.HomologousCode)
                            .AddParameter("ExtendNumberValue1", DbType.Decimal, 11, lookupItem.ExtendNumberValue1)
                            .AddParameter("ExtendNumberValue2", DbType.Decimal, 11, lookupItem.ExtendNumberValue2)
                            .AddParameter("ExtendStringValue1", DbType.AnsiString, 30, lookupItem.ExtendStringValue1)
                            .AddParameter("ExtendStringValue2", DbType.AnsiString, 30, lookupItem.ExtendStringValue2)
                            .AddParameter("RecordStatus", DbType.Decimal, 5, lookupItem.RecordStatus)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, lookupItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, lookupItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla Lookup.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="lookupItems">Lista de instancia de Lookup</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.Lookup> lookupItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.Lookup item in lookupItems)
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
        /// Recupera un registro en la tabla Lookup por medio de su clave primaria.
        /// </summary>
        /// <param name="lookupid">LookupId</param>
        /// <param name="companyid">Identificación de la compañía propietaria.</param>
        /// <param name="language">Código lenguaje.</param>
        /// <param name="parentlookupid">Identificación del registro padre para lista con dependencias.</param>
        /// <param name="subparentlookupid">Identificación del registro de según nivel para lista con dependencias.</param>
        /// <param name="code">Código.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Lookup</returns>
        public static Architect.API.Core.Contracts.General.Lookup Retrieve(int lookupid, int companyid, int language, int parentlookupid, int subparentlookupid, int code, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.Lookup result = null;
            Database.Select("SELECT LookupId, Lookup.CompanyId, Language, ParentLookupId, SubParentLookupId, Code, Description, QueryOrder, HomologousCode, ExtendNumberValue1, ExtendNumberValue2, ExtendStringValue1, ExtendStringValue2, Lookup.RecordStatus, Lookup.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Lookup.UpdateDate " +
                              "FROM Lookup LEFT JOIN UserMember um ON um.UserId = Lookup.UpdateUserCode " +
                             "WHERE Lookup.LookupId=:LookupId AND Lookup.CompanyId=:CompanyId AND Lookup.Language=:Language AND Lookup.ParentLookupId=:ParentLookupId AND Lookup.SubParentLookupId=:SubParentLookupId AND Lookup.Code=:Code AND Lookup.CompanyId=:CompanyId")
                        .AddParameter("LookupId", DbType.Decimal, 9, lookupid)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                        .AddParameter("Language", DbType.Decimal, 5, language)
                        .AddParameter("ParentLookupId", DbType.Decimal, 9, parentlookupid)
                        .AddParameter("SubParentLookupId", DbType.Decimal, 9, subparentlookupid)
                        .AddParameter("Code", DbType.Decimal, 9, code)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToLookup(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Lookup.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Lookup</returns>
        public static List<Architect.API.Core.Contracts.General.Lookup> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Lookup> result = new List<Architect.API.Core.Contracts.General.Lookup>();
            Database.Select("SELECT LookupId, Lookup.CompanyId, Language, ParentLookupId, SubParentLookupId, Code, Description, QueryOrder, HomologousCode, ExtendNumberValue1, ExtendNumberValue2, ExtendStringValue1, ExtendStringValue2, Lookup.RecordStatus, Lookup.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Lookup.UpdateDate " +
                              "FROM Lookup LEFT JOIN UserMember um ON um.UserId = Lookup.UpdateUserCode " +
                             "WHERE Lookup.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToLookup(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Lookup.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Lookup</returns>
        public static List<Architect.API.Core.Contracts.General.Lookup> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Lookup> result = new List<Architect.API.Core.Contracts.General.Lookup>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT LookupId, Lookup.CompanyId, Language, ParentLookupId, SubParentLookupId, Code, Description, QueryOrder, HomologousCode, ExtendNumberValue1, ExtendNumberValue2, ExtendStringValue1, ExtendStringValue2, Lookup.RecordStatus, Lookup.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Lookup.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY Lookup.LookupId DESC) RowNumber " +
                              "FROM Lookup LEFT JOIN UserMember um ON um.UserId = Lookup.UpdateUserCode " +
                             "WHERE Lookup.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToLookup(reader));
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
        /// Último valor asignado a clave única de la tabla Lookup.
        /// </summary>
        /// <param name="lookupid"></param>
        /// <param name="companyid"></param>
        /// <param name="language"></param>
        /// <param name="parentlookupid"></param>
        /// <param name="subparentlookupid"></param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(int lookupid, int companyid, int language, int parentlookupid, int subparentlookupid, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Code),0) " +
                                     "FROM Lookup " +
                                    "WHERE LookupId=:LookupId AND CompanyId=:CompanyId AND Language=:Language AND ParentLookupId=:ParentLookupId AND SubParentLookupId=:SubParentLookupId")
                                .AddParameter("LookupId", DbType.Decimal, 9, lookupid)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                                .AddParameter("Language", DbType.Decimal, 5, language)
                                .AddParameter("ParentLookupId", DbType.Decimal, 9, parentlookupid)
                                .AddParameter("SubParentLookupId", DbType.Decimal, 9, subparentlookupid)
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla Lookup por medio de su clave primaria.
        /// </summary>
        /// <param name="lookupItem">Instancia de Lookup</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.Lookup lookupItem, IDbConnection connection = null)
        {
            if (lookupItem.UpdateDate.IsEmpty())
            {
                lookupItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE Lookup " +
                                      "SET Description=:Description, QueryOrder=:QueryOrder, HomologousCode=:HomologousCode, ExtendNumberValue1=:ExtendNumberValue1, ExtendNumberValue2=:ExtendNumberValue2, ExtendStringValue1=:ExtendStringValue1, ExtendStringValue2=:ExtendStringValue2, RecordStatus=:RecordStatus, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE LookupId=:LookupId AND CompanyId=:CompanyId AND Language=:Language AND ParentLookupId=:ParentLookupId AND SubParentLookupId=:SubParentLookupId AND Code=:Code")
                                .AddParameter("Description", DbType.AnsiString, 255, lookupItem.Description)
                                .AddParameter("QueryOrder", DbType.Decimal, 5, lookupItem.QueryOrder)
                                .AddParameter("HomologousCode", DbType.AnsiString, 12, lookupItem.HomologousCode)
                                .AddParameter("ExtendNumberValue1", DbType.Decimal, 11, lookupItem.ExtendNumberValue1)
                                .AddParameter("ExtendNumberValue2", DbType.Decimal, 11, lookupItem.ExtendNumberValue2)
                                .AddParameter("ExtendStringValue1", DbType.AnsiString, 30, lookupItem.ExtendStringValue1)
                                .AddParameter("ExtendStringValue2", DbType.AnsiString, 30, lookupItem.ExtendStringValue2)
                                .AddParameter("RecordStatus", DbType.Decimal, 5, lookupItem.RecordStatus)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, lookupItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, lookupItem.UpdateDate)
                                .AddParameter("LookupId", DbType.Decimal, 9, lookupItem.LookupId)
                                .AddParameter("CompanyId", DbType.Decimal, 5, lookupItem.CompanyId)
                                .AddParameter("Language", DbType.Decimal, 5, lookupItem.Language)
                                .AddParameter("ParentLookupId", DbType.Decimal, 9, lookupItem.ParentLookupId)
                                .AddParameter("SubParentLookupId", DbType.Decimal, 9, lookupItem.SubParentLookupId)
                                .AddParameter("Code", DbType.Decimal, 9, lookupItem.Code)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Lookup por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="lookupItems">Lista de instancia de Lookup</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.Lookup> lookupItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.Lookup item in lookupItems)
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
        /// Elimina un registro en la tabla Lookup por medio de su clave primaria.
        /// </summary>
        /// <param name="lookupid">LookupId</param>
        /// <param name="companyid">Identificación de la compañía propietaria.</param>
        /// <param name="language">Código lenguaje.</param>
        /// <param name="parentlookupid">Identificación del registro padre para lista con dependencias.</param>
        /// <param name="subparentlookupid">Identificación del registro de según nivel para lista con dependencias.</param>
        /// <param name="code">Código.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int lookupid, int companyid, int language, int parentlookupid, int subparentlookupid, int code, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM Lookup " +
                                    "WHERE LookupId=:LookupId AND CompanyId=:CompanyId AND Language=:Language AND ParentLookupId=:ParentLookupId AND SubParentLookupId=:SubParentLookupId AND Code=:Code AND CompanyId=:CompanyId")
                                .AddParameter("LookupId", DbType.Decimal, 9, lookupid)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                                .AddParameter("Language", DbType.Decimal, 5, language)
                                .AddParameter("ParentLookupId", DbType.Decimal, 9, parentlookupid)
                                .AddParameter("SubParentLookupId", DbType.Decimal, 9, subparentlookupid)
                                .AddParameter("Code", DbType.Decimal, 9, code)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Lookup por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="lookupidList">Lista de LookupId</param>
        /// <param name="companyidList">Lista de Identificación de la compañía propietaria.</param>
        /// <param name="languageList">Lista de Código lenguaje.</param>
        /// <param name="parentlookupidList">Lista de Identificación del registro padre para lista con dependencias.</param>
        /// <param name="subparentlookupidList">Lista de Identificación del registro de según nivel para lista con dependencias.</param>
        /// <param name="codeList">Lista de Código.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Delete(List<int> lookupidList, List<int> companyidList, List<int> languageList, List<int> parentlookupidList, List<int> subparentlookupidList, List<int> codeList, int companyId, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (int item in lookupidList)
            {
                result.Add(Delete(item, item, item, item, item, item, companyId, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Lookup por medio de su clave primaria.
        /// </summary>
        /// <param name="lookupid">LookupId</param>
        /// <param name="companyid">Identificación de la compañía propietaria.</param>
        /// <param name="language">Código lenguaje.</param>
        /// <param name="parentlookupid">Identificación del registro padre para lista con dependencias.</param>
        /// <param name="subparentlookupid">Identificación del registro de según nivel para lista con dependencias.</param>
        /// <param name="code">Código.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int lookupid, int companyid, int language, int parentlookupid, int subparentlookupid, int code, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(LookupId) " +
                                          "FROM Lookup " +
                                         "WHERE LookupId=:LookupId AND CompanyId=:CompanyId AND Language=:Language AND ParentLookupId=:ParentLookupId AND SubParentLookupId=:SubParentLookupId AND Code=:Code AND CompanyId=:CompanyId")
                               .AddParameter("LookupId", DbType.Decimal, 9, lookupid)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                               .AddParameter("Language", DbType.Decimal, 5, language)
                               .AddParameter("ParentLookupId", DbType.Decimal, 9, parentlookupid)
                               .AddParameter("SubParentLookupId", DbType.Decimal, 9, subparentlookupid)
                               .AddParameter("Code", DbType.Decimal, 9, code)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Lookup que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(LookupId) " +
                                          "FROM Lookup " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista para selección de la tabla Lookup.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookUpValue</returns>
        public static List<Utilities.Contracts.LookUpValue> LookUp(int companyId, IDbConnection connection = null)
        {
            List<Utilities.Contracts.LookUpValue> result = new List<Utilities.Contracts.LookUpValue>();
            Database.Select("SELECT LookupId, Description " +
                              "FROM Lookup WHERE CompanyId=:CompanyId ORDER BY Description")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Utilities.Contracts.LookUpValue()
                            {
                                Code = reader.StringValue("LookupId"),
                                Description = reader.StringValue("Description")
                            });
                        }));
            return result;
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'Lookup'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.Lookup DataReaderToLookup(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.Lookup item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.Lookup();
            }
            item.LookupId = reader.IntegerValue("LookupId");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.Language = reader.IntegerValue("Language");
            item.ParentLookupId = reader.IntegerValue("ParentLookupId");
            item.SubParentLookupId = reader.IntegerValue("SubParentLookupId");
            item.Code = reader.IntegerValue("Code");
            item.Description = reader.StringValue("Description");
            item.QueryOrder = reader.IntegerValue("QueryOrder");
            item.HomologousCode = reader.StringValue("HomologousCode");
            item.ExtendNumberValue1 = reader.DoubleValue("ExtendNumberValue1");
            item.ExtendNumberValue2 = reader.DoubleValue("ExtendNumberValue2");
            item.ExtendStringValue1 = reader.StringValue("ExtendStringValue1");
            item.ExtendStringValue2 = reader.StringValue("ExtendStringValue2");
            item.RecordStatus = reader.IntegerValue("RecordStatus");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

