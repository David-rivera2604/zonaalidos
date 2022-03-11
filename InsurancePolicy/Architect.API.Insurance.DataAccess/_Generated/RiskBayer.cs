using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.Policy
{
    /// <summary>
    /// RiskBayer
    /// </summary>
    public sealed partial class RiskBayer
    {
        /// <summary>
        /// Crea un registro en la tabla RiskBayer.
        /// </summary>
        /// <param name="riskbayerItem">Instancia de RiskBayer</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Insurance.Contracts.Policy.RiskBayer riskbayerItem, IDbConnection connection = null)
        {
            if (riskbayerItem.UpdateDate.IsEmpty())
            {
                riskbayerItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO RiskBayer (Id, CompanyId, MainPolicyId, IssueDate, ContractorName, IsLife, IsHealth, SocialSecurity, DominantMember, DateEntryWork, MonthlySalary, Doctor, RefundBankCode, RefundBankAccount, RefundBankAccountType, RefundBankAccountCurrency, PaymentModeType, PaymentBankAccount, PaymentCardNumber, PaymentCardExpirationDate, PaymentHolder, PaymentBankCode, HasDigitalSignature, ContinuityDate, EmployeeNumber, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :MainPolicyId, :IssueDate, :ContractorName, :IsLife, :IsHealth, :SocialSecurity, :DominantMember, :DateEntryWork, :MonthlySalary, :Doctor, :RefundBankCode, :RefundBankAccount, :RefundBankAccountType, :RefundBankAccountCurrency, :PaymentModeType, :PaymentBankAccount, :PaymentCardNumber, :PaymentCardExpirationDate, :PaymentHolder, :PaymentBankCode, :HasDigitalSignature, :ContinuityDate, :EmployeeNumber, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, riskbayerItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, riskbayerItem.CompanyId)
                            .AddParameter("MainPolicyId", DbType.AnsiString, 20, riskbayerItem.MainPolicyId)
                            .AddParameter("IssueDate", DbType.DateTime, 9, riskbayerItem.IssueDate)
                            .AddParameter("ContractorName", DbType.AnsiString, 80, riskbayerItem.ContractorName)
                            .AddParameter("IsLife", DbType.AnsiStringFixedLength, 2, riskbayerItem.IsLife)
                            .AddParameter("IsHealth", DbType.AnsiStringFixedLength, 2, riskbayerItem.IsHealth)
                            .AddParameter("SocialSecurity", DbType.AnsiString, 20, riskbayerItem.SocialSecurity)
                            .AddParameter("DominantMember", DbType.Decimal, 5, riskbayerItem.DominantMember)
                            .AddParameter("DateEntryWork", DbType.DateTime, 9, riskbayerItem.DateEntryWork)
                            .AddParameter("MonthlySalary", DbType.Decimal, 18, riskbayerItem.MonthlySalary)
                            .AddParameter("Doctor", DbType.AnsiString, 120, riskbayerItem.Doctor)
                            .AddParameter("RefundBankCode", DbType.Decimal, 5, riskbayerItem.RefundBankCode)
                            .AddParameter("RefundBankAccount", DbType.AnsiString, 22, riskbayerItem.RefundBankAccount)
                            .AddParameter("RefundBankAccountType", DbType.Decimal, 5, riskbayerItem.RefundBankAccountType)
                            .AddParameter("RefundBankAccountCurrency", DbType.Decimal, 5, riskbayerItem.RefundBankAccountCurrency)
                            .AddParameter("PaymentModeType", DbType.Decimal, 5, riskbayerItem.PaymentModeType)
                            .AddParameter("PaymentBankAccount", DbType.AnsiString, 22, riskbayerItem.PaymentBankAccount)
                            .AddParameter("PaymentCardNumber", DbType.AnsiString, 22, riskbayerItem.PaymentCardNumber)
                            .AddParameter("PaymentCardExpirationDate", DbType.DateTime, 9, riskbayerItem.PaymentCardExpirationDate)
                            .AddParameter("PaymentHolder", DbType.AnsiString, 60, riskbayerItem.PaymentHolder)
                            .AddParameter("PaymentBankCode", DbType.Decimal, 5, riskbayerItem.PaymentBankCode)
                            .AddParameter("HasDigitalSignature", DbType.Decimal, 1, riskbayerItem.HasDigitalSignature ? 1 : 0)
                            .AddParameter("ContinuityDate", DbType.DateTime, 9, riskbayerItem.ContinuityDate)
                            .AddParameter("EmployeeNumber", DbType.AnsiString, 30, riskbayerItem.EmployeeNumber)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskbayerItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, riskbayerItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla RiskBayer.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="riskbayerItems">Lista de instancia de RiskBayer</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Insurance.Contracts.Policy.RiskBayer> riskbayerItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.Policy.RiskBayer item in riskbayerItems)
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
        /// Recupera un registro en la tabla RiskBayer por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la póliza.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de RiskBayer</returns>
        public static Architect.API.Insurance.Contracts.Policy.RiskBayer Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Insurance.Contracts.Policy.RiskBayer result = null;
            Database.Select("SELECT Id, RiskBayer.CompanyId, MainPolicyId, IssueDate, ContractorName, IsLife, IsHealth, SocialSecurity, DominantMember, DateEntryWork, MonthlySalary, Doctor, RefundBankCode, RefundBankAccount, RefundBankAccountType, RefundBankAccountCurrency, PaymentModeType, PaymentBankAccount, PaymentCardNumber, PaymentCardExpirationDate, PaymentHolder, PaymentBankCode, HasDigitalSignature, ContinuityDate, EmployeeNumber, RiskBayer.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RiskBayer.UpdateDate " +
                              "FROM RiskBayer LEFT JOIN UserMember um ON um.UserId = RiskBayer.UpdateUserCode " +
                             "WHERE RiskBayer.Id=:Id AND RiskBayer.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToRiskBayer(reader);
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
        /// Último valor asignado a clave unica de la tabla RiskBayer.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM RiskBayer")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla RiskBayer por medio de su clave primaria.
        /// </summary>
        /// <param name="riskbayerItem">Instancia de RiskBayer</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Insurance.Contracts.Policy.RiskBayer riskbayerItem, IDbConnection connection = null)
        {
            if (riskbayerItem.UpdateDate.IsEmpty())
            {
                riskbayerItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE RiskBayer " +
                                      "SET CompanyId=:CompanyId, MainPolicyId=:MainPolicyId, IssueDate=:IssueDate, ContractorName=:ContractorName, IsLife=:IsLife, IsHealth=:IsHealth, SocialSecurity=:SocialSecurity, DominantMember=:DominantMember, DateEntryWork=:DateEntryWork, MonthlySalary=:MonthlySalary, Doctor=:Doctor, RefundBankCode=:RefundBankCode, RefundBankAccount=:RefundBankAccount, RefundBankAccountType=:RefundBankAccountType, RefundBankAccountCurrency=:RefundBankAccountCurrency, PaymentModeType=:PaymentModeType, PaymentBankAccount=:PaymentBankAccount, PaymentCardNumber=:PaymentCardNumber, PaymentCardExpirationDate=:PaymentCardExpirationDate, PaymentHolder=:PaymentHolder, PaymentBankCode=:PaymentBankCode, HasDigitalSignature=:HasDigitalSignature, ContinuityDate=:ContinuityDate, EmployeeNumber=:EmployeeNumber, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, riskbayerItem.CompanyId)
                                .AddParameter("MainPolicyId", DbType.AnsiString, 20, riskbayerItem.MainPolicyId)
                                .AddParameter("IssueDate", DbType.DateTime, 9, riskbayerItem.IssueDate)
                                .AddParameter("ContractorName", DbType.AnsiString, 80, riskbayerItem.ContractorName)
                                .AddParameter("IsLife", DbType.AnsiStringFixedLength, 2, riskbayerItem.IsLife)
                                .AddParameter("IsHealth", DbType.AnsiStringFixedLength, 2, riskbayerItem.IsHealth)
                                .AddParameter("SocialSecurity", DbType.AnsiString, 20, riskbayerItem.SocialSecurity)
                                .AddParameter("DominantMember", DbType.Decimal, 5, riskbayerItem.DominantMember)
                                .AddParameter("DateEntryWork", DbType.DateTime, 9, riskbayerItem.DateEntryWork)
                                .AddParameter("MonthlySalary", DbType.Decimal, 18, riskbayerItem.MonthlySalary)
                                .AddParameter("Doctor", DbType.AnsiString, 120, riskbayerItem.Doctor)
                                .AddParameter("RefundBankCode", DbType.Decimal, 5, riskbayerItem.RefundBankCode)
                                .AddParameter("RefundBankAccount", DbType.AnsiString, 22, riskbayerItem.RefundBankAccount)
                                .AddParameter("RefundBankAccountType", DbType.Decimal, 5, riskbayerItem.RefundBankAccountType)
                                .AddParameter("RefundBankAccountCurrency", DbType.Decimal, 5, riskbayerItem.RefundBankAccountCurrency)
                                .AddParameter("PaymentModeType", DbType.Decimal, 5, riskbayerItem.PaymentModeType)
                                .AddParameter("PaymentBankAccount", DbType.AnsiString, 22, riskbayerItem.PaymentBankAccount)
                                .AddParameter("PaymentCardNumber", DbType.AnsiString, 22, riskbayerItem.PaymentCardNumber)
                                .AddParameter("PaymentCardExpirationDate", DbType.DateTime, 9, riskbayerItem.PaymentCardExpirationDate)
                                .AddParameter("PaymentHolder", DbType.AnsiString, 60, riskbayerItem.PaymentHolder)
                                .AddParameter("PaymentBankCode", DbType.Decimal, 5, riskbayerItem.PaymentBankCode)
                                .AddParameter("HasDigitalSignature", DbType.Decimal, 1, riskbayerItem.HasDigitalSignature ? 1 : 0)
                                .AddParameter("ContinuityDate", DbType.DateTime, 9, riskbayerItem.ContinuityDate)
                                .AddParameter("EmployeeNumber", DbType.AnsiString, 30, riskbayerItem.EmployeeNumber)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskbayerItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, riskbayerItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, riskbayerItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla RiskBayer por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="riskbayerItems">Lista de instancia de RiskBayer</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Insurance.Contracts.Policy.RiskBayer> riskbayerItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.Policy.RiskBayer item in riskbayerItems)
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
        /// Elimina un registro en la tabla RiskBayer por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la póliza.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM RiskBayer " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla RiskBayer por medio de su clave primaria.
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
        /// Recupera la cantidad de registros existentes en la tabla RiskBayer que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM RiskBayer " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'RiskBayer'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Insurance.Contracts.Policy.RiskBayer DataReaderToRiskBayer(System.Data.IDataReader reader, Architect.API.Insurance.Contracts.Policy.RiskBayer item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Insurance.Contracts.Policy.RiskBayer();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.MainPolicyId = reader.StringValue("MainPolicyId");
            item.IssueDate = reader.DateTimeValue("IssueDate");
            item.ContractorName = reader.StringValue("ContractorName");
            item.IsLife = reader.StringValue("IsLife");
            item.IsHealth = reader.StringValue("IsHealth");
            item.SocialSecurity = reader.StringValue("SocialSecurity");
            item.DominantMember = reader.IntegerValue("DominantMember");
            item.DateEntryWork = reader.DateTimeValue("DateEntryWork");
            item.MonthlySalary = reader.DoubleValue("MonthlySalary");
            item.Doctor = reader.StringValue("Doctor");
            item.RefundBankCode = reader.IntegerValue("RefundBankCode");
            item.RefundBankAccount = reader.StringValue("RefundBankAccount");
            item.RefundBankAccountType = reader.IntegerValue("RefundBankAccountType");
            item.RefundBankAccountCurrency = reader.IntegerValue("RefundBankAccountCurrency");
            item.PaymentModeType = reader.IntegerValue("PaymentModeType");
            item.PaymentBankAccount = reader.StringValue("PaymentBankAccount");
            item.PaymentCardNumber = reader.StringValue("PaymentCardNumber");
            item.PaymentCardExpirationDate = reader.DateTimeValue("PaymentCardExpirationDate");
            item.PaymentHolder = reader.StringValue("PaymentHolder");
            item.PaymentBankCode = reader.IntegerValue("PaymentBankCode");
            item.HasDigitalSignature = reader.IntegerValue("HasDigitalSignature") == 1;
            item.ContinuityDate = reader.DateTimeValue("ContinuityDate");
            item.EmployeeNumber = reader.StringValue("EmployeeNumber");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }
    }
}