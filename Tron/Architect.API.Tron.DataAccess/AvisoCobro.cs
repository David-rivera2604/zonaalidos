using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess
{
    /// <summary>
    /// Avisos de cobro asociados a los recibos
    /// </summary>
    public static partial class AvisoCobro
    {
        //reparar contrato
        /// <summary>
        /// Genera Aviso de Cobro
        /// </summary>
        public static List<Contracts.AvisosDeCobro.AvisoResponse> Generar(Contracts.AvisosDeCobro.Parameters.AvisoCobroGenerarParametros avisoCobroInstance, int cod_Agt, IDbConnection connection = null)
        {

            //,  avisoCobroInstance.Num_Contrato != 0 ? avisoCobroInstance.Num_Contrato : null segundo parametro

            List<Contracts.AvisosDeCobro.AvisoResponse> result = new List<Contracts.AvisosDeCobro.AvisoResponse>();
            Database.Procedure("DC_K_CONSULTA_WEB_AVISOS_MCR.P_GENERA_AVISO_LISTA")
                    .AddParameter("P_NUM_POLIZA_GRUPO", DbType.String, 13, avisoCobroInstance.Num_Poliza_Grupo)
                    .AddParameter("P_NUM_CONTRATO", DbType.Int32, 22, avisoCobroInstance.Num_Contrato)
                    .AddParameter("P_NUM_POLIZA_CLIENTE", DbType.String, 13, string.Empty)
                    .AddParameter("P_NUM_POLIZA", DbType.String, 13, string.Empty)
                    .AddParameter("P_TIP_DOCUM", DbType.String, 3, string.Empty)
                    .AddParameter("P_COD_DOCUM", DbType.String, 20, string.Empty)
                    .AddParameter("P_COD_MON", DbType.Int32, 22, avisoCobroInstance.Cod_Mon)
                    .AddParameter("P_FEC_EFEC_REC_DESDE", DbType.Date, 0, avisoCobroInstance.Fec_Efec_Rec_Desde)
                    .AddParameter("P_FEC_EFEC_REC_HASTA", DbType.Date, 0, avisoCobroInstance.Fec_Efec_Rec_Hasta)
                    .AddParameter("P_COD_AGT", DbType.Int32, 22, cod_Agt)
                    .AddParameter("P_LISTA_RECIBOS", DbType.String, 65535, avisoCobroInstance.Lista_Recibos)
                    .AddParameter("P_AVISO", DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                    .AddParameter("P_ERRORES", DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                    .Query(connection, "Tron", new Action<System.Data.IDataReader>((reader) =>
                    {
                        result.Add(new Contracts.AvisosDeCobro.AvisoResponse()
                        {
                            Num_Aviso = reader.Integer64Value("NUM_AVISO"),
                            Cantidad_Recibos = reader.IntegerValue("CANTIDAD_RECIBOS"),
                            Total_Importe_Aviso = reader.DoubleValue("TOTAL_IMPORTE_AVISO"),
                            Cantidad_Recibos_No_Procesados = reader.IntegerValue("CANTIDAD_RECIBOS_NO_PROCESADOS")
                        });
                    }));
            return result;
        }

        /// <summary>
        /// Elimina un aviso de cobro en base a número del aviso
        /// </summary>
        public static bool Delete(string numAviso, IDbConnection connection = null)
        {
            return Database.Procedure("DC_K_CONSULTA_WEB_AVISOS_MCR.P_ELIMINA_AVISO")
                        .AddParameter("P_NUM_AVISO", DbType.String, 15, numAviso)
                        .AddParameter("P_RESULTADO", DbType.RefCursor, 0, null, ParameterDirection.Output)
                        .AddParameter("P_ERRORES", DbType.RefCursor, 0, null, ParameterDirection.Output)
                        .Execute(connection, "Tron") != 0;
        }

        /// <summary>
        /// Consulta de avisos de cobro
        /// </summary>
        public static Contracts.AvisosDeCobro.InformacionAvisosResponse Consulta(Contracts.AvisosDeCobro.Parameters.AvisoCobroConsultaParametros avisoCobroInstance, int cod_Agt, IDbConnection connection = null)
        {
            Contracts.AvisosDeCobro.InformacionAvisosResponse result = new Contracts.AvisosDeCobro.InformacionAvisosResponse() { 
                Avisos = new List<Contracts.AvisosDeCobro.AvisoConsultaResponse>(), 
                Errors = new List<string>(), 
                RecibosAviso = new List<Contracts.AvisosDeCobro.ReciboAvisoRespose>() };

            //avisoCobroInstance.Num_Contrato != 0 ? avisoCobroInstance.Num_Contrato : null  segundo parametro
            Database.Procedure("DC_K_CONSULTA_WEB_AVISOS_MCR.P_CONSULTA_AVISOS")
                    .AddParameter("P_NUM_POLIZA_GRUPO", DbType.String, 13, avisoCobroInstance.Num_Poliza_Grupo)
                    .AddParameter("P_NUM_CONTRATO", DbType.Int32, 22, avisoCobroInstance.Num_Contrato)
                    .AddParameter("P_NUM_POLIZA_CLIENTE", DbType.String, 13, string.Empty)
                    .AddParameter("P_NUM_POLIZA", DbType.String, 13, string.Empty)
                    .AddParameter("P_TIP_DOCUM", DbType.String, 3, avisoCobroInstance.Tip_Docum)
                    .AddParameter("P_COD_DOCUM", DbType.String, 20, avisoCobroInstance.Cod_Docum)
                    .AddParameter("P_COD_MON", DbType.Int32, 22, avisoCobroInstance.Cod_Mon)
                    .AddParameter("P_FEC_EFEC_REC_DESDE", DbType.Date, 0, avisoCobroInstance.Fec_Efec_Rec_Desde)
                    .AddParameter("P_FEC_EFEC_REC_HASTA", DbType.Date, 0, avisoCobroInstance.Fec_Efec_Rec_Hasta)
                    .AddParameter("P_COD_AGT", DbType.Int32, 22, cod_Agt)
                    .AddParameter("P_COD_FRACC_PAGO", DbType.Int32, 22, avisoCobroInstance.Cod_Fracc_Pago != 0 ? avisoCobroInstance.Cod_Fracc_Pago : null)
                    .AddParameter("P_TIP_DOCUM_ACREEDOR", DbType.String, 3, avisoCobroInstance.Tip_Docum_Acreedor)
                    .AddParameter("P_COD_DOCUM_ACREEDOR", DbType.String, 20, avisoCobroInstance.Cod_Docum_Acreedor)
                    .AddParameter("P_AVISO", DbType.RefCursor, 0, null, ParameterDirection.Output)
                    .AddParameter("P_RECIBOS_AVISO", DbType.RefCursor, 0, null, ParameterDirection.Output)
                    .AddParameter("P_ERRORES", DbType.RefCursor, 0, null, ParameterDirection.Output)
                    .Query(connection, "Tron", new Action<System.Data.IDataReader, string>((reader, key) =>
                    {
                        switch (key)
                        {
                            case "P_AVISO":
                                result.Avisos.Add(new Contracts.AvisosDeCobro.AvisoConsultaResponse()
                                {
                                    Num_Aviso = reader.Integer64Value("NUM_AVISO"),
                                    Cantidad_Recibos = reader.IntegerValue("CANT_RECIBOS"),
                                    Total_Recivos = reader.DoubleValue("TOTAL_RECIBOS"),
                                    Estatus = reader.StringValue("ESTATUS")
                                });

                                break;
                            case "P_RECIBOS_AVISO":
                                result.RecibosAviso.Add(new Contracts.AvisosDeCobro.ReciboAvisoRespose()
                                {
                                    Imp_Recibo = reader.DoubleValue("imp_recibo"),
                                    Num_Recibo = reader.IntegerValue("num_recibo"),
                                    Fec_Efec_Recibo = reader.DateTimeValue("fec_efec_recibo"),
                                    Cod_Mon = reader.IntegerValue("cod_mon"),
                                    Num_Aviso = reader.StringValue("num_aviso"),
                                    Estatus = reader.StringValue("estatus"),
                                    Num_Poliza = reader.StringValue("num_poliza"),
                                    Nom_Riesgo = reader.StringValue("nom_riesgo"),
                                    Tip_Docum_Aseg = reader.StringValue("tip_docum_aseg"),
                                    Cod_Docum_Aseg = reader.StringValue("cod_docum_aseg"),
                                    Nom_Asegurado = reader.StringValue("nom_asegurado")
                                });
                                break;

                            case "P_ERRORES":
                                result.Errors.Add(reader.StringValue("''"));
                                break;
                        }
                    }));
            return result;
        }

    }
}
