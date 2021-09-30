namespace Architect.Insurance.Contracts.Interfaces
{
    /// <summary>
    /// Interfaz común para contratos de datos particulares.
    /// </summary>
    /// <remarks>VT.NONE</remarks>
    public interface IParticularData
    {

        /// <summary>
        /// Monto de capital asegurado.
        /// </summary>
        /// <remarks>VT.TABLA.NCAPITAL</remarks>
        decimal InsuredAmount { get; set; }

        /// <summary>
        /// Monto complemento del capital asegurado.
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        decimal InsuredAmountComplement { get; set; }

    }
}
