using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Architect.SICOP.WcfService.Contracts
{
    public class ElectronicWarranty
    {

        public int ID { get; set; }
        public string Guarantee_sequencenumber { get; set; }
        public string Moneda { get; set; }
        public string Metodo { get; set; }
        public string Codigo_Proceso { get; set; }

    }
}