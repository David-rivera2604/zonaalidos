using System.Data;
using System.Diagnostics;

namespace Architect.DataFactory.Contracts
{

    /// <summary>
    /// Estructura para manejar el objeto command
    /// </summary>
    [DebuggerDisplay("{Name}")]
    public class Parameter
    {
        public string Name { get; set; }

        public Architect.DataFactory.Enumerations.DbType Type { get; set; }

        public int Size { get; set; }

        public object Value { get; set; }

        public ParameterDirection direction { get; set; }

        public bool Filter { get; set; }
        public string LogicOperator { get; set; }
    }
}