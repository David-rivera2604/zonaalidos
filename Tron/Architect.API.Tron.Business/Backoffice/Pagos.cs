using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architect.Utilities.Extensions;
using Newtonsoft.Json;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// 
    /// </summary>
    public class Pagos
    {

        public static void Monitor()
        {
            try
            {

                List<Payment.Integrations.Contracts.OnlinePayment> pendings = Payment.Integrations.DataAccess.OnlinePayment.RetrievePendings(2);
                if (pendings.IsNotEmpty())
                {
                    Task.Run(() => VerifiyOnlinePaymentPending(pendings));
                }
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Payment", "Monitor", ex);
                throw ex;
            }
        }

        private static void VerifiyOnlinePaymentPending(List<Payment.Integrations.Contracts.OnlinePayment> pendings)
        {
            try
            {
                foreach (Payment.Integrations.Contracts.OnlinePayment currentRecord in pendings)
                {
                    Verify(currentRecord);
                }
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Payment", "NewMethod", ex);
                throw ex;
            }

        }

        private static async Task Verify(Payment.Integrations.Contracts.OnlinePayment currentRecord)
        {
            Payment.Integrations.Providers.Placetopay.Contracts.InformationRequest result = await Payment.Integrations.Payment.VerifyUpdateStatus(currentRecord, currentRecord.UpdateUserCode, true);

            // Se verifica el cambio de estado y si el pago fue aprobado para proceder con el pago den tron.
            if (result.changed && result.status.status == "APPROVED")
            {
                bool tronPayment = await TronPayment(result, result.OnlinePayment.AgentCode);
            }
        }

        /// <summary>
        /// Procesa y valida una notificación de pago.
        /// </summary>
        public async static Task Notificacion(int companyId, Payment.Integrations.Providers.Placetopay.Contracts.NotifyRequest notify)
        {
            if (Utilities.Helpers.Settings.BoolValue("Payment.Placetopay.Notify.Enabled", true))
            {
                Payment.Integrations.Contracts.OnlinePayment currentRecord = Payment.Integrations.Business.OnlinePayment.RetrieveByRequestID(companyId, Convert.ToInt64(notify.requestId));
                if (currentRecord != null)
                {
                    string signature = Payment.Integrations.Providers.Placetopay.Webcheckout.NotifySignature(notify, currentRecord.Currency);

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
        public async static Task<Payment.Integrations.Contracts.SessionInformation> CrearSesion(Core.Contracts.Security.Token tokenInfo, string ipAddress, string userAgent, string num_poliza, Int64 num_recibo)
        {
            Payment.Integrations.Contracts.SessionInformation session = await Payment.Integrations.Payment.VerifySession(tokenInfo.CompanyId, num_poliza, num_recibo);
            if (session == null)
            {
                Contracts.Vistas.Recibo recibo = DataAccess.PorRamo.Informacion_de_un_Recibo(Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_cia", 1), tokenInfo.AgentCode, tokenInfo.IdentificationType.IdentificationType(), tokenInfo.Identification.OnlyNumbers(), num_poliza, num_recibo);

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
                    session = await Payment.Integrations.Payment.NewSession(tokenInfo.CompanyId, tokenInfo.UserId, tokenInfo.AgentCode, payInfo, ipAddress, userAgent);
                }
                else
                {
                    session = new Payment.Integrations.Contracts.SessionInformation()
                    {
                        Status = "FAIL",
                        Reason = "Recibo no encontrado o no está pendiente de pago"
                    };
                }
            }
            return session;
        }

        /// <summary>
        /// Recupera la información de una sesión de pago, en caso de haber algún cambio de estado, se actualiza la tabla interna.
        /// </summary>
        public async static Task<Payment.Integrations.Providers.Placetopay.Contracts.InformationRequest> GetRequestInformation(int companyId, int userId, Int64 requestId, string reference)
        {

            Payment.Integrations.Providers.Placetopay.Contracts.InformationRequest result;

            if (requestId.IsNotEmpty())
            {
                result = await Payment.Integrations.Payment.GetRequestInformation(companyId, userId, requestId, true);
            }
            else
            {
                result = await Payment.Integrations.Payment.GetRequestInformation(companyId, userId, reference, true);
            }
            // Se verifica el cambio de estado y si el pago fue aprobado para proceder con el pago den tron.
            if (result.changed && result.status.status == "APPROVED")
            {
                bool tronPayment = await TronPayment(result, result.OnlinePayment.AgentCode);
            }
            return result;
        }

        /// <summary>
        /// Procesa el pago de un recibo en tron.
        /// </summary>
        public async static Task<bool> TronPayment(Payment.Integrations.Providers.Placetopay.Contracts.InformationRequest request, int agentCode)
        {
            string tipoPagador = "A";
            string pagador = agentCode.ToString();

            //En el caso de que no se trate de un agente, se asume que es un cliente tomador
            if (agentCode.IsEmpty() && request.OnlinePayment.UpdateUserCode.IsNotEmpty())
            {
                tipoPagador = "C";
                var userInfo = Core.Business.Security.UserMember.RetrieveById(request.OnlinePayment.CompanyId, request.OnlinePayment.UpdateUserCode);
                if (userInfo.IsNotEmpty())
                {
                    pagador = userInfo.IdentificationType.ToString().IdentificationType() + "-" + userInfo.Identification.DocumentNumber(userInfo.IdentificationType.ToString());
                }
            }

            var payment = request.payment.FirstOrDefault();
            string data = JsonConvert.SerializeObject(
                new
                {
                    guid = request.OnlinePayment.RequestID.ToString(),
                    canal = "ALI",
                    fechaPago = payment.status.date,
                    tipoPagador = tipoPagador,
                    pagador = pagador,
                    tipoPago = string.Empty,
                    referenciaPago = payment.authorization,
                    montoTotal = payment.amount.to.total,
                    moneda = payment.amount.to.currency,
                    direccionIP = request.request.ipAddress,
                    huellaNavegador = (string)null,
                    tarjeta = new
                    {
                        bin = string.Empty,
                        terminacion = payment.processorFields.Find(f => f.keyword == "lastDigits").value,
                        nombre = string.Format("{0} {1}", request.request.payer.name, request.request.payer.surname),
                        mesExpira = string.Empty,
                        annioExpira = string.Empty,
                        marcaTarjeta = payment.paymentMethodName
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
            if (tronCobro.codigo_respuesta != "200")
            {
                Utilities.Log.WarningLog("Pagos.TronPayment", string.Format("codigo_respuesta={0}, mensaje_respuesta={1}", tronCobro.codigo_respuesta, tronCobro.mensaje_respuesta), "payment");
            }
            return (tronCobro.codigo_respuesta == "200");
        }

    }
}
