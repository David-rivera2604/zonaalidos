using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts
{
    /// <summary>
    /// Estructura que refleja la información de una persona involucrada en una transacción.
    /// </summary>
    public class Person
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string document { get; set; }
        public string documentType { get; set; }
        public string mobile { get; set; }
    }
}
