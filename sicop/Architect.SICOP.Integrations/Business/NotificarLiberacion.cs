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
    public class NotificarLiberacion
    {

        static public ResultGurtWS.GurtResponseBean ResultGurtWService(ResultGurtBean request)
        {
            ResultGurtWS.GurtResponseBean result = null;
            resultGuaranteeResponse internalResult = null;
            using (ResultGurtWServiceClient client = new ResultGurtWServiceClient())
            {
                internalResult = client.resultGuarantee(new resultGuaranteeRequest()
                {
                    Body = new resultGuaranteeRequestBody()
                    {
                        resultGurtBean = request

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
