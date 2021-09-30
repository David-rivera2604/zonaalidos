namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Información del agente
    /// </summary>
    public class AgentInformation
    {
        /// <summary>
        ///  Agente
        /// </summary>
        public int cod_agt { get; set; }

        /// <summary>
        ///  Sub Agente
        /// </summary>
        public int cod_sub_agt { get; set; }

        /// <summary>
        ///Nombre del agente
        /// </summary>
        public string info_agt { get; set; }

        /// <summary>
        ///  Tipo del documento
        /// </summary>
        public string tip_docum { get; set; }

        /// <summary>
        ///  Documento
        /// </summary>
        public string cod_docum { get; set; }
    }
}
