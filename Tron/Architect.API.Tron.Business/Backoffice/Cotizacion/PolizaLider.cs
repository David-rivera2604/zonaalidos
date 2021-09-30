using Architect.Utilities.Extensions;
using Architect.DataFactory.Handlers;
using System;
using System.Data;
using System.Linq;

namespace Architect.API.Tron.Business.Backoffice.Cotizacion
{
    /// <summary>
    /// Permite realizar cotizaciones de pólizas del tipo PolizaLider.
    /// </summary>
    public static class PolizaLider
    {
        public static Contracts.Presupuesto.DatoFijo Calcular(Contracts.Batch.CotizadorPolizaLiderClass quoteInfo)
        {
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron");
            Contracts.Presupuesto.DatoFijo P30Instance = Architect.API.Tron.DataAccess.CotizadorPolizaLiderClass.P_Cotiza(quoteInfo, currentConnection);
            // Guardar datos del Sub Agente en la P2000060
            if (quoteInfo.Sub_agt)
            {
                Architect.API.Tron.DataAccess.CrearPresupuesto.PP_Insert_P2000060(new Contracts.Presupuesto.Tercero
                {
                    cod_cia = 1,
                    num_poliza = P30Instance.Coberturas.First().num_poliza,
                    num_spto = 0,
                    num_apli = 0,
                    num_spto_apli = 0,
                    num_riesgo = 1,
                    tip_benef = 20.ToString(),
                    num_secu = 1,
                    tip_docum = quoteInfo.tip_docum_sub_agt,
                    cod_docum = quoteInfo.cod_docum_sub_agt,
                    mca_principal = "N",
                    mca_calculo = "N",
                    mca_baja = "N",
                    mca_vigente = "S"
                }, currentConnection);
            }

            if (P30Instance?.Coberturas?.Count > 0 && P30Instance.Coberturas.First().txt_error.IsEmpty())
            {
                P30Instance = Architect.API.Tron.DataAccess.LeerPresupuesto.Presupuesto(1, P30Instance.Coberturas.First().num_poliza, 0, 0, 0, currentConnection, true, "onlyresult");
            }

            currentConnection.Close();
            return P30Instance;
        }


    }
}
