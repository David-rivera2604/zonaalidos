using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Navegación disponible.
    /// </summary>
    public static partial class Navigation
    {

        /// <summary>
        /// Crea un registro en la tabla Navigation.
        /// </summary>
        /// <param name="navigationItem">Instancia de Navigation</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.Navigation navigationItem, IDbConnection connection = null)
        {
            if (navigationItem.UpdateDate.IsEmpty())
            {
                navigationItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO Navigation (NavigationId, CompanyId, ParentCode, Code, Type, Title, Description, MenuTitle, URLPath, URLHelp, SmallImage, BigImage, Sequence, RecordStatus, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:NavigationId, :CompanyId, :ParentCode, :Code, :Type, :Title, :Description, :MenuTitle, :URLPath, :URLHelp, :SmallImage, :BigImage, :Sequence, :RecordStatus, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("NavigationId", DbType.Decimal, 9, navigationItem.NavigationId)
                            .AddParameter("CompanyId", DbType.Decimal, 5, navigationItem.CompanyId)
                            .AddParameter("ParentCode", DbType.AnsiStringFixedLength, 8, navigationItem.ParentCode)
                            .AddParameter("Code", DbType.AnsiStringFixedLength, 8, navigationItem.Code)
                            .AddParameter("Type", DbType.Decimal, 5, navigationItem.Type)
                            .AddParameter("Title", DbType.AnsiString, 120, navigationItem.Title)
                            .AddParameter("Description", DbType.AnsiString, 255, navigationItem.Description)
                            .AddParameter("MenuTitle", DbType.AnsiString, 40, navigationItem.MenuTitle)
                            .AddParameter("URLPath", DbType.AnsiString, 255, navigationItem.URLPath)
                            .AddParameter("URLHelp", DbType.AnsiString, 255, navigationItem.URLHelp)
                            .AddParameter("SmallImage", DbType.AnsiString, 80, navigationItem.SmallImage)
                            .AddParameter("BigImage", DbType.AnsiString, 80, navigationItem.BigImage)
                            .AddParameter("Sequence", DbType.Decimal, 5, navigationItem.Sequence)
                            .AddParameter("RecordStatus", DbType.Decimal, 5, navigationItem.RecordStatus)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, navigationItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, navigationItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla Navigation.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="navigationItems">Lista de instancia de Navigation</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.Navigation> navigationItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.Navigation item in navigationItems)
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
        /// Recupera un registro en la tabla Navigation por medio de su clave primaria.
        /// </summary>
        /// <param name="navigationid">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Navigation</returns>
        public static Architect.API.Core.Contracts.General.Navigation Retrieve(int navigationid, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.Navigation result = null;
            Database.Select("SELECT NavigationId, Navigation.CompanyId, ParentCode, Code, Type, Title, Description, MenuTitle, URLPath, URLHelp, SmallImage, BigImage, Sequence, Navigation.RecordStatus, Navigation.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Navigation.UpdateDate " +
                              "FROM Navigation LEFT JOIN UserMember um ON um.UserId = Navigation.UpdateUserCode " +
                             "WHERE Navigation.NavigationId=:NavigationId AND Navigation.CompanyId=:CompanyId")
                        .AddParameter("NavigationId", DbType.Decimal, 9, navigationid)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToNavigation(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Navigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Navigation</returns>
        public static List<Architect.API.Core.Contracts.General.Navigation> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Navigation> result = new List<Architect.API.Core.Contracts.General.Navigation>();
            Database.Select("SELECT NavigationId, Navigation.CompanyId, ParentCode, Code, Type, Title, Description, MenuTitle, URLPath, URLHelp, SmallImage, BigImage, Sequence, Navigation.RecordStatus, Navigation.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Navigation.UpdateDate " +
                              "FROM Navigation LEFT JOIN UserMember um ON um.UserId = Navigation.UpdateUserCode " +
                             "WHERE Navigation.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToNavigation(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Navigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Navigation</returns>
        public static List<Architect.API.Core.Contracts.General.Navigation> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Navigation> result = new List<Architect.API.Core.Contracts.General.Navigation>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT NavigationId, Navigation.CompanyId, ParentCode, Code, Type, Title, Description, MenuTitle, URLPath, URLHelp, SmallImage, BigImage, Sequence, Navigation.RecordStatus, Navigation.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Navigation.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY Navigation.Sequence ASC) RowNumber " +
                              "FROM Navigation LEFT JOIN UserMember um ON um.UserId = Navigation.UpdateUserCode " +
                             "WHERE Navigation.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToNavigation(reader));
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


            return result;
        }

        /// <summary>
        /// Último valor asignado a clave unica de la tabla Navigation.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(NavigationId),0) " +
                                     "FROM Navigation")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla Navigation por medio de su clave primaria.
        /// </summary>
        /// <param name="navigationItem">Instancia de Navigation</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.Navigation navigationItem, IDbConnection connection = null)
        {
            if (navigationItem.UpdateDate.IsEmpty())
            {
                navigationItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE Navigation " +
                                      "SET CompanyId=:CompanyId, ParentCode=:ParentCode, Code=:Code, Type=:Type, Title=:Title, Description=:Description, MenuTitle=:MenuTitle, URLPath=:URLPath, URLHelp=:URLHelp, SmallImage=:SmallImage, BigImage=:BigImage, Sequence=:Sequence, RecordStatus=:RecordStatus, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE NavigationId=:NavigationId")
                                .AddParameter("CompanyId", DbType.Decimal, 5, navigationItem.CompanyId)
                                .AddParameter("ParentCode", DbType.AnsiStringFixedLength, 8, navigationItem.ParentCode)
                                .AddParameter("Code", DbType.AnsiStringFixedLength, 8, navigationItem.Code)
                                .AddParameter("Type", DbType.Decimal, 5, navigationItem.Type)
                                .AddParameter("Title", DbType.AnsiString, 120, navigationItem.Title)
                                .AddParameter("Description", DbType.AnsiString, 255, navigationItem.Description)
                                .AddParameter("MenuTitle", DbType.AnsiString, 40, navigationItem.MenuTitle)
                                .AddParameter("URLPath", DbType.AnsiString, 255, navigationItem.URLPath)
                                .AddParameter("URLHelp", DbType.AnsiString, 255, navigationItem.URLHelp)
                                .AddParameter("SmallImage", DbType.AnsiString, 80, navigationItem.SmallImage)
                                .AddParameter("BigImage", DbType.AnsiString, 80, navigationItem.BigImage)
                                .AddParameter("Sequence", DbType.Decimal, 5, navigationItem.Sequence)
                                .AddParameter("RecordStatus", DbType.Decimal, 5, navigationItem.RecordStatus)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, navigationItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, navigationItem.UpdateDate)
                                .AddParameter("NavigationId", DbType.Decimal, 9, navigationItem.NavigationId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Navigation por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="navigationItems">Lista de instancia de Navigation</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.Navigation> navigationItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.Navigation item in navigationItems)
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
        /// Elimina un registro en la tabla Navigation por medio de su clave primaria.
        /// </summary>
        /// <param name="navigationid">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int navigationid, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM Navigation " +
                                    "WHERE NavigationId=:NavigationId AND CompanyId=:CompanyId")
                                .AddParameter("NavigationId", DbType.Decimal, 9, navigationid)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Navigation por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="navigationidList">Lista de Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Delete(List<int> navigationidList, int companyId, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (int item in navigationidList)
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
        /// Recupera la cantidad de registros existentes en la tabla Navigation por medio de su clave primaria.
        /// </summary>
        /// <param name="navigationid">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int navigationid, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(NavigationId) " +
                                          "FROM Navigation " +
                                         "WHERE NavigationId=:NavigationId AND CompanyId=:CompanyId")
                               .AddParameter("NavigationId", DbType.Decimal, 9, navigationid)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Navigation que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(NavigationId) " +
                                          "FROM Navigation " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista para selección de la tabla Navigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookUpValue</returns>
        public static List<Utilities.Contracts.LookUpValue> LookUp(int companyId, IDbConnection connection = null)
        {
            List<Utilities.Contracts.LookUpValue> result = new List<Utilities.Contracts.LookUpValue>();
            Database.Select("SELECT NavigationId, Title " +
                              "FROM Navigation WHERE CompanyId=:CompanyId ORDER BY Title")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                            {
                                result.Add(new Utilities.Contracts.LookUpValue()
                                {
                                    Code = reader.StringValue("NavigationId"),
                                    Description = reader.StringValue("Title")
                                });
                            }));
            return result;
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'Navigation'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.Navigation DataReaderToNavigation(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.Navigation item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.Navigation();
            }
            item.NavigationId = reader.IntegerValue("NavigationId");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.ParentCode = reader.StringValue("ParentCode");
            item.Code = reader.StringValue("Code");
            item.Type = reader.IntegerValue("Type");
            item.Title = reader.StringValue("Title");
            item.Description = reader.StringValue("Description");
            item.MenuTitle = reader.StringValue("MenuTitle");
            item.URLPath = reader.StringValue("URLPath");
            item.URLHelp = reader.StringValue("URLHelp");
            item.SmallImage = reader.StringValue("SmallImage");
            item.BigImage = reader.StringValue("BigImage");
            item.Sequence = reader.IntegerValue("Sequence");
            item.RecordStatus = reader.IntegerValue("RecordStatus");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

