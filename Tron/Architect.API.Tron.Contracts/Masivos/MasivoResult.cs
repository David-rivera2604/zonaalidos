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
        }

        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
        public List<string> Errores { get; set; }
    }
}
