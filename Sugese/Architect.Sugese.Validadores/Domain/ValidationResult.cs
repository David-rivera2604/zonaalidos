using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Sugese.Validadores.Domain
{
    public class ValidationResult
    {
        public bool Successfully { get; set; }

        public List<Message> Messages { get; set; } = new List<Message>();
    }

    [DebuggerDisplay("{Id} {Value}")]
    public class Message
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }

    }
}