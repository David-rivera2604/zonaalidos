using System;

namespace Architect.API.Tron.Contracts.Batch
{
    /// <summary>
    ///  Procesos masivos (G2000510)
    /// </summary>
    public partial class Proceso
    {
        /// <summary>
        ///  Fecha en la que se realiza el proceso masivo
        /// </summary>
        public DateTime fec_tratamiento { get; set; }

        /// <summary>
        ///  Número del proceso masivo
        /// </summary>
        public int num_orden { get; set; }

        /// <summary>
        ///  Tipo del proceso masivo
        /// </summary>
        public string tip_mvto_batch { get; set; }

        /// <summary>
        ///  Código de compañía
        /// </summary>
        public int cod_cia { get; set; }

        /// <summary>
        ///  Nombre que se quiera dar al proceso
        /// </summary>
        public string txt_alias { get; set; }

        /// <summary>
        ///  Situación del movimiento
        /// </summary>
        public string tip_situ_filtro { get; set; }

        /// <summary>
        ///  Procedimiento de excepción
        /// </summary>
        public string nom_prg_excepcion { get; set; }

        /// <summary>
        ///  Marca que indica si se toma como base la fecha que ya esta calculado o se vuelve a calcular
        /// </summary>
        public string mca_recalcula_fecha { get; set; }

        /// <summary>
        ///  Indica en base a que fecha se hará el re-calculo de la fecha
        /// </summary>
        public string tip_fecha_base { get; set; }

        /// <summary>
        ///  Usuario que actualizo la fila
        /// </summary>
        public string cod_usr { get; set; }

        /// <summary>
        ///  Fecha de la ultima actualización del registro
        /// </summary>
        public DateTime fec_actu { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string num_presupuesto { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int num_riesgo { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string num_poliza_definitivo { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string txt_error { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string txt_ruta_error { get; set; }
    }
}