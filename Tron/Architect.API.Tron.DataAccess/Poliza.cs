using Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia;
using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess
{
    public static class Poliza
    {

        /// <summary>
        /// Permite renovar una póliza
        /// </summary>
        public static string Renovar(string num_poliza, IDbConnection connection = null)
        {
            string result = string.Empty;
            List<DataFactory.Contracts.Parameter> parameters = Database.ParameterList()
                        .AddParameter("P_NUM_POLIZA", DbType.AnsiString, 13, num_poliza)
                        .AddParameter("P_TXT_ERROR", DbType.String, 600, "", ParameterDirection.Output).Parameters;
            Database.Procedure("DC_K_CONSULTA_WEB_AVISOS_MCR.p_modifica_aviso")
                        .AddParameter(parameters)
                        .Execute(connection, "Tron");
            result = parameters.Find(r => r.Name == "P_TXT_ERROR").Value.ToString();
            return result;
        }
    }
}