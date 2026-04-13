using Architect.Utilities.Extensions;
using Architect.API.Core.Business.General;
using System;
using System.Collections.Generic;
using System.Configuration;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Architect.DocuSign.Integrations.Providers.Evicertia.Contracts;
using System.Linq;


namespace Architect.API.Tron.Business.Emision
{
    /// <summary>
    /// Emision de Poliza Viajero en TRON
    /// </summary>
    public static class Viajero
    {

        /// <summary>
        /// Devuelve información de un presupuesto para la emisión de una póliza de viajero.
        /// </summary>
        public static Contracts.Emision.Viajero Setup(string presupuesto, string mode, Core.Contracts.Security.Token tokenInfo)
        {

            Contracts.Emision.Viajero result = null;
            Contracts.Traza.TrackSession session = Traza.TrackRequest.NewSession(tokenInfo, "Viajero/Issue/Setup", result);

            try
            {

                string key = string.Format("viajero.{0}", presupuesto);

                if (mode == "resume")
                {
                    //Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.RetrieveByProposalId(presupuesto, tokenInfo.CompanyId);

                    Contracts.Presupuesto.DatoFijo P30Instance = DataAccess.LeerPresupuesto.Presupuesto(1, presupuesto, 0, 0, 0, null, true);
                    Contracts.Cotizacion.Viajero resultInfo2 = Cotizacion.ViajeroConvert.FromTron_Full(P30Instance);

                    resultInfo2.coberturas.Remove(resultInfo2.coberturas.Find(r => r.codigo == 9998));

                    Utilities.Cache.SetItem(key, Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo2), -1);
                }

                if (Architect.Utilities.Cache.Exist(key))
                {
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.Viajero>(Architect.Utilities.Cache.GetItem(key).ToString());

                    result.terceros = Default_Terceros(result);

                    result.terceros = Reglas.research.Apply_Terceros("Viajero", result.terceros, string.Empty, result.num_contrato, tokenInfo);

                    result.documentosrequeridos = Reglas.research.Apply_DocumentosRequeridos("Viajero", null, 0, tokenInfo);

                }
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(ex, session.MessageId);

                session.ResponseStatus = 400;
                session.ResponseText = ex.Message;
            }

            Traza.TrackRequest.CloseSession(session, result);

            return result;
        }

        private static List<Contracts.Comun.tercero> Default_Terceros(Contracts.Emision.Viajero quoteInfo)
        {
            List<Contracts.Comun.tercero> result = new List<Contracts.Comun.tercero>();
            DateTime[] values = { DateTime.MinValue, quoteInfo.FEC_NACIMIENTO, quoteInfo.FEC_NACIMIENTO2, quoteInfo.FEC_NACIMIENTO3, quoteInfo.FEC_NACIMIENTO4, quoteInfo.FEC_NACIMIENTO5, quoteInfo.FEC_NACIMIENTO6, quoteInfo.FEC_NACIMIENTO7, quoteInfo.FEC_NACIMIENTO8, quoteInfo.FEC_NACIMIENTO9, quoteInfo.FEC_NACIMIENTO10 };
            for (int riesgo = 1; riesgo <= quoteInfo.cantidad_riesgos; riesgo++)
            {
                result.Add(new Contracts.Comun.tercero()
                {
                    tercerosId = riesgo,
                    tipodetercero = 2, //Asegurado
                    tipodeterceroDesc = Reglas.research.tip_benef_lookup(2),
                    DocumentNumberType = 0,
                    DocumentNumber = string.Empty,
                    nombre = string.Empty,
                    apellido1 = null,
                    apellido2 = null,
                    fechadenacimiento = values[riesgo],
                    tercerosMca_sexo = 0,
                    tercerosMca_sexoDesc = string.Empty,
                    estadoCivil = string.Empty,
                    estadoCivilDesc = string.Empty,
                    numerodetelefono = string.Empty,
                    correoelectronico = string.Empty,
                    cod_pais = "CRI",
                    TProvincia = 0,
                    TProvinciaDesc = string.Empty,
                    TCanton = 0,
                    TCantonDesc = string.Empty,
                    TDistrito = 0,
                    TDistritoDesc = string.Empty,
                    otrasenas = string.Empty,
                    eltomadoreselmismoasegurado = 2,
                    elaseguradoeselconductorhabitual = 0,
                    numerodeprestamo = null,
                    importedecesion = 0,
                    vencimientodecesion = DateTime.MinValue,
                    porcentajeacredor = 0,
                    parentesco = 0,
                    porcentaje = 0,
                    NoEditable = false,
                    numeroderiesgo = riesgo
                });
            }

            return result;
        }

        /// <summary>
        /// Realiza la validación de datos y emisión de una póliza de viajero.
        /// </summary>
        public static Contracts.Emision.Viajero Issue(Contracts.Emision.Viajero quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {

            Contracts.Emision.Viajero resultQuoteInfo = null;

            Contracts.Traza.TrackSession session = Traza.TrackRequest.NewSession(tokenInfo, "Viajero/Issue/Issue", quoteInfo);

            try
            {
                Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = ViajeroConvertTo.Tron(quoteInfo);

                result.user_txt_motivo_spto = quoteInfo.user_txt_motivo_spto;

                Architect.API.Tron.Contracts.Poliza.DatoFijo result2 = Backoffice.Emision.Generico.Emitir(result, tokenInfo);

                resultQuoteInfo = ViajeroConvertFrom.Quote(quoteInfo, result2);

                if (resultQuoteInfo.num_poliza.IsNotEmpty())
                {
                    Core.Business.General.ChangeSet.Create(3000, Convert.ToInt64(resultQuoteInfo.num_poliza), tokenInfo.CompanyId, "Emisión Seguro de Viaje", $"Póliza #{resultQuoteInfo.num_poliza}, desde el presupuesto #{quoteInfo.presupuesto}", tokenInfo.UserId, resultQuoteInfo);

                    //Se cambian los adjuntos creados al número de presupuesto al número de póliza generado
                    Core.Business.General.Attachment.ChangeEntityId(tokenInfo.CompanyId, 3000, Convert.ToInt64(resultQuoteInfo.presupuesto), 3000, Convert.ToInt64(resultQuoteInfo.num_poliza), tokenInfo.UserId);

                    //Se almacena la informacion de la póliza.
                    resultQuoteInfo.roles = tokenInfo.Roles;
                    Core.Business.General.CustomData.Create(tokenInfo, 3002, Convert.ToInt64(resultQuoteInfo.num_poliza),
                                                            Newtonsoft.Json.JsonConvert.SerializeObject(quoteInfo), "ISSUE-P-" + resultQuoteInfo.num_poliza, resultQuoteInfo.num_poliza);
                    Core.Business.General.CustomData.Create(tokenInfo, 3003, Convert.ToInt64(resultQuoteInfo.num_poliza),
                                                            Newtonsoft.Json.JsonConvert.SerializeObject(resultQuoteInfo), "ISSUE-R-" + resultQuoteInfo.num_poliza, resultQuoteInfo.num_poliza);

                    //resultQuoteInfo = Asistencia_Panama(quoteInfo, resultQuoteInfo, tokenInfo.Roles);

                    //(r => r.tipodetercero == 1)
                    if (tokenInfo.Roles.Contains("Scotiabank"))
                    {
                        bool enviado = Integraciones.FacturaElectronica.Generar
                                                        (tokenInfo.CompanyId,
                                                         441,
                                                         resultQuoteInfo.num_poliza, resultQuoteInfo.cod_mon,
                                                         result2.Calculado.Recibos.FirstOrDefault(),
                                                         quoteInfo.terceros.Where(r => r.tipodetercero == 1).FirstOrDefault());


                        ChangeSet.Create(3000, Convert.ToInt64(resultQuoteInfo.num_poliza), tokenInfo.CompanyId, "Emisión Seguro de Viaje",
                            enviado ? $"Póliza #{resultQuoteInfo.num_poliza}, factura electrónica enviada"
                                   : $"Póliza #{resultQuoteInfo.num_poliza}, falló el envio de la factura electrónica", tokenInfo.UserId, resultQuoteInfo);
                    }
                }
                else if (resultQuoteInfo.Mensaje.IsNotEmpty())
                {
                    string message = resultQuoteInfo.Mensaje;
                    ChangeSet.Create(3000, Convert.ToInt64(quoteInfo.presupuesto), tokenInfo.CompanyId, "Emisión Seguro de Viaje", message, tokenInfo.UserId, resultQuoteInfo);
                }
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(ex, session.MessageId);

                session.ResponseStatus = 400;
                session.ResponseText = ex.Message;
            }

            Traza.TrackRequest.CloseSession(session, resultQuoteInfo);


            return resultQuoteInfo;
        }

        public static Contracts.Emision.Viajero Asistencia_Panama(Contracts.Emision.Viajero quoteInfo, Contracts.Emision.Viajero resultQuoteInfo, string roles)
        {
            //
            if (roles.Contains("Grupo_Monge"))
            {
                var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Monge"], ConfigurationManager.AppSettings["Warranty.Pass.Monge"]);
                var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Monge"]); //Test- "DL0001S" //PRD: DL0001Q
                resultQuoteInfo.envio_asistencia = envio_poliza_panama;
            }
            else if (roles.Contains("Confia"))
            {
                var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Confia"], ConfigurationManager.AppSettings["Warranty.Pass.Confia"]);
                var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Confia"]);
                resultQuoteInfo.envio_asistencia = envio_poliza_panama;
            }
            else if (roles.Contains("Innova"))
            {
                var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Innova"], ConfigurationManager.AppSettings["Warranty.Pass.Innova"]);
                var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Innova"]);
                resultQuoteInfo.envio_asistencia = envio_poliza_panama;
            }
            else if (roles.Contains("Martha"))
            {
                var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Martha"], ConfigurationManager.AppSettings["Warranty.Pass.Martha"]);
                var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Martha"]);
                resultQuoteInfo.envio_asistencia = envio_poliza_panama;
            }
            else if (roles.Contains("Prisma"))
            {
                var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Prisma"], ConfigurationManager.AppSettings["Warranty.Pass.Prisma"]);
                var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Prisma"]);
                resultQuoteInfo.envio_asistencia = envio_poliza_panama;
            }
            else if (roles.Contains("GSI"))
            {
                var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.GSI"], ConfigurationManager.AppSettings["Warranty.Pass.GSI"]);
                var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.GSI"]);
                resultQuoteInfo.envio_asistencia = envio_poliza_panama;
            }
            else if (roles.Contains("IBG"))
            {
                var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.IBG"], ConfigurationManager.AppSettings["Warranty.Pass.IBG"]);
                var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.IBG"]);
                resultQuoteInfo.envio_asistencia = envio_poliza_panama;
            }
            else if (roles.Contains("Metropolitanos"))
            {
                var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Metropolitanos"], ConfigurationManager.AppSettings["Warranty.Pass.Metropolitanos"]);
                var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Metropolitanos"]);
                resultQuoteInfo.envio_asistencia = envio_poliza_panama;
            }
            else if (roles.Contains("Proteccion"))
            {
                var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Proteccion"], ConfigurationManager.AppSettings["Warranty.Pass.Proteccion"]);
                var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Proteccion"]);
                resultQuoteInfo.envio_asistencia = envio_poliza_panama;
            }
            else if (roles.Contains("Popular"))
            {
                var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Popular"], ConfigurationManager.AppSettings["Warranty.Pass.Popular"]);
                var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Popular"]);
                resultQuoteInfo.envio_asistencia = envio_poliza_panama;
            }
            else if (roles.Contains("Davivienda"))
            {
                var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Davivienda"], ConfigurationManager.AppSettings["Warranty.Pass.Davivienda"]);
                var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Davivienda"]);
                resultQuoteInfo.envio_asistencia = envio_poliza_panama;
            }
            else if (roles.Contains("Coopeservidores"))
            {
                var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Coopeservidores"], ConfigurationManager.AppSettings["Warranty.Pass.Coopeservidores"]);
                var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Coopeservidores"]);
                resultQuoteInfo.envio_asistencia = envio_poliza_panama;
            }
            else if (roles.Contains("Comercial"))
            {
                var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Comercial"], ConfigurationManager.AppSettings["Warranty.Pass.Comercial"]);
                var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Comercial"]);
                resultQuoteInfo.envio_asistencia = envio_poliza_panama;
            }
            else if (roles.Contains("BCR"))
            {
                var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.BCR"], ConfigurationManager.AppSettings["Warranty.Pass.BCR"]);
                var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.BCR"]);
                resultQuoteInfo.envio_asistencia = envio_poliza_panama;
            }
            else // Se usa el dealer MAPFRE para todos en general
            {
                var token_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.login(ConfigurationManager.AppSettings["Warranty.User.Mapfre"], ConfigurationManager.AppSettings["Warranty.Pass.Mapfre"]);
                var envio_poliza_panama = Architect.WS.Integrations.PanamaAsistencia.Envio_Poliza_441.envio_XML(token_panama, quoteInfo, resultQuoteInfo, ConfigurationManager.AppSettings["Warranty.Dealer.Mapfre"]);
                resultQuoteInfo.envio_asistencia = envio_poliza_panama;
            }

            if (resultQuoteInfo.envio_asistencia.IsNotEmpty())
            {
                Utilities.Log.WarningLog("Respuesta Asistencia_Panama", resultQuoteInfo.envio_asistencia + " Poliza: " + resultQuoteInfo.num_poliza, "asistencia.panama");
            }

            return resultQuoteInfo;
        }


        /// <summary>
        /// Permite el monitoreo díario de recibos pagados para polizas de viajeros.
        /// </summary>
        public static void MonitorRecibosCobrado(DateTime fec_cobro)
        {
            Int64 num_poliza = 0;
            if (fec_cobro == null)
            {
                fec_cobro = DateTime.Now;
            }
            List<Contracts.Pagos.Recibo> recibos = DataAccess.Pagos.Recibos.RecibosCobradoPorRamo(441, fec_cobro);

            if (recibos?.Count > 0)
            {
                foreach (Contracts.Pagos.Recibo item in recibos)
                {
                    Contracts.Emision.Viajero quoteInfo = null;
                    Contracts.Emision.Viajero resultQuoteInfo = null;
                    num_poliza = Convert.ToInt64(item.NUM_POLIZA);
                    Core.Contracts.General.CustomData customData = CustomData.RetrieveByEntity(3002, num_poliza);
                    if (!string.IsNullOrEmpty(customData?.Data))
                    {
                        quoteInfo = JsonConvert.DeserializeObject<Contracts.Emision.Viajero>(customData.Data);

                        customData = CustomData.RetrieveByEntity(3003, num_poliza);
                        if (!string.IsNullOrEmpty(customData?.Data))
                        {
                            resultQuoteInfo = JsonConvert.DeserializeObject<Contracts.Emision.Viajero>(customData.Data);

                        }

                    }

                    if (quoteInfo != null && resultQuoteInfo != null)
                    {
                        resultQuoteInfo = Asistencia_Panama(quoteInfo, resultQuoteInfo, resultQuoteInfo.roles);

                        CustomData.Delete(3002, Convert.ToInt64(item.NUM_POLIZA));
                        CustomData.Delete(3003, Convert.ToInt64(item.NUM_POLIZA));

                    }
                }
            }

        }
    }
}
