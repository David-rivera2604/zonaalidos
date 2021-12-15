using Architect.Utilities.Extensions;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Architect.API.Tron.Business.Emision
{
    /// <summary>
    /// Emision de Poliza Viajero en TRON
    /// </summary>
    public static class Viajero
    {

        public static Contracts.Emision.Viajero Setup(string presupuesto, Core.Contracts.Security.Token tokenInfo)
        {

            Contracts.Emision.Viajero result = null;
            string key = string.Format("viajero.{0}", presupuesto);

            if (Architect.Utilities.Cache.Exist(key))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.Viajero>(Architect.Utilities.Cache.GetItem(key).ToString());

                result.terceros = Reglas.research.Apply_Terceros("Viajero", result.terceros, string.Empty, tokenInfo);

                result.documentosrequeridos = Reglas.research.Apply_DocumentosRequeridos("Viajero", null, 0, tokenInfo);

            }

            return result;
        }

        public static Contracts.Emision.Viajero Issue(Contracts.Emision.Viajero quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {

            Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = ViajeroConvertTo.Tron(quoteInfo);

            Architect.API.Tron.Contracts.Poliza.DatoFijo result2 = Backoffice.Emision.Generico.Emitir(result, tokenInfo);

            Contracts.Emision.Viajero resultQuoteInfo = ViajeroConvertFrom.Quote(quoteInfo, result2);

            if (resultQuoteInfo.num_poliza.IsNotEmpty())
            {
                Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultQuoteInfo.num_poliza.Substring(4)), tokenInfo.CompanyId, "Emisión Seguro de Viaje", "Póliza #" + resultQuoteInfo.num_poliza, tokenInfo.UserId, resultQuoteInfo);

                //Se cambian los adjuntos creados al número de presupuesto al número de póliza generado
                Core.Business.General.Attachment.ChangeEntityId(tokenInfo.CompanyId, 3000, Convert.ToInt64(resultQuoteInfo.presupuesto), 3000, Convert.ToInt64(resultQuoteInfo.num_poliza), tokenInfo.UserId);

                //Llamado a Servicio de  Asistencia Panama (Ojo) Credenciales de Monge TEST
                if (tokenInfo.Roles.Contains("Grupo_Monge"))
                { 
                var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Monge"], ConfigurationManager.AppSettings["Warranty.Pass.Monge"]);
                var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Monge"]); //Test- "DL0001S" //PRD: DL0001Q
                    resultQuoteInfo.envio_asistencia = envio_poliza_panama;
                }
                if (tokenInfo.Roles.Contains("Mapfre"))
                {
                    var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Mapfre"], ConfigurationManager.AppSettings["Warranty.Pass.Mapfre"]);
                    var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Mapfre"]);
                    resultQuoteInfo.envio_asistencia = envio_poliza_panama;
                }
                if (tokenInfo.Roles.Contains("Confia"))
                {
                    var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Confia"], ConfigurationManager.AppSettings["Warranty.Pass.Confia"]);
                    var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Confia"]);
                    resultQuoteInfo.envio_asistencia = envio_poliza_panama;
                }
                if (tokenInfo.Roles.Contains("Innova"))
                {
                    var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Innova"], ConfigurationManager.AppSettings["Warranty.Pass.Innova"]);
                    var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Innova"]);
                    resultQuoteInfo.envio_asistencia = envio_poliza_panama;
                }
                if (tokenInfo.Roles.Contains("Martha"))
                {
                    var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Martha"], ConfigurationManager.AppSettings["Warranty.Pass.Martha"]);
                    var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Martha"]);
                    resultQuoteInfo.envio_asistencia = envio_poliza_panama;
                }
                if (tokenInfo.Roles.Contains("Prisma"))
                {
                    var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Prisma"], ConfigurationManager.AppSettings["Warranty.Pass.Prisma"]);
                    var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Prisma"]);
                    resultQuoteInfo.envio_asistencia = envio_poliza_panama;
                }
                if (tokenInfo.Roles.Contains("GSI"))
                {
                    var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.GSI"], ConfigurationManager.AppSettings["Warranty.Pass.GSI"]);
                    var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.GSI"]);
                    resultQuoteInfo.envio_asistencia = envio_poliza_panama;
                }
                 if (tokenInfo.Roles.Contains("IBG"))
                {
                    var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.IBG"], ConfigurationManager.AppSettings["Warranty.Pass.IBG"]);
                    var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.IBG"]);
                    resultQuoteInfo.envio_asistencia = envio_poliza_panama;
                }
                if (tokenInfo.Roles.Contains("Metropolitanos"))
                {
                    var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Metropolitanos"], ConfigurationManager.AppSettings["Warranty.Pass.Metropolitanos"]);
                    var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Metropolitanos"]);
                    resultQuoteInfo.envio_asistencia = envio_poliza_panama;
                }
                if (tokenInfo.Roles.Contains("Proteccion"))
                {
                    var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Proteccion"], ConfigurationManager.AppSettings["Warranty.Pass.Proteccion"]);
                    var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Proteccion"]);
                    resultQuoteInfo.envio_asistencia = envio_poliza_panama;
                }
                if (tokenInfo.Roles.Contains("Popular"))
                {
                    var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Popular"], ConfigurationManager.AppSettings["Warranty.Pass.Popular"]);
                    var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Popular"]);
                    resultQuoteInfo.envio_asistencia = envio_poliza_panama;
                }
                if (tokenInfo.Roles.Contains("Davivienda"))
                {
                    var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Davivienda"], ConfigurationManager.AppSettings["Warranty.Pass.Davivienda"]);
                    var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Davivienda"]);
                    resultQuoteInfo.envio_asistencia = envio_poliza_panama;
                }
                if (tokenInfo.Roles.Contains("Coopeservidores"))
                {
                    var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Coopeservidores"], ConfigurationManager.AppSettings["Warranty.Pass.Coopeservidores"]);
                    var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Coopeservidores"]);
                    resultQuoteInfo.envio_asistencia = envio_poliza_panama;
                }
                if (tokenInfo.Roles.Contains("Comercial"))
                {
                    var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Comercial"], ConfigurationManager.AppSettings["Warranty.Pass.Comercial"]);
                    var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Comercial"]);
                    resultQuoteInfo.envio_asistencia = envio_poliza_panama;
                }
            }
            return resultQuoteInfo;
        }

        

    }
}
