using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.ManualPolicies
{
    /// <summary>
    /// .
    /// </summary>
    public sealed partial class Certificate
    {

        /// <summary>
        /// Crea un registro en la tabla Certificate.
        /// </summary>
        /// <param name="certificateItem">Instancia de Certificate</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Insurance.Contracts.ManualPolicies.Certificate certificateItem, IDbConnection connection = null)
        {
            if (certificateItem.UpdateDate.IsEmpty())
            {
                certificateItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO Certificate (Id, CompanyId, PolicyInternalId, CertificateId, IssueDate, EffectiveDate, EndingDate, InsuredAmount, FuneralExpenses, CustomData, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :PolicyInternalId, :CertificateId, :IssueDate, :EffectiveDate, :EndingDate, :InsuredAmount, :FuneralExpenses, :CustomData, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, certificateItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, certificateItem.CompanyId)
                            .AddParameter("PolicyInternalId", DbType.Decimal, 9, certificateItem.PolicyInternalId)
                            .AddParameter("CertificateId", DbType.AnsiString, 19, certificateItem.CertificateId)
                            .AddParameter("IssueDate", DbType.DateTime, 9, certificateItem.IssueDate)
                            .AddParameter("EffectiveDate", DbType.DateTime, 9, certificateItem.EffectiveDate)
                            .AddParameter("EndingDate", DbType.DateTime, 9, certificateItem.EndingDate)
                            .AddParameter("InsuredAmount", DbType.Decimal, 18, certificateItem.InsuredAmount)
                            .AddParameter("FuneralExpenses", DbType.Decimal, 18, certificateItem.FuneralExpenses)
                            .AddParameter("CustomData", DbType.AnsiString, 2000, certificateItem.CustomData)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, certificateItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, certificateItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla Certificate.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="certificateItems">Lista de instancia de Certificate</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Insurance.Contracts.ManualPolicies.Certificate> certificateItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.ManualPolicies.Certificate item in certificateItems)
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
        /// Recupera un registro en la tabla Certificate por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la póliza.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Certificate</returns>
        public static Architect.API.Insurance.Contracts.ManualPolicies.Certificate Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Insurance.Contracts.ManualPolicies.Certificate result = null;
            Database.Select("SELECT Id, Certificate.CompanyId, PolicyInternalId, CertificateId, IssueDate, EffectiveDate, EndingDate, InsuredAmount, FuneralExpenses, Certificate.CustomData, Certificate.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Certificate.UpdateDate " +
                              "FROM Certificate LEFT JOIN UserMember um ON um.UserId = Certificate.UpdateUserCode " +
                             "WHERE Certificate.Id=:Id AND Certificate.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToCertificate(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Certificate.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Certificate</returns>
        public static List<Architect.API.Insurance.Contracts.ManualPolicies.Certificate> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Insurance.Contracts.ManualPolicies.Certificate> result = new List<Architect.API.Insurance.Contracts.ManualPolicies.Certificate>();
            Database.Select("SELECT Id, Certificate.CompanyId, PolicyInternalId, CertificateId, IssueDate, EffectiveDate, EndingDate, InsuredAmount, FuneralExpenses, Certificate.CustomData, Certificate.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Certificate.UpdateDate " +
                              "FROM Certificate LEFT JOIN UserMember um ON um.UserId = Certificate.UpdateUserCode " +
                             "WHERE Certificate.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToCertificate(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Certificate.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Certificate</returns>
        public static List<Architect.API.Insurance.Contracts.ManualPolicies.Certificate> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Insurance.Contracts.ManualPolicies.Certificate> result = new List<Architect.API.Insurance.Contracts.ManualPolicies.Certificate>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, Certificate.CompanyId, PolicyInternalId, CertificateId, IssueDate, EffectiveDate, EndingDate, InsuredAmount, FuneralExpenses, Certificate.CustomData, Certificate.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Certificate.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY Certificate.Id DESC) RowNumber " +
                              "FROM Certificate LEFT JOIN UserMember um ON um.UserId = Certificate.UpdateUserCode " +
                             "WHERE Certificate.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToCertificate(reader));
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
        /// Último valor asignado a clave única de la tabla Certificate.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM Certificate")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla Certificate por medio de su clave primaria.
        /// </summary>
        /// <param name="certificateItem">Instancia de Certificate</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Insurance.Contracts.ManualPolicies.Certificate certificateItem, IDbConnection connection = null)
        {
            if (certificateItem.UpdateDate.IsEmpty())
            {
                certificateItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE Certificate " +
                                      "SET CompanyId=:CompanyId, PolicyInternalId=:PolicyInternalId, CertificateId=:CertificateId, IssueDate=:IssueDate, EffectiveDate=:EffectiveDate, EndingDate=:EndingDate, InsuredAmount=:InsuredAmount, FuneralExpenses=:FuneralExpenses, CustomData=:CustomData, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, certificateItem.CompanyId)
                                .AddParameter("PolicyInternalId", DbType.Decimal, 9, certificateItem.PolicyInternalId)
                                .AddParameter("CertificateId", DbType.AnsiString, 19, certificateItem.CertificateId)
                                .AddParameter("IssueDate", DbType.DateTime, 9, certificateItem.IssueDate)
                                .AddParameter("EffectiveDate", DbType.DateTime, 9, certificateItem.EffectiveDate)
                                .AddParameter("EndingDate", DbType.DateTime, 9, certificateItem.EndingDate)
                                .AddParameter("InsuredAmount", DbType.Decimal, 18, certificateItem.InsuredAmount)
                                .AddParameter("FuneralExpenses", DbType.Decimal, 18, certificateItem.FuneralExpenses)
                                .AddParameter("CustomData", DbType.AnsiString, 2000, certificateItem.CustomData)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, certificateItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, certificateItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, certificateItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Certificate por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="certificateItems">Lista de instancia de Certificate</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Insurance.Contracts.ManualPolicies.Certificate> certificateItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.ManualPolicies.Certificate item in certificateItems)
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
        /// Elimina un registro en la tabla Certificate por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la póliza.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM Certificate " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Certificate por medio de su clave primaria.
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
        /// Recupera la cantidad de registros existentes en la tabla Certificate por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la póliza.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Certificate " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Certificate que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Certificate " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'Certificate'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Insurance.Contracts.ManualPolicies.Certificate DataReaderToCertificate(System.Data.IDataReader reader, Architect.API.Insurance.Contracts.ManualPolicies.Certificate item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Insurance.Contracts.ManualPolicies.Certificate();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.PolicyInternalId = reader.IntegerValue("PolicyInternalId");
            item.CertificateId = reader.StringValue("CertificateId");
            item.IssueDate = reader.DateTimeValue("IssueDate");
            item.EffectiveDate = reader.DateTimeValue("EffectiveDate");
            item.EndingDate = reader.DateTimeValue("EndingDate");
            item.InsuredAmount = reader.DoubleValue("InsuredAmount");
            item.FuneralExpenses = reader.DoubleValue("FuneralExpenses");
            item.CustomData = reader.StringValue("CustomData");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

