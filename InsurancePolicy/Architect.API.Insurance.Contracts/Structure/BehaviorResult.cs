using System.Collections.Generic;

namespace Architect.API.Insurance.Contracts.Structure
{
    public class BehaviorResult
    {
        public string Behavior { get; set; }

        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}
