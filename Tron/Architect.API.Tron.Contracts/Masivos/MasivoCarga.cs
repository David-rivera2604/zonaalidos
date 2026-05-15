using System;

namespace Architect.API.Tron.Contracts.Masivos
{
    /// <summary>
    /// Representa un registro de carga masiva almacenado en la tabla aliados.masivos.
    /// </summary>
    public class MasivoCarga
    {
        public int cod_cia { get; set; }
        public int cod_ramo { get; set; }
        public string cod_estructura { get; set; }
        public string txt_archivo_carga { get; set; }
        public int num_tam_archivo { get; set; }
        public string archivo_carga { get; set; }
        public int cod_usr { get; set; }
        public DateTime fec_actu { get; set; }
        public string estado { get; set; }
        public string resultado_proceso { get; set; }
    }
}
