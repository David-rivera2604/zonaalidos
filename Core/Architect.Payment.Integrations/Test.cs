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

  
        public static void DoTokenize()
        {
            Auth auth = Providers.Placetopay.Webcheckout.BuildAuth("d47ba34d7872700bd4859d52db7de97a", "Sc8985wd6M8RSSc9"); //Providers.Placetopay.Webcheckout.BuildAuth(0, "CRC", 0, 0);



            var body = new Providers.Placetopay.Contracts.Requests.Tokenize()
            {
                auth = auth,
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
