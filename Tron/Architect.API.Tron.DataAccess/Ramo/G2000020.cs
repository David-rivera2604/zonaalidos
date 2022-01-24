using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Ramo
{
    /// <summary>
    /// DATOS VARIABLES DEL RAMO.
    /// </summary>
    public static partial class G2000020
    {
        /// <summary>
        /// Recupera una lista de registros en la tabla G2000020.
        /// </summary>
        /// <param name="cod_cia">CODIGO DE COMPAÑIA.</param>
        /// <param name="cod_ramo">RAMO.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de COBERTURAS DEL RAMO.</returns>
        public static List<Contracts.Ramo.G2000020> Retrieve(int cod_cia, int cod_ramo, IDbConnection connection = null)
        {
            return RetrieveAll(" WHERE COD_CIA=:COD_CIA AND COD_RAMO=:COD_RAMO ORDER BY NUM_SECU, COD_CAMPO",
                                Database.ParameterList()
                                        .AddParameter("COD_CIA", DbType.Decimal, 2, cod_cia)
                                        .AddParameter("COD_RAMO", DbType.Decimal, 3, cod_ramo).Parameters, connection);
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla G2000020.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de DATOS VARIABLES DEL RAMO.</returns>
        public static List<Contracts.Ramo.G2000020> RetrieveAll(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Contracts.Ramo.G2000020> result = new List<Contracts.Ramo.G2000020>();
            Database.Select("SELECT COD_CIA, COD_RAMO, COD_MODALIDAD, COD_COB, COD_AGR, FEC_VALIDEZ, TIP_NIVEL, NUM_SECU, COD_CAMPO, MCA_INH, MCA_VISIBLE, MCA_OBLIGATORIO, MCA_VALIDA_SI_NULL, MCA_MODALIDAD, MCA_CALCULO, MCA_PRESUPUESTO, MCA_SINI, MCA_UNICO, MCA_INSPEC, MCA_BUSCA_INSP, MCA_BUSCA_POR_IGUAL_INSP, MCA_SOLICITA_EN_COPIA, MCA_GRABA_RECHAZO, MCA_SUMA_ASEG, MCA_VALIDACION, MCA_VALIDACION_CIA, COD_USR, FEC_ACTU, TIP_REGULARIZA, TIP_REGULARIZA_ESP, PCT_REGULARIZA_ESP, COD_INDICE, NOM_PRG_REGULARIZA_ESP, NOM_PRG_PRE_CAMPO, VAL_DEFECTO, NOM_TABLA_VAL_DEFECTO, NOM_CAMPO_TABLA_VAL_DEFECTO, NOM_PGM_HELP, NOM_TABLA_VALIDA, COD_VERSION, NOM_GLOBAL_PGM_HELP, NOM_PRG_CAMPO, COD_LISTA, COD_TRANSPORTES, NUM_SECU_INSP " +
                              "FROM G2000020" + filter)
                        .AddParameter(parameters)
                        .Query(connection, "Tron", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToG2000020(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'G2000020'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Contracts.Ramo.G2000020 DataReaderToG2000020(System.Data.IDataReader reader, Contracts.Ramo.G2000020 item = null)
        {
            if (item == null)
            {
                item = new Contracts.Ramo.G2000020();
            }
            item.COD_CIA = reader.IntegerValue("COD_CIA");
            item.COD_RAMO = reader.IntegerValue("COD_RAMO");
            item.COD_MODALIDAD = reader.IntegerValue("COD_MODALIDAD");
            item.COD_COB = reader.IntegerValue("COD_COB");
            item.COD_AGR = reader.IntegerValue("COD_AGR");
            item.FEC_VALIDEZ = reader.DateTimeValue("FEC_VALIDEZ");
            item.TIP_NIVEL = reader.IntegerValue("TIP_NIVEL");
            item.NUM_SECU = reader.IntegerValue("NUM_SECU");
            item.COD_CAMPO = reader.StringValue("COD_CAMPO");
            item.MCA_INH = reader.StringValue("MCA_INH");
            item.MCA_VISIBLE = reader.StringValue("MCA_VISIBLE");
            item.MCA_OBLIGATORIO = reader.StringValue("MCA_OBLIGATORIO");
            item.MCA_VALIDA_SI_NULL = reader.StringValue("MCA_VALIDA_SI_NULL");
            item.MCA_MODALIDAD = reader.StringValue("MCA_MODALIDAD");
            item.MCA_CALCULO = reader.StringValue("MCA_CALCULO");
            item.MCA_PRESUPUESTO = reader.StringValue("MCA_PRESUPUESTO");
            item.MCA_SINI = reader.StringValue("MCA_SINI");
            item.MCA_UNICO = reader.StringValue("MCA_UNICO");
            item.MCA_INSPEC = reader.StringValue("MCA_INSPEC");
            item.MCA_BUSCA_INSP = reader.StringValue("MCA_BUSCA_INSP");
            item.MCA_BUSCA_POR_IGUAL_INSP = reader.StringValue("MCA_BUSCA_POR_IGUAL_INSP");
            item.MCA_SOLICITA_EN_COPIA = reader.StringValue("MCA_SOLICITA_EN_COPIA");
            item.MCA_GRABA_RECHAZO = reader.StringValue("MCA_GRABA_RECHAZO");
            item.MCA_SUMA_ASEG = reader.StringValue("MCA_SUMA_ASEG");
            item.MCA_VALIDACION = reader.StringValue("MCA_VALIDACION");
            item.MCA_VALIDACION_CIA = reader.StringValue("MCA_VALIDACION_CIA");
            item.COD_USR = reader.StringValue("COD_USR");
            item.FEC_ACTU = reader.DateTimeValue("FEC_ACTU");
            item.TIP_REGULARIZA = reader.StringValue("TIP_REGULARIZA");
            item.TIP_REGULARIZA_ESP = reader.StringValue("TIP_REGULARIZA_ESP");
            item.PCT_REGULARIZA_ESP = reader.Integer64Value("PCT_REGULARIZA_ESP");
            item.COD_INDICE = reader.IntegerValue("COD_INDICE");
            item.NOM_PRG_REGULARIZA_ESP = reader.StringValue("NOM_PRG_REGULARIZA_ESP");
            item.NOM_PRG_PRE_CAMPO = reader.StringValue("NOM_PRG_PRE_CAMPO");
            item.VAL_DEFECTO = reader.StringValue("VAL_DEFECTO");
            item.NOM_TABLA_VAL_DEFECTO = reader.StringValue("NOM_TABLA_VAL_DEFECTO");
            item.NOM_CAMPO_TABLA_VAL_DEFECTO = reader.StringValue("NOM_CAMPO_TABLA_VAL_DEFECTO");
            item.NOM_PGM_HELP = reader.StringValue("NOM_PGM_HELP");
            item.NOM_TABLA_VALIDA = reader.StringValue("NOM_TABLA_VALIDA");
            item.COD_VERSION = reader.IntegerValue("COD_VERSION");
            item.NOM_GLOBAL_PGM_HELP = reader.StringValue("NOM_GLOBAL_PGM_HELP");
            item.NOM_PRG_CAMPO = reader.StringValue("NOM_PRG_CAMPO");
            item.COD_LISTA = reader.IntegerValue("COD_LISTA");
            item.COD_TRANSPORTES = reader.StringValue("COD_TRANSPORTES");
            item.NUM_SECU_INSP = reader.IntegerValue("NUM_SECU_INSP");
            return item;
        }

    }

}

