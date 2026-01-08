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
    public class InformacionProveedor
    {

        static public Contracts.SUPPLIER_INFO SupplierInfo(string supplier_identifier, int companyId)
        {
            getSupplierInfoResponse result = null;
            Contracts.SUPPLIER_INFO info = new Contracts.SUPPLIER_INFO()
            {
                Confirmation = "3",
                Msg_err = "Ha ocurrido un error al intentar consultar la información del proveedor"
            };
            getSupplierInfoRequest request = new getSupplierInfoRequest()
            {
                Body = new getSupplierInfoRequestBody() { supplier_identifier = supplier_identifier }
            };
            var session = API.Core.Business.Traza.TrackRequest.NewSession(new API.Core.Contracts.Security.Token() { CompanyId = companyId }, "SICOP/SupplierInfoWS/SupplierInfoWService", request);

            try
            {
                using (SupplierInfoWServiceClient client = new SupplierInfoWServiceClient())
                {
                    result = client.getSupplierInfo(request);
                    client.Close();
                }

                if (result.IsNotEmpty() && result.Body.IsNotEmpty() && result.Body.@return.IsNotEmpty())
                {
                    info = Utilities.SerializeHandler<Contracts.SUPPLIER_INFO>.Deserialize(result.Body.@return);

                    switch (info.Confirmation)
                    {
                        case "3":
                            info.Msg_err = "Ha ocurrido un error al intentar consultar la información del proveedor";
                            break;
                        case "5":
                            info.Msg_err = $"No existe información registra del proveedor con número de identificación {supplier_identifier}";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                string code = Architect.Utilities.Log.ErrorLog(ex, session.MessageId);

                session.ResponseStatus = 500;
                session.ResponseText = $"{ex.Message} ({code})";
            }
            API.Core.Business.Traza.TrackRequest.CloseSession(session, info);


            return info;
        }

    }
}
