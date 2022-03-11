using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Utilities.Contracts
{
    public class LookUpValue : Architect.Utilities.Helpers.Expando
    {

        public string Code { get; set; }
        public string Description { get; set; }

    }
}
