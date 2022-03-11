using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Permite disponibilizar páginas y enlaces para un proceso.
    /// </summary>
    public sealed partial class ProcessSpecLink
    {

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecLink por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="flowId">Identificación única del proceso.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int LastLinkOrderByFlowId(int companyId, int flowId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(LinkOrder),0) " +
                                          "FROM ProcessSpecLink " +
                                         "WHERE FlowId=:FlowId AND CompanyId=:CompanyId")
                               .AddParameter("FlowId", DbType.Double, 9, flowId)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecLink.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="flowId">Identificación única del proceso.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecLink</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecLink> RetrieveByFlowId(int companyId, int flowId, IDbConnection connection = null)
        {
            return RetrieveAll(companyId,
                " AND ProcessSpecLink.FlowId=:FlowId",
                Database.ParameterList().AddParameter("FlowId", DbType.Double, 9, flowId).Parameters, connection);
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

