using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Variaciones
{
    public interface IVariableDataProvider
    {
        Dictionary<string, string> GetVariableData();
    }
}
