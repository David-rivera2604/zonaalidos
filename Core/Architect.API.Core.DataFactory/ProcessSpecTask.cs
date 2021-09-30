using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Tareas vinculadas a un paso o estado de un proceso.
    /// </summary>
    public static partial class ProcessSpecTask
    {

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecTask.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="stepId">Identificación única del paso.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecTask</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecTask> RetrieveByStepId(int companyId, int stepId, IDbConnection connection = null)
        {
            return RetrieveAll(companyId,
                " AND ProcessSpecTask.StepId=:StepId",
                Database.ParameterList().AddParameter("StepId", DbType.Double, 9, stepId).Parameters, connection);
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecTask.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecTask</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecTask> RetrieveFull(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecTask> result = new List<Architect.API.Core.Contracts.General.ProcessSpecTask>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT ProcessSpecTask.Id, StepId, ProcessSpecTask.CompanyId, ProcessSpecTask.Name, ProcessSpecTask.Description, ProcessSpecTask.SLATimeOut, IsRequired, IsSelected, TaskOrder, Type, Action, ProcessSpecTask.PreScript, ProcessSpecTask.PostScript, SubStatus, SubLabel, ProcessSpecTask.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecTask.UpdateDate" +
                                   ", Flow.Id FlowId, Flow.Name FlowIdDesc, step.Name StepIdDesc" +
                                   ", ROW_NUMBER() OVER (ORDER BY Flow.Name, step.StepOrder, TaskOrder) RowNumber " +
                              "FROM ProcessSpecTask LEFT JOIN UserMember um ON um.UserId = ProcessSpecTask.UpdateUserCode " +
                              "LEFT JOIN ProcessSpecStep step ON step.Id=ProcessSpecTask.StepId " +
                              "LEFT JOIN ProcessSpecFlow flow ON flow.Id=step.FlowId " +
                             "WHERE ProcessSpecTask.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecTask(reader,
                                    new Architect.API.Core.Contracts.General.ProcessSpecTask()
                                    {
                                        StepIdDesc = reader.StringValue("StepIdDesc"),
                                        FlowId = reader.IntegerValue("FlowId"),
                                        FlowIdDesc = reader.StringValue("FlowIdDesc")
                                    }));
                        }));
            return result;
        }


        /// <summary>
        /// Recupera un registro en la tabla ProcessSpecTask por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la tarea.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ProcessSpecTask</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecTask RetrieveFull(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.ProcessSpecTask result = null;
            Database.Select("SELECT ProcessSpecTask.Id, StepId, ProcessSpecTask.CompanyId, ProcessSpecTask.Name, ProcessSpecTask.Description, ProcessSpecTask.SLATimeOut, IsRequired, IsSelected, TaskOrder, Type, Action, SubStatus, SubLabel, ProcessSpecTask.PreScript, ProcessSpecTask.PostScript, ProcessSpecTask.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecTask.UpdateDate " +
                                    ", Flow.Id FlowId, Flow.Name FlowIdDesc, step.Name StepIdDesc " +
                              "FROM ProcessSpecTask LEFT JOIN UserMember um ON um.UserId = ProcessSpecTask.UpdateUserCode " +
                              "LEFT JOIN ProcessSpecStep step ON step.Id=ProcessSpecTask.StepId " +
                              "LEFT JOIN ProcessSpecFlow flow ON flow.Id=step.FlowId " +
                             "WHERE ProcessSpecTask.Id=:Id AND ProcessSpecTask.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToProcessSpecTask(reader,
                                    new Architect.API.Core.Contracts.General.ProcessSpecTask()
                                    {
                                        StepIdDesc = reader.StringValue("StepIdDesc"),
                                        FlowId = reader.IntegerValue("FlowId"),
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
                if (includeWhere)
                {
                    result = " WHERE ";
                }
                else
                {
                    result = " AND ";
                }

                result += "(";
                result += " UPPER(ProcessSpecTask.StepId) LIKE '%" + filter.ToUpper() + "%' ";

                result += ")";
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
                    result += "(";
                    result += " UPPER(ProcessSpecTask.Name) LIKE '%" + values["search"].ToUpper() + "%' ";
                    result += " OR UPPER(ProcessSpecTask.Description) LIKE '%" + values["search"].ToUpper() + "%' ";
                    result += " OR UPPER(Flow.Name) LIKE '%" + values["search"].ToUpper() + "%' ";
                    result += " OR UPPER(step.Name) LIKE '%" + values["search"].ToUpper() + "%' ";
                    result += ")";
                }

                if (values.ContainsKey("flowId"))
                {
                    if (result.IsNotEmpty())
                    {
                        result += " AND ";
                    }
                    result += " Flow.Id  IN (" + values["flowId"] + ") ";
                }

                if (values.ContainsKey("stepId"))
                {
                    if (result.IsNotEmpty())
                    {
                        result += " AND ";
                    }
                    result += " StepId  IN (" + values["stepId"] + ") ";
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

