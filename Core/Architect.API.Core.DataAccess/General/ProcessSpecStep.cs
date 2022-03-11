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
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecStep por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="flowId">Identificación única del proceso.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int LastStepOrderByFlowId(int companyId, int flowId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(StepOrder),0) " +
                                          "FROM ProcessSpecStep " +
                                         "WHERE FlowId=:FlowId AND CompanyId=:CompanyId")
                               .AddParameter("FlowId", DbType.Double, 9, flowId)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecStep.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="flowId">Identificación única del proceso.</param>
        /// <returns>Lista de instancias de ProcessSpecStep</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecStep> RetrieveByFlowId(int companyId, int flowId, IDbConnection connection = null)
        {
            return RetrieveAll(companyId,
                " AND ProcessSpecStep.FlowId=:FlowId",
                Database.ParameterList().AddParameter("FlowId", DbType.Double, 9, flowId).Parameters, connection);
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecStep.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecStep</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecStep> RetrieveFull(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
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
                            "SELECT ProcessSpecStep.Id, FlowId, ProcessSpecStep.CompanyId, ProcessSpecStep.Name, ProcessSpecStep.Description, SLATimeOut, StepOrder, ProcessStatus, ProcessLabel, EnableComment, ProgressMode, SLA, ProcessSpecStep.MailServer, MailToContact, MailToContactCustom, MailToContactTmpl, MailToStepResponsible, MailToStepResponsibleCustom, MailToStepResponsibleTmpl, MailForSLAExpiration, MailForSLAExpirationCustom, MailForSLAExpirationTmpl, PreScript, PostScript, ProcessSpecStep.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecStep.UpdateDate " +
                                   ", Flow.Name FlowIdDesc" +
                                   ", ROW_NUMBER() OVER (ORDER BY StepOrder) RowNumber " +
                              "FROM ProcessSpecStep LEFT JOIN UserMember um ON um.UserId = ProcessSpecStep.UpdateUserCode " +
                              "LEFT JOIN ProcessSpecFlow flow ON flow.Id=ProcessSpecStep.FlowId " +
                             "WHERE ProcessSpecStep.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecStep(reader,
                                    new Architect.API.Core.Contracts.General.ProcessSpecStep()
                                    {
                                        FlowIdDesc = reader.StringValue("FlowIdDesc")
                                    }));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla ProcessSpecStep por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del paso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ProcessSpecStep</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecStep RetrieveFull(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.ProcessSpecStep result = null;
            Database.Select("SELECT ProcessSpecStep.Id, FlowId, ProcessSpecStep.CompanyId, ProcessSpecStep.Name, ProcessSpecStep.Description, SLATimeOut, StepOrder, ProcessStatus, ProcessLabel, EnableComment, ProgressMode, SLA, ProcessSpecStep.MailServer, MailToContact, MailToContactCustom, MailToContactTmpl, MailToStepResponsible, MailToStepResponsibleCustom, MailToStepResponsibleTmpl, MailForSLAExpiration, MailForSLAExpirationCustom, MailForSLAExpirationTmpl, PreScript, PostScript, ProcessSpecStep.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecStep.UpdateDate " +
                                 ", Flow.Name FlowIdDesc " +
                              "FROM ProcessSpecStep LEFT JOIN UserMember um ON um.UserId = ProcessSpecStep.UpdateUserCode " +
                              "LEFT JOIN ProcessSpecFlow flow ON flow.Id=ProcessSpecStep.FlowId " +
                             "WHERE ProcessSpecStep.Id=:Id AND ProcessSpecStep.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToProcessSpecStep(reader,
                                    new Architect.API.Core.Contracts.General.ProcessSpecStep()
                                    {
                                        FlowIdDesc = reader.StringValue("FlowIdDesc")
                                    });
                        }));
            return result;
        }

        /// <summary>
        /// Genera complemento del query para habilitar el filtro por columnas establecidas.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros.</param>
        /// <param name="where">Indica que el complement debe incluir el WHERE del comando.</param>
        /// <returns>Complemento del query</returns>
        public static string FilterBuilderEx(string filter, bool includeWhere = true)
        {
            string result = string.Empty;

            if (filter.IsNotEmpty())
            {
                Dictionary<string, string> values = ("search=" + filter).ToDictionary(':', '=');
                if (values["search"].IsNotEmpty())
                {
                    result += "(" +
                              " UPPER(ProcessSpecStep.Name) LIKE '%" + values["search"].ToUpper() + "%' " +
                              " OR UPPER(ProcessSpecStep.Description) LIKE '%" + values["search"].ToUpper() + "%' " +
                              ")";
                }
                if (values.ContainsKey("status"))
                {
                    if (result.IsNotEmpty())
                    {
                        result += " AND ";
                    }
                    result += " Status  IN (" + values["status"] + ") ";
                }
                if (includeWhere)
                {
                    result = " WHERE " + result;
                }
                else
                {
                    result = " AND " + result;
                }
            }
            return result;
        }

        /// <summary>
        /// Genera complemento del query para habilitar el filtro por columnas establecidas.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros.</param>
        /// <param name="where">Indica que el complement debe incluir el WHERE del comando.</param>
        /// <returns>Complemento del query</returns>
        public static string FilterBuilderFull(string filter, bool includeWhere = true)
        {
            string result = string.Empty;

            if (filter.IsNotEmpty())
            {
                Dictionary<string, string> values = ("search=" + filter).ToDictionary(':', '=');
                if (values["search"].IsNotEmpty())
                {
                    result += "(" +
                              " UPPER(Name) LIKE '%" + values["search"].ToUpper() + "%' " +
                              " OR UPPER(Description) LIKE '%" + values["search"].ToUpper() + "%' " +
                              " OR UPPER(Alias) LIKE '%" + values["search"].ToUpper() + "%' " +
                              " OR UPPER(Flow.Name) LIKE '%" + values["search"].ToUpper() + "%' " +
                              ")";
                }
                if (values.ContainsKey("flowId"))
                {
                    if (result.IsNotEmpty())
                    {
                        result += " AND ";
                    }
                    result += " FlowId IN (" + values["flowId"] + ") ";
                }
                if (includeWhere)
                {
                    result = " WHERE " + result;
                }
                else
                {
                    result = " AND " + result;
                }
            }
            return result;
        }
    }

}

