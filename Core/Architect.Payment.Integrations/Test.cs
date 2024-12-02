using Architect.Payment.Integrations.Providers.Placetopay.Contracts;
using Architect.Payment.Integrations.Providers.Placetopay.Contracts.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Architect.Payment.Integrations
{
    public static class Test
    {


        public static void Doing()
        { 
            
            string reference = "31185";
            string description = "MAPFRE: AUTOMOVILES. MAPFRE MAS. POLIZA #3021910103696 RECIBO #11049219";
            string email = "solernelson@hotmail.com";
            double amount = 17154.33;
            string moneda = "CRC";

            Auth auth = Providers.Placetopay.Webcheckout.BuildAuth("Recurring", moneda);

            PaymentLink pl = new PaymentLink()
            {
                auth = auth,
                locale = "es_CR",
                name = description,
                paymentsAllowed = 1,
                expirationDate = DateTime.Now.AddMinutes(Utilities.Helpers.Settings.IntegerValue("Payment.Placetopay.TimeOut", 10)),
                paymentExpiration = Utilities.Helpers.Settings.IntegerValue("Payment.Placetopay.TimeOut", 10),
                currency = moneda,
                amount = amount,
                reference = reference,
                description = description,
                receiverEmails = new string[] { email }
            };


            string pl_json = JsonConvert.SerializeObject(pl);


            Providers.Placetopay.Contracts.Responses.PaymentLink result = Architect.Payment.Integrations.Providers.Placetopay.Webcheckout.PaymentLink(pl).Result;
        }

    }

}
