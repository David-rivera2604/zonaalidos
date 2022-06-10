using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.Policy
{
    public partial class Risk
    {
        public static int RetrieveLastIdByExecutiveUserCode(int companyId, int userId, IDbConnection connection = null)
        {
            return (int)Database.Select(@"SELECT NVL(MAX(Id),0)
                                            FROM Risk
                                           WHERE CompanyId=:CompanyId AND ExecutiveUserCode=:UserId")
                             .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                             .AddParameter("UserId", DbType.Decimal, 5, userId)
                             .QueryScalar<Decimal>(connection, "Research");
        }

        public static int RetrieveLastPolicyId(int companyId, IDbConnection connection = null)
        {
            return (int)Database.Select(@"SELECT NVL(MAX(Policyid),0)
                                            FROM Risk
                                           WHERE CompanyId=:CompanyId")
                            .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                            .QueryScalar<Decimal>(connection, "Research");
        }

        public static string BuildFilter(string filter, int lineOfBusiness, int product, string status)
        {
            string result = string.Empty;

            // Permite filtrar por póliza, identificación, nombre, apellido
            // Email, telefono
            // Permite filtrar por certificado, identificación, número de cuenta
            if (filter.IsNotEmpty())
            {
                if (filter.IsNumeric())
                {
                    result = " AND (P.POLICYID LIKE '%" + filter.ToUpper() + "%' " + "OR REPLACE(A.DOCUMENTNUMBER,'-','') LIKE '%" + filter.ToUpper() + "%' " + "OR A.PHONENUMBER LIKE '%" + filter.ToUpper() + "%') ";
                }
                else
                {
                    result = " AND (UPPER(A.FIRSTNAME) LIKE '%" + filter.ToUpper() + "%' " + "OR UPPER(A.MIDDLENAME) LIKE '%" + filter.ToUpper() + "%' " + "OR UPPER(A.LASTNAME) LIKE '%" + filter.ToUpper() + "%' " + "OR UPPER(A.SECONDLASTNAME) LIKE '%" + filter.ToUpper() + "%' " + "OR A.DOCUMENTNUMBER LIKE '%" + filter.ToUpper() + "%' " + "OR UPPER(A.PRIMARYEMAILADDRESS) LIKE '%" + filter.ToUpper() + "%') ";
                }
            }

            if (lineOfBusiness.IsNotEmpty())
            {
                result += " AND P.LINEOFBUSINESSCODE=" + lineOfBusiness + " ";
            }

            if (product.IsNotEmpty())
            {
                result += " AND P.PRODUCTCODE=" + product + " ";
            }

            if (status.IsNotEmpty())
            {
                result += " AND P.STATUS IN (" + status + ") ";
            }

            return result;
        }

        /// <summary>
        /// Lista de pólizas existen según los criterio definidos en los filtros.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Permite filtrar por póliza o por la identificación, nombre, apellido, teléfono o correo electrónico del asegurado.</param>
        /// <param name="lineOfBusiness">Opción para filtrar por ramo o linea de negocio.</param>
        /// <param name="product">Opción para filtrar por producto vincaulado a un ramo.</param>
        /// <param name="status">Opción para filtrar por multiples esta de las pólizas.</param>
        /// <returns>Lista de pólizas según los criterio definidos en el filtro.</returns>
        public static List<Contracts.Policy.PolicyView> RetrieveView(int companyId, string filter, int lineOfBusiness, int product, string status, IDbConnection connection = null)
        {
            var result = new List<Contracts.Policy.PolicyView>();

            Database.Select(Properties.Resources.Risk_RetrieveView.Replace("@FILTER@", BuildFilter(filter, lineOfBusiness, product, status)))
                       .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                       .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                       {
                           result.Add(DataReaderToPolicyView(reader));
                       }));
            return result;
        }

        public static Contracts.Policy.PolicyView DataReaderToPolicyView(System.Data.IDataReader reader, Contracts.Policy.PolicyView newItem = null)
        {
            newItem = new Contracts.Policy.PolicyView()
            {
                Id = reader.IntegerValue("ID"),
                IssueDate = reader.DateTimeValue("ISSUEDATE"),
                LineOfBusiness = reader.StringValue("LINEOFBUSINESS"),
                Product = reader.StringValue("PRODUCT"),
                PolicyId = reader.StringValue("POLICYID"),
                InsuredName = reader.StringValue("INSURED"),
                InsuredNumber = reader.StringValue("DOCUMENTNUMBER"),
                Module = reader.StringValue("MODULE"),
                EffectiveDate = reader.DateTimeValue("EFFECTIVEDATE"),
                EndingDate = reader.DateTimeValue("ENDINGDATE"),
                Status = reader.StringValue("STATUS"),
                StatusCode = (int)Math.Round(reader.NumericValue("STATUSCODE")),
                Currency = reader.StringValue("CURRENCY"),
                CancellationDate = reader.DateTimeValue("CANCELLATIONDATE"),
                ReasonForStatus = reader.StringValue("REASONFORSTATUS"),
                InsuredAmount = (double)reader.NumericValue("INSUREDAMOUNT"),
                AnnualPremium = (double)reader.NumericValue("ANNUALPREMIUM")
            };

            return newItem;
        }

        public static Contracts.Policy.Risk RetrieveByKey(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Insurance.Contracts.Policy.Risk result = null;
            Database.Select("SELECT Id, Risk.CompanyId, OriginType, LineOfBusinessCode, ProductCode, PolicyId, Currency, ModuleCode, PaymentFrequency, IssueDate, EffectiveDate, EndingDate, InsuredAmountBase, InsuredAmountComplement, InsuredAmount, AnnualPremium, MonthlyPremium, Surcharge, Status, CancellationDate, ReasonForStatus, CertificateId, Comments, Annotation, Risk.Reference, Risk.BranchOffice, ExecutiveUserCode, Risk.CustomData, Risk.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Risk.UpdateDate " +
                              "FROM Risk LEFT JOIN UserMember um ON um.UserId = Risk.UpdateUserCode " +
                             "WHERE Risk.Id=:Id AND Risk.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToRisk(reader);
                        }));
            return result;
        }

        public static Utilities.Contracts.LookUpValue RetrieveByDocumentNumber(int companyid, int lineOfBusinessCode, int productCode, int recordId, int documentType, string documentNumber, IDbConnection connection = null)
        {
            Utilities.Contracts.LookUpValue result = null;

            Database.Select(@"SELECT P.Status, LKS.Description StatusDesc
                               FROM RiskRoles JOIN Risk P ON P.Id=RiskRoles.PolicyId AND P.LineOfBusinessCode=:LineOfBusinessCode AND P.ProductCode=:ProductCode AND P.Status = 10
                               LEFT JOIN LOOKUP LKS ON LKS.LOOKUPID = 2050 AND LKS.LANGUAGE=1 AND LKS.CODE = P.STATUS
                             WHERE P.CompanyId=:CompanyId AND TYPE=2 AND DOCUMENTTYPE=:DocumentType AND DOCUMENTNUMBER=:DocumentNumber AND RiskRoles.PolicyId <> :PolicyId ORDER BY P.ID DESC")
                        .AddParameter("LineOfBusinessCode", DbType.Decimal, 9, lineOfBusinessCode)
                        .AddParameter("ProductCode", DbType.Decimal, 9, productCode)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                        .AddParameter("DocumentType", DbType.Decimal, 8, documentType)
                        .AddParameter("DocumentNumber", DbType.AnsiString, 20, documentNumber)
                        .AddParameter("PolicyId", DbType.Decimal, 9, recordId)
                       .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                       {
                           result = new Utilities.Contracts.LookUpValue() { Code = reader.NumericValue("Status").ToString(), Description = reader.StringValue("StatusDesc") };
                       }));

            return result;
        }

        /// <summary>
        /// Actualiza el campo de referencia para un registro en la tabla Risk por medio de su clave primaria.
        /// </summary>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int UpdateReference(int companyId, int Id, string reference, IDbConnection connection = null)
        {
            return (int)Database.Update(@"UPDATE Risk 
                                             SET Reference=:Reference 
                                           WHERE Id=:Id AND CompanyId=:CompanyId")
                            .AddParameter("Reference", DbType.AnsiString, 36, reference)
                            .AddParameter("Id", DbType.Decimal, 9, Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Risk.
        /// </summary>
        /// <param name="companyid"></param>
        /// <param name="status"></param>
        /// <returns>Lista de id</returns>
        public static List<Utilities.Contracts.LookUpValue> RetrieveByStatus(int companyid, int status, IDbConnection connection = null)
        {

            var result = new List<Utilities.Contracts.LookUpValue>();
            Database.Select(@"SELECT Risk.Id, Risk.Reference  
                                FROM Risk  
                                JOIN RiskBayer ON RiskBayer.Id=Risk.Id AND NVL(RiskBayer.HasDigitalSignature,0)=0  
                               WHERE Risk.CompanyId=:CompanyId AND Risk.Status=:Status ")
                    .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                    .AddParameter("Status", DbType.Decimal, 5, status)
                    .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                     {
                         result.Add(new Utilities.Contracts.LookUpValue() { Code = reader.NumericValue("Id").ToString(), Description = reader.StringValue("Reference") });
                     }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Risk.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="companyId"></param>
        /// <returns>Lista de instancias de Risk</returns>
        public static List<Contracts.Policy.Risk> RetrieveByIdCompanyId(int id, int companyId, IDbConnection connection = null)
        {
            var result = new List<Contracts.Policy.Risk>();
            Database.Select("SELECT Id, Risk.CompanyId, OriginType, LineOfBusinessCode, ProductCode, PolicyId, Currency, ModuleCode, PaymentFrequency, IssueDate, EffectiveDate, EndingDate, InsuredAmountBase, InsuredAmountComplement, InsuredAmount, AnnualPremium, MonthlyPremium, Surcharge, Status, CancellationDate, ReasonForStatus, CertificateId, Comments, Annotation, Risk.Reference, Risk.BranchOffice, ExecutiveUserCode, Risk.CustomData, Risk.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Risk.UpdateDate " +
                              "FROM Risk LEFT JOIN UserMember um ON um.UserId = Risk.UpdateUserCode " +
                             "WHERE Risk.Id=:Id AND Risk.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToRisk(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Elimina un registro en la tabla Risk por medio de su clave primaria.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="companyId"></param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int DeleteByIdCompanyId(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete(@"DELETE FROM Risk 
                                     WHERE Id=:Id AND CompanyId=:CompanyId")
                              .AddParameter("Id", DbType.Decimal, 9, id)
                              .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                              .Execute(connection, "Research");
        }
    }
}