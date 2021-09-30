using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Operaciones relacionadas a las pólizas de TRON.
    /// </summary>
    public static class Poliza
    {

        /// <summary>
        /// Recupera los datos variables de una póliza
        /// </summary>
        public static List<Contracts.Poliza.DatoVariacion> DatosVariables(string num_poliza)
        {
            List<Contracts.Poliza.DatoVariable> data = DataAccess.DatosVariables.RetrieveByPolicy(Int32.Parse(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]), num_poliza);
            List<Contracts.Poliza.DatoVariacion> result = new List<Contracts.Poliza.DatoVariacion>();

            foreach (Contracts.Poliza.DatoVariable item in data)
            {
                result.Add(new Contracts.Poliza.DatoVariacion() { cod_campo = item.cod_campo, val_campo_act = item.val_campo });
            }
            return result;
        }

        /// <summary>
        /// Aplica variaciones a una póliza
        /// </summary>
        public static bool Variaciones(string num_poliza, Contracts.Poliza.Variacion variacion)
        {
            bool result = false;
            IDbConnection currentConnection = DataFactory.Database.OpenConnection("Tron");
            try
            {
                foreach (Contracts.Poliza.DatoVariacion item in variacion.Detalle)
                {
                    if (item.val_campo_ant != item.val_campo_act)
                    {
                        DataAccess.DatosVariables.AplicarVariacion(variacion.cod_ramo, num_poliza, variacion.num_riesgo,
                            item.cod_campo, item.val_campo_ant, item.val_campo_act, variacion.fec_validez, "ZA: " + variacion.txt_obs, currentConnection);
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Falla al tratar de procesar las variaciones", "Póliza " + num_poliza, ex);
            }

            currentConnection.Close();
            return result;
        }

    }
}