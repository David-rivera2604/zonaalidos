using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;


namespace Architect.API.Insurance.DataAccess.Policy
{

    /// <summary>
    /// Pólizas registradas.
    /// </summary>
    public static partial class Risk
    {

        /// <summary>
        /// Crea un registro en la tabla Risk.
        /// </summary>
        /// <param name="riskItem">Instancia de Risk</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Insurance.Contracts.Policy.Risk riskItem, IDbConnection connection = null)
        {
            if (riskItem.UpdateDate.IsEmpty())
            {
                riskItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO Risk (Id, CompanyId, OriginType, LineOfBusinessCode, ProductCode, PolicyId, Currency, ModuleCode, PaymentFrequency, IssueDate, EffectiveDate, EndingDate, InsuredAmountBase, InsuredAmountComplement, InsuredAmount, AnnualPremium, MonthlyPremium, Surcharge, Status, CancellationDate, ReasonForStatus, CertificateId, Comments, Annotation, Reference, BranchOffice, ExecutiveUserCode, HasDigitalSignature, Subsidiary, MainPolicyId, CustomData, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :OriginType, :LineOfBusinessCode, :ProductCode, :PolicyId, :Currency, :ModuleCode, :PaymentFrequency, :IssueDate, :EffectiveDate, :EndingDate, :InsuredAmountBase, :InsuredAmountComplement, :InsuredAmount, :AnnualPremium, :MonthlyPremium, :Surcharge, :Status, :CancellationDate, :ReasonForStatus, :CertificateId, :Comments, :Annotation, :Reference, :BranchOffice, :ExecutiveUserCode, :HasDigitalSignature, :Subsidiary, :MainPolicyId, :CustomData, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, riskItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, riskItem.CompanyId)
                            .AddParameter("OriginType", DbType.Decimal, 5, riskItem.OriginType)
                            .AddParameter("LineOfBusinessCode", DbType.Decimal, 9, riskItem.LineOfBusinessCode)
                            .AddParameter("ProductCode", DbType.Decimal, 9, riskItem.ProductCode)
                            .AddParameter("PolicyId", DbType.Decimal, 9, riskItem.PolicyId)
                            .AddParameter("Currency", DbType.Decimal, 5, riskItem.Currency)
                            .AddParameter("ModuleCode", DbType.Decimal, 5, riskItem.ModuleCode)
                            .AddParameter("PaymentFrequency", DbType.Decimal, 5, riskItem.PaymentFrequency)
                            .AddParameter("IssueDate", DbType.DateTime, 9, riskItem.IssueDate)
                            .AddParameter("EffectiveDate", DbType.DateTime, 9, riskItem.EffectiveDate)
                            .AddParameter("EndingDate", DbType.DateTime, 9, riskItem.EndingDate)
                            .AddParameter("InsuredAmountBase", DbType.Decimal, 18, riskItem.InsuredAmountBase)
                            .AddParameter("InsuredAmountComplement", DbType.Decimal, 18, riskItem.InsuredAmountComplement)
                            .AddParameter("InsuredAmount", DbType.Decimal, 18, riskItem.InsuredAmount)
                            .AddParameter("AnnualPremium", DbType.Decimal, 18, riskItem.AnnualPremium)
                            .AddParameter("MonthlyPremium", DbType.Decimal, 18, riskItem.MonthlyPremium)
                            .AddParameter("Surcharge", DbType.Decimal, 18, riskItem.Surcharge)
                            .AddParameter("Status", DbType.Decimal, 5, riskItem.Status)
                            .AddParameter("CancellationDate", DbType.DateTime, 9, riskItem.CancellationDate)
                            .AddParameter("ReasonForStatus", DbType.Decimal, 5, riskItem.ReasonForStatus)
                            .AddParameter("CertificateId", DbType.Decimal, 9, riskItem.CertificateId)
                            .AddParameter("Comments", DbType.AnsiString, 350, riskItem.Comments)
                            .AddParameter("Annotation", DbType.AnsiString, 350, riskItem.Annotation)
                            .AddParameter("Reference", DbType.AnsiString, 36, riskItem.Reference)
                            .AddParameter("BranchOffice", DbType.Decimal, 5, riskItem.BranchOffice)
                            .AddParameter("ExecutiveUserCode", DbType.Decimal, 9, riskItem.ExecutiveUserCode)
                            .AddParameter("HasDigitalSignature", DbType.Decimal, 1, riskItem.HasDigitalSignature ? 1 : 0)
                            .AddParameter("Subsidiary", DbType.Decimal, 5, riskItem.Subsidiary)
                            .AddParameter("MainPolicyId", DbType.AnsiString, 20, riskItem.MainPolicyId)
                            .AddParameter("CustomData", DbType.AnsiString, 2000, riskItem.CustomData)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, riskItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla Risk.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="riskItems">Lista de instancia de Risk</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Insurance.Contracts.Policy.Risk> riskItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.Policy.Risk item in riskItems)
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
        /// Recupera un registro en la tabla Risk por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la póliza.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Risk</returns>
        public static Architect.API.Insurance.Contracts.Policy.Risk Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Insurance.Contracts.Policy.Risk result = null;
            Database.Select("SELECT Id, Risk.CompanyId, OriginType, LineOfBusinessCode, ProductCode, PolicyId, Currency, ModuleCode, PaymentFrequency, IssueDate, EffectiveDate, EndingDate, InsuredAmountBase, InsuredAmountComplement, InsuredAmount, AnnualPremium, MonthlyPremium, Surcharge, Status, CancellationDate, ReasonForStatus, CertificateId, Comments, Annotation, Risk.Reference, Risk.BranchOffice, ExecutiveUserCode, HasDigitalSignature, Subsidiary, MainPolicyId, Risk.CustomData, Risk.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Risk.UpdateDate " +
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
        /// Último valor asignado a clave unica de la tabla Risk.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM Risk")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla Risk por medio de su clave primaria.
        /// </summary>
        /// <param name="riskItem">Instancia de Risk</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        /// <summary>
        /// Actualiza un registro en la tabla Risk por medio de su clave primaria.
        /// </summary>
        /// <param name="riskItem">Instancia de Risk</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Insurance.Contracts.Policy.Risk riskItem, IDbConnection connection = null)
        {
            if (riskItem.UpdateDate.IsEmpty())
            {
                riskItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE Risk " +
                                      "SET CompanyId=:CompanyId, OriginType=:OriginType, LineOfBusinessCode=:LineOfBusinessCode, ProductCode=:ProductCode, PolicyId=:PolicyId, Currency=:Currency, ModuleCode=:ModuleCode, PaymentFrequency=:PaymentFrequency, IssueDate=:IssueDate, EffectiveDate=:EffectiveDate, EndingDate=:EndingDate, InsuredAmountBase=:InsuredAmountBase, InsuredAmountComplement=:InsuredAmountComplement, InsuredAmount=:InsuredAmount, AnnualPremium=:AnnualPremium, MonthlyPremium=:MonthlyPremium, Surcharge=:Surcharge, Status=:Status, CancellationDate=:CancellationDate, ReasonForStatus=:ReasonForStatus, CertificateId=:CertificateId, Comments=:Comments, Annotation=:Annotation, Reference=:Reference, BranchOffice=:BranchOffice, ExecutiveUserCode=:ExecutiveUserCode, HasDigitalSignature=:HasDigitalSignature, Subsidiary=:Subsidiary, MainPolicyId=:MainPolicyId, CustomData=:CustomData, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, riskItem.CompanyId)
                                .AddParameter("OriginType", DbType.Decimal, 5, riskItem.OriginType)
                                .AddParameter("LineOfBusinessCode", DbType.Decimal, 9, riskItem.LineOfBusinessCode)
                                .AddParameter("ProductCode", DbType.Decimal, 9, riskItem.ProductCode)
                                .AddParameter("PolicyId", DbType.Decimal, 9, riskItem.PolicyId)
                                .AddParameter("Currency", DbType.Decimal, 5, riskItem.Currency)
                                .AddParameter("ModuleCode", DbType.Decimal, 5, riskItem.ModuleCode)
                                .AddParameter("PaymentFrequency", DbType.Decimal, 5, riskItem.PaymentFrequency)
                                .AddParameter("IssueDate", DbType.DateTime, 9, riskItem.IssueDate)
                                .AddParameter("EffectiveDate", DbType.DateTime, 9, riskItem.EffectiveDate)
                                .AddParameter("EndingDate", DbType.DateTime, 9, riskItem.EndingDate)
                                .AddParameter("InsuredAmountBase", DbType.Decimal, 18, riskItem.InsuredAmountBase)
                                .AddParameter("InsuredAmountComplement", DbType.Decimal, 18, riskItem.InsuredAmountComplement)
                                .AddParameter("InsuredAmount", DbType.Decimal, 18, riskItem.InsuredAmount)
                                .AddParameter("AnnualPremium", DbType.Decimal, 18, riskItem.AnnualPremium)
                                .AddParameter("MonthlyPremium", DbType.Decimal, 18, riskItem.MonthlyPremium)
                                .AddParameter("Surcharge", DbType.Decimal, 18, riskItem.Surcharge)
                                .AddParameter("Status", DbType.Decimal, 5, riskItem.Status)
                                .AddParameter("CancellationDate", DbType.DateTime, 9, riskItem.CancellationDate)
                                .AddParameter("ReasonForStatus", DbType.Decimal, 5, riskItem.ReasonForStatus)
                                .AddParameter("CertificateId", DbType.Decimal, 9, riskItem.CertificateId)
                                .AddParameter("Comments", DbType.AnsiString, 350, riskItem.Comments)
                                .AddParameter("Annotation", DbType.AnsiString, 350, riskItem.Annotation)
                                .AddParameter("Reference", DbType.AnsiString, 36, riskItem.Reference)
                                .AddParameter("BranchOffice", DbType.Decimal, 5, riskItem.BranchOffice)
                                .AddParameter("ExecutiveUserCode", DbType.Decimal, 9, riskItem.ExecutiveUserCode)
                                .AddParameter("HasDigitalSignature", DbType.Decimal, 1, riskItem.HasDigitalSignature ? 1 : 0)
                                .AddParameter("Subsidiary", DbType.Decimal, 5, riskItem.Subsidiary)
                                .AddParameter("MainPolicyId", DbType.AnsiString, 20, riskItem.MainPolicyId)
                                .AddParameter("CustomData", DbType.AnsiString, 2000, riskItem.CustomData)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, riskItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, riskItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Risk por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="riskItems">Lista de instancia de Risk</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Insurance.Contracts.Policy.Risk> riskItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.Policy.Risk item in riskItems)
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
        /// Elimina un registro en la tabla Risk por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la póliza.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM Risk " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Risk por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única de la póliza.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla Risk que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Risk " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'Risk'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Insurance.Contracts.Policy.Risk DataReaderToRisk(System.Data.IDataReader reader, Architect.API.Insurance.Contracts.Policy.Risk item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Insurance.Contracts.Policy.Risk();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.OriginType = reader.IntegerValue("OriginType");
            item.LineOfBusinessCode = reader.IntegerValue("LineOfBusinessCode");
            item.ProductCode = reader.IntegerValue("ProductCode");
            item.PolicyId = reader.IntegerValue("PolicyId");
            item.Currency = reader.IntegerValue("Currency");
            item.ModuleCode = reader.IntegerValue("ModuleCode");
            item.PaymentFrequency = reader.IntegerValue("PaymentFrequency");
            item.IssueDate = reader.DateTimeValue("IssueDate");
            item.EffectiveDate = reader.DateTimeValue("EffectiveDate");
            item.EndingDate = reader.DateTimeValue("EndingDate");
            item.InsuredAmountBase = reader.DoubleValue("InsuredAmountBase");
            item.InsuredAmountComplement = reader.DoubleValue("InsuredAmountComplement");
            item.InsuredAmount = reader.DoubleValue("InsuredAmount");
            item.AnnualPremium = reader.DoubleValue("AnnualPremium");
            item.MonthlyPremium = reader.DoubleValue("MonthlyPremium");
            item.Surcharge = reader.DoubleValue("Surcharge");
            item.Status = reader.IntegerValue("Status");
            item.CancellationDate = reader.DateTimeValue("CancellationDate");
            item.ReasonForStatus = reader.IntegerValue("ReasonForStatus");
            item.CertificateId = reader.IntegerValue("CertificateId");
            item.Comments = reader.StringValue("Comments");
            item.Annotation = reader.StringValue("Annotation");
            item.Reference = reader.StringValue("Reference");
            item.BranchOffice = reader.IntegerValue("BranchOffice");
            item.ExecutiveUserCode = reader.IntegerValue("ExecutiveUserCode");
            item.HasDigitalSignature = reader.IntegerValue("HasDigitalSignature") == 1;
            item.Subsidiary = reader.IntegerValue("Subsidiary");
            item.MainPolicyId = reader.StringValue("MainPolicyId");
            item.CustomData = reader.StringValue("CustomData");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }
}