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
    public sealed partial class CertificateRole
    {

        /// <summary>
        /// Crea un registro en la tabla CertificateRole.
        /// </summary>
        /// <param name="certificateroleItem">Instancia de CertificateRole</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole certificateroleItem, IDbConnection connection = null)
        {
            if (certificateroleItem.UpdateDate.IsEmpty())
            {
                certificateroleItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO CertificateRole (Id, CompanyId, CertificatInternalId, ThirdPartyId, ThirdPartyRole, Relationship, ParticipationRate, CustomData, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :CertificatInternalId, :ThirdPartyId, :ThirdPartyRole, :Relationship, :ParticipationRate, :CustomData, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, certificateroleItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, certificateroleItem.CompanyId)
                            .AddParameter("CertificatInternalId", DbType.Decimal, 9, certificateroleItem.CertificatInternalId)
                            .AddParameter("ThirdPartyId", DbType.Decimal, 9, certificateroleItem.ThirdPartyId)
                            .AddParameter("ThirdPartyRole", DbType.Decimal, 9, certificateroleItem.ThirdPartyRole)
                            .AddParameter("Relationship", DbType.Decimal, 5, certificateroleItem.Relationship)
                            .AddParameter("ParticipationRate", DbType.Decimal, 3, certificateroleItem.ParticipationRate)
                            .AddParameter("CustomData", DbType.AnsiString, 2000, certificateroleItem.CustomData)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, certificateroleItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, certificateroleItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla CertificateRole.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="certificateroleItems">Lista de instancia de CertificateRole</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole> certificateroleItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole item in certificateroleItems)
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
        /// Recupera un registro en la tabla CertificateRole por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del siniestro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de CertificateRole</returns>
        public static Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole result = null;
            Database.Select("SELECT Id, CertificateRole.CompanyId, CertificatInternalId, ThirdPartyId, ThirdPartyRole, Relationship, ParticipationRate, CertificateRole.CustomData, CertificateRole.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, CertificateRole.UpdateDate " +
                              "FROM CertificateRole LEFT JOIN UserMember um ON um.UserId = CertificateRole.UpdateUserCode " +
                             "WHERE CertificateRole.Id=:Id AND CertificateRole.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToCertificateRole(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla CertificateRole.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de CertificateRole</returns>
        public static List<Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole> result = new List<Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole>();
            Database.Select("SELECT Id, CertificateRole.CompanyId, CertificatInternalId, ThirdPartyId, ThirdPartyRole, Relationship, ParticipationRate, CertificateRole.CustomData, CertificateRole.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, CertificateRole.UpdateDate " +
                              "FROM CertificateRole LEFT JOIN UserMember um ON um.UserId = CertificateRole.UpdateUserCode " +
                             "WHERE CertificateRole.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToCertificateRole(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla CertificateRole.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de CertificateRole</returns>
        public static List<Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole> result = new List<Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, CertificateRole.CompanyId, CertificatInternalId, ThirdPartyId, ThirdPartyRole, Relationship, ParticipationRate, CertificateRole.CustomData, CertificateRole.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, CertificateRole.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY CertificateRole.Id DESC) RowNumber " +
                              "FROM CertificateRole LEFT JOIN UserMember um ON um.UserId = CertificateRole.UpdateUserCode " +
                             "WHERE CertificateRole.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToCertificateRole(reader));
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
        /// Último valor asignado a clave única de la tabla CertificateRole.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM CertificateRole")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla CertificateRole por medio de su clave primaria.
        /// </summary>
        /// <param name="certificateroleItem">Instancia de CertificateRole</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole certificateroleItem, IDbConnection connection = null)
        {
            if (certificateroleItem.UpdateDate.IsEmpty())
            {
                certificateroleItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE CertificateRole " +
                                      "SET CompanyId=:CompanyId, CertificatInternalId=:CertificatInternalId, ThirdPartyId=:ThirdPartyId, ThirdPartyRole=:ThirdPartyRole, Relationship=:Relationship, ParticipationRate=:ParticipationRate, CustomData=:CustomData, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, certificateroleItem.CompanyId)
                                .AddParameter("CertificatInternalId", DbType.Decimal, 9, certificateroleItem.CertificatInternalId)
                                .AddParameter("ThirdPartyId", DbType.Decimal, 9, certificateroleItem.ThirdPartyId)
                                .AddParameter("ThirdPartyRole", DbType.Decimal, 9, certificateroleItem.ThirdPartyRole)
                                .AddParameter("Relationship", DbType.Decimal, 5, certificateroleItem.Relationship)
                                .AddParameter("ParticipationRate", DbType.Decimal, 3, certificateroleItem.ParticipationRate)
                                .AddParameter("CustomData", DbType.AnsiString, 2000, certificateroleItem.CustomData)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, certificateroleItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, certificateroleItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, certificateroleItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla CertificateRole por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="certificateroleItems">Lista de instancia de CertificateRole</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole> certificateroleItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole item in certificateroleItems)
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
        /// Elimina un registro en la tabla CertificateRole por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del siniestro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM CertificateRole " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla CertificateRole por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única del siniestro.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla CertificateRole por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del siniestro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM CertificateRole " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla CertificateRole que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM CertificateRole " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'CertificateRole'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole DataReaderToCertificateRole(System.Data.IDataReader reader, Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.CertificatInternalId = reader.IntegerValue("CertificatInternalId");
            item.ThirdPartyId = reader.IntegerValue("ThirdPartyId");
            item.ThirdPartyRole = reader.IntegerValue("ThirdPartyRole");
            item.Relationship = reader.IntegerValue("Relationship");
            item.ParticipationRate = reader.IntegerValue("ParticipationRate");
            item.CustomData = reader.StringValue("CustomData");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

