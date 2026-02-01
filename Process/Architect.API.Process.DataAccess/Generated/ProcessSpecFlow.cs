using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Process.DataAccess.General
{
    /// <summary>
    /// Especificación de un proceso.
    /// </summary>
    public sealed partial class ProcessSpecFlow
    {

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
                              " UPPER(Name) LIKE '%" + values["search"].ToUpper() + "%' " +
                              " OR UPPER(Description) LIKE '%" + values["search"].ToUpper() + "%' " +
                              " OR UPPER(Alias) LIKE '%" + values["search"].ToUpper() + "%' " +
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

    }

}

