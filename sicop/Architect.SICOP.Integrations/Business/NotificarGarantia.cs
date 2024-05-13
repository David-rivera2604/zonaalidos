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

        static public RcvGurtWS.GurtResponseBean RcvGurtWService(RcvGurtBean request)
        {
            RcvGurtWS.GurtResponseBean result = null;
            receiveGuaranteeResponse internalResult = null;
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
            return result;
        }

    }
}
