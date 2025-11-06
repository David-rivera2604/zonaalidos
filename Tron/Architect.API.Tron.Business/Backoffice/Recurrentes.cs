using Architect.API.Core.Business;
using Architect.API.Core.Business.General;
using Architect.API.Insurance.Contracts.Bayer;
using Architect.API.Tron.DataAccess.Pagos;
using Architect.DocuSign.Integrations.Providers.Evicertia.Contracts;
using Architect.Payment.Integrations.Contracts.v2;
using Architect.Payment.Integrations.Providers.Placetopay.Contracts;
using Architect.Utilities.Extensions;
using Hangfire;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// 
    /// </summary>
    public class Recurrentes
    {

        /// <summary>
        /// Proceso 'Batch', que envía a cobro los recibos pendiente con cobro recurrente.
        /// </summary>
        [AutomaticRetry(Attempts = 0)]
        public static int PendientesRecurrentesAlCobro(DateTime fec_efect_recibo, Contracts.Pagos.RecibosParaRecobro recibosParaRecobro = null)
        {
            int recordCount = 0;
            string procesoId = Guid.NewGuid().ToString();
            Utilities.Log.TraceLog("Payment.RecurrentesAlCobro", "Inicio - Proceso pendientes recurrentes al cobro", "payment");
            List<Contracts.Pagos.Recibo> pendientes;
            try
            {
                string provider = Core.Business.Settings.StringValue(0, "Tenant.Settings.Payment.Provider");
                string filter = Core.Business.Settings.StringValue(0, "Payment.Silice.RecurringReceipts.Filter.Policies", string.Empty);
                int limitCount = Core.Business.Settings.IntegerValue(0, "Payment.Silice.RecurringReceipts.Limit.Count", 5);
                int cod_cia = Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_cia", 1);
                string prefix = Utilities.Helpers.Settings.StringValue("EMail.Test", string.Empty);
                Payment.Integrations.Contracts.OnlinePayment track = null;

                if (recibosParaRecobro == null)
                {
                    // PASO 1a: Se obtienen los recibos pendientes por cobrar.
                    pendientes = Architect.API.Tron.DataAccess.Pagos.Recibos.PendientesRecurrentesAlCobro(cod_cia, fec_efect_recibo, limitCount, filter);
                }
                else
                {
                    // PASO 1b: Se obtienen los recibos para re-cobrar.
                    pendientes = Architect.API.Tron.DataAccess.Pagos.Recibos.Recobro(cod_cia, string.Join(",", recibosParaRecobro.NUM_RECIBO));
                }

                if (pendientes.Count > 0)
                {

                    ReciboRequest reciboReq = new ReciboRequest()
                    {
                        procesoId = procesoId,
                        bankCode = "0",
                        convenioType = "0",
                        convenioCode = "0",
                        envioType = "0",
                        envioDate = DateTime.Today,
                        numPlan = "0",
                        trnExterna = true,
                        items = new List<Item>(),
                        urlWebhook = string.Format("{0}/v2/Pagos/RecurringReceipts", Utilities.Helpers.Settings.StringValue("Payment.Silice.urlWebhook"))
                    };
                    string email = string.Empty;
                    int count = 0;
                    double total = 0;
                    Item newItem = null;

                    Utilities.Log.TraceLog("Payment.RecurrentesAlCobro", String.Format("Proceso #{1}, cantidad de recibos a procesar #{0}\n", pendientes.Count, reciboReq.procesoId), "payment");

                    foreach (Contracts.Pagos.Recibo pendiente in pendientes)
                    {
                        recordCount++;
                        // PASO 2: Se prepara la información de un recibo para su cobro.
                        newItem = PreparaElCobro(prefix, reciboReq, pendiente);
                        if (newItem == null)
                        {
                            continue;
                        }

                        // PASO 3: Se crea la traza del recibo a cobro (OnlinePayment).   
                        track = CreaTraza_OnlinePayment(cod_cia, reciboReq.procesoId, newItem, pendiente);
                        newItem.ordenId = track.Id.ToString();

                        total += pendiente.IMP_RECIBO;
                        count++;
                        

                        reciboReq.totalItems = count;
                        reciboReq.totalCompleto = total;

                        // PASO 4: Se prepara la solicitud de cobro para el recibo.
                        Payment.Integrations.Providers.Placetopay.Contracts.Requests.Collect collectRequest = PreparaSolicitudDePago(newItem);

                        // PASO 5: Se envía la solicitud de cobro a Evertec.
                        Payment.Integrations.Providers.Placetopay.Contracts.CollectTransaction collectResponse = EnviaSolicitudDePago(newItem, collectRequest);

                        // PASO 6: Se procesa la respuesta de la solicitud de cobro enviada por Evertec.
                        Payment.Integrations.Contracts.InformationRequest item = ProcesaRepuestaDeSolicitudDePago(newItem, collectRequest, collectResponse);

                        bool maxTry = false;
                        try
                        {
                            item.OnlinePayment = track;

                            // PASO 7: Se actualiza el estado del pago en la traza del recibo a cobrar.
                            if (item?.status != track?.ProviderStatus)
                            {
                                Architect.Payment.Integrations.Payment.UpdateStatus(track.UpdateUserCode, track, item);
                            }

                            // PASO 8a: Se verifica si el pago fue aprobado para proceder con el pago den tron.
                            if (item?.status == "APPROVED")
                            {
                                AplicaPagoAprobado(provider, track, item);
                            }
                            else if (item?.status == "FAILED")
                            {
                                maxTry = true;
                            }
                            else if (item?.status == "REJECTED")
                            {
                                // PASO 8b: Se verifica si el pago fue rechazado para llevar el conteo de reintento por rechazos.
                                maxTry = ManejoDeReintentoPorRechazos(track, item);
                            }
                            if (maxTry)
                            {
                                // PASO 8c: Se marca la tarjeta para que no sea usada en el mes actual.
                                MarcaTarjetaParaPoderSerUsadaHastaElProximoMes(track, item);
                            }
                        }
                        catch (Exception exi)
                        {
                            Utilities.Log.ErrorLog("Payment", "RecurrentesAlCobro", exi);
                            Utilities.Log.TraceLog("Payment.RecurrentesAlCobro", string.Format("FALLA: controlada para {0} - {1}", item.description, exi.Message), "payment");
                        }

                    }
                    EnviarReporteDeDomiciliacion(reciboReq);
                }

            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Payment", "RecurrentesAlCobro", ex);
                Utilities.Log.TraceLog("Payment.RecurrentesAlCobro", string.Format("FALLA: no controlada del proceso #{0} - {1}", procesoId, ex.Message), "payment");
                recordCount = -1;
            }

            Utilities.Log.TraceLog("Payment.RecurrentesAlCobro", string.Format("Fin - Proceso pendientes recurrentes al cobro ({0})", recordCount), "payment");
            return recordCount;
        }

        /// <summary>
        /// PASO 2: Se prepara la información de un recibo para su cobro.
        /// </summary>
        private static Architect.Payment.Integrations.Contracts.v2.Item PreparaElCobro(string prefix, ReciboRequest reciboReq, Contracts.Pagos.Recibo pendiente)
        {
            Item newItem = null;
            string email = pendiente.EMAIL;
            if (string.IsNullOrEmpty(email))
                email = pendiente.EMAIL_COM;
            if (string.IsNullOrEmpty(email))
                email = pendiente.TXT_EMAIL;

            if (!string.IsNullOrEmpty(email))
            {
                newItem = new Item()
                {
                    productCode = "0",
                    subtotal = pendiente.IMP_RECIBO.ToString(),
                    impuestos = "0",
                    emailCliente = email,
                    total = pendiente.IMP_RECIBO.ToString(),
                    ordenId = pendiente.NUM_RECIBO.ToString(),
                    origen = "api",
                    expectedCollectionPaidDate = DateTime.Today,
                    moneda = pendiente.NOM_MON,
                    concepto = string.Format("MAPFRE: {3}. {0}. POLIZA #{1} RECIBO #{2}", pendiente.NOM_RAMO, pendiente.NUM_POLIZA, pendiente.NUM_RECIBO, pendiente.NOM_SECTOR),
                    token = pendiente.TOKEN,

                    firstname = pendiente.NOM_TERCERO,
                    lastname = pendiente.APE1_TERCERO,
                    documenttype = pendiente.TIP_DOCUM,
                    document = pendiente.COD_DOCUM,
                    mobile = pendiente.TLF_NUMERO.OnlyNumbers()
                };
                reciboReq.items.Add(newItem);
                if (string.IsNullOrEmpty(prefix))
                {
                    newItem.emailCliente = reciboReq.items.Last().emailCliente;
                }
                else
                {
                    newItem.emailCliente = prefix;
                }
            }

            return newItem;
        }

        /// <summary>
        /// PASO 3: Se crea la traza del recibo a cobro (OnlinePayment).  
        /// </summary>
        private static Payment.Integrations.Contracts.OnlinePayment CreaTraza_OnlinePayment(int cod_cia, string procesoId, Architect.Payment.Integrations.Contracts.v2.Item newItem, Contracts.Pagos.Recibo pendiente)
        {
            return Payment.Integrations.Providers.Silice.Payment.TrackOnlinePayment(cod_cia, 0, newItem,
                          pendiente.NUM_POLIZA, pendiente.NUM_RECIBO, pendiente.IMP_RECIBO,
                          pendiente.TIP_DOCUM, pendiente.COD_DOCUM, pendiente.NOM_TERCERO, pendiente.APE1_TERCERO, pendiente.TLF_NUMERO, pendiente.COD_AGT, procesoId);
        }

        /// <summary>
        /// PASO 4: Se prepara la solicitud de cobro para el recibo.
        /// </summary>
        private static Payment.Integrations.Providers.Placetopay.Contracts.Requests.Collect PreparaSolicitudDePago(Item item)
        {
            return new Payment.Integrations.Providers.Placetopay.Contracts.Requests.Collect()
            {
                auth = Payment.Integrations.Providers.Placetopay.Webcheckout.BuildAuth("Recurring", item.moneda),
                payer = new Architect.Payment.Integrations.Providers.Placetopay.Contracts.Person()
                {
                    name = item.firstname,
                    surname = item.lastname,
                    email = item.emailCliente,
                    document = item.document,
                    documentType = Architect.Payment.Integrations.Providers.Placetopay.Webcheckout.IdentificationTypeConvert(item.documenttype),
                    mobile = item.mobile
                },
                payment = new Architect.Payment.Integrations.Providers.Placetopay.Contracts.PaymentRequest()
                {
                    reference = item.ordenId,
                    description = item.concepto,
                    amount = new Architect.Payment.Integrations.Providers.Placetopay.Contracts.Amount()
                    {
                        currency = item.moneda,
                        total = Convert.ToDouble(item.total)
                    }
                },
                instrument = new Architect.Payment.Integrations.Providers.Placetopay.Contracts.Instrument()
                {
                    token = new Architect.Payment.Integrations.Providers.Placetopay.Contracts.Token()
                    {
                        token = item.token
                    }
                },
                expiration = DateTime.Now.AddMinutes(Utilities.Helpers.Settings.IntegerValue("Payment.Placetopay.TimeOut", 10)),
                locale = "es_CR",
                ipAddress = "127.0.0.1",
                userAgent = "MAPFRE - Aliados",
                returnUrl = Utilities.Helpers.Settings.StringValue("Payment.Placetopay.ReturnUrl.Recurring")
            };
        }

        /// <summary>
        /// PASO 5: Se envía la solicitud de cobro a Evertec.
        /// </summary>
        private static Payment.Integrations.Providers.Placetopay.Contracts.CollectTransaction EnviaSolicitudDePago(Item item, Payment.Integrations.Providers.Placetopay.Contracts.Requests.Collect collectRequest)
        {
            string payLoad = JsonConvert.SerializeObject(collectRequest, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

            Utilities.Log.TraceLog("Payment.RecurrentesAlCobro", string.Format("  Información: {0}\nSolicitud: {1}\n", item.concepto, payLoad), "payment");

            Payment.Integrations.Providers.Placetopay.Contracts.CollectTransaction collectResponse = Collect(payLoad).Result;

            Utilities.Log.TraceLog("Payment.RecurrentesAlCobro", string.Format("  Información: {0}\nRespuesta: {1}\n", item.concepto, collectResponse.rawresponse), "payment");
            return collectResponse;
        }

        /// <summary>
        /// PASO 5-A: Realiza el cobro a la tarjeta de un cliente
        /// </summary>
        private async static Task<CollectTransaction> Collect(string payLoad)
        {
            CollectTransaction collectResponse = null;

            var data = new StringContent(payLoad, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(3) };

            var response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Payment.Placetopay.PaymentUrl.Recurring") + "gateway/process", data);
            string resultResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                collectResponse = JsonConvert.DeserializeObject<Architect.Payment.Integrations.Providers.Placetopay.Contracts.CollectTransaction>(resultResponse);
            }
            else
            {
                try
                {
                    collectResponse = JsonConvert.DeserializeObject<Architect.Payment.Integrations.Providers.Placetopay.Contracts.CollectTransaction>(resultResponse);
                }
                catch (Exception)
                {
                    collectResponse = new CollectTransaction()
                    {
                        status = new Architect.Payment.Integrations.Providers.Placetopay.Contracts.Status()
                        {
                            date = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz"),
                            status = Architect.Payment.Integrations.Providers.Placetopay.Webcheckout.ST_FAILED,
                            reason = response.ReasonPhrase
                        }
                    };
                }

            }
            collectResponse.rawresponse = resultResponse;
            return collectResponse;
        }

        /// <summary>
        /// PASO 6: Se procesa la respuesta de la solicitud de cobro enviada por Evertec.
        /// </summary>
        private static Payment.Integrations.Contracts.InformationRequest ProcesaRepuestaDeSolicitudDePago(Item item, Payment.Integrations.Providers.Placetopay.Contracts.Requests.Collect collectRequest, Payment.Integrations.Providers.Placetopay.Contracts.CollectTransaction collectResponse)
        {
            Architect.Payment.Integrations.Contracts.InformationRequest infoItem = new Architect.Payment.Integrations.Contracts.InformationRequest()
            {
                status = collectResponse.status.status,
                ipAddress = collectRequest.userAgent,
                rawData = collectResponse.rawresponse
            };

            switch (collectResponse.status.status)
            {
                case "APPROVED":

                    infoItem.description = item.concepto;
                    infoItem.reference = collectResponse.reference;

                    infoItem.payerName = item.firstname;
                    infoItem.payerSurname = item.lastname;
                    infoItem.date = collectResponse.status.date;
                    infoItem.currency = collectResponse.amount.currency;
                    infoItem.total = collectResponse.amount.total;
                    infoItem.paymentMethodName = collectResponse.franchise;
                    infoItem.lastDigits = collectResponse.lastDigits;
                    infoItem.authorization = collectResponse.authorization;
                    infoItem.receipt = collectResponse.receipt;
                    infoItem.message = collectResponse.status.message;

                    break;
                case "REJECTED":
                    infoItem.description = item.concepto;
                    infoItem.reference = collectResponse.reference;
                    infoItem.currency = item.moneda;
                    infoItem.total = collectResponse.amount.total;
                    infoItem.message = collectResponse.status.message;
                    infoItem.date = collectResponse.status.date;
                    break;
                default:
                    infoItem.reference = item.ordenId;
                    infoItem.message = collectResponse.status.message;
                    break;

            }

            return infoItem;
        }

        /// <summary>
        /// PASO 8a: Se verifica si el pago fue aprobado para proceder con el pago den tron.
        /// </summary>
        private static void AplicaPagoAprobado(string provider, Payment.Integrations.Contracts.OnlinePayment track, Payment.Integrations.Contracts.InformationRequest item)
        {
            bool tronPayment = Backoffice.Pagos.TronPayment(item, item.OnlinePayment.AgentCode, "Placetopay", provider, false).Result;

            //Se establece que la proxima fecha para poder usar esta tarjeta seria desde el primero del proximo mes.
            DateTime nextCollectAttempt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);

            Tarjetas.UpdateRejectionCount(track.PolicyId, track.DocumentType.DocumentType(), track.DocumentNumber, 0, $"Último pago {DateTime.Now}", 1, nextCollectAttempt);
        }

        /// <summary>
        /// PASO 8b: Se verifica si el pago fue rechazado para llevar el conteo de reintento por rechazos.
        /// </summary>
        private static bool ManejoDeReintentoPorRechazos(Payment.Integrations.Contracts.OnlinePayment track, Payment.Integrations.Contracts.InformationRequest item)
        {
            bool maxTry = false;
            //NOTA:
            //     Se agrega de forma temporal el manejo de reintento bajo la condicion de FAILED

            int numberOfRetries = Tarjetas.RetrieveNumberOfRetries(track.PolicyId, track.DocumentType.DocumentType(), track.DocumentNumber);

            // Si ya se tiene dos rechazo quiere decir que el actual seria el tercero.
            if (numberOfRetries == 2)
            {
                maxTry = true;
            }
            else
            {
                // Si ya se habia deshabilitado por reintento, cuando se intente al mes siguiente se reinicia el contador.
                if (numberOfRetries == 3)
                {
                    numberOfRetries = 0;
                }

                // Se incrementa la cantidad de reintento fallidos 
                Tarjetas.UpdateRejectionCount(track.PolicyId, track.DocumentType.DocumentType(), track.DocumentNumber, numberOfRetries + 1, item.reason);
            }

            return maxTry;
        }

        /// <summary>
        /// MarcaTarjetaParaPoderSerUsadaHastaElProximoMes(track, item);
        /// </summary>
        private static void MarcaTarjetaParaPoderSerUsadaHastaElProximoMes(Payment.Integrations.Contracts.OnlinePayment track, Payment.Integrations.Contracts.InformationRequest item)
        {
            //Se establece que la proxima fecha para poder usar esta tarjeta seria desde el primero del proximo mes.
            DateTime nextCollectAttempt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);

            // Se bloquea la tarjeta para que no sea conciderada en cobros futuros.
            Tarjetas.UpdateRejectionCount(track.PolicyId, track.DocumentType.DocumentType(), track.DocumentNumber, 3, item.reason, 3, nextCollectAttempt);
        }

        private static void EnviarReporteDeDomiciliacion(ReciboRequest reciboReq)
        {
            string title = string.Empty;
            string attachFileName = Architect.Data.Source.Business.ExcelExport.GenerateFile("ReporteDomiciliacion", 0,
                "id=ReporteDomiciliacion:processid=" + reciboReq.procesoId, new Core.Contracts.Security.Token(), ref title, Settings.StringValue(0, "aliados.app.path.temp") + "Reporte Domiciliación.xlsx");

            Mail.SendByTemplate("Reporte_Domiciliacion", 0, 0, 0, null, null,
                                new string[] { string.Format("{0};Reporte Domiciliación.xlsx", attachFileName) });
        }

    }

}
