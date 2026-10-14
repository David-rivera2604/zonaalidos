using System;

namespace Architect.API.Tron.Contracts.Masivos
{
    /// <summary>
    /// Representa un registro de error o advertencia retornado por el procedimiento p_procesar_archivo.
    /// Si la colección viene vacía, el proceso fue exitoso.
    /// </summary>
    public class MasivoErrorDetalle
    {
        /// <summary>Número de proceso generado durante la validación.</summary>
        public int num_proceso { get; set; }

        /// <summary>Código de estructura procesada.</summary>
        public string cod_estructura { get; set; }

        /// <summary>Número de registro del CSV donde se detectó el error.</summary>
        public int num_registro { get; set; }

        /// <summary>Tipo de error o advertencia (E = Error, A = Advertencia).</summary>
        public string tip_error { get; set; }

        /// <summary>Descripción del error.</summary>
        public string txt_error { get; set; }

        /// <summary>Ruta o campo específico donde se originó el error.</summary>
        public string txt_ruta_error { get; set; }

        /// <summary>Código del usuario que ejecutó el proceso.</summary>
        public int cod_usr { get; set; }

        /// <summary>Fecha de actualización del registro.</summary>
        public DateTime fec_actu { get; set; }
    }
}
