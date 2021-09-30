using System;
using System.Collections.Generic;

namespace Architect.API.Tron.Contracts.Poliza
{
    /// <summary>
    ///  Información de la variación
    /// </summary>
    public class Variacion
    {
        /// <summary>
        ///  Ramo
        /// </summary>
        public int cod_ramo { get; set; }

        /// <summary>
        ///  Póliza
        /// </summary>
        public string num_poliza { get; set; }

        /// <summary>
        ///  Riesgo
        /// </summary>
        public int num_riesgo { get; set; }

        /// <summary>
        ///  Fecha de validez
        /// </summary>
        public DateTime fec_validez { get; set; }

        /// <summary>
        ///  Observación
        /// </summary>
        public string txt_obs { get; set; }

        /// <summary>
        ///  Detalle de la variación
        /// </summary>
        public List<DatoVariacion> Detalle { get; set; }

    }

    /// <summary>
    ///  Detalle de la variación
    /// </summary>
    public class DatoVariacion
    {
        /// <summary>
        ///  Nombre del dato variable
        /// </summary>
        public string cod_campo { get; set; }

        /// <summary>
        ///  Valor anterior
        /// </summary>
        public string val_campo_ant { get; set; }

        /// <summary>
        ///  Valor actual
        /// </summary>
        public string val_campo_act { get; set; }

    }

}