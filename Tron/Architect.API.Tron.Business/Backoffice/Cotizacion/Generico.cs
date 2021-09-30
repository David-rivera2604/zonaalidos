using Architect.Utilities.Extensions;
using Architect.DataFactory.Handlers;
using System;
using System.Data;
using Architect.API.Tron.Contracts.Presupuesto;

namespace Architect.API.Tron.Business.Backoffice.Cotizacion
{
    /// <summary>
    /// Permite realizar cotizaciones de pólizas genéricas.
    /// </summary>
    public static class Generico
    {
        public static DatoFijo Calcular(Architect.API.Tron.Contracts.Presupuesto.DatoFijo quoteInfo)
        {
            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {
                Contracts.Batch.Proceso g2000510Instance = new Contracts.Batch.Proceso
                {
                    fec_tratamiento = DateTime.Today,
                    num_orden = 0,
                    tip_mvto_batch = 8.ToString(),
                    cod_cia = quoteInfo.cod_cia,
                    txt_alias = "Cotizado desde ZA",
                    tip_situ_filtro = 3.ToString(),
                    nom_prg_excepcion = string.Empty,
                    mca_recalcula_fecha = "N",
                    tip_fecha_base = string.Empty,
                    cod_usr = "COTIZWEB"
                };

                DataAccess.Batch.G2000510.Create(g2000510Instance, currentConnection);
                quoteInfo.fec_tratamiento = g2000510Instance.fec_tratamiento;
                quoteInfo.num_orden = g2000510Instance.num_orden;
                quoteInfo.tip_mvto_batch = g2000510Instance.tip_mvto_batch;

                // Por ser una cotización se crea con el tercero genérico
                quoteInfo.tip_docum = "CNA";
                quoteInfo.cod_docum = "999999999";

                DataAccess.CrearPresupuesto.PP_Insert_P2000030(quoteInfo, currentConnection);

                Crea_Riesgos(quoteInfo, currentConnection);

                Crea_DatosVariables(quoteInfo, currentConnection);

                Crea_Ocurrencias(quoteInfo, currentConnection);

                Crea_Terceros(quoteInfo, currentConnection);

                Crea_Coberturas(quoteInfo, currentConnection);

                // Por ser una cotización no se graba el cliente
                if (quoteInfo.DetalleDeTerceros.IsNotEmpty() && quoteInfo.DetalleDeTerceros.Count > 0)
                {
                    quoteInfo.DetalleDeTerceros = null;
                }

                g2000510Instance = DataAccess.Batch.G2000510.Execute(g2000510Instance, currentConnection);
                if (g2000510Instance.txt_error.IsEmpty())
                {
                    quoteInfo = DataAccess.LeerPresupuesto.Presupuesto(quoteInfo.cod_cia, g2000510Instance.num_poliza_definitivo, 0, 0, 0, currentConnection, true, "onlyresult");
                }

                quoteInfo.DatosDelProceso = g2000510Instance;

                currentConnection.Close();
            }
            return quoteInfo;
        }

        private static void Crea_Coberturas(DatoFijo quoteInfo, IDbConnection currentConnection)
        {
            foreach (Cobertura p2000030Instance40 in quoteInfo.Coberturas)
            {
                p2000030Instance40.num_poliza = quoteInfo.num_poliza;
                DataAccess.CrearPresupuesto.PP_Insert_P2000040(p2000030Instance40, currentConnection);
            }
        }

        private static void Crea_Terceros(DatoFijo quoteInfo, IDbConnection currentConnection)
        {
            foreach (Tercero p2000030Instance60 in quoteInfo.Terceros)
            {
                p2000030Instance60.num_poliza = quoteInfo.num_poliza;
                DataAccess.CrearPresupuesto.PP_Insert_P2000060(p2000030Instance60, currentConnection);
            }
        }

        private static void Crea_Ocurrencias(DatoFijo quoteInfo, IDbConnection currentConnection)
        {
            foreach (Ocurrencia p2000030Instance25 in quoteInfo.Ocurrencias)
            {
                p2000030Instance25.num_poliza = quoteInfo.num_poliza;
                DataAccess.CrearPresupuesto.PP_Insert_P2000025(p2000030Instance25, currentConnection);
            }
        }

        private static void Crea_DatosVariables(DatoFijo quoteInfo, IDbConnection currentConnection)
        {
            foreach (DatoVariable p2000030Instance20 in quoteInfo.DatosVariables)
            {
                p2000030Instance20.num_poliza = quoteInfo.num_poliza;
                DataAccess.CrearPresupuesto.PP_Insert_P2000020(p2000030Instance20, currentConnection);
            }
        }

        private static void Crea_Riesgos(DatoFijo quoteInfo, IDbConnection currentConnection)
        {
            foreach (Riesgo item31 in quoteInfo.Riesgos)
            {
                item31.num_poliza = quoteInfo.num_poliza;
                DataAccess.CrearPresupuesto.PP_Insert_P2000031(item31, currentConnection);
            }
        }

    }
}
