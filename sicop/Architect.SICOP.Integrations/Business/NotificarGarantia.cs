using Architect.SICOP.Integrations.RcvGurtWS;
using Architect.SICOP.Integrations.ResultGurtWS;
using Architect.SICOP.Integrations.SupplierInfoWS;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Architect.SICOP.Integrations.Business
{
    public class NotificarGarantia
    {

        static public RcvGurtWS.GurtResponseBean RcvGurtWService(RcvGurtBean request, int companyId)
        {
            RcvGurtWS.GurtResponseBean result = null;
            receiveGuaranteeResponse internalResult = null;

            var session = API.Core.Business.Traza.TrackRequest.NewSession(new API.Core.Contracts.Security.Token() { CompanyId = companyId }, "SICOP/RcvGurtWS/RcvGurtWService", request);
            try
            {
                using (RcvGurtWServiceClient client = new RcvGurtWServiceClient())
                {
                    internalResult = client.receiveGuarantee(new receiveGuaranteeRequest()
                    {
                        Body = new receiveGuaranteeRequestBody()
                        {
                            rcvGurtBean = request
                        }
                    });
                    client.Close();
                }
                if (internalResult?.Body?.@return != null)
                {

                    result = internalResult.Body.@return;
                }
            }
            catch (Exception ex)
            {
                string code = Architect.Utilities.Log.ErrorLog(ex, session.MessageId);

                session.ResponseStatus = 500;
                session.ResponseText = $"{ex.Message} ({code})";
            }
            API.Core.Business.Traza.TrackRequest.CloseSession(session, internalResult);


            return result;
        }

    }
}
