using Architect.Utilities.Extensions;
using Architect.DataFactory.Handlers;
using System;
using System.Data;
using System.Linq;

namespace Architect.API.Tron.Business.Backoffice.Cotizacion
{
    /// <summary>
    /// Permite realizar cotizaciones de pólizas MapfreMas.
    /// </summary>
    public static class MapfreMas
    {
        public static Architect.API.Tron.Contracts.Presupuesto.DatoFijo Calcular(Architect.API.Tron.Contracts.Batch.CotizadorMapfreMasClass _class)
        {
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron");
            Architect.Utilities.Log.TraceLog("processAutomobile302.QuotationIssue", "Antes de cotizar");
            Architect.API.Tron.Contracts.Presupuesto.DatoFijo P30Instance = Architect.API.Tron.DataAccess.CotizadorMapfreMasClass.P_Cotiza(_class, currentConnection);
            Architect.Utilities.Log.TraceLog("processAutomobile302.QuotationIssue", "Antes de cotizar");

            // Guardar datos del Sub Agente en la P2000060
            if (_class.Sub_Agt)
            {
                Architect.API.Tron.DataAccess.CrearPresupuesto.PP_Insert_P2000060(new Architect.API.Tron.Contracts.Presupuesto.Tercero
                {
                    cod_cia = 1,
                    num_poliza = P30Instance.Coberturas.First().num_poliza,
                    num_spto = 0,
                    num_apli = 0,
                    num_spto_apli = 0,
                    num_riesgo = 1,
                    tip_benef = _class.tip_benef_subAgente.ToString(),
                    num_secu = 1,
                    tip_docum = _class.tip_docum_sub_agt,
                    cod_docum = _class.cod_docum_sub_agt,
                    mca_principal = "N",
                    mca_calculo = "N",
                    mca_baja = "N",
                    mca_vigente = "S"
                }, currentConnection);
            }

            if (P30Instance?.Coberturas?.Count > 0 && P30Instance.Coberturas.First().txt_error.IsEmpty())
            {
                P30Instance = DataAccess.LeerPresupuesto.Presupuesto(1, P30Instance.Coberturas.First().num_poliza, 0, 0, 0, currentConnection, true, "onlyresult");
            }

            currentConnection.Close();
            return P30Instance;
        }

    }
}
