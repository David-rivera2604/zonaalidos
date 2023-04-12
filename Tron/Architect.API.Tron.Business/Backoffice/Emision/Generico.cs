using Architect.API;
using Architect.API.Tron.Contracts.Batch;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace Architect.API.Tron.Business.Backoffice.Emision
{
    /// <summary>   
    /// Permite realizar la emisión de pólizas genéricas.
    /// </summary>
    public static class Generico
    {

        public static Contracts.Poliza.DatoFijo Emitir(Contracts.Presupuesto.DatoFijo s2000030Instance, Architect.API.Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Poliza.DatoFijo a2000030Instance;

            using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
            {

                // se llena el objeto para insertar en la g2000510 para generar el numero de orden
                Contracts.Batch.Proceso g2000510Instance = new Contracts.Batch.Proceso()
                {
                    fec_tratamiento = DateTime.Today,
                    num_orden = 0,
                    tip_mvto_batch = 3.ToString(),
                    cod_cia = 1,
                    txt_alias = "Emisión desde cotización",
                    tip_situ_filtro = 3.ToString(),
                    nom_prg_excepcion = string.Empty,
                    mca_recalcula_fecha = "N",
                    tip_fecha_base = string.Empty,
                    cod_usr = "COTIZWEB",
                    num_presupuesto = s2000030Instance.num_poliza
                };

                // se manda a ejecutar el procedimiento que inserta en la g2000510 y devuelve el numero de orden
                Architect.API.Tron.DataAccess.Batch.G2000510.Create(g2000510Instance, currentConnection);
                s2000030Instance.fec_tratamiento = g2000510Instance.fec_tratamiento;
                s2000030Instance.num_orden = g2000510Instance.num_orden;
                s2000030Instance.tip_mvto_batch = g2000510Instance.tip_mvto_batch;

                //Emitir a la fecha del día
                Util.ChangeEffectiveDate(s2000030Instance, tokenInfo, currentConnection);

                Sincroniza_DetalleDeTerceros(s2000030Instance, currentConnection, g2000510Instance);

                Sincroniza_DatosVariables(s2000030Instance, currentConnection);

                Sincroniza_Terceros(s2000030Instance, currentConnection);

                // envía el numero de presupuesto y los datos de la g2000510 para ejecutar el método de emitir desde una cotización
                g2000510Instance = DataAccess.Batch.G2000510.ExecutePolicyFromQuotation(g2000510Instance, s2000030Instance.num_poliza, currentConnection); // numpresupuesto
                if (g2000510Instance.txt_error.IsEmpty())
                {
                    a2000030Instance = DataAccess.LeerPoliza.Poliza(g2000510Instance.cod_cia, g2000510Instance.num_poliza_definitivo, 0, 0, 0, currentConnection, true, "onlyresult");
                    a2000030Instance.Error_Emision = g2000510Instance.txt_error;
                }
                else
                {
                    var item = new Contracts.Poliza.DatoFijo
                    {
                        cod_cia = g2000510Instance.cod_cia,
                        num_poliza = g2000510Instance.num_poliza_definitivo,
                        num_spto = 0,
                        num_apli = 0,
                        num_spto_apli = 0
                    };
                    a2000030Instance = item;
                    a2000030Instance.Error_Emision = g2000510Instance.txt_error;
                }

                a2000030Instance.DatosDelProceso = g2000510Instance;

                // Se actualiza la información complementaria de terceros (dirección, correo y estado civil)
                Actualiza_Terceros_InfoComplementaria(s2000030Instance, currentConnection);

                currentConnection.Close();
            }

            return a2000030Instance;
        }

        /// <summary>
        /// Se actualiza la información complementaria de terceros (dirección, correo y estado civil)
        /// </summary>
        private static void Actualiza_Terceros_InfoComplementaria(Contracts.Presupuesto.DatoFijo s2000030Instance, IDbConnection currentConnection)
        {
            if (s2000030Instance.DetalleDeTerceros.IsNotEmpty() && s2000030Instance.DetalleDeTerceros.Count > 0)
            {
                foreach (Contracts.Presupuesto.DetalleDeTercero item1331 in s2000030Instance.DetalleDeTerceros)
                {
                    DataAccess.A1001331.P_Actualiza_Terceros(
                        new Contracts.Poliza.DetalleDeTercero()
                        {
                            cod_pais = "CRI",
                            tip_docum = item1331.tip_docum,
                            cod_docum = item1331.cod_docum,
                            cod_est_civil = item1331.cod_est_civil,
                            cod_estado = item1331.cod_estado.ToString(),
                            cod_prov = item1331.cod_prov.ToString(),
                            cod_localidad = item1331.cod_localidad.ToString(),
                            nom_domicilio1 = item1331.nom_domicilio1,
                            tlf_numero = item1331.tlf_numero,
                            email = item1331.email
                        },
                        currentConnection);
                }
            }
        }

        private static void Sincroniza_Terceros(Contracts.Presupuesto.DatoFijo s2000030Instance, IDbConnection currentConnection)
        {
            //Se elimina el tercero genérico
            DataAccess.Batch.P2000060.Delete(s2000030Instance.num_poliza, currentConnection);
            if (s2000030Instance.Terceros.IsNotEmpty() && s2000030Instance.Terceros.Count > 0)
            {
                foreach (Contracts.Presupuesto.Tercero p2000030Instance60 in s2000030Instance.Terceros)
                {
                    p2000030Instance60.num_poliza = s2000030Instance.num_poliza;
                    if (!DataAccess.Batch.P2000060.Exist(p2000030Instance60.tip_docum, p2000030Instance60.cod_docum, s2000030Instance.num_poliza, p2000030Instance60.tip_benef, currentConnection))
                    {
                        DataAccess.CrearPresupuesto.PP_Insert_P2000060(p2000030Instance60, currentConnection);
                    }					 
                }
            }
        }

        private static void Sincroniza_DatosVariables(Contracts.Presupuesto.DatoFijo s2000030Instance, IDbConnection currentConnection)
        {
            if (s2000030Instance.DatosVariables.IsNotEmpty() && s2000030Instance.DatosVariables.Count > 0)
            {
                foreach (Contracts.Presupuesto.DatoVariable p2000030Instance20 in s2000030Instance.DatosVariables)
                {
                    p2000030Instance20.num_poliza = s2000030Instance.num_poliza;
                    if (DataAccess.Batch.P2000020.Exist(p2000030Instance20.num_poliza, p2000030Instance20.cod_campo, currentConnection))
                    {
                        DataAccess.Batch.P2000020.Update(p2000030Instance20.num_poliza, p2000030Instance20.cod_campo, p2000030Instance20.val_campo, currentConnection);
                    }
                    else
                    {
                        DataAccess.CrearPresupuesto.PP_Insert_P2000020(p2000030Instance20, currentConnection);
                    }
                }
            }
        }

        private static void Sincroniza_DetalleDeTerceros(Contracts.Presupuesto.DatoFijo s2000030Instance, IDbConnection currentConnection, Proceso g2000510Instance)
        {
            string tip_docum = string.Empty;
            string cod_docum = string.Empty;
            if (s2000030Instance.DetalleDeTerceros.IsNotEmpty() && s2000030Instance.DetalleDeTerceros.Count > 0)
            {
                foreach (Contracts.Presupuesto.DetalleDeTercero item1331 in s2000030Instance.DetalleDeTerceros)
                {
                    item1331.cod_cia = g2000510Instance.cod_cia;
                    item1331.fec_tratamiento = g2000510Instance.fec_tratamiento;
                    item1331.tip_mvto_batch = g2000510Instance.tip_mvto_batch;
                    item1331.cod_act_tercero = 1;
                    item1331.cod_idioma = "ES";
                    if (!DataAccess.A1001331.Exist(item1331.tip_docum, item1331.cod_docum, currentConnection))
                    {
                        DataAccess.CrearPresupuesto.PP_Insert_P1001331(item1331, currentConnection);
                    }

                    if (item1331.titular)
                    {
                        tip_docum = item1331.tip_docum;
                        cod_docum = item1331.cod_docum;
                    }
                }
            }
            DataAccess.Batch.P2000030.Update(tip_docum, cod_docum, s2000030Instance.num_poliza, currentConnection);
        }

    }
}
