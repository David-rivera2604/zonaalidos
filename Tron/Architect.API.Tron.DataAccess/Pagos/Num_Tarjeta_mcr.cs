using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System.Data;

namespace Architect.API.Tron.DataAccess.Pagos
{
    /// <summary>
    ///  Registro de números de tarjeta de crédito cifrado
    /// </summary>
    public static class Num_Tarjeta_mcr
    {

        public static bool Update(int cod_cia, string tip_docum, string cod_docum, string num_tarjeta, IDbConnection currentConnection)
        {
            var result = Database.Update("UPDATE NUM_TARJETA_MCR " +
                                           " SET NUM_TARJETA_ORIGINAL = :NUM_TARJETA, " +
                                               " NUM_TARJETA_VISTA = :NUM_TARJETAV, " +
                                               " FEC_ACTU = SYSDATE" +
                                         " WHERE COD_CIA = :COD_CIA AND TIP_DOCUM = :TIP_DOCUM AND COD_DOCUM = :COD_DOCUM")
                .AddParameter("NUM_TARJETA", Architect.DataFactory.Enumerations.DbType.String, 20, num_tarjeta)
                .AddParameter("NUM_TARJETAV", Architect.DataFactory.Enumerations.DbType.String, 20, num_tarjeta)
                .AddParameter("COD_CIA", Architect.DataFactory.Enumerations.DbType.Decimal, 5, cod_cia)
                .AddParameter("TIP_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 3, tip_docum)
                .AddParameter("COD_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 20, cod_docum)
                .Execute(currentConnection, "Tron");
            return result >= 1;
        }

    }
}
