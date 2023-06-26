using Architect.Utilities.Extensions;
using Architect.DataFactory.Handlers;
using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace Architect.API.Tron.Business.Backoffice.Cotizacion
{
    /// <summary>
    /// Permite realizar cotizaciones de pólizas MapfreMas.
    /// </summary>
    public static class MapfreMas
    {
        public static Architect.API.Tron.Contracts.Presupuesto.DatoFijo Calcular(Contracts.Batch.CotizadorMapfreMasClass _class)
        {
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron");
            Architect.API.Tron.Contracts.Presupuesto.DatoFijo P30Instance = Architect.API.Tron.DataAccess.CotizadorMapfreMasPlusClass.P_Cotiza(_class, currentConnection);

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
                P30Instance.num_poliza = P30Instance.Coberturas.First().num_poliza;
                              
                P30Instance = DataAccess.LeerPresupuesto.Presupuesto(1, P30Instance.num_poliza, 0, 0, 0, currentConnection, true, "onlyresult");
                P30Instance.num_riesgos = 1;
                Crea_DatosVariables(_class, P30Instance, currentConnection);
            }

            currentConnection.Close();
            return P30Instance;
        }

        /// <summary>
        /// Permite la creación de los datos variables que no son ingresado por medio del procedimiento P_Cotiza
        /// </summary>
        private static void Crea_DatosVariables(Contracts.Batch.CotizadorMapfreMasClass _class, Contracts.Presupuesto.DatoFijo datoFijo, IDbConnection currentConnection)
        {
            List<Contracts.Presupuesto.DatoVariable> datosVariables = new List<Contracts.Presupuesto.DatoVariable>();

            datosVariables.Add(Util.DatoVariable(datoFijo, datoFijo.num_riesgos, "NUM_MATRICULA", _class.num_matricula, 2, 7));
            datosVariables.Add(Util.DatoVariable(datoFijo, datoFijo.num_riesgos, "NUM_MOTOR", _class.num_motor, 2, 8));
            datosVariables.Add(Util.DatoVariable(datoFijo, datoFijo.num_riesgos, "COD_CHASSIS", _class.cod_chassis, 2, 12));

            foreach (Contracts.Presupuesto.DatoVariable dato in datosVariables)
            {
                dato.num_poliza = datoFijo.num_poliza;
                DataAccess.CrearPresupuesto.PP_Insert_P2000020(dato, currentConnection);
            }
        }

    }
}
