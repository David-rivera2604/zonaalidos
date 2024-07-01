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
                    Task.Run(() => VerifiyOnlinePaymentPending(pendingOnlinePayment));
                }
                List<Payment.Integrations.Contracts.OnlinePayment> pendingPaymentInTron = Payment.Integrations.DataAccess.OnlinePayment.RetrieveByTronCode(500);
                if (pendingPaymentInTron.IsNotEmpty())
                {
                    Utilities.Log.WarningLog("Payment.Monitor", $"  {pendingOnlinePayment.Count} Pending Payment In Tron", "payment");
                    Task.Run(() => VerifiyOnlinePaymentPending(pendingPaymentInTron));
                }
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Payment", "Monitor", ex);
                throw ex;
            }
            Utilities.Log.WarningLog("Payment.Monitor", "Fin - Proceso de sondeo", "payment");
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
            Architect.Payment.Integrations.Contracts.InformationRequest result = await Payment.Integrations.Payment.VerifyUpdateStatus(currentRecord, currentRecord.UpdateUserCode, true);

            // Se verifica el cambio de estado y si el pago fue aprobado para proceder con el pago den tron.
            if (result != null && result.changed && result.status == "APPROVED")
            {
                if (IsEmployee)
                {
                    result.OnlinePayment.AgentCode = 999999;
                }
                bool tronPayment = await TronPayment(result, result.OnlinePayment.AgentCode, "Placetopay");

            }
        }

        /// <summary>
        /// Procesa y valida una notificación de pago.
        /// </summary>
        public async static Task Notificacion(Architect.Payment.Integrations.Contracts.NotifyRequest notify)
        {
            if (Utilities.Helpers.Settings.BoolValue("Payment.Placetopay.Notify.Enabled", true))
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
        public async static Task<Payment.Integrations.Contracts.SessionInformation> CrearSesion(Core.Contracts.Security.Token tokenInfo, string ipAddress, string userAgent, string num_poliza, Int64 num_recibo)
        {
            Payment.Integrations.Contracts.SessionInformation session = await Payment.Integrations.Payment.VerifySession(tokenInfo.CompanyId, num_poliza, num_recibo);
            if (session == null)
            {
                int cod_cia = Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_cia", 1);
                IsEmployee = tokenInfo.Roles.Contain("Empleado");
                Contracts.Vistas.Recibo recibo = null;
                if (IsEmployee)
                {
                    tokenInfo.AgentCode = 999999;
                }

                int cantidadRemesados = Architect.API.Tron.DataAccess.A2990700.RecibosRemesadosPorPoliza(cod_cia, num_poliza);
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
                    session = await Payment.Integrations.Payment.NewSession(tokenInfo.CompanyId, tokenInfo.UserId, tokenInfo.AgentCode, payInfo, ipAddress, userAgent);
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
            return session;
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
                if (IsEmployee)
                {
                    result.OnlinePayment.AgentCode = 999999;
                }
                bool tronPayment = await TronPayment(result, result.OnlinePayment.AgentCode, "Placetopay");

            }

            return result;
        }

        /// <summary>
        /// Procesa el pago de un recibo en tron.
        /// </summary>
        public async static Task<bool> TronPayment(Architect.Payment.Integrations.Contracts.InformationRequest request, int agentCode, string source)
        {
            string tipoPagador = "A";
            string pagador = agentCode.ToString();
            string cuenta = "";

            switch (source)
            {
                case "RecurringReceipts":
                    cuenta = request.currency == "CRC" ? "BAC01" : "BAC02";
                    break;
                case "Widget&Link":
                    cuenta = request.currency == "CRC" ? "HSBC1" : "HSBC2";
                    break;

                default:
                    cuenta = source;
                    break;
            }

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

    }
}
