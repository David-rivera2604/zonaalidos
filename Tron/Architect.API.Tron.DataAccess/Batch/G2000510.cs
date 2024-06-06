using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Data;
using System.Data.Common;

namespace Architect.API.Tron.DataAccess.Batch
{
    /// <summary>
    ///  Procesos masivos
    /// </summary>
    public static class G2000510
    {
        public static Architect.API.Tron.Contracts.Batch.Proceso ExecutePolicyFromQuotation(Architect.API.Tron.Contracts.Batch.Proceso g2000510Instance, string val_num_presupuesto, IDbConnection currentConnection)
        {
            Architect.API.Tron.Contracts.Batch.Proceso result = new Architect.API.Tron.Contracts.Batch.Proceso();
            try {
                
                Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.POLICYFROMQUOTATION")
                                               .AddParameter("P_NUM_PRESUPUESTO", Architect.DataFactory.Enumerations.DbType.String, 13, val_num_presupuesto)
                                               .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, g2000510Instance.cod_cia)
                                               .AddParameter("P_FEC_TRATAMIENTO", Architect.DataFactory.Enumerations.DbType.Date, 0, g2000510Instance.fec_tratamiento)
                                               .AddParameter("P_NUM_ORDEN", Architect.DataFactory.Enumerations.DbType.Int32, 22, g2000510Instance.num_orden)
                                               .AddParameter("P_TIP_MVTO_BATCH", Architect.DataFactory.Enumerations.DbType.String, 2, g2000510Instance.tip_mvto_batch)
                                               .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                                               .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                                               {
                                                   result = new Architect.API.Tron.Contracts.Batch.Proceso()
                                                   {
                                                       num_presupuesto = reader.StringValue("num_presupuesto"),
                                                       num_riesgo = reader.IntegerValue("num_riesgo"),
                                                       num_poliza_definitivo = reader.StringValue("num_poliza_definitivo"),
                                                       txt_error = reader.StringValue("txt_error"),
                                                       txt_ruta_error = reader.StringValue("txt_ruta_error"),
                                                       cod_cia = g2000510Instance.cod_cia
                                                   };
                                               }));

                return result;

            }
            catch(Exception ex)
            {
                Utilities.Log.ErrorLog("ExecutePolicyFromQuotation", "ExecutePolicyFromQuotation", ex);

                if (ex.InnerException != null && ex.InnerException.Message.IsNotEmpty())
                {
                    result.txt_error = ex.InnerException.Message;
                }
                else
                {
                    result.txt_error = ex.Message;
                }

                return result;

            }

        }

        public static Architect.API.Tron.Contracts.Batch.Proceso Execute(Architect.API.Tron.Contracts.Batch.Proceso g2000510Instance, IDbConnection currentConnection)
        {
            Architect.API.Tron.Contracts.Batch.Proceso result = new Architect.API.Tron.Contracts.Batch.Proceso();
            Database.Procedure("em_k_Mapfre_Batch_Contract_mcr.pp_em_k_batch")
                                           .AddParameter("cod_cia", Architect.DataFactory.Enumerations.DbType.Int32, 22, g2000510Instance.cod_cia)
                                           .AddParameter("fec_tratamiento", Architect.DataFactory.Enumerations.DbType.Date, 13, g2000510Instance.fec_tratamiento)
                                           .AddParameter("num_orden", Architect.DataFactory.Enumerations.DbType.Int32, 22, g2000510Instance.num_orden)
                                           .AddParameter("tip_mvto_batch", Architect.DataFactory.Enumerations.DbType.Int32, 22, g2000510Instance.tip_mvto_batch)
                                           .AddParameter("RC1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                                           .Query(currentConnection, "Tron", new Action<IDataReader>((reader) =>
                                           {
                                               result = new Architect.API.Tron.Contracts.Batch.Proceso()
                                               {
                                                   num_presupuesto = reader.StringValue("num_presupuesto"),
                                                   num_riesgo = reader.IntegerValue("num_riesgo"),
                                                   num_poliza_definitivo = reader.StringValue("num_poliza_definitivo"),
                                                   txt_error = reader.StringValue("txt_error"),
                                                   txt_ruta_error = reader.StringValue("txt_ruta_error")
                                               };
                                           }));
            return result;
        }

        public static bool Create(Architect.API.Tron.Contracts.Batch.Proceso g2000510Instance, IDbConnection currentConnection)
        {
            bool result = false;
            int affected = Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_INSERT_G2000510")
                                           .AddParameter("P_FEC_TRATAMIENTO", Architect.DataFactory.Enumerations.DbType.Date, 0, g2000510Instance.fec_tratamiento)
                                           .AddParameter("P_NUM_ORDEN", Architect.DataFactory.Enumerations.DbType.Int32, 22, g2000510Instance.num_orden, ParameterDirection.InputOutput)
                                           .AddParameter("P_TIP_MVTO_BATCH", Architect.DataFactory.Enumerations.DbType.String, 2, g2000510Instance.tip_mvto_batch)
                                           .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, g2000510Instance.cod_cia)
                                           .AddParameter("P_TXT_ALIAS", Architect.DataFactory.Enumerations.DbType.String, 30, g2000510Instance.txt_alias)
                                           .AddParameter("P_TIP_SITU_FILTRO", Architect.DataFactory.Enumerations.DbType.String, 1, g2000510Instance.tip_situ_filtro)
                                           .AddParameter("P_NOM_PRG_EXCEPCION", Architect.DataFactory.Enumerations.DbType.String, 61, g2000510Instance.nom_prg_excepcion)
                                           .AddParameter("P_MCA_RECALCULA_FECHA", Architect.DataFactory.Enumerations.DbType.String, 1, g2000510Instance.mca_recalcula_fecha)
                                           .AddParameter("P_TIP_FECHA_BASE", Architect.DataFactory.Enumerations.DbType.String, 2, g2000510Instance.tip_fecha_base)
                                           .AddParameter("P_COD_USR", Architect.DataFactory.Enumerations.DbType.String, 8, g2000510Instance.cod_usr)
                                           .Execute(currentConnection, "Tron", new Action<DbCommand>((command) =>
                                           {
                                               g2000510Instance.num_orden = Int32.Parse(command.Parameters["P_NUM_ORDEN"].Value.ToString());
                                           }));
            if (affected != 0)
            {
                result = true;
            }
            return result;
        }

    }
}
