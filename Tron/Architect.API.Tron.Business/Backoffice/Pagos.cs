using System;
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
        /// <summary>
        /// Permite la creación de un sesión para realizar un pago.
        /// </summary>
        public async static Task<Payment.Integrations.Contracts.SessionInformation> CrearSesion(int companyId, int userId, string ipAddress, string userAgent, int cod_agt, string num_poliza, Int64 num_recibo)
        {
            Payment.Integrations.Contracts.SessionInformation session = await Payment.Integrations.Payment.VerifySession(companyId, num_poliza, num_recibo);
            if (session == null)
            {
                Contracts.Vistas.Recibo recibo = DataAccess.PorRamo.Informacion_de_un_Recibo(Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_cia", 1), cod_agt, num_poliza, num_recibo);

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
                    session = await Payment.Integrations.Payment.NewSession(companyId, userId, cod_agt, payInfo, ipAddress, userAgent);
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

            //tipoPagador A / C. pagador = codigo de cliente o agente
            var payment = request.payment.FirstOrDefault();
            string data = JsonConvert.SerializeObject(
                new
                {
                    guid = request.OnlinePayment.RequestID.ToString(),
                    canal = "ALI",
                    fechaPago = payment.status.date,
                    tipoPagador = "A",
                    pagador = agentCode.ToString(),
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
                        mesExpira = "08",
                        annioExpira = "2021",
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

            return (DataAccess.PorRamo.p_proceso_cobro(1, Guid.NewGuid().ToString(), data).codigo_respuesta == "200");
        }
    }
}
