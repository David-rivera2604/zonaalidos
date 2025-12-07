using Architect.DataFactory;
using System;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess
{
    /// <summary>
    /// CODIGOS CABYS POR RAMO.
    /// </summary>
    public static class A5029134_MCR
    {
        /// <summary>
        /// Obtiene el código CABYS asociado a una compañía y ramo indicados.
        /// </summary>
        public static string ObtenerCodigoCabysPorRamo(int cod_cia, int cod_ramo, IDbConnection connection = null)
        {
            return (string)Database.Select(
@"SELECT COD_CABYS
    FROM A5029134_MCR
   WHERE COD_CIA = :COD_CIA AND COD_RAMO = :COD_RAMO")
                        .AddParameter("COD_CIA", DbType.Decimal, 5, cod_cia)
                        .AddParameter("COD_RAMO", DbType.Decimal, 5, cod_ramo)
                        .QueryScalar<string>(connection, "Tron");
        }

    }
}
