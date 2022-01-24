namespace Architect.API.Tron.Contracts.Presupuesto.API
{
    /// <summary>
    ///  Ocurrencias del presupuesto (P2000025)
    /// </summary>
    public class Ocurrencia
    {

        /// <summary>
        ///  Número de ocurrencia
        /// </summary>
        public int num_ocurrencia { get; set; }

        /// <summary>
        ///  Nombre del dato variable
        /// </summary>
        public string cod_campo { get; set; }

        /// <summary>
        ///  Valor
        /// </summary>
        public string val_campo { get; set; }

    }
}