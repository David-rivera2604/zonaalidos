namespace Architect.API.Tron.Contracts.Masivos
{
    /// <summary>
    /// Avance de un procesamiento individual, usado en la consulta de resultados por lote.
    /// </summary>
    public class MasivoResultadoProceso
    {
        public int id { get; set; }
        public int num_proceso { get; set; }
        public string mensaje { get; set; }
        public bool finalizado { get; set; }
    }
}
