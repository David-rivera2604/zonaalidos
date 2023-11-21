using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Architect.DocuSign.Integrations.Providers.Evicertia.Contracts;
using Architect.Utilities.Extensions;
using Newtonsoft.Json;
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
        /// Permite la creación de un sesión para realizar un pago.
        /// </summary>
        public async static Task<Payment.Integrations.Contracts.v2.PaymentInformation> CrearSesion(Core.Contracts.Security.Token tokenInfo, string ipAddress, string userAgent, string num_poliza, Int64 num_recibo)
        {
            Payment.Integrations.Contracts.v2.PaymentInformation payInfov2 = null;
            Payment.Integrations.Contracts.SessionInformation session = await Payment.Integrations.Payment.VerifySession(tokenInfo.CompanyId, num_poliza, num_recibo);
            if (session == null)
            {
                payInfov2 = new Payment.Integrations.Contracts.v2.PaymentInformation() { Status = string.Empty };
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
                        Description = string.Format("MAPFRE: {0}. POLIZA #{1} RECIBO #{2}", recibo.NOM_RAMO, num_poliza, num_recibo),
                        Currency = recibo.COD_MON.ToString(),
                        Amount = recibo.IMP_RECIBO
                    };


                    session = await Payment.Integrations.Payment.NewSessionV2(tokenInfo.CompanyId, tokenInfo.UserId, tokenInfo.AgentCode, payInfo, ipAddress, userAgent);

                    payInfov2 = new Payment.Integrations.Contracts.v2.PaymentInformation()
                    {
                        ordenId = session.RequestId,
                        documentoCliente = string.Format("{0} {1}", recibo.TIP_DOCUM, recibo.COD_DOCUM),
                        nombreCliente = string.Format("{0} {1}", recibo.NOM_TERCERO, recibo.APE1_TERCERO),
                        emailCliente = recibo.EMAIL.IfEmpty(recibo.TXT_EMAIL),
                        telefonoCliente = recibo.TLF_MOVIL.IfEmpty(recibo.TLF_NUMERO),
                        contratoFrontal = false,
                        concepto = string.Format("MAPFRE: {0}. POLIZA #{1} RECIBO #{2}", recibo.NOM_RAMO, num_poliza, num_recibo),
                        subtotal = recibo.IMP_RECIBO.ToString().Replace(",", "."),
                        impuestos = "0",
                        total = recibo.IMP_RECIBO.ToString().Replace(",", "."),
                        urlWebhook = string.Empty,
                        items = new Payment.Integrations.Contracts.v2.PaymentInformation.Item[] { new Payment.Integrations.Contracts.v2.PaymentInformation.Item{
                            cantidad= 1,
                            moneda= "CRC",
                            precio= recibo.IMP_RECIBO,
                            producto=string.Format("MAPFRE: {0}. POLIZA #{1} RECIBO #{2}", recibo.NOM_RAMO, num_poliza, num_recibo)
                        } },
                        Status = string.Empty
                    };
                    payInfov2.emailCliente = "solernelson@gmail.com";
                    payInfov2.telefonoCliente = "+50672155569";
                    payInfov2.urlWebhook = "https://webhook.site/702fe79f-c080-4317-a194-71f0a62d70fc";
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

            Payment.Integrations.Contracts.OnlinePayment currentRecord = Payment.Integrations.Business.OnlinePayment.RetrieveByRequestID(Convert.ToInt64(webhookRequest.ordenId));
            if (currentRecord != null)
            {
                Architect.Payment.Integrations.Contracts.InformationRequest result = new Payment.Integrations.Contracts.InformationRequest()
                {
                    status = webhookRequest.status == "Aprobado" ? "APPROVED" : "",
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
                    bool tronPayment = await Backoffice.Pagos.TronPayment(result, result.OnlinePayment.AgentCode);
                }

            }



        }

        /// <summary>
        /// Permite el envio de un link de pago.
        /// </summary>
        public async static Task<Payment.Integrations.Contracts.v2.PaymentInformation> SendPaymentLink(Core.Contracts.Security.Token tokenInfo, string ipAddress, string userAgent, string num_poliza, Int64 num_recibo, string mode)
        {

            string token = await Architect.Payment.Integrations.Providers.Silice.Payment.signin();

            Payment.Integrations.Contracts.v2.PaymentInformation payInfov2 = await CrearSesion(tokenInfo, ipAddress, userAgent, num_poliza, num_recibo);

            if (payInfov2 != null)
            {


                payInfov2.urlReturn = payInfov2.urlWebhook;

                string reciboId = await Architect.Payment.Integrations.Providers.Silice.Payment.recibo(token, payInfov2);

                switch (mode)
                {
                    case "Correo":
                        payInfov2.Reason = await Architect.Payment.Integrations.Providers.Silice.Payment.CobroSendEmail(token, reciboId);
                        break;
                    case "WhatsApp":
                        payInfov2.Reason = await Architect.Payment.Integrations.Providers.Silice.Payment.CobroMensajeAutomata(token, reciboId);
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
            return payInfov2;
        }


    }
}
