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
        /// <summary>
        /// Modifica un aviso de cobro para exluir recibos del mismo
        /// </summary>
        public static bool Modifica(Int64 numAviso, string recibos_excluir, IDbConnection connection = null)
        {
            return Database.Procedure("DC_K_CONSULTA_WEB_AVISOS_MCR.p_modifica_aviso")
                        .AddParameter("P_NUM_AVISO", DbType.String, 15, numAviso.ToString())
                        .AddParameter("p_lista_recibos_excluir", DbType.String, 65535, recibos_excluir)
                        .AddParameter("P_RESULTADO", DbType.RefCursor, 0, null, ParameterDirection.Output)
                        .AddParameter("P_ERRORES", DbType.RefCursor, 0, null, ParameterDirection.Output)
                        .Execute(connection, "Tron") != 0;
        }

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
        ///  Consulta recibos para incluir en aviso de cobro
        /// </summary>
        public static List<Contracts.AvisosDeCobro.ReciboRespose> ConsultaRecibos(Contracts.AvisosDeCobro.Parameters.RecibosParametros cobrosInstance, int cod_Agt, IDbConnection connection = null)
        {
            List<Contracts.AvisosDeCobro.ReciboRespose> result = new List<Contracts.AvisosDeCobro.ReciboRespose>();
            Database.Procedure("DC_K_CONSULTA_WEB_AVISOS_MCR.P_CONSULTA_RECIBOS")
                    .AddParameter("P_NUM_POLIZA_GRUPO", DbType.String, 13, cobrosInstance.Num_Poliza_Grupo)
                    .AddParameter("P_NUM_CONTRATO", DbType.Int32, 22, cobrosInstance.Num_Contrato)
                    .AddParameter("P_NUM_POLIZA_CLIENTE", DbType.String, 13, string.Empty)
                    .AddParameter("P_NUM_POLIZA", DbType.String, 13, string.Empty)
                    .AddParameter("P_TIP_DOCUM", DbType.String, 3, cobrosInstance.Tip_Docum)
                    .AddParameter("P_COD_DOCUM", DbType.String, 20, cobrosInstance.Cod_Docum.IsNotEmpty() ? cobrosInstance.Cod_Docum : null)
                    .AddParameter("P_COD_MON", DbType.Int32, 22, cobrosInstance.Cod_Mon)
                    .AddParameter("P_FEC_EFEC_REC_DESDE", DbType.Date, 0, cobrosInstance.Fec_Efec_Rec_Desde)
                    .AddParameter("P_FEC_EFEC_REC_HASTA", DbType.Date, 0, cobrosInstance.Fec_Efec_Rec_Hasta)
                    .AddParameter("P_COD_AGT", DbType.Int32, 22, cod_Agt)
                    .AddParameter("P_COD_FRACC_PAGO", DbType.Int32, 22, cobrosInstance.Cod_Fracc_Pago != 0 ? cobrosInstance.Cod_Fracc_Pago : null)
                    .AddParameter("P_TIP_DOCUM_ACREEDOR", DbType.String, 3, cobrosInstance.Tip_Docum_Acreedor)
                    .AddParameter("P_COD_DOCUM_ACREEDOR", DbType.String, 20, cobrosInstance.Cod_Docum_Acreedor)
                    .AddParameter("P_RECIBOS_AVISO", DbType.RefCursor, 0, null, ParameterDirection.Output)
                    .AddParameter("P_ERRORES", DbType.RefCursor, 0, null, ParameterDirection.Output)
                    .Query(connection, "Tron", new Action<System.Data.IDataReader, string>((reader, key) =>
                    {
                        switch (key)
                        {
                            case "P_RECIBOS_AVISO":
                                result.Add(new Contracts.AvisosDeCobro.ReciboRespose()
                                {
                                    Imp_Recibo = reader.DoubleValue("imp_recibo"),
                                    Num_Recibo = reader.IntegerValue("num_recibo"),
                                    Fec_Efec_Recibo = reader.DateTimeValue("fec_efec_recibo"),
                                    Cod_Mon = reader.IntegerValue("cod_mon"),
                                    Estatus = reader.StringValue("estatus"),
                                    Num_Poliza = reader.StringValue("num_poliza"),
                                    Nom_Riesgo = reader.StringValue("nom_riesgo"),
                                    Tip_Docum_Aseg = reader.StringValue("tip_docum_aseg"),
                                    Cod_Docum_Aseg = reader.StringValue("cod_docum_aseg"),
                                    Nom_Asegurado = reader.StringValue("nom_asegurado")
                                });
                                break;
                            case "P_ERRORES":
                                string xx = reader.GetValue(0).ToString();
                                break;
                        }
                    }));

            return result;
        }

    }
}
