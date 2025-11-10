using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Sugese.Validadores.Domain
{
    [DebuggerDisplay("{Id} {Left} {Right} {Target}")]
    public class Inspection 
    {
        public int Id { get; set; }
        public string Target { get; set; }
        public string Left { get; set; }
        public string Tag { get; set; }
        public string Right { get; set; }
        public string Message { get; set; }
    } 
}
