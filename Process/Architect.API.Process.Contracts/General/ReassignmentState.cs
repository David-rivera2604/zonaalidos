namespace Architect.API.Process.Contracts.General
{
    /// <summary>
    /// Estados de una reasignación. Alineado con LookupMaster Id:161 (ProcessState).
    /// </summary>
    public enum ReassignmentState
    {
        /// <summary>
        /// Reasignación generada de forma automática por el sistema.
        /// </summary>
        Automatico = 1,

        /// <summary>
        /// Reasignación originada desde un caso.
        /// </summary>
        Caso = 2,

        /// <summary>
        /// Reasignación manual.
        /// </summary>
        Reasignacion = 3
    }
}
