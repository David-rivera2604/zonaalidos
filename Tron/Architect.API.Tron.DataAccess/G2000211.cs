using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System.Data;

namespace Architect.API.Tron.DataAccess
{
    /// <summary>
    /// DESCRIPCION DE ERRORES DE CONTROL TECNICO.
    /// </summary>
    public static class G2000211
    {

        /// <summary>
        ///Devuelve la descripcion del error segun su codigo.
        /// </summary>
        public static string DescripcionPorCodigo(int cod_cia, int cod_error, IDbConnection connection = null)
        {
            return (string)Database.Select(
@"SELECT NOM_ERROR 
    FROM G2000211 
   WHERE COD_CIA=:COD_CIA AND COD_ERROR=:COD_ERROR")
                        .AddParameter("COD_CIA", DataFactory.Enumerations.DbType.Decimal, 5, cod_cia)
                        .AddParameter("COD_ERROR", DataFactory.Enumerations.DbType.Decimal, 4, cod_error)
                        .QueryScalar<string>(connection, "Tron");
        }

    }
}
