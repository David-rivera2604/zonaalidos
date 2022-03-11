using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.ManualPolicies
{
    /// <summary>
    /// Póliza
    /// </summary>
    public sealed partial class Policy
    {

        /// <summary>
        /// Crea un registro en la tabla Policy.
        /// </summary>
        /// <param name="policyItem">Instancia de Policy</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Insurance.Contracts.ManualPolicies.Policy policyItem, IDbConnection connection = null)
        {
            if (policyItem.UpdateDate.IsEmpty())
            {
                policyItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO Policy (Id, CompanyId, Sector, LineOfBusiness, PolicyID, IssueDate, EffectiveDate, EndingDate, EffectiveOtherPolicyDate, ProducerId, CustomData, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :Sector, :LineOfBusiness, :PolicyID, :IssueDate, :EffectiveDate, :EndingDate, :EffectiveOtherPolicyDate, :ProducerId, :CustomData, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, policyItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, policyItem.CompanyId)
                            .AddParameter("Sector", DbType.Decimal, 5, policyItem.Sector)
                            .AddParameter("LineOfBusiness", DbType.Decimal, 5, policyItem.LineOfBusiness)
                            .AddParameter("PolicyID", DbType.AnsiString, 19, policyItem.PolicyID)
                            .AddParameter("IssueDate", DbType.DateTime, 9, policyItem.IssueDate)
                            .AddParameter("EffectiveDate", DbType.DateTime, 9, policyItem.EffectiveDate)
                            .AddParameter("EndingDate", DbType.DateTime, 9, policyItem.EndingDate)
                            .AddParameter("EffectiveOtherPolicyDate", DbType.DateTime, 9, policyItem.EffectiveOtherPolicyDate)
                            .AddParameter("ProducerId", DbType.Decimal, 9, policyItem.ProducerId)
                            .AddParameter("CustomData", DbType.AnsiString, 2000, policyItem.CustomData)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, policyItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, policyItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla Policy.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="policyItems">Lista de instancia de Policy</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Insurance.Contracts.ManualPolicies.Policy> policyItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.ManualPolicies.Policy item in policyItems)
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
        /// Recupera un registro en la tabla Policy por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la póliza.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Policy</returns>
        public static Architect.API.Insurance.Contracts.ManualPolicies.Policy Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Insurance.Contracts.ManualPolicies.Policy result = null;
            Database.Select("SELECT Id, Policy.CompanyId, Sector, LineOfBusiness, PolicyID, IssueDate, EffectiveDate, EndingDate, EffectiveOtherPolicyDate, ProducerId, Policy.CustomData, Policy.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Policy.UpdateDate " +
                              "FROM Policy LEFT JOIN UserMember um ON um.UserId = Policy.UpdateUserCode " +
                             "WHERE Policy.Id=:Id AND Policy.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToPolicy(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Policy.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Policy</returns>
        public static List<Architect.API.Insurance.Contracts.ManualPolicies.Policy> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Insurance.Contracts.ManualPolicies.Policy> result = new List<Architect.API.Insurance.Contracts.ManualPolicies.Policy>();
            Database.Select("SELECT Id, Policy.CompanyId, Sector, LineOfBusiness, PolicyID, IssueDate, EffectiveDate, EndingDate, EffectiveOtherPolicyDate, ProducerId, Policy.CustomData, Policy.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Policy.UpdateDate " +
                              "FROM Policy LEFT JOIN UserMember um ON um.UserId = Policy.UpdateUserCode " +
                             "WHERE Policy.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToPolicy(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Policy.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Policy</returns>
        public static List<Architect.API.Insurance.Contracts.ManualPolicies.Policy> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Insurance.Contracts.ManualPolicies.Policy> result = new List<Architect.API.Insurance.Contracts.ManualPolicies.Policy>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, Policy.CompanyId, Sector, LineOfBusiness, PolicyID, IssueDate, EffectiveDate, EndingDate, EffectiveOtherPolicyDate, ProducerId, Policy.CustomData, Policy.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Policy.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY Policy.Id DESC) RowNumber " +
                              "FROM Policy LEFT JOIN UserMember um ON um.UserId = Policy.UpdateUserCode " +
                             "WHERE Policy.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToPolicy(reader));
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
        /// Último valor asignado a clave única de la tabla Policy.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM Policy")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla Policy por medio de su clave primaria.
        /// </summary>
        /// <param name="policyItem">Instancia de Policy</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Insurance.Contracts.ManualPolicies.Policy policyItem, IDbConnection connection = null)
        {
            if (policyItem.UpdateDate.IsEmpty())
            {
                policyItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE Policy " +
                                      "SET CompanyId=:CompanyId, Sector=:Sector, LineOfBusiness=:LineOfBusiness, PolicyID=:PolicyID, IssueDate=:IssueDate, EffectiveDate=:EffectiveDate, EndingDate=:EndingDate, EffectiveOtherPolicyDate=:EffectiveOtherPolicyDate, ProducerId=:ProducerId, CustomData=:CustomData, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, policyItem.CompanyId)
                                .AddParameter("Sector", DbType.Decimal, 5, policyItem.Sector)
                                .AddParameter("LineOfBusiness", DbType.Decimal, 5, policyItem.LineOfBusiness)
                                .AddParameter("PolicyID", DbType.AnsiString, 19, policyItem.PolicyID)
                                .AddParameter("IssueDate", DbType.DateTime, 9, policyItem.IssueDate)
                                .AddParameter("EffectiveDate", DbType.DateTime, 9, policyItem.EffectiveDate)
                                .AddParameter("EndingDate", DbType.DateTime, 9, policyItem.EndingDate)
                                .AddParameter("EffectiveOtherPolicyDate", DbType.DateTime, 9, policyItem.EffectiveOtherPolicyDate)
                                .AddParameter("ProducerId", DbType.Decimal, 9, policyItem.ProducerId)
                                .AddParameter("CustomData", DbType.AnsiString, 2000, policyItem.CustomData)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, policyItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, policyItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, policyItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Policy por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="policyItems">Lista de instancia de Policy</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Insurance.Contracts.ManualPolicies.Policy> policyItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.ManualPolicies.Policy item in policyItems)
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
        /// Elimina un registro en la tabla Policy por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la póliza.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM Policy " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Policy por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única de la póliza.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla Policy por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la póliza.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Policy " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Policy que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Policy " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'Policy'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Insurance.Contracts.ManualPolicies.Policy DataReaderToPolicy(System.Data.IDataReader reader, Architect.API.Insurance.Contracts.ManualPolicies.Policy item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Insurance.Contracts.ManualPolicies.Policy();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.Sector = reader.IntegerValue("Sector");
            item.LineOfBusiness = reader.IntegerValue("LineOfBusiness");
            item.PolicyID = reader.StringValue("PolicyID");
            item.IssueDate = reader.DateTimeValue("IssueDate");
            item.EffectiveDate = reader.DateTimeValue("EffectiveDate");
            item.EndingDate = reader.DateTimeValue("EndingDate");
            item.EffectiveOtherPolicyDate = reader.DateTimeValue("EffectiveOtherPolicyDate");
            item.ProducerId = reader.IntegerValue("ProducerId");
            item.CustomData = reader.StringValue("CustomData");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

