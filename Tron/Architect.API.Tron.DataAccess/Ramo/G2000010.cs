using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Ramo
{
    /// <summary>
    /// DATOS VARIABLES.
    /// </summary>
    public static partial class G2000010
    {

        /// <summary>
        /// Recupera una lista de registros en la tabla G2000010.
        /// </summary>
        /// <param name="cod_cia">CODIGO DE COMPAÑIA.</param>
        /// <param name="cod_ramo">RAMO.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de DATOS VARIABLES.</returns>
        public static List<Contracts.Ramo.G2000010> Retrieve(int cod_cia, int cod_ramo, IDbConnection connection = null)
        {
            return RetrieveAll(" WHERE COD_CIA=:COD_CIA AND COD_CAMPO IN (SELECT COD_CAMPO FROM G2000020 WHERE COD_CIA=G2000010.COD_CIA AND COD_RAMO=:COD_RAMO) ORDER BY COD_CAMPO",
                                Database.ParameterList()
                                        .AddParameter("COD_CIA", DbType.Decimal, 2, cod_cia)
                                        .AddParameter("COD_RAMO", DbType.Decimal, 3, cod_ramo).Parameters, connection);
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla G2000010.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de DATOS VARIABLES.</returns>
        public static List<Contracts.Ramo.G2000010> RetrieveAll(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Contracts.Ramo.G2000010> result = new List<Contracts.Ramo.G2000010>();
            Database.Select("SELECT COD_CIA, COD_CAMPO, COD_MODULO, COD_TEXTO, NOM_CAMPO, TIP_CAMPO, LNG_CAMPO, COD_SISTEMA, MCA_INH, MCA_SINI, MCA_OBLIGATORIO, MCA_VALIDACION, NOM_PRG_PRE_CAMPO, NOM_PRG_CAMPO, VAL_DEFECTO, NOM_PGM_HELP, COD_VERSION, NOM_GLOBAL_PGM_HELP, NOM_TABLA_VALIDA, COD_USR, FEC_ACTU " +
                              "FROM G2000010" + filter)
                        .AddParameter(parameters)
                        .Query(connection, "Tron", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToG2000010(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'G2000010'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Contracts.Ramo.G2000010 DataReaderToG2000010(System.Data.IDataReader reader, Contracts.Ramo.G2000010 item = null)
        {
            if (item == null)
            {
                item = new Contracts.Ramo.G2000010();
            }
            item.COD_CIA = reader.IntegerValue("COD_CIA");
            item.COD_CAMPO = reader.StringValue("COD_CAMPO");
            item.COD_MODULO = reader.StringValue("COD_MODULO");
            item.COD_TEXTO = reader.IntegerValue("COD_TEXTO");
            item.NOM_CAMPO = reader.StringValue("NOM_CAMPO");
            item.TIP_CAMPO = reader.StringValue("TIP_CAMPO");
            item.LNG_CAMPO = reader.IntegerValue("LNG_CAMPO");
            item.COD_SISTEMA = reader.StringValue("COD_SISTEMA");
            item.MCA_INH = reader.StringValue("MCA_INH");
            item.MCA_SINI = reader.StringValue("MCA_SINI");
            item.MCA_OBLIGATORIO = reader.StringValue("MCA_OBLIGATORIO");
            item.MCA_VALIDACION = reader.StringValue("MCA_VALIDACION");
            item.NOM_PRG_PRE_CAMPO = reader.StringValue("NOM_PRG_PRE_CAMPO");
            item.NOM_PRG_CAMPO = reader.StringValue("NOM_PRG_CAMPO");
            item.VAL_DEFECTO = reader.StringValue("VAL_DEFECTO");
            item.NOM_PGM_HELP = reader.StringValue("NOM_PGM_HELP");
            item.COD_VERSION = reader.IntegerValue("COD_VERSION");
            item.NOM_GLOBAL_PGM_HELP = reader.StringValue("NOM_GLOBAL_PGM_HELP");
            item.NOM_TABLA_VALIDA = reader.StringValue("NOM_TABLA_VALIDA");
            item.COD_USR = reader.StringValue("COD_USR");
            item.FEC_ACTU = reader.DateTimeValue("FEC_ACTU");
            return item;
        }

    }

}

