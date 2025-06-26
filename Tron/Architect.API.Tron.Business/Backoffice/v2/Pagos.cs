using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Architect.API.Core.Business;
using Architect.API.Core.Business.General;
using Architect.API.Insurance.Contracts.Bayer;
using Architect.API.Tron.DataAccess.Pagos;
using Architect.DocuSign.Integrations.Providers.Evicertia.Contracts;
using Architect.Payment.Integrations.Contracts.v2;
using Architect.Utilities.Extensions;
using Microsoft.Win32;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Utilities.Net;

namespace Architect.API.Tron.Business.Backoffice.v2
{
    /// <summary>
    /// 
    /// </summary>
    public class Pagos
    {
        public static bool IsEmployee { get; private set; }

        /// <summary>
        /// Proceso 'Batch', que envía a cobro los recibos pendiente con cobro recurrente.
        /// </summary>
        public static int PendientesRecurrentesAlCobro(DateTime fec_efect_recibo)
        {
            int recordCount = 0;
            Utilities.Log.WarningLog("Payment.RecurrentesAlCobro", "Inicio - Proceso pendientes recurrentes al cobro", "payment");

            try
            {
                string provider = Core.Business.Settings.StringValue(0, "Tenant.Settings.Payment.Provider");
                string filter = Core.Business.Settings.StringValue(0, "Payment.Silice.RecurringReceipts.Filter.Policies", string.Empty);
                int limitCount = Core.Business.Settings.IntegerValue(0, "Payment.Silice.RecurringReceipts.Limit.Count", 5);


                int cod_cia = Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_cia", 1);
                string prefix = Utilities.Helpers.Settings.StringValue("EMail.Test", string.Empty);


                List<Contracts.Pagos.Recibo> pendientes = Architect.API.Tron.DataAccess.Pagos.Recibos.PendientesRecurrentesAlCobro(cod_cia, fec_efect_recibo, limitCount, filter);
                if (pendientes.Count > 0)
                {
                    ReciboRequest reciboReq = new ReciboRequest()
                    {
                        procesoId = Guid.NewGuid().ToString(),
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
                    int id = 0;
                    foreach (Contracts.Pagos.Recibo pendiente in pendientes)
                    {
                        email = pendiente.EMAIL;
                        if (string.IsNullOrEmpty(email))
                            email = pendiente.EMAIL_COM;
                        if (string.IsNullOrEmpty(email))
                            email = pendiente.TXT_EMAIL;

                        if (!string.IsNullOrEmpty(email))
                        {
                            total += pendiente.IMP_RECIBO;
                            count++;

                            Item newItem = new Item()
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

                            id = Payment.Integrations.Providers.Silice.Payment.TrackOnlinePayment(cod_cia, 0, newItem,
                                pendiente.NUM_POLIZA, pendiente.NUM_RECIBO, pendiente.IMP_RECIBO,
                                pendiente.TIP_DOCUM, pendiente.COD_DOCUM, pendiente.NOM_TERCERO, pendiente.APE1_TERCERO, pendiente.TLF_NUMERO, pendiente.COD_AGT, reciboReq.procesoId).Result;

                            newItem.ordenId = id.ToString();
                        }
                        recordCount++;
                    }
                    reciboReq.totalItems = count;
                    reciboReq.totalCompleto = total;


                    Utilities.Log.TraceLog("RecurringReceipts", JsonConvert.SerializeObject(reciboReq), "payment");


                    HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(3) };
                    //client.Timeout = TimeSpan.FromSeconds(3);
                    client.DefaultRequestHeaders.Authorization = null;

                    List<Architect.Payment.Integrations.Contracts.InformationRequest> result = Architect.Payment.Integrations.Recurring.Request(provider, client, reciboReq).Result;

                    if (provider.Equals("Evertec", StringComparison.CurrentCultureIgnoreCase))
                    {
                        foreach (Architect.Payment.Integrations.Contracts.InformationRequest item in result)
                        {
                            Payment.Integrations.Contracts.OnlinePayment currentRecord = Payment.Integrations.Business.OnlinePayment.RetrieveById(cod_cia, Convert.ToInt32(item.reference));

                            if (currentRecord != null)
                            {
                                item.OnlinePayment = currentRecord;
                            }

                            if (item?.status != currentRecord?.ProviderStatus)
                            {
                                Architect.Payment.Integrations.Payment.UpdateStatus(currentRecord.UpdateUserCode, currentRecord, item);
                            }

                            // Se verifica el cambio de estado y si el pago fue aprobado para proceder con el pago den tron.
                            if (item?.status == "APPROVED")
                            {
                                if (IsEmployee)
                                {
                                    item.OnlinePayment.AgentCode = 999999;
                                }
                                bool tronPayment = Backoffice.Pagos.TronPayment(item, item.OnlinePayment.AgentCode, "Placetopay", provider, false).Result;

                                //Se establece que la proxima fecha para poder usar esta tarjeta seria desde el primero del proximo mes.
                                DateTime nextCollectAttempt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);

                                Tarjetas.UpdateRejectionCount(currentRecord.PolicyId, currentRecord.DocumentType.DocumentType(), currentRecord.DocumentNumber, 0, $"Último pago {DateTime.Now}", 1, nextCollectAttempt);
                            }
                            else if (item?.status == "REJECTED")
                            {


                                int numberOfRetries = Tarjetas.RetrieveNumberOfRetries(currentRecord.PolicyId, currentRecord.DocumentType.DocumentType(), currentRecord.DocumentNumber);

                                // Si ya se tiene dos rechazo quiere decir que el actual seria el tercero.
                                if (numberOfRetries == 2)
                                {
                                    //Se establece que la proxima fecha para poder usar esta tarjeta seria desde el primero del proximo mes.
                                    DateTime nextCollectAttempt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);

                                    // Se bloquea la tarjeta para que no sea conciderada en cobros futuros.
                                    Tarjetas.UpdateRejectionCount(currentRecord.PolicyId, currentRecord.DocumentType.DocumentType(), currentRecord.DocumentNumber, numberOfRetries + 1, item.reason, 3, nextCollectAttempt);

                                }
                                else
                                {
                                    // Si ya se habia deshabilitado por reintento, cuando se intente al mes siguiente se reinicia el contador.
                                    if (numberOfRetries == 3)
                                    {
                                        numberOfRetries = 0;
                                    }

                                    // Se incrementa la cantidad de reintento fallidos 
                                    Tarjetas.UpdateRejectionCount(currentRecord.PolicyId, currentRecord.DocumentType.DocumentType(), currentRecord.DocumentNumber, numberOfRetries + 1, item.reason);
                                }
                            }
                        }

                        EnviarReporteDeDomiciliacion(reciboReq);
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Payment", "RecurrentesAlCobro", ex);
                recordCount = -1;
            }

            Utilities.Log.WarningLog("Payment.RecurrentesAlCobro", string.Format( "Fin - Proceso pendientes recurrentes al cobro ({0})", recordCount), "payment");
            return recordCount;
        }

        /// <summary>
        /// Permite la creación de un sesión para realizar un pago.
        /// </summary>
        public async static Task<Payment.Integrations.Contracts.v2.PaymentInformation> CrearSesion(Core.Contracts.Security.Token tokenInfo, string ipAddress, string userAgent, string num_poliza, Int64 num_recibo, bool widget)
        {
            Payment.Integrations.Contracts.v2.PaymentInformation payInfov2 = null;
            int timeout = Core.Business.General.DynamicSetting.IntegerValue(tokenInfo, "Payment.Silice.Init.Timeout", 5);
            Payment.Integrations.Contracts.SessionInformation session = await Payment.Integrations.Payment.VerifySession(tokenInfo.CompanyId, num_poliza, num_recibo, timeout);
            if (session == null)
            {
                payInfov2 = new Payment.Integrations.Contracts.v2.PaymentInformation()
                {
                    Status = string.Empty
                };
                int cod_cia = Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_cia", 1);
                IsEmployee = tokenInfo.Roles.Contain("Empleado");
                Contracts.Vistas.Recibo recibo = null;
                if (IsEmployee)
                {
                    tokenInfo.AgentCode = 999999;
                }

                int cantidadRemesados = DataAccess.A2990700.RecibosRemesadosPorPoliza(cod_cia, num_poliza);
                if (cantidadRemesados == 0)
                {
                    recibo = DataAccess.PorRamo.Informacion_de_un_Recibo(cod_cia, tokenInfo.AgentCode, tokenInfo.IdentificationType.IdentificationType(), tokenInfo.Identification.DocumentNumber(tokenInfo.IdentificationType), num_poliza, num_recibo);
                }
                if (recibo != null)
                {

                    Payment.Integrations.Contracts.PaymentInformation payInfo = new Payment.Integrations.Contracts.PaymentInformation()
                    {
                        FirstName = recibo.NOM_TERCERO,
                        LastName = recibo.APE1_TERCERO,
                        Email = recibo.EMAIL.IfEmpty(recibo.TXT_EMAIL),
                        Document = recibo.COD_DOCUM,
                        DocumentType = recibo.TIP_DOCUM,
                        Mobile = recibo.TLF_MOVIL.IfEmpty(recibo.TLF_NUMERO),
                        PolicyId = num_poliza,
                        BillNumber = num_recibo,
                        Description = string.Format("MAPFRE: {3}. {0}. POLIZA #{1} RECIBO #{2}", recibo.NOM_RAMO, num_poliza, num_recibo, recibo.NOM_SECTOR),
                        Currency = recibo.COD_MON.ToString(),
                        Amount = recibo.IMP_RECIBO
                    };


                    session = await Payment.Integrations.Payment.NewSessionV2(tokenInfo.CompanyId, tokenInfo.UserId, tokenInfo.AgentCode, payInfo, ipAddress, userAgent, widget);

                    payInfov2 = new Payment.Integrations.Contracts.v2.PaymentInformation()
                    {
                        ordenId = session.RequestId,
                        documentoCliente = string.Format("{0} {1}", recibo.TIP_DOCUM, recibo.COD_DOCUM),
                        nombreCliente = string.Format("{0} {1}", recibo.NOM_TERCERO, recibo.APE1_TERCERO),
                        emailCliente = recibo.EMAIL.IfEmpty(recibo.TXT_EMAIL),
                        telefonoCliente = recibo.TLF_MOVIL.IfEmpty("506" + recibo.TLF_NUMERO),
                        contratoFrontal = false,
                        concepto = string.Format("MAPFRE: {3}. {0}. POLIZA #{1} RECIBO #{2}", recibo.NOM_RAMO, num_poliza, num_recibo, recibo.NOM_SECTOR),
                        subtotal = recibo.IMP_RECIBO.ToString().Replace(",", "."),
                        impuestos = "0",
                        total = recibo.IMP_RECIBO.ToString().Replace(",", "."),
                        urlWebhook = string.Empty,
                        moneda = recibo.COD_MON == 1 ? "CRC" : "USD",
                        //origen = "pau",
                        //countryCode = "Silice",
                        items = new Payment.Integrations.Contracts.v2.PaymentInformation.Item[] { new Payment.Integrations.Contracts.v2.PaymentInformation.Item{
                            cantidad= 1,
                            moneda= recibo.COD_MON == 1? "CRC" : "USD",
                            precio= recibo.IMP_RECIBO,
                            producto=string.Format("MAPFRE: {3}. {0}. POLIZA #{1} RECIBO #{2}", recibo.NOM_RAMO, num_poliza, num_recibo, recibo.NOM_SECTOR)
                        }  },
                        //dataExtra = new Payment.Integrations.Contracts.v2.PaymentInformation.DataExtra() { id = "enviadopormapfre" },
                        ////address = new Payment.Integrations.Contracts.v2.PaymentInformation.Address() { address1 = "panamá", address2 = "herrera", address3 = "chitre", postalCode = "507", city = "chitre", state = "nl", countryCode = "" }
                    };
                    //payInfov2.emailCliente = "solernelson@gmail.com";
                    //payInfov2.telefonoCliente = "50672155569";
                    payInfov2.urlWebhook = Utilities.Helpers.Settings.StringValue("Payment.Silice.urlWebhook");
                    payInfov2.Status = string.Empty;
                }
                else
                {
                    payInfov2 = new Payment.Integrations.Contracts.v2.PaymentInformation()
                    {
                        Status = "FAIL",
                        Reason = cantidadRemesados == 0 ? "Recibo no encontrado o no está pendiente de pago." : "No puede pagar este recibo, ya que la póliza tiene recibos remesados."
                    };
                }
            }
            else
            {
                payInfov2 = new Payment.Integrations.Contracts.v2.PaymentInformation()
                {
                    Status = session.Status,
                    Reason = session.Reason
                };
            }
            return payInfov2;
        }


        /// <summary>
        /// Procesa y valida una notificación de pago.
        /// </summary>
        public async static Task Webhook(Architect.Payment.Integrations.Contracts.v2.WebhookRequest webhookRequest)
        {

            Utilities.Log.TraceLog("Payment.Webhook", JsonConvert.SerializeObject(webhookRequest), "payment");

            Payment.Integrations.Contracts.OnlinePayment currentRecord = Payment.Integrations.Business.OnlinePayment.RetrieveByRequestID(Convert.ToInt64(webhookRequest.ordenId));
            if (currentRecord != null)
            {
                Architect.Payment.Integrations.Contracts.InformationRequest result = new Payment.Integrations.Contracts.InformationRequest()
                {
                    status = webhookRequest.status.IndexOf("aprobad", StringComparison.CurrentCultureIgnoreCase) > -1 ? "APPROVED" : "",
                    date = null,
                    authorization = webhookRequest.resultado_pasarela.authorization,
                    total = currentRecord.Amount,
                    currency = currentRecord.Currency.ToString(),
                    ipAddress = null,
                    lastDigits = webhookRequest.card_number,
                    payerName = currentRecord.FirstName,
                    payerSurname = currentRecord.LastName,
                    paymentMethodName = null
                };


                if (result != null)
                {
                    result.OnlinePayment = currentRecord;
                    Utilities.Log.WarningLog("Payment.VerifyUpdateStatus", string.Format("requestId={0}, currency={1}, currentStatus={2}, newStatus={3}, recibo={4}", currentRecord.RequestID, currentRecord.Currency, currentRecord.ProviderStatus, result.status, currentRecord.BillNumber), "payment");

                    if (result.status != currentRecord.ProviderStatus)
                    {
                        result.OnlinePayment = Architect.Payment.Integrations.Payment.UpdateStatus(currentRecord.UpdateUserCode, currentRecord, result);
                        result.changed = true;
                    }
                }

                // Se verifica el cambio de estado y si el pago fue aprobado para proceder con el pago den tron.
                if (result != null && result.changed && result.status == "APPROVED")
                {
                    if (IsEmployee)
                    {
                        result.OnlinePayment.AgentCode = 999999;
                    }
                    bool tronPayment = await Backoffice.Pagos.TronPayment(result, result.OnlinePayment.AgentCode, "Widget&Link", string.Empty, false);
                }
            }
        }

        /// <summary>
        /// Permite el envio de un link de pago.
        /// </summary>
        public async static Task<Payment.Integrations.Contracts.v2.PaymentInformation> SendPaymentLink(Core.Contracts.Security.Token tokenInfo, string ipAddress, string userAgent, string num_poliza, Int64 num_recibo, string mode, string email, int agentCode)
        {
            Payment.Integrations.Contracts.v2.PaymentInformation result = null;
            Payment.Integrations.Contracts.v2.PaymentInformation payInfov2;

            string provider = Core.Business.Settings.StringValue(tokenInfo.CompanyId, "Tenant.Settings.Payment.Provider");
            if (provider.Equals("Silice", StringComparison.CurrentCultureIgnoreCase) || mode.Equals("WhatsApp", StringComparison.CurrentCultureIgnoreCase))
            {
                HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(3) };

                client.DefaultRequestHeaders.Authorization = null;
                string token = await Architect.Payment.Integrations.Providers.Silice.Payment.signin(client);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                payInfov2 = await CrearSesion(tokenInfo, ipAddress, userAgent, num_poliza, num_recibo, false);

                if (payInfov2 != null && payInfov2.Status != "FAIL")
                {


                    payInfov2.urlReturn = payInfov2.urlWebhook;
                    payInfov2.urlReturn = "https://mapfre.cr";

                    payInfov2.telefonoCliente = payInfov2.telefonoCliente.Replace("-", "");
                    if (!payInfov2.telefonoCliente.StartsWith("506"))
                    {
                        payInfov2.telefonoCliente = "506" + payInfov2.telefonoCliente;
                    }

                    string reciboId = await Architect.Payment.Integrations.Providers.Silice.Payment.recibo(client, payInfov2);

                    switch (mode)
                    {
                        case "Correo":
                            payInfov2.Reason = await Architect.Payment.Integrations.Providers.Silice.Payment.CobroSendEmail(client, reciboId, payInfov2.emailCliente);
                            break;
                        case "WhatsApp":
                            payInfov2.Reason = await Architect.Payment.Integrations.Providers.Silice.Payment.CobroMensajeAutomata(client, reciboId, payInfov2.telefonoCliente);
                            break;
                    }

                    if (payInfov2.Reason.StartsWith("Error. ", StringComparison.CurrentCultureIgnoreCase))
                    {
                        payInfov2.Status = "FAIL";

                        Payment.Integrations.Contracts.OnlinePayment currentRecord = Payment.Integrations.Business.OnlinePayment.RetrieveByRequestID(Convert.ToInt64(payInfov2.ordenId));
                        Architect.Payment.Integrations.Payment.UpdateStatus(currentRecord.UpdateUserCode, currentRecord,
                            new Payment.Integrations.Contracts.InformationRequest()
                            {
                                status = "FAIL",
                                reason = payInfov2.Reason
                            });

                    }
                }
                result = new Payment.Integrations.Contracts.v2.PaymentInformation() { Status = payInfov2.Status, Reason = payInfov2.Reason };
            }
            else
            {
                bool onlyInfo = false;
                if (mode == "CorreoInfo")
                {
                    onlyInfo = true;
                }
                payInfov2 = await Business.Backoffice.Pagos.SendPaymentLink(tokenInfo, ipAddress, userAgent, num_poliza, num_recibo, agentCode, onlyInfo, email);
                result = new Payment.Integrations.Contracts.v2.PaymentInformation() { Status = payInfov2.Status, Reason = payInfov2.Reason, emailCliente = payInfov2.emailCliente, telefonoCliente = payInfov2.telefonoCliente };
            }
            return result;
        }

        /// <summary>
        /// Proceso 'Batch', que envía a tokenizar las tarjetas de créditos registradas en tron.
        /// </summary>
        public static int TokenizeTarjetas(string cod_docum)
        {
            int recordCount = 0;
            int cod_cia = Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_cia", 1);
            string prefix = Core.Business.Settings.StringValue(0, "EMail.Test");
            int cardCount = Core.Business.Settings.IntegerValue(0, "Payment.Silice.Tokenize.Cantidad.Tarjetas", 50);
            string provider = Core.Business.Settings.StringValue(0, "Tenant.Settings.Payment.Provider");

            List<Contracts.Pagos.Tarjeta> pendientes = Architect.API.Tron.DataAccess.Pagos.Tarjetas.PendientesPorTokenizar(cod_cia, cardCount, cod_docum);

            List<DatosTarjeta> datosTajetas = new List<DatosTarjeta>();
            string email = string.Empty;
            //Se crea una lista de tarjetas a tokenizar a partir de la información de tron
            foreach (Contracts.Pagos.Tarjeta pendiente in pendientes)
            {
                email = pendiente.EMAIL;
                if (string.IsNullOrEmpty(email))
                    email = pendiente.EMAIL_COM;
                if (string.IsNullOrEmpty(email))
                    email = pendiente.TXT_EMAIL;

                if (!string.IsNullOrEmpty(email))
                {
                    datosTajetas.Add(new DatosTarjeta
                    {
                        number = pendiente.NUM_TARJETA,
                        holder_name = pendiente.NOM_TERCERO.CompleteFullName(pendiente.NOM2_TERCERO, pendiente.APE1_TERCERO, pendiente.APE2_TERCERO),
                        expiry_month = pendiente.FEC_VCTO_TARJETA.Month,
                        expiry_year = pendiente.FEC_VCTO_TARJETA.Year,
                        method = "tarjeta",
                        typeMethod = "AHO",
                        email = pendiente.EMAIL,
                        cod_docum = pendiente.COD_DOCUM,
                        tip_docum = pendiente.TIP_DOCUM,
                        token = string.Empty
                    });

                    datosTajetas.Last().holder_name = datosTajetas.Last().holder_name;
                    if (string.IsNullOrEmpty(prefix))
                    {
                        datosTajetas.Last().email = datosTajetas.Last().email;
                    }
                    else
                    {
                        datosTajetas.Last().email = prefix;
                    }
                }
            }

            if (datosTajetas.Count > 0)
            {
                HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(3) };
                client.Timeout = TimeSpan.FromSeconds(10);
                client.DefaultRequestHeaders.Authorization = null;


                List<DatosTarjeta> result = Architect.Payment.Integrations.Tokenize.Request(provider, client, datosTajetas).Result;

                foreach (DatosTarjeta tarjeta in result)
                {
                    var data = pendientes.Where(r => r.NUM_TARJETA == tarjeta.key).FirstOrDefault();
                    if (tarjeta.token != string.Empty)
                    {

                        DataAccess.A1000802.Update(cod_cia, data.NUM_POLIZA, data.NUM_SPTO, tarjeta.tip_docum, tarjeta.cod_docum, tarjeta.card, null);
                        DataAccess.Pagos.Num_Tarjeta_mcr.Update(cod_cia, tarjeta.tip_docum, tarjeta.cod_docum, tarjeta.card, null);
                        data.NUM_TARJETA = tarjeta.card;
                    }
                    DataAccess.Pagos.Tarjetas.CreateBoveda(data.NUM_POLIZA, data.NUM_SPTO, tarjeta.tip_docum, tarjeta.cod_docum, data.NUM_TARJETA, tarjeta.token, tarjeta.clientId, tarjeta.status, tarjeta.reason);
                    recordCount++;
                }
            }
            return recordCount;
        }

        private static void EnviarReporteDeDomiciliacion(ReciboRequest reciboReq)
        {
            string title = string.Empty;
            string attachFileName = Architect.Data.Source.Business.ExcelExport.GenerateFile("ReporteDomiciliacion", 0,
                "id=ReporteDomiciliacion:processid=" + reciboReq.procesoId, new Core.Contracts.Security.Token(), ref title, Settings.StringValue(0, "aliados.app.path.temp") + "Reporte Domiciliación.xlsx");

            Mail.SendByTemplate("Reporte_Domiciliacion", 0, 0, 0, null, null,
                                new string[] { string.Format("{0};Reporte Domiciliación.xlsx", attachFileName) });
        }

        /// <summary>
        /// Procesar el resultado del pago para los recibos con cobro recurrente.
        /// </summary>
        public async static Task<string> RecurringReceipts(Payment.Integrations.Contracts.v2.ReciboResponse request)
        {
            string message = string.Empty;


            if (request.items != null)
            {
                message = string.Format("{0} recibos reportados", request.items.Count);

                int cod_cia = Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_cia", 1);
                int num_recibo = 0;
                int procesados = 0;
                foreach (Payment.Integrations.Contracts.v2.ReciboResponseItem item in request.items)
                {

                    Payment.Integrations.Contracts.OnlinePayment currentRecord = Payment.Integrations.Business.OnlinePayment.RetrieveById(cod_cia, Convert.ToInt32(item.ordenId));

                    num_recibo = Convert.ToInt32(currentRecord.BillNumber);
                    Contracts.Pagos.Recibo recibo = Architect.API.Tron.DataAccess.Pagos.Recibos.ReciboAlCobro(cod_cia, num_recibo);

                    if (recibo != null)
                    {
                        procesados++;
                        Architect.Payment.Integrations.Contracts.InformationRequest result = new Payment.Integrations.Contracts.InformationRequest()
                        {
                            status = item.status.IndexOf("aprobad", StringComparison.CurrentCultureIgnoreCase) > -1 ? "APPROVED" : item.status,
                            message = string.Format("original status {0}", item.status),
                            date = null,
                            authorization = item.resultado_pasarela.authorization,
                            total = recibo.IMP_RECIBO,
                            currency = currentRecord.Currency.ToString(),
                            ipAddress = null,
                            lastDigits = item.card_number,
                            payerName = recibo.NOM_TERCERO,
                            payerSurname = recibo.APE1_TERCERO,
                            paymentMethodName = null,
                            receipt = item.resultado_pasarela.receipt,
                            OnlinePayment = new Payment.Integrations.Contracts.OnlinePayment()
                            {
                                CompanyId = 0,
                                UpdateUserCode = 0,
                                RequestID = num_recibo,
                                PolicyId = recibo.NUM_POLIZA,
                                BillNumber = num_recibo,
                                Amount = recibo.IMP_RECIBO
                            }
                        };
                        Architect.Payment.Integrations.Payment.UpdateStatus(currentRecord.UpdateUserCode, currentRecord, result);
                        if (item.status.IndexOf("aprobad", StringComparison.CurrentCultureIgnoreCase) > -1)
                        {
                            bool tronPayment = await Backoffice.Pagos.TronPayment(result, currentRecord.AgentCode, "RecurringReceipts", "Silice", false);
                        }
                    }


                }
                message += string.Format(", {0} recibos procesados", procesados);
            }
            return message;
        }

    }
}
