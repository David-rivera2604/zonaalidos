using Architect.DataFactory;
using System;
using System.Data;
using System.Data.Common;

namespace Architect.API.Tron.DataAccess
{
    /// <summary>
    /// Funciones para el manejo de controles técnicos (EM_K_GEN_CT_MCR).
    /// </summary>
    public static class ControlesTecnicos
    {
        /// <summary>
        ///  Autorización de un contrato de póliza a solicitud del asegurado o de la compañía de seguros.
        /// </summary>
        public static void Autorizar(string numPoliza, Contracts.Poliza.Parameters.ControlTecnicoParametros controlTecnico)
        {
            int cod_cia = Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_cia", 1);
            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                Contracts.Poliza.DatoFijo policy = LeerPoliza.Poliza(cod_cia, numPoliza, controlTecnico.num_spto, 0, 0, currentConnection, false);

                Database.Procedure("EM_K_GEN_CT_MCR.P_AUTORIZA_CT_INDIVIDUAL")
                      .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 5, cod_cia)
                      .AddParameter("P_ID_PROCESO", Architect.DataFactory.Enumerations.DbType.Int32, 13, int.MinValue)
                      .AddParameter("P_COD_RAMO", Architect.DataFactory.Enumerations.DbType.Int32, 5, policy.cod_ramo)
                      .AddParameter("P_COD_NIVEL1", Architect.DataFactory.Enumerations.DbType.Int32, 22, policy.cod_nivel1)
                      .AddParameter("P_COD_NIVEL2", Architect.DataFactory.Enumerations.DbType.Int32, 22, policy.cod_nivel2)
                      .AddParameter("P_COD_NIVEL3", Architect.DataFactory.Enumerations.DbType.Int32, 22, policy.cod_nivel3)
                      .AddParameter("P_TIP_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 3, policy.tip_docum)
                      .AddParameter("P_COD_DOCUM", Architect.DataFactory.Enumerations.DbType.String, 20, policy.cod_docum)
                      .AddParameter("P_COD_ERROR", Architect.DataFactory.Enumerations.DbType.Int32, 5, controlTecnico.cod_error)
                      .AddParameter("P_MCA_AUTORIZA", Architect.DataFactory.Enumerations.DbType.String, 1, "N")
                      .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 15, numPoliza)
                      .AddParameter("P_TIP_AUTORIZ", Architect.DataFactory.Enumerations.DbType.String, 3, controlTecnico.tip_autoriza)
                      .AddParameter("P_OBS", Architect.DataFactory.Enumerations.DbType.String, 400, controlTecnico.observacion)
                      .Execute(currentConnection, "Tron");

                currentConnection.Close();
            }

 
        }
    }
}
