using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Visualizaciones de datos en forma de widget, reportes, dashboard. (OJO)
    /// </summary>
    public sealed partial class Visualizations
    {

        /// <summary>
        /// Crea un registro en la tabla Visualizations.
        /// </summary>
        /// <param name="visualizationsItem">Instancia de Visualizations</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.Visualizations visualizationsItem, IDbConnection connection = null)
        {
            if (visualizationsItem.UpdateDate.IsEmpty())
            {
                visualizationsItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO Visualizations (Id, Key, CompanyId, EntityType, Sequence, Type, Caption, Description, StatementType, Statement, Specification, Dialog, Icon, IconClass, ValueFormat, ConnectionName, RecordStatus, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :Key, :CompanyId, :EntityType, :Sequence, :Type, :Caption, :Description, :StatementType, :Statement, :Specification, :Dialog, :Icon, :IconClass, :ValueFormat, :ConnectionName, :RecordStatus, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, visualizationsItem.Id)
                            .AddParameter("Key", DbType.AnsiString, 40, visualizationsItem.Key)
                            .AddParameter("CompanyId", DbType.Decimal, 5, visualizationsItem.CompanyId)
                            .AddParameter("EntityType", DbType.Decimal, 5, visualizationsItem.EntityType)
                            .AddParameter("Sequence", DbType.Decimal, 9, visualizationsItem.Sequence)
                            .AddParameter("Type", DbType.Decimal, 5, visualizationsItem.Type)
                            .AddParameter("Caption", DbType.AnsiString, 120, visualizationsItem.Caption)
                            .AddParameter("Description", DbType.AnsiString, 120, visualizationsItem.Description)
                            .AddParameter("StatementType", DbType.Decimal, 5, visualizationsItem.StatementType)
                            .AddParameter("Statement", DbType.AnsiString, 4000, visualizationsItem.Statement)
                            .AddParameter("Specification", DbType.AnsiString, 4000, visualizationsItem.Specification)
                            .AddParameter("Dialog", DbType.AnsiString, 4000, visualizationsItem.Dialog)
                            .AddParameter("Icon", DbType.AnsiString, 80, visualizationsItem.Icon)
                            .AddParameter("IconClass", DbType.AnsiString, 80, visualizationsItem.IconClass)
                            .AddParameter("ValueFormat", DbType.AnsiString, 80, visualizationsItem.ValueFormat)
                            .AddParameter("ConnectionName", DbType.AnsiString, 80, visualizationsItem.ConnectionName)
                            .AddParameter("RecordStatus", DbType.Decimal, 5, visualizationsItem.RecordStatus)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, visualizationsItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, visualizationsItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla Visualizations.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="visualizationsItems">Lista de instancia de Visualizations</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.Visualizations> visualizationsItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.Visualizations item in visualizationsItems)
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
        /// Recupera un registro en la tabla Visualizations por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Visualizations</returns>
        public static Architect.API.Core.Contracts.General.Visualizations Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.Visualizations result = null;
            Database.Select("SELECT Id, Key, Visualizations.CompanyId, EntityType, Sequence, Type, Caption, Description, StatementType, Statement, Specification, Dialog, Icon, IconClass, ValueFormat, ConnectionName, Visualizations.RecordStatus, Visualizations.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Visualizations.UpdateDate " +
                              "FROM Visualizations LEFT JOIN UserMember um ON um.UserId = Visualizations.UpdateUserCode " +
                             "WHERE Visualizations.Id=:Id AND Visualizations.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToVisualizations(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Visualizations.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Visualizations</returns>
        public static List<Architect.API.Core.Contracts.General.Visualizations> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Visualizations> result = new List<Architect.API.Core.Contracts.General.Visualizations>();
            Database.Select("SELECT Id, Key, Visualizations.CompanyId, EntityType, Sequence, Type, Caption, Description, StatementType, Statement, Specification, Dialog, Icon, IconClass, ValueFormat, ConnectionName, Visualizations.RecordStatus, Visualizations.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Visualizations.UpdateDate " +
                              "FROM Visualizations LEFT JOIN UserMember um ON um.UserId = Visualizations.UpdateUserCode " +
                             "WHERE Visualizations.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToVisualizations(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Visualizations.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Visualizations</returns>
        public static List<Architect.API.Core.Contracts.General.Visualizations> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Visualizations> result = new List<Architect.API.Core.Contracts.General.Visualizations>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, Key, Visualizations.CompanyId, EntityType, Sequence, Type, Caption, Description, StatementType, Statement, Specification, Dialog, Icon, IconClass, ValueFormat, ConnectionName, Visualizations.RecordStatus, Visualizations.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Visualizations.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY Visualizations.Id DESC) RowNumber " +
                              "FROM Visualizations LEFT JOIN UserMember um ON um.UserId = Visualizations.UpdateUserCode " +
                             "WHERE Visualizations.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToVisualizations(reader));
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
        /// Último valor asignado a clave única de la tabla Visualizations.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM Visualizations")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla Visualizations por medio de su clave primaria.
        /// </summary>
        /// <param name="visualizationsItem">Instancia de Visualizations</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.Visualizations visualizationsItem, IDbConnection connection = null)
        {
            if (visualizationsItem.UpdateDate.IsEmpty())
            {
                visualizationsItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE Visualizations " +
                                      "SET Key=:Key, CompanyId=:CompanyId, EntityType=:EntityType, Sequence=:Sequence, Type=:Type, Caption=:Caption, Description=:Description, StatementType=:StatementType, Statement=:Statement, Specification=:Specification, Dialog=:Dialog, Icon=:Icon, IconClass=:IconClass, ValueFormat=:ValueFormat, ConnectionName=:ConnectionName, RecordStatus=:RecordStatus, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("Key", DbType.AnsiString, 40, visualizationsItem.Key)
                                .AddParameter("CompanyId", DbType.Decimal, 5, visualizationsItem.CompanyId)
                                .AddParameter("EntityType", DbType.Decimal, 5, visualizationsItem.EntityType)
                                .AddParameter("Sequence", DbType.Decimal, 9, visualizationsItem.Sequence)
                                .AddParameter("Type", DbType.Decimal, 5, visualizationsItem.Type)
                                .AddParameter("Caption", DbType.AnsiString, 120, visualizationsItem.Caption)
                                .AddParameter("Description", DbType.AnsiString, 120, visualizationsItem.Description)
                                .AddParameter("StatementType", DbType.Decimal, 5, visualizationsItem.StatementType)
                                .AddParameter("Statement", DbType.AnsiString, 4000, visualizationsItem.Statement)
                                .AddParameter("Specification", DbType.AnsiString, 4000, visualizationsItem.Specification)
                                .AddParameter("Dialog", DbType.AnsiString, 4000, visualizationsItem.Dialog)
                                .AddParameter("Icon", DbType.AnsiString, 80, visualizationsItem.Icon)
                                .AddParameter("IconClass", DbType.AnsiString, 80, visualizationsItem.IconClass)
                                .AddParameter("ValueFormat", DbType.AnsiString, 80, visualizationsItem.ValueFormat)
                                .AddParameter("ConnectionName", DbType.AnsiString, 80, visualizationsItem.ConnectionName)
                                .AddParameter("RecordStatus", DbType.Decimal, 5, visualizationsItem.RecordStatus)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, visualizationsItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, visualizationsItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, visualizationsItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Visualizations por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="visualizationsItems">Lista de instancia de Visualizations</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.Visualizations> visualizationsItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.Visualizations item in visualizationsItems)
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
        /// Elimina un registro en la tabla Visualizations por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM Visualizations " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Visualizations por medio de su clave primaria.
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
        /// Recupera la cantidad de registros existentes en la tabla Visualizations por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Visualizations " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Visualizations que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Visualizations " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista para selección de la tabla Visualizations.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookUpValue</returns>
        public static List<Utilities.Contracts.LookUpValue> LookUp(int companyId, IDbConnection connection = null)
        {
            List<Utilities.Contracts.LookUpValue> result = new List<Utilities.Contracts.LookUpValue>();
            Database.Select("SELECT Id, Caption " +
                              "FROM Visualizations WHERE CompanyId=:CompanyId ORDER BY Caption")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Utilities.Contracts.LookUpValue()
                            {
                                Code = reader.StringValue("Id"),
                                Description = reader.StringValue("Caption")
                            });
                        }));
            return result;
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'Visualizations'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.Visualizations DataReaderToVisualizations(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.Visualizations item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.Visualizations();
            }
            item.Id = reader.IntegerValue("Id");
            item.Key = reader.StringValue("Key");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.EntityType = reader.IntegerValue("EntityType");
            item.Sequence = reader.IntegerValue("Sequence");
            item.Type = reader.IntegerValue("Type");
            item.Caption = reader.StringValue("Caption");
            item.Description = reader.StringValue("Description");
            item.StatementType = reader.IntegerValue("StatementType");
            item.Statement = reader.StringValue("Statement");
            item.Specification = reader.StringValue("Specification");
            item.Dialog = reader.StringValue("Dialog");
            item.Icon = reader.StringValue("Icon");
            item.IconClass = reader.StringValue("IconClass");
            item.ValueFormat = reader.StringValue("ValueFormat");
            item.ConnectionName = reader.StringValue("ConnectionName");
            item.RecordStatus = reader.IntegerValue("RecordStatus");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

