using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Contracts.v2
{
    public class DatosTarjeta : DatosTarjetaBase
    {

        public string tip_docum { get; set; }
        public string cod_docum { get; set; }
        public string email { get; set; }

        public string card { get; set; }
        public string token { get; set; }
        public string clientId { get; set; }

        public bool status { get; set; }
        public string reason { get; set; }

        [JsonIgnore]
        public string key { get; set; }

    }
}
