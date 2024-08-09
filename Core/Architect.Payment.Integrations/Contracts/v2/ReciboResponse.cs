using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Contracts.v2
{

    public class ReciboResponse
    {
        public string procesoId { get; set; }

        public List<ReciboResponseItem> items { get; set; }

    }

    public class ReciboResponseItem
    {
        public string status { get; set; }
        public string ordenId { get; set; }
        public string card_number { get; set; }

        public Resultado_Pasarela resultado_pasarela { get; set; }

    }


}
