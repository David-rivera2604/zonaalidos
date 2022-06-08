using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Insurance.Contracts.Structure
{
    public class BehaviorResult
    {
        public string Behavior { get; set; }

        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}
