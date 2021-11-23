using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    public static partial class WhiteList
    {

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla WhiteList para una dirección IP.
        /// </summary>
        /// <param name="ipAddress">Dirección IP/Nombre de la maquina donde se hizo la solicitud.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int CountByIPAddress(string ipAddress, IDbConnection connection = null)
        {

            return Count(" WHERE IPAddress=:IPAddress",
                            Database.ParameterList()
                            .AddParameter("IPAddress", DbType.AnsiString, 20, ipAddress).Parameters, connection);
        }


    }

}

