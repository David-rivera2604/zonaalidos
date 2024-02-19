using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Contracts.v2
{
    internal class TokenizerRequest
    {

        public string data0 { get; set; }
        public Client client { get; set; }
        public string origen { get; set; }
        public bool validar { get; set; }

    }

    internal class Client
    {
        public string email { get; set; }
        public string name { get; set; }
        public string fiscal_number { get; set; }
        public Dataextra dataExtra { get; set; }
    }

    internal class Dataextra
    {
        public string productExternal { get; set; }
        public string externalClientId { get; set; }
    }

}
