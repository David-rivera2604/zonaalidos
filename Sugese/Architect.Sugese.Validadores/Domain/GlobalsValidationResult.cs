using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Sugese.Validadores.Domain
{
     
    public class GlobalsValidationResult
    {
        public Dictionary<string, double> catalog;

        public dynamic model { get; set; }

        public bool Successfully { get; set; } = true; 


        public double Value { get; set; } = double.MinValue;

        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
