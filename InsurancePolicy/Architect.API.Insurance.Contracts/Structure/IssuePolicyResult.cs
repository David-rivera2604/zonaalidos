using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Insurance.Contracts.Structure
{
    public class IssuePolicyResult : BehaviorResult
    {
        public Contracts.Policy.Risk Risk { get; set; }

    }
}
