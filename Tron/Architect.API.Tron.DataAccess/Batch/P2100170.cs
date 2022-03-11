using System;
using System.Collections.Generic;
using System.Data;
using Architect.DataFactory;
using Architect.Utilities.Extensions;

namespace Architect.API.Tron.DataAccess.Batch
{
    /// <summary>
    ///  Conceptos de desglose económico del presupuesto
    /// </summary>
    public static class P2100170
    {
        public static bool Create(Architect.API.Tron.Contracts.Presupuesto.DesgloseEconomico p2100170Instance, IDbConnection currentConnection)
        {
            bool result = false;
            int affected = Database.Procedure("EM_K_MAPFRE_BATCH_CONTRACT_MCR.PP_INSERT_P2100170")
                               .AddParameter("P_COD_CIA", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2100170Instance.cod_cia)
                               .AddParameter("P_NUM_POLIZA", Architect.DataFactory.Enumerations.DbType.String, 13, p2100170Instance.num_poliza)
                               .AddParameter("P_NUM_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2100170Instance.num_spto)
                               .AddParameter("P_NUM_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2100170Instance.num_apli)
                               .AddParameter("P_NUM_SPTO_APLI", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2100170Instance.num_spto_apli)
                               .AddParameter("P_NUM_RIESGO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2100170Instance.num_riesgo)
                               .AddParameter("P_NUM_PERIODO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2100170Instance.num_periodo)
                               .AddParameter("P_COD_COB", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2100170Instance.cod_cob)
                               .AddParameter("P_COD_DESGLOSE", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2100170Instance.cod_desglose)
                               .AddParameter("P_COD_ECO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2100170Instance.cod_eco)
                               .AddParameter("P_NUM_BLOQUE_ESTUDIO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2100170Instance.num_bloque_estudio)
                               .AddParameter("P_IMP_ACUMULADO_ANUAL", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2100170Instance.imp_acumulado_anual)
                               .AddParameter("P_IMP_SPTO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2100170Instance.imp_spto)
                               .AddParameter("P_IMP_NO_CONSUMIDO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2100170Instance.imp_no_consumido)
                               .AddParameter("P_IMP_ANUAL", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2100170Instance.imp_anual)
                               .AddParameter("P_COD_RAMO", Architect.DataFactory.Enumerations.DbType.Int32, 22, p2100170Instance.cod_ramo)
                               .Execute(currentConnection, "Tron");
            if (affected != 0)
            {
                result = true;
            }
            return result;
        }

    }
}
