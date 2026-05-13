namespace Architect.API.Tron.Contracts.Masivos
{
    /// <summary>
    /// Modelo de request para procesar una carga masiva.
    /// </summary>
    public class MasivoProcesarRequest
    {
        public int codRamo { get; set; }
        public string fileName { get; set; }
    }
}
