using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Insurance.Business.Structure
{
    public class IssuePolicyResult
    {
        public Contracts.Policy.Risk Risk { get; set; }

        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}
