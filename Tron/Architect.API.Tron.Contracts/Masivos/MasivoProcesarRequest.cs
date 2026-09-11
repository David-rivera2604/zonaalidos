namespace Architect.API.Tron.Contracts.Masivos
{
    /// <summary>
    /// Modelo de request para procesar una carga masiva.
    /// </summary>
    public class MasivoProcesarRequest
    {
        public int id { get; set; }
        public int codRamo { get; set; }
        public string fileName { get; set; }
    }
}
