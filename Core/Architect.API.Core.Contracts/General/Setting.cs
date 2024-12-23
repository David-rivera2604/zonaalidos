using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Contracts.General
{
    public class Setting
    {
        public int CompanyId { get; set; }
        public string Key { get; set; }

        public string Value { get; set; }

        public bool LocalStorageEnabled { get; set; }
        public bool TokenEnabled { get; set; }
    }
}