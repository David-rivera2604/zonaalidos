using Architect.Payment.Integrations.Providers.Placetopay.Contracts;
using Architect.Payment.Integrations.Providers.Placetopay.Contracts.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations
{
    public static class Test
    {

        public static void DoTokenize()
        {
            var body = new Tokenize()
            {
                auth = Architect.Payment.Integrations.Providers.Placetopay.Webcheckout.BuildAuth(0, "CRC", 0, 0),
                payer = new Person()
                {
                    name = "Diego",
                    surname = "Calle",
                    email = "dnetix@yopmail.com"
                },
                instrument = new Instrument()
                {
                    card = new Card()
                    {
                        number = "5180300000000005",
                        expiration = "12/18",
                        cvv = "123",
                        installments = 3
                    }
                },
                ipAddress = "127.0.0.1",
                userAgent = "Testing"
            };

            string json = JsonConvert.SerializeObject(body);


            var result = Architect.Payment.Integrations.Providers.Placetopay.Webcheckout.Tokenize(body).Result;

        }

    }
}
