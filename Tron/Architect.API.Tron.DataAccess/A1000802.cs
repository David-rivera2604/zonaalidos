using Architect.DataFactory;
using System.Data;

namespace Architect.API.Tron.DataAccess
{
    /// <summary>
    ///  Modificaciones locales de un tercero para una poliza.
    /// </summary>
    public static class A1000802
    {

        public static bool Update(int cod_cia, string num_poliza, int num_spto, string tip_docum, string cod_docum, string num_tarjeta, IDbConnection currentConnection)
        {
            var result = Database.Update("UPDATE A1000802 " +
                                           " SET NUM_TARJETA = :NUM_TARJETA " +
                                         " WHERE COD_CIA = :COD_CIA AND NUM_POLIZA = :NUM_POLIZA AND NUM_SPTO = :NUM_SPTO AND TIP_DOCUM = :TIP_DOCUM AND COD_DOCUM = :COD_DOCUM")
                .AddParameter("NUM_TARJETA", Architect.DataFactory.Enumerations.DbType.String, 20, num_tarjeta)
                .AddParameter("COD_CIA", Architect.DataFactory.Enumerations.DbType.Decimal, 5, cod_cia)
                .AddParameter("NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                .AddParameter("NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, num_spto)
                .AddParameter("TIP_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 3, tip_docum)
                .AddParameter("COD_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 20, cod_docum)
                .Execute(currentConnection, "Tron");
            return result >= 1;
        }

    }
}
