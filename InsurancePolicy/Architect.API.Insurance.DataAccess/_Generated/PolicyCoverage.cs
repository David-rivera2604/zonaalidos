using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.ManualPolicies
{
    /// <summary>
    /// Coberturas.
    /// </summary>
    public sealed partial class PolicyCoverage
    {

        /// <summary>
        /// Crea un registro en la tabla PolicyCoverage.
        /// </summary>
        /// <param name="policycoverageItem">Instancia de PolicyCoverage</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage policycoverageItem, IDbConnection connection = null)
        {
            if (policycoverageItem.UpdateDate.IsEmpty())
            {
                policycoverageItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO PolicyCoverage (Id, CompanyId, PolicyInternalId, InsuredAmount, Code, Description, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :PolicyInternalId, :InsuredAmount, :Code, :Description, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, policycoverageItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, policycoverageItem.CompanyId)
                            .AddParameter("PolicyInternalId", DbType.Decimal, 9, policycoverageItem.PolicyInternalId)
                            .AddParameter("InsuredAmount", DbType.Decimal, 18, policycoverageItem.InsuredAmount)
                            .AddParameter("Code", DbType.AnsiString, 12, policycoverageItem.Code)
                            .AddParameter("Description", DbType.AnsiString, 80, policycoverageItem.Description)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, policycoverageItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, policycoverageItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla PolicyCoverage.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="policycoverageItems">Lista de instancia de PolicyCoverage</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage> policycoverageItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage item in policycoverageItems)
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
        /// Recupera un registro en la tabla PolicyCoverage por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del rol.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de PolicyCoverage</returns>
        public static Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage result = null;
            Database.Select("SELECT Id, PolicyCoverage.CompanyId, PolicyInternalId, InsuredAmount, Code, Description, PolicyCoverage.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, PolicyCoverage.UpdateDate " +
                              "FROM PolicyCoverage LEFT JOIN UserMember um ON um.UserId = PolicyCoverage.UpdateUserCode " +
                             "WHERE PolicyCoverage.Id=:Id AND PolicyCoverage.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToPolicyCoverage(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla PolicyCoverage.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de PolicyCoverage</returns>
        public static List<Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage> result = new List<Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage>();
            Database.Select("SELECT Id, PolicyCoverage.CompanyId, PolicyInternalId, InsuredAmount, Code, Description, PolicyCoverage.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, PolicyCoverage.UpdateDate " +
                              "FROM PolicyCoverage LEFT JOIN UserMember um ON um.UserId = PolicyCoverage.UpdateUserCode " +
                             "WHERE PolicyCoverage.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToPolicyCoverage(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla PolicyCoverage.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de PolicyCoverage</returns>
        public static List<Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage> result = new List<Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, PolicyCoverage.CompanyId, PolicyInternalId, InsuredAmount, Code, Description, PolicyCoverage.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, PolicyCoverage.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY PolicyCoverage.Id DESC) RowNumber " +
                              "FROM PolicyCoverage LEFT JOIN UserMember um ON um.UserId = PolicyCoverage.UpdateUserCode " +
                             "WHERE PolicyCoverage.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToPolicyCoverage(reader));
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
        /// Último valor asignado a clave única de la tabla PolicyCoverage.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM PolicyCoverage")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla PolicyCoverage por medio de su clave primaria.
        /// </summary>
        /// <param name="policycoverageItem">Instancia de PolicyCoverage</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage policycoverageItem, IDbConnection connection = null)
        {
            if (policycoverageItem.UpdateDate.IsEmpty())
            {
                policycoverageItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE PolicyCoverage " +
                                      "SET CompanyId=:CompanyId, PolicyInternalId=:PolicyInternalId, InsuredAmount=:InsuredAmount, Code=:Code, Description=:Description, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, policycoverageItem.CompanyId)
                                .AddParameter("PolicyInternalId", DbType.Decimal, 9, policycoverageItem.PolicyInternalId)
                                .AddParameter("InsuredAmount", DbType.Decimal, 18, policycoverageItem.InsuredAmount)
                                .AddParameter("Code", DbType.AnsiString, 12, policycoverageItem.Code)
                                .AddParameter("Description", DbType.AnsiString, 80, policycoverageItem.Description)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, policycoverageItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, policycoverageItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, policycoverageItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla PolicyCoverage por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="policycoverageItems">Lista de instancia de PolicyCoverage</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage> policycoverageItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage item in policycoverageItems)
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
        /// Elimina un registro en la tabla PolicyCoverage por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del rol.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM PolicyCoverage " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla PolicyCoverage por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única del rol.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla PolicyCoverage por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del rol.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM PolicyCoverage " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla PolicyCoverage que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM PolicyCoverage " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'PolicyCoverage'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage DataReaderToPolicyCoverage(System.Data.IDataReader reader, Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.PolicyInternalId = reader.IntegerValue("PolicyInternalId");
            item.InsuredAmount = reader.DoubleValue("InsuredAmount");
            item.Code = reader.StringValue("Code");
            item.Description = reader.StringValue("Description");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

