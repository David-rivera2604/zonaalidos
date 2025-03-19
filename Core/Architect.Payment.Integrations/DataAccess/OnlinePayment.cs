using Architect.DataFactory;
using Architect.Utilities.Extensions;
using Architect.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.Payment.Integrations.DataAccess
{
    /// <summary>
    /// Pagos en línea
    /// </summary>
    public sealed partial class OnlinePayment
    {

        /// <summary>
        /// Crea un registro en la tabla OnlinePayment.
        /// </summary>
        /// <param name="onlinepaymentItem">Instancia de OnlinePayment</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Contracts.OnlinePayment onlinepaymentItem, IDbConnection connection = null)
        {
            if (onlinepaymentItem.UpdateDate.IsEmpty())
            {
                onlinepaymentItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO OnlinePayment (Id, CompanyId, DocumentType, DocumentNumber, FirstName, LastName, PrimaryEmailAddress, PhoneNumberMobile, AgentCode, PolicyId, BillNumber, Currency, Amount, Reference, Description, IssueDate, StatusDate, RequestID, ProcessUrl, ProviderStatus, ResponseData, Status, Reason, UpdateUserCode, UpdateDate, SettingId, RecurringReceipt, Source, ProcessId) " +
                                                 "VALUES(:Id, :CompanyId, :DocumentType, :DocumentNumber, :FirstName, :LastName, :PrimaryEmailAddress, :PhoneNumberMobile, :AgentCode, :PolicyId, :BillNumber, :Currency, :Amount, :Reference, :Description, :IssueDate, :StatusDate, :RequestID, :ProcessUrl, :ProviderStatus, :ResponseData, :Status, :Reason, :UpdateUserCode, :UpdateDate, :SettingId, :RecurringReceipt, :Source, :ProcessId)")
                            .AddParameter("Id", DbType.Decimal, 9, onlinepaymentItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, onlinepaymentItem.CompanyId)
                            .AddParameter("DocumentType", DbType.Decimal, 8, onlinepaymentItem.DocumentType)
                            .AddParameter("DocumentNumber", DbType.AnsiString, 20, onlinepaymentItem.DocumentNumber)
                            .AddParameter("FirstName", DbType.AnsiString, 40, onlinepaymentItem.FirstName)
                            .AddParameter("LastName", DbType.AnsiString, 40, onlinepaymentItem.LastName)
                            .AddParameter("PrimaryEmailAddress", DbType.AnsiString, 80, onlinepaymentItem.PrimaryEmailAddress)
                            .AddParameter("PhoneNumberMobile", DbType.AnsiString, 20, onlinepaymentItem.PhoneNumberMobile)
                            .AddParameter("AgentCode", DbType.Decimal, 11, onlinepaymentItem.AgentCode)
                            .AddParameter("PolicyId", DbType.AnsiString, 13, onlinepaymentItem.PolicyId)
                            .AddParameter("BillNumber", DbType.Decimal, 11, onlinepaymentItem.BillNumber)
                            .AddParameter("Currency", DbType.Decimal, 5, onlinepaymentItem.Currency)
                            .AddParameter("Amount", DbType.Decimal, 18, onlinepaymentItem.Amount)
                            .AddParameter("Reference", DbType.AnsiString, 80, onlinepaymentItem.Reference)
                            .AddParameter("Description", DbType.AnsiString, 256, onlinepaymentItem.Description)
                            .AddParameter("IssueDate", DbType.DateTime, 9, onlinepaymentItem.IssueDate)
                            .AddParameter("StatusDate", DbType.DateTime, 9, onlinepaymentItem.StatusDate)
                            .AddParameter("RequestID", DbType.Decimal, 11, onlinepaymentItem.RequestID)
                            .AddParameter("ProcessUrl", DbType.AnsiString, 256, onlinepaymentItem.ProcessUrl)
                            .AddParameter("ProviderStatus", DbType.AnsiString, 20, onlinepaymentItem.ProviderStatus)
                            .AddParameter("ResponseData", DbType.Clob, 0, onlinepaymentItem.ResponseData)
                            .AddParameter("Status", DbType.Decimal, 5, onlinepaymentItem.Status)
                            .AddParameter("Reason", DbType.AnsiString, 256, onlinepaymentItem.Reason)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, onlinepaymentItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, onlinepaymentItem.UpdateDate)
                            .AddParameter("SettingId", DbType.Decimal, 9, onlinepaymentItem.SettingId)
                            .AddParameter("RecurringReceipt", DbType.Decimal, 1, onlinepaymentItem.RecurringReceipt ? 1 : 0)
                            .AddParameter("Source", DbType.AnsiString, 18, onlinepaymentItem.Source)
                            .AddParameter("ProcessId", DbType.AnsiString, 36, onlinepaymentItem.ProcessId)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Recupera un registro en la tabla OnlinePayment por el campo Id.
        /// </summary>
        public static Contracts.OnlinePayment Retrieve(int id, int companyId, bool full = false, IDbConnection connection = null)
        {
            Contracts.OnlinePayment result = null;
            string complement = ", NULL ResponseData";
            if (full)
            {
                complement = ", ResponseData";
            }
            Database.Select("SELECT Id, OnlinePayment.CompanyId, DocumentType, DocumentNumber, OnlinePayment.FirstName, OnlinePayment.LastName, PrimaryEmailAddress, PhoneNumberMobile, AgentCode, PolicyId, BillNumber, Currency, Amount, OnlinePayment.Reference, Description, IssueDate, StatusDate, RequestID, ProcessUrl, ProviderStatus" + complement + ", Status, Reason, Authorization, Receipt, OnlinePayment.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, OnlinePayment.UpdateDate, SettingId " +
                              "FROM OnlinePayment LEFT JOIN UserMember um ON um.UserId = OnlinePayment.UpdateUserCode " +
                             "WHERE OnlinePayment.Id=:Id AND OnlinePayment.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToOnlinePayment(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla OnlinePayment por el campo RequestID.
        /// </summary>
        public static Contracts.OnlinePayment RetrieveByRequestID(Int64 requestID, bool full = false, IDbConnection connection = null)
        {
            Contracts.OnlinePayment result = null;
            string complement = ", NULL ResponseData";
            if (full)
            {
                complement = ", ResponseData";
            }
            Database.Select("SELECT Id, OnlinePayment.CompanyId, DocumentType, DocumentNumber, OnlinePayment.FirstName, OnlinePayment.LastName, PrimaryEmailAddress, PhoneNumberMobile, AgentCode, PolicyId, BillNumber, Currency, Amount, OnlinePayment.Reference, Description, IssueDate, StatusDate, RequestID, ProcessUrl, ProviderStatus" + complement + ", Status, Reason, Authorization, Receipt, OnlinePayment.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, OnlinePayment.UpdateDate, SettingId " +
                              "FROM OnlinePayment LEFT JOIN UserMember um ON um.UserId = OnlinePayment.UpdateUserCode " +
                             "WHERE OnlinePayment.RequestID=:RequestID")
                        .AddParameter("RequestID", DbType.Decimal, 11, requestID)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToOnlinePayment(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla OnlinePayment con estado pendiente por póliza y recibo.
        /// </summary>
        public static Contracts.OnlinePayment Retrieve(string policyId, Int64 billNumber, int companyId, bool full = false, IDbConnection connection = null)
        {
            string complement = ", NULL ResponseData";
            if (full)
            {
                complement = ", ResponseData";
            }

            Contracts.OnlinePayment result = null;
            Database.Select("SELECT Id, OnlinePayment.CompanyId, DocumentType, DocumentNumber, OnlinePayment.FirstName, OnlinePayment.LastName, PrimaryEmailAddress, PhoneNumberMobile, AgentCode, PolicyId, BillNumber, Currency, Amount, OnlinePayment.Reference, Description, IssueDate, NULL StatusDate, RequestID, ProcessUrl, ProviderStatus" + complement + ", Status, Reason, Authorization, Receipt, OnlinePayment.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, OnlinePayment.UpdateDate, SettingId " +
                              "FROM OnlinePayment LEFT JOIN UserMember um ON um.UserId = OnlinePayment.UpdateUserCode " +
                             "WHERE OnlinePayment.CompanyId=:CompanyId AND OnlinePayment.PolicyId=:PolicyId AND OnlinePayment.BillNumber=:BillNumber " +
                             "ORDER BY OnlinePayment.IssueDate DESC FETCH FIRST 1 ROWS ONLY")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter("PolicyId", DbType.AnsiString, 13, policyId)
                        .AddParameter("BillNumber", DbType.Decimal, 11, billNumber)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToOnlinePayment(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Último valor asignado a clave única de la tabla OnlinePayment.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                          "FROM OnlinePayment")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Este método de actualización debido a su naturaleza no actualiza el código el usuario que actualiza.</remarks>
        public static int UpdateNewSession(Contracts.OnlinePayment onlinepaymentItem, IDbConnection connection = null)
        {
            if (onlinepaymentItem.UpdateDate.IsEmpty())
            {
                onlinepaymentItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE OnlinePayment " +
                                      "SET RequestID=:RequestID, ProviderStatus=:ProviderStatus, Reason=:Reason, ResponseData=:ResponseData, Reference=:Reference, IssueDate=:IssueDate, StatusDate=:StatusDate, ProcessUrl=:ProcessUrl, Status=:Status, UpdateDate=:UpdateDate, SettingId=:SettingId " +
                                    "WHERE Id=:Id")
                                .AddParameter("RequestID", DbType.Decimal, 11, onlinepaymentItem.RequestID)
                                .AddParameter("ProviderStatus", DbType.AnsiString, 20, onlinepaymentItem.ProviderStatus)
                                .AddParameter("Reason", DbType.AnsiString, 256, onlinepaymentItem.Reason)
                                .AddParameter("ResponseData", DbType.AnsiString, 4000, onlinepaymentItem.ResponseData)
                                .AddParameter("Reference", DbType.AnsiString, 80, onlinepaymentItem.Reference)
                                .AddParameter("IssueDate", DbType.DateTime, 9, onlinepaymentItem.IssueDate)
                                .AddParameter("StatusDate", DbType.DateTime, 9, onlinepaymentItem.StatusDate)
                                .AddParameter("ProcessUrl", DbType.AnsiString, 256, onlinepaymentItem.ProcessUrl)
                                .AddParameter("Status", DbType.Decimal, 5, onlinepaymentItem.Status)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, onlinepaymentItem.UpdateDate)
                                .AddParameter("SettingId", DbType.Decimal, 9, onlinepaymentItem.SettingId)
                                .AddParameter("Id", DbType.Decimal, 9, onlinepaymentItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla OnlinePayment por medio de su clave primaria.
        /// </summary>
        /// <remarks>Este método de actualización debido a su naturaleza no actualiza el código el usuario que actualiza.</remarks>
        public static int Update(Contracts.OnlinePayment onlinepaymentItem, IDbConnection connection = null)
        {
            if (onlinepaymentItem.UpdateDate.IsEmpty())
            {
                onlinepaymentItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE OnlinePayment " +
                                      "SET StatusDate=:StatusDate, ProviderStatus=:ProviderStatus, ResponseData=:ResponseData, Status=:Status, Reason=:Reason, Authorization=:Authorization, Receipt=:Receipt, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("StatusDate", DbType.DateTime, 9, onlinepaymentItem.StatusDate)
                                .AddParameter("ProviderStatus", DbType.AnsiString, 20, onlinepaymentItem.ProviderStatus)
                                .AddParameter("ResponseData", DbType.Clob, 0, onlinepaymentItem.ResponseData)
                                .AddParameter("Status", DbType.Decimal, 5, onlinepaymentItem.Status)
                                .AddParameter("Reason", DbType.AnsiString, 256, onlinepaymentItem.Reason)
                                .AddParameter("Authorization", DbType.AnsiString, 128, onlinepaymentItem.Authorization)
                                .AddParameter("Receipt", DbType.AnsiString, 128, onlinepaymentItem.Receipt)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, onlinepaymentItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, onlinepaymentItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza la información retornada por el package de pago en tron.
        /// </summary>
        /// <remarks>Este método de actualización debido a su naturaleza no actualiza el código el usuario que actualiza.</remarks>
        public static int UpdateTronInformation(int id, int tronCode, string tronMessage, IDbConnection connection = null)
        {
            return Database.Update("UPDATE OnlinePayment " +
                                      "SET TronCode=:TronCode, TronMessage=:TronMessage, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("TronCode", DbType.Decimal, 5, tronCode)
                                .AddParameter("TronMessage", DbType.AnsiString, 256, tronMessage)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, DateTime.Now)
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'OnlinePayment'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Contracts.OnlinePayment DataReaderToOnlinePayment(System.Data.IDataReader reader, Contracts.OnlinePayment item = null)
        {
            if (item == null)
            {
                item = new Contracts.OnlinePayment();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.DocumentType = reader.IntegerValue("DocumentType");
            item.DocumentNumber = reader.StringValue("DocumentNumber");
            item.FirstName = reader.StringValue("FirstName");
            item.LastName = reader.StringValue("LastName");
            item.PrimaryEmailAddress = reader.StringValue("PrimaryEmailAddress");
            item.PhoneNumberMobile = reader.StringValue("PhoneNumberMobile");
            item.AgentCode = reader.IntegerValue("AgentCode");
            item.PolicyId = reader.StringValue("PolicyId");
            item.BillNumber = reader.Integer64Value("BillNumber");
            item.Currency = reader.IntegerValue("Currency");
            item.Amount = reader.DoubleValue("Amount");
            item.Reference = reader.StringValue("Reference");
            item.Description = reader.StringValue("Description");
            item.IssueDate = reader.DateTimeValue("IssueDate");
            item.StatusDate = reader.DateTimeValue("StatusDate");
            item.RequestID = reader.Integer64Value("RequestID");
            item.ProcessUrl = reader.StringValue("ProcessUrl");
            item.ProviderStatus = reader.StringValue("ProviderStatus");
            item.ResponseData = reader.StringValue("ResponseData");
            item.Status = reader.IntegerValue("Status");
            item.Reason = reader.StringValue("Reason");
            item.Authorization = reader.StringValue("Authorization");
            item.Receipt = reader.StringValue("Receipt");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            item.SettingId = reader.IntegerValue("SettingId");
            return item;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla OnlinePayment.
        /// </summary>
        public static List<Contracts.OnlinePayment> RetrievePendings(IDbConnection connection = null)
        {
            List<Contracts.OnlinePayment> result = new List<Contracts.OnlinePayment>();
            Database.Select("SELECT Id, OnlinePayment.CompanyId, RequestID, ProviderStatus, Reason, Authorization, Receipt, NULL ResponseData, DocumentType, DocumentNumber, OnlinePayment.FirstName, OnlinePayment.LastName, PrimaryEmailAddress, PhoneNumberMobile, AgentCode, PolicyId, BillNumber, Currency, Amount, OnlinePayment.Reference, Description, IssueDate, StatusDate, ProcessUrl, Status, OnlinePayment.UpdateUserCode, NULL UpdateUserName, OnlinePayment.UpdateDate, SettingId " +
                              "FROM OnlinePayment " +
                             "WHERE OnlinePayment.ProviderStatus IN ('INIT', 'PENDING')")
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToOnlinePayment(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla OnlinePayment que cumplan con el criterio del campo TronCode.
        /// </summary>
        public static List<Contracts.OnlinePayment> RetrieveByTronCode(int tronCode, IDbConnection connection = null)
        {
            List<Contracts.OnlinePayment> result = new List<Contracts.OnlinePayment>();
            Database.Select("SELECT Id, OnlinePayment.CompanyId, RequestID, ProviderStatus, Reason, Authorization, Receipt, NULL ResponseData, DocumentType, DocumentNumber, OnlinePayment.FirstName, OnlinePayment.LastName, PrimaryEmailAddress, PhoneNumberMobile, AgentCode, PolicyId, BillNumber, Currency, Amount, OnlinePayment.Reference, Description, IssueDate, StatusDate, ProcessUrl, Status, OnlinePayment.UpdateUserCode, NULL UpdateUserName, OnlinePayment.UpdateDate, SettingId " +
                              "FROM OnlinePayment " +
                             "WHERE NVL(OnlinePayment.TronCode,0) = :TronCode")
                        .AddParameter("TronCode", DbType.Decimal, 5, tronCode)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToOnlinePayment(reader));
                        }));
            return result;
        }

    }

}

