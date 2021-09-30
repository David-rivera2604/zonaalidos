using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Plantillas de comunicación.
    /// </summary>
    public static partial class Template
    {

        /// <summary>
        /// Crea un registro en la tabla Template.
        /// </summary>
        /// <param name="templateItem">Instancia de Template</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.Template templateItem, IDbConnection connection = null)
        {
            if (templateItem.UpdateDate.IsEmpty())
            {
                templateItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO Template (Id, CompanyId, Key, Description, EmailTo, Subject, Body, MasterTemplateId, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :Key, :Description, :EmailTo, :Subject, :Body, :MasterTemplateId, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, templateItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, templateItem.CompanyId)
                            .AddParameter("Key", DbType.AnsiString, 40, templateItem.Key)
                            .AddParameter("Description", DbType.AnsiString, 80, templateItem.Description)
                            .AddParameter("EmailTo", DbType.AnsiString, 256, templateItem.EmailTo)
                            .AddParameter("Subject", DbType.AnsiString, 256, templateItem.Subject)
                            .AddParameter("Body", DbType.AnsiString, 4000, templateItem.Body)
                            .AddParameter("MasterTemplateId", DbType.Decimal, 9, templateItem.MasterTemplateId)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, templateItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, templateItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla Template.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="templateItems">Lista de instancia de Template</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.Template> templateItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.Template item in templateItems)
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
        /// Recupera un registro en la tabla Template por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la plantilla.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Template</returns>
        public static Architect.API.Core.Contracts.General.Template Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.Template result = null;
            Database.Select("SELECT Id, Template.CompanyId, Key, Description, EmailTo, Subject, Body, MasterTemplateId, Template.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Template.UpdateDate " +
                              "FROM Template LEFT JOIN UserMember um ON um.UserId = Template.UpdateUserCode " +
                             "WHERE Template.Id=:Id AND Template.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToTemplate(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Template.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Template</returns>
        public static List<Architect.API.Core.Contracts.General.Template> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Template> result = new List<Architect.API.Core.Contracts.General.Template>();
            Database.Select("SELECT Id, Template.CompanyId, Key, Description, EmailTo, Subject, Body, MasterTemplateId, Template.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Template.UpdateDate " +
                              "FROM Template LEFT JOIN UserMember um ON um.UserId = Template.UpdateUserCode " +
                             "WHERE Template.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToTemplate(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Template.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Template</returns>
        public static List<Architect.API.Core.Contracts.General.Template> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Template> result = new List<Architect.API.Core.Contracts.General.Template>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, Template.CompanyId, Key, Description, EmailTo, Subject, Body, MasterTemplateId, Template.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Template.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY Template.Id DESC) RowNumber " +
                              "FROM Template LEFT JOIN UserMember um ON um.UserId = Template.UpdateUserCode " +
                             "WHERE Template.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToTemplate(reader));
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
        /// Último valor asignado a clave unica de la tabla Template.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM Template")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla Template por medio de su clave primaria.
        /// </summary>
        /// <param name="templateItem">Instancia de Template</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.Template templateItem, IDbConnection connection = null)
        {
            if (templateItem.UpdateDate.IsEmpty())
            {
                templateItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE Template " +
                                      "SET CompanyId=:CompanyId, Key=:Key, Description=:Description, EmailTo=:EmailTo, Subject=:Subject, Body=:Body, MasterTemplateId=:MasterTemplateId, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, templateItem.CompanyId)
                                .AddParameter("Key", DbType.AnsiString, 40, templateItem.Key)
                                .AddParameter("Description", DbType.AnsiString, 80, templateItem.Description)
                                .AddParameter("EmailTo", DbType.AnsiString, 256, templateItem.EmailTo)
                                .AddParameter("Subject", DbType.AnsiString, 256, templateItem.Subject)
                                .AddParameter("Body", DbType.AnsiString, 4000, templateItem.Body)
                                .AddParameter("MasterTemplateId", DbType.Decimal, 9, templateItem.MasterTemplateId)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, templateItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, templateItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, templateItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Template por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="templateItems">Lista de instancia de Template</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.Template> templateItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.Template item in templateItems)
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
        /// Elimina un registro en la tabla Template por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la plantilla.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM Template " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Template por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única de la plantilla.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla Template por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la plantilla.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Template " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Template que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Template " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista para selección de la tabla Template.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookUpValue</returns>
        public static List<Utilities.Contracts.LookUpValue> LookUp(int companyId, IDbConnection connection = null)
        {
            List<Utilities.Contracts.LookUpValue> result = new List<Utilities.Contracts.LookUpValue>();
            Database.Select("SELECT Id, Description " +
                              "FROM Template WHERE CompanyId=:CompanyId ORDER BY Description")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                            {
                                result.Add(new Utilities.Contracts.LookUpValue()
                                {
                                    Code = reader.StringValue("Id"),
                                    Description = reader.StringValue("Description")
                                });
                            }));
            return result;
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'Template'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.Template DataReaderToTemplate(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.Template item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.Template();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.Key = reader.StringValue("Key");
            item.Description = reader.StringValue("Description");
            item.EmailTo = reader.StringValue("EmailTo");
            item.Subject = reader.StringValue("Subject");
            item.Body = reader.StringValue("Body");
            item.MasterTemplateId = reader.IntegerValue("MasterTemplateId");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

