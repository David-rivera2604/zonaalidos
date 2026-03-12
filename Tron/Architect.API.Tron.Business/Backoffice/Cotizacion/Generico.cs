using Architect.Utilities.Extensions;
using Architect.DataFactory.Handlers;
using System;
using System.Data;
using Architect.API.Tron.Contracts.Presupuesto;
using Architect.API.Tron.Contracts.Presupuesto.API;
using System.Collections.Generic;
using Architect.Utilities;
using System.Threading.Tasks;
using System.Linq;
using Architect.API.Core.Contracts.General;
using static Architect.API.Tron.Business.ErrorHandler;
using static Architect.API.Tron.Business.Backoffice.Cotizacion.Generico;

namespace Architect.API.Tron.Business.Backoffice.Cotizacion
{
    /// <summary>
    /// Permite realizar cotizaciones de pólizas genéricas.
    /// </summary>
    public static class Generico
    {

        public enum Tipo_Mvto_Batch : int
        {
            Cotizar = 8,
            Emitir = 3
        }

        public static DatoFijo Calcular(Architect.API.Tron.Contracts.Presupuesto.DatoFijo quoteInfo, Tipo_Mvto_Batch tip_mvto_batch = Tipo_Mvto_Batch.Cotizar, string txt_alias = "Cotizado desde ZA")
        {
            List<Contracts.Presupuesto.DatoVariable> datosVariable = null;
            ErrorHandler.ErrorDetail errInfo = new ErrorDetail();

            for (int tryIndex = 1; tryIndex <= 2; tryIndex++)
            {
                using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
                {

                    try
                    {
                        Contracts.Batch.Proceso g2000510Instance = new Contracts.Batch.Proceso
                        {
                            fec_tratamiento = DateTime.Today,
                            num_orden = 0,
                            tip_mvto_batch = ((int)tip_mvto_batch).ToString(),
                            cod_cia = quoteInfo.cod_cia,
                            txt_alias = txt_alias,
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
                        if (tip_mvto_batch == Tipo_Mvto_Batch.Cotizar)
                        {
                            var contratante = quoteInfo.Terceros?.Find(t => t.tip_benef == "0");
                            if (contratante is null)
                            {
                                quoteInfo.tip_docum = "CNA";
                                quoteInfo.cod_docum = "999999999";
                            }
                            else
                            {
                                quoteInfo.tip_docum = contratante.tip_docum;
                                quoteInfo.cod_docum = contratante.cod_docum;
                            }
                        }

                        DataAccess.CrearPresupuesto.PP_Insert_P2000030(quoteInfo, currentConnection);

                        Crea_Riesgos(quoteInfo, currentConnection);

                        Crea_DatosVariables(quoteInfo.num_poliza, quoteInfo.DatosVariables, currentConnection);
                        datosVariable = quoteInfo.DatosVariables;

                        Crea_Ocurrencias(quoteInfo, currentConnection);

                        Crea_P170(quoteInfo, currentConnection);

                        Crea_Terceros(quoteInfo, currentConnection);

                        Crea_Coberturas(quoteInfo, currentConnection);

                        Crea_P1331(quoteInfo, currentConnection);


                        g2000510Instance = DataAccess.Batch.G2000510.Execute(g2000510Instance, currentConnection);
                        if (g2000510Instance.txt_error.IsEmpty())
                        {
                            if (tip_mvto_batch == Tipo_Mvto_Batch.Cotizar)
                            {
                                quoteInfo = DataAccess.LeerPresupuesto.Presupuesto(quoteInfo.cod_cia, g2000510Instance.num_poliza_definitivo, 0, 0, 0, currentConnection, true, "onlyresult");
                            }
                        }
                        else
                        {
                            errInfo = ErrorHandler.Parser(g2000510Instance.txt_error);
                            g2000510Instance.txt_error = errInfo.message;
                            Log.WarningLog("Cotizacion.Generico.txt_error", $"\nnum_presupuesto: {g2000510Instance.num_presupuesto}\n  txt_error: {g2000510Instance.txt_error}\n  txt_error(raw): {errInfo.raw}\n  txt_ruta_error: {g2000510Instance.txt_ruta_error}", "tron");
                        }

                        quoteInfo.DatosDelProceso = g2000510Instance;


                    }
                    catch (Exception ex)
                    {
                        if (quoteInfo.DatosDelProceso == null)
                        {
                            quoteInfo.DatosDelProceso = new Contracts.Batch.Proceso();
                        }
                        quoteInfo.DatosDelProceso.txt_error = Backoffice.Emision.FormatoErrores.FormatearError(ex.Message);
                        Log.ErrorLog("CustomException", quoteInfo.DatosDelProceso.txt_error, ex);
                    }
                    //Actualiza_txt_campo(quoteInfo.num_poliza, datosVariable, currentConnection);

                    currentConnection.Close();

                }
                if (quoteInfo.DatosDelProceso.txt_error == "")
                {
                    break;
                }
                else
                {
                    if (errInfo.tron)
                    {
                        break;
                    }
                    else if (tryIndex <= 2)
                    {
                        //Se hace una demora de medio segun antes de volver a intentar la emisión
                        Task.Delay(500);
                    }
                }
            }

            return quoteInfo;
        }

        private static void Actualiza_txt_campo(string num_presupuesto, List<Contracts.Presupuesto.DatoVariable> dato_variable, IDbConnection currentConnection)
        {
            foreach (Contracts.Presupuesto.DatoVariable datosVariable in dato_variable)
            {
                switch (datosVariable.cod_campo)
                {
                    case "DES_DESTINO":
                        DataAccess.DatosVariables.Agrega_txt_campo(num_presupuesto, datosVariable.cod_campo, datosVariable.txt_campo, currentConnection);
                        break;
                    case "ORI_ORIGEN":
                        DataAccess.DatosVariables.Agrega_txt_campo(num_presupuesto, datosVariable.cod_campo, datosVariable.txt_campo, currentConnection);
                        break;

                }

            }
        }

        private static void Crea_Coberturas(DatoFijo quoteInfo, IDbConnection currentConnection)
        {
            foreach (Contracts.Presupuesto.Cobertura p2000030Instance40 in quoteInfo.Coberturas)
            {
                p2000030Instance40.num_poliza = quoteInfo.num_poliza;
                DataAccess.CrearPresupuesto.PP_Insert_P2000040(p2000030Instance40, currentConnection);
            }
        }

        private static void Crea_Terceros(DatoFijo quoteInfo, IDbConnection currentConnection)
        {
            foreach (Contracts.Presupuesto.Tercero p2000030Instance60 in quoteInfo.Terceros.Where(r => r.tip_benef != "0"))
            {
                p2000030Instance60.num_poliza = quoteInfo.num_poliza;
                DataAccess.CrearPresupuesto.PP_Insert_P2000060(p2000030Instance60, currentConnection);
            }
        }

        private static void Crea_Ocurrencias(DatoFijo quoteInfo, IDbConnection currentConnection)
        {
            foreach (Contracts.Presupuesto.Ocurrencia p2000030Instance25 in quoteInfo.Ocurrencias)
            {
                p2000030Instance25.num_poliza = quoteInfo.num_poliza;
                DataAccess.CrearPresupuesto.PP_Insert_P2000025(p2000030Instance25, currentConnection);
            }
        }

        private static void Crea_P170(DatoFijo quoteInfo, IDbConnection currentConnection)
        {
            foreach (Contracts.Presupuesto.DesgloseEconomico p2000030Instance170 in quoteInfo.DesgloseEconomico)
            {
                p2000030Instance170.num_poliza = quoteInfo.num_poliza;
                DataAccess.Batch.P2100170.Create(p2000030Instance170, currentConnection);
            }
        }

        private static void Crea_P1331(DatoFijo quoteInfo, IDbConnection currentConnection)
        {
            if (quoteInfo.DetalleDeTerceros.IsNotEmpty() && quoteInfo.DetalleDeTerceros.Count > 0)
            {
                foreach (Contracts.Presupuesto.DetalleDeTercero p2000030Instance1331 in quoteInfo.DetalleDeTerceros)
                {
                    p2000030Instance1331.cod_cia = quoteInfo.cod_cia;
                    p2000030Instance1331.fec_tratamiento = quoteInfo.fec_tratamiento;
                    p2000030Instance1331.tip_mvto_batch = quoteInfo.tip_mvto_batch;
                    p2000030Instance1331.cod_act_tercero = 1;
                    p2000030Instance1331.cod_idioma = "ES";
                    if (!DataAccess.A1001331.Exist(p2000030Instance1331.tip_docum, p2000030Instance1331.cod_docum, currentConnection))
                    {
                        DataAccess.Batch.P1001331.Create(p2000030Instance1331, currentConnection);
                    }

                }
            }
        }
        private static void Crea_DatosVariables(string num_poliza, List<Contracts.Presupuesto.DatoVariable> datosVariables, IDbConnection currentConnection)
        {
            foreach (Contracts.Presupuesto.DatoVariable p2000030Instance20 in datosVariables)
            {
                Crea_DatosVariable(num_poliza, p2000030Instance20, currentConnection);
            }
        }

        public static void Crea_DatosVariable(string num_poliza, Contracts.Presupuesto.DatoVariable p2000030Instance20, IDbConnection currentConnection = null)
        {
            bool local = false;
            if (currentConnection == null)
            {
                currentConnection = Architect.DataFactory.Database.OpenConnection("Tron");
                local = true;
            }
            p2000030Instance20.num_poliza = num_poliza;
            DataAccess.CrearPresupuesto.PP_Insert_P2000020(p2000030Instance20, currentConnection);
            if (local)
            {
                Architect.DataFactory.Database.ClosedConnection(null, currentConnection);
            }
        }

        private static void Crea_Riesgos(DatoFijo quoteInfo, IDbConnection currentConnection)
        {
            foreach (Contracts.Presupuesto.Riesgo item31 in quoteInfo.Riesgos)
            {
                item31.num_poliza = quoteInfo.num_poliza;
                DataAccess.CrearPresupuesto.PP_Insert_P2000031(item31, currentConnection);
            }
        }

    }
}
