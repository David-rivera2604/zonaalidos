using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Ramo
{
    /// <summary>
    /// CONCEPTOS DE DESGLOSE DEL RAMO.
    /// </summary>
    public static partial class G2000180
    {

        /// <summary>
        /// Recupera una lista de registros en la tabla G2000180.
        /// </summary>
        /// <param name="cod_cia">CODIGO DE COMPAÑIA.</param>
        /// <param name="cod_ramo">RAMO.</param>
        /// <param name="cod_modalidad">MODALIDAD DE VIDA.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de CONCEPTOS DE DESGLOSE DEL RAMO.</returns>
        public static List<Contracts.Ramo.G2000180> Retrieve(int cod_cia, int cod_ramo, int cod_modalidad, IDbConnection connection = null)
        {
            return RetrieveAll(" WHERE COD_CIA=:COD_CIA AND COD_RAMO=:COD_RAMO AND COD_MODALIDAD=:COD_MODALIDAD ORDER BY COD_COB, NUM_SECU",
                                Database.ParameterList()
                                        .AddParameter("COD_CIA", DbType.Decimal, 2, cod_cia)
                                        .AddParameter("COD_RAMO", DbType.Decimal, 3, cod_ramo)
                                        .AddParameter("COD_MODALIDAD", DbType.Decimal, 5, cod_modalidad).Parameters, connection);
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla G2000180.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de CONCEPTOS DE DESGLOSE DEL RAMO.</returns>
        public static List<Contracts.Ramo.G2000180> RetrieveAll(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Contracts.Ramo.G2000180> result = new List<Contracts.Ramo.G2000180>();
            Database.Select("SELECT COD_CIA, COD_RAMO, COD_MODALIDAD, COD_COB, NUM_SECU, COD_DESGLOSE, NUM_BLOQUE_ESTUDIO, TIP_APLICACION, FEC_VALIDEZ, COD_USR, FEC_ACTU " +
                              "FROM G2000180" + filter)
                        .AddParameter(parameters)
                        .Query(connection, "Tron", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToG2000180(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'G2000180'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Contracts.Ramo.G2000180 DataReaderToG2000180(System.Data.IDataReader reader, Contracts.Ramo.G2000180 item = null)
        {
            if (item == null)
            {
                item = new Contracts.Ramo.G2000180();
            }
            item.COD_CIA = reader.IntegerValue("COD_CIA");
            item.COD_RAMO = reader.IntegerValue("COD_RAMO");
            item.COD_MODALIDAD = reader.IntegerValue("COD_MODALIDAD");
            item.COD_COB = reader.IntegerValue("COD_COB");
            item.NUM_SECU = reader.IntegerValue("NUM_SECU");
            item.COD_DESGLOSE = reader.IntegerValue("COD_DESGLOSE");
            item.NUM_BLOQUE_ESTUDIO = reader.IntegerValue("NUM_BLOQUE_ESTUDIO");
            item.TIP_APLICACION = reader.StringValue("TIP_APLICACION");
            item.FEC_VALIDEZ = reader.DateTimeValue("FEC_VALIDEZ");
            item.COD_USR = reader.StringValue("COD_USR");
            item.FEC_ACTU = reader.DateTimeValue("FEC_ACTU");
            return item;
        }

    }

}

