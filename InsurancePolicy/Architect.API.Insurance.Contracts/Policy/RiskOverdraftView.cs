using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Información de los prestamos vinculados a una póliza.
    /// </summary>
    [Serializable(), DataContract()]
    public class RiskOverdraftView : RiskOverdraft
    {
    }
}

