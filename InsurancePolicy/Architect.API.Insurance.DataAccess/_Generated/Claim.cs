using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.ManualClaims
{
    /// <summary>
    /// .
    /// </summary>
    public sealed partial class Claim
    {

        /// <summary>
        /// Crea un registro en la tabla Claim.
        /// </summary>
        /// <param name="claimItem">Instancia de Claim</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Insurance.Contracts.ManualClaims.Claim claimItem, IDbConnection connection = null)
        {
            if (claimItem.UpdateDate.IsEmpty())
            {
                claimItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO Claim (Id, CompanyId, ClaimId, StatementDate, OccurrenceDate, ReserveAmount, PaidAmount, PaidDate, DeclinedDate, IncidentDetail, PolicyInternalId, CertificatInternalId, CoverageInternalId, AssociateIsTheInsured, DisabilityDate, Disputability, Status, CustomData, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :ClaimId, :StatementDate, :OccurrenceDate, :ReserveAmount, :PaidAmount, :PaidDate, :DeclinedDate, :IncidentDetail, :PolicyInternalId, :CertificatInternalId, :CoverageInternalId, :AssociateIsTheInsured, :DisabilityDate, :Disputability, :Status, :CustomData, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, claimItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, claimItem.CompanyId)
                            .AddParameter("ClaimId", DbType.AnsiString, 19, claimItem.ClaimId)
                            .AddParameter("StatementDate", DbType.DateTime, 9, claimItem.StatementDate)
                            .AddParameter("OccurrenceDate", DbType.DateTime, 9, claimItem.OccurrenceDate)
                            .AddParameter("ReserveAmount", DbType.Decimal, 18, claimItem.ReserveAmount)
                            .AddParameter("PaidAmount", DbType.Decimal, 18, claimItem.PaidAmount)
                            .AddParameter("PaidDate", DbType.DateTime, 9, claimItem.PaidDate)
                            .AddParameter("DeclinedDate", DbType.DateTime, 9, claimItem.DeclinedDate)
                            .AddParameter("IncidentDetail", DbType.AnsiString, 4000, claimItem.IncidentDetail)
                            .AddParameter("PolicyInternalId", DbType.Decimal, 9, claimItem.PolicyInternalId)
                            .AddParameter("CertificatInternalId", DbType.Decimal, 9, claimItem.CertificatInternalId)
                            .AddParameter("CoverageInternalId", DbType.Decimal, 9, claimItem.CoverageInternalId)
                            .AddParameter("AssociateIsTheInsured", DbType.Decimal, 1, claimItem.AssociateIsTheInsured ? 1 : 0)
                            .AddParameter("DisabilityDate", DbType.DateTime, 9, claimItem.DisabilityDate)
                            .AddParameter("Disputability", DbType.Decimal, 1, claimItem.Disputability ? 1 : 0)
                            .AddParameter("Status", DbType.Decimal, 5, claimItem.Status)
                            .AddParameter("CustomData", DbType.AnsiString, 2000, claimItem.CustomData)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, claimItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, claimItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla Claim.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="claimItems">Lista de instancia de Claim</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Insurance.Contracts.ManualClaims.Claim> claimItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.ManualClaims.Claim item in claimItems)
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
        /// Recupera un registro en la tabla Claim por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del siniestro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Claim</returns>
        public static Architect.API.Insurance.Contracts.ManualClaims.Claim Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Insurance.Contracts.ManualClaims.Claim result = null;
            Database.Select("SELECT Id, Claim.CompanyId, ClaimId, StatementDate, OccurrenceDate, ReserveAmount, PaidAmount, PaidDate, DeclinedDate, IncidentDetail, PolicyInternalId, CertificatInternalId, CoverageInternalId, AssociateIsTheInsured, DisabilityDate, Disputability, Status, Claim.CustomData, Claim.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Claim.UpdateDate " +
                              "FROM Claim LEFT JOIN UserMember um ON um.UserId = Claim.UpdateUserCode " +
                             "WHERE Claim.Id=:Id AND Claim.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToClaim(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Claim.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Claim</returns>
        public static List<Architect.API.Insurance.Contracts.ManualClaims.Claim> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Insurance.Contracts.ManualClaims.Claim> result = new List<Architect.API.Insurance.Contracts.ManualClaims.Claim>();
            Database.Select("SELECT Id, Claim.CompanyId, ClaimId, StatementDate, OccurrenceDate, ReserveAmount, PaidAmount, PaidDate, DeclinedDate, IncidentDetail, PolicyInternalId, CertificatInternalId, CoverageInternalId, AssociateIsTheInsured, DisabilityDate, Disputability, Status, Claim.CustomData, Claim.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Claim.UpdateDate " +
                              "FROM Claim LEFT JOIN UserMember um ON um.UserId = Claim.UpdateUserCode " +
                             "WHERE Claim.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToClaim(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Claim.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Claim</returns>
        public static List<Architect.API.Insurance.Contracts.ManualClaims.Claim> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Insurance.Contracts.ManualClaims.Claim> result = new List<Architect.API.Insurance.Contracts.ManualClaims.Claim>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, Claim.CompanyId, ClaimId, StatementDate, OccurrenceDate, ReserveAmount, PaidAmount, PaidDate, DeclinedDate, IncidentDetail, PolicyInternalId, CertificatInternalId, CoverageInternalId, AssociateIsTheInsured, DisabilityDate, Disputability, Status, Claim.CustomData, Claim.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Claim.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY Claim.Id DESC) RowNumber " +
                              "FROM Claim LEFT JOIN UserMember um ON um.UserId = Claim.UpdateUserCode " +
                             "WHERE Claim.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToClaim(reader));
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
        /// Último valor asignado a clave única de la tabla Claim.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM Claim")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla Claim por medio de su clave primaria.
        /// </summary>
        /// <param name="claimItem">Instancia de Claim</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Insurance.Contracts.ManualClaims.Claim claimItem, IDbConnection connection = null)
        {
            if (claimItem.UpdateDate.IsEmpty())
            {
                claimItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE Claim " +
                                      "SET CompanyId=:CompanyId, ClaimId=:ClaimId, StatementDate=:StatementDate, OccurrenceDate=:OccurrenceDate, ReserveAmount=:ReserveAmount, PaidAmount=:PaidAmount, PaidDate=:PaidDate, DeclinedDate=:DeclinedDate, IncidentDetail=:IncidentDetail, PolicyInternalId=:PolicyInternalId, CertificatInternalId=:CertificatInternalId, CoverageInternalId=:CoverageInternalId, AssociateIsTheInsured=:AssociateIsTheInsured, DisabilityDate=:DisabilityDate, Disputability=:Disputability, Status=:Status, CustomData=:CustomData, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, claimItem.CompanyId)
                                .AddParameter("ClaimId", DbType.AnsiString, 19, claimItem.ClaimId)
                                .AddParameter("StatementDate", DbType.DateTime, 9, claimItem.StatementDate)
                                .AddParameter("OccurrenceDate", DbType.DateTime, 9, claimItem.OccurrenceDate)
                                .AddParameter("ReserveAmount", DbType.Decimal, 18, claimItem.ReserveAmount)
                                .AddParameter("PaidAmount", DbType.Decimal, 18, claimItem.PaidAmount)
                                .AddParameter("PaidDate", DbType.DateTime, 9, claimItem.PaidDate)
                                .AddParameter("DeclinedDate", DbType.DateTime, 9, claimItem.DeclinedDate)
                                .AddParameter("IncidentDetail", DbType.AnsiString, 4000, claimItem.IncidentDetail)
                                .AddParameter("PolicyInternalId", DbType.Decimal, 9, claimItem.PolicyInternalId)
                                .AddParameter("CertificatInternalId", DbType.Decimal, 9, claimItem.CertificatInternalId)
                                .AddParameter("CoverageInternalId", DbType.Decimal, 9, claimItem.CoverageInternalId)
                                .AddParameter("AssociateIsTheInsured", DbType.Decimal, 1, claimItem.AssociateIsTheInsured ? 1 : 0)
                                .AddParameter("DisabilityDate", DbType.DateTime, 9, claimItem.DisabilityDate)
                                .AddParameter("Disputability", DbType.Decimal, 1, claimItem.Disputability ? 1 : 0)
                                .AddParameter("Status", DbType.Decimal, 5, claimItem.Status)
                                .AddParameter("CustomData", DbType.AnsiString, 2000, claimItem.CustomData)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, claimItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, claimItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, claimItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Claim por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="claimItems">Lista de instancia de Claim</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Insurance.Contracts.ManualClaims.Claim> claimItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.ManualClaims.Claim item in claimItems)
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
        /// Elimina un registro en la tabla Claim por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del siniestro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM Claim " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Claim por medio de su clave primaria.
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
        /// Recupera la cantidad de registros existentes en la tabla Claim por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del siniestro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Claim " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Claim que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Claim " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'Claim'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Insurance.Contracts.ManualClaims.Claim DataReaderToClaim(System.Data.IDataReader reader, Architect.API.Insurance.Contracts.ManualClaims.Claim item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Insurance.Contracts.ManualClaims.Claim();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.ClaimId = reader.StringValue("ClaimId");
            item.StatementDate = reader.DateTimeValue("StatementDate");
            item.OccurrenceDate = reader.DateTimeValue("OccurrenceDate");
            item.ReserveAmount = reader.DoubleValue("ReserveAmount");
            item.PaidAmount = reader.DoubleValue("PaidAmount");
            item.PaidDate = reader.DateTimeValue("PaidDate");
            item.DeclinedDate = reader.DateTimeValue("DeclinedDate");
            item.IncidentDetail = reader.StringValue("IncidentDetail");
            item.PolicyInternalId = reader.IntegerValue("PolicyInternalId");
            item.CertificatInternalId = reader.IntegerValue("CertificatInternalId");
            item.CoverageInternalId = reader.IntegerValue("CoverageInternalId");
            item.AssociateIsTheInsured = reader.IntegerValue("AssociateIsTheInsured") == 1;
            item.DisabilityDate = reader.DateTimeValue("DisabilityDate");
            item.Disputability = reader.IntegerValue("Disputability") == 1;
            item.Status = reader.IntegerValue("Status");
            item.CustomData = reader.StringValue("CustomData");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

