using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System.Data;
using System.Data.Common;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess
{
    /// <summary>
    ///  Datos variables de la poliza (A2000020)
    /// </summary>
    public static class DatosVariables
    {

        /// <summary>
        /// Recupera una lista acotada de datos variables.
        /// </summary>
        public static List<Contracts.Poliza.DatoVariable> RetrieveByPolicy(int cod_cia, string num_poliza)
        {
            List<Contracts.Poliza.DatoVariable> result = new List<Contracts.Poliza.DatoVariable>();

            Database.Select("SELECT G10.NOM_CAMPO, A20.COD_CAMPO, A20.VAL_CAMPO" +
                             " FROM A2000020 A20" +
                            " INNER JOIN G2000010 G10 ON A20.COD_CIA = G10.COD_CIA AND A20.COD_CAMPO = G10.COD_CAMPO" +
                            " WHERE A20.COD_CIA = :cod_cia" +
                            "   AND A20.NUM_POLIZA = :num_poliza" +
                            "   AND A20.MCA_VIGENTE = 'S'" +
                            "   AND A20.MCA_BAJA_RIESGO = 'N'" +
                            "   AND A20.MCA_VIGENTE_APLI = 'S'" +
                            "   AND A20.COD_CAMPO IN ('NUM_MATRICULA', 'COD_CHASSIS', 'NUM_MOTOR')" +
                            " ORDER BY A20.TIP_NIVEL, A20.NUM_SECU")
                    .AddParameter("cod_cia", Architect.DataFactory.Enumerations.DbType.Int32, 2, cod_cia)
                    .AddParameter("num_poliza", Architect.DataFactory.Enumerations.DbType.String, 13, num_poliza)
                    .Query("Tron", new Action<IDataReader>((reader) =>
                    {
                        result.Add(new Contracts.Poliza.DatoVariable()
                        {
                            nom_campo = reader.StringValue("nom_campo"),
                            cod_campo = reader.StringValue("cod_campo"),
                            val_campo = reader.StringValue("val_campo")
                        });
                    }));
            return result;
        }

        public static void AplicarVariacion(int cod_ramo, string num_poliza, int num_riesgo, string cod_campo, string val_campo_ant, string val_campo_act, DateTime fec_validez, string txt_obs, IDbConnection currentConnection)
        {

            Database.Procedure("em_k_batch_spto_var_mcr.pp_despliega_variacion")
                                .Parameter("p_cod_ramo", Architect.DataFactory.Enumerations.DbType.Int32, 5, cod_ramo)
                                .Parameter("p_num_poliza", Architect.DataFactory.Enumerations.DbType.String, 15, num_poliza)
                                .Parameter("p_num_riesgo", Architect.DataFactory.Enumerations.DbType.Int32, 5, num_riesgo)
                                .Parameter("p_cod_campo", Architect.DataFactory.Enumerations.DbType.String, 20, cod_campo)
                                .Parameter("p_val_campo_ant", Architect.DataFactory.Enumerations.DbType.String, 50, val_campo_ant)
                                .Parameter("p_val_campo_act", Architect.DataFactory.Enumerations.DbType.String, 50, val_campo_act)
                                .Parameter("p_fec_validez", Architect.DataFactory.Enumerations.DbType.String, 18, fec_validez.ToString("ddmmyyyy"))
                                .Parameter("p_txt_obs", Architect.DataFactory.Enumerations.DbType.String, 400, txt_obs)
                                .Parameter("p_cod_usr", Architect.DataFactory.Enumerations.DbType.String, 8, "COTIZWEB")
                                .Execute(currentConnection, "Tron");
        }

        public static bool Agrega_txt_campo (string num_poliza, string cod_campo, string txt_campo, IDbConnection connection = null)
        {
            bool result = false;
         
            int affected = Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.p_actualiza_txt_campo")
                                    .AddParameter("p_num_poliza", DbType.String, 22, num_poliza)
                                    .AddParameter("p_cod_campo", DbType.String, 22, cod_campo)
                                    .AddParameter("p_txt_campo", DbType.String, 80, txt_campo)
                                    .Execute(connection, "Tron");
            if (affected != 0)
            {
                result = true;
            }
            return result;
        }
    }
}
