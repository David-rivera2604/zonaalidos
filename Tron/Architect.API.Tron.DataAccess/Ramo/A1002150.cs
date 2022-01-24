using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Ramo
{
    /// <summary>
    /// COBERTURAS DEL RAMO.
    /// </summary>
    public static partial class A1002150
    {

        /// <summary>
        /// Recupera un registro en la tabla A1002150 por medio de su clave primaria.
        /// </summary>
        /// <param name="cod_cia">CODIGO DE COMPAÑIA.</param>
        /// <param name="cod_ramo">RAMO.</param>
        /// <param name="cod_modalidad">MODALIDAD DE VIDA.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de COBERTURAS DEL RAMO.</returns>
        public static List<Contracts.Ramo.A1002150> Retrieve(int cod_cia, int cod_ramo, int cod_modalidad, IDbConnection connection = null)
        {
            return RetrieveAll(" WHERE COD_CIA=:COD_CIA AND COD_RAMO=:COD_RAMO AND COD_MODALIDAD=:COD_MODALIDAD AND MCA_INH='N'",
                                Database.ParameterList()
                                        .AddParameter("COD_CIA", DbType.Decimal, 2, cod_cia)
                                        .AddParameter("COD_RAMO", DbType.Decimal, 3, cod_ramo)
                                        .AddParameter("COD_MODALIDAD", DbType.Decimal, 5, cod_modalidad).Parameters, connection);
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla A1002150.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de COBERTURAS DEL RAMO.</returns>
        public static List<Contracts.Ramo.A1002150> RetrieveAll(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Contracts.Ramo.A1002150> result = new List<Contracts.Ramo.A1002150>();
            Database.Select("SELECT COD_CIA, COD_RAMO, COD_MODALIDAD, NUM_SECU, COD_COB, NOM_COB, COD_MON_CAPITAL, MCA_UNIDAD, IMP_UNIDAD, MCA_TIP_CAPITAL, COD_COB_RELACIONADA, PCT_PARTICIPACION, MCA_PCT_PARTICIPACION_VARIABLE, NOM_PRG_PRE_COB, COD_AGRUP_COB_1, COD_AGRUP_COB_2, COD_AGRUP_COB_3, COD_AGRUP_COB_4, COD_RAMO_CTABLE, COEF_INVENTARIO, MCA_IMP_OBLIGATORIA, MCA_ACCESORIOS, MCA_FRANQUICIA, MCA_BONI, MCA_SOBRE_TASAS, MCA_COMIS_NPR, MCA_COMIS_CAR, MCA_OBLIGATORIO, MCA_INH, MCA_MOD_SUMA_ASEG, MCA_BAJA_SUMA_ASEG_STRO, MCA_REASEGURO, MCA_FINANCIABLE, MCA_INSPEC, MCA_NUEVO_CAPITAL, TIP_REGULARIZA, TIP_REGULARIZA_ESP, PCT_REGULARIZA_ESP, COD_INDICE, NOM_PRG_REGULARIZA_ESP, COD_MON_TARIFA, TIP_CALCULO_COB, TASA_CALCULO, IMP_CALCULO, NOM_TABLA_CALCULO, TIP_TABLA_CALCULO, NOM_CAMPO_TABLA_CALCULO, NOM_PRG_CALCULO, NOM_TABLA_CORRECTORA, NOM_CAMPO_TABLA_CORRECTORA, TIP_CALCULO_AUX, COD_CALCULO_AUX, NOM_CALCULO_AUX, TIP_PRIMA_MINIMA, IMP_PRIMA_MINIMA, NOM_TABLA_PRIMA_MINIMA, NOM_CAMPO_TABLA_PRIMA_MINIMA, NOM_PRG_PRIMA_MINIMA, TIP_ACT_AUM_NO_MOD, NOM_PRG_AUM_NO_MOD, TIP_ACT_AUM_SI_MOD, NOM_PRG_AUM_SI_MOD, TIP_ACT_BAJ_NO_MOD, NOM_PRG_BAJ_NO_MOD, TIP_ACT_BAJ_SI_MOD, NOM_PRG_BAJ_SI_MOD, TIP_ACT_MAN_NO_MOD, NOM_PRG_MAN_NO_MOD, TIP_ACT_MAN_SI_MOD, NOM_PRG_MAN_SI_MOD, MCA_VALIDACION_PRIMA, MCA_VALIDACION_SUMA_ASEG, NOM_PRG_VALIDACION, NOM_PRG_PRE_FRANQUICIA, FEC_VALIDEZ, COD_USR, FEC_ACTU, NOM_PRG_VALIDACION_PRIMA " +
                              "FROM A1002150 " + filter)
                        .AddParameter(parameters)
                        .Query(connection, "Tron", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToA1002150(reader));
                        }));
            return result;
        }


        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'A1002150'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Contracts.Ramo.A1002150 DataReaderToA1002150(System.Data.IDataReader reader, Contracts.Ramo.A1002150 item = null)
        {
            if (item == null)
            {
                item = new Contracts.Ramo.A1002150();
            }
            item.COD_CIA = reader.IntegerValue("COD_CIA");
            item.COD_RAMO = reader.IntegerValue("COD_RAMO");
            item.COD_MODALIDAD = reader.IntegerValue("COD_MODALIDAD");
            item.NUM_SECU = reader.IntegerValue("NUM_SECU");
            item.COD_COB = reader.IntegerValue("COD_COB");
            item.NOM_COB = reader.StringValue("NOM_COB");
            item.COD_MON_CAPITAL = reader.IntegerValue("COD_MON_CAPITAL");
            item.MCA_UNIDAD = reader.StringValue("MCA_UNIDAD");
            item.IMP_UNIDAD = reader.Integer64Value("IMP_UNIDAD");
            item.MCA_TIP_CAPITAL = reader.StringValue("MCA_TIP_CAPITAL");
            item.COD_COB_RELACIONADA = reader.IntegerValue("COD_COB_RELACIONADA");
            item.PCT_PARTICIPACION = reader.Integer64Value("PCT_PARTICIPACION");
            item.MCA_PCT_PARTICIPACION_VARIABLE = reader.StringValue("MCA_PCT_PARTICIPACION_VARIABLE");
            item.NOM_PRG_PRE_COB = reader.StringValue("NOM_PRG_PRE_COB");
            item.COD_AGRUP_COB_1 = reader.StringValue("COD_AGRUP_COB_1");
            item.COD_AGRUP_COB_2 = reader.StringValue("COD_AGRUP_COB_2");
            item.COD_AGRUP_COB_3 = reader.StringValue("COD_AGRUP_COB_3");
            item.COD_AGRUP_COB_4 = reader.StringValue("COD_AGRUP_COB_4");
            item.COD_RAMO_CTABLE = reader.StringValue("COD_RAMO_CTABLE");
            item.COEF_INVENTARIO = reader.Integer64Value("COEF_INVENTARIO");
            item.MCA_IMP_OBLIGATORIA = reader.StringValue("MCA_IMP_OBLIGATORIA");
            item.MCA_ACCESORIOS = reader.StringValue("MCA_ACCESORIOS");
            item.MCA_FRANQUICIA = reader.StringValue("MCA_FRANQUICIA");
            item.MCA_BONI = reader.StringValue("MCA_BONI");
            item.MCA_SOBRE_TASAS = reader.StringValue("MCA_SOBRE_TASAS");
            item.MCA_COMIS_NPR = reader.StringValue("MCA_COMIS_NPR");
            item.MCA_COMIS_CAR = reader.StringValue("MCA_COMIS_CAR");
            item.MCA_OBLIGATORIO = reader.StringValue("MCA_OBLIGATORIO");
            item.MCA_INH = reader.StringValue("MCA_INH");
            item.MCA_MOD_SUMA_ASEG = reader.StringValue("MCA_MOD_SUMA_ASEG");
            item.MCA_BAJA_SUMA_ASEG_STRO = reader.StringValue("MCA_BAJA_SUMA_ASEG_STRO");
            item.MCA_REASEGURO = reader.StringValue("MCA_REASEGURO");
            item.MCA_FINANCIABLE = reader.StringValue("MCA_FINANCIABLE");
            item.MCA_INSPEC = reader.StringValue("MCA_INSPEC");
            item.MCA_NUEVO_CAPITAL = reader.StringValue("MCA_NUEVO_CAPITAL");
            item.TIP_REGULARIZA = reader.StringValue("TIP_REGULARIZA");
            item.TIP_REGULARIZA_ESP = reader.StringValue("TIP_REGULARIZA_ESP");
            item.PCT_REGULARIZA_ESP = reader.Integer64Value("PCT_REGULARIZA_ESP");
            item.COD_INDICE = reader.IntegerValue("COD_INDICE");
            item.NOM_PRG_REGULARIZA_ESP = reader.StringValue("NOM_PRG_REGULARIZA_ESP");
            item.COD_MON_TARIFA = reader.IntegerValue("COD_MON_TARIFA");
            item.TIP_CALCULO_COB = reader.StringValue("TIP_CALCULO_COB");
            item.TASA_CALCULO = reader.Integer64Value("TASA_CALCULO");
            item.IMP_CALCULO = reader.Integer64Value("IMP_CALCULO");
            item.NOM_TABLA_CALCULO = reader.StringValue("NOM_TABLA_CALCULO");
            item.TIP_TABLA_CALCULO = reader.StringValue("TIP_TABLA_CALCULO");
            item.NOM_CAMPO_TABLA_CALCULO = reader.StringValue("NOM_CAMPO_TABLA_CALCULO");
            item.NOM_PRG_CALCULO = reader.StringValue("NOM_PRG_CALCULO");
            item.NOM_TABLA_CORRECTORA = reader.StringValue("NOM_TABLA_CORRECTORA");
            item.NOM_CAMPO_TABLA_CORRECTORA = reader.StringValue("NOM_CAMPO_TABLA_CORRECTORA");
            item.TIP_CALCULO_AUX = reader.StringValue("TIP_CALCULO_AUX");
            item.COD_CALCULO_AUX = reader.IntegerValue("COD_CALCULO_AUX");
            item.NOM_CALCULO_AUX = reader.StringValue("NOM_CALCULO_AUX");
            item.TIP_PRIMA_MINIMA = reader.StringValue("TIP_PRIMA_MINIMA");
            item.IMP_PRIMA_MINIMA = reader.Integer64Value("IMP_PRIMA_MINIMA");
            item.NOM_TABLA_PRIMA_MINIMA = reader.StringValue("NOM_TABLA_PRIMA_MINIMA");
            item.NOM_CAMPO_TABLA_PRIMA_MINIMA = reader.StringValue("NOM_CAMPO_TABLA_PRIMA_MINIMA");
            item.NOM_PRG_PRIMA_MINIMA = reader.StringValue("NOM_PRG_PRIMA_MINIMA");
            item.TIP_ACT_AUM_NO_MOD = reader.StringValue("TIP_ACT_AUM_NO_MOD");
            item.NOM_PRG_AUM_NO_MOD = reader.StringValue("NOM_PRG_AUM_NO_MOD");
            item.TIP_ACT_AUM_SI_MOD = reader.StringValue("TIP_ACT_AUM_SI_MOD");
            item.NOM_PRG_AUM_SI_MOD = reader.StringValue("NOM_PRG_AUM_SI_MOD");
            item.TIP_ACT_BAJ_NO_MOD = reader.StringValue("TIP_ACT_BAJ_NO_MOD");
            item.NOM_PRG_BAJ_NO_MOD = reader.StringValue("NOM_PRG_BAJ_NO_MOD");
            item.TIP_ACT_BAJ_SI_MOD = reader.StringValue("TIP_ACT_BAJ_SI_MOD");
            item.NOM_PRG_BAJ_SI_MOD = reader.StringValue("NOM_PRG_BAJ_SI_MOD");
            item.TIP_ACT_MAN_NO_MOD = reader.StringValue("TIP_ACT_MAN_NO_MOD");
            item.NOM_PRG_MAN_NO_MOD = reader.StringValue("NOM_PRG_MAN_NO_MOD");
            item.TIP_ACT_MAN_SI_MOD = reader.StringValue("TIP_ACT_MAN_SI_MOD");
            item.NOM_PRG_MAN_SI_MOD = reader.StringValue("NOM_PRG_MAN_SI_MOD");
            item.MCA_VALIDACION_PRIMA = reader.StringValue("MCA_VALIDACION_PRIMA");
            item.MCA_VALIDACION_SUMA_ASEG = reader.StringValue("MCA_VALIDACION_SUMA_ASEG");
            item.NOM_PRG_VALIDACION = reader.StringValue("NOM_PRG_VALIDACION");
            item.NOM_PRG_PRE_FRANQUICIA = reader.StringValue("NOM_PRG_PRE_FRANQUICIA");
            item.FEC_VALIDEZ = reader.DateTimeValue("FEC_VALIDEZ");
            item.COD_USR = reader.StringValue("COD_USR");
            item.FEC_ACTU = reader.DateTimeValue("FEC_ACTU");
            item.NOM_PRG_VALIDACION_PRIMA = reader.StringValue("NOM_PRG_VALIDACION_PRIMA");
            return item;
        }

    }

}

