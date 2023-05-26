using Architect.DataFactory;
using System;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess
{
    /// <summary>
    /// RECIBOS/CUOTAS DE UNA POLIZA.
    /// </summary>
    public static class A2990700
    {

        public static int RecibosRemesadosPorPoliza(int cod_cia, string num_poliza, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(NUM_RECIBO) " +
                                          "FROM A2990700 " +
                                         "WHERE COD_CIA=:COD_CIA AND NUM_POLIZA=:NUM_POLIZA and TIP_SITUACION='RE'")
                        .AddParameter("COD_CIA", DbType.Decimal, 5, cod_cia)
                        .AddParameter("NUM_POLIZA", DbType.AnsiString, 13, num_poliza)
                        .QueryScalar<Decimal>(connection, "Tron");
        }
    }
}
