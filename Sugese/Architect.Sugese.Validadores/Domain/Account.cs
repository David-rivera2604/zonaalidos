using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Sugese.Validadores.Domain
{
    [DebuggerDisplay("{Id} {Name}, {Amount}")]
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}
