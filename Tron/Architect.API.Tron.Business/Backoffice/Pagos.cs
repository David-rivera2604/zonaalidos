using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architect.API.Core.Business.General;
using Architect.API.Tron.Contracts.Pagos;
using Architect.DocuSign.Integrations.Providers.Evicertia.Contracts;
using Architect.Payment.Integrations.Contracts;
using Architect.Payment.Integrations.Providers.Placetopay.Contracts;
using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using static iTextSharp.text.pdf.PdfDocument;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// 
    /// </summary>
    public class Pagos
    {
        public static bool IsEmployee { get; private set; }

        public static void Monitor()
        {
            Utilities.Log.WarningLog("Payment.Monitor", "Inicio - Proceso de sondeo", "payment");

            try
            {
                List<Payment.Integrations.Contracts.OnlinePayment> pendingOnlinePayment = Payment.Integrations.DataAccess.OnlinePayment.RetrievePendings();
                if (pendingOnlinePayment.IsNotEmpty())
                {
                    Utilities.Log.WarningLog("Payment.Monitor", $"  {pendingOnlinePayment.Count} Pending Online Payment", "payment");
                    VerifiyOnlinePaymentPendingv2(pendingOnlinePayment);
                }
                List<Payment.Integrations.Contracts.OnlinePayment> pendingPaymentInTron = Payment.Integrations.DataAccess.OnlinePayment.RetrieveByTronCode(500);
                if (pendingPaymentInTron.IsNotEmpty())
                {
                    Utilities.Log.WarningLog("Payment.Monitor", $"  {pendingOnlinePayment.Count} Pending Payment In Tron", "payment");
                    VerifiyOnlinePaymentPendingv2(pendingPaymentInTron);
                }
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Payment", "Monitor", ex);
                throw ex;
            }
            Utilities.Log.WarningLog("Payment.Monitor", "Fin - Proceso de sondeo", "payment");
        }

        public static async Task Monitorv1()
        {
            Utilities.Log.WarningLog("Payment.Monitor", "Inicio - Proceso de sondeo", "payment");

            try
            {

                List<Payment.Integrations.Contracts.OnlinePayment> pendingOnlinePayment = Payment.Integrations.DataAccess.OnlinePayment.RetrievePendings();
                if (pendingOnlinePayment.IsNotEmpty())
                {
                    Utilities.Log.WarningLog("Payment.Monitor", $"  {pendingOnlinePayment.Count} Pending Online Payment", "payment");
                    await VerifiyOnlinePaymentPending(pendingOnlinePayment);
                }
                List<Payment.Integrations.Contracts.OnlinePayment> pendingPaymentInTron = Payment.Integrations.DataAccess.OnlinePayment.RetrieveByTronCode(500);
                if (pendingPaymentInTron.IsNotEmpty())
                {
                    Utilities.Log.WarningLog("Payment.Monitor", $"  {pendingOnlinePayment.Count} Pending Payment In Tron", "payment");
                    await VerifiyOnlinePaymentPending(pendingPaymentInTron);
                }
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Payment", "Monitor", ex);
                throw ex;
            }
            Utilities.Log.WarningLog("Payment.Monitor", "Fin - Proceso de sondeo", "payment");
        }

        private static void VerifiyOnlinePaymentPendingv2(List<Payment.Integrations.Contracts.OnlinePayment> pendings)
        {
            try
            {
                foreach (Payment.Integrations.Contracts.OnlinePayment currentRecord in pendings)
                {
                    Verifyv2(currentRecord);
                }
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Payment", "NewMethod", ex);
                throw ex;
            }

        }
        private static async Task VerifiyOnlinePaymentPending(List<Payment.Integrations.Contracts.OnlinePayment> pendings)
        {
            try
            {
                foreach (Payment.Integrations.Contracts.OnlinePayment currentRecord in pendings)
                {
                    await Verify(currentRecord);
                }
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Payment", "NewMethod", ex);
                throw ex;
            }

        }
        private static void Verifyv2(Payment.Integrations.Contracts.OnlinePayment currentRecord)
        {
            Architect.Payment.Integrations.Contracts.InformationRequest result = Payment.Integrations.Payment.VerifyUpdateStatusv2(currentRecord, currentRecord.UpdateUserCode, true);

            // Se verifica el cambio de estado y si el pago fue aprobado para proceder con el pago den tron.
            if (result != null && result.changed && result.status == "APPROVED")
            {
                PaymentApprovedv2(result);
            }
        }
        private static async Task Verify(Payment.Integrations.Contracts.OnlinePayment currentRecord)
        {
            Architect.Payment.Integrations.Contracts.InformationRequest result = await Payment.Integrations.Payment.VerifyUpdateStatus(currentRecord, currentRecord.UpdateUserCode, true);

            // Se verifica el cambio de estado y si el pago fue aprobado para proceder con el pago den tron.
            if (result != null && result.changed && result.status == "APPROVED")
            {
                await PaymentApproved(result);
            }
        }

        /// <summary>
        /// Procesa y valida una notificación de pago.
        /// </summary>
        public async static Task Notificacion(Architect.Payment.Integrations.Contracts.NotifyRequest notify)
        {
            if (Core.Business.Settings.BoolValue(0, "Payment.Placetopay.Notify.Enabled", true))
            {
                Payment.Integrations.Contracts.OnlinePayment currentRecord = Payment.Integrations.Business.OnlinePayment.RetrieveByRequestID(Convert.ToInt64(notify.requestId));
                if (currentRecord != null)
                {
                    string signature = Payment.Integrations.Payment.NotifySignature(notify, currentRecord.Currency, currentRecord.SettingId, currentRecord.CompanyId);

                    if (signature == notify.signature)
                    {
                        await Verify(currentRecord);
                    }
                }
            }
        }

        /// <summary>
        /// Permite la creación de un sesión para realizar un pago.
        /// </summary>
        public async static Task<Dictionary<string, object>> CrearSesionCore(Core.Contracts.Security.Token tokenInfo, string ipAddress, string userAgent, string num_poliza, Int64 num_recibo, int agentCode, bool widget, bool onlyInfo = false, string email = "")
        {
            int timeout = Core.Business.General.DynamicSetting.IntegerValue(tokenInfo, "Payment.Silice.Init.Timeout", 5);
            Payment.Integrations.Contracts.SessionInformation session = await Payment.Integrations.Payment.VerifySession(tokenInfo.CompanyId, num_poliza, num_recibo, timeout);
            Contracts.Vistas.Recibo recibo = null;
            Payment.Integrations.Contracts.PaymentInformation payInfo = null;
            if (session == null)
            {
                int cod_cia = Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_cia", 1);
                int cantidadRemesados = Architect.API.Tron.DataAccess.A2990700.RecibosRemesadosPorPoliza(cod_cia, num_poliza);
                if (cantidadRemesados == 0)
                {
                    recibo = DataAccess.PorRamo.Informacion_de_un_Recibo(cod_cia, agentCode, tokenInfo.IdentificationType.IdentificationType(), tokenInfo.Identification.DocumentNumber(tokenInfo.IdentificationType), num_poliza, num_recibo);
                }
                if (recibo != null)
                {
                    payInfo = new Payment.Integrations.Contracts.PaymentInformation()
                    {
                        FirstName = recibo.NOM_TERCERO,
                        LastName = recibo.APE1_TERCERO,
                        Email = email.IfEmpty(recibo.EMAIL.IfEmpty(recibo.TXT_EMAIL)),
                        Document = recibo.COD_DOCUM,
                        DocumentType = recibo.TIP_DOCUM,
                        Mobile = recibo.TLF_MOVIL.IfEmpty(recibo.TLF_NUMERO),
                        PolicyId = num_poliza,
                        BillNumber = num_recibo,
                        Description = string.Format("MAPFRE: {0}. POLIZA #{1} RECIBO #{2}", recibo.NOM_RAMO, num_poliza, num_recibo),
                        Currency = recibo.COD_MON.ToString(),
                        Amount = recibo.IMP_RECIBO
                    };
                    if (!onlyInfo)
                    {
                        session = await Payment.Integrations.Payment.NewSession(tokenInfo.CompanyId, tokenInfo.UserId, agentCode, payInfo, ipAddress, userAgent, widget);
                    }
                }
                else
                {
                    session = new Payment.Integrations.Contracts.SessionInformation()
                    {
                        Status = "FAIL",
                        Reason = cantidadRemesados == 0 ? "Recibo no encontrado o no está pendiente de pago." : "No puede pagar este recibo, ya que la póliza tiene recibos remesados."
                    };
                }
            }

            return new Dictionary<string, object>() { { "session", session }, { "recibo", recibo }, { "payinfo", payInfo } };
        }

        /// <summary>
        /// Permite la creación de un sesión para realizar un pago.
        /// </summary>
        public async static Task<Payment.Integrations.Contracts.SessionInformation> CrearSesion(Core.Contracts.Security.Token tokenInfo, string ipAddress, string userAgent, string num_poliza, Int64 num_recibo, int agentCode)
        {
            Dictionary<string, object> sessionCore = await CrearSesionCore(tokenInfo, ipAddress, userAgent, num_poliza, num_recibo, agentCode, true);
            return (Payment.Integrations.Contracts.SessionInformation)sessionCore["session"];
        }

        /// <summary>
        /// Recupera la información de una sesión de pago, en caso de haber algún cambio de estado, se actualiza la tabla interna.
        /// </summary>
        public async static Task<Payment.Integrations.Contracts.InformationRequest> GetRequestInformation(int companyId, int userId, Int64 requestId, string reference)
        {

            Architect.Payment.Integrations.Contracts.InformationRequest result;

            if (requestId.IsNotEmpty())
            {
                result = await Payment.Integrations.Payment.GetRequestInformation(userId, requestId, true);
            }
            else
            {
                result = await Payment.Integrations.Payment.GetRequestInformation(companyId, userId, reference, true);
            }
            // Se verifica el cambio de estado y si el pago fue aprobado para proceder con el pago den tron.
            if (result.changed && result.status == "APPROVED")
            {
                await PaymentApproved(result);
            }

            return result;
        }

        internal static async Task PaymentApproved(InformationRequest result)
        {
            if (result.subscribe)
            {
                await CambioTarjeta(result);
            }
            if (IsEmployee)
            {
                result.OnlinePayment.AgentCode = 999999;
            }
            bool tronPayment = await TronPayment(result, result.OnlinePayment.AgentCode, "Placetopay", string.Empty);
        }

        internal static void PaymentApprovedv2(InformationRequest result)
        {
            if (result.subscribe)
            {
                CambioTarjeta(result);
            }
            if (IsEmployee)
            {
                result.OnlinePayment.AgentCode = 999999;
            }
            bool tronPayment = TronPayment(result, result.OnlinePayment.AgentCode, "Placetopay", string.Empty).Result;
        }

        /// <summary>
        /// Procesa el pago de un recibo en tron.
        /// </summary>
        public async static Task<bool> TronPayment(Architect.Payment.Integrations.Contracts.InformationRequest request, int agentCode, string source, string provider, string pagadorReq = "")
        {
            string tipoPagador = "A";
            string pagador = agentCode.ToString();
            string cuenta = "";

            switch (source)
            {
                case "RecurringReceipts":
                    if (provider.Equals("Evertec", StringComparison.CurrentCultureIgnoreCase))
                        cuenta = request.currency == "1" || request.currency == "CRC" ? "HSBC1" : "HSBC2";
                    else
                        cuenta = request.currency == "1" ? "BAC01" : "BAC02";
                    break;
                case "Widget&Link":
                    cuenta = request.currency == "1" ? "HSBC1" : "HSBC2";
                    break;

                default:
                    cuenta = request.currency == "1" || request.currency == "CRC" ? "HSBC1" : "HSBC2";
                    break;
            }

            //En el caso de que no se trate de un agente, se asume que es un cliente tomador
            if (pagadorReq.IsEmpty() && agentCode.IsEmpty() && request.OnlinePayment.UpdateUserCode.IsNotEmpty())
            {
                tipoPagador = "C";
                var userInfo = Core.Business.Security.UserMember.RetrieveById(request.OnlinePayment.CompanyId, request.OnlinePayment.UpdateUserCode);
                if (userInfo.IsNotEmpty())
                {
                    pagador = userInfo.IdentificationType.ToString().IdentificationType() + "-" + userInfo.Identification.DocumentNumber(userInfo.IdentificationType.ToString());
                }
            }
            if (pagadorReq.IsNotEmpty())
            {
                tipoPagador = "C";
                pagador = pagadorReq;
            }


            string data = JsonConvert.SerializeObject(
                new
                {
                    guid = request.OnlinePayment.RequestID.ToString(),
                    canal = "ALI",
                    fechaPago = request.date,
                    tipoPagador = tipoPagador,
                    pagador = pagador,
                    tipoPago = string.Empty,
                    referenciaPago = request.authorization,
                    montoTotal = request.total,
                    moneda = request.currency,
                    direccionIP = request.ipAddress,
                    huellaNavegador = (string)null,
                    cuenta = cuenta,
                    tarjeta = new
                    {
                        bin = string.Empty,
                        terminacion = request.lastDigits,
                        nombre = string.Format("{0} {1}", request.payerName, request.payerSurname),
                        mesExpira = string.Empty,
                        annioExpira = string.Empty,
                        marcaTarjeta = request.paymentMethodName
                    },
                    recibos = new[] {
                        new {
                            numPoliza = request.OnlinePayment.PolicyId,
                            numRecibo = request.OnlinePayment.BillNumber.ToString(),
                            tipoPago = string.Empty,
                            monto = request.OnlinePayment.Amount
                        }
                    }
                });

            Contracts.Batch.Respuesta tronCobro = DataAccess.PorRamo.p_proceso_cobro(1, Guid.NewGuid().ToString(), data);
            if (request.OnlinePayment.Id > 0)
            {
                Payment.Integrations.DataAccess.OnlinePayment.UpdateTronInformation(request.OnlinePayment.Id, Convert.ToInt16(tronCobro.codigo_respuesta), tronCobro.mensaje_respuesta);
            }
            Utilities.Log.WarningLog("Pagos.TronPayment", string.Format("codigo_respuesta={0}, mensaje_respuesta={1}, recibo={2}", tronCobro.codigo_respuesta, tronCobro.mensaje_respuesta, request.OnlinePayment.BillNumber), "payment");
            return (tronCobro.codigo_respuesta == "200");
        }

        public async static Task<Payment.Integrations.Contracts.v2.PaymentInformation> SendPaymentLink(Core.Contracts.Security.Token tokenInfo, string ipAddress, string userAgent, string num_poliza, Int64 num_recibo, int agentCode, bool onlyInfo = false, string email = "")
        {
            Payment.Integrations.Contracts.v2.PaymentInformation result = null;
            Dictionary<string, object> sessionCore = await CrearSesionCore(tokenInfo, ipAddress, userAgent, num_poliza, num_recibo, agentCode, false, onlyInfo, email);
            Payment.Integrations.Contracts.SessionInformation session = (Payment.Integrations.Contracts.SessionInformation)sessionCore["session"];

            if (onlyInfo)
            {
                Payment.Integrations.Contracts.PaymentInformation payInfo = (Payment.Integrations.Contracts.PaymentInformation)sessionCore["payinfo"];

                if (payInfo != null)
                {
                    return new Payment.Integrations.Contracts.v2.PaymentInformation() { Status = "OK", Reason = string.Empty, emailCliente = payInfo.Email, telefonoCliente = payInfo.Mobile };
                }
                else
                {
                    return new Payment.Integrations.Contracts.v2.PaymentInformation() { Status = session.Status, Reason = session.Reason, emailCliente = string.Empty, telefonoCliente = string.Empty };
                }

            }
            else
            {
                if (session.Status == "OK")
                {
                    Payment.Integrations.Contracts.PaymentInformation payInfo = (Payment.Integrations.Contracts.PaymentInformation)sessionCore["payinfo"];

                    Core.Business.General.Mail.SendByTemplate("Send_PaymentLink", tokenInfo.CompanyId, new { payinfo = payInfo, session = session }, new Dictionary<string, string> { { payInfo.Email, $"{payInfo.FirstName} {payInfo.LastName}" } });

                    session.Reason = $"El enlace de pago fue enviado al correo electrónico {payInfo.Email} del cliente";
                }
                return new Payment.Integrations.Contracts.v2.PaymentInformation() { Status = session.Status, Reason = session.Reason };
            }


        }


        /// <summary>
        /// Realiza el cambio de tarjeta para el cliente de una póliza.
        /// </summary>
        public async static Task<bool> CambioTarjeta(Architect.Payment.Integrations.Contracts.InformationRequest request)
        {
            string data = JsonConvert.SerializeObject(
                new
                {
                    num_poliza = request.OnlinePayment.PolicyId,
                    tip_benef = "0",
                    datos = request.instrument
                });

            Contracts.Batch.Respuesta tronCobro = DataAccess.PorRamo.p_cambio_tarjeta(1, Guid.NewGuid().ToString(), data);
            if (request.OnlinePayment.Id > 0)
            {
                string card = "";
                string token = "";

                if (request.instrument != null)
                {
                    InstrumentValue ivalue = request.instrument.Where(r => r.keyword == "lastDigits").FirstOrDefault();
                    if (ivalue != null)
                    {
                        card = "************" + ivalue.value;
                    }
                    ivalue = request.instrument.Where(r => r.keyword == "token").FirstOrDefault();
                    if (ivalue != null)
                    {
                        token = ivalue.value;
                    }
                }

                if (!string.IsNullOrEmpty(token))
                {
                    int numSpto = DataAccess.Pagos.Recibos.Get_NumSpto(request.OnlinePayment.BillNumber);
                    DataAccess.Pagos.Tarjetas.CreateBoveda(request.OnlinePayment.PolicyId, numSpto, request.OnlinePayment.DocumentType.DocumentType(), request.OnlinePayment.DocumentNumber, card, token, string.Empty, true, "subscribe");
                }
            }
            Utilities.Log.WarningLog("Pagos.CambioTarjeta", string.Format("codigo_respuesta={0}, mensaje_respuesta={1}, recibo={2}", tronCobro.codigo_respuesta, tronCobro.mensaje_respuesta, request.OnlinePayment.BillNumber), "payment");
            return (tronCobro.codigo_respuesta == "200");
        }

    }
}
