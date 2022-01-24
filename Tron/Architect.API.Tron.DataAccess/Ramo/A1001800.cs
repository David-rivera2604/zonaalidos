using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Ramo
{
    /// <summary>
    /// RAMOS.
    /// </summary>
    public static partial class A1001800
    {

        /// <summary>
        /// Recupera un registro en la tabla A1001800 por medio de su clave primaria.
        /// </summary>
        /// <param name="cod_cia">CODIGO DE COMPAÑIA.</param>
        /// <param name="cod_ramo">RAMO.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de RAMOS.</returns>
        public static Contracts.Ramo.A1001800 Retrieve(int cod_cia, int cod_ramo, IDbConnection connection = null)
        {
            Contracts.Ramo.A1001800 result = null;
            Database.Select("SELECT COD_CIA, COD_SECTOR, COD_SUBSECTOR, COD_RAMO, NOM_RAMO, ABR_RAMO, MCA_CLAUSULA, MCA_ANEXO, MCA_PRORRATA, MCA_CAMBIA_PRORRATA, MCA_RIESGOS, MCA_PERIODOS, MCA_RECIBO_POR_PERIODO, MCA_EMISION, MCA_CAMBIO_NIVEL_3, MCA_CALCULA_FRACC_PAGO, MCA_SPTO_EN_PLAN_PAGO, MCA_CAMBIO_PLAN_PAGO, MCA_CERTIFICADOS, MCA_INH, MCA_COMIS_COA_EXT, MCA_365_DIAS, MCA_OBLIGA_PRESUPUESTO, MCA_AUTORIZA_PRESUPUESTO, MCA_CAMBIO_NUM_POLIZA, MCA_CAMBIO_NUM_POLIZA_APLI, MCA_VAL_STRO_EN_SPTO, MCA_REMESA_RECIBO, MCA_RECIBO_MANUAL, MCA_COMIS_MANUAL, MCA_BUSCA_INSP_EMISION, MCA_EMISION_SIN_RECIBO, MCA_REUTILIZA_PRESUPUESTO, MCA_REUTILIZA_DECLARACION, MCA_APLICA_AT_EN_RIESGO, TIP_COASEGURO_PERMITIDO, MCA_CUADRO_COASEGURO_OBL, TIP_PRIMAS_MANUALES, NUM_AGT, NUM_RIESGOS_TRASPASO_DIRECTO, NUM_RIESGOS_IMPRESION, NOM_PRG_RIESGO, TIP_FORMACION_MODALIDAD, COD_USR, FEC_ACTU, NOM_PRG_BUSCA_INSP_EMISION, COD_TRATAMIENTO, COD_TRATAMIENTO_SINI, COD_TRATAMIENTO_CTABLE, NOM_PRG_EMISION_SIN_RECIBO, COD_PROCESO, COD_PROCESO_P, COD_PROCESO_R, COD_EST_DV_POLIZA, COD_EST_RIESGO, COD_EST_MODALIDAD, COD_EST_ACCESORIOS, COD_EST_PLAN_PAGO, COD_EST_INSPEC, NOM_PRG_COEF_COB, NOM_PRG_BUSCA_INSP, NOM_PRG_EXCLUYE_INSP, TIP_DST_COMIS, NOM_PRG_DST_COMIS, NOM_PRG_REMESA_RECIBO, MCA_MOD_ORG_ASE, MCA_MOD_COM_CUOTA_INTERV, MCA_RECHAZO_SUSP_A_TODOS, MCA_RECALCULA_COMIS, MCA_REGISTRA_HORA, TIP_REA_PERMITIDO, MCA_TASA_MANUAL, MCA_DES_POR_RIESGO_BATCH, MCA_MOTIVOS_SPTO, TIP_ACCESO_COM, MCA_RECHAZA_SUSPENDE_APLI, NOM_PRG_SPTO_PLAN_PAGO " +
                              "FROM A1001800 " +
                             "WHERE COD_CIA=:COD_CIA AND COD_RAMO=:COD_RAMO")
                        .AddParameter("COD_CIA", DbType.Decimal, 2, cod_cia)
                        .AddParameter("COD_RAMO", DbType.Decimal, 3, cod_ramo)
                        .Query(connection, "Tron", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToA1001800(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'A1001800'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Contracts.Ramo.A1001800 DataReaderToA1001800(System.Data.IDataReader reader, Contracts.Ramo.A1001800 item = null)
        {
            if (item == null)
            {
                item = new Contracts.Ramo.A1001800();
            }
            item.COD_CIA = reader.IntegerValue("COD_CIA");
            item.COD_SECTOR = reader.IntegerValue("COD_SECTOR");
            item.COD_SUBSECTOR = reader.IntegerValue("COD_SUBSECTOR");
            item.COD_RAMO = reader.IntegerValue("COD_RAMO");
            item.NOM_RAMO = reader.StringValue("NOM_RAMO");
            item.ABR_RAMO = reader.StringValue("ABR_RAMO");
            item.MCA_CLAUSULA = reader.StringValue("MCA_CLAUSULA");
            item.MCA_ANEXO = reader.StringValue("MCA_ANEXO");
            item.MCA_PRORRATA = reader.StringValue("MCA_PRORRATA");
            item.MCA_CAMBIA_PRORRATA = reader.StringValue("MCA_CAMBIA_PRORRATA");
            item.MCA_RIESGOS = reader.StringValue("MCA_RIESGOS");
            item.MCA_PERIODOS = reader.StringValue("MCA_PERIODOS");
            item.MCA_RECIBO_POR_PERIODO = reader.StringValue("MCA_RECIBO_POR_PERIODO");
            item.MCA_EMISION = reader.StringValue("MCA_EMISION");
            item.MCA_CAMBIO_NIVEL_3 = reader.StringValue("MCA_CAMBIO_NIVEL_3");
            item.MCA_CALCULA_FRACC_PAGO = reader.StringValue("MCA_CALCULA_FRACC_PAGO");
            item.MCA_SPTO_EN_PLAN_PAGO = reader.StringValue("MCA_SPTO_EN_PLAN_PAGO");
            item.MCA_CAMBIO_PLAN_PAGO = reader.StringValue("MCA_CAMBIO_PLAN_PAGO");
            item.MCA_CERTIFICADOS = reader.StringValue("MCA_CERTIFICADOS");
            item.MCA_INH = reader.StringValue("MCA_INH");
            item.MCA_COMIS_COA_EXT = reader.StringValue("MCA_COMIS_COA_EXT");
            item.MCA_365_DIAS = reader.StringValue("MCA_365_DIAS");
            item.MCA_OBLIGA_PRESUPUESTO = reader.StringValue("MCA_OBLIGA_PRESUPUESTO");
            item.MCA_AUTORIZA_PRESUPUESTO = reader.StringValue("MCA_AUTORIZA_PRESUPUESTO");
            item.MCA_CAMBIO_NUM_POLIZA = reader.StringValue("MCA_CAMBIO_NUM_POLIZA");
            item.MCA_CAMBIO_NUM_POLIZA_APLI = reader.StringValue("MCA_CAMBIO_NUM_POLIZA_APLI");
            item.MCA_VAL_STRO_EN_SPTO = reader.StringValue("MCA_VAL_STRO_EN_SPTO");
            item.MCA_REMESA_RECIBO = reader.StringValue("MCA_REMESA_RECIBO");
            item.MCA_RECIBO_MANUAL = reader.StringValue("MCA_RECIBO_MANUAL");
            item.MCA_COMIS_MANUAL = reader.StringValue("MCA_COMIS_MANUAL");
            item.MCA_BUSCA_INSP_EMISION = reader.StringValue("MCA_BUSCA_INSP_EMISION");
            item.MCA_EMISION_SIN_RECIBO = reader.StringValue("MCA_EMISION_SIN_RECIBO");
            item.MCA_REUTILIZA_PRESUPUESTO = reader.StringValue("MCA_REUTILIZA_PRESUPUESTO");
            item.MCA_REUTILIZA_DECLARACION = reader.StringValue("MCA_REUTILIZA_DECLARACION");
            item.MCA_APLICA_AT_EN_RIESGO = reader.StringValue("MCA_APLICA_AT_EN_RIESGO");
            item.TIP_COASEGURO_PERMITIDO = reader.IntegerValue("TIP_COASEGURO_PERMITIDO");
            item.MCA_CUADRO_COASEGURO_OBL = reader.StringValue("MCA_CUADRO_COASEGURO_OBL");
            item.TIP_PRIMAS_MANUALES = reader.StringValue("TIP_PRIMAS_MANUALES");
            item.NUM_AGT = reader.IntegerValue("NUM_AGT");
            item.NUM_RIESGOS_TRASPASO_DIRECTO = reader.IntegerValue("NUM_RIESGOS_TRASPASO_DIRECTO");
            item.NUM_RIESGOS_IMPRESION = reader.IntegerValue("NUM_RIESGOS_IMPRESION");
            item.NOM_PRG_RIESGO = reader.StringValue("NOM_PRG_RIESGO");
            item.TIP_FORMACION_MODALIDAD = reader.StringValue("TIP_FORMACION_MODALIDAD");
            item.COD_USR = reader.StringValue("COD_USR");
            item.FEC_ACTU = reader.DateTimeValue("FEC_ACTU");
            item.NOM_PRG_BUSCA_INSP_EMISION = reader.StringValue("NOM_PRG_BUSCA_INSP_EMISION");
            item.COD_TRATAMIENTO = reader.StringValue("COD_TRATAMIENTO");
            item.COD_TRATAMIENTO_SINI = reader.StringValue("COD_TRATAMIENTO_SINI");
            item.COD_TRATAMIENTO_CTABLE = reader.StringValue("COD_TRATAMIENTO_CTABLE");
            item.NOM_PRG_EMISION_SIN_RECIBO = reader.StringValue("NOM_PRG_EMISION_SIN_RECIBO");
            item.COD_PROCESO = reader.StringValue("COD_PROCESO");
            item.COD_PROCESO_P = reader.StringValue("COD_PROCESO_P");
            item.COD_PROCESO_R = reader.StringValue("COD_PROCESO_R");
            item.COD_EST_DV_POLIZA = reader.StringValue("COD_EST_DV_POLIZA");
            item.COD_EST_RIESGO = reader.StringValue("COD_EST_RIESGO");
            item.COD_EST_MODALIDAD = reader.StringValue("COD_EST_MODALIDAD");
            item.COD_EST_ACCESORIOS = reader.StringValue("COD_EST_ACCESORIOS");
            item.COD_EST_PLAN_PAGO = reader.StringValue("COD_EST_PLAN_PAGO");
            item.COD_EST_INSPEC = reader.StringValue("COD_EST_INSPEC");
            item.NOM_PRG_COEF_COB = reader.StringValue("NOM_PRG_COEF_COB");
            item.NOM_PRG_BUSCA_INSP = reader.StringValue("NOM_PRG_BUSCA_INSP");
            item.NOM_PRG_EXCLUYE_INSP = reader.StringValue("NOM_PRG_EXCLUYE_INSP");
            item.TIP_DST_COMIS = reader.IntegerValue("TIP_DST_COMIS");
            item.NOM_PRG_DST_COMIS = reader.StringValue("NOM_PRG_DST_COMIS");
            item.NOM_PRG_REMESA_RECIBO = reader.StringValue("NOM_PRG_REMESA_RECIBO");
            item.MCA_MOD_ORG_ASE = reader.StringValue("MCA_MOD_ORG_ASE");
            item.MCA_MOD_COM_CUOTA_INTERV = reader.StringValue("MCA_MOD_COM_CUOTA_INTERV");
            item.MCA_RECHAZO_SUSP_A_TODOS = reader.StringValue("MCA_RECHAZO_SUSP_A_TODOS");
            item.MCA_RECALCULA_COMIS = reader.StringValue("MCA_RECALCULA_COMIS");
            item.MCA_REGISTRA_HORA = reader.StringValue("MCA_REGISTRA_HORA");
            item.TIP_REA_PERMITIDO = reader.IntegerValue("TIP_REA_PERMITIDO");
            item.MCA_TASA_MANUAL = reader.StringValue("MCA_TASA_MANUAL");
            item.MCA_DES_POR_RIESGO_BATCH = reader.StringValue("MCA_DES_POR_RIESGO_BATCH");
            item.MCA_MOTIVOS_SPTO = reader.StringValue("MCA_MOTIVOS_SPTO");
            item.TIP_ACCESO_COM = reader.StringValue("TIP_ACCESO_COM");
            item.MCA_RECHAZA_SUSPENDE_APLI = reader.StringValue("MCA_RECHAZA_SUSPENDE_APLI");
            item.NOM_PRG_SPTO_PLAN_PAGO = reader.StringValue("NOM_PRG_SPTO_PLAN_PAGO");
            return item;
        }

    }

}

