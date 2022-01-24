namespace Architect.API.Tron.Contracts.Presupuesto.API
{
    /// <summary>
    ///  Datos variables del presupuesto
    /// </summary>
    /// <remarks> Tabla física P2000020 </remarks>
    public class DatoVariable
    {
        /// <summary>
        ///  Nombre del dato variable
        /// </summary>
        public string cod_campo { get; set; }

        /// <summary>
        ///  Valor
        /// </summary>
        public string val_campo { get; set; }

        /// <summary>
        ///  Descripción
        /// </summary>
        public string txt_campo { get; set; }

    }
}