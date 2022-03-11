using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Información complementaria a los casos asociados a los procesos.
    /// </summary>
    public sealed partial class ProcessCaseComplement
    {

        /// <summary>
        /// Crea un registro en la tabla ProcessCaseComplement.
        /// </summary>
        /// <param name="processcasecomplementItem">Instancia de ProcessCaseComplement</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.ProcessCaseComplement processcasecomplementItem, IDbConnection connection = null)
        {
            if (processcasecomplementItem.UpdateDate.IsEmpty())
            {
                processcasecomplementItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO ProcessCaseComplement (CaseId, CompanyId, Fee, Compensation, Deductible, SpareParts, ManPower, Workshop, ManPowerInvoice, SparePartsInvoice, SettlementDate, AppointmentDate, AppointmentTime, AssignedAdvisor, ReportDate, RepairTotalAmount, RepairManPower, RepairSpareParts, SetSpaFee, SetSpaCompensation, SetSpaDeductible, SetSpaSpareParts, SetSpaManPower, SetSpaManPowerInvoice, SetSpaSparePartsInvoice, SetSpaSettlementDate, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:CaseId, :CompanyId, :Fee, :Compensation, :Deductible, :SpareParts, :ManPower, :Workshop, :ManPowerInvoice, :SparePartsInvoice, :SettlementDate, :AppointmentDate, :AppointmentTime, :AssignedAdvisor, :ReportDate, :RepairTotalAmount, :RepairManPower, :RepairSpareParts, :SetSpaFee, :SetSpaCompensation, :SetSpaDeductible, :SetSpaSpareParts, :SetSpaManPower, :SetSpaManPowerInvoice, :SetSpaSparePartsInvoice, :SetSpaSettlementDate, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("CaseId", DbType.Decimal, 9, processcasecomplementItem.CaseId)
                            .AddParameter("CompanyId", DbType.Decimal, 5, processcasecomplementItem.CompanyId)
                            .AddParameter("Fee", DbType.Decimal, 18, processcasecomplementItem.Fee)
                            .AddParameter("Compensation", DbType.Decimal, 18, processcasecomplementItem.Compensation)
                            .AddParameter("Deductible", DbType.Decimal, 18, processcasecomplementItem.Deductible)
                            .AddParameter("SpareParts", DbType.Decimal, 18, processcasecomplementItem.SpareParts)
                            .AddParameter("ManPower", DbType.Decimal, 18, processcasecomplementItem.ManPower)
                            .AddParameter("Workshop", DbType.Decimal, 5, processcasecomplementItem.Workshop)
                            .AddParameter("ManPowerInvoice", DbType.AnsiString, 18, processcasecomplementItem.ManPowerInvoice)
                            .AddParameter("SparePartsInvoice", DbType.AnsiString, 18, processcasecomplementItem.SparePartsInvoice)
                            .AddParameter("SettlementDate", DbType.DateTime, 9, processcasecomplementItem.SettlementDate)
                            .AddParameter("AppointmentDate", DbType.DateTime, 9, processcasecomplementItem.AppointmentDate)
                            .AddParameter("AppointmentTime", DbType.AnsiStringFixedLength, 5, processcasecomplementItem.AppointmentTime)
                            .AddParameter("AssignedAdvisor", DbType.AnsiString, 120, processcasecomplementItem.AssignedAdvisor)
                            .AddParameter("ReportDate", DbType.DateTime, 9, processcasecomplementItem.ReportDate)
                            .AddParameter("RepairTotalAmount", DbType.Decimal, 18, processcasecomplementItem.RepairTotalAmount)
                            .AddParameter("RepairManPower", DbType.Decimal, 18, processcasecomplementItem.RepairManPower)
                            .AddParameter("RepairSpareParts", DbType.Decimal, 18, processcasecomplementItem.RepairSpareParts)
                            .AddParameter("SetSpaFee", DbType.Decimal, 18, processcasecomplementItem.SetSpaFee)
                            .AddParameter("SetSpaCompensation", DbType.Decimal, 18, processcasecomplementItem.SetSpaCompensation)
                            .AddParameter("SetSpaDeductible", DbType.Decimal, 18, processcasecomplementItem.SetSpaDeductible)
                            .AddParameter("SetSpaSpareParts", DbType.Decimal, 18, processcasecomplementItem.SetSpaSpareParts)
                            .AddParameter("SetSpaManPower", DbType.Decimal, 18, processcasecomplementItem.SetSpaManPower)
                            .AddParameter("SetSpaManPowerInvoice", DbType.AnsiString, 18, processcasecomplementItem.SetSpaManPowerInvoice)
                            .AddParameter("SetSpaSparePartsInvoice", DbType.AnsiString, 18, processcasecomplementItem.SetSpaSparePartsInvoice)
                            .AddParameter("SetSpaSettlementDate", DbType.DateTime, 9, processcasecomplementItem.SetSpaSettlementDate)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, processcasecomplementItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, processcasecomplementItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla ProcessCaseComplement.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processcasecomplementItems">Lista de instancia de ProcessCaseComplement</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.ProcessCaseComplement> processcasecomplementItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessCaseComplement item in processcasecomplementItems)
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
        /// Recupera un registro en la tabla ProcessCaseComplement por medio de su clave primaria.
        /// </summary>
        /// <param name="caseid">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ProcessCaseComplement</returns>
        public static Architect.API.Core.Contracts.General.ProcessCaseComplement Retrieve(int caseid, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.ProcessCaseComplement result = null;
            Database.Select("SELECT CaseId, ProcessCaseComplement.CompanyId, Fee, Compensation, Deductible, SpareParts, ManPower, Workshop, ManPowerInvoice, SparePartsInvoice, SettlementDate, AppointmentDate, AppointmentTime, AssignedAdvisor, ReportDate, RepairTotalAmount, RepairManPower, RepairSpareParts, SetSpaFee, SetSpaCompensation, SetSpaDeductible, SetSpaSpareParts, SetSpaManPower, SetSpaManPowerInvoice, SetSpaSparePartsInvoice, SetSpaSettlementDate, ProcessCaseComplement.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessCaseComplement.UpdateDate " +
                              "FROM ProcessCaseComplement LEFT JOIN UserMember um ON um.UserId = ProcessCaseComplement.UpdateUserCode " +
                             "WHERE ProcessCaseComplement.CaseId=:CaseId AND ProcessCaseComplement.CompanyId=:CompanyId")
                        .AddParameter("CaseId", DbType.Decimal, 9, caseid)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToProcessCaseComplement(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessCaseComplement.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessCaseComplement</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessCaseComplement> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessCaseComplement> result = new List<Architect.API.Core.Contracts.General.ProcessCaseComplement>();
            Database.Select("SELECT CaseId, ProcessCaseComplement.CompanyId, Fee, Compensation, Deductible, SpareParts, ManPower, Workshop, ManPowerInvoice, SparePartsInvoice, SettlementDate, AppointmentDate, AppointmentTime, AssignedAdvisor, ReportDate, RepairTotalAmount, RepairManPower, RepairSpareParts, SetSpaFee, SetSpaCompensation, SetSpaDeductible, SetSpaSpareParts, SetSpaManPower, SetSpaManPowerInvoice, SetSpaSparePartsInvoice, SetSpaSettlementDate, ProcessCaseComplement.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessCaseComplement.UpdateDate " +
                              "FROM ProcessCaseComplement LEFT JOIN UserMember um ON um.UserId = ProcessCaseComplement.UpdateUserCode " +
                             "WHERE ProcessCaseComplement.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessCaseComplement(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessCaseComplement.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessCaseComplement</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessCaseComplement> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessCaseComplement> result = new List<Architect.API.Core.Contracts.General.ProcessCaseComplement>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT CaseId, ProcessCaseComplement.CompanyId, Fee, Compensation, Deductible, SpareParts, ManPower, Workshop, ManPowerInvoice, SparePartsInvoice, SettlementDate, AppointmentDate, AppointmentTime, AssignedAdvisor, ReportDate, RepairTotalAmount, RepairManPower, RepairSpareParts, SetSpaFee, SetSpaCompensation, SetSpaDeductible, SetSpaSpareParts, SetSpaManPower, SetSpaManPowerInvoice, SetSpaSparePartsInvoice, SetSpaSettlementDate, ProcessCaseComplement.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessCaseComplement.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY ProcessCaseComplement.CaseId DESC) RowNumber " +
                              "FROM ProcessCaseComplement LEFT JOIN UserMember um ON um.UserId = ProcessCaseComplement.UpdateUserCode " +
                             "WHERE ProcessCaseComplement.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessCaseComplement(reader));
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
        /// Último valor asignado a clave única de la tabla ProcessCaseComplement.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(CaseId),0) " +
                                     "FROM ProcessCaseComplement")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessCaseComplement por medio de su clave primaria.
        /// </summary>
        /// <param name="processcasecomplementItem">Instancia de ProcessCaseComplement</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.ProcessCaseComplement processcasecomplementItem, IDbConnection connection = null)
        {
            if (processcasecomplementItem.UpdateDate.IsEmpty())
            {
                processcasecomplementItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE ProcessCaseComplement " +
                                      "SET CompanyId=:CompanyId, Fee=:Fee, Compensation=:Compensation, Deductible=:Deductible, SpareParts=:SpareParts, ManPower=:ManPower, Workshop=:Workshop, ManPowerInvoice=:ManPowerInvoice, SparePartsInvoice=:SparePartsInvoice, SettlementDate=:SettlementDate, AppointmentDate=:AppointmentDate, AppointmentTime=:AppointmentTime, AssignedAdvisor=:AssignedAdvisor, ReportDate=:ReportDate, RepairTotalAmount=:RepairTotalAmount, RepairManPower=:RepairManPower, RepairSpareParts=:RepairSpareParts, SetSpaFee=:SetSpaFee, SetSpaCompensation=:SetSpaCompensation, SetSpaDeductible=:SetSpaDeductible, SetSpaSpareParts=:SetSpaSpareParts, SetSpaManPower=:SetSpaManPower, SetSpaManPowerInvoice=:SetSpaManPowerInvoice, SetSpaSparePartsInvoice=:SetSpaSparePartsInvoice, SetSpaSettlementDate=:SetSpaSettlementDate, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE CaseId=:CaseId")
                                .AddParameter("CompanyId", DbType.Decimal, 5, processcasecomplementItem.CompanyId)
                                .AddParameter("Fee", DbType.Decimal, 18, processcasecomplementItem.Fee)
                                .AddParameter("Compensation", DbType.Decimal, 18, processcasecomplementItem.Compensation)
                                .AddParameter("Deductible", DbType.Decimal, 18, processcasecomplementItem.Deductible)
                                .AddParameter("SpareParts", DbType.Decimal, 18, processcasecomplementItem.SpareParts)
                                .AddParameter("ManPower", DbType.Decimal, 18, processcasecomplementItem.ManPower)
                                .AddParameter("Workshop", DbType.Decimal, 5, processcasecomplementItem.Workshop)
                                .AddParameter("ManPowerInvoice", DbType.AnsiString, 18, processcasecomplementItem.ManPowerInvoice)
                                .AddParameter("SparePartsInvoice", DbType.AnsiString, 18, processcasecomplementItem.SparePartsInvoice)
                                .AddParameter("SettlementDate", DbType.DateTime, 9, processcasecomplementItem.SettlementDate)
                                .AddParameter("AppointmentDate", DbType.DateTime, 9, processcasecomplementItem.AppointmentDate)
                                .AddParameter("AppointmentTime", DbType.AnsiStringFixedLength, 5, processcasecomplementItem.AppointmentTime)
                                .AddParameter("AssignedAdvisor", DbType.AnsiString, 120, processcasecomplementItem.AssignedAdvisor)
                                .AddParameter("ReportDate", DbType.DateTime, 9, processcasecomplementItem.ReportDate)
                                .AddParameter("RepairTotalAmount", DbType.Decimal, 18, processcasecomplementItem.RepairTotalAmount)
                                .AddParameter("RepairManPower", DbType.Decimal, 18, processcasecomplementItem.RepairManPower)
                                .AddParameter("RepairSpareParts", DbType.Decimal, 18, processcasecomplementItem.RepairSpareParts)
                                .AddParameter("SetSpaFee", DbType.Decimal, 18, processcasecomplementItem.SetSpaFee)
                                .AddParameter("SetSpaCompensation", DbType.Decimal, 18, processcasecomplementItem.SetSpaCompensation)
                                .AddParameter("SetSpaDeductible", DbType.Decimal, 18, processcasecomplementItem.SetSpaDeductible)
                                .AddParameter("SetSpaSpareParts", DbType.Decimal, 18, processcasecomplementItem.SetSpaSpareParts)
                                .AddParameter("SetSpaManPower", DbType.Decimal, 18, processcasecomplementItem.SetSpaManPower)
                                .AddParameter("SetSpaManPowerInvoice", DbType.AnsiString, 18, processcasecomplementItem.SetSpaManPowerInvoice)
                                .AddParameter("SetSpaSparePartsInvoice", DbType.AnsiString, 18, processcasecomplementItem.SetSpaSparePartsInvoice)
                                .AddParameter("SetSpaSettlementDate", DbType.DateTime, 9, processcasecomplementItem.SetSpaSettlementDate)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, processcasecomplementItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, processcasecomplementItem.UpdateDate)
                                .AddParameter("CaseId", DbType.Decimal, 9, processcasecomplementItem.CaseId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessCaseComplement por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processcasecomplementItems">Lista de instancia de ProcessCaseComplement</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.ProcessCaseComplement> processcasecomplementItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessCaseComplement item in processcasecomplementItems)
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
        /// Elimina un registro en la tabla ProcessCaseComplement por medio de su clave primaria.
        /// </summary>
        /// <param name="caseid">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int caseid, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ProcessCaseComplement " +
                                    "WHERE CaseId=:CaseId AND CompanyId=:CompanyId")
                                .AddParameter("CaseId", DbType.Decimal, 9, caseid)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessCaseComplement por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="caseidList">Lista de Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Delete(List<int> caseidList, int companyId, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (int item in caseidList)
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
        /// Recupera la cantidad de registros existentes en la tabla ProcessCaseComplement por medio de su clave primaria.
        /// </summary>
        /// <param name="caseid">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int caseid, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(CaseId) " +
                                          "FROM ProcessCaseComplement " +
                                         "WHERE CaseId=:CaseId AND CompanyId=:CompanyId")
                               .AddParameter("CaseId", DbType.Decimal, 9, caseid)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessCaseComplement que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(CaseId) " +
                                          "FROM ProcessCaseComplement " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'ProcessCaseComplement'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.ProcessCaseComplement DataReaderToProcessCaseComplement(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.ProcessCaseComplement item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.ProcessCaseComplement();
            }
            item.CaseId = reader.IntegerValue("CaseId");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.Fee = reader.DoubleValue("Fee");
            item.Compensation = reader.DoubleValue("Compensation");
            item.Deductible = reader.DoubleValue("Deductible");
            item.SpareParts = reader.DoubleValue("SpareParts");
            item.ManPower = reader.DoubleValue("ManPower");
            item.Workshop = reader.IntegerValue("Workshop");
            item.ManPowerInvoice = reader.StringValue("ManPowerInvoice");
            item.SparePartsInvoice = reader.StringValue("SparePartsInvoice");
            item.SettlementDate = reader.DateTimeValue("SettlementDate");
            item.AppointmentDate = reader.DateTimeValue("AppointmentDate");
            item.AppointmentTime = reader.StringValue("AppointmentTime");
            item.AssignedAdvisor = reader.StringValue("AssignedAdvisor");
            item.ReportDate = reader.DateTimeValue("ReportDate");
            item.RepairTotalAmount = reader.DoubleValue("RepairTotalAmount");
            item.RepairManPower = reader.DoubleValue("RepairManPower");
            item.RepairSpareParts = reader.DoubleValue("RepairSpareParts");
            item.SetSpaFee = reader.DoubleValue("SetSpaFee");
            item.SetSpaCompensation = reader.DoubleValue("SetSpaCompensation");
            item.SetSpaDeductible = reader.DoubleValue("SetSpaDeductible");
            item.SetSpaSpareParts = reader.DoubleValue("SetSpaSpareParts");
            item.SetSpaManPower = reader.DoubleValue("SetSpaManPower");
            item.SetSpaManPowerInvoice = reader.StringValue("SetSpaManPowerInvoice");
            item.SetSpaSparePartsInvoice = reader.StringValue("SetSpaSparePartsInvoice");
            item.SetSpaSettlementDate = reader.DateTimeValue("SetSpaSettlementDate");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

