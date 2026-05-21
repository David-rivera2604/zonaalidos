using System.Collections.Generic;

namespace Architect.API.Tron.Contracts.Masivos
{
    /// <summary>
    /// Resultado de las operaciones de carga masiva.
    /// </summary>
    public class MasivoResult
    {
        public MasivoResult()
        {
            Errores = new List<string>();
            Detalles = new List<MasivoErrorDetalle>();
        }

        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
        public List<string> Errores { get; set; }

        /// <summary>
        /// Colección de errores o advertencias por registro. 
        /// Si viene vacía el procesamiento fue exitoso.
        /// </summary>
        public List<MasivoErrorDetalle> Detalles { get; set; }
    }
}
