using Architect.Payment.Integrations.Contracts;
using Architect.Payment.Integrations.Providers.Placetopay.Contracts;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations
{
    public static class Payment
    {

        /// <summary>
        /// Permite la creación de un sesión para realizar un pago.
        /// </summary>
        public async static Task<Contracts.SessionInformation> VerifySession(int companyId, string policyId, Int64 billNumber)
        {
            Contracts.SessionInformation current = null;
            Contracts.OnlinePayment currenTrack = Business.OnlinePayment.RetrieveByPolicyAndBill(companyId, policyId, billNumber);

            if (currenTrack != null)
            {
                if (currenTrack.ProviderStatus == Providers.Placetopay.Webcheckout.ST_INIT || currenTrack.ProviderStatus == Providers.Placetopay.Webcheckout.ST_PENDING)
                {

                    current = new Contracts.SessionInformation()
                    {
                        Status = "FAIL",
                        Reason = string.Format("El recibo #{0} se encuentra en un proceso de pago que no ha terminado", billNumber)
                    };
                }
            }
            return current;
        }

        /// <summary>
        /// Permite la creación de un sesión para realizar un pago.
        /// </summary>
        public async static Task<Contracts.SessionInformation> NewSession(int companyId, int userId, int cod_agt, Contracts.PaymentInformation payInfo, string ipAddress, string userAgent)
        {
            Contracts.OnlinePayment track = Business.OnlinePayment.Create(companyId, userId, new Contracts.OnlinePayment()
            {
                CompanyId = companyId,
                DocumentType = IdentificationTypeConvert(payInfo.DocumentType),
                DocumentNumber = payInfo.Document,
                FirstName = payInfo.FirstName,
                LastName = payInfo.LastName,
                PrimaryEmailAddress = payInfo.Email,
                PhoneNumberMobile = payInfo.Mobile,
                AgentCode = cod_agt,
                PolicyId = payInfo.PolicyId,
                BillNumber = payInfo.BillNumber,
                Currency = CurrencyConvert(payInfo.Currency),
                Amount = payInfo.Amount,
                Reference = string.Format("{0}-{1}", payInfo.PolicyId, payInfo.BillNumber),
                Description = payInfo.Description,
                IssueDate = DateTime.Now,
                StatusDate = DateTime.Now,
                Status = 1
            });

            payInfo.Reference = string.Format("{0}-{1}-{2}", payInfo.PolicyId, payInfo.BillNumber, track.Id);

            Contracts.SessionInformation result = await Providers.Placetopay.Webcheckout.CreateRequest(payInfo, ipAddress, userAgent);

            track.Reference = string.Format("{0}-{1}-{2}", payInfo.PolicyId, payInfo.BillNumber, track.Id);
            track.IssueDate = DateTime.Now;
            track.StatusDate = DateTime.Now;
            track.RequestID = Convert.ToInt64(result.RequestId);
            track.ProcessUrl = result.ProcessUrl;
            track.ProviderStatus = result.Status == Providers.Placetopay.Webcheckout.ST_OK ? Providers.Placetopay.Webcheckout.ST_INIT : result.Status;
            track.Reason = result.Reason;
            track.ResponseData = result.rawData;
            track.Status = Providers.Placetopay.Webcheckout.StatusConvert(track.ProviderStatus);

            Business.OnlinePayment.UpdateNewSession(track);

            return result;
        }

        /// <summary>
        /// Obtiene y actualiza la información de un pago.
        /// </summary>
        public async static Task<Providers.Placetopay.Contracts.InformationRequest> GetRequestInformation(int companyId, int userId, string reference, bool updateStatus = false)
        {
            Contracts.OnlinePayment currentRecord = null;
            if (reference.IndexOf("-") > -1)
            {
                string policyId = reference.Split('-')[0].OnlyNumbers();
                Int64 billNumber = Convert.ToInt64("0" + reference.Split('-')[1].OnlyNumbers());
                int id = Convert.ToInt32("0" + reference.Split('-')[2].OnlyNumbers());
                currentRecord = Business.OnlinePayment.RetrieveById(companyId, id);
                if (currentRecord?.PolicyId != policyId || currentRecord?.BillNumber != billNumber)
                {
                    currentRecord = null;
                }

            }
            return await VerifyUpdateStatus(currentRecord, userId, updateStatus);
        }

        /// <summary>
        /// Obtiene y actualiza la información de un pago.
        /// </summary>
        public async static Task<Providers.Placetopay.Contracts.InformationRequest> GetRequestInformation(int companyId, int userId, Int64 requestId, bool updateStatus = false)
        {
            Contracts.OnlinePayment currentRecord = Business.OnlinePayment.RetrieveByRequestID(companyId, requestId);
            return await VerifyUpdateStatus(currentRecord, userId, updateStatus);
        }

        public async static Task<Providers.Placetopay.Contracts.InformationRequest> VerifyUpdateStatus(Contracts.OnlinePayment currentRecord, int userId, bool updateStatus)
        {
            Providers.Placetopay.Contracts.InformationRequest result;
            if (currentRecord != null)
            {
                result = await Providers.Placetopay.Webcheckout.GetRequestInformation(currentRecord.RequestID, currentRecord.Currency);
                result.OnlinePayment = currentRecord;
                Utilities.Log.WarningLog("Payment.VerifyUpdateStatus", string.Format("requestId={0}, currency={1}, currentStatus={2}, newStatus={3}", currentRecord.RequestID, currentRecord.Currency, currentRecord.ProviderStatus, result.status.status), "payment");


                if (updateStatus && result.status.status != currentRecord.ProviderStatus)
                {
                    result.OnlinePayment = UpdateStatus(userId, currentRecord, result);
                    result.changed = true;
                }
            }
            else
            {
                result = new Providers.Placetopay.Contracts.InformationRequest()
                {
                    status = new Providers.Placetopay.Contracts.Status()
                    {
                        date = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz"),
                        status = "NotFound"
                    }
                };
            }
            return result;
        }


        /// <summary>
        /// Actualiza la información relacionada con un pago.
        /// </summary>
        private static OnlinePayment UpdateStatus(int userId, OnlinePayment currentRecord, InformationRequest result)
        {
            currentRecord.StatusDate = DateTime.Now;
            currentRecord.ProviderStatus = result.status.status;
            currentRecord.ResponseData = result.rawData;
            currentRecord.Status = Providers.Placetopay.Webcheckout.StatusConvert(result.status.status);
            currentRecord.Reason = result.status.message;
            currentRecord.UpdateUserCode = userId;
            currentRecord.UpdateDate = DateTime.Now;
            if (result.payment?.Count > 0)
            {
                currentRecord.Authorization = result.payment.FirstOrDefault().authorization;
                currentRecord.Receipt = result.payment.FirstOrDefault().receipt;
            }
            Business.OnlinePayment.Update(currentRecord);
            return currentRecord;
        }

       


        private static int IdentificationTypeConvert(string identificationType)
        {
            int type = 0;

            switch (identificationType)
            {
                case "1": //Cédula
                case "CNA":
                    type = 1;
                    break;

                case "2": //Residencia
                case "CRE":
                    type = 2;
                    break;

                case "4": //Cédula jurídica
                case "CJU":
                    type = 4;
                    break;

                case "3": //Pasaporte
                case "PAS":
                    type = 3;
                    break;

                    //DIDI
            }

            return type;
        }

        private static int CurrencyConvert(string currency)
        {
            int result = 0;
            switch (currency)
            {
                case "1":
                case "CRC":
                    result = 1;
                    break;
                case "2":
                case "USD":
                    result = 2;
                    break;
            }
            return result;
        }


    }
}
