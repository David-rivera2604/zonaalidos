using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Siniestro
{
    /// <summary>
    /// Operaciones de siniestros exclusivas para Purdy
    /// </summary>
    public class Purdy
    {

        public async static void PurdyServiceRequests(int agentCode)
        {
            Architect.API.Tron.Contracts.Siniestro.Purdy.DetalleDeSiniestro detalle = null;

            if (agentCode > 0)
            {
                agentCode = Convert.ToInt32(ConfigurationManager.AppSettings["Purdy.Service.AgentCode"]);
            }

            foreach (Contracts.Siniestro.Purdy.Siniestro item in DataAccess.Siniestro.Purdy.Siniestro.Retrieve(agentCode))
            {
                detalle = await DetalleSiniestroPurdy(item.NoSiniestro, item.Expediente, item.NoPoliza);
                if (detalle != null)
                {
                    SiniestroPurdy.CreateOrUpdate(new Contracts.Siniestro.Purdy.SiniestroPurdy()
                    {
                        NUM_SINI = item.NoSiniestro,
                        NUM_EXP = item.Expediente,
                        NUM_POLIZA = item.NoPoliza,
                        TIP_EXP = detalle.TipoDeExpediente,
                        MONTO_MANO_OBRA = detalle.MontoManoDeObra,
                        MONTO_REPUESTOS = detalle.MontoDeRepuestos,
                        MONTO_TOTAL = detalle.MontoTotal,
                        MONTO_OTRO_RUBROS = detalle.MontoOtrosRubros,
                        MONTO_DEDUCIBLE = detalle.MontoDeducible,
                        MONTO_RECUPERADO = detalle.MontoRecuperado,
                        FECHA_ULTIMO_PAGO = detalle.FechaUltimoPago == null ? DateTime.MinValue : detalle.FechaUltimoPago.Value,
                        FECHA_RECUPERACION = detalle.FechaRecuperación == null ? DateTime.MinValue : detalle.FechaRecuperación.Value,
                        TIP_EST_EXP = detalle.TipoDeExpediente
                    });
                }
            }
        }

        /// <summary>
        /// Recupera una lista de siniestros por agente para un rango de fecha de ocurrencia.
        /// </summary>
        /// <param name="startDate">Fecha inicial de ocurrencia del siniestro.</param>
        /// <param name="endDate">Fecha final de ocurrencia del siniestro.</param>
        /// <param name="cod_agt">Código de agente.</param>
        /// <returns>Lista de siniestros.</returns>
        public static List<Contracts.Siniestro.Purdy.Siniestro> Retrieve(DateTime startDate, DateTime endDate, Core.Contracts.Security.Token tokenInfo)
        {
            return DataAccess.Siniestro.Purdy.Siniestro.Retrieve(startDate, endDate, tokenInfo.AgentCode);
        }

        internal async static Task<Architect.API.Tron.Contracts.Siniestro.Purdy.DetalleDeSiniestro> DetalleSiniestroPurdy(Int64 siniestro, int expediente, string poliza)
        {
            Architect.API.Tron.Contracts.Siniestro.Purdy.DetalleDeSiniestro result = new Contracts.Siniestro.Purdy.DetalleDeSiniestro();
            string resultResponse = string.Empty;
            try
            {
                var url = string.Format("APIPATH?siniestro={0}&expediente={1}&polizas={2}", siniestro, expediente, poliza);
                HttpClient client = new HttpClient() { Timeout = new TimeSpan(0, 0, 2) };
                var response = await client.GetAsync(url).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {

                    resultResponse = response.Content.ReadAsStringAsync().Result;

                    if (resultResponse.IsNotEmpty())
                    {
                        result = JsonConvert.DeserializeObject<Architect.API.Tron.Contracts.Siniestro.Purdy.DetalleDeSiniestro>(resultResponse);
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Data.Add("resultResponse", resultResponse);
                throw ex;
            }
            return result;
        }

    }
}
