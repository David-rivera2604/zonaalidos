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
        public async static Task<Contracts.SessionInformation> NewSession(int companyId, int userId, Contracts.PaymentInformation payInfo, string ipAddress, string userAgent)
        {
            payInfo.Reference = string.Format("{0}-{1}", payInfo.PolicyId, payInfo.BillNumber);
            Contracts.SessionInformation result = await Providers.Placetopay.Webcheckout.CreateRequest(payInfo, ipAddress, userAgent);

            Business.OnlinePayment.Create(companyId, userId, new Contracts.OnlinePayment()
            {
                CompanyId = companyId,
                DocumentType = IdentificationTypeConvert( payInfo.DocumentType),
                DocumentNumber = payInfo.Document,
                FirstName = payInfo.FirstName,
                LastName = payInfo.LastName,
                PrimaryEmailAddress = payInfo.Email,
                PhoneNumberMobile = payInfo.Mobile,
                PolicyId = payInfo.PolicyId,
                BillNumber = payInfo.BillNumber,
                Currency = CurrencyConvert(payInfo.Currency),
                Amount = payInfo.Amount,
                Reference = payInfo.Reference,
                Description = payInfo.Description,
                IssueDate = DateTime.Now,
                StatusDate = DateTime.Now,
                RequestID = Convert.ToInt64(result.RequestId),
                ProcessUrl = result.ProcessUrl,
                ProviderStatus = result.Status == Providers.Placetopay.Webcheckout.ST_OK ? Providers.Placetopay.Webcheckout.ST_PENDING : result.Status,
                Reason = result.Reason,
                ResponseData = result.rawData,
                Status = result.Status == Providers.Placetopay.Webcheckout.ST_OK ? 1 : Providers.Placetopay.Webcheckout.StatusConvert(result.Status)
            });

            return result;
        }

        /// <summary>
        /// Obtiene y actualiza la información de un pago.
        /// </summary>
        public async static Task<Providers.Placetopay.Contracts.InformationRequest> GetRequestInformation(int companyId, int userId, Int64 requestId, bool updateStatus = false)
        {
            Providers.Placetopay.Contracts.InformationRequest result = null;
            Contracts.OnlinePayment currentRecord = Business.OnlinePayment.RetrieveByRequestID(companyId, requestId);

            if (currentRecord != null)
            {
                result = await Providers.Placetopay.Webcheckout.GetRequestInformation(requestId, currentRecord.Currency);
                if (updateStatus && result.status.status != currentRecord.ProviderStatus)
                {
                    UpdateStatus(userId, currentRecord, result);
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
        /// Procesa y valida una notificación de pago.
        /// </summary>
        public async static Task Notify(int companyId, int userId, Integrations.Providers.Placetopay.Contracts.NotifyRequest notify)
        {
            Contracts.OnlinePayment currentRecord = Business.OnlinePayment.RetrieveByRequestID(companyId, Convert.ToInt64(notify.requestId));
            if (currentRecord != null)
            {
                string signature = Providers.Placetopay.Webcheckout.NotifySignature(notify, currentRecord.Currency);

                if (signature == notify.signature)
                {
                    Providers.Placetopay.Contracts.InformationRequest result = await Providers.Placetopay.Webcheckout.GetRequestInformation(Convert.ToInt64(notify.requestId), currentRecord.Currency);
                    if (result.status.status != currentRecord.ProviderStatus)
                    {
                        UpdateStatus(userId, currentRecord, result);
                    }
                }
            }
        }

        /// <summary>
        /// Actualiza la información relacionada con un pago.
        /// </summary>
        private static void UpdateStatus(int userId, OnlinePayment currentRecord, InformationRequest result)
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
        }

        public static int IdentificationTypeConvert(string identificationType)
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
