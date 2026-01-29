using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Pasos o estados de un proceso.
    /// </summary>
    public sealed partial class ProcessSpecStep
    {

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecStep.
        /// </summary>
        /// <param name="processspecstepItem">Instancia de ProcessSpecStep</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.ProcessSpecStep processspecstepItem, IDbConnection connection = null)
        {
            if (processspecstepItem.UpdateDate.IsEmpty())
            {
                processspecstepItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO ProcessSpecStep (Id, FlowId, CompanyId, Name, Description, StepOrder, ProcessStatus, ProcessLabel, EnableComment, ProgressMode, SLA, SLODuration, MailServer, MailToContact, MailToContactCustom, MailToContactTmpl, MailToStepResponsible, MailToStepResponsibleCustom, MailToStepResponsibleTmpl, PreScript, PostScript, References, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :FlowId, :CompanyId, :Name, :Description, :StepOrder, :ProcessStatus, :ProcessLabel, :EnableComment, :ProgressMode, :SLA, :SLODuration, :MailServer, :MailToContact, :MailToContactCustom, :MailToContactTmpl, :MailToStepResponsible, :MailToStepResponsibleCustom, :MailToStepResponsibleTmpl, :PreScript, :PostScript, :References, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, processspecstepItem.Id)
                            .AddParameter("FlowId", DbType.Decimal, 9, processspecstepItem.FlowId)
                            .AddParameter("CompanyId", DbType.Decimal, 5, processspecstepItem.CompanyId)
                            .AddParameter("Name", DbType.AnsiString, 80, processspecstepItem.Name)
                            .AddParameter("Description", DbType.AnsiString, 256, processspecstepItem.Description)
                            .AddParameter("StepOrder", DbType.Decimal, 5, processspecstepItem.StepOrder)
                            .AddParameter("ProcessStatus", DbType.Decimal, 3, processspecstepItem.ProcessStatus)
                            .AddParameter("ProcessLabel", DbType.AnsiString, 80, processspecstepItem.ProcessLabel)
                            .AddParameter("EnableComment", DbType.Decimal, 1, processspecstepItem.EnableComment ? 1 : 0)
                            .AddParameter("ProgressMode", DbType.Decimal, 3, processspecstepItem.ProgressMode)
                            .AddParameter("SLA", DbType.Decimal, 5, processspecstepItem.SLA)
                            .AddParameter("SLODuration", DbType.Decimal, 5, processspecstepItem.SLODuration)
                            .AddParameter("MailServer", DbType.Decimal, 5, processspecstepItem.MailServer)
                            .AddParameter("MailToContact", DbType.Decimal, 5, processspecstepItem.MailToContact)
                            .AddParameter("MailToContactCustom", DbType.AnsiString, 256, processspecstepItem.MailToContactCustom)
                            .AddParameter("MailToContactTmpl", DbType.Decimal, 5, processspecstepItem.MailToContactTmpl)
                            .AddParameter("MailToStepResponsible", DbType.Decimal, 5, processspecstepItem.MailToStepResponsible)
                            .AddParameter("MailToStepResponsibleCustom", DbType.AnsiString, 256, processspecstepItem.MailToStepResponsibleCustom)
                            .AddParameter("MailToStepResponsibleTmpl", DbType.Decimal, 5, processspecstepItem.MailToStepResponsibleTmpl)
                            .AddParameter("PreScript", DbType.AnsiString, 9, processspecstepItem.PreScript)
                            .AddParameter("PostScript", DbType.AnsiString, 9, processspecstepItem.PostScript)
                            .AddParameter("References", DbType.AnsiString, 1024, processspecstepItem.References)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspecstepItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, processspecstepItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla ProcessSpecStep.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspecstepItems">Lista de instancia de ProcessSpecStep</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.ProcessSpecStep> processspecstepItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessSpecStep item in processspecstepItems)
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
        /// Recupera un registro en la tabla ProcessSpecStep por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del paso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ProcessSpecStep</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecStep Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.ProcessSpecStep result = null;
            Database.Select("SELECT Id, FlowId, ProcessSpecStep.CompanyId, Name, Description, StepOrder, ProcessStatus, ProcessLabel, EnableComment, ProgressMode, SLA, SLODuration, MailServer, MailToContact, MailToContactCustom, MailToContactTmpl, MailToStepResponsible, MailToStepResponsibleCustom, MailToStepResponsibleTmpl, PreScript, PostScript, References, ProcessSpecStep.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecStep.UpdateDate " +
                              "FROM ProcessSpecStep LEFT JOIN UserMember um ON um.UserId = ProcessSpecStep.UpdateUserCode " +
                             "WHERE ProcessSpecStep.Id=:Id AND ProcessSpecStep.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToProcessSpecStep(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecStep.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecStep</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecStep> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecStep> result = new List<Architect.API.Core.Contracts.General.ProcessSpecStep>();
            Database.Select("SELECT Id, FlowId, ProcessSpecStep.CompanyId, Name, Description, StepOrder, ProcessStatus, ProcessLabel, EnableComment, ProgressMode, SLA, SLODuration, MailServer, MailToContact, MailToContactCustom, MailToContactTmpl, MailToStepResponsible, MailToStepResponsibleCustom, MailToStepResponsibleTmpl, PreScript, PostScript, References, ProcessSpecStep.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecStep.UpdateDate " +
                              "FROM ProcessSpecStep LEFT JOIN UserMember um ON um.UserId = ProcessSpecStep.UpdateUserCode " +
                             "WHERE ProcessSpecStep.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecStep(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecStep.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecStep</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecStep> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecStep> result = new List<Architect.API.Core.Contracts.General.ProcessSpecStep>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, FlowId, ProcessSpecStep.CompanyId, Name, Description, StepOrder, ProcessStatus, ProcessLabel, EnableComment, ProgressMode, SLA, SLODuration, MailServer, MailToContact, MailToContactCustom, MailToContactTmpl, MailToStepResponsible, MailToStepResponsibleCustom, MailToStepResponsibleTmpl, PreScript, PostScript, References, ProcessSpecStep.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecStep.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY ProcessSpecStep.Id DESC) RowNumber " +
                              "FROM ProcessSpecStep LEFT JOIN UserMember um ON um.UserId = ProcessSpecStep.UpdateUserCode " +
                             "WHERE ProcessSpecStep.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecStep(reader));
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

            if (filter.IsNotEmpty())
            {
                string condition = string.Empty;
                if (filter.IndexOf("|")>-1)
                {
                    condition = filter.Substring( filter.IndexOf("|"));
                    filter = filter.Substring(0, filter.IndexOf("|"));
                }			
                if (includeWhere)
                {
                    result = " WHERE ";
                }
                else
                {
                    result = " AND ";
                }

                result += "(";
                result += " UPPER(ProcessSpecStep.FlowId) LIKE '%" + filter.ToUpper() + "%' ";

                result += ")";
                if (condition.IsNotEmpty())
                {
                    result += Database.FilterFactory(condition, "ProcessSpecStep");
                }				
            }
            return result;
        }

        /// <summary>
        /// Último valor asignado a clave única de la tabla ProcessSpecStep.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM ProcessSpecStep")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecStep por medio de su clave primaria.
        /// </summary>
        /// <param name="processspecstepItem">Instancia de ProcessSpecStep</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.ProcessSpecStep processspecstepItem, IDbConnection connection = null)
        {
            if (processspecstepItem.UpdateDate.IsEmpty())
            {
                processspecstepItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE ProcessSpecStep " +
                                      "SET FlowId=:FlowId, CompanyId=:CompanyId, Name=:Name, Description=:Description, StepOrder=:StepOrder, ProcessStatus=:ProcessStatus, ProcessLabel=:ProcessLabel, EnableComment=:EnableComment, ProgressMode=:ProgressMode, SLA=:SLA, SLODuration=:SLODuration, MailServer=:MailServer, MailToContact=:MailToContact, MailToContactCustom=:MailToContactCustom, MailToContactTmpl=:MailToContactTmpl, MailToStepResponsible=:MailToStepResponsible, MailToStepResponsibleCustom=:MailToStepResponsibleCustom, MailToStepResponsibleTmpl=:MailToStepResponsibleTmpl, PreScript=:PreScript, PostScript=:PostScript, References=:References, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("FlowId", DbType.Decimal, 9, processspecstepItem.FlowId)
                                .AddParameter("CompanyId", DbType.Decimal, 5, processspecstepItem.CompanyId)
                                .AddParameter("Name", DbType.AnsiString, 80, processspecstepItem.Name)
                                .AddParameter("Description", DbType.AnsiString, 256, processspecstepItem.Description)

                                .AddParameter("StepOrder", DbType.Decimal, 5, processspecstepItem.StepOrder)
                                .AddParameter("ProcessStatus", DbType.Decimal, 3, processspecstepItem.ProcessStatus)
                                .AddParameter("ProcessLabel", DbType.AnsiString, 80, processspecstepItem.ProcessLabel)
                                .AddParameter("EnableComment", DbType.Decimal, 1, processspecstepItem.EnableComment ? 1 : 0)
                                .AddParameter("ProgressMode", DbType.Decimal, 3, processspecstepItem.ProgressMode)
                                .AddParameter("SLA", DbType.Decimal, 5, processspecstepItem.SLA)
                                .AddParameter("SLODuration", DbType.Decimal, 5, processspecstepItem.SLODuration)
                                .AddParameter("MailServer", DbType.Decimal, 5, processspecstepItem.MailServer)
                                .AddParameter("MailToContact", DbType.Decimal, 5, processspecstepItem.MailToContact)
                                .AddParameter("MailToContactCustom", DbType.AnsiString, 256, processspecstepItem.MailToContactCustom)
                                .AddParameter("MailToContactTmpl", DbType.Decimal, 5, processspecstepItem.MailToContactTmpl)
                                .AddParameter("MailToStepResponsible", DbType.Decimal, 5, processspecstepItem.MailToStepResponsible)
                                .AddParameter("MailToStepResponsibleCustom", DbType.AnsiString, 256, processspecstepItem.MailToStepResponsibleCustom)
                                .AddParameter("MailToStepResponsibleTmpl", DbType.Decimal, 5, processspecstepItem.MailToStepResponsibleTmpl)
                                .AddParameter("PreScript", DbType.AnsiString, 9, processspecstepItem.PreScript)
                                .AddParameter("PostScript", DbType.AnsiString, 9, processspecstepItem.PostScript)
                                .AddParameter("References", DbType.AnsiString, 1024, processspecstepItem.References)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspecstepItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, processspecstepItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, processspecstepItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecStep por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspecstepItems">Lista de instancia de ProcessSpecStep</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.ProcessSpecStep> processspecstepItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessSpecStep item in processspecstepItems)
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
        /// Elimina un registro en la tabla ProcessSpecStep por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del paso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ProcessSpecStep " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecStep por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única del paso.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecStep por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del paso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecStep " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecStep que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecStep " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista para selección de la tabla ProcessSpecStep.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookUpValue</returns>
        public static List<Utilities.Contracts.LookUpValue> LookUp(int companyId, IDbConnection connection = null)
        {
            List<Utilities.Contracts.LookUpValue> result = new List<Utilities.Contracts.LookUpValue>();
            Database.Select("SELECT Id, Name " +
                              "FROM ProcessSpecStep WHERE CompanyId=:CompanyId ORDER BY Name")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Utilities.Contracts.LookUpValue()
                            {
                                Code = reader.StringValue("Id"),
                                Description = reader.StringValue("Name")
                            });
                        }));
            return result;
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'ProcessSpecStep'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecStep DataReaderToProcessSpecStep(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.ProcessSpecStep item = null, bool queryExt = false)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.ProcessSpecStep();
            }
            item.Id = reader.IntegerValue("Id");
            item.FlowId = reader.IntegerValue("FlowId");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.Name = reader.StringValue("Name");
            item.Description = reader.StringValue("Description");
            item.StepOrder = reader.IntegerValue("StepOrder");
            item.ProcessStatus = reader.IntegerValue("ProcessStatus");
            item.ProcessLabel = reader.StringValue("ProcessLabel");
            item.EnableComment = reader.IntegerValue("EnableComment") == 1;
            item.ProgressMode = reader.IntegerValue("ProgressMode");
            item.SLA = reader.IntegerValue("SLA");
            item.SLODuration = reader.IntegerValue("SLODuration");
            item.MailServer = reader.IntegerValue("MailServer");
            item.MailToContact = reader.IntegerValue("MailToContact");
            item.MailToContactCustom = reader.StringValue("MailToContactCustom");
            item.MailToContactTmpl = reader.IntegerValue("MailToContactTmpl");
            item.MailToStepResponsible = reader.IntegerValue("MailToStepResponsible");
            item.MailToStepResponsibleCustom = reader.StringValue("MailToStepResponsibleCustom");
            item.MailToStepResponsibleTmpl = reader.IntegerValue("MailToStepResponsibleTmpl");
            item.PreScript = reader.StringValue("PreScript");
            item.PostScript = reader.StringValue("PostScript");
            item.References = reader.StringValue("References");            
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            if (queryExt) { 
            item.RoleNames = reader.StringValue("Roles");
            }
            return item;
        }

    }

}

