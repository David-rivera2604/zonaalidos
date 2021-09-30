using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System.Data;

namespace Architect.API.Tron.DataAccess
{
    /// <summary>
    ///  Terceros relacionados con la póliza (Tomadores, Asegurados, etc.)
    /// </summary>
    public static class A1001331
    {

        public static bool Exist(string tip_docum, string cod_docum, IDbConnection currentConnection)
        {
            string result = Database.Select("SELECT COD_DOCUM" +
                                             " FROM A1001331 " +
                                            " WHERE TIP_DOCUM=:TIP_DOCUM" +
                                              " AND COD_DOCUM=:COD_DOCUM")
                            .AddParameter("P_TIP_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 3, tip_docum)
                            .AddParameter("P_COD_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 20, cod_docum)
                            .QueryScalar<string>(currentConnection, "Tron");
            return result.IsNotEmpty();
        }

        public static bool P_Actualiza_Terceros(Architect.API.Tron.Contracts.Poliza.DetalleDeTercero tercero, IDbConnection currentConnection)
        {
            return (Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.P_ACTUALIZA_TERCEROS")
                        .Parameter("P_COD_PAIS", Architect.DataFactory.Enumerations.DbType.String, 3, tercero.cod_pais)
                        .Parameter("P_TIP_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 3, tercero.tip_docum)
                        .Parameter("P_COD_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 20, tercero.cod_docum)
                        .Parameter("P_COD_EST_CIVIL", Architect.DataFactory.Enumerations.DbType.String, 1, tercero.cod_est_civil)
                        .Parameter("P_COD_ESTADO", Architect.DataFactory.Enumerations.DbType.String, 3, tercero.cod_estado)
                        .Parameter("P_COD_PROV", Architect.DataFactory.Enumerations.DbType.String, 6, tercero.cod_prov)
                        .Parameter("P_COD_LOCALIDAD", Architect.DataFactory.Enumerations.DbType.String, 6, tercero.cod_localidad)
                        .Parameter("P_NOM_DOMICILIO1", Architect.DataFactory.Enumerations.DbType.String, 120, tercero.nom_domicilio1)
                        .Parameter("P_TLF_NUMERO", Architect.DataFactory.Enumerations.DbType.String, 10, tercero.tlf_numero)
                        .Parameter("P_EMAIL", Architect.DataFactory.Enumerations.DbType.String, 95, tercero.email)
                        .Execute(currentConnection) != 0);
        }

    }
}
