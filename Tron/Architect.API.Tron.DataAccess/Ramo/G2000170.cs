using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Ramo
{
    /// <summary>
    /// CONCEPTOS DE DESGLOSE.
    /// </summary>
    public static partial class G2000170
    {


        /// <summary>
        /// Recupera una lista de registros en la tabla G2000170.
        /// </summary>
        /// <param name="cod_cia">CODIGO DE COMPAÑIA.</param>
        /// <param name="cod_ramo">RAMO.</param>
        /// <param name="cod_modalidad">MODALIDAD DE VIDA.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de CONCEPTOS DE DESGLOSE.</returns>
        public static List<Contracts.Ramo.G2000170> Retrieve(int cod_cia, int cod_ramo, int cod_modalidad, IDbConnection connection = null)
        {
            return RetrieveAll(" WHERE COD_CIA=:COD_CIA AND COD_DESGLOSE in (SELECT COD_DESGLOSE FROM G2000180 WHERE COD_CIA=G2000170.COD_CIA AND COD_RAMO=:COD_RAMO AND COD_MODALIDAD=:COD_MODALIDAD)",
                                Database.ParameterList()
                                        .AddParameter("COD_CIA", DbType.Decimal, 2, cod_cia)
                                        .AddParameter("COD_RAMO", DbType.Decimal, 3, cod_ramo)
                                        .AddParameter("COD_MODALIDAD", DbType.Decimal, 5, cod_modalidad).Parameters, connection);
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla G2000170.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de CONCEPTOS DE DESGLOSE.</returns>
        public static List<Contracts.Ramo.G2000170> RetrieveAll(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Contracts.Ramo.G2000170> result = new List<Contracts.Ramo.G2000170>();
            Database.Select("SELECT COD_CIA, COD_DESGLOSE, NOM_DESGLOSE, NOM_COR_DESGLOSE, TIP_AMBITO, MCA_ESTUDIO, TIP_BASE_CALCULO, TIP_CALCULO, TASA_CALCULO, IMP_CALCULO, NOM_PRG_CALCULO, MCA_DEVUELVE, MCA_APLICA_PRORRATA, MCA_CALCULO_AUTOMATICO, COD_ECO, MCA_DEPOSITA_CALCULO_C0, MCA_DEPOSITA_CALCULO_C1, MCA_DEPOSITA_CALCULO_C2, MCA_DEPOSITA_CALCULO_C3, MCA_DEPOSITA_CALCULO_C4, MCA_DEPOSITA_CALCULO_C5, MCA_DEPOSITA_CALCULO_C6, MCA_DEPOSITA_CALCULO_C7, MCA_DEPOSITA_CALCULO_C8, MCA_DEPOSITA_CALCULO_C9, MCA_DEPOSITA_CALCULO_R0, MCA_DEPOSITA_CALCULO_R1, MCA_DEPOSITA_CALCULO_R2, MCA_DEPOSITA_CALCULO_R3, MCA_DEPOSITA_CALCULO_R4, MCA_DEPOSITA_CALCULO_P0, MCA_DEPOSITA_CALCULO_P1, MCA_DEPOSITA_CALCULO_P2, MCA_DEPOSITA_CALCULO_P3, MCA_DEPOSITA_CALCULO_P4, MCA_DEPOSITA_CALCULO_T0, MCA_DEPOSITA_CALCULO_T1, MCA_DEPOSITA_CALCULO_T2, MCA_DEPOSITA_CALCULO_T3, MCA_DEPOSITA_CALCULO_T4, COD_USR, FEC_ACTU, FEC_VALIDEZ, NOM_PRG_NO_CONSUMIDO " +
                              "FROM G2000170" + filter)
                        .AddParameter(parameters)
                        .Query(connection, "Tron", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToG2000170(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'G2000170'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Contracts.Ramo.G2000170 DataReaderToG2000170(System.Data.IDataReader reader, Contracts.Ramo.G2000170 item = null)
        {
            if (item == null)
            {
                item = new Contracts.Ramo.G2000170();
            }
            item.COD_CIA = reader.IntegerValue("COD_CIA");
            item.COD_DESGLOSE = reader.IntegerValue("COD_DESGLOSE");
            item.NOM_DESGLOSE = reader.StringValue("NOM_DESGLOSE");
            item.NOM_COR_DESGLOSE = reader.StringValue("NOM_COR_DESGLOSE");
            item.TIP_AMBITO = reader.StringValue("TIP_AMBITO");
            item.MCA_ESTUDIO = reader.StringValue("MCA_ESTUDIO");
            item.TIP_BASE_CALCULO = reader.StringValue("TIP_BASE_CALCULO");
            item.TIP_CALCULO = reader.StringValue("TIP_CALCULO");
            item.TASA_CALCULO = reader.Integer64Value("TASA_CALCULO");
            item.IMP_CALCULO = reader.Integer64Value("IMP_CALCULO");
            item.NOM_PRG_CALCULO = reader.StringValue("NOM_PRG_CALCULO");
            item.MCA_DEVUELVE = reader.StringValue("MCA_DEVUELVE");
            item.MCA_APLICA_PRORRATA = reader.StringValue("MCA_APLICA_PRORRATA");
            item.MCA_CALCULO_AUTOMATICO = reader.StringValue("MCA_CALCULO_AUTOMATICO");
            item.COD_ECO = reader.IntegerValue("COD_ECO");
            item.MCA_DEPOSITA_CALCULO_C0 = reader.StringValue("MCA_DEPOSITA_CALCULO_C0");
            item.MCA_DEPOSITA_CALCULO_C1 = reader.StringValue("MCA_DEPOSITA_CALCULO_C1");
            item.MCA_DEPOSITA_CALCULO_C2 = reader.StringValue("MCA_DEPOSITA_CALCULO_C2");
            item.MCA_DEPOSITA_CALCULO_C3 = reader.StringValue("MCA_DEPOSITA_CALCULO_C3");
            item.MCA_DEPOSITA_CALCULO_C4 = reader.StringValue("MCA_DEPOSITA_CALCULO_C4");
            item.MCA_DEPOSITA_CALCULO_C5 = reader.StringValue("MCA_DEPOSITA_CALCULO_C5");
            item.MCA_DEPOSITA_CALCULO_C6 = reader.StringValue("MCA_DEPOSITA_CALCULO_C6");
            item.MCA_DEPOSITA_CALCULO_C7 = reader.StringValue("MCA_DEPOSITA_CALCULO_C7");
            item.MCA_DEPOSITA_CALCULO_C8 = reader.StringValue("MCA_DEPOSITA_CALCULO_C8");
            item.MCA_DEPOSITA_CALCULO_C9 = reader.StringValue("MCA_DEPOSITA_CALCULO_C9");
            item.MCA_DEPOSITA_CALCULO_R0 = reader.StringValue("MCA_DEPOSITA_CALCULO_R0");
            item.MCA_DEPOSITA_CALCULO_R1 = reader.StringValue("MCA_DEPOSITA_CALCULO_R1");
            item.MCA_DEPOSITA_CALCULO_R2 = reader.StringValue("MCA_DEPOSITA_CALCULO_R2");
            item.MCA_DEPOSITA_CALCULO_R3 = reader.StringValue("MCA_DEPOSITA_CALCULO_R3");
            item.MCA_DEPOSITA_CALCULO_R4 = reader.StringValue("MCA_DEPOSITA_CALCULO_R4");
            item.MCA_DEPOSITA_CALCULO_P0 = reader.StringValue("MCA_DEPOSITA_CALCULO_P0");
            item.MCA_DEPOSITA_CALCULO_P1 = reader.StringValue("MCA_DEPOSITA_CALCULO_P1");
            item.MCA_DEPOSITA_CALCULO_P2 = reader.StringValue("MCA_DEPOSITA_CALCULO_P2");
            item.MCA_DEPOSITA_CALCULO_P3 = reader.StringValue("MCA_DEPOSITA_CALCULO_P3");
            item.MCA_DEPOSITA_CALCULO_P4 = reader.StringValue("MCA_DEPOSITA_CALCULO_P4");
            item.MCA_DEPOSITA_CALCULO_T0 = reader.StringValue("MCA_DEPOSITA_CALCULO_T0");
            item.MCA_DEPOSITA_CALCULO_T1 = reader.StringValue("MCA_DEPOSITA_CALCULO_T1");
            item.MCA_DEPOSITA_CALCULO_T2 = reader.StringValue("MCA_DEPOSITA_CALCULO_T2");
            item.MCA_DEPOSITA_CALCULO_T3 = reader.StringValue("MCA_DEPOSITA_CALCULO_T3");
            item.MCA_DEPOSITA_CALCULO_T4 = reader.StringValue("MCA_DEPOSITA_CALCULO_T4");
            item.COD_USR = reader.StringValue("COD_USR");
            item.FEC_ACTU = reader.DateTimeValue("FEC_ACTU");
            item.FEC_VALIDEZ = reader.DateTimeValue("FEC_VALIDEZ");
            item.NOM_PRG_NO_CONSUMIDO = reader.StringValue("NOM_PRG_NO_CONSUMIDO");
            return item;
        }

    }

}

