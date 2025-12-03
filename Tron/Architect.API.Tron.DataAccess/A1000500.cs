using Architect.DataFactory;
using System;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess
{
    /// <summary>
    /// TIPOS DE CAMBIO DE UNA MONEDA.
    /// </summary>
    public static class A1000500
    {
        /// <summary>
        /// Obtiene el último valor de cambio (más reciente por fecha) para la moneda indicada.
        /// </summary>
        public static double ObtenerTasaCambioMasRecientePorMoneda(int codigoMoneda, IDbConnection connection = null)
        {
            return (double)Database.Select(
@"SELECT VAL_CAMBIO
    FROM A1000500
   WHERE COD_MON = :COD_MON
ORDER BY FEC_CAMBIO DESC FETCH FIRST 1 ROWS ONLY")
                        .AddParameter("COD_MON", DbType.Decimal, 5, codigoMoneda)
                        .QueryScalar<decimal>(connection, "Tron");
        }
    }
}
