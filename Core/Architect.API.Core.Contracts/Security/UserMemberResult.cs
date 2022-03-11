using System.Collections.Generic;

namespace Architect.API.Core.Contracts.Security
{
    public partial class UserMemberResult
    {
        public Contracts.Security.UserMember UserMember { get; set; }

        public List<Core.Contracts.General.Error> Errors { get; set; }

    }
}

